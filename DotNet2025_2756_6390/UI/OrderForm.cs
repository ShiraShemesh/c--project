using BlApi;
using BO;

namespace UI
{
    public partial class OrderForm : Form
    {
        private IBL _bl;
        private Order _order;
        private List<Product?> _products = new();
        private List<Customer?> _customers = new();
        private Customer? _selectedCustomer;

        public OrderForm(IBL bl)
        {
            InitializeComponent();
            _bl = bl;
            _order = new Order { Products = new(), TotalPrice = 0 };
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadProducts();
            SetupOrderGrid();
            ClearForm();
        }

        private void LoadCustomers()
        {
            try
            {
                _customers = _bl.Customer.ReadAll() ?? new();
                cmbCustomer.Items.Clear();
                foreach (var customer in _customers)
                {
                    if (customer != null)
                        cmbCustomer.Items.Add($"ID: {customer.CustomerId} - {customer.Name}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                _products = _bl.Product.ReadAll() ?? new();
                cmbProduct.Items.Clear();
                foreach (var product in _products)
                {
                    if (product != null)
                        cmbProduct.Items.Add($"ID: {product.ProductId} - {product.Name} (Price: ${product.Price:F2})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupOrderGrid()
        {
            dgvOrder.AutoGenerateColumns = false;
            dgvOrder.Columns.Clear();
            dgvOrder.Columns.Add("ProductId", "Product ID");
            dgvOrder.Columns.Add("Name", "Product Name");
            dgvOrder.Columns.Add("BasePrice", "Base Price");
            dgvOrder.Columns.Add("Quantity", "Quantity");
            dgvOrder.Columns.Add("finalPrice", "Final Price");

            dgvOrder.Columns[0].DataPropertyName = "ProductId";
            dgvOrder.Columns[1].DataPropertyName = "Name";
            dgvOrder.Columns[2].DataPropertyName = "BasePrice";
            dgvOrder.Columns[3].DataPropertyName = "Quantity";
            dgvOrder.Columns[4].DataPropertyName = "finalPrice";

            dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedIndex >= 0 && cmbCustomer.SelectedIndex < _customers.Count)
            {
                _selectedCustomer = _customers[cmbCustomer.SelectedIndex];
                _order = new Order { Products = new(), TotalPrice = 0, IsPreferredCustomer = true };
                lblCustomerInfo.Text = $"Selected: {_selectedCustomer?.Name}";
                btnAddProduct.Enabled = true;
                RefreshOrderGrid();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out var quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var product = _products[cmbProduct.SelectedIndex];
                if (product == null)
                {
                    MessageBox.Show("Invalid product selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (product.QuantityInStock < quantity)
                {
                    MessageBox.Show($"Not enough stock. Available: {product.QuantityInStock}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if product already in order
                var existingProduct = _order.Products.FirstOrDefault(p => p?.ProductId == product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.Quantity += quantity;
                }
                else
                {
                    var productInOrder = new ProductInOrder
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        BasePrice = product.Price ?? 0,
                        Quantity = quantity,
                        Sales = new(),
                        finalPrice = (product.Price ?? 0) * quantity
                    };

                    // Search for applicable sales
                    _bl.Order.SearchSaleForProduct(productInOrder, _order.IsPreferredCustomer);
                    _bl.Order.CalcTotalPriceForProduct(productInOrder);

                    _order.Products.Add(productInOrder);
                }

                RefreshOrderGrid();
                UpdateTotalPrice();
                cmbProduct.SelectedIndex = -1;
                txtQuantity.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshOrderGrid()
        {
            dgvOrder.DataSource = null;
            dgvOrder.DataSource = new BindingSource(_order.Products, null);
        }

        private void UpdateTotalPrice()
        {
            _bl.Order.CalcTotalPrice(_order);
            lblTotalPrice.Text = $"Total Price: ${_order.TotalPrice:F2}";
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOrder.Columns["Remove"]?.Index && e.RowIndex >= 0)
            {
                if (e.RowIndex < _order.Products.Count)
                {
                    _order.Products.RemoveAt(e.RowIndex);
                    RefreshOrderGrid();
                    UpdateTotalPrice();
                }
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvOrder.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < _order.Products.Count)
                {
                    _order.Products.RemoveAt(selectedIndex);
                    RefreshOrderGrid();
                    UpdateTotalPrice();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_order.Products.Count == 0)
            {
                MessageBox.Show("Please add at least one product to the order.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _bl.Order.DoOrder(_order);
                MessageBox.Show($"Order completed successfully!\nTotal: ${_order.TotalPrice:F2}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                _order = new Order { Products = new(), TotalPrice = 0 };
                RefreshOrderGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error completing order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            ClearForm();
            _order = new Order { Products = new(), TotalPrice = 0 };
            RefreshOrderGrid();
        }

        private void ClearForm()
        {
            cmbCustomer.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            txtQuantity.Clear();
            lblCustomerInfo.Text = "No customer selected";
            lblTotalPrice.Text = "Total Price: $0.00";
            _selectedCustomer = null;
            btnAddProduct.Enabled = false;
        }
    }
}
