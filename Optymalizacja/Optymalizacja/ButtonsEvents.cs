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
        drawGraph graph;

        private void button1_Click(object sender, EventArgs e)
        {
            sExpression = tbInsertFunction.Text;
            //label1.Text = rownanieTestowe(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text)).ToString();
            cSimplexSolver solver = new cSimplexSolver(2, 0.1, 1.5);
            label1.Text = solver.simpPocz.pkt[0].y.ToString() + ";   " + solver.simpPocz.pkt[0].wsp[0] + ";   " + solver.simpPocz.pkt[0].wsp[1];
            label2.Text = solver.simpPocz.pkt[1].y.ToString() + ";   " + solver.simpPocz.pkt[1].wsp[0] + ";   " + solver.simpPocz.pkt[1].wsp[1];
            label3.Text = solver.simpPocz.pkt[2].y.ToString() + ";   " + solver.simpPocz.pkt[2].wsp[0] + ";   " + solver.simpPocz.pkt[2].wsp[1];
            solver.simpPocz.sortujS();
            solver.solveSimp();
            label3.Text = "Wynik " + Math.Round(solver.simpTemp.pkt[0].wsp[0],4) + ";   " + Math.Round(solver.simpTemp.pkt[0].wsp[1],4);
            label4.Text = "Wynik " + Math.Round(solver.simpTemp.pkt[1].wsp[0],4) + ";   " + Math.Round(solver.simpTemp.pkt[1].wsp[1], 4);
            //label4.Text = ""+ solver.skurczenie;
            //label3.Text = solver.simpPocz.pkt[0].wsp[1].ToString();
            //pictureBoxGraph.Image = new Bitmap(640, 640);

            graph = new drawGraph(640, 640, scale, tbInsertFunction.Text);

            pictureBoxGraph.Image = graph.getGraph(0);
            
            label8.Text = "Jednostka: " + 40 * scale;
        }

        private void btPrzybliz_Click(object sender, EventArgs e)
        {
            scale = scale - 0.01;
            graph = new drawGraph(640, 640, scale, tbInsertFunction.Text);
            pictureBoxGraph.Image = graph.getGraph(stepNumber);
            label8.Text = "Jednostka: " + 40 * scale;
        }
        private void btOddal_Click(object sender, EventArgs e)
        {
            scale += 0.01;
            graph = new drawGraph(640, 640, scale, tbInsertFunction.Text);
            pictureBoxGraph.Image = graph.getGraph(stepNumber);
            label8.Text = "Jednostka: " + 40 * scale;
        }

        private void btCalculate_Click(object sender, EventArgs e)
        {
            sExpression = tbInsertFunction.Text;
            if (nudInsertSize.Value == 2)
            {
                label9.Text = getValFromExpression(5, 2).ToString();
            }
            else if (nudInsertSize.Value == 3)
            {
                label9.Text = getValFromExpression(5, 2, 3).ToString();
            }
        }

    }


}
