namespace DZ2
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numAlpha = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numBeta = new System.Windows.Forms.NumericUpDown();
            this.numRho = new System.Windows.Forms.NumericUpDown();
            this.numQ = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.ofdValues = new System.Windows.Forms.OpenFileDialog();
            this.btnFile = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDuzina = new System.Windows.Forms.Label();
            this.lblRedosled = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQ)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox.Location = new System.Drawing.Point(13, 10);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(607, 626);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(819, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Alpha:";
            // 
            // numAlpha
            // 
            this.numAlpha.Location = new System.Drawing.Point(886, 32);
            this.numAlpha.Name = "numAlpha";
            this.numAlpha.Size = new System.Drawing.Size(120, 22);
            this.numAlpha.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(826, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Beta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(721, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Intenzitet isparavanja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(734, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Intenzitet feromona:";
            // 
            // numBeta
            // 
            this.numBeta.Location = new System.Drawing.Point(886, 95);
            this.numBeta.Name = "numBeta";
            this.numBeta.Size = new System.Drawing.Size(120, 22);
            this.numBeta.TabIndex = 9;
            // 
            // numRho
            // 
            this.numRho.DecimalPlaces = 2;
            this.numRho.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numRho.Location = new System.Drawing.Point(886, 150);
            this.numRho.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRho.Name = "numRho";
            this.numRho.Size = new System.Drawing.Size(120, 22);
            this.numRho.TabIndex = 10;
            // 
            // numQ
            // 
            this.numQ.DecimalPlaces = 1;
            this.numQ.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numQ.Location = new System.Drawing.Point(886, 211);
            this.numQ.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numQ.Name = "numQ";
            this.numQ.Size = new System.Drawing.Size(120, 22);
            this.numQ.TabIndex = 11;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(853, 350);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(76, 37);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // ofdValues
            // 
            this.ofdValues.FileName = "openFileDialog1";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(724, 279);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(120, 32);
            this.btnFile.TabIndex = 14;
            this.btnFile.Text = "Izaberite fajl";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(850, 287);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(26, 17);
            this.lblFile.TabIndex = 15;
            this.lblFile.Text = "fajl";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(652, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Redosled kojim treba obići:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(652, 619);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Dužina pronađenog puta:";
            // 
            // lblDuzina
            // 
            this.lblDuzina.AutoSize = true;
            this.lblDuzina.Location = new System.Drawing.Point(826, 619);
            this.lblDuzina.Name = "lblDuzina";
            this.lblDuzina.Size = new System.Drawing.Size(46, 17);
            this.lblDuzina.TabIndex = 18;
            this.lblDuzina.Text = "label1";
            // 
            // lblRedosled
            // 
            this.lblRedosled.AutoSize = true;
            this.lblRedosled.Location = new System.Drawing.Point(652, 466);
            this.lblRedosled.Name = "lblRedosled";
            this.lblRedosled.Size = new System.Drawing.Size(46, 17);
            this.lblRedosled.TabIndex = 19;
            this.lblRedosled.Text = "label8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 648);
            this.Controls.Add(this.lblRedosled);
            this.Controls.Add(this.lblDuzina);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numQ);
            this.Controls.Add(this.numRho);
            this.Controls.Add(this.numBeta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numAlpha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numAlpha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numBeta;
        private System.Windows.Forms.NumericUpDown numRho;
        private System.Windows.Forms.NumericUpDown numQ;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.OpenFileDialog ofdValues;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDuzina;
        private System.Windows.Forms.Label lblRedosled;
    }
}

