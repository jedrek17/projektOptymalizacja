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

        double rownanieTestowe(double x1, double x2)
        {
            return Math.Pow(x1-4,2) + Math.Pow(x2 - 2, 2);  //Funkcja ma min w punkcie (4,2)
        }
    }



    class cPoint
    {
        public double[] wsp;
        public double y;
        public cPoint(int n)    //n - ile współrzędnych ma jeden punkt
        {
            wsp = new double[n];
        }
    }


    class cSimplex
    {
        public cPoint[] pkt;
        public cSimplex(int n)
        {
            for(int i=0; i<n; i++)
                pkt[i] = new cPoint(n-1);   //simpleks ma rozmiar o jeden większy niż ilość wymiarów zadania
        }
    }


    class cSimplexSolver
    {
        public byte n;          //n-wymiarowa funkcja
        public cSimplex simpPocz;    //simpleks początkowy


        public cSimplexSolver(byte n)
        {
            this.n = n;
            simpPocz = new cSimplex(n+1);
        }
    }
}
