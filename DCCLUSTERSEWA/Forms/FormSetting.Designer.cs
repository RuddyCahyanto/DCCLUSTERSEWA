
namespace DCCLUSTERSEWA.Forms
{
    partial class FormSetting
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
            this.tbKodeDC = new System.Windows.Forms.TextBox();
            this.tbNamaDC = new System.Windows.Forms.TextBox();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.btnDirBackup = new System.Windows.Forms.Button();
            this.tbDirBackup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbNPBRPB = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbNmFileRPB = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNmFileNPB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gbRadButNPBRPB = new System.Windows.Forms.GroupBox();
            this.rbKoma = new System.Windows.Forms.RadioButton();
            this.rbPipe = new System.Windows.Forms.RadioButton();
            this.gbPassMenu = new System.Windows.Forms.GroupBox();
            this.btnNewPassKunci = new System.Windows.Forms.Button();
            this.btnNewPassMobil = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbConnection.SuspendLayout();
            this.gbNPBRPB.SuspendLayout();
            this.gbRadButNPBRPB.SuspendLayout();
            this.gbPassMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DC: ";
            // 
            // tbKodeDC
            // 
            this.tbKodeDC.Enabled = false;
            this.tbKodeDC.Location = new System.Drawing.Point(47, 10);
            this.tbKodeDC.Name = "tbKodeDC";
            this.tbKodeDC.Size = new System.Drawing.Size(65, 20);
            this.tbKodeDC.TabIndex = 1;
            // 
            // tbNamaDC
            // 
            this.tbNamaDC.Enabled = false;
            this.tbNamaDC.Location = new System.Drawing.Point(128, 10);
            this.tbNamaDC.Name = "tbNamaDC";
            this.tbNamaDC.Size = new System.Drawing.Size(188, 20);
            this.tbNamaDC.TabIndex = 2;
            // 
            // gbConnection
            // 
            this.gbConnection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConnection.Controls.Add(this.btnTestConn);
            this.gbConnection.Controls.Add(this.btnDirBackup);
            this.gbConnection.Controls.Add(this.tbDirBackup);
            this.gbConnection.Controls.Add(this.label5);
            this.gbConnection.Controls.Add(this.tbPassword);
            this.gbConnection.Controls.Add(this.label4);
            this.gbConnection.Controls.Add(this.tbUser);
            this.gbConnection.Controls.Add(this.label3);
            this.gbConnection.Controls.Add(this.tbServer);
            this.gbConnection.Controls.Add(this.label2);
            this.gbConnection.Location = new System.Drawing.Point(16, 51);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(772, 131);
            this.gbConnection.TabIndex = 3;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // btnTestConn
            // 
            this.btnTestConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestConn.FlatAppearance.BorderSize = 0;
            this.btnTestConn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConn.Location = new System.Drawing.Point(660, 67);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(106, 23);
            this.btnTestConn.TabIndex = 11;
            this.btnTestConn.Text = "Test Connection";
            this.btnTestConn.UseVisualStyleBackColor = true;
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // btnDirBackup
            // 
            this.btnDirBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDirBackup.FlatAppearance.BorderSize = 0;
            this.btnDirBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirBackup.Location = new System.Drawing.Point(732, 95);
            this.btnDirBackup.Name = "btnDirBackup";
            this.btnDirBackup.Size = new System.Drawing.Size(34, 22);
            this.btnDirBackup.TabIndex = 10;
            this.btnDirBackup.Text = "...";
            this.btnDirBackup.UseVisualStyleBackColor = true;
            this.btnDirBackup.Click += new System.EventHandler(this.btnDirBackup_Click);
            // 
            // tbDirBackup
            // 
            this.tbDirBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirBackup.Location = new System.Drawing.Point(95, 97);
            this.tbDirBackup.Name = "tbDirBackup";
            this.tbDirBackup.Size = new System.Drawing.Size(631, 20);
            this.tbDirBackup.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dir. Backup: ";
            // 
            // tbPassword
            // 
            this.tbPassword.Enabled = false;
            this.tbPassword.Location = new System.Drawing.Point(95, 71);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(205, 20);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password: ";
            // 
            // tbUser
            // 
            this.tbUser.Enabled = false;
            this.tbUser.Location = new System.Drawing.Point(95, 45);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(205, 20);
            this.tbUser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "User: ";
            // 
            // tbServer
            // 
            this.tbServer.Enabled = false;
            this.tbServer.Location = new System.Drawing.Point(95, 19);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(205, 20);
            this.tbServer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server: ";
            // 
            // gbNPBRPB
            // 
            this.gbNPBRPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNPBRPB.Controls.Add(this.label14);
            this.gbNPBRPB.Controls.Add(this.label13);
            this.gbNPBRPB.Controls.Add(this.tbNmFileRPB);
            this.gbNPBRPB.Controls.Add(this.label11);
            this.gbNPBRPB.Controls.Add(this.tbNmFileNPB);
            this.gbNPBRPB.Controls.Add(this.label12);
            this.gbNPBRPB.Controls.Add(this.gbRadButNPBRPB);
            this.gbNPBRPB.Location = new System.Drawing.Point(16, 201);
            this.gbNPBRPB.Name = "gbNPBRPB";
            this.gbNPBRPB.Size = new System.Drawing.Size(772, 157);
            this.gbNPBRPB.TabIndex = 14;
            this.gbNPBRPB.TabStop = false;
            this.gbNPBRPB.Text = "File NPB/RPB";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(158, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(397, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "+kddc+kdtoko+yyyyMMddHHmm.CSV      Cth: RPBG001T001202109150749.CSV";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(158, 78);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(397, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "+kddc+kdtoko+yyyyMMddHHmm.CSV      Cth: NPBG001T001202109150749.CSV";
            // 
            // tbNmFileRPB
            // 
            this.tbNmFileRPB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNmFileRPB.Location = new System.Drawing.Point(95, 101);
            this.tbNmFileRPB.Name = "tbNmFileRPB";
            this.tbNmFileRPB.Size = new System.Drawing.Size(57, 20);
            this.tbNmFileRPB.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Nama File RPB: ";
            // 
            // tbNmFileNPB
            // 
            this.tbNmFileNPB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbNmFileNPB.Location = new System.Drawing.Point(95, 75);
            this.tbNmFileNPB.Name = "tbNmFileNPB";
            this.tbNmFileNPB.Size = new System.Drawing.Size(57, 20);
            this.tbNmFileNPB.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Nama File NPB: ";
            // 
            // gbRadButNPBRPB
            // 
            this.gbRadButNPBRPB.Controls.Add(this.rbKoma);
            this.gbRadButNPBRPB.Controls.Add(this.rbPipe);
            this.gbRadButNPBRPB.Location = new System.Drawing.Point(6, 19);
            this.gbRadButNPBRPB.Name = "gbRadButNPBRPB";
            this.gbRadButNPBRPB.Size = new System.Drawing.Size(191, 50);
            this.gbRadButNPBRPB.TabIndex = 14;
            this.gbRadButNPBRPB.TabStop = false;
            // 
            // rbKoma
            // 
            this.rbKoma.AutoSize = true;
            this.rbKoma.Enabled = false;
            this.rbKoma.Location = new System.Drawing.Point(98, 20);
            this.rbKoma.Name = "rbKoma";
            this.rbKoma.Size = new System.Drawing.Size(64, 17);
            this.rbKoma.TabIndex = 1;
            this.rbKoma.Text = "Koma (,)";
            this.rbKoma.UseVisualStyleBackColor = true;
            // 
            // rbPipe
            // 
            this.rbPipe.AutoSize = true;
            this.rbPipe.Checked = true;
            this.rbPipe.Location = new System.Drawing.Point(7, 20);
            this.rbPipe.Name = "rbPipe";
            this.rbPipe.Size = new System.Drawing.Size(57, 17);
            this.rbPipe.TabIndex = 0;
            this.rbPipe.TabStop = true;
            this.rbPipe.Text = "Pipe (|)";
            this.rbPipe.UseVisualStyleBackColor = true;
            // 
            // gbPassMenu
            // 
            this.gbPassMenu.Controls.Add(this.btnNewPassKunci);
            this.gbPassMenu.Controls.Add(this.btnNewPassMobil);
            this.gbPassMenu.Location = new System.Drawing.Point(16, 379);
            this.gbPassMenu.Name = "gbPassMenu";
            this.gbPassMenu.Size = new System.Drawing.Size(258, 78);
            this.gbPassMenu.TabIndex = 15;
            this.gbPassMenu.TabStop = false;
            this.gbPassMenu.Text = "Password Menu";
            // 
            // btnNewPassKunci
            // 
            this.btnNewPassKunci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewPassKunci.FlatAppearance.BorderSize = 0;
            this.btnNewPassKunci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPassKunci.Location = new System.Drawing.Point(136, 32);
            this.btnNewPassKunci.Name = "btnNewPassKunci";
            this.btnNewPassKunci.Size = new System.Drawing.Size(116, 35);
            this.btnNewPassKunci.TabIndex = 1;
            this.btnNewPassKunci.Text = "Password Kunci";
            this.btnNewPassKunci.UseVisualStyleBackColor = true;
            this.btnNewPassKunci.Click += new System.EventHandler(this.btnNewPassKunci_Click);
            // 
            // btnNewPassMobil
            // 
            this.btnNewPassMobil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewPassMobil.FlatAppearance.BorderSize = 0;
            this.btnNewPassMobil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPassMobil.Location = new System.Drawing.Point(7, 32);
            this.btnNewPassMobil.Name = "btnNewPassMobil";
            this.btnNewPassMobil.Size = new System.Drawing.Size(109, 35);
            this.btnNewPassMobil.TabIndex = 0;
            this.btnNewPassMobil.Text = "Password Mobil";
            this.btnNewPassMobil.UseVisualStyleBackColor = true;
            this.btnNewPassMobil.Click += new System.EventHandler(this.btnNewPassMobil_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DCCLUSTERSEWA.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(679, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(109, 48);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "   Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 474);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbPassMenu);
            this.Controls.Add(this.gbNPBRPB);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.tbNamaDC);
            this.Controls.Add(this.tbKodeDC);
            this.Controls.Add(this.label1);
            this.Name = "FormSetting";
            this.Text = "SETTING";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbNPBRPB.ResumeLayout(false);
            this.gbNPBRPB.PerformLayout();
            this.gbRadButNPBRPB.ResumeLayout(false);
            this.gbRadButNPBRPB.PerformLayout();
            this.gbPassMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKodeDC;
        private System.Windows.Forms.TextBox tbNamaDC;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Button btnDirBackup;
        private System.Windows.Forms.TextBox tbDirBackup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.GroupBox gbNPBRPB;
        private System.Windows.Forms.GroupBox gbRadButNPBRPB;
        private System.Windows.Forms.RadioButton rbKoma;
        private System.Windows.Forms.RadioButton rbPipe;
        private System.Windows.Forms.TextBox tbNmFileRPB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNmFileNPB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gbPassMenu;
        private System.Windows.Forms.Button btnNewPassKunci;
        private System.Windows.Forms.Button btnNewPassMobil;
        private System.Windows.Forms.Button btnSave;
    }
}