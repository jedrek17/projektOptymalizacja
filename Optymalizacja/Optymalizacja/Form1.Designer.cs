namespace Optymalizacja
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btCalculate = new System.Windows.Forms.Button();
            this.tbInsertFunction = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbP1x2 = new System.Windows.Forms.TextBox();
            this.tbP1x = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInsertEpsilon = new System.Windows.Forms.TextBox();
            this.nudInsertSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btOddal = new System.Windows.Forms.Button();
            this.btPrzybliz = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btNextStep = new System.Windows.Forms.Button();
            this.btPreviousStep = new System.Windows.Forms.Button();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInsertSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "x1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "x2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wynik";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wykonano kroków";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Wynik";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(800, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 152);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tymczasowe - jakies okienka <?>";
            this.groupBox1.Visible = false;
            // 
            // btCalculate
            // 
            this.btCalculate.Location = new System.Drawing.Point(698, 19);
            this.btCalculate.Name = "btCalculate";
            this.btCalculate.Size = new System.Drawing.Size(75, 125);
            this.btCalculate.TabIndex = 8;
            this.btCalculate.Text = "Wylicz";
            this.btCalculate.UseVisualStyleBackColor = true;
            this.btCalculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbInsertFunction
            // 
            this.tbInsertFunction.Location = new System.Drawing.Point(108, 19);
            this.tbInsertFunction.Name = "tbInsertFunction";
            this.tbInsertFunction.Size = new System.Drawing.Size(584, 20);
            this.tbInsertFunction.TabIndex = 9;
            this.tbInsertFunction.Text = "(x1-4)*(x1-4) + (x2-2)*(x2-2)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Wprowadz funkcję";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbInsertEpsilon);
            this.groupBox2.Controls.Add(this.nudInsertSize);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btCalculate);
            this.groupBox2.Controls.Add(this.tbInsertFunction);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(779, 152);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dane wejściowe";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(234, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Liczba kroków";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(316, 44);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 16;
            this.numericUpDown1.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.tbP1x2);
            this.groupBox4.Controls.Add(this.tbP1x);
            this.groupBox4.Location = new System.Drawing.Point(11, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(327, 73);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Zakres losowania wartości początkowych simpleksu";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(233, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 11;
            this.label15.Text = "x3 max";
            this.label15.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(235, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "x3 min";
            this.label16.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(276, 46);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(43, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "10";
            this.textBox5.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(276, 17);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(43, 20);
            this.textBox6.TabIndex = 8;
            this.textBox6.Text = "-10";
            this.textBox6.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(114, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "x2 max";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(119, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "x2 min";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(160, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(43, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "10";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(160, 17);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(43, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "-10";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "x1 max";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "x1 min";
            // 
            // tbP1x2
            // 
            this.tbP1x2.Location = new System.Drawing.Point(48, 46);
            this.tbP1x2.Name = "tbP1x2";
            this.tbP1x2.Size = new System.Drawing.Size(43, 20);
            this.tbP1x2.TabIndex = 1;
            this.tbP1x2.Text = "10";
            // 
            // tbP1x
            // 
            this.tbP1x.Location = new System.Drawing.Point(48, 17);
            this.tbP1x.Name = "tbP1x";
            this.tbP1x.Size = new System.Drawing.Size(43, 20);
            this.tbP1x.TabIndex = 0;
            this.tbP1x.Text = "-10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Rozmiar zadania";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(442, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Wprowadź epsilon";
            // 
            // tbInsertEpsilon
            // 
            this.tbInsertEpsilon.Location = new System.Drawing.Point(542, 44);
            this.tbInsertEpsilon.Name = "tbInsertEpsilon";
            this.tbInsertEpsilon.Size = new System.Drawing.Size(150, 20);
            this.tbInsertEpsilon.TabIndex = 12;
            this.tbInsertEpsilon.Text = "0,01";
            // 
            // nudInsertSize
            // 
            this.nudInsertSize.Location = new System.Drawing.Point(108, 44);
            this.nudInsertSize.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudInsertSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudInsertSize.Name = "nudInsertSize";
            this.nudInsertSize.Size = new System.Drawing.Size(120, 20);
            this.nudInsertSize.TabIndex = 11;
            this.nudInsertSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudInsertSize.ValueChanged += new System.EventHandler(this.nudInsertSize_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btOddal);
            this.groupBox3.Controls.Add(this.btPrzybliz);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btNextStep);
            this.groupBox3.Controls.Add(this.btPreviousStep);
            this.groupBox3.Controls.Add(this.pictureBoxGraph);
            this.groupBox3.Location = new System.Drawing.Point(15, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 504);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wyniki";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Zoom";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Krok";
            // 
            // btOddal
            // 
            this.btOddal.Enabled = false;
            this.btOddal.Location = new System.Drawing.Point(6, 64);
            this.btOddal.Name = "btOddal";
            this.btOddal.Size = new System.Drawing.Size(23, 23);
            this.btOddal.TabIndex = 5;
            this.btOddal.Text = "-";
            this.btOddal.UseVisualStyleBackColor = true;
            this.btOddal.Click += new System.EventHandler(this.btOddal_Click);
            // 
            // btPrzybliz
            // 
            this.btPrzybliz.Enabled = false;
            this.btPrzybliz.Location = new System.Drawing.Point(79, 64);
            this.btPrzybliz.Name = "btPrzybliz";
            this.btPrzybliz.Size = new System.Drawing.Size(23, 23);
            this.btPrzybliz.TabIndex = 4;
            this.btPrzybliz.Text = "+";
            this.btPrzybliz.UseVisualStyleBackColor = true;
            this.btPrzybliz.Click += new System.EventHandler(this.btPrzybliz_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Jednostka:";
            // 
            // btNextStep
            // 
            this.btNextStep.Enabled = false;
            this.btNextStep.Location = new System.Drawing.Point(79, 35);
            this.btNextStep.Name = "btNextStep";
            this.btNextStep.Size = new System.Drawing.Size(23, 23);
            this.btNextStep.TabIndex = 2;
            this.btNextStep.Text = ">";
            this.btNextStep.UseVisualStyleBackColor = true;
            this.btNextStep.Click += new System.EventHandler(this.btNextStep_Click);
            // 
            // btPreviousStep
            // 
            this.btPreviousStep.Enabled = false;
            this.btPreviousStep.Location = new System.Drawing.Point(6, 35);
            this.btPreviousStep.Name = "btPreviousStep";
            this.btPreviousStep.Size = new System.Drawing.Size(23, 23);
            this.btPreviousStep.TabIndex = 1;
            this.btPreviousStep.Text = "<";
            this.btPreviousStep.UseVisualStyleBackColor = true;
            this.btPreviousStep.Click += new System.EventHandler(this.btPreviousStep_Click);
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Location = new System.Drawing.Point(108, 18);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(480, 480);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(614, 170);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(180, 504);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(344, 71);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(260, 75);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Wyniki";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 683);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInsertSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btCalculate;
        private System.Windows.Forms.TextBox tbInsertFunction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btNextStep;
        private System.Windows.Forms.Button btPreviousStep;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbInsertEpsilon;
        private System.Windows.Forms.NumericUpDown nudInsertSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btOddal;
        private System.Windows.Forms.Button btPrzybliz;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbP1x2;
        private System.Windows.Forms.TextBox tbP1x;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

