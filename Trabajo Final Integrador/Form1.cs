using Datos;
using Negocio;

namespace Trabajo_Final_Integrador
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ApiProducts apiProducts = new ApiProducts();
            apiProducts.Products = ConnecectionApi.GetProducts("https://fakestoreapi.com");
            dataGridView.DataSource = apiProducts.Products;
            cmbBoxCategory.DataSource = apiProducts.GetCategory();
        }

        private void cmbBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}