using Negocio;

namespace Trabajo_Final_Integrador
{
    public partial class FrmAcctions : Form
    {
        int id = FrmMain.Products.Last().Id + 1;
        private ErrorProvider errorProvider = new ErrorProvider();

        public FrmAcctions()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            txtBoxTitle.Visible = true;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = false;
            txtBoxTitle.Visible = false;
            txtBoxTitle.Text = string.Empty;
            txtBoxCategory.Text = string.Empty;
            txtBoxDescription.Text = string.Empty;
            txtBoxPrice.Text = string.Empty;
        }

        private void txtBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox? textBox = sender as TextBox;

            // Permite dígitos, la coma decimal y teclas de control como Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela el evento si no es un número, coma o tecla de control
            }

            // Permite solo una coma decimal y evita que sea la primera entrada
            if (e.KeyChar == ',')
            {
                // Si la coma ya existe o es la primera entrada (posición 0) cancela el evento
                if (textBox.Text.IndexOf(',') > -1 || textBox.SelectionStart == 0)
                {
                    e.Handled = true; // Cancela el evento
                }
            }
        }

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }
    }
}
