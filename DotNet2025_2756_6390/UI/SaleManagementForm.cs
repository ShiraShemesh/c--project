using BlApi;
using BO;

namespace UI
{
    public partial class SaleManagementForm : Form
    {
        private IBL _bl;
        private List<Sale?> _sales = new();
        private Sale? _selectedSale;
        private List<Product?> _products = new();

        public SaleManagementForm(IBL bl)
        {
            InitializeComponent();
            _bl = bl;
        }

        private void SaleManagementForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadProducts();
            LoadSales();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvSales.AutoGenerateColumns = false;
            dgvSales.Columns.Add("SaleId", "ID");
            dgvSales.Columns.Add("ProductId", "Product ID");
            dgvSales.Columns.Add("RequiedQuantity", "Req. Qty");
            dgvSales.Columns.Add("PriceWhithSale", "Sale Price");
            dgvSales.Columns.Add("IsClub", "Club Only");
            dgvSales.Columns.Add("Startsale", "Start Date");
            dgvSales.Columns.Add("FinishSale", "End Date");

            dgvSales.Columns[0].DataPropertyName = "SaleId";
            dgvSales.Columns[1].DataPropertyName = "ProductId";
            dgvSales.Columns[2].DataPropertyName = "RequiedQuantity";
            dgvSales.Columns[3].DataPropertyName = "PriceWhithSale";
            dgvSales.Columns[4].DataPropertyName = "IsClub";
            dgvSales.Columns[5].DataPropertyName = "Startsale";
            dgvSales.Columns[6].DataPropertyName = "FinishSale";

            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.MultiSelect = false;
            dgvSales.CellClick += DgvSales_CellClick;
        }

        private void LoadProducts()
        {
            try
            {
                _products = _bl.Product.ReadAll() ?? new();
                cmbProductId.Items.Clear();
                foreach (var product in _products)
                {
                    if (product != null)
                        cmbProductId.Items.Add($"ID: {product.ProductId} - {product.Name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSales(Func<Sale, bool>? filter = null)
        {
            try
            {
                _sales = _bl.Sale.ReadAll(filter) ?? new();
                dgvSales.DataSource = new BindingSource(_sales, null);
                lblTotal.Text = $"Total Sales: {_sales.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _sales.Count)
            {
                _selectedSale = _sales[e.RowIndex];
                DisplaySale(_selectedSale);
            }
        }

        private void DisplaySale(Sale? sale)
        {
            if (sale == null)
            {
                ClearForm();
                return;
            }

            // Find product in combobox
            cmbProductId.SelectedIndex = _products.FindIndex(p => p?.ProductId == sale.ProductId);
            txtRequiredQuantity.Text = sale.RequiedQuantity.ToString();
            txtSalePrice.Text = sale.PriceWhithSale.ToString("F2");
            chkClub.Checked = sale.IsClub;
            dtpStartDate.Value = sale.Startsale;
            dtpEndDate.Value = sale.FinishSale;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void ClearForm()
        {
            cmbProductId.SelectedIndex = -1;
            txtRequiredQuantity.Clear();
            txtSalePrice.Clear();
            chkClub.Checked = false;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(7);

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            _selectedSale = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var productId = GetSelectedProductId();
                var sale = new Sale
                {
                    ProductId = productId,
                    RequiedQuantity = int.Parse(txtRequiredQuantity.Text),
                    PriceWhithSale = double.Parse(txtSalePrice.Text),
                    IsClub = chkClub.Checked,
                    Startsale = dtpStartDate.Value,
                    FinishSale = dtpEndDate.Value
                };

                _bl.Sale.Create(sale);
                MessageBox.Show("Sale added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSales();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedSale == null)
            {
                MessageBox.Show("Please select a sale to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                var productId = GetSelectedProductId();
                var sale = new Sale
                {
                    SaleId = _selectedSale.SaleId,
                    ProductId = productId,
                    RequiedQuantity = int.Parse(txtRequiredQuantity.Text),
                    PriceWhithSale = double.Parse(txtSalePrice.Text),
                    IsClub = chkClub.Checked,
                    Startsale = dtpStartDate.Value,
                    FinishSale = dtpEndDate.Value
                };

                _bl.Sale.Update(sale);
                MessageBox.Show("Sale updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSales();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSale == null)
            {
                MessageBox.Show("Please select a sale to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this sale?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                _bl.Sale.Delete(_selectedSale.SaleId);
                MessageBox.Show("Sale deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSales();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting sale: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedProductId()
        {
            if (cmbProductId.SelectedIndex < 0)
                throw new Exception("Please select a product");

            return _products[cmbProductId.SelectedIndex]?.ProductId ?? throw new Exception("Invalid product");
        }

        private bool ValidateInput()
        {
            if (cmbProductId.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRequiredQuantity.Text) || !int.TryParse(txtRequiredQuantity.Text, out var qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid required quantity (greater than 0).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSalePrice.Text) || !double.TryParse(txtSalePrice.Text, out var price) || price < 0)
            {
                MessageBox.Show("Please enter a valid sale price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("End date must be after start date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
