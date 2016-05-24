﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optymalizacja
{
    partial class Form1
    {
        //funkcje związane z obsługą zdarzeń
        drawGraph graph;

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            richTextBox1.Text += "1\n"; 
            sExpression = tbInsertFunction.Text;
            richTextBox1.Text += "2\n";
            //label1.Text = rownanieTestowe(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text)).ToString();
            cSimplexSolver solver = new cSimplexSolver(Decimal.ToInt16(nudInsertSize.Value), 0.01);
            textBox1.Text = solver.simpPocz.pkt[0].wsp[0] + ";   " + solver.simpPocz.pkt[0].wsp[1];
            textBox2.Text = solver.simpPocz.pkt[1].wsp[0] + ";   " + solver.simpPocz.pkt[1].wsp[1];
            //label1.Text = solver.simpPocz.pkt[0].y.ToString() + ";   " + solver.simpPocz.pkt[0].wsp[0] + ";   " + solver.simpPocz.pkt[0].wsp[1];
            solver.simpPocz.sortujS();
            solver.solveSimp();
            label1.Text ="Flagi(e,kS,kZ,s): " + solver.fl_eks + solver.fl_konDoSr + solver.fl_konNaZew + solver.fl_sku;// <(*)>
            label2.Text = "Wykonane " + solver.krok + " kroków";
            label3.Text = "Wynik " + Math.Round(solver.simpTemp.pkt[0].wsp[0],4) + ";   " + Math.Round(solver.simpTemp.pkt[0].wsp[1],4) + ";   " + Math.Round(solver.simpTemp.pkt[0].wsp[1], 4);
            label4.Text = "Wynik " + Math.Round(solver.simpTemp.pkt[1].wsp[0],4) + ";   " + Math.Round(solver.simpTemp.pkt[1].wsp[1], 4);
            //label4.Text = ""+ solver.skurczenie;
            //label3.Text = solver.simpPocz.pkt[0].wsp[1].ToString();
            //pictureBoxGraph.Image = new Bitmap(640, 640);
            /*
            for (int i=0; i<solver.listaSimp.Count; i++)
            {
                listBox1.Items.Add("Krok " + (i+1));
                for(int j=0; j<solver.simpTemp.pkt.Length; j++)
                {
                    listBox1.Items.Add("Współrzędne i wartość funkcji w punkcie " + (j+1));
                    for(int k=0; k<solver.n; k++)
                        listBox1.Items.Add(Math.Round(solver.listaSimp[i].pkt[j].wsp[k],4));
                    listBox1.Items.Add(Math.Round(solver.listaSimp[i].pkt[j].y, 4));
                }
                listBox1.Items.Add("");
            }
            */

            graph = new drawGraph(640, 640, scale, tbInsertFunction.Text);

            pictureBoxGraph.Image = graph.getGraph(0);
            
            label8.Text = "Jednostka: " + 40 * scale;
            Cursor.Current = Cursors.Default;
        }

        private void btPrzybliz_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            scale = scale - 0.01;
            graph = new drawGraph(640, 640, scale, tbInsertFunction.Text);
            pictureBoxGraph.Image = graph.getGraph(stepNumber);
            label8.Text = "Jednostka: " + 40 * scale;
            Cursor.Current = Cursors.Default;
        }
        private void btOddal_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            scale += 0.01;
            graph = new drawGraph(640, 640, scale, tbInsertFunction.Text);
            pictureBoxGraph.Image = graph.getGraph(stepNumber);
            label8.Text = "Jednostka: " + 40 * scale;
            Cursor.Current = Cursors.Default;
        }

        private void btCalculate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            sExpression = tbInsertFunction.Text;
            
            sExpression = tbInsertFunction.Text;

            double eps = double.Parse(tbInsertEpsilon.Text.Replace(".",","));
            cSimplexSolver solver = new cSimplexSolver(Decimal.ToInt16(nudInsertSize.Value), eps);
            solver.simpPocz.sortujS();
            solver.solveSimp();
            foreach (var simpleksy in solver.listaSimp)
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
            
            if (nudInsertSize.Value == 2)
            {
                //label9.Text = getValFromExpression(5, 2).ToString();
                graph = new drawGraph(640, 640, scale, tbInsertFunction.Text);
                pictureBoxGraph.Image = graph.getGraph(0);
            }
             /*
            else if (nudInsertSize.Value == 3)
            {
                label9.Text = getValFromExpression(5, 2, 3).ToString();
            }
             */
            Cursor.Current = Cursors.Default;
        }

    }


}
