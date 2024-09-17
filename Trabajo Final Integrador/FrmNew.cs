using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final_Integrador
{
    public partial class FrmNew : Form
    {
        int id = FrmMain.Products.Last().Id + 1;
        private ErrorProvider errorProvider = new ErrorProvider();
        public FrmNew()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtBoxTitle.Text = string.Empty;
            txtBoxCategory.Text = string.Empty;
            txtBoxDescription.Text = string.Empty;
            txtBoxPrice.Text = string.Empty;
            this.Dispose();
        }

        private void FrmNew_Load(object sender, EventArgs e)
        {
            txtBoxId.Text = id.ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string title = txtBoxTitle.Text;
            string priceText = txtBoxPrice.Text;
            decimal price = 0;

            bool isValid = true;

            // Validamos si title es nulo o vacio.
            if (string.IsNullOrWhiteSpace(title))
            {
                errorProvider.SetError(txtBoxTitle, "El campo Title es obligatorio.");
                isValid = false;
            }

            // Validamos que el campo Price no este vacio y sea un numero valido mayor que cero
            if (string.IsNullOrWhiteSpace(priceText))
            {
                errorProvider.SetError(txtBoxPrice, "El campo Price es obligatorio.");
                isValid = false;
            }
            else if (!decimal.TryParse(priceText, out price) || price <= 0)
            {
                errorProvider.SetError(txtBoxPrice, "El campo Price debe ser un número válido mayor que cero.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show("Por favor, corrija los errores antes de continuar.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salimos del método si la validación falla
            }

            ApiProducts product = new ApiProducts
            {
                Id = id,
                Title = title,
                Price = price,
                Description = txtBoxDescription.Text,
                Category = txtBoxCategory.Text
            };

            FrmMain.Products.Add(product);

            MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; // Indica que se hizo una modificación
            this.Close();
        }
    }
}
