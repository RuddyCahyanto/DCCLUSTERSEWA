
namespace DCCLUSTERSEWA.Forms
{
    partial class FormSupir
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
            this.dgvMasterSupir = new System.Windows.Forms.DataGridView();
            this.nikDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kelompokDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utamaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supirBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset = new DCCLUSTERSEWA.Datasets.Dataset();
            this.dgvFilterKlmpk = new System.Windows.Forms.DataGridView();
            this.kelompok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterSupir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supirBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilterKlmpk)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMasterSupir
            // 
            this.dgvMasterSupir.AllowUserToAddRows = false;
            this.dgvMasterSupir.AllowUserToDeleteRows = false;
            this.dgvMasterSupir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMasterSupir.AutoGenerateColumns = false;
            this.dgvMasterSupir.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMasterSupir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMasterSupir.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nikDataGridViewTextBoxColumn,
            this.namaDataGridViewTextBoxColumn,
            this.kelompokDataGridViewTextBoxColumn,
            this.utamaDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgvMasterSupir.DataSource = this.supirBindingSource;
            this.dgvMasterSupir.Location = new System.Drawing.Point(12, 12);
            this.dgvMasterSupir.Name = "dgvMasterSupir";
            this.dgvMasterSupir.ReadOnly = true;
            this.dgvMasterSupir.Size = new System.Drawing.Size(710, 404);
            this.dgvMasterSupir.TabIndex = 10;
            // 
            // nikDataGridViewTextBoxColumn
            // 
            this.nikDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nikDataGridViewTextBoxColumn.DataPropertyName = "nik";
            this.nikDataGridViewTextBoxColumn.HeaderText = "NIK";
            this.nikDataGridViewTextBoxColumn.Name = "nikDataGridViewTextBoxColumn";
            this.nikDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // namaDataGridViewTextBoxColumn
            // 
            this.namaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.namaDataGridViewTextBoxColumn.DataPropertyName = "nama";
            this.namaDataGridViewTextBoxColumn.HeaderText = "Nama";
            this.namaDataGridViewTextBoxColumn.Name = "namaDataGridViewTextBoxColumn";
            this.namaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kelompokDataGridViewTextBoxColumn
            // 
            this.kelompokDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.kelompokDataGridViewTextBoxColumn.DataPropertyName = "kelompok";
            this.kelompokDataGridViewTextBoxColumn.HeaderText = "Kelompok";
            this.kelompokDataGridViewTextBoxColumn.Name = "kelompokDataGridViewTextBoxColumn";
            this.kelompokDataGridViewTextBoxColumn.ReadOnly = true;
            this.kelompokDataGridViewTextBoxColumn.Width = 79;
            // 
            // utamaDataGridViewTextBoxColumn
            // 
            this.utamaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.utamaDataGridViewTextBoxColumn.DataPropertyName = "utama";
            this.utamaDataGridViewTextBoxColumn.HeaderText = "Utama";
            this.utamaDataGridViewTextBoxColumn.Name = "utamaDataGridViewTextBoxColumn";
            this.utamaDataGridViewTextBoxColumn.ReadOnly = true;
            this.utamaDataGridViewTextBoxColumn.Width = 63;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 62;
            // 
            // supirBindingSource
            // 
            this.supirBindingSource.DataMember = "Supir";
            this.supirBindingSource.DataSource = this.dataset;
            // 
            // dataset
            // 
            this.dataset.DataSetName = "Dataset";
            this.dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvFilterKlmpk
            // 
            this.dgvFilterKlmpk.AllowUserToAddRows = false;
            this.dgvFilterKlmpk.AllowUserToDeleteRows = false;
            this.dgvFilterKlmpk.AllowUserToResizeColumns = false;
            this.dgvFilterKlmpk.AllowUserToResizeRows = false;
            this.dgvFilterKlmpk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFilterKlmpk.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFilterKlmpk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilterKlmpk.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kelompok});
            this.dgvFilterKlmpk.Location = new System.Drawing.Point(752, 12);
            this.dgvFilterKlmpk.Name = "dgvFilterKlmpk";
            this.dgvFilterKlmpk.RowHeadersVisible = false;
            this.dgvFilterKlmpk.Size = new System.Drawing.Size(83, 404);
            this.dgvFilterKlmpk.TabIndex = 12;
            this.dgvFilterKlmpk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilterKlmpk_CellClick);
            // 
            // kelompok
            // 
            this.kelompok.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kelompok.HeaderText = "Kelompok";
            this.kelompok.Name = "kelompok";
            this.kelompok.ReadOnly = true;
            // 
            // FormSupir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 450);
            this.Controls.Add(this.dgvFilterKlmpk);
            this.Controls.Add(this.dgvMasterSupir);
            this.Name = "FormSupir";
            this.Text = "SUPIR";
            this.Load += new System.EventHandler(this.FormSupir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterSupir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supirBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilterKlmpk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMasterSupir;
        private System.Windows.Forms.BindingSource supirBindingSource;
        private Datasets.Dataset dataset;
        private System.Windows.Forms.DataGridView dgvFilterKlmpk;
        private System.Windows.Forms.DataGridViewTextBoxColumn kelompok;
        private System.Windows.Forms.DataGridViewTextBoxColumn nikDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kelompokDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn utamaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}