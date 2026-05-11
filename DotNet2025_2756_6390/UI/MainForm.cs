using BlApi;

namespace UI
{
    public partial class MainForm : Form
    {
        private IBL? _bl;

        public MainForm()
        {
            InitializeComponent();
            _bl = BlApi.Factory.Get();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = "Shoe Store Management System";
            CenterToScreen();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var form = new CustomerManagementForm(_bl);
            form.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var form = new ProductManagementForm(_bl);
            form.ShowDialog();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            var form = new SaleManagementForm(_bl);
            form.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            var form = new OrderForm(_bl);
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
