using BlApi;
using BO;

namespace UI
{
    public partial class ProductManagementForm : Form
    {
        private IBL _bl;
        private List<Product?> _products = new();
        private Product? _selectedProduct;

        public ProductManagementForm(IBL bl)
        {
            InitializeComponent();
            _bl = bl;
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            SetupCategoryCombo();
            LoadProducts();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Add("ProductId", "ID");
            dgvProducts.Columns.Add("Name", "Name");
            dgvProducts.Columns.Add("Category", "Category");
            dgvProducts.Columns.Add("Price", "Price");
            dgvProducts.Columns.Add("QuantityInStock", "Stock Qty");

            dgvProducts.Columns[0].DataPropertyName = "ProductId";
            dgvProducts.Columns[1].DataPropertyName = "Name";
            dgvProducts.Columns[2].DataPropertyName = "Category";
            dgvProducts.Columns[3].DataPropertyName = "Price";
            dgvProducts.Columns[4].DataPropertyName = "QuantityInStock";

            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.CellClick += DgvProducts_CellClick;
        }

        private void SetupCategoryCombo()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add(Categories.WOMEN);
            cmbCategory.Items.Add(Categories.MEN);
            cmbCategory.Items.Add(Categories.SPORTS);
            cmbCategory.Items.Add(Categories.ELEGANT);
            cmbCategory.Items.Add(Categories.CHILDREN);

            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("All Categories");
            cmbFilterCategory.Items.Add(Categories.WOMEN);
            cmbFilterCategory.Items.Add(Categories.MEN);
            cmbFilterCategory.Items.Add(Categories.SPORTS);
            cmbFilterCategory.Items.Add(Categories.ELEGANT);
            cmbFilterCategory.Items.Add(Categories.CHILDREN);
            cmbFilterCategory.SelectedIndex = 0;
        }

        private void LoadProducts(Func<Product, bool>? filter = null)
        {
            try
            {
                _products = _bl.Product.ReadAll(filter) ?? new();
                dgvProducts.DataSource = new BindingSource(_products, null);
                lblTotal.Text = $"Total Products: {_products.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _products.Count)
            {
                _selectedProduct = _products[e.RowIndex];
                DisplayProduct(_selectedProduct);
            }
        }

        private void DisplayProduct(Product? product)
        {
            if (product == null)
            {
                ClearForm();
                return;
            }

            txtProductId.Text = product.ProductId.ToString();
            txtName.Text = product.Name ?? string.Empty;
            cmbCategory.SelectedItem = product.Category;
            txtPrice.Text = product.Price?.ToString("F2") ?? string.Empty;
            txtQuantity.Text = product.QuantityInStock?.ToString() ?? string.Empty;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void ClearForm()
        {
            txtProductId.Clear();
            txtName.Clear();
            cmbCategory.SelectedIndex = -1;
            txtPrice.Clear();
            txtQuantity.Clear();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            _selectedProduct = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var product = new Product
                {
                    ProductId = int.Parse(txtProductId.Text),
                    Name = txtName.Text,
                    Category = (Categories)cmbCategory.SelectedItem!,
                    Price = double.Parse(txtPrice.Text),
                    QuantityInStock = int.Parse(txtQuantity.Text)
                };

                _bl.Product.Create(product);
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                var product = new Product
                {
                    ProductId = _selectedProduct.ProductId,
                    Name = txtName.Text,
                    Category = (Categories)cmbCategory.SelectedItem!,
                    Price = double.Parse(txtPrice.Text),
                    QuantityInStock = int.Parse(txtQuantity.Text)
                };

                _bl.Product.Update(product);
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                _bl.Product.Delete(_selectedProduct.ProductId);
                MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterCategory.SelectedIndex == 0)
            {
                LoadProducts();
            }
            else
            {
                var selectedCategory = (Categories)cmbFilterCategory.SelectedItem!;
                LoadProducts(p => p.Category == selectedCategory);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text) || !int.TryParse(txtProductId.Text, out _))
            {
                MessageBox.Show("Please enter a valid Product ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !double.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !int.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("Please enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
