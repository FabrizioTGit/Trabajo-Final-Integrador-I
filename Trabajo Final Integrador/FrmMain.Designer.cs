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
            dataGridView = new DataGridView();
            cmbBoxCategory = new ComboBox();
            btnAscDesc = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(22, 137);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(559, 268);
            dataGridView.TabIndex = 0;
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
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 450);
            Controls.Add(btnAscDesc);
            Controls.Add(cmbBoxCategory);
            Controls.Add(dataGridView);
            Name = "FrmMain";
            Text = "Trabajo Final Integrador";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private ComboBox cmbBoxCategory;
        private Button btnAscDesc;
    }
}