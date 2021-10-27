
namespace DCCLUSTERSEWA.Forms
{
    partial class FormGO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGO));
            this.dgvProsesGO = new System.Windows.Forms.DataGridView();
            this.tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdtoko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nmtoko = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nopb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kubikreal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdmobil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdsupir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nokunci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataset = new DCCLUSTERSEWA.Datasets.Dataset();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbKunci = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSupir = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKodeMobil = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.loadingSpinnerGO = new System.Windows.Forms.PictureBox();
            this.btnGO = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProsesGO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpinnerGO)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProsesGO
            // 
            this.dgvProsesGO.AllowUserToAddRows = false;
            this.dgvProsesGO.AllowUserToDeleteRows = false;
            this.dgvProsesGO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProsesGO.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProsesGO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProsesGO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tanggal,
            this.kdtoko,
            this.nmtoko,
            this.nopb,
            this.kubikreal,
            this.kdmobil,
            this.kdsupir,
            this.nokunci,
            this.check});
            this.dgvProsesGO.Location = new System.Drawing.Point(15, 102);
            this.dgvProsesGO.Name = "dgvProsesGO";
            this.dgvProsesGO.Size = new System.Drawing.Size(834, 296);
            this.dgvProsesGO.TabIndex = 9;
            this.dgvProsesGO.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvProsesGO_CellPainting);
            // 
            // tanggal
            // 
            this.tanggal.HeaderText = "Tanggal";
            this.tanggal.Name = "tanggal";
            this.tanggal.ReadOnly = true;
            this.tanggal.Width = 90;
            // 
            // kdtoko
            // 
            this.kdtoko.HeaderText = "Kd Toko";
            this.kdtoko.Name = "kdtoko";
            this.kdtoko.ReadOnly = true;
            this.kdtoko.Width = 70;
            // 
            // nmtoko
            // 
            this.nmtoko.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nmtoko.HeaderText = "Nm Toko";
            this.nmtoko.Name = "nmtoko";
            this.nmtoko.ReadOnly = true;
            this.nmtoko.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nopb
            // 
            this.nopb.HeaderText = "No PB";
            this.nopb.Name = "nopb";
            this.nopb.ReadOnly = true;
            // 
            // kubikreal
            // 
            this.kubikreal.HeaderText = "Kubik Real";
            this.kubikreal.Name = "kubikreal";
            this.kubikreal.ReadOnly = true;
            this.kubikreal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // kdmobil
            // 
            this.kdmobil.HeaderText = "Kd Mobil";
            this.kdmobil.Name = "kdmobil";
            this.kdmobil.ReadOnly = true;
            this.kdmobil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.kdmobil.Width = 80;
            // 
            // kdsupir
            // 
            this.kdsupir.HeaderText = "Kd Supir";
            this.kdsupir.Name = "kdsupir";
            this.kdsupir.ReadOnly = true;
            this.kdsupir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nokunci
            // 
            this.nokunci.HeaderText = "No Kunci";
            this.nokunci.Name = "nokunci";
            this.nokunci.ReadOnly = true;
            this.nokunci.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nokunci.Width = 70;
            // 
            // check
            // 
            this.check.FalseValue = "";
            this.check.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.check.HeaderText = "";
            this.check.IndeterminateValue = "";
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.TrueValue = "1";
            this.check.Width = 40;
            // 
            // gOBindingSource
            // 
            this.gOBindingSource.DataMember = "GO";
            this.gOBindingSource.DataSource = this.dataset;
            // 
            // dataset
            // 
            this.dataset.DataSetName = "Dataset";
            this.dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbFind);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.cbKunci);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbSupir);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbKodeMobil);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 100);
            this.panel1.TabIndex = 25;
            // 
            // tbFind
            // 
            this.tbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFind.Location = new System.Drawing.Point(683, 72);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(164, 20);
            this.tbFind.TabIndex = 17;
            this.tbFind.Text = "Kode/Nama/NoPB";
            this.tbFind.Click += new System.EventHandler(this.tbFind_Click);
            this.tbFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFind_KeyPress);
            this.tbFind.Leave += new System.EventHandler(this.tbFind_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(644, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Find: ";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(250, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbKunci
            // 
            this.cbKunci.FormattingEnabled = true;
            this.cbKunci.Location = new System.Drawing.Point(84, 70);
            this.cbKunci.Name = "cbKunci";
            this.cbKunci.Size = new System.Drawing.Size(148, 21);
            this.cbKunci.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kunci: ";
            // 
            // cbSupir
            // 
            this.cbSupir.FormattingEnabled = true;
            this.cbSupir.Location = new System.Drawing.Point(84, 40);
            this.cbSupir.Name = "cbSupir";
            this.cbSupir.Size = new System.Drawing.Size(148, 21);
            this.cbSupir.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Supir: ";
            // 
            // cbKodeMobil
            // 
            this.cbKodeMobil.FormattingEnabled = true;
            this.cbKodeMobil.Location = new System.Drawing.Point(85, 9);
            this.cbKodeMobil.Name = "cbKodeMobil";
            this.cbKodeMobil.Size = new System.Drawing.Size(148, 21);
            this.cbKodeMobil.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kode Mobil: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.loadingSpinnerGO);
            this.panel2.Controls.Add(this.btnGO);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 404);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 87);
            this.panel2.TabIndex = 26;
            // 
            // loadingSpinnerGO
            // 
            this.loadingSpinnerGO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loadingSpinnerGO.Image = global::DCCLUSTERSEWA.Properties.Resources.spinning_loading;
            this.loadingSpinnerGO.Location = new System.Drawing.Point(498, 3);
            this.loadingSpinnerGO.Name = "loadingSpinnerGO";
            this.loadingSpinnerGO.Size = new System.Drawing.Size(45, 43);
            this.loadingSpinnerGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingSpinnerGO.TabIndex = 26;
            this.loadingSpinnerGO.TabStop = false;
            this.loadingSpinnerGO.Visible = false;
            // 
            // btnGO
            // 
            this.btnGO.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGO.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGO.FlatAppearance.BorderSize = 0;
            this.btnGO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGO.Location = new System.Drawing.Point(366, 3);
            this.btnGO.Name = "btnGO";
            this.btnGO.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGO.Size = new System.Drawing.Size(113, 43);
            this.btnGO.TabIndex = 25;
            this.btnGO.Text = "GO!";
            this.btnGO.UseVisualStyleBackColor = false;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // FormGO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(859, 491);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvProsesGO);
            this.Name = "FormGO";
            this.Text = "GO | V1000";
            this.Load += new System.EventHandler(this.FormGO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProsesGO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataset)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingSpinnerGO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProsesGO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbKunci;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSupir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbKodeMobil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox loadingSpinnerGO;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.BindingSource gOBindingSource;
        private Datasets.Dataset dataset;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdtoko;
        private System.Windows.Forms.DataGridViewTextBoxColumn nmtoko;
        private System.Windows.Forms.DataGridViewTextBoxColumn nopb;
        private System.Windows.Forms.DataGridViewTextBoxColumn kubikreal;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdmobil;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdsupir;
        private System.Windows.Forms.DataGridViewTextBoxColumn nokunci;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}