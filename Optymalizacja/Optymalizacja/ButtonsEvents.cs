using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optymalizacja
{
    partial class Form1
    {
        //funkcje związane z obsługą zdarzeń

        public double rownanieTestowe(double x1, double x2)
        {
            return Math.Pow(x1-4,2) + Math.Pow(x2 - 2, 2);  //Funkcja ma min w punkcie (4,2)
        }
    }

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
            y = Math.Pow(wsp[0] - 4, 2) + Math.Pow(wsp[1] - 2, 2);  //nie umiałem skorzystać z funkcji testowej (wywala coś dziwnego), to musiałem ją po prostu wkleić...
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
    }

//cSimplex-------------------------------------------------------------------------------------

    class cSimplex
    {
        public cPoint[] pkt;

        public cSimplex(int n) //n - z ilu punktów składa się simpleks
        {
            pkt = new cPoint[n];
            for(int i=0; i<n; i++)
                pkt[i] = new cPoint(n-1);   //simpleks ma rozmiar o jeden większy niż ilość wymiarów zadania
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
            cPoint tmp=new cPoint(pkt.Length-1);

            for (int j=pkt.Length-1; j>0; j--)
                for(int i=0; i<j; i++)
                    if(pkt[i].y>pkt[i+1].y)
                    {
                        tmp.kopiujZeZrodla(pkt[i]); //tmp = pkt[i];
                        pkt[i].kopiujZeZrodla(pkt[i+1]);    //pkt[i].y = pkt[i+1];
                        pkt[i+1].kopiujZeZrodla(tmp); //pkt[i+1] = tmp;
                    }
        }
    }

//cSimplexSolver-------------------------------------------------------------------------------------

    class cSimplexSolver
    {
        private int n, krok;          //n-wymiarowa funkcja, krok - liczy ilość iteracji solvera
        public double epsilon, ekspansja=2.0, kontrakcja=0.5, skurczenie=0.5;  //parametry do ustawienia w konstruktorze
        public cSimplex simpPocz, simpTemp, simpWynik;    //simpleks początkowy, roboczy, wynikowy

        public cSimplexSolver(int n, double epsilon, double ekspansja=2.0, double kontrakcja=0.5, double skurczenie=0.5)   //n - ilość wymiarów funkcji, epsilon - warunek stopu
        {
            this.n = n;
            this.epsilon = epsilon;
            krok = 0;

            if(ekspansja>1.0)   //poniższe parametry muszą przyjmować wartości z odpowiednich zakresów (http://akson.sgh.waw.pl/~jd37272/MO/mo_zaj3.pdf)
                this.ekspansja = ekspansja;
            if(kontrakcja>0 & kontrakcja<1)
                this.kontrakcja = kontrakcja;
            if (skurczenie>0 & skurczenie<1)
                this.skurczenie = skurczenie;

            simpPocz = new cSimplex(n+1);   //simpleks składa się zawsze z 1 punktu więcej niż rozmiar zadania
            simpTemp = new cSimplex(n+1);
            simpWynik = new cSimplex(n+1);

            Random rand = new Random();
            for (int i = 0; i < n + 1; i++) //pętle losują każdą współrzędną dla każdego punktu
                for (int j = 0; j < n; j++)
                    simpPocz.pkt[i].wsp[j] = rand.Next(-100,100)/10.0;

            simpPocz.liczS();
        }



        private void print()
        {
            //tu możesz rysować obrazek krok po kroku - funkcja wywoływana jest w każdym kroku solvera      <<<--------------!!!
            //najlepiej korzystaj z simpTemp i zmiennej krok (dobrze by było jakby obok obrazka wyświetlała się lista kroków)
        }



        public void solveSimp()
        {
            simpPocz.sortujS();
            simpTemp.kopiujZeZrodla(simpPocz);
            print();
        }
    }
}
