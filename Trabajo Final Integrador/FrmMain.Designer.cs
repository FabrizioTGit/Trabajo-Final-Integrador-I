namespace Trabajo_Final_Integrador
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView = new DataGridView();
            cntxMenuStripDelete = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            cmbBoxCategory = new ComboBox();
            btnAscDesc = new Button();
            btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            cntxMenuStripDelete.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ContextMenuStrip = cntxMenuStripDelete;
            dataGridView.Location = new Point(22, 137);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(559, 268);
            dataGridView.TabIndex = 0;
            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
            // 
            // cntxMenuStripDelete
            // 
            cntxMenuStripDelete.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            cntxMenuStripDelete.Name = "cntxMenuStripDelete";
            cntxMenuStripDelete.Size = new Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(107, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // cmbBoxCategory
            // 
            cmbBoxCategory.FormattingEnabled = true;
            cmbBoxCategory.Location = new Point(337, 36);
            cmbBoxCategory.Name = "cmbBoxCategory";
            cmbBoxCategory.Size = new Size(121, 23);
            cmbBoxCategory.TabIndex = 1;
            cmbBoxCategory.SelectedIndexChanged += cmbBoxCategory_SelectedIndexChanged;
            // 
            // btnAscDesc
            // 
            btnAscDesc.Location = new Point(131, 35);
            btnAscDesc.Name = "btnAscDesc";
            btnAscDesc.Size = new Size(106, 23);
            btnAscDesc.TabIndex = 2;
            btnAscDesc.Text = "Ascendente";
            btnAscDesc.UseVisualStyleBackColor = true;
            btnAscDesc.Click += btnAscDesc_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(131, 83);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 4;
            btnNew.Text = "Nuevo";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 450);
            Controls.Add(btnNew);
            Controls.Add(btnAscDesc);
            Controls.Add(cmbBoxCategory);
            Controls.Add(dataGridView);
            Name = "FrmMain";
            Text = "Trabajo Final Integrador";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            cntxMenuStripDelete.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private ComboBox cmbBoxCategory;
        private Button btnAscDesc;
        private Button btnNew;
        private ContextMenuStrip cntxMenuStripDelete;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}