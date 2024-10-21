using Datos;
using Negocio;
using System.Configuration;


namespace Trabajo_Final_Integrador
{
    public partial class FrmMain : Form
    {
        ConnecectionApi connecectionApi;
        public List<ApiProducts> Products;
        public List<string>? Categories;
        public List<ApiProducts>? FilteredProducts;
        public FrmMain()
        {
            InitializeComponent();
            Products = new List<ApiProducts>();
            Categories = new List<string>();


            connecectionApi = new ConnecectionApi();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            MessageBox.Show(connecectionApi.GetProducts(Products));
            FilteredProducts = new List<ApiProducts>(Products);
            connecectionApi.GetCategories(Categories);

            dataGridView.DataSource = Products;

            Categories.Insert(0, "All");

            cmbBoxCategory.DataSource = Categories;

            cmbBoxCategory.SelectedIndex = 0;
        }

        private void cmbBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedCategory = cmbBoxCategory.SelectedItem.ToString();

            FilteredProducts = new List<ApiProducts>(Products);

            if (int.TryParse(txtBoxLimit.Text, out int limit) && limit > 0)
            {
                if (selectedCategory == "All")
                {
                    connecectionApi.LimitResult(Products, limit);
                }
                else
                {
                    connecectionApi.GetInCategory(FilteredProducts, selectedCategory);
                    connecectionApi.LimitResult(FilteredProducts, limit);
                }
            }
            else
            {
                if (selectedCategory == "All")
                {
                    dataGridView.DataSource = Products;
                }
                else
                {
                    connecectionApi.GetInCategory(FilteredProducts, selectedCategory);
                }
            }
            dataGridView.DataSource = null;
            dataGridView.DataSource = FilteredProducts;
        }


        private void btnAscDesc_Click(object sender, EventArgs e)
        {
            string? selectedCategory = cmbBoxCategory.SelectedItem?.ToString();

            if (selectedCategory != "All")
            {
                connecectionApi.SortResults(Products, btnAscDesc.Text);
                dataGridView.DataSource = null;
                dataGridView.DataSource = Products
                    .Where(p => p.Category != null && p.Category.Equals(selectedCategory))
                    .ToList();
            }
            else
            {
                connecectionApi.SortResults(Products, btnAscDesc.Text);
                dataGridView.DataSource = null;
                dataGridView.DataSource = Products;
            }

            if (btnAscDesc.Text == "Descendente")
            {
                btnAscDesc.Text = "Ascendente";
            }
            else
            {
                btnAscDesc.Text = "Descendente";
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
                                
                dataGridView.BindingContext[Products].SuspendBinding();
                                
                string resultMessage = connecectionApi.DeleteProducts(Products, selectedIds);
                MessageBox.Show(resultMessage);
                                
                dataGridView.DataSource = null;
                dataGridView.DataSource = Products;
                                
                dataGridView.BindingContext[Products].ResumeBinding();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila.");
            }
        }




        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var filteredProducts = (List<ApiProducts>)dataGridView.DataSource;
            var selectedProduct = filteredProducts[e.RowIndex];

            using (FrmEdit form = new FrmEdit(selectedProduct, this.Products))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dataGridView.Refresh();
                }
            }
        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Capturamos la categoría seleccionada
            string? selectedCategory = cmbBoxCategory.SelectedItem?.ToString();

            // Validamos que el texto en txtBoxSearch sea un número válido
            if (int.TryParse(txtBoxSearch.Text, out int filterId))
            {
                // Comprobamos si la lista esta filtrada
                if (selectedCategory == "All")
                {
                    var product = connecectionApi.GetSingleProduct(Products, filterId);
                    dataGridView.DataSource = new List<ApiProducts> { product };
                }
                else
                {
                    var product = connecectionApi.GetSingleProduct(FilteredProducts, filterId);
                    dataGridView.DataSource = new List<ApiProducts> { product };
                }
            }
            else
            {
                // Comprobamos si la lista esta filtrada
                if (selectedCategory == "All")
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = Products;
                }
                else
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = FilteredProducts;
                }
            }
        }



        private void txtBoxLimit_TextChanged(object sender, EventArgs e)
        {
            string? selectedCategory = cmbBoxCategory.SelectedItem?.ToString();

            if (int.TryParse(txtBoxLimit.Text, out int limit) && limit > 0)
            {
                if (selectedCategory == "All")
                {
                    var limitedList = connecectionApi.LimitResult(Products, limit);
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = limitedList;
                }
                else
                {
                    var limitedList = connecectionApi.LimitResult(FilteredProducts, limit);
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = limitedList;
                }
            }
            else
            {
                if (selectedCategory == "All")
                {
                    dataGridView.DataSource = Products;
                }
                else
                {
                    dataGridView.DataSource = FilteredProducts;
                }
            }
        }
    }
}