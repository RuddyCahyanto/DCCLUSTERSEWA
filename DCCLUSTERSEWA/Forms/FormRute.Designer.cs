
namespace DCCLUSTERSEWA.Forms
{
    partial class FormRute
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
            this.dgvMasterRute = new System.Windows.Forms.DataGridView();
            this.rUTEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.rUTEBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.datasetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset = new DCCLUSTERSEWA.Datasets.Dataset();
            this.zonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdtkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kmasliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jlnkhususDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterRute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rUTEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rUTEBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datasetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMasterRute
            // 
            this.dgvMasterRute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMasterRute.AutoGenerateColumns = false;
            this.dgvMasterRute.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvMasterRute.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMasterRute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMasterRute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.zonaDataGridViewTextBoxColumn,
            this.grupDataGridViewTextBoxColumn,
            this.kdtkDataGridViewTextBoxColumn,
            this.kmasliDataGridViewTextBoxColumn,
            this.jlnkhususDataGridViewTextBoxColumn,
            this.gageDataGridViewTextBoxColumn});
            this.dgvMasterRute.DataSource = this.rUTEBindingSource;
            this.dgvMasterRute.Location = new System.Drawing.Point(12, 12);
            this.dgvMasterRute.Name = "dgvMasterRute";
            this.dgvMasterRute.Size = new System.Drawing.Size(832, 301);
            this.dgvMasterRute.TabIndex = 9;
            this.dgvMasterRute.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMasterRute_CellClick);
            this.dgvMasterRute.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvMasterRute_UserDeletingRow);
            // 
            // rUTEBindingSource
            // 
            this.rUTEBindingSource.DataMember = "RUTE";
            this.rUTEBindingSource.DataSource = this.datasetBindingSource;
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
            this.btnSave.Location = new System.Drawing.Point(735, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSave.Size = new System.Drawing.Size(109, 48);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "   Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rUTEBindingSource1
            // 
            this.rUTEBindingSource1.DataMember = "RUTE";
            this.rUTEBindingSource1.DataSource = this.datasetBindingSource;
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
            // zonaDataGridViewTextBoxColumn
            // 
            this.zonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.zonaDataGridViewTextBoxColumn.DataPropertyName = "zona";
            this.zonaDataGridViewTextBoxColumn.HeaderText = "Zona";
            this.zonaDataGridViewTextBoxColumn.Name = "zonaDataGridViewTextBoxColumn";
            // 
            // grupDataGridViewTextBoxColumn
            // 
            this.grupDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.grupDataGridViewTextBoxColumn.DataPropertyName = "grup";
            this.grupDataGridViewTextBoxColumn.HeaderText = "Grup";
            this.grupDataGridViewTextBoxColumn.Name = "grupDataGridViewTextBoxColumn";
            // 
            // kdtkDataGridViewTextBoxColumn
            // 
            this.kdtkDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kdtkDataGridViewTextBoxColumn.DataPropertyName = "kdtk";
            this.kdtkDataGridViewTextBoxColumn.HeaderText = "Kd Toko";
            this.kdtkDataGridViewTextBoxColumn.Name = "kdtkDataGridViewTextBoxColumn";
            // 
            // kmasliDataGridViewTextBoxColumn
            // 
            this.kmasliDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kmasliDataGridViewTextBoxColumn.DataPropertyName = "kmasli";
            this.kmasliDataGridViewTextBoxColumn.HeaderText = "Km Asli";
            this.kmasliDataGridViewTextBoxColumn.Name = "kmasliDataGridViewTextBoxColumn";
            // 
            // jlnkhususDataGridViewTextBoxColumn
            // 
            this.jlnkhususDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.jlnkhususDataGridViewTextBoxColumn.DataPropertyName = "jlnkhusus";
            this.jlnkhususDataGridViewTextBoxColumn.FalseValue = "N";
            this.jlnkhususDataGridViewTextBoxColumn.HeaderText = "Jln Khusus";
            this.jlnkhususDataGridViewTextBoxColumn.Name = "jlnkhususDataGridViewTextBoxColumn";
            this.jlnkhususDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.jlnkhususDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.jlnkhususDataGridViewTextBoxColumn.TrueValue = "Y";
            // 
            // gageDataGridViewTextBoxColumn
            // 
            this.gageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gageDataGridViewTextBoxColumn.DataPropertyName = "gage";
            this.gageDataGridViewTextBoxColumn.FalseValue = "N";
            this.gageDataGridViewTextBoxColumn.HeaderText = "Ganjil/Genap";
            this.gageDataGridViewTextBoxColumn.Name = "gageDataGridViewTextBoxColumn";
            this.gageDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gageDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gageDataGridViewTextBoxColumn.TrueValue = "Y";
            // 
            // FormRute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 390);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvMasterRute);
            this.Name = "FormRute";
            this.Text = "RUTE";
            this.Load += new System.EventHandler(this.FormRute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterRute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rUTEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rUTEBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datasetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.DataGridView dgvMasterRute;
        private System.Windows.Forms.BindingSource datasetBindingSource;
        private Datasets.Dataset dataset;
        private System.Windows.Forms.BindingSource rUTEBindingSource;
        private System.Windows.Forms.BindingSource rUTEBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn zonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdtkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kmasliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn jlnkhususDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gageDataGridViewTextBoxColumn;
    }
}