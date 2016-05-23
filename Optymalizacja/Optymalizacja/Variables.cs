using org.mariuszgromada.math.mxparser;
//using org.mariuszgromada.math.mxparser;                           <<<---!!!
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optymalizacja
{
    partial class Form1
    {
        // tutaj bedziemy umieszczac roznego rodzaju zmienne wykorzystywane w programie 
        double scale = 0.05; // skala wyswitlanego wykresu
        int stepNumber = 0;
        public static string sExpression = "";

        //cPoint-------------------------------------------------------------------------------------
        class cPoint
        {
            public double[] wsp;    //współrzędne
            public double y;    //wartość funkcji w punkcie

            public cPoint(int n)    //n - ile współrzędnych ma jeden punkt
            {
                wsp = new double[n];
            }



            public void liczP() //oblicza wartość funkcji w punkcie
            {
                y = rownanieTestowe(wsp[0], wsp[1]);
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

        class cSimplex
        {
            public cPoint[] pkt;

            public cSimplex(int n) //n - z ilu punktów składa się simpleks
            {
                pkt = new cPoint[n];
                for (int i = 0; i < n; i++)
                    pkt[i] = new cPoint(n - 1);   //simpleks ma rozmiar o jeden większy niż ilość wymiarów zadania
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

        class cSimplexSolver
        {
            private int n, krok;          //n-wymiarowa funkcja, krok - liczy ilość iteracji solvera
            public double epsilon, ekspansja = 2.0, kontrakcja = 0.5, skurczenie = 0.5;  //parametry do ustawienia w konstruktorze
            public cSimplex simpPocz, simpTemp, simpWynik;    //simpleks początkowy, roboczy, wynikowy

            public cSimplexSolver(int n, double epsilon, double ekspansja = 2.0, double kontrakcja = 0.5, double skurczenie = 0.5)   //n - ilość wymiarów funkcji, epsilon - warunek stopu
            {
                this.n = n;
                this.epsilon = epsilon;
                krok = 0;

                if (ekspansja > 1.0)   //poniższe parametry muszą przyjmować wartości z odpowiednich zakresów (http://akson.sgh.waw.pl/~jd37272/MO/mo_zaj3.pdf)
                    this.ekspansja = ekspansja;
                if (kontrakcja > 0 & kontrakcja < 1)
                    this.kontrakcja = kontrakcja;
                if (skurczenie > 0 & skurczenie < 1)
                    this.skurczenie = skurczenie;

                simpPocz = new cSimplex(n + 1);   //simpleks składa się zawsze z 1 punktu więcej niż rozmiar zadania
                simpTemp = new cSimplex(n + 1);
                simpWynik = new cSimplex(n + 1);

                Random rand = new Random();
                for (int i = 0; i < n + 1; i++) //pętle losują każdą współrzędną dla każdego punktu
                    for (int j = 0; j < n; j++)
                        simpPocz.pkt[i].wsp[j] = rand.Next(-100, 100) / 10.0;   //z zakresu -10:10

                simpPocz.liczS();
            }



            private void print()
            {
                //tu możesz rysować obrazek krok po kroku - funkcja wywoływana jest w każdym kroku solvera      <<<--------------!!!
                //najlepiej korzystaj z simpTemp i zmiennej krok (dobrze by było jakby obok obrazka wyświetlała się lista kroków)
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
                    for (int j = 0; j < simpKopia.pkt.Length-1; j++)     //pętla poruszająca się po kolejnych punktach Simpleksu (za wyjątkiem największego - ostatniego)
                        punkt.wsp[i] += simpKopia.pkt[j].wsp[i];         //sumuje tą samą współrzędną z kolejnych punktów
                    punkt.wsp[i] /= simpKopia.pkt[i].wsp.Length;         //dzieli sumę przez ilość współrzędnych
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

                //simpWynikowy.liczS();         //  <<< możnaby policzyć odrazu...
                return simpWynikowy;
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
                while((Math.Abs(simpTemp.pkt[0].wsp[0]- simpTemp.pkt[1].wsp[0]))>epsilon && krok<10000)      //  <<<---!!! - docelowo zmienić na prawidłowy warunek stopu
                {
                    pktOdbity.kopiujZeZrodla(odbicieSimpleksu(simpTemp));   //tworzy odbicie najgorszego punkyu

                    if(pktOdbity.y<simpTemp.pkt[0].y)   //aR<aL
                    {
                        pktTemp.kopiujZeZrodla(ekspansjaSimpleksu(simpTemp,pktOdbity));
                        if (pktTemp.y < pktOdbity.y)
                            simpTemp.pkt[simpTemp.pkt.Length-1].kopiujZeZrodla(pktTemp);
                        else if (pktTemp.y > pktOdbity.y)
                            simpTemp.pkt[simpTemp.pkt.Length-1].kopiujZeZrodla(pktOdbity);
                    }
                    else if(pktOdbity.y>=simpTemp.pkt[simpTemp.pkt.Length-2].y)   // aR>aSH; -2 ponieważ -1 to najgorszy, a -2 to drugi najgorszy
                    {
                        bool jest_poprawa = false;
                        if (pktOdbity.y >= simpTemp.pkt[simpTemp.pkt.Length-1].y)    //aR>aH
                        {
                            pktTemp.kopiujZeZrodla(kontrakcjaSimpleksuDoSr(simpTemp));
                            if(pktTemp.y < simpTemp.pkt[simpTemp.pkt.Length-1].y)
                            {
                                simpTemp.pkt[simpTemp.pkt.Length-1].kopiujZeZrodla(pktTemp);
                                jest_poprawa = true;
                            }
                        }
                        else if (pktOdbity.y < simpTemp.pkt[simpTemp.pkt.Length-1].y)   //aR<aH
                        {
                            pktTemp.kopiujZeZrodla(kontrakcjaSimpleksuNaZew(simpTemp,pktOdbity));
                            if (pktTemp.y < simpTemp.pkt[simpTemp.pkt.Length-1].y)
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
                    simpTemp.liczS();
                    simpTemp.sortujS();
                    print();
                    krok++;
                }
            }
        }




        public static double rownanieTestowe(double x1, double x2)
        {
            return Math.Pow(x1 - 4, 2) + Math.Pow(x2 - 2, 2);  //Funkcja ma min w punkcie (4,2)
        }

        public static double getValFromExpression(double x_1, double x_2)
        {
            Argument x1 = new Argument("x1", x_1);
            Argument x2 = new Argument("x2", x_2);

            Expression e = new Expression(sExpression,x1,x2);
            return e.calculate();
        }
        public static double getValFromExpression(double x_1, double x_2, double x_3)
        {
            Argument x1 = new Argument("x1", x_1);
            Argument x2 = new Argument("x2", x_2);
            Argument x3 = new Argument("x3", x_3);

            Expression e = new Expression(sExpression, x1, x2, x3);
            return e.calculate();
        }

        public class drawGraph
        {
            Bitmap bmpBackgroud;
            Bitmap bmpToShow;
            double scale;
            int width;
            int height;
            string expression;

            public drawGraph(int _width, int _height, double _scale, string _exporession)
            {
                width = _width;
                height = _height;
                bmpBackgroud = new Bitmap(width, height);
                scale = _scale;
                createGraph();
                expression = _exporession;
            }
            private void createGraph()
            {
                double val;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        val = rownanieTestowe((i - (width/2))*scale, (j - (height/2))*scale);
//                        val = getValFromExpression((i - (width / 2)) * scale, (j - (height / 2)) * scale, expression);
                       // Color c = Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(0xffffff) - (int)val));
                       // Color c2 = Color.White;
                        Color c = getColor(val);
                        bmpBackgroud.SetPixel(i,j,c);
                        //bmpBackgroud.SetPixel(i, j, Color.White);
                    }
                }

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
                if (value < 0x0000ff)
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

            public Bitmap getGraph(int stepNumber)
            {
                bmpToShow.RotateFlip(RotateFlipType.Rotate270FlipNone);
                return bmpToShow;
            }
        }


    }
   
}
