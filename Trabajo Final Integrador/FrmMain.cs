using Datos;
using Negocio;
using System.Windows.Forms;

namespace Trabajo_Final_Integrador
{
    public partial class FrmMain : Form
    {
        ConnecectionApi connecectionApi;
        public List<ApiProducts> Products;
        public List<string>? Categories;
        public FrmMain()
        {
            InitializeComponent();
            Products = new List<ApiProducts>();
            Categories = new List<string>();
            connecectionApi = new ConnecectionApi("https://fakestoreapi.com");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            MessageBox.Show(connecectionApi.GetProducts(Products));
            connecectionApi.GetCategories(Categories);
                        
            dataGridView.DataSource = Products;

            Categories.Insert(0, "All");

            cmbBoxCategory.DataSource = Categories;
                        
            cmbBoxCategory.SelectedIndex = 0;
        }

        private void cmbBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string? selectedCategory = cmbBoxCategory.SelectedItem.ToString();
                        
            if (selectedCategory == "All")
            {
                dataGridView.DataSource = Products;
            }
            else
            {
                dataGridView.DataSource = Products.Where(p => p.Category != null && p.Category.Equals(selectedCategory)).ToList();
            }                
        }

        private void btnAscDesc_Click(object sender, EventArgs e)
        {
            string? selectedCategory = cmbBoxCategory.SelectedItem?.ToString();

            if (selectedCategory != "All")
            {
                connecectionApi.SortResults(Products, btnAscDesc.Text);
                dataGridView.DataSource = null;
                dataGridView.DataSource = Products.Where(p => p.Category != null && p.Category.Equals(selectedCategory)).ToList();
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
                                
                string resultMessage = connecectionApi.DeleteProducts(Products, selectedIds);
                MessageBox.Show(resultMessage);
                                                
                dataGridView.DataSource = null; 
                dataGridView.DataSource = Products;
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
    }
}