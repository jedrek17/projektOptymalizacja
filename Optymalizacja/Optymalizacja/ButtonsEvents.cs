﻿using System;
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
            cSimplexSolver solver = new cSimplexSolver(4, 0.1);
            label1.Text = solver.simpPocz.pkt[0].y.ToString() + ", " + solver.simpPocz.pkt[0].wsp[0] + ", " + solver.simpPocz.pkt[0].wsp[1];

            label4.Text = solver.skurczenie.ToString();
            //label3.Text = solver.simpPocz.pkt[0].wsp[1].ToString();
            //pictureBoxGraph.Image = new Bitmap(640, 640);
            drawGraph graph = new drawGraph(640, 640, 0.05);
            pictureBoxGraph.Image = graph.getGraph(0);
        }

    }


}
