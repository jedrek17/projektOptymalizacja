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
        //funkcje związane z obsługą zdarzeń
        




        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = rownanieTestowe(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text)).ToString();
            cSimplexSolver solver = new cSimplexSolver(2, 0.1);
            label1.Text = solver.simpPocz.pkt[0].y.ToString() + ";   " + solver.simpPocz.pkt[0].wsp[0] + ";   " + solver.simpPocz.pkt[0].wsp[1];
            label2.Text = solver.simpPocz.pkt[1].y.ToString() + ";   " + solver.simpPocz.pkt[1].wsp[0] + ";   " + solver.simpPocz.pkt[1].wsp[1];
            label3.Text = solver.simpPocz.pkt[2].y.ToString() + ";   " + solver.simpPocz.pkt[2].wsp[0] + ";   " + solver.simpPocz.pkt[2].wsp[1];
            label4.Text = "SrodekC " + (solver.liczPolepszonySrCiezk(solver.simpPocz)).wsp[0] + ";   " + (solver.liczPolepszonySrCiezk(solver.simpPocz)).wsp[1];
            //label4.Text = ""+ solver.skurczenie;
            //label3.Text = solver.simpPocz.pkt[0].wsp[1].ToString();
            //pictureBoxGraph.Image = new Bitmap(640, 640);

            drawGraph graph = new drawGraph(640, 640, scale);

            pictureBoxGraph.Image = graph.getGraph(0);
            
            label8.Text = "Jednostka: " + 40 * scale;
        }

        private void btPrzybliz_Click(object sender, EventArgs e)
        {
            scale = scale - 0.01;
            drawGraph graph = new drawGraph(640, 640, scale);
            pictureBoxGraph.Image = graph.getGraph(stepNumber);
            label8.Text = "Jednostka: " + 40 * scale;
        }
        private void btOddal_Click(object sender, EventArgs e)
        {
            scale += 0.01;
            drawGraph graph = new drawGraph(640, 640, scale);
            pictureBoxGraph.Image = graph.getGraph(stepNumber);
            label8.Text = "Jednostka: " + 40 * scale;
        }

    }


}
