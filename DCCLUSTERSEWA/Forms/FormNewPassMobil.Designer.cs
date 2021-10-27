
namespace DCCLUSTERSEWA.Forms
{
    partial class FormNewPassMobil
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
            this.tbPassLama = new System.Windows.Forms.TextBox();
            this.tbPassBaru = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKonfirPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password Lama: ";
            // 
            // tbPassLama
            // 
            this.tbPassLama.Location = new System.Drawing.Point(113, 40);
            this.tbPassLama.Name = "tbPassLama";
            this.tbPassLama.Size = new System.Drawing.Size(144, 20);
            this.tbPassLama.TabIndex = 1;
            this.tbPassLama.UseSystemPasswordChar = true;
            // 
            // tbPassBaru
            // 
            this.tbPassBaru.Location = new System.Drawing.Point(113, 75);
            this.tbPassBaru.Name = "tbPassBaru";
            this.tbPassBaru.Size = new System.Drawing.Size(144, 20);
            this.tbPassBaru.TabIndex = 3;
            this.tbPassBaru.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password Baru: ";
            // 
            // tbKonfirPass
            // 
            this.tbKonfirPass.Location = new System.Drawing.Point(113, 111);
            this.tbKonfirPass.Name = "tbKonfirPass";
            this.tbKonfirPass.Size = new System.Drawing.Size(144, 20);
            this.tbKonfirPass.TabIndex = 5;
            this.tbKonfirPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Konfirmasi: ";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(174, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormNewPassMobil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 225);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbKonfirPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPassBaru);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPassLama);
            this.Controls.Add(this.label1);
            this.Name = "FormNewPassMobil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Mobil";
            this.Load += new System.EventHandler(this.FormNewPassMobil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassLama;
        private System.Windows.Forms.TextBox tbPassBaru;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKonfirPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
    }
}