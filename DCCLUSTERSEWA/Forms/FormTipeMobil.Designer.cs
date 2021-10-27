
namespace DCCLUSTERSEWA.Forms
{
    partial class FormTipeMobil
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
            this.dgvMasterTipeMobil = new System.Windows.Forms.DataGridView();
            this.alltoboxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinggiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lebarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panjangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kapasitasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tIPEMOBILBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset = new DCCLUSTERSEWA.Datasets.Dataset();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterTipeMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIPEMOBILBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMasterTipeMobil
            // 
            this.dgvMasterTipeMobil.AllowUserToAddRows = false;
            this.dgvMasterTipeMobil.AllowUserToDeleteRows = false;
            this.dgvMasterTipeMobil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMasterTipeMobil.AutoGenerateColumns = false;
            this.dgvMasterTipeMobil.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMasterTipeMobil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMasterTipeMobil.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alltoboxDataGridViewTextBoxColumn,
            this.kodeDataGridViewTextBoxColumn,
            this.tipeDataGridViewTextBoxColumn,
            this.tinggiDataGridViewTextBoxColumn,
            this.lebarDataGridViewTextBoxColumn,
            this.panjangDataGridViewTextBoxColumn,
            this.kapasitasDataGridViewTextBoxColumn});
            this.dgvMasterTipeMobil.DataSource = this.tIPEMOBILBindingSource;
            this.dgvMasterTipeMobil.Location = new System.Drawing.Point(15, 12);
            this.dgvMasterTipeMobil.Name = "dgvMasterTipeMobil";
            this.dgvMasterTipeMobil.ReadOnly = true;
            this.dgvMasterTipeMobil.Size = new System.Drawing.Size(832, 301);
            this.dgvMasterTipeMobil.TabIndex = 10;
            // 
            // alltoboxDataGridViewTextBoxColumn
            // 
            this.alltoboxDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.alltoboxDataGridViewTextBoxColumn.DataPropertyName = "alltobox";
            this.alltoboxDataGridViewTextBoxColumn.HeaderText = "All To Box (%)";
            this.alltoboxDataGridViewTextBoxColumn.Name = "alltoboxDataGridViewTextBoxColumn";
            this.alltoboxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kodeDataGridViewTextBoxColumn
            // 
            this.kodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kodeDataGridViewTextBoxColumn.DataPropertyName = "kode";
            this.kodeDataGridViewTextBoxColumn.HeaderText = "Kode";
            this.kodeDataGridViewTextBoxColumn.Name = "kodeDataGridViewTextBoxColumn";
            this.kodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipeDataGridViewTextBoxColumn
            // 
            this.tipeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipeDataGridViewTextBoxColumn.DataPropertyName = "tipe";
            this.tipeDataGridViewTextBoxColumn.HeaderText = "Tipe";
            this.tipeDataGridViewTextBoxColumn.Name = "tipeDataGridViewTextBoxColumn";
            this.tipeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tinggiDataGridViewTextBoxColumn
            // 
            this.tinggiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tinggiDataGridViewTextBoxColumn.DataPropertyName = "tinggi";
            this.tinggiDataGridViewTextBoxColumn.HeaderText = "Tinggi";
            this.tinggiDataGridViewTextBoxColumn.Name = "tinggiDataGridViewTextBoxColumn";
            this.tinggiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lebarDataGridViewTextBoxColumn
            // 
            this.lebarDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lebarDataGridViewTextBoxColumn.DataPropertyName = "lebar";
            this.lebarDataGridViewTextBoxColumn.HeaderText = "Lebar";
            this.lebarDataGridViewTextBoxColumn.Name = "lebarDataGridViewTextBoxColumn";
            this.lebarDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panjangDataGridViewTextBoxColumn
            // 
            this.panjangDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.panjangDataGridViewTextBoxColumn.DataPropertyName = "panjang";
            this.panjangDataGridViewTextBoxColumn.HeaderText = "Panjang";
            this.panjangDataGridViewTextBoxColumn.Name = "panjangDataGridViewTextBoxColumn";
            this.panjangDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kapasitasDataGridViewTextBoxColumn
            // 
            this.kapasitasDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kapasitasDataGridViewTextBoxColumn.DataPropertyName = "kapasitas";
            this.kapasitasDataGridViewTextBoxColumn.HeaderText = "Kapasitas";
            this.kapasitasDataGridViewTextBoxColumn.Name = "kapasitasDataGridViewTextBoxColumn";
            this.kapasitasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tIPEMOBILBindingSource
            // 
            this.tIPEMOBILBindingSource.DataMember = "TIPE_MOBIL";
            this.tIPEMOBILBindingSource.DataSource = this.dataset;
            // 
            // dataset
            // 
            this.dataset.DataSetName = "Dataset";
            this.dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormTipeMobil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 450);
            this.Controls.Add(this.dgvMasterTipeMobil);
            this.Name = "FormTipeMobil";
            this.Text = "TIPE MOBIL";
            this.Load += new System.EventHandler(this.FormTipeMobil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterTipeMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tIPEMOBILBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMasterTipeMobil;
        private System.Windows.Forms.BindingSource tIPEMOBILBindingSource;
        private Datasets.Dataset dataset;
        private System.Windows.Forms.DataGridViewTextBoxColumn alltoboxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinggiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lebarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn panjangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kapasitasDataGridViewTextBoxColumn;
    }
}