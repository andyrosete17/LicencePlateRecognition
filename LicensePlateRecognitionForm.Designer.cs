namespace LicensePlateRecognition
{
   partial class LicensePlateRecognitionForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.indiceB = new System.Windows.Forms.TextBox();
            this.beforeB = new System.Windows.Forms.Button();
            this.nextB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.inputB = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.cVisionButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GoogleBtn = new System.Windows.Forms.Button();
            this.TesseractBtn = new System.Windows.Forms.Button();
            this.processTimeLabel = new System.Windows.Forms.Label();
            this.informationLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.nameB = new System.Windows.Forms.TextBox();
            this.SaveDbButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Controls.Add(this.inputTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1478, 709);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 709);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(2, 108);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(248, 362);
            this.inputTextBox.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SaveDbButton);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.nameB);
            this.panel2.Controls.Add(this.indiceB);
            this.panel2.Controls.Add(this.beforeB);
            this.panel2.Controls.Add(this.nextB);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.inputB);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.cVisionButton);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.GoogleBtn);
            this.panel2.Controls.Add(this.TesseractBtn);
            this.panel2.Controls.Add(this.processTimeLabel);
            this.panel2.Controls.Add(this.informationLabel);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 108);
            this.panel2.TabIndex = 3;
            // 
            // indiceB
            // 
            this.indiceB.Location = new System.Drawing.Point(49, 77);
            this.indiceB.Name = "indiceB";
            this.indiceB.Size = new System.Drawing.Size(42, 20);
            this.indiceB.TabIndex = 18;
            this.indiceB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.indiceB.KeyUp += new System.Windows.Forms.KeyEventHandler(this.indiceB_KeyUp);
            // 
            // beforeB
            // 
            this.beforeB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beforeB.Location = new System.Drawing.Point(2, 70);
            this.beforeB.Name = "beforeB";
            this.beforeB.Size = new System.Drawing.Size(41, 36);
            this.beforeB.TabIndex = 17;
            this.beforeB.Text = "<";
            this.beforeB.UseVisualStyleBackColor = true;
            this.beforeB.Click += new System.EventHandler(this.beforeB_Click);
            // 
            // nextB
            // 
            this.nextB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextB.Location = new System.Drawing.Point(97, 70);
            this.nextB.Name = "nextB";
            this.nextB.Size = new System.Drawing.Size(42, 36);
            this.nextB.TabIndex = 16;
            this.nextB.Text = ">";
            this.nextB.UseVisualStyleBackColor = true;
            this.nextB.Click += new System.EventHandler(this.nextB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "File:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(439, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Input Folder";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // inputB
            // 
            this.inputB.Location = new System.Drawing.Point(73, 47);
            this.inputB.Name = "inputB";
            this.inputB.Size = new System.Drawing.Size(360, 20);
            this.inputB.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(610, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Delete Image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cVisionButton
            // 
            this.cVisionButton.Location = new System.Drawing.Point(691, 19);
            this.cVisionButton.Name = "cVisionButton";
            this.cVisionButton.Size = new System.Drawing.Size(101, 23);
            this.cVisionButton.TabIndex = 8;
            this.cVisionButton.Text = "Computer Vision";
            this.cVisionButton.UseVisualStyleBackColor = true;
            this.cVisionButton.Click += new System.EventHandler(this.CVisionButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(529, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Reset Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // GoogleBtn
            // 
            this.GoogleBtn.Location = new System.Drawing.Point(610, 19);
            this.GoogleBtn.Name = "GoogleBtn";
            this.GoogleBtn.Size = new System.Drawing.Size(75, 23);
            this.GoogleBtn.TabIndex = 6;
            this.GoogleBtn.Text = "GoogleApi";
            this.GoogleBtn.UseVisualStyleBackColor = true;
            this.GoogleBtn.Click += new System.EventHandler(this.GoogleBtn_Click);
            // 
            // TesseractBtn
            // 
            this.TesseractBtn.Location = new System.Drawing.Point(529, 18);
            this.TesseractBtn.Name = "TesseractBtn";
            this.TesseractBtn.Size = new System.Drawing.Size(75, 23);
            this.TesseractBtn.TabIndex = 5;
            this.TesseractBtn.Text = "Tesseract";
            this.TesseractBtn.UseVisualStyleBackColor = true;
            this.TesseractBtn.Click += new System.EventHandler(this.TesseractBtn_Click_1);
            // 
            // processTimeLabel
            // 
            this.processTimeLabel.AutoSize = true;
            this.processTimeLabel.Location = new System.Drawing.Point(34, 54);
            this.processTimeLabel.Name = "processTimeLabel";
            this.processTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.processTimeLabel.TabIndex = 4;
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Location = new System.Drawing.Point(27, 55);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(0, 13);
            this.informationLabel.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(360, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Matricula:";
            // 
            // nameB
            // 
            this.nameB.Location = new System.Drawing.Point(271, 74);
            this.nameB.Name = "nameB";
            this.nameB.Size = new System.Drawing.Size(162, 20);
            this.nameB.TabIndex = 19;
            // 
            // SaveDbButton
            // 
            this.SaveDbButton.Location = new System.Drawing.Point(439, 75);
            this.SaveDbButton.Name = "SaveDbButton";
            this.SaveDbButton.Size = new System.Drawing.Size(75, 23);
            this.SaveDbButton.TabIndex = 21;
            this.SaveDbButton.Text = "Guardar BD";
            this.SaveDbButton.UseVisualStyleBackColor = true;
            this.SaveDbButton.Click += new System.EventHandler(this.SaveDbButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.imageBox1);
            this.panel3.Location = new System.Drawing.Point(248, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(868, 524);
            this.panel3.TabIndex = 6;
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(2, 2);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(865, 521);
            this.imageBox1.TabIndex = 0;
            this.imageBox1.TabStop = false;
            // 
            // LicensePlateRecognitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 709);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LicensePlateRecognitionForm";
            this.Text = "License Plate Recognition";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label informationLabel;
      private System.Windows.Forms.Label processTimeLabel;
        private System.Windows.Forms.Button GoogleBtn;
        private System.Windows.Forms.Button TesseractBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cVisionButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.TextBox indiceB;
        private System.Windows.Forms.Button beforeB;
        private System.Windows.Forms.Button nextB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox inputB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameB;
        private System.Windows.Forms.Button SaveDbButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox imageBox1;
    }
}