namespace WinFormsApp6
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
            components = new System.ComponentModel.Container();
            picDisplay = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tbDirection = new TrackBar();
            lblDirection = new Label();
            tbGraviton1 = new TrackBar();
            label1 = new Label();
            tbGraviton2 = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            tbParticleCount = new TrackBar();
            label4 = new Label();
            lblCount = new Label();
            ((System.ComponentModel.ISupportInitialize)picDisplay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbParticleCount).BeginInit();
            SuspendLayout();
            // 
            // picDisplay
            // 
            picDisplay.Location = new Point(0, -1);
            picDisplay.Name = "picDisplay";
            picDisplay.Size = new Size(1373, 648);
            picDisplay.TabIndex = 0;
            picDisplay.TabStop = false;
            picDisplay.Click += picDisplay_Click;
            picDisplay.MouseClick += picDisplay_MouseClick;
            picDisplay.MouseMove += picDisplay_MouseMove;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // tbDirection
            // 
            tbDirection.Location = new Point(0, 678);
            tbDirection.Maximum = 359;
            tbDirection.Name = "tbDirection";
            tbDirection.Size = new Size(252, 69);
            tbDirection.TabIndex = 1;
            tbDirection.Scroll += tbDirection_Scroll;
            // 
            // lblDirection
            // 
            lblDirection.AutoSize = true;
            lblDirection.Location = new Point(258, 689);
            lblDirection.Name = "lblDirection";
            lblDirection.Size = new Size(22, 25);
            lblDirection.TabIndex = 2;
            lblDirection.Text = "0";
            // 
            // tbGraviton1
            // 
            tbGraviton1.Location = new Point(332, 678);
            tbGraviton1.Maximum = 359;
            tbGraviton1.Name = "tbGraviton1";
            tbGraviton1.Size = new Size(320, 69);
            tbGraviton1.TabIndex = 3;
            tbGraviton1.Scroll += tbGraviton_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 650);
            label1.Name = "label1";
            label1.Size = new Size(181, 25);
            label1.TabIndex = 4;
            label1.Text = "Направление частиц";
            // 
            // tbGraviton2
            // 
            tbGraviton2.Location = new Point(658, 678);
            tbGraviton2.Maximum = 359;
            tbGraviton2.Name = "tbGraviton2";
            tbGraviton2.Size = new Size(320, 69);
            tbGraviton2.TabIndex = 5;
            tbGraviton2.Scroll += tbGraviton2_Scroll;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(405, 650);
            label2.Name = "label2";
            label2.Size = new Size(155, 25);
            label2.TabIndex = 6;
            label2.Text = "Размер порталов";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(740, 650);
            label3.Name = "label3";
            label3.Size = new Size(158, 25);
            label3.TabIndex = 7;
            label3.Text = "Размер красителя";
            // 
            // tbParticleCount
            // 
            tbParticleCount.Location = new Point(984, 678);
            tbParticleCount.Maximum = 10000;
            tbParticleCount.Name = "tbParticleCount";
            tbParticleCount.Size = new Size(320, 69);
            tbParticleCount.TabIndex = 8;
            tbParticleCount.Scroll += tbParticleCount_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1068, 650);
            label4.Name = "label4";
            label4.Size = new Size(167, 25);
            label4.TabIndex = 9;
            label4.Text = "Количество частиц";
            label4.Click += label4_Click;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(1310, 689);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(22, 25);
            lblCount.TabIndex = 10;
            lblCount.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 743);
            Controls.Add(lblCount);
            Controls.Add(label4);
            Controls.Add(tbParticleCount);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tbGraviton2);
            Controls.Add(label1);
            Controls.Add(tbGraviton1);
            Controls.Add(lblDirection);
            Controls.Add(tbDirection);
            Controls.Add(picDisplay);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picDisplay).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDirection).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbGraviton2).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbParticleCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private TrackBar tbDirection;
        private Label lblDirection;
        private TrackBar tbGraviton1;
        private Label label1;
        private TrackBar tbGraviton2;
        private Label label2;
        private Label label3;
        private TrackBar tbParticleCount;
        private Label label4;
        private Label lblCount;
    }
}