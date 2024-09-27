using Datos;
using Negocio;

namespace Trabajo_Final_Integrador
{
    public partial class FrmMain : Form
    {
        ConnecectionApi connecectionApi;
        public List<ApiProducts>? Products { get; set; }

        public List<string>? Categories { get; set; }
        public FrmMain()
        {
            InitializeComponent();
            connecectionApi = new ConnecectionApi("https://fakestoreapi.com");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Asignamos la api a utilizar al metodo para obtener los productos            
            Products = connecectionApi.GetProducts();
            Categories = connecectionApi.GetCategories();

            // Asignamos la lista de productos con sus atributos
            dataGridView.DataSource = Products;

            // Creamos la variable categories para poder agregar All para filtrar todos las categorias
            Categories = connecectionApi.GetCategories();
            Categories.Insert(0, "All");

            cmbBoxCategory.DataSource = Categories;

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
                dataGridView.DataSource = Products;
            }
            else
                // Actualizamos el DataGridView con los productos filtrados
                dataGridView.DataSource = Products.Where(p => p.Category != null && p.Category.Equals(selectedCategory)).ToList();
        }

        private void btnAscDesc_Click(object sender, EventArgs e)
        {
            string? selectedCategory = cmbBoxCategory.SelectedItem.ToString();            
            
            if (btnAscDesc.Text == "Ascendente")
            {
                if (selectedCategory != "All")
                    dataGridView.DataSource = Products.Where(p => p.Category == selectedCategory).OrderBy(p => p.Title).ToList();
                else
                    dataGridView.DataSource = Products.OrderBy(p => p.Title).ToList();

                btnAscDesc.Text = "Descendente";
            }
            else
            {
                if (selectedCategory != "All")
                    dataGridView.DataSource = Products.Where(p => p.Category == selectedCategory).OrderByDescending(p => p.Title).ToList();
                else
                    dataGridView.DataSource = Products.OrderByDescending(p => p.Title).ToList();

                btnAscDesc.Text = "Ascendente";
            }
        }

        private void btnAcctions_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (FrmNew form = new FrmNew(this.Products))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {                    
                    this.Products = form.newProducts;

                    dataGridView.DataSource = null;
                    dataGridView.DataSource = this.Products;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var selectedIds = new List<int>();
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    int selectedId = Convert.ToInt32(row.Cells["Id"].Value);
                    selectedIds.Add(selectedId);
                }
                Products.RemoveAll(item => selectedIds.Contains(item.Id));
                dataGridView.DataSource = null; 
                dataGridView.DataSource = Products; 
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila.");
            }
        }
    }
}