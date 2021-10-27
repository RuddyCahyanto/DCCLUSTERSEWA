
namespace DCCLUSTERSEWA.Forms
{
    partial class FormBackup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProsesBackup = new System.Windows.Forms.DataGridView();
            this.bACKUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset = new DCCLUSTERSEWA.Datasets.Dataset();
            this.lblProgressBackup = new System.Windows.Forms.Label();
            this.progressBarBackup = new System.Windows.Forms.ProgressBar();
            this.loadingSpinnerBackup = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateUlangNPB = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.tokcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toknameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProsesBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bACKUPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpinnerBackup)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProsesBackup
            // 
            this.dgvProsesBackup.AllowUserToAddRows = false;
            this.dgvProsesBackup.AllowUserToDeleteRows = false;
            this.dgvProsesBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProsesBackup.AutoGenerateColumns = false;
            this.dgvProsesBackup.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProsesBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProsesBackup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tokcodeDataGridViewTextBoxColumn,
            this.toknameDataGridViewTextBoxColumn,
            this.x});
            this.dgvProsesBackup.DataSource = this.bACKUPBindingSource;
            this.dgvProsesBackup.Location = new System.Drawing.Point(12, 12);
            this.dgvProsesBackup.Name = "dgvProsesBackup";
            this.dgvProsesBackup.ReadOnly = true;
            this.dgvProsesBackup.Size = new System.Drawing.Size(483, 307);
            this.dgvProsesBackup.TabIndex = 18;
            this.dgvProsesBackup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProsesBackup_CellClick);
            // 
            // bACKUPBindingSource
            // 
            this.bACKUPBindingSource.DataMember = "BACKUP";
            this.bACKUPBindingSource.DataSource = this.dataset;
            // 
            // dataset
            // 
            this.dataset.DataSetName = "Dataset";
            this.dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblProgressBackup
            // 
            this.lblProgressBackup.AutoSize = true;
            this.lblProgressBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressBackup.ForeColor = System.Drawing.Color.Black;
            this.lblProgressBackup.Location = new System.Drawing.Point(44, 359);
            this.lblProgressBackup.Name = "lblProgressBackup";
            this.lblProgressBackup.Size = new System.Drawing.Size(153, 17);
            this.lblProgressBackup.TabIndex = 21;
            this.lblProgressBackup.Text = "Progress: Proses NPB ";
            this.lblProgressBackup.Visible = false;
            // 
            // progressBarBackup
            // 
            this.progressBarBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarBackup.Location = new System.Drawing.Point(13, 325);
            this.progressBarBackup.Name = "progressBarBackup";
            this.progressBarBackup.Size = new System.Drawing.Size(482, 23);
            this.progressBarBackup.TabIndex = 22;
            this.progressBarBackup.Visible = false;
            // 
            // loadingSpinnerBackup
            // 
            this.loadingSpinnerBackup.Image = global::DCCLUSTERSEWA.Properties.Resources.spinning_loading;
            this.loadingSpinnerBackup.Location = new System.Drawing.Point(12, 354);
            this.loadingSpinnerBackup.Name = "loadingSpinnerBackup";
            this.loadingSpinnerBackup.Size = new System.Drawing.Size(26, 26);
            this.loadingSpinnerBackup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingSpinnerBackup.TabIndex = 23;
            this.loadingSpinnerBackup.TabStop = false;
            this.loadingSpinnerBackup.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCreateUlangNPB);
            this.panel1.Controls.Add(this.btnBackup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(501, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 432);
            this.panel1.TabIndex = 24;
            // 
            // btnCreateUlangNPB
            // 
            this.btnCreateUlangNPB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCreateUlangNPB.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCreateUlangNPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateUlangNPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUlangNPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateUlangNPB.Image = global::DCCLUSTERSEWA.Properties.Resources.add_file;
            this.btnCreateUlangNPB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateUlangNPB.Location = new System.Drawing.Point(21, 75);
            this.btnCreateUlangNPB.Name = "btnCreateUlangNPB";
            this.btnCreateUlangNPB.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCreateUlangNPB.Size = new System.Drawing.Size(165, 48);
            this.btnCreateUlangNPB.TabIndex = 22;
            this.btnCreateUlangNPB.Text = "  Create Ulang NPB";
            this.btnCreateUlangNPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateUlangNPB.UseVisualStyleBackColor = false;
            this.btnCreateUlangNPB.Click += new System.EventHandler(this.btnCreateUlangNPB_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBackup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Image = global::DCCLUSTERSEWA.Properties.Resources.arrow;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(21, 12);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBackup.Size = new System.Drawing.Size(115, 48);
            this.btnBackup.TabIndex = 21;
            this.btnBackup.Text = "  Backup";
            this.btnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // tokcodeDataGridViewTextBoxColumn
            // 
            this.tokcodeDataGridViewTextBoxColumn.DataPropertyName = "tok_kode";
            this.tokcodeDataGridViewTextBoxColumn.HeaderText = "Kode Toko";
            this.tokcodeDataGridViewTextBoxColumn.Name = "tokcodeDataGridViewTextBoxColumn";
            this.tokcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tokcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // toknameDataGridViewTextBoxColumn
            // 
            this.toknameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.toknameDataGridViewTextBoxColumn.DataPropertyName = "tok_name";
            this.toknameDataGridViewTextBoxColumn.HeaderText = "Nama Toko";
            this.toknameDataGridViewTextBoxColumn.Name = "toknameDataGridViewTextBoxColumn";
            this.toknameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // x
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Red;
            this.x.DefaultCellStyle = dataGridViewCellStyle1;
            this.x.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.x.HeaderText = "";
            this.x.Name = "x";
            this.x.ReadOnly = true;
            this.x.Text = "x";
            this.x.UseColumnTextForButtonValue = true;
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(766, 432);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loadingSpinnerBackup);
            this.Controls.Add(this.progressBarBackup);
            this.Controls.Add(this.lblProgressBackup);
            this.Controls.Add(this.dgvProsesBackup);
            this.Name = "FormBackup";
            this.Text = "NPB DC SEWA | V1000";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProsesBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bACKUPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpinnerBackup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProsesBackup;
        private System.Windows.Forms.Label lblProgressBackup;
        private System.Windows.Forms.ProgressBar progressBarBackup;
        private System.Windows.Forms.PictureBox loadingSpinnerBackup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateUlangNPB;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.BindingSource bACKUPBindingSource;
        private Datasets.Dataset dataset;
        private System.Windows.Forms.DataGridViewTextBoxColumn tokcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toknameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn x;
    }
}