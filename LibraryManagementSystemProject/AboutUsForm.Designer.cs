namespace LibraryManagementSystemProject
{
    partial class AboutUsForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUsForm));
            label1 = new Label();
            panel1 = new Panel();
            btnReturn = new Guna.UI2.WinForms.Guna2Button();
            guna2Button9 = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 21F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(210, 36);
            label1.Name = "label1";
            label1.Size = new Size(242, 34);
            label1.TabIndex = 3;
            label1.Text = "BakasaLibrary";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Turquoise;
            panel1.Controls.Add(btnReturn);
            panel1.Controls.Add(guna2Button9);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 100);
            panel1.TabIndex = 5;
            // 
            // btnReturn
            // 
            btnReturn.CustomizableEdges = customizableEdges1;
            btnReturn.DisabledState.BorderColor = Color.DarkGray;
            btnReturn.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReturn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReturn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReturn.FillColor = Color.Turquoise;
            btnReturn.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(12, 30);
            btnReturn.Name = "btnReturn";
            btnReturn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnReturn.Size = new Size(79, 45);
            btnReturn.TabIndex = 93;
            btnReturn.Text = "Return Book";
            btnReturn.Click += btnReturn_Click;
            // 
            // guna2Button9
            // 
            guna2Button9.BackColor = Color.Turquoise;
            guna2Button9.CustomizableEdges = customizableEdges3;
            guna2Button9.DisabledState.BorderColor = Color.DarkGray;
            guna2Button9.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button9.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button9.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button9.FillColor = Color.Turquoise;
            guna2Button9.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button9.ForeColor = Color.White;
            guna2Button9.Image = Properties.Resources.images__2__preview_rev_1;
            guna2Button9.Location = new Point(505, 0);
            guna2Button9.Name = "guna2Button9";
            guna2Button9.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button9.Size = new Size(45, 28);
            guna2Button9.TabIndex = 7;
            guna2Button9.Click += guna2Button9_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Georgia", 21F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(75, 136);
            label2.Name = "label2";
            label2.Size = new Size(433, 32);
            label2.TabIndex = 8;
            label2.Text = "BakasaLibrary make by Kasa";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Georgia", 21F, FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(155, 168);
            label3.Name = "label3";
            label3.Size = new Size(271, 32);
            label3.TabIndex = 9;
            label3.Text = "Get better every day";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Turquoise;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Enabled = false;
            pictureBox2.Image = Properties.Resources.pngwing_com__1_;
            pictureBox2.Location = new Point(130, 33);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(74, 40);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // AboutUsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.zyro_image;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(550, 300);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AboutUsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AboutUsForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button9;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2Button btnReturn;
        private PictureBox pictureBox2;
    }
}