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
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInsertEpsilon = new System.Windows.Forms.TextBox();
            this.nudInsertSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btOddal = new System.Windows.Forms.Button();
            this.btPrzybliz = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btNextStep = new System.Windows.Forms.Button();
            this.btPreviousStep = new System.Windows.Forms.Button();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInsertSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "x1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(41, 46);
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
            this.label2.Location = new System.Drawing.Point(19, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
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
            this.label4.Location = new System.Drawing.Point(19, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(800, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 190);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tymczasowe - jakies okienka <?>";
            this.groupBox1.Visible = false;
            // 
            // btCalculate
            // 
            this.btCalculate.Location = new System.Drawing.Point(698, 71);
            this.btCalculate.Name = "btCalculate";
            this.btCalculate.Size = new System.Drawing.Size(75, 23);
            this.btCalculate.TabIndex = 8;
            this.btCalculate.Text = "Wylicz";
            this.btCalculate.UseVisualStyleBackColor = true;
            this.btCalculate.Click += new System.EventHandler(this.btCalculate_Click);
            // 
            // tbInsertFunction
            // 
            this.tbInsertFunction.Location = new System.Drawing.Point(108, 19);
            this.tbInsertFunction.Name = "tbInsertFunction";
            this.tbInsertFunction.Size = new System.Drawing.Size(665, 20);
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
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbInsertEpsilon);
            this.groupBox2.Controls.Add(this.nudInsertSize);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btCalculate);
            this.groupBox2.Controls.Add(this.tbInsertFunction);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(779, 101);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dane wejściowe";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(274, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "label9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(562, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Rozmiar zadania";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Wprowadź epsilon";
            // 
            // tbInsertEpsilon
            // 
            this.tbInsertEpsilon.Location = new System.Drawing.Point(108, 45);
            this.tbInsertEpsilon.Name = "tbInsertEpsilon";
            this.tbInsertEpsilon.Size = new System.Drawing.Size(150, 20);
            this.tbInsertEpsilon.TabIndex = 12;
            this.tbInsertEpsilon.Text = "0,01";
            // 
            // nudInsertSize
            // 
            this.nudInsertSize.Location = new System.Drawing.Point(653, 45);
            this.nudInsertSize.Maximum = new decimal(new int[] {
            3,
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
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btOddal);
            this.groupBox3.Controls.Add(this.btPrzybliz);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btNextStep);
            this.groupBox3.Controls.Add(this.btPreviousStep);
            this.groupBox3.Controls.Add(this.pictureBoxGraph);
            this.groupBox3.Location = new System.Drawing.Point(15, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(779, 700);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wyniki";
            // 
            // btOddal
            // 
            this.btOddal.Location = new System.Drawing.Point(692, 665);
            this.btOddal.Name = "btOddal";
            this.btOddal.Size = new System.Drawing.Size(23, 23);
            this.btOddal.TabIndex = 5;
            this.btOddal.Text = "-";
            this.btOddal.UseVisualStyleBackColor = true;
            this.btOddal.Click += new System.EventHandler(this.btOddal_Click);
            // 
            // btPrzybliz
            // 
            this.btPrzybliz.Location = new System.Drawing.Point(721, 665);
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
            this.label8.Location = new System.Drawing.Point(11, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Jednostka:";
            // 
            // btNextStep
            // 
            this.btNextStep.Location = new System.Drawing.Point(750, 665);
            this.btNextStep.Name = "btNextStep";
            this.btNextStep.Size = new System.Drawing.Size(23, 23);
            this.btNextStep.TabIndex = 2;
            this.btNextStep.Text = ">";
            this.btNextStep.UseVisualStyleBackColor = true;
            // 
            // btPreviousStep
            // 
            this.btPreviousStep.Location = new System.Drawing.Point(663, 665);
            this.btPreviousStep.Name = "btPreviousStep";
            this.btPreviousStep.Size = new System.Drawing.Size(23, 23);
            this.btPreviousStep.TabIndex = 1;
            this.btPreviousStep.Text = "<";
            this.btPreviousStep.UseVisualStyleBackColor = true;
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Location = new System.Drawing.Point(133, 19);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(640, 640);
            this.pictureBoxGraph.TabIndex = 0;
            this.pictureBoxGraph.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(800, 208);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(187, 530);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 824);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudInsertSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

