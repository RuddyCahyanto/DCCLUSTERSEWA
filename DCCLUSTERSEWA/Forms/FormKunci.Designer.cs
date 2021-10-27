
namespace DCCLUSTERSEWA.Forms
{
    partial class FormKunci
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
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvMasterKunci = new System.Windows.Forms.DataGridView();
            this.kunciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset = new DCCLUSTERSEWA.Datasets.Dataset();
            this.kddcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nokunciDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tglupdpassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterKunci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kunciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            this.SuspendLayout();
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
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "   Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvMasterKunci
            // 
            this.dgvMasterKunci.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMasterKunci.AutoGenerateColumns = false;
            this.dgvMasterKunci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMasterKunci.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kddcDataGridViewTextBoxColumn,
            this.nokunciDataGridViewTextBoxColumn,
            this.passDataGridViewTextBoxColumn,
            this.passoldDataGridViewTextBoxColumn,
            this.tglupdpassDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgvMasterKunci.DataSource = this.kunciBindingSource;
            this.dgvMasterKunci.Location = new System.Drawing.Point(12, 12);
            this.dgvMasterKunci.Name = "dgvMasterKunci";
            this.dgvMasterKunci.Size = new System.Drawing.Size(834, 301);
            this.dgvMasterKunci.TabIndex = 18;
            // 
            // kunciBindingSource
            // 
            this.kunciBindingSource.DataMember = "Kunci";
            this.kunciBindingSource.DataSource = this.dataset;
            // 
            // dataset
            // 
            this.dataset.DataSetName = "Dataset";
            this.dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kddcDataGridViewTextBoxColumn
            // 
            this.kddcDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.kddcDataGridViewTextBoxColumn.DataPropertyName = "kddc";
            this.kddcDataGridViewTextBoxColumn.HeaderText = "Kd DC";
            this.kddcDataGridViewTextBoxColumn.Name = "kddcDataGridViewTextBoxColumn";
            // 
            // nokunciDataGridViewTextBoxColumn
            // 
            this.nokunciDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nokunciDataGridViewTextBoxColumn.DataPropertyName = "nokunci";
            this.nokunciDataGridViewTextBoxColumn.HeaderText = "No Kunci";
            this.nokunciDataGridViewTextBoxColumn.Name = "nokunciDataGridViewTextBoxColumn";
            // 
            // passDataGridViewTextBoxColumn
            // 
            this.passDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.passDataGridViewTextBoxColumn.DataPropertyName = "pass";
            this.passDataGridViewTextBoxColumn.HeaderText = "Pass";
            this.passDataGridViewTextBoxColumn.Name = "passDataGridViewTextBoxColumn";
            // 
            // passoldDataGridViewTextBoxColumn
            // 
            this.passoldDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.passoldDataGridViewTextBoxColumn.DataPropertyName = "pass_old";
            this.passoldDataGridViewTextBoxColumn.HeaderText = "Pass Old";
            this.passoldDataGridViewTextBoxColumn.Name = "passoldDataGridViewTextBoxColumn";
            this.passoldDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tglupdpassDataGridViewTextBoxColumn
            // 
            this.tglupdpassDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tglupdpassDataGridViewTextBoxColumn.DataPropertyName = "tgl_updpass";
            this.tglupdpassDataGridViewTextBoxColumn.HeaderText = "Tgl Update Pass";
            this.tglupdpassDataGridViewTextBoxColumn.Name = "tglupdpassDataGridViewTextBoxColumn";
            this.tglupdpassDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // FormKunci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvMasterKunci);
            this.Name = "FormKunci";
            this.Text = "KUNCI";
            this.Load += new System.EventHandler(this.FormKunci_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterKunci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kunciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvMasterKunci;
        private System.Windows.Forms.BindingSource kunciBindingSource;
        private Datasets.Dataset dataset;
        private System.Windows.Forms.DataGridViewTextBoxColumn kddcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nokunciDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passoldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tglupdpassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}