namespace UI
{
    partial class CustomerManagementForm
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
            dgvCustomers = new DataGridView();
            lblCustomerId = new Label();
            txtCustomerId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblSearchName = new Label();
            txtSearchName = new TextBox();
            btnSearch = new Button();
            btnClear = new Button();
            lblTotal = new Label();

            SuspendLayout();

            // dgvCustomers
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(12, 12);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(600, 250);
            dgvCustomers.TabIndex = 0;

            // lblCustomerId
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(12, 280);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(70, 15);
            lblCustomerId.TabIndex = 1;
            lblCustomerId.Text = "Customer ID:";

            // txtCustomerId
            txtCustomerId.Location = new Point(100, 280);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(150, 23);
            txtCustomerId.TabIndex = 2;

            // lblName
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 310);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 3;
            lblName.Text = "Name:";

            // txtName
            txtName.Location = new Point(100, 310);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 23);
            txtName.TabIndex = 4;

            // lblAddress
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(12, 340);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(52, 15);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address:";

            // txtAddress
            txtAddress.Location = new Point(100, 340);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(150, 23);
            txtAddress.TabIndex = 6;

            // lblPhoneNumber
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(12, 370);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(77, 15);
            lblPhoneNumber.TabIndex = 7;
            lblPhoneNumber.Text = "Phone Number:";

            // txtPhoneNumber
            txtPhoneNumber.Location = new Point(100, 370);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(150, 23);
            txtPhoneNumber.TabIndex = 8;

            // btnAdd
            btnAdd.Location = new Point(12, 410);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // btnUpdate
            btnUpdate.Location = new Point(100, 410);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // btnDelete
            btnDelete.Location = new Point(188, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // lblSearchName
            lblSearchName.AutoSize = true;
            lblSearchName.Location = new Point(310, 280);
            lblSearchName.Name = "lblSearchName";
            lblSearchName.Size = new Size(84, 15);
            lblSearchName.TabIndex = 12;
            lblSearchName.Text = "Search by Name:";

            // txtSearchName
            txtSearchName.Location = new Point(400, 280);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(150, 23);
            txtSearchName.TabIndex = 13;

            // btnSearch
            btnSearch.Location = new Point(310, 310);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // btnClear
            btnClear.Location = new Point(400, 310);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 445);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(52, 15);
            lblTotal.TabIndex = 16;
            lblTotal.Text = "Total: 0";

            // CustomerManagementForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 470);
            Controls.Add(dgvCustomers);
            Controls.Add(lblCustomerId);
            Controls.Add(txtCustomerId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblAddress);
            Controls.Add(txtAddress);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtPhoneNumber);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(lblSearchName);
            Controls.Add(txtSearchName);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(lblTotal);
            Name = "CustomerManagementForm";
            Text = "Customer Management";
            Load += CustomerManagementForm_Load;

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomers;
        private Label lblCustomerId;
        private TextBox txtCustomerId;
        private Label lblName;
        private TextBox txtName;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblSearchName;
        private TextBox txtSearchName;
        private Button btnSearch;
        private Button btnClear;
        private Label lblTotal;
    }
}
