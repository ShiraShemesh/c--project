namespace UI
{
    partial class OrderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCustomer = new Label();
            cmbCustomer = new ComboBox();
            lblCustomerInfo = new Label();
            lblProduct = new Label();
            cmbProduct = new ComboBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnAddProduct = new Button();
            dgvOrder = new DataGridView();
            lblOrderSummary = new Label();
            lblTotalPrice = new Label();
            btnRemoveProduct = new Button();
            btnCompleteOrder = new Button();
            btnClearOrder = new Button();

            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(300, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create Order";

            // lblCustomer
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(12, 50);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(59, 15);
            lblCustomer.TabIndex = 1;
            lblCustomer.Text = "Customer:";

            // cmbCustomer
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomer.Location = new Point(80, 50);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(300, 23);
            cmbCustomer.TabIndex = 2;
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;

            // lblCustomerInfo
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Location = new Point(400, 50);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(138, 15);
            lblCustomerInfo.TabIndex = 3;
            lblCustomerInfo.Text = "No customer selected";

            // lblProduct
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(12, 90);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(53, 15);
            lblProduct.TabIndex = 4;
            lblProduct.Text = "Product:";

            // cmbProduct
            cmbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduct.Location = new Point(80, 90);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(300, 23);
            cmbProduct.TabIndex = 5;

            // lblQuantity
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(12, 130);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(56, 15);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Quantity:";

            // txtQuantity
            txtQuantity.Location = new Point(80, 130);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 7;

            // btnAddProduct
            btnAddProduct.Enabled = false;
            btnAddProduct.Location = new Point(190, 130);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(100, 23);
            btnAddProduct.TabIndex = 8;
            btnAddProduct.Text = "Add to Order";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;

            // lblOrderSummary
            lblOrderSummary.AutoSize = true;
            lblOrderSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblOrderSummary.Location = new Point(12, 170);
            lblOrderSummary.Name = "lblOrderSummary";
            lblOrderSummary.Size = new Size(122, 28);
            lblOrderSummary.TabIndex = 9;
            lblOrderSummary.Text = "Order Items";

            // dgvOrder
            dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrder.Location = new Point(12, 200);
            dgvOrder.Name = "dgvOrder";
            dgvOrder.RowHeadersWidth = 51;
            dgvOrder.Size = new Size(750, 300);
            dgvOrder.TabIndex = 10;

            // lblTotalPrice
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalPrice.Location = new Point(12, 520);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(166, 28);
            lblTotalPrice.TabIndex = 11;
            lblTotalPrice.Text = "Total Price: $0.00";

            // btnRemoveProduct
            btnRemoveProduct.Location = new Point(12, 560);
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(120, 30);
            btnRemoveProduct.TabIndex = 12;
            btnRemoveProduct.Text = "Remove Selected";
            btnRemoveProduct.UseVisualStyleBackColor = true;
            btnRemoveProduct.Click += btnRemoveProduct_Click;

            // btnCompleteOrder
            btnCompleteOrder.BackColor = Color.Green;
            btnCompleteOrder.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCompleteOrder.ForeColor = Color.White;
            btnCompleteOrder.Location = new Point(300, 560);
            btnCompleteOrder.Name = "btnCompleteOrder";
            btnCompleteOrder.Size = new Size(120, 30);
            btnCompleteOrder.TabIndex = 13;
            btnCompleteOrder.Text = "Complete Order";
            btnCompleteOrder.UseVisualStyleBackColor = false;
            btnCompleteOrder.Click += btnCompleteOrder_Click;

            // btnClearOrder
            btnClearOrder.Location = new Point(450, 560);
            btnClearOrder.Name = "btnClearOrder";
            btnClearOrder.Size = new Size(120, 30);
            btnClearOrder.TabIndex = 14;
            btnClearOrder.Text = "Clear Order";
            btnClearOrder.UseVisualStyleBackColor = true;
            btnClearOrder.Click += btnClearOrder_Click;

            // OrderForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 610);
            Controls.Add(lblTitle);
            Controls.Add(lblCustomer);
            Controls.Add(cmbCustomer);
            Controls.Add(lblCustomerInfo);
            Controls.Add(lblProduct);
            Controls.Add(cmbProduct);
            Controls.Add(lblQuantity);
            Controls.Add(txtQuantity);
            Controls.Add(btnAddProduct);
            Controls.Add(lblOrderSummary);
            Controls.Add(dgvOrder);
            Controls.Add(lblTotalPrice);
            Controls.Add(btnRemoveProduct);
            Controls.Add(btnCompleteOrder);
            Controls.Add(btnClearOrder);
            Name = "OrderForm";
            Text = "Create Order - Cashier";
            Load += OrderForm_Load;

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCustomer;
        private ComboBox cmbCustomer;
        private Label lblCustomerInfo;
        private Label lblProduct;
        private ComboBox cmbProduct;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnAddProduct;
        private Label lblOrderSummary;
        private DataGridView dgvOrder;
        private Label lblTotalPrice;
        private Button btnRemoveProduct;
        private Button btnCompleteOrder;
        private Button btnClearOrder;
    }
}
