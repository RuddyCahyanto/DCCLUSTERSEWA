
namespace DCCLUSTERSEWA.Forms
{
    partial class FormCreateUlangNPB
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
            this.tbFolderBackup = new System.Windows.Forms.TextBox();
            this.btnDir = new System.Windows.Forms.Button();
            this.tbKodeToko = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateNPB = new System.Windows.Forms.Button();
            this.loadingSpinnerCreateNPB = new System.Windows.Forms.PictureBox();
            this.progressBarCreateNPB = new System.Windows.Forms.ProgressBar();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpinnerCreateNPB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tanggal: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder Backup: ";
            // 
            // tbFolderBackup
            // 
            this.tbFolderBackup.Location = new System.Drawing.Point(100, 55);
            this.tbFolderBackup.Name = "tbFolderBackup";
            this.tbFolderBackup.Size = new System.Drawing.Size(264, 20);
            this.tbFolderBackup.TabIndex = 3;
            // 
            // btnDir
            // 
            this.btnDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDir.Location = new System.Drawing.Point(370, 53);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(32, 23);
            this.btnDir.TabIndex = 4;
            this.btnDir.Text = "...";
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // tbKodeToko
            // 
            this.tbKodeToko.Location = new System.Drawing.Point(100, 88);
            this.tbKodeToko.Name = "tbKodeToko";
            this.tbKodeToko.Size = new System.Drawing.Size(98, 20);
            this.tbKodeToko.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kode Toko: ";
            // 
            // btnCreateNPB
            // 
            this.btnCreateNPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateNPB.Location = new System.Drawing.Point(100, 125);
            this.btnCreateNPB.Name = "btnCreateNPB";
            this.btnCreateNPB.Size = new System.Drawing.Size(134, 36);
            this.btnCreateNPB.TabIndex = 7;
            this.btnCreateNPB.Text = "Create Ulang NPB";
            this.btnCreateNPB.UseVisualStyleBackColor = true;
            this.btnCreateNPB.Click += new System.EventHandler(this.btnCreateNPB_Click);
            // 
            // loadingSpinnerCreateNPB
            // 
            this.loadingSpinnerCreateNPB.Image = global::DCCLUSTERSEWA.Properties.Resources.spinning_loading;
            this.loadingSpinnerCreateNPB.Location = new System.Drawing.Point(240, 125);
            this.loadingSpinnerCreateNPB.Name = "loadingSpinnerCreateNPB";
            this.loadingSpinnerCreateNPB.Size = new System.Drawing.Size(38, 36);
            this.loadingSpinnerCreateNPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingSpinnerCreateNPB.TabIndex = 24;
            this.loadingSpinnerCreateNPB.TabStop = false;
            this.loadingSpinnerCreateNPB.Visible = false;
            // 
            // progressBarCreateNPB
            // 
            this.progressBarCreateNPB.Location = new System.Drawing.Point(100, 167);
            this.progressBarCreateNPB.Name = "progressBarCreateNPB";
            this.progressBarCreateNPB.Size = new System.Drawing.Size(264, 23);
            this.progressBarCreateNPB.TabIndex = 25;
            this.progressBarCreateNPB.Visible = false;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggal.Location = new System.Drawing.Point(101, 23);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggal.TabIndex = 26;
            // 
            // FormCreateNPB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 210);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.progressBarCreateNPB);
            this.Controls.Add(this.loadingSpinnerCreateNPB);
            this.Controls.Add(this.btnCreateNPB);
            this.Controls.Add(this.tbKodeToko);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDir);
            this.Controls.Add(this.tbFolderBackup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCreateNPB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CREATE ULANG NPB | V1000";
            this.Load += new System.EventHandler(this.FormCreateNPB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpinnerCreateNPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFolderBackup;
        private System.Windows.Forms.Button btnDir;
        private System.Windows.Forms.TextBox tbKodeToko;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateNPB;
        private System.Windows.Forms.PictureBox loadingSpinnerCreateNPB;
        private System.Windows.Forms.ProgressBar progressBarCreateNPB;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
    }
}