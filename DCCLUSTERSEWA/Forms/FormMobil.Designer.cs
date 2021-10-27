
namespace DCCLUSTERSEWA.Forms
{
    partial class FormMobil
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
            this.dgvMasterMobil = new System.Windows.Forms.DataGridView();
            this.mobilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.datasetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset = new DCCLUSTERSEWA.Datasets.Dataset();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.kdmobilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nopolisiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supirDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kubikasiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterMobil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datasetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMasterMobil
            // 
            this.dgvMasterMobil.AllowUserToAddRows = false;
            this.dgvMasterMobil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMasterMobil.AutoGenerateColumns = false;
            this.dgvMasterMobil.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMasterMobil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMasterMobil.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kdmobilDataGridViewTextBoxColumn,
            this.nopolisiDataGridViewTextBoxColumn,
            this.supirDataGridViewTextBoxColumn,
            this.tipeDataGridViewTextBoxColumn,
            this.kubikasiDataGridViewTextBoxColumn,
            this.gpsDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgvMasterMobil.DataSource = this.mobilBindingSource;
            this.dgvMasterMobil.Location = new System.Drawing.Point(12, 12);
            this.dgvMasterMobil.Name = "dgvMasterMobil";
            this.dgvMasterMobil.Size = new System.Drawing.Size(834, 301);
            this.dgvMasterMobil.TabIndex = 9;
            // 
            // mobilBindingSource
            // 
            this.mobilBindingSource.DataMember = "Mobil";
            this.mobilBindingSource.DataSource = this.datasetBindingSource;
            // 
            // datasetBindingSource
            // 
            this.datasetBindingSource.DataSource = this.dataset;
            this.datasetBindingSource.Position = 0;
            // 
            // dataset
            // 
            this.dataset.DataSetName = "Dataset";
            this.dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::DCCLUSTERSEWA.Properties.Resources.add_file;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(741, 330);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnNew.Size = new System.Drawing.Size(105, 48);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "   New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
            this.btnSave.Location = new System.Drawing.Point(603, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(109, 48);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "   Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // kdmobilDataGridViewTextBoxColumn
            // 
            this.kdmobilDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kdmobilDataGridViewTextBoxColumn.DataPropertyName = "kd_mobil";
            this.kdmobilDataGridViewTextBoxColumn.HeaderText = "Kd Mobil";
            this.kdmobilDataGridViewTextBoxColumn.Name = "kdmobilDataGridViewTextBoxColumn";
            // 
            // nopolisiDataGridViewTextBoxColumn
            // 
            this.nopolisiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nopolisiDataGridViewTextBoxColumn.DataPropertyName = "no_polisi";
            this.nopolisiDataGridViewTextBoxColumn.HeaderText = "No Polisi";
            this.nopolisiDataGridViewTextBoxColumn.Name = "nopolisiDataGridViewTextBoxColumn";
            // 
            // supirDataGridViewTextBoxColumn
            // 
            this.supirDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.supirDataGridViewTextBoxColumn.DataPropertyName = "supir";
            this.supirDataGridViewTextBoxColumn.HeaderText = "Supir";
            this.supirDataGridViewTextBoxColumn.Name = "supirDataGridViewTextBoxColumn";
            // 
            // tipeDataGridViewTextBoxColumn
            // 
            this.tipeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tipeDataGridViewTextBoxColumn.DataPropertyName = "tipe";
            this.tipeDataGridViewTextBoxColumn.HeaderText = "Tipe";
            this.tipeDataGridViewTextBoxColumn.Name = "tipeDataGridViewTextBoxColumn";
            this.tipeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // kubikasiDataGridViewTextBoxColumn
            // 
            this.kubikasiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kubikasiDataGridViewTextBoxColumn.DataPropertyName = "kubikasi";
            this.kubikasiDataGridViewTextBoxColumn.HeaderText = "Kubikasi";
            this.kubikasiDataGridViewTextBoxColumn.Name = "kubikasiDataGridViewTextBoxColumn";
            this.kubikasiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gpsDataGridViewTextBoxColumn
            // 
            this.gpsDataGridViewTextBoxColumn.DataPropertyName = "gps";
            this.gpsDataGridViewTextBoxColumn.HeaderText = "GPS";
            this.gpsDataGridViewTextBoxColumn.Name = "gpsDataGridViewTextBoxColumn";
            this.gpsDataGridViewTextBoxColumn.Width = 60;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 60;
            // 
            // FormMobil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 450);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvMasterMobil);
            this.Name = "FormMobil";
            this.Text = "MOBIL";
            this.Load += new System.EventHandler(this.FormMobil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterMobil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mobilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datasetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvMasterMobil;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.BindingSource mobilBindingSource;
        private System.Windows.Forms.BindingSource datasetBindingSource;
        private Datasets.Dataset dataset;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdmobilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nopolisiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supirDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kubikasiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}