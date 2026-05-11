namespace UI
{
    partial class MainForm
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
            btnCustomers = new Button();
            btnProducts = new Button();
            btnSales = new Button();
            btnOrders = new Button();
            btnExit = new Button();
            label1 = new Label();

            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(150, 20);
            label1.Name = "label1";
            label1.Size = new Size(300, 41);
            label1.TabIndex = 0;
            label1.Text = "Shoe Store Management";

            // btnCustomers
            btnCustomers.Font = new Font("Segoe UI", 12F);
            btnCustomers.Location = new Point(100, 100);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(200, 60);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "Manage Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;

            // btnProducts
            btnProducts.Font = new Font("Segoe UI", 12F);
            btnProducts.Location = new Point(100, 180);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(200, 60);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "Manage Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;

            // btnSales
            btnSales.Font = new Font("Segoe UI", 12F);
            btnSales.Location = new Point(100, 260);
            btnSales.Name = "btnSales";
            btnSales.Size = new Size(200, 60);
            btnSales.TabIndex = 3;
            btnSales.Text = "Manage Sales";
            btnSales.UseVisualStyleBackColor = true;
            btnSales.Click += btnSales_Click;

            // btnOrders
            btnOrders.Font = new Font("Segoe UI", 12F);
            btnOrders.Location = new Point(100, 340);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(200, 60);
            btnOrders.TabIndex = 4;
            btnOrders.Text = "Create Order (Cashier)";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;

            // btnExit
            btnExit.Font = new Font("Segoe UI", 12F);
            btnExit.Location = new Point(100, 420);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 60);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 500);
            Controls.Add(label1);
            Controls.Add(btnCustomers);
            Controls.Add(btnProducts);
            Controls.Add(btnSales);
            Controls.Add(btnOrders);
            Controls.Add(btnExit);
            Name = "MainForm";
            Text = "Shoe Store Management";
            Load += MainForm_Load;

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCustomers;
        private Button btnProducts;
        private Button btnSales;
        private Button btnOrders;
        private Button btnExit;
        private Label label1;
    }
}
