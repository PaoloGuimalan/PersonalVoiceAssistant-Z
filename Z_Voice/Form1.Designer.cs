
namespace Z_Voice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.gunaCircleProgressBar1 = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.gunaCircleProgressBar2 = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.Label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.bunifuGradientPanel1.SuspendLayout();
            this.gunaCircleProgressBar1.SuspendLayout();
            this.gunaCircleProgressBar2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 255;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.gunaCircleProgressBar1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.Black;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(219, 219);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // gunaCircleProgressBar1
            // 
            this.gunaCircleProgressBar1.Animated = true;
            this.gunaCircleProgressBar1.AnimationSpeed = 0.6F;
            this.gunaCircleProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.gunaCircleProgressBar1.BaseColor = System.Drawing.Color.Transparent;
            this.gunaCircleProgressBar1.Controls.Add(this.gunaCircleProgressBar2);
            this.gunaCircleProgressBar1.IdleColor = System.Drawing.Color.Cyan;
            this.gunaCircleProgressBar1.IdleOffset = 10;
            this.gunaCircleProgressBar1.IdleThickness = 5;
            this.gunaCircleProgressBar1.Image = null;
            this.gunaCircleProgressBar1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaCircleProgressBar1.Location = new System.Drawing.Point(2, 4);
            this.gunaCircleProgressBar1.Name = "gunaCircleProgressBar1";
            this.gunaCircleProgressBar1.ProgressMaxColor = System.Drawing.Color.Lime;
            this.gunaCircleProgressBar1.ProgressMinColor = System.Drawing.Color.Lime;
            this.gunaCircleProgressBar1.ProgressOffset = 5;
            this.gunaCircleProgressBar1.ProgressThickness = 13;
            this.gunaCircleProgressBar1.Size = new System.Drawing.Size(216, 213);
            this.gunaCircleProgressBar1.TabIndex = 4;
            this.gunaCircleProgressBar1.Value = 30;
            this.gunaCircleProgressBar1.Click += new System.EventHandler(this.gunaCircleProgressBar1_Click);
            // 
            // gunaCircleProgressBar2
            // 
            this.gunaCircleProgressBar2.Animated = true;
            this.gunaCircleProgressBar2.AnimationSpeed = 0.6F;
            this.gunaCircleProgressBar2.Backwards = true;
            this.gunaCircleProgressBar2.BaseColor = System.Drawing.Color.Transparent;
            this.gunaCircleProgressBar2.Controls.Add(this.Label2);
            this.gunaCircleProgressBar2.Controls.Add(this.panel4);
            this.gunaCircleProgressBar2.Controls.Add(this.panel3);
            this.gunaCircleProgressBar2.Controls.Add(this.panel2);
            this.gunaCircleProgressBar2.Controls.Add(this.panel1);
            this.gunaCircleProgressBar2.Controls.Add(this.pictureBox2);
            this.gunaCircleProgressBar2.Controls.Add(this.pictureBox1);
            this.gunaCircleProgressBar2.IdleColor = System.Drawing.Color.Cyan;
            this.gunaCircleProgressBar2.IdleOffset = 10;
            this.gunaCircleProgressBar2.IdleThickness = 5;
            this.gunaCircleProgressBar2.Image = null;
            this.gunaCircleProgressBar2.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaCircleProgressBar2.Location = new System.Drawing.Point(23, 21);
            this.gunaCircleProgressBar2.Name = "gunaCircleProgressBar2";
            this.gunaCircleProgressBar2.ProgressMaxColor = System.Drawing.Color.Lime;
            this.gunaCircleProgressBar2.ProgressMinColor = System.Drawing.Color.Lime;
            this.gunaCircleProgressBar2.ProgressOffset = 3;
            this.gunaCircleProgressBar2.ProgressThickness = 13;
            this.gunaCircleProgressBar2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gunaCircleProgressBar2.Size = new System.Drawing.Size(173, 172);
            this.gunaCircleProgressBar2.TabIndex = 5;
            this.gunaCircleProgressBar2.Value = 25;
            this.gunaCircleProgressBar2.Click += new System.EventHandler(this.gunaCircleProgressBar2_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Cyan;
            this.Label2.Location = new System.Drawing.Point(32, 76);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(108, 20);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "I\'m 1011010";
            this.Label2.Click += new System.EventHandler(this.Label2_Click_1);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(95, 67);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(59, 17);
            this.panel4.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(95, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(59, 15);
            this.panel3.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(21, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(59, 15);
            this.panel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(21, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(59, 17);
            this.panel1.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Z_Voice.Properties.Resources.maxresdefault_removebg_preview;
            this.pictureBox2.Location = new System.Drawing.Point(95, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(59, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Z_Voice.Properties.Resources.maxresdefault_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(21, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 219);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Z";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.gunaCircleProgressBar1.ResumeLayout(false);
            this.gunaCircleProgressBar2.ResumeLayout(false);
            this.gunaCircleProgressBar2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Guna.UI.WinForms.GunaCircleProgressBar gunaCircleProgressBar1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI.WinForms.GunaCircleProgressBar gunaCircleProgressBar2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer2;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Timer timer3;
    }
}

