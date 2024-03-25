namespace DetectFaceTester
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTest = new Button();
            pictureBox1 = new PictureBox();
            txtImagePath = new TextBox();
            btnSet = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtTest
            // 
            txtTest.Location = new Point(542, 12);
            txtTest.Name = "txtTest";
            txtTest.Size = new Size(84, 23);
            txtTest.TabIndex = 0;
            txtTest.Text = "테스트 실행";
            txtTest.UseVisualStyleBackColor = true;
            txtTest.Click += txtTest_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(614, 513);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtImagePath
            // 
            txtImagePath.Location = new Point(12, 12);
            txtImagePath.Name = "txtImagePath";
            txtImagePath.ReadOnly = true;
            txtImagePath.Size = new Size(419, 23);
            txtImagePath.TabIndex = 2;
            // 
            // btnSet
            // 
            btnSet.Location = new Point(437, 12);
            btnSet.Name = "btnSet";
            btnSet.Size = new Size(35, 23);
            btnSet.TabIndex = 3;
            btnSet.Text = "...";
            btnSet.UseVisualStyleBackColor = true;
            btnSet.Click += btnSet_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 606);
            Controls.Add(btnSet);
            Controls.Add(txtImagePath);
            Controls.Add(pictureBox1);
            Controls.Add(txtTest);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button txtTest;
        private PictureBox pictureBox1;
        private TextBox txtImagePath;
        private Button btnSet;
    }
}
