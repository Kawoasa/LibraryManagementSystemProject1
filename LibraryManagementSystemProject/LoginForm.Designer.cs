using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;

namespace ManagementLibraryProject
{
    partial class LoginForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            label2 = new Label();
            tbPass = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            tbUser = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            label4 = new Label();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(tbPass);
            panel1.Controls.Add(guna2HtmlLabel2);
            panel1.Controls.Add(guna2HtmlLabel1);
            panel1.Controls.Add(tbUser);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -7);
            panel1.Name = "panel1";
            panel1.Size = new Size(279, 310);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Teal;
            label2.Location = new Point(108, 246);
            label2.Name = "label2";
            label2.Size = new Size(54, 18);
            label2.TabIndex = 7;
            label2.Text = "Clear";
            label2.Click += label2_Click;
            // 
            // tbPass
            // 
            tbPass.CustomizableEdges = customizableEdges3;
            tbPass.DefaultText = "";
            tbPass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPass.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbPass.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPass.Location = new Point(116, 149);
            tbPass.Name = "tbPass";
            tbPass.PasswordChar = '\0';
            tbPass.PlaceholderText = "";
            tbPass.SelectedText = "";
            tbPass.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbPass.Size = new Size(120, 23);
            tbPass.TabIndex = 4;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel2.Location = new Point(43, 152);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(62, 18);
            guna2HtmlLabel2.TabIndex = 3;
            guna2HtmlLabel2.Text = "Password";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            guna2HtmlLabel1.Location = new Point(43, 97);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(66, 18);
            guna2HtmlLabel1.TabIndex = 2;
            guna2HtmlLabel1.Text = "Username";
            // 
            // tbUser
            // 
            tbUser.CustomizableEdges = customizableEdges5;
            tbUser.DefaultText = "";
            tbUser.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbUser.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbUser.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbUser.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbUser.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUser.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbUser.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUser.Location = new Point(116, 95);
            tbUser.Name = "tbUser";
            tbUser.PasswordChar = '\0';
            tbUser.PlaceholderText = "";
            tbUser.SelectedText = "";
            tbUser.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbUser.Size = new Size(120, 23);
            tbUser.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(69, 29);
            label1.Name = "label1";
            label1.Size = new Size(143, 23);
            label1.TabIndex = 0;
            label1.Text = "USER LOGIN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(285, 124);
            label4.Name = "label4";
            label4.Size = new Size(261, 29);
            label4.TabIndex = 9;
            label4.Text = "CENTRAL LIBRARY";
            // 
            // btnLogin
            // 
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.Teal;
            btnLogin.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(80, 199);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(114, 33);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = LibraryManagementSystemProject.Properties.Resources.zyro_image;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(550, 300);
            Controls.Add(label4);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbPass;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox tbUser;
        private Label label4;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
    }
}