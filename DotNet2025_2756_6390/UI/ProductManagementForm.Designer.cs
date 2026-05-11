namespace UI
{
    partial class ProductManagementForm
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
            dgvProducts = new DataGridView();
            lblProductId = new Label();
            txtProductId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            cmbCategory = new ComboBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            lblQuantity = new Label();
            txtQuantity = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblFilterCategory = new Label();
            cmbFilterCategory = new ComboBox();
            lblTotal = new Label();

            SuspendLayout();

            // dgvProducts
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 12);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(700, 250);
            dgvProducts.TabIndex = 0;

            // lblProductId
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(12, 280);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(60, 15);
            lblProductId.TabIndex = 1;
            lblProductId.Text = "Product ID:";

            // txtProductId
            txtProductId.Location = new Point(80, 280);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(100, 23);
            txtProductId.TabIndex = 2;

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 310);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 3;
            lblName.Text = "Name:";

            // txtName
            txtName.Location = new Point(80, 310);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 23);
            txtName.TabIndex = 4;

            // lblCategory
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(12, 340);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 5;
            lblCategory.Text = "Category:";

            // cmbCategory
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(80, 340);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(150, 23);
            cmbCategory.TabIndex = 6;

            // lblPrice
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(12, 370);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(35, 15);
            lblPrice.TabIndex = 7;
            lblPrice.Text = "Price:";

            // txtPrice
            txtPrice.Location = new Point(80, 370);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 8;

            // lblQuantity
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(12, 400);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(56, 15);
            lblQuantity.TabIndex = 9;
            lblQuantity.Text = "Quantity:";

            // txtQuantity
            txtQuantity.Location = new Point(80, 400);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 10;

            // btnAdd
            btnAdd.Location = new Point(12, 440);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // btnUpdate
            btnUpdate.Location = new Point(100, 440);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // btnDelete
            btnDelete.Location = new Point(188, 440);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // lblFilterCategory
            lblFilterCategory.AutoSize = true;
            lblFilterCategory.Location = new Point(350, 280);
            lblFilterCategory.Name = "lblFilterCategory";
            lblFilterCategory.Size = new Size(84, 15);
            lblFilterCategory.TabIndex = 14;
            lblFilterCategory.Text = "Filter Category:";

            // cmbFilterCategory
            cmbFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterCategory.Location = new Point(440, 280);
            cmbFilterCategory.Name = "cmbFilterCategory";
            cmbFilterCategory.Size = new Size(150, 23);
            cmbFilterCategory.TabIndex = 15;
            cmbFilterCategory.SelectedIndexChanged += cmbFilterCategory_SelectedIndexChanged;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 475);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(52, 15);
            lblTotal.TabIndex = 16;
            lblTotal.Text = "Total: 0";

            // ProductManagementForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 500);
            Controls.Add(dgvProducts);
            Controls.Add(lblProductId);
            Controls.Add(txtProductId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblCategory);
            Controls.Add(cmbCategory);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblQuantity);
            Controls.Add(txtQuantity);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(lblFilterCategory);
            Controls.Add(cmbFilterCategory);
            Controls.Add(lblTotal);
            Name = "ProductManagementForm";
            Text = "Product Management";
            Load += ProductManagementForm_Load;

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProducts;
        private Label lblProductId;
        private TextBox txtProductId;
        private Label lblName;
        private TextBox txtName;
        private Label lblCategory;
        private ComboBox cmbCategory;
        private Label lblPrice;
        private TextBox txtPrice;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblFilterCategory;
        private ComboBox cmbFilterCategory;
        private Label lblTotal;
    }
}
