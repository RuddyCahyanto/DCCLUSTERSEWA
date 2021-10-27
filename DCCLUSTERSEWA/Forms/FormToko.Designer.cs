
namespace DCCLUSTERSEWA.Forms
{
    partial class FormToko
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
            this.dgvMasterToko = new System.Windows.Forms.DataGridView();
            this.tokoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset = new DCCLUSTERSEWA.Datasets.Dataset();
            this.btnSave = new System.Windows.Forms.Button();
            this.mobilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namatokoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglbukaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipemobilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kotaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kantorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxcontDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxbronjDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxdolyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterToko)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobilBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMasterToko
            // 
            this.dgvMasterToko.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMasterToko.AutoGenerateColumns = false;
            this.dgvMasterToko.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMasterToko.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMasterToko.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodeDataGridViewTextBoxColumn,
            this.namatokoDataGridViewTextBoxColumn,
            this.tglbukaDataGridViewTextBoxColumn,
            this.tipemobilDataGridViewTextBoxColumn,
            this.kotaDataGridViewTextBoxColumn,
            this.telpDataGridViewTextBoxColumn,
            this.kantorDataGridViewTextBoxColumn,
            this.rutingDataGridViewTextBoxColumn,
            this.maxcontDataGridViewTextBoxColumn,
            this.maxbronjDataGridViewTextBoxColumn,
            this.maxdolyDataGridViewTextBoxColumn});
            this.dgvMasterToko.DataSource = this.tokoBindingSource;
            this.dgvMasterToko.Location = new System.Drawing.Point(12, 12);
            this.dgvMasterToko.Name = "dgvMasterToko";
            this.dgvMasterToko.Size = new System.Drawing.Size(834, 301);
            this.dgvMasterToko.TabIndex = 0;
            // 
            // tokoBindingSource
            // 
            this.tokoBindingSource.DataMember = "Toko";
            this.tokoBindingSource.DataSource = this.dataset;
            // 
            // dataset
            // 
            this.dataset.DataSetName = "Dataset";
            this.dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::DCCLUSTERSEWA.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(737, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(109, 48);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "   Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mobilBindingSource
            // 
            this.mobilBindingSource.DataMember = "Mobil";
            this.mobilBindingSource.DataSource = this.dataset;
            // 
            // kodeDataGridViewTextBoxColumn
            // 
            this.kodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.kodeDataGridViewTextBoxColumn.DataPropertyName = "kode";
            this.kodeDataGridViewTextBoxColumn.HeaderText = "Kode";
            this.kodeDataGridViewTextBoxColumn.Name = "kodeDataGridViewTextBoxColumn";
            this.kodeDataGridViewTextBoxColumn.Width = 57;
            // 
            // namatokoDataGridViewTextBoxColumn
            // 
            this.namatokoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.namatokoDataGridViewTextBoxColumn.DataPropertyName = "nama_toko";
            this.namatokoDataGridViewTextBoxColumn.HeaderText = "Nama";
            this.namatokoDataGridViewTextBoxColumn.Name = "namatokoDataGridViewTextBoxColumn";
            this.namatokoDataGridViewTextBoxColumn.Width = 60;
            // 
            // tglbukaDataGridViewTextBoxColumn
            // 
            this.tglbukaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tglbukaDataGridViewTextBoxColumn.DataPropertyName = "tgl_buka";
            dataGridViewCellStyle1.NullValue = null;
            this.tglbukaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.tglbukaDataGridViewTextBoxColumn.HeaderText = "Tgl Buka (MM/dd/yyyy)";
            this.tglbukaDataGridViewTextBoxColumn.Name = "tglbukaDataGridViewTextBoxColumn";
            this.tglbukaDataGridViewTextBoxColumn.Width = 132;
            // 
            // tipemobilDataGridViewTextBoxColumn
            // 
            this.tipemobilDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tipemobilDataGridViewTextBoxColumn.DataPropertyName = "tipe_mobil";
            this.tipemobilDataGridViewTextBoxColumn.HeaderText = "Tipe Mobil";
            this.tipemobilDataGridViewTextBoxColumn.Name = "tipemobilDataGridViewTextBoxColumn";
            this.tipemobilDataGridViewTextBoxColumn.Width = 70;
            // 
            // kotaDataGridViewTextBoxColumn
            // 
            this.kotaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.kotaDataGridViewTextBoxColumn.DataPropertyName = "kota";
            this.kotaDataGridViewTextBoxColumn.HeaderText = "Kota";
            this.kotaDataGridViewTextBoxColumn.Name = "kotaDataGridViewTextBoxColumn";
            this.kotaDataGridViewTextBoxColumn.Width = 54;
            // 
            // telpDataGridViewTextBoxColumn
            // 
            this.telpDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.telpDataGridViewTextBoxColumn.DataPropertyName = "telp";
            this.telpDataGridViewTextBoxColumn.HeaderText = "Telp";
            this.telpDataGridViewTextBoxColumn.Name = "telpDataGridViewTextBoxColumn";
            this.telpDataGridViewTextBoxColumn.Width = 53;
            // 
            // kantorDataGridViewTextBoxColumn
            // 
            this.kantorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.kantorDataGridViewTextBoxColumn.DataPropertyName = "kantor";
            this.kantorDataGridViewTextBoxColumn.HeaderText = "Kantor";
            this.kantorDataGridViewTextBoxColumn.Name = "kantorDataGridViewTextBoxColumn";
            this.kantorDataGridViewTextBoxColumn.Width = 55;
            // 
            // rutingDataGridViewTextBoxColumn
            // 
            this.rutingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.rutingDataGridViewTextBoxColumn.DataPropertyName = "ruting";
            this.rutingDataGridViewTextBoxColumn.HeaderText = "Ruting";
            this.rutingDataGridViewTextBoxColumn.Name = "rutingDataGridViewTextBoxColumn";
            this.rutingDataGridViewTextBoxColumn.Width = 55;
            // 
            // maxcontDataGridViewTextBoxColumn
            // 
            this.maxcontDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.maxcontDataGridViewTextBoxColumn.DataPropertyName = "max_cont";
            this.maxcontDataGridViewTextBoxColumn.HeaderText = "Max Container";
            this.maxcontDataGridViewTextBoxColumn.Name = "maxcontDataGridViewTextBoxColumn";
            this.maxcontDataGridViewTextBoxColumn.Width = 76;
            // 
            // maxbronjDataGridViewTextBoxColumn
            // 
            this.maxbronjDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.maxbronjDataGridViewTextBoxColumn.DataPropertyName = "max_bronj";
            this.maxbronjDataGridViewTextBoxColumn.HeaderText = "Max Bronjong";
            this.maxbronjDataGridViewTextBoxColumn.Name = "maxbronjDataGridViewTextBoxColumn";
            this.maxbronjDataGridViewTextBoxColumn.Width = 76;
            // 
            // maxdolyDataGridViewTextBoxColumn
            // 
            this.maxdolyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.maxdolyDataGridViewTextBoxColumn.DataPropertyName = "max_doly";
            this.maxdolyDataGridViewTextBoxColumn.HeaderText = "Max Doly";
            this.maxdolyDataGridViewTextBoxColumn.Name = "maxdolyDataGridViewTextBoxColumn";
            this.maxdolyDataGridViewTextBoxColumn.Width = 76;
            // 
            // FormToko
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(858, 390);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvMasterToko);
            this.Name = "FormToko";
            this.Text = "TOKO";
            this.Load += new System.EventHandler(this.FormToko_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterToko)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tokoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobilBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMasterToko;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.BindingSource tokoBindingSource;
        private Datasets.Dataset dataset;
        private System.Windows.Forms.BindingSource mobilBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namatokoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglbukaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipemobilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kotaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kantorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxcontDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxbronjDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxdolyDataGridViewTextBoxColumn;
    }
}