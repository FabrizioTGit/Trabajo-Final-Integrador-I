namespace Trabajo_Final_Integrador
{
    partial class FrmAcctions
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
            components = new System.ComponentModel.Container();
            btnAdd = new Button();
            pnlAdd = new Panel();
            lblCategory = new Label();
            lblDescription = new Label();
            lblPrice = new Label();
            lblTitle = new Label();
            lblId = new Label();
            txtBoxId = new TextBox();
            btnCancel = new Button();
            btnAccept = new Button();
            txtBoxCategory = new TextBox();
            txtBoxDescription = new TextBox();
            txtBoxPrice = new TextBox();
            txtBoxTitle = new TextBox();
            errMandatory = new ErrorProvider(components);
            pnlAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errMandatory).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(89, 67);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(84, 27);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Agregar";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // pnlAdd
            // 
            pnlAdd.Controls.Add(lblCategory);
            pnlAdd.Controls.Add(lblDescription);
            pnlAdd.Controls.Add(lblPrice);
            pnlAdd.Controls.Add(lblTitle);
            pnlAdd.Controls.Add(lblId);
            pnlAdd.Controls.Add(txtBoxId);
            pnlAdd.Controls.Add(btnCancel);
            pnlAdd.Controls.Add(btnAccept);
            pnlAdd.Controls.Add(txtBoxCategory);
            pnlAdd.Controls.Add(txtBoxDescription);
            pnlAdd.Controls.Add(txtBoxPrice);
            pnlAdd.Controls.Add(txtBoxTitle);
            pnlAdd.Location = new Point(33, 27);
            pnlAdd.Name = "pnlAdd";
            pnlAdd.Size = new Size(231, 310);
            pnlAdd.TabIndex = 1;
            pnlAdd.Visible = false;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(38, 192);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(61, 15);
            lblCategory.TabIndex = 11;
            lblCategory.Text = "Categoria:";
            lblCategory.Click += lblCategory_Click;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(38, 145);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(72, 15);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Descripcion:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(38, 97);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(43, 15);
            lblPrice.TabIndex = 9;
            lblPrice.Text = "Precio:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(38, 52);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(40, 15);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Titulo:";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(40, 8);
            lblId.Name = "lblId";
            lblId.Size = new Size(21, 15);
            lblId.TabIndex = 7;
            lblId.Text = "ID:";
            // 
            // txtBoxId
            // 
            txtBoxId.Location = new Point(40, 26);
            txtBoxId.Name = "txtBoxId";
            txtBoxId.ReadOnly = true;
            txtBoxId.Size = new Size(147, 23);
            txtBoxId.TabIndex = 6;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(130, 250);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(83, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(24, 250);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(83, 23);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "Aceptar";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // txtBoxCategory
            // 
            txtBoxCategory.Location = new Point(38, 210);
            txtBoxCategory.Name = "txtBoxCategory";
            txtBoxCategory.Size = new Size(149, 23);
            txtBoxCategory.TabIndex = 3;
            // 
            // txtBoxDescription
            // 
            txtBoxDescription.Location = new Point(38, 163);
            txtBoxDescription.Name = "txtBoxDescription";
            txtBoxDescription.Size = new Size(149, 23);
            txtBoxDescription.TabIndex = 2;
            // 
            // txtBoxPrice
            // 
            txtBoxPrice.Location = new Point(38, 114);
            txtBoxPrice.Name = "txtBoxPrice";
            txtBoxPrice.Size = new Size(149, 23);
            txtBoxPrice.TabIndex = 1;
            txtBoxPrice.KeyPress += txtBoxPrice_KeyPress;
            // 
            // txtBoxTitle
            // 
            txtBoxTitle.Location = new Point(38, 71);
            txtBoxTitle.Name = "txtBoxTitle";
            txtBoxTitle.Size = new Size(149, 23);
            txtBoxTitle.TabIndex = 0;
            txtBoxTitle.Visible = false;
            // 
            // errMandatory
            // 
            errMandatory.ContainerControl = this;
            // 
            // FrmAcctions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 367);
            Controls.Add(pnlAdd);
            Controls.Add(btnAdd);
            Name = "FrmAcctions";
            Text = "FrmAcctions";
            pnlAdd.ResumeLayout(false);
            pnlAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errMandatory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private Panel pnlAdd;
        private TextBox txtBoxTitle;
        private TextBox txtBoxDescription;
        private TextBox txtBoxPrice;
        private Button btnCancel;
        private Button btnAccept;
        private TextBox txtBoxCategory;
        private TextBox txtBoxId;
        private Label lblCategory;
        private Label lblDescription;
        private Label lblPrice;
        private Label lblTitle;
        private Label lblId;
        private ErrorProvider errMandatory;
    }
}