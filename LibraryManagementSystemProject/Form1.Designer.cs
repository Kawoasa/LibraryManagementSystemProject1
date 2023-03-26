using static Guna.UI2.WinForms.Suite.Descriptions;
using static System.Net.Mime.MediaTypeNames;

namespace ManagementLibraryProject
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            MyProcess = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(508, 38);
            label1.TabIndex = 0;
            label1.Text = "LibraryManagementSystem";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(385, 60);
            label2.Name = "label2";
            label2.Size = new Size(148, 29);
            label2.TabIndex = 1;
            label2.Text = "Version 1.0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(184, 248);
            label3.Name = "label3";
            label3.Size = new Size(201, 29);
            label3.TabIndex = 2;
            label3.Text = "PoweredByKasa";
            // 
            // MyProcess
            // 
            MyProcess.FillColor = Color.FromArgb(200, 213, 218, 223);
            MyProcess.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MyProcess.ForeColor = Color.White;
            MyProcess.Location = new Point(219, 100);
            MyProcess.Minimum = 0;
            MyProcess.Name = "MyProcess";
            MyProcess.ProgressColor = Color.FromArgb(0, 64, 0);
            MyProcess.ShadowDecoration.CustomizableEdges = customizableEdges2;
            MyProcess.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            MyProcess.Size = new Size(130, 130);
            MyProcess.TabIndex = 3;
            MyProcess.Text = "guna2CircleProgressBar1";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(550, 300);
            Controls.Add(MyProcess);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2CircleProgressBar MyProcess;
        private System.Windows.Forms.Timer timer1;
    }
}