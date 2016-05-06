using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optymalizacja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = rownanieTestowe(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text)).ToString();
            cSimplexSolver solver = new cSimplexSolver(4, 0.1);
            label1.Text = solver.simpPocz.pkt[0].y.ToString();
            label2.Text = solver.ekspansja.ToString();
            label3.Text = solver.kontrakcja.ToString();
            label4.Text = solver.skurczenie.ToString();
            //label3.Text = solver.simpPocz.pkt[0].wsp[1].ToString();
        }
    }
}
