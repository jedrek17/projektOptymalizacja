
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using NCalc;



namespace Optymalizacja
{
    partial class Form1
    {
        // tutaj bedziemy umieszczac roznego rodzaju zmienne wykorzystywane w programie 
        double scale = 0.05; // skala wyswitlanego wykresu
        int stepNumber = 0;
        int lastStepNumber = 0;
        public static string sExpression = "";

        //cPoint-------------------------------------------------------------------------------------
        public class cPoint
        {
            public double[] wsp;    //współrzędne
            public double y;    //wartość funkcji w punkcie

            public cPoint(int n)    //n - ile współrzędnych ma jeden punkt
            {
                wsp = new double[n];
            }



            public void liczP() //oblicza wartość funkcji w punkcie
            {
                //y = rownanieTestowe(wsp[0], wsp[1]);
                if (wsp.Length == 2)
                    y = getValFromExpression(wsp[0], wsp[1]);
                else if (wsp.Length == 3)
                    y = getValFromExpression(wsp[0], wsp[1], wsp[2]);
                else
                    y = getValFromExpression(wsp);
            }



            public bool kopiujZeZrodla(cPoint zrodlo)   //przepisuje wszystkie pola z obiektu podanego jako źródło
            {
                if (this.wsp.Length != zrodlo.wsp.Length)
                    return false;

                for (int i = 0; i < this.wsp.Length; i++)
                    this.wsp[i] = zrodlo.wsp[i];
                this.y = zrodlo.y;
                return true;
            }



            public void zerujWspolrzedne()
            {
                for (int i = 0; i < wsp.Length; i++)
                    wsp[i] = 0;
                liczP();
            }
        }

        //cSimplex-------------------------------------------------------------------------------------

        public class cSimplex
        {
            public cPoint[] pkt;

            public cSimplex(int n) //n - z ilu punktów składa się simpleks
            {
                pkt = new cPoint[n];
                for (int i = 0; i < n; i++)
                    pkt[i] = new cPoint(n - 1);   //simpleks ma rozmiar o jeden większy niż ilość wymiarów zadania
            }



            public cSimplex(cSimplex simp)
            {
                pkt = new cPoint[simp.pkt.Length];
                for (int i = 0; i < simp.pkt.Length; i++)
                    pkt[i] = new cPoint(simp.pkt.Length - 1);
                this.kopiujZeZrodla(simp);
            }



            public void liczS() //oblicza wartość każdego punktu simpleksu
            {
                for (int i = 0; i < pkt.Length; i++)
                   pkt[i].liczP();
            }



            public bool kopiujZeZrodla(cSimplex zrodlo)   //przepisuje wszystkie pola z obiektu podanego jako źródło
            {
                if (this.pkt.Length != zrodlo.pkt.Length)
                    return false;

                for (int i = 0; i < this.pkt.Length; i++)
                    this.pkt[i].kopiujZeZrodla(zrodlo.pkt[i]);
                return true;
            }



            public void sortujS()   //sortuje punkty simpleksu od najmniejszego do największego; wymaga zwykle najpierw użycia liczS()
            {
                cPoint tmp = new cPoint(pkt.Length - 1);

                for (int j = pkt.Length - 1; j > 0; j--)
                    for (int i = 0; i < j; i++)
                        if (pkt[i].y > pkt[i + 1].y)
                        {
                            tmp.kopiujZeZrodla(pkt[i]); //tmp = pkt[i];
                            pkt[i].kopiujZeZrodla(pkt[i + 1]);    //pkt[i].y = pkt[i+1];
                            pkt[i + 1].kopiujZeZrodla(tmp); //pkt[i+1] = tmp;
                        }
            }
        }

        //cSimplexSolver-------------------------------------------------------------------------------------

        public class cSimplexSolver
        {
            public int n, krok, l;          //n-wymiarowa funkcja, krok - liczy ilość iteracji solvera, l - max kroków
            public double epsilon, ekspansja = 2.1, kontrakcja = 0.5, skurczenie = 0.5;  //parametry do ustawienia w konstruktorze
            public cSimplex simpPocz, simpTemp;    //simpleks początkowy, roboczy
            public List<cSimplex> listaSimp;
            public bool minZnaleziony;
            public double []xmin;// = new double[3];
            public double []xmax;// = new double[3];

            public bool fl_eks, fl_konDoSr, fl_konNaZew, fl_sku;    // <(*)> - znacznik flag do znalezienia błędu

            public cSimplexSolver(int n, double epsilon, int l, double x1min, double x2min, double x3min, double x1max, double x2max, double x3max, double ekspansja = 2.1, double kontrakcja = 0.5, double skurczenie = 0.5)   //n - ilość wymiarów funkcji, epsilon - warunek stopu
            {
                this.n = n;
                this.epsilon = epsilon;
                this.l = l;
                xmin = new double[n+1];
                xmax = new double[n+1];
                krok = 0;

                xmin[0] = x1min;
                xmin[1] = x2min;
                xmin[2] = x3min;
                xmax[0] = x1max;
                xmax[1] = x2max;
                xmax[2] = x3max;
                for (int i = 3; i < n; i++)
                {
                    xmin[i] = -10; // wartosci domyslne
                    xmax[i] = 10; 
                }

                if (ekspansja > 1.0)   //poniższe parametry muszą przyjmować wartości z odpowiednich zakresów (http://akson.sgh.waw.pl/~jd37272/MO/mo_zaj3.pdf)
                        this.ekspansja = ekspansja;
                if (kontrakcja > 0 && kontrakcja < 1)
                    this.kontrakcja = kontrakcja;
                if (skurczenie > 0 && skurczenie < 1)
                    this.skurczenie = skurczenie;

                simpPocz = new cSimplex(n + 1);   //simpleks składa się zawsze z 1 punktu więcej niż rozmiar zadania
                simpTemp = new cSimplex(n + 1);

                Random rand = new Random();
                for (int i = 0; i < (n + 1); i++) //pętle losują każdą współrzędną dla każdego punktu
                    for (int j = 0; j < n; j++)
                        simpPocz.pkt[i].wsp[j] = rand.NextDouble()*(xmax[j]-xmin[j])+xmin[j];

                fl_eks = false;
                fl_konDoSr = false;
                fl_konNaZew = false;
                fl_sku = false;             //<(*)>

                minZnaleziony = false;
                listaSimp = new List<cSimplex>();
                simpPocz.liczS();
            }



            public void print()
            {
                listaSimp.Add(new cSimplex(simpTemp));
            }


            
            private cPoint liczPolepszonySrCiezk(cSimplex simp)
            {
                cPoint punkt = new cPoint(n);
                punkt.zerujWspolrzedne();

                cSimplex simpKopia = new cSimplex(simp.pkt.Length);
                simpKopia.kopiujZeZrodla(simp);

                simpKopia.sortujS();

                for (int i = 0; i < simpKopia.pkt[0].wsp.Length; i++)    //pętla poruszająca się po współrzędnych
                {
                    for (int j = 0; j < (simpKopia.pkt.Length-1); j++)     //pętla poruszająca się po kolejnych punktach Simpleksu (za wyjątkiem największego - ostatniego)
                        punkt.wsp[i] += simpKopia.pkt[j].wsp[i];         //sumuje tą samą współrzędną z kolejnych punktów
                    punkt.wsp[i] /= simpKopia.pkt.Length-1;         //dzieli sumę przez ilość punktów -1
                }
                return punkt;
            }



            /*private cSimplex ekspansjaSimpleksu(cSimplex simpZew) //działa jak funkcja - nie dotyka nawet obiektu który ją wykonuje
            {
                cSimplex simp = new cSimplex(simpZew.n);
                simp.kopiujZeZrodla(simpZew);

                return simp;
            }*/
            public cPoint odbicieSimpleksu(cSimplex simp) //poniższych pięciu metod używać zawsze z posortowanym simpleksem <<<---!!!
            {
                cPoint srCiez = new cPoint(n);
                srCiez.kopiujZeZrodla(liczPolepszonySrCiezk(simp));
                cPoint pktWynikowy = new cPoint(n);
                pktWynikowy.zerujWspolrzedne();

                for (int i=0; i<n; i++)   //pętla omiatająca współrzędne
                    pktWynikowy.wsp[i] = 2*srCiez.wsp[i] - simp.pkt[simp.pkt.Length-1].wsp[i]; //2*srCiezkosci-najgorszyPunkt

                pktWynikowy.liczP();
                return pktWynikowy;
                //simp.pkt[simp.pkt.Length-1].kopiujZeZrodla(pktWynikowy);    //przypisanie na najgorszy punkt nowego-odbitego punktu
            }


            //private
            public cPoint ekspansjaSimpleksu(cSimplex simp, cPoint odbityPkt)  //dla zaoszczędzenia nieco obliczeń przekazuje się odbity punkt (odbity za pomocą metody powyżej)
            {
                cPoint srCiez = new cPoint(n);
                srCiez.kopiujZeZrodla(liczPolepszonySrCiezk(simp));
                cPoint pktWynikowy = new cPoint(n);
                pktWynikowy.zerujWspolrzedne();

                for (int i = 0; i < n; i++)   //pętla omiatająca współrzędne
                    pktWynikowy.wsp[i] = srCiez.wsp[i] + ekspansja*(odbityPkt.wsp[i] - srCiez.wsp[i]);    //srCiezkosci + wspEkspansji*(odbityPkt - srCiezkosci)

                pktWynikowy.liczP();
                fl_eks = true;  //  <(*)>
                return pktWynikowy;
            }


            //private
            public cPoint kontrakcjaSimpleksuDoSr(cSimplex simp)
            {
                cPoint srCiez = new cPoint(n);
                srCiez.kopiujZeZrodla(liczPolepszonySrCiezk(simp));
                cPoint pktWynikowy = new cPoint(n);
                pktWynikowy.zerujWspolrzedne();

                for (int i = 0; i < n; i++)   //pętla omiatająca współrzędne
                    pktWynikowy.wsp[i] = srCiez.wsp[i] + kontrakcja*(simp.pkt[simp.pkt.Length-1].wsp[i] - srCiez.wsp[i]);    //srCiezkosci + wspKontrakcji*(najgorszyPkt-srCiezkosci)

                pktWynikowy.liczP();
                fl_konDoSr = true;  //  <(*)>
                return pktWynikowy;
            }


            //private
            public cPoint kontrakcjaSimpleksuNaZew(cSimplex simp, cPoint odbityPkt)
            {
                cPoint srCiez = new cPoint(n);
                srCiez.kopiujZeZrodla(liczPolepszonySrCiezk(simp));
                cPoint pktWynikowy = new cPoint(n);
                pktWynikowy.zerujWspolrzedne();

                for (int i = 0; i < n; i++)   //pętla omiatająca współrzędne
                    pktWynikowy.wsp[i] = srCiez.wsp[i] + kontrakcja * (odbityPkt.wsp[i] - srCiez.wsp[i]);    //srCiezkosci + wspKontrakcji*(odbityPkt-srCiezkosci)

                pktWynikowy.liczP();
                fl_konNaZew = true;  //  <(*)>
                return pktWynikowy;
            }



            //private
            public cSimplex skurczenieSimpleksu(cSimplex simp)
            {
                cPoint srCiez = new cPoint(n);
                srCiez.kopiujZeZrodla(liczPolepszonySrCiezk(simp));
                cPoint pktWynikowy = new cPoint(n);
                pktWynikowy.zerujWspolrzedne();
                cSimplex simpWynikowy = new cSimplex(simp.pkt.Length);

                for(int j=0; j<simp.pkt.Length; j++)        //pętla omiatająca kolejne punkty - j
                    for (int i=0; i<n; i++)                 //pętla omiatająca współrzędne - i
                        simpWynikowy.pkt[j].wsp[i] = simp.pkt[0].wsp[i] + skurczenie*(simp.pkt[j].wsp[i]-simp.pkt[0].wsp[i]);  //pkt[j]=pkt[0]+wspSkurczenia*(pkt[j]-pkt[0]) gdzie pkt[0] to najmniejszy-najlepszy punkt

                simpWynikowy.liczS();
                fl_sku = true;  //  <(*)>
                return simpWynikowy;
            }



            private bool stopSpelniony(cSimplex simp)
            {
                cPoint punkt = new cPoint(n);
                punkt.zerujWspolrzedne();
                
                for (int i = 0; i < simp.pkt[0].wsp.Length; i++)    //pętla poruszająca się po współrzędnych
                {
                    for (int j = 0; j < simp.pkt.Length; j++)     //pętla poruszająca się po kolejnych punktach Simpleksu
                        punkt.wsp[i] += simp.pkt[j].wsp[i];         //sumuje tą samą współrzędną z kolejnych punktów
                    punkt.wsp[i] /= simp.pkt.Length;         //dzieli sumę przez ilość punktów

                    for (int j = 0; j < simp.pkt.Length; j++)   //j - po punktach
                        if (Math.Abs(punkt.wsp[i] - simp.pkt[j].wsp[i]) > epsilon)
                            return false;
                }
                return true;
            }



            public void solveSimp()
            {
                cPoint pktOdbity = new cPoint(n);
                cPoint pktTemp = new cPoint(n);
                krok = 0;
                simpTemp.kopiujZeZrodla(simpPocz);
                simpTemp.liczS();
                simpTemp.sortujS();
                print();
                while(!stopSpelniony(simpTemp) && krok<l)      //  <<<---!!! - docelowo zmienić na prawidłowy warunek stopu
                {
                    pktOdbity.kopiujZeZrodla(odbicieSimpleksu(simpTemp));   //tworzy odbicie najgorszego punktu

                    if(pktOdbity.y<simpTemp.pkt[0].y)   //aR<aL
                    {
                        pktTemp.kopiujZeZrodla(ekspansjaSimpleksu(simpTemp,pktOdbity));
                        //if (pktTemp.y < pktOdbity.y)  //stara wersja warunku
                        if(pktOdbity.y < simpTemp.pkt[0].y)
                            simpTemp.pkt[simpTemp.pkt.Length-1].kopiujZeZrodla(pktTemp);
                        //else if (pktTemp.y >= pktOdbity.y)    //stara wersja warunku
                        else
                            simpTemp.pkt[simpTemp.pkt.Length-1].kopiujZeZrodla(pktOdbity);
                    }

                    //else if(pktOdbity.y>=simpTemp.pkt[simpTemp.pkt.Length-2].y)   // stary, błędny warunek // aR>aSH; -2 ponieważ -1 to najgorszy, a -2 to drugi najgorszy
                    else
                    {
                        bool jest_poprawa = false;
                        if ((pktOdbity.y < simpTemp.pkt[simpTemp.pkt.Length-1].y) && (pktOdbity.y >= simpTemp.pkt[simpTemp.pkt.Length - 2].y))   //aR<aH
                        {
                            pktTemp.kopiujZeZrodla(kontrakcjaSimpleksuNaZew(simpTemp, pktOdbity));
                            if (pktTemp.y < simpTemp.pkt[simpTemp.pkt.Length - 1].y)
                            {
                                simpTemp.pkt[simpTemp.pkt.Length - 1].kopiujZeZrodla(pktTemp);
                                jest_poprawa = true;
                            }
                        }
                        else //if (pktOdbity.y >= simpTemp.pkt[simpTemp.pkt.Length-1].y)    //aR>aH
                        {
                            pktTemp.kopiujZeZrodla(kontrakcjaSimpleksuDoSr(simpTemp));
                            if(pktTemp.y < simpTemp.pkt[simpTemp.pkt.Length-1].y)
                            {
                                simpTemp.pkt[simpTemp.pkt.Length-1].kopiujZeZrodla(pktTemp);
                                jest_poprawa = true;
                            }
                        }
                        if (!jest_poprawa)   //jeśli brak poprawy w powyższych dwóch
                        {
                            /*simpTemp.pkt[simpTemp.pkt.Length - 1].kopiujZeZrodla(pktOdbity);
                            simpTemp.liczS();
                            simpTemp.sortujS();*/ //teoretycznie blok tych trzech linii powinien być raczej zakomentowany - skurczenie wykonywane na nienaruszonym od poprzedniej iteracji simpleksie

                            simpTemp.kopiujZeZrodla(skurczenieSimpleksu(simpTemp));
                        }
                    }
                    //simpTemp.liczS();
                    simpTemp.sortujS();
                    print();
                    krok++;
                }
                if (krok < l)
                    minZnaleziony = true;
            }
        }




        public static double rownanieTestowe(double x1, double x2)
        {
            return Math.Pow(x1 - 4, 2) + Math.Pow(x2 - 2, 2);  //Funkcja ma min w punkcie (24,52)

            //return 2 * Math.Pow(x1, 3) - Math.Pow(x2, 3) + 12 * Math.Pow(x1, 2) + 27 * x2;
        }

        static double Evaluate(string expression)
        {
            double ret;
           // Expression e = new Expression(expression);
            try
            {
                var loDataTable = new DataTable();
                var loDataColumn = new DataColumn("Eval", typeof(double), expression);
                loDataTable.Columns.Add(loDataColumn);
                loDataTable.Rows.Add(0);
                ret = (double)(loDataTable.Rows[0]["Eval"]);
            }
            catch (Exception e)
            {
                
                ret = Double.MaxValue;
            }
            return ret;
             
           // return e.calculate();
        }

        private static double Parser(string expr)
        {
            double ret = 0;
            int indK = 0; // indeks koncowego nawiasu
            int indS = 0; // indeks srednika
            int ind = expr.IndexOf("Sqrt");
            double liczba;
            if (ind != -1)
            {
                indK = expr.IndexOf("]", ind);
                string exprN = expr.Substring(ind + 5, indK - ind - 5);
                double wyrazenie = Parser(exprN);
                double wynik = Math.Sqrt(wyrazenie);
                expr = expr.Replace("Sqrt[" + exprN + "]", wynik.ToString());
            }

            if (ind == -1)
            {
               ret = Evaluate(expr);
               return ret;
            }
            ret = Evaluate(expr);
            MessageBox.Show(ind.ToString());
            return ret;
        }

        public static double getValFromExpression(double x_1, double x_2)
        {
                string expr = "";
                expr = sExpression.Replace("x1", x_1.ToString().Replace(",", "."));
                expr = expr.Replace("x2", x_2.ToString().Replace(",", "."));
                Expression e = new Expression(expr);
                object ret = e.Evaluate();
            return double.Parse(ret.ToString());
        }
        public static double getValFromExpression(double x_1, double x_2, double x_3)
        {
            string expr = "";
            expr = sExpression.Replace("x1", x_1.ToString().Replace(",", "."));
            expr = expr.Replace("x2", x_2.ToString().Replace(",", "."));
            expr = expr.Replace("x3", x_3.ToString().Replace(",", "."));
            Expression e = new Expression(expr);
            object ret = e.Evaluate();
            return double.Parse(ret.ToString());
        }

        public static double getValFromExpression(double[] x)
        {
            string expr = "";
            expr = sExpression;
            string xT;
            for (int i = 0; i < x.Length; i++)
            {
                xT = "x" + (i + 1).ToString();
                expr = expr.Replace(xT, x[i].ToString().Replace(",", "."));
            }

            Expression e = new Expression(expr);
            object ret = e.Evaluate();
            return double.Parse(ret.ToString());
        }

        public class drawGraph
        {
            Bitmap bmpBackgroud;
            Bitmap bmpToShow;
            private cSimplexSolver solver;
            double scale;
            int width;
            int height;
            string expression;

            public drawGraph(int _width, int _height, double _scale, string _exporession, cSimplexSolver _solver)
            {
                width = _width;
                height = _height;
                bmpBackgroud = new Bitmap(width, height);
                scale = _scale;
                createGraph();
                expression = _exporession;
                solver = _solver;
            }
            private void createGraph()
            {

                    /*double val;
                    for (int i = 0; i < width; i++)   //  <<<---próbuję to zrównoleglić co by się szybciej liczyło :)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            //val = rownanieTestowe((i - (width / 2)) * scale, (j - (height / 2)) * scale);
                            val = getValFromExpression((i - (width / 2)) * scale, (j - (height / 2)) * scale);
                            // Color c = Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(0xffffff) - (int)val));
                            // Color c2 = Color.White;
                            Color c = getColor(val);
                            bmpBackgroud.SetPixel(i, j, c);
                            //bmpBackgroud.SetPixel(i, j, Color.White);
                        }
                    }*/

                    
                    Color [,]tab=new Color[width,height];
                    Parallel.For(0, width, i =>
                    {
                        for (int j = 0; j < height; j++)
                        {
                            //val = rownanieTestowe((i - (width / 2)) * scale, (j - (height / 2)) * scale);
                            //val = getValFromExpression((i - (width / 2)) * scale, (j - (height / 2)) * scale);
                            string expr = "";
                            expr = sExpression.Replace("x1", Convert.ToString((i - (width / 2)) * scale));
                            expr = expr.Replace("x2", Convert.ToString((j - (height / 2)) * scale));
                            expr = expr.Replace(",", ".");
                            // Color c = Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(0xffffff) - (int)val));
                            // Color c2 = Color.White;
                            Color c = getColor(Evaluate(expr));
                            tab[i,j] = c;
                            //bmpBackgroud.SetPixel(i, j, Color.White);
                        }
                    });
                    for (int i = 0; i < width; i++)
                        for (int j = 0; j < height; j++)
                            bmpBackgroud.SetPixel(i, j, tab[i,j]);



                drawAxis();

                bmpToShow = bmpBackgroud;
            }
            private Color getColor(double val)
            {
                int value = 0;
                if (((int)(val * 100)) > 0xffffff)
                {
                    value = 0xffffff;
                }
                else
                {
                    value = (int)(val * 100);
                }
                //int value = (val*100);
                Color c;
                int red = 255;
                int green = 0;
                int blue = 0;
                //if (value < 0) value = 0;
                if (value < 0)
                { // (x1*x1 + x2 - 11) * (x1*x1 + x2 - 11) + (x1 + x2*x2 -7)*(x1 + x2*x2 -7)-200   // pierwsza funkcja do testow
                    // 4*x1*x1 - 2.1*x1*x1*x1*x1 +1/3*x1*x1*x1*x1*x1*x1 + x1*x2 -4*x2*x2 +4*x2*x2*x2*x2  // druga funkcja do testow
                    if (value > -1000)
                        red = 255 -36;
                    else if (value > -4000)
                        red = 255 - 50;
                    else if (value > -8000)
                        red = 255 - 75;
                    else if (value > -16000)
                        red = 255 - 100;
                    else if (value > -35000)
                        red = 255 - 125;
                    else if (value > -40000)
                        red = 255 - 175;

                    else red = 255 - 215;
                }
                else if (value < 0x0000ff)
                {
                     //red = 255 - value;
                    green = 0 + value;
                }
                else if (value < 0x00ff00)
                {
                    value = value >> 8;
                    red = 255 - value;
                    green = 255;
                    
                }
                else if (value < 0xff0000)
                {
                    value = value >> 16;
                    red = 0;
                    green = 255;
                    blue = 0 + value;
                    //blue = 0;
                }
                else
                {
                    red = 0;
                    green = 255;
                    blue = 255;
                }
                //int red = 255 - (value & 0xff0000 >> 16);
                //int green = 0 + (value & 0x00ff00 >> 8);
                //int blue = 0 + (value & 0x0000ff);
                c = Color.FromArgb(255, red, green, blue);
                
                //c = Color.FromArgb(255, value & 0xff0000 >> 16, value & 0x00ff00>>8, value & 0x0000ff);
                //c = Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(0xff0000) - (int)val));

//                return Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(0xff0000) - (int)val));
                return c;
            }
            private void drawAxis()
            {
                for (int i = 0; i < width; i++)
                {
                    bmpBackgroud.SetPixel(i, height / 2, Color.Black);
                    if (i % 40 == 0)
                    {
                        bmpBackgroud.SetPixel(i, height / 2 + 2, Color.Black);
                        bmpBackgroud.SetPixel(i, height / 2 + 1, Color.Black);
                        bmpBackgroud.SetPixel(i, height / 2 - 1, Color.Black);
                        bmpBackgroud.SetPixel(i, height / 2 - 2, Color.Black);
                    }
                }
                for (int i = 0; i < height; i++)
                {
                    bmpBackgroud.SetPixel(width/2 ,i, Color.Black);
                    if (i % 40 == 0)
                    {
                        bmpBackgroud.SetPixel(width / 2 + 2,i, Color.Black);
                        bmpBackgroud.SetPixel(width / 2 + 1,i, Color.Black);
                        bmpBackgroud.SetPixel(width / 2 - 1,i, Color.Black);
                        bmpBackgroud.SetPixel(width / 2 - 2,i, Color.Black);
                    }

                }
            }
            private void drawSimplex(int step)
            {
                bmpToShow = bmpBackgroud;
                cSimplex simplex = solver.listaSimp[step];
                foreach (var pkt in simplex.pkt)
                {
                    double x = pkt.wsp[0] / (scale);
                    double y = pkt.wsp[1] / (scale);
                    int h = height / 2 + (int)y;
                    int w = width / 2 + (int)x;
                    if (h > 1 && h < height - 1 && w > 1 && w < width - 1)
                    {
                        //     rysujemy punkt, jesli miesci sie on na obrazku
                        bmpToShow.SetPixel(w, h-1, Color.Black);
                        bmpToShow.SetPixel(w, h, Color.Black);
                        bmpToShow.SetPixel(w, h+1, Color.Black);
                        bmpToShow.SetPixel(w-1, h, Color.Black);
                        bmpToShow.SetPixel(w, h, Color.Black);
                        bmpToShow.SetPixel(w+1, h, Color.Black);
                    }
                    else
                    {
                        MessageBox.Show("Jeden z punktów nie zmieścił się na wykresie");
                    }
                    
                }
            }
            public Bitmap getGraph(int stepNumber)
            {
                /*
                 * foreach (var simpleksy in solver.listaSimp)
            {
                foreach (var punkty in simpleksy.pkt)
                {
                    richTextBox1.Text += "wspolrzedne: ";
                    foreach (var wsp in punkty.wsp)
                    {
                        richTextBox1.Text += wsp + " ";
                    }
                    richTextBox1.Text += "wartość w punkcie "+punkty.y+"\n";
                }
            }
                */
                drawSimplex(stepNumber);
                bmpToShow.RotateFlip(RotateFlipType.RotateNoneFlipY);
                //bmpToShow.RotateFlip(RotateFlipType.Rotate270FlipNone);
                return bmpToShow;
            }
        }


    }
   
}
