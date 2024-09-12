using Datos;
using Negocio;

namespace Trabajo_Final_Integrador
{
    public partial class FrmMain : Form
    {
        ApiProducts apiProducts = new();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Asignamos la api a utilizar al metodo para obtener los productos
            apiProducts.Products = ConnecectionApi.GetProducts("https://fakestoreapi.com");

            // Asignamos la lista de productos con sus atributos
            dataGridView.DataSource = apiProducts.Products;

            // Creamos la variable categories para poder agregar All para filtrar todos las categorias
            var categories = apiProducts.Products.Select(p => p.Category).Distinct().ToList();
            categories.Insert(0, "All");
            cmbBoxCategory.DataSource = categories;

            // Asignamos el elemento seleccionado para que sea All
            cmbBoxCategory.SelectedIndex = 0;
        }

        private void cmbBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Le asignamos a una variable la categoria seleccionada en el ComboBox
            string? selectedCategory = cmbBoxCategory.SelectedItem.ToString();

            // Verificamos si la categoria seleccionada es All
            if (selectedCategory == "All")
            {
                dataGridView.DataSource = apiProducts.Products;
            }
            else
                // Actualizamos el DataGridView con los productos filtrados
                dataGridView.DataSource = apiProducts.Products.Where(p => p.Category == selectedCategory).ToList();
        }

        private void btnAscDesc_Click(object sender, EventArgs e)
        {
            string? selectedCategory = cmbBoxCategory.SelectedItem.ToString();


            if (btnAscDesc.Text == "Ascendente")
            {
                if (selectedCategory != "All")
                    dataGridView.DataSource = apiProducts.Products.Where(p => p.Category == selectedCategory).OrderBy(p => p.Title).ToList();
                else
                    dataGridView.DataSource = apiProducts.Products.OrderBy(p => p.Title).ToList();

                btnAscDesc.Text = "Descendente";
            }
            else
            {
                if (selectedCategory != "All")
                    dataGridView.DataSource = apiProducts.Products.Where(p => p.Category == selectedCategory).OrderByDescending(p => p.Title).ToList();
                else
                    dataGridView.DataSource = apiProducts.Products.OrderByDescending(p => p.Title).ToList();
                
                btnAscDesc.Text = "Ascendente";
            }





        }
    }
}