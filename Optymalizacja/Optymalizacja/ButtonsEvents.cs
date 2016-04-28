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
    }


    class cSimplex
    {
        public cPoint[] pkt;

        public cSimplex(int n) //n - z ilu punktów składa się simpleks
        {
            for(int i=0; i<n; i++)
                pkt[i] = new cPoint(n-1);   //simpleks ma rozmiar o jeden większy niż ilość wymiarów zadania
        }

        public void liczS() //oblicza wartość każdego punktu simpleksu
        {
            for (int i = 0; i < pkt.Length; i++)
                pkt[i].liczP();
        }
    }


    class cSimplexSolver
    {
        public byte n;          //n-wymiarowa funkcja
        public cSimplex simpPocz;    //simpleks początkowy

        public cSimplexSolver(byte n)   //n - ilość wymiarów funkcji
        {
            this.n = n;
            simpPocz = new cSimplex(n+1);   //simpleks zawsze o 1 więcej punktów
        }
    }
}
