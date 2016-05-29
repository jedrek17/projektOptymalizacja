//Algorytm wykonany według:
//http://akson.sgh.waw.pl/~jd37272/MO/mo_zaj3.pdf - prawdopodobnie zawiera błędy
//poprawiony według:
//http://optymalizacja.w8.pl/simplexNM.html

using System;
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
        cSimplexSolver solver;

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            richTextBox1.Text += "1\n"; 
            sExpression = tbInsertFunction.Text;
            richTextBox1.Text += "2\n";
            //label1.Text = rownanieTestowe(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text)).ToString();
            double epsilon = Double.Parse(tbInsertEpsilon.Text);
            int krokow = Decimal.ToInt32(numericUpDown1.Value);
            double x1min = double.Parse(tbP1x.Text);
            double x2min = double.Parse(textBox4.Text);
            double x3min = double.Parse(textBox6.Text);
            double x1max = double.Parse(tbP1x2.Text);
            double x2max = double.Parse(textBox3.Text);
            double x3max = double.Parse(textBox5.Text);
            solver = new cSimplexSolver(Decimal.ToInt16(nudInsertSize.Value), epsilon, krokow, x1min, x2min, x3min, x1max, x2max, x3max);
            textBox1.Text = solver.simpPocz.pkt[0].wsp[0] + ";   " + solver.simpPocz.pkt[0].wsp[1];
            textBox2.Text = solver.simpPocz.pkt[1].wsp[0] + ";   " + solver.simpPocz.pkt[1].wsp[1];
            //label1.Text = solver.simpPocz.pkt[0].y.ToString() + ";   " + solver.simpPocz.pkt[0].wsp[0] + ";   " + solver.simpPocz.pkt[0].wsp[1];
            solver.simpPocz.sortujS();
            solver.solveSimp(); 
            lastStepNumber = solver.listaSimp.Count - 1; // wprowadzamy wartosc oznaczajaca, ile krokow wykonal nasz algorytm
            stepNumber = 0; // wprowadzamy zmienna okreslajaca, ktory aktualnie krok wyswietlamy
            label1.Text ="Flagi(e,kS,kZ,s): " + solver.fl_eks + solver.fl_konDoSr + solver.fl_konNaZew + solver.fl_sku;// <(*)>
            label2.Text = "Wykonano " + solver.krok + " kroków";
            label3.Text = "Znaleziono min: " + solver.minZnaleziony;
            label4.Text = "Wynik " + Math.Round(solver.simpTemp.pkt[1].wsp[0],4) + ";   " + Math.Round(solver.simpTemp.pkt[1].wsp[1], 4);
            //label4.Text = ""+ solver.skurczenie;
            //label3.Text = solver.simpPocz.pkt[0].wsp[1].ToString();
            //pictureBoxGraph.Image = new Bitmap(640, 640);

            //richTextBox1.Clear();
            richTextBox1.Text = "Uwaga - punkty simpleksu są sortowane od najmniejszego do największgo po każdej iteracji.\n\n";
            for (int i=0; i<solver.listaSimp.Count; i++)
            {
                richTextBox1.Text+=("Krok " + i + ":");
                for(int j=0; j<solver.simpTemp.pkt.Length; j++)
                {
                    richTextBox1.Text += ("\n\nWspółrzędne w punkcie " + (j+1) + ":\n");
                    for(int k=0; k<solver.n; k++)
                        richTextBox1.Text += (Math.Round(solver.listaSimp[i].pkt[j].wsp[k],4) + ";   ");
                    richTextBox1.Text += ("\nWartość funkcji w punkcie " + (j+1) + ":");
                    richTextBox1.Text += "\n" + (Math.Round(solver.listaSimp[i].pkt[j].y, 4));
                }
                richTextBox1.Text += ("\n\n\n");
            }
            
            if(solver.n<3)
            {
                graph = new drawGraph(480, 480, scale, tbInsertFunction.Text, solver);

                pictureBoxGraph.Image = graph.getGraph(stepNumber);
            
                label8.Text = "Jednostka: " + 40 * scale;
                btNextStep.Enabled = true;
                btPrzybliz.Enabled = true;
                btOddal.Enabled = true;
            }
            Cursor.Current = Cursors.Default;
        }

        private void btNextStep_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            graph = new drawGraph(480, 480, scale, tbInsertFunction.Text, solver);
            stepNumber += 1;
            btPreviousStep.Enabled = true;
            if (stepNumber == lastStepNumber)
            {
                btNextStep.Enabled = false;               
            }
            pictureBoxGraph.Image = graph.getGraph(stepNumber);

            Cursor.Current = Cursors.Default;
        }
        private void btPreviousStep_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            graph = new drawGraph(480, 480, scale, tbInsertFunction.Text, solver);
            stepNumber -= 1;
            btNextStep.Enabled = true;
            if (stepNumber == 0)
            { 
                btPreviousStep.Enabled = false;
            }
            pictureBoxGraph.Image = graph.getGraph(stepNumber);

            Cursor.Current = Cursors.Default;
        }
        private void btPrzybliz_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            scale = scale - 0.01;
            graph = new drawGraph(480, 480, scale, tbInsertFunction.Text, solver);
            pictureBoxGraph.Image = graph.getGraph(stepNumber);
            label8.Text = "Jednostka: " + 40 * scale;
            Cursor.Current = Cursors.Default;
        }
        private void btOddal_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            scale += 0.01;
            graph = new drawGraph(480, 480, scale, tbInsertFunction.Text, solver);
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
            solver = new cSimplexSolver(Decimal.ToInt16(nudInsertSize.Value), eps, 60, -10, -10, -10, 10, 10, 10);
            solver.simpPocz.sortujS();
            solver.solveSimp();
            richTextBox1.Clear();
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
                graph = new drawGraph(480, 480, scale, tbInsertFunction.Text, solver);
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

        private void nudInsertSize_ValueChanged(object sender, EventArgs e)
        {
            switch (Decimal.ToInt32(nudInsertSize.Value))
            {
                case 2:
                    textBox5.Visible = false;
                    textBox5.Text = "10";
                    textBox6.Visible = false;
                    textBox6.Text = "-10";
                    label15.Visible = false;
                    label16.Visible = false;
                    break;
                case 3:
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    break;
            }
        }


    }


}
