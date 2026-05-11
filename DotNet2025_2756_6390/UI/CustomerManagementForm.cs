using BlApi;
using BO;

namespace UI
{
    public partial class CustomerManagementForm : Form
    {
        private IBL _bl;
        private List<Customer?> _customers = new();
        private Customer? _selectedCustomer;

        public CustomerManagementForm(IBL bl)
        {
            InitializeComponent();
            _bl = bl;
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadCustomers();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Add("CustomerId", "ID");
            dgvCustomers.Columns.Add("Name", "Name");
            dgvCustomers.Columns.Add("Address", "Address");
            dgvCustomers.Columns.Add("PhoneNumber", "Phone");

            dgvCustomers.Columns[0].DataPropertyName = "CustomerId";
            dgvCustomers.Columns[1].DataPropertyName = "Name";
            dgvCustomers.Columns[2].DataPropertyName = "Address";
            dgvCustomers.Columns[3].DataPropertyName = "PhoneNumber";

            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.CellClick += DgvCustomers_CellClick;
        }

        private void LoadCustomers(Func<Customer, bool>? filter = null)
        {
            try
            {
                _customers = _bl.Customer.ReadAll(filter) ?? new();
                dgvCustomers.DataSource = new BindingSource(_customers, null);
                lblTotal.Text = $"Total Customers: {_customers.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _customers.Count)
            {
                _selectedCustomer = _customers[e.RowIndex];
                DisplayCustomer(_selectedCustomer);
            }
        }

        private void DisplayCustomer(Customer? customer)
        {
            if (customer == null)
            {
                ClearForm();
                return;
            }

            txtCustomerId.Text = customer.CustomerId.ToString();
            txtName.Text = customer.Name;
            txtAddress.Text = customer.Address ?? string.Empty;
            txtPhoneNumber.Text = customer.PhoneNumber ?? string.Empty;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void ClearForm()
        {
            txtCustomerId.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtPhoneNumber.Clear();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            _selectedCustomer = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var customer = new Customer
                {
                    CustomerId = int.Parse(txtCustomerId.Text),
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhoneNumber.Text
                };

                _bl.Customer.Create(customer);
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                var customer = new Customer
                {
                    CustomerId = _selectedCustomer.CustomerId,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    PhoneNumber = txtPhoneNumber.Text
                };

                _bl.Customer.Update(customer);
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            try
            {
                _bl.Customer.Delete(_selectedCustomer.CustomerId);
                MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomers();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = txtSearchName.Text.Trim();

            if (string.IsNullOrEmpty(searchName))
            {
                LoadCustomers();
                return;
            }

            LoadCustomers(c => c.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchName.Clear();
            LoadCustomers();
            ClearForm();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtCustomerId.Text) || !int.TryParse(txtCustomerId.Text, out _))
            {
                MessageBox.Show("Please enter a valid Customer ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
