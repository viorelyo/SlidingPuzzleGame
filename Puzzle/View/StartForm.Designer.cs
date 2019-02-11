namespace Puzzle
{
    partial class StartForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgBrowseBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.squaresNrComboBox = new System.Windows.Forms.ComboBox();
            this.gameBoxPuzzle = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Squares";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Image";
            // 
            // imgBrowseBtn
            // 
            this.imgBrowseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgBrowseBtn.Location = new System.Drawing.Point(153, 75);
            this.imgBrowseBtn.Name = "imgBrowseBtn";
            this.imgBrowseBtn.Size = new System.Drawing.Size(149, 42);
            this.imgBrowseBtn.TabIndex = 3;
            this.imgBrowseBtn.Text = "Choose Image";
            this.imgBrowseBtn.UseVisualStyleBackColor = true;
            this.imgBrowseBtn.Click += new System.EventHandler(this.imgBrowseBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startBtn);
            this.groupBox1.Controls.Add(this.printPreviewControl1);
            this.groupBox1.Controls.Add(this.squaresNrComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.imgBrowseBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 129);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(342, 49);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(194, 52);
            this.startBtn.TabIndex = 7;
            this.startBtn.TabStop = false;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(463, 177);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(100, 100);
            this.printPreviewControl1.TabIndex = 6;
            // 
            // squaresNrComboBox
            // 
            this.squaresNrComboBox.FormattingEnabled = true;
            this.squaresNrComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5"});
            this.squaresNrComboBox.Location = new System.Drawing.Point(153, 34);
            this.squaresNrComboBox.Name = "squaresNrComboBox";
            this.squaresNrComboBox.Size = new System.Drawing.Size(149, 28);
            this.squaresNrComboBox.TabIndex = 4;
            // 
            // gameBoxPuzzle
            // 
            this.gameBoxPuzzle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameBoxPuzzle.Location = new System.Drawing.Point(12, 147);
            this.gameBoxPuzzle.Name = "gameBoxPuzzle";
            this.gameBoxPuzzle.Size = new System.Drawing.Size(560, 510);
            this.gameBoxPuzzle.TabIndex = 5;
            this.gameBoxPuzzle.TabStop = false;
            this.gameBoxPuzzle.Text = "Game";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 669);
            this.Controls.Add(this.gameBoxPuzzle);
            this.Controls.Add(this.groupBox1);
            this.Name = "StartForm";
            this.Text = "Puzzle";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button imgBrowseBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox squaresNrComboBox;
        private System.Windows.Forms.GroupBox gameBoxPuzzle;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
    }
}

