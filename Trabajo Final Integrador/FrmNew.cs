using Datos;
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

        private ErrorProvider errorProvider = new ErrorProvider();        
        public List<ApiProducts> newProducts { get; private set; }

        public FrmNew(List<ApiProducts> existingProducts)
        {
            InitializeComponent();
            this.newProducts = existingProducts;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmNew_Load(object sender, EventArgs e)
        {
            txtBoxId.Text = GetNextProductId().ToString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ConnecectionApi connecectionApi = new ConnecectionApi("https://fakestoreapi.com");
            string title = txtBoxTitle.Text;
            string priceText = txtBoxPrice.Text;
            decimal price = Convert.ToDecimal(priceText);

            if (!ValidateFields())
            {
                MessageBox.Show("Por favor, corrija los errores antes de continuar.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = int.Parse(txtBoxId.Text);

            ApiProducts product = new ApiProducts
            {
                Id = id,
                Title = title,
                Price = price,
                Description = txtBoxDescription.Text,
                Category = txtBoxCategory.Text
            };

            newProducts = connecectionApi.PostProducts(newProducts, product);

            MessageBox.Show("Producto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; // Indica que se hizo una modificación
            this.Close();
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtBoxTitle.Text))
            {
                errorProvider.SetError(txtBoxTitle, "El campo Title es obligatorio.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtBoxTitle, string.Empty); // Elimina el error si es válido
            }

            if (string.IsNullOrWhiteSpace(txtBoxPrice.Text) || !decimal.TryParse(txtBoxPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider.SetError(txtBoxPrice, "El campo Price debe ser un número válido mayor que cero.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(txtBoxPrice, string.Empty); // Elimina el error si es válido
            }

            return isValid;
        }
        private int GetNextProductId()
        {
            if (newProducts != null && newProducts.Count > 0)
            {
                return newProducts.Max(p => p.Id) + 1;
            }
            return 1;
        }
    }
}
