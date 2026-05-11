namespace UI
{
    partial class SaleManagementForm
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
            dgvSales = new DataGridView();
            lblProductId = new Label();
            cmbProductId = new ComboBox();
            lblRequiredQuantity = new Label();
            txtRequiredQuantity = new TextBox();
            lblSalePrice = new Label();
            txtSalePrice = new TextBox();
            chkClub = new CheckBox();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lblTotal = new Label();

            SuspendLayout();

            // dgvSales
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(12, 12);
            dgvSales.Name = "dgvSales";
            dgvSales.RowHeadersWidth = 51;
            dgvSales.Size = new Size(900, 250);
            dgvSales.TabIndex = 0;

            // lblProductId
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(12, 280);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(60, 15);
            lblProductId.TabIndex = 1;
            lblProductId.Text = "Product:";

            // cmbProductId
            cmbProductId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProductId.Location = new Point(80, 280);
            cmbProductId.Name = "cmbProductId";
            cmbProductId.Size = new Size(200, 23);
            cmbProductId.TabIndex = 2;

            // lblRequiredQuantity
            lblRequiredQuantity.AutoSize = true;
            lblRequiredQuantity.Location = new Point(12, 310);
            lblRequiredQuantity.Name = "lblRequiredQuantity";
            lblRequiredQuantity.Size = new Size(108, 15);
            lblRequiredQuantity.TabIndex = 3;
            lblRequiredQuantity.Text = "Required Quantity:";

            // txtRequiredQuantity
            txtRequiredQuantity.Location = new Point(130, 310);
            txtRequiredQuantity.Name = "txtRequiredQuantity";
            txtRequiredQuantity.Size = new Size(100, 23);
            txtRequiredQuantity.TabIndex = 4;

            // lblSalePrice
            lblSalePrice.AutoSize = true;
            lblSalePrice.Location = new Point(12, 340);
            lblSalePrice.Name = "lblSalePrice";
            lblSalePrice.Size = new Size(58, 15);
            lblSalePrice.TabIndex = 5;
            lblSalePrice.Text = "Sale Price:";

            // txtSalePrice
            txtSalePrice.Location = new Point(80, 340);
            txtSalePrice.Name = "txtSalePrice";
            txtSalePrice.Size = new Size(100, 23);
            txtSalePrice.TabIndex = 6;

            // chkClub
            chkClub.AutoSize = true;
            chkClub.Location = new Point(80, 370);
            chkClub.Name = "chkClub";
            chkClub.Size = new Size(112, 19);
            chkClub.TabIndex = 7;
            chkClub.Text = "Club Members Only";
            chkClub.UseVisualStyleBackColor = true;

            // lblStartDate
            lblStartDate.AutoSize = true;
            lblStartDate.Location = new Point(12, 400);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(60, 15);
            lblStartDate.TabIndex = 8;
            lblStartDate.Text = "Start Date:";

            // dtpStartDate
            dtpStartDate.Location = new Point(80, 400);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 9;

            // lblEndDate
            lblEndDate.AutoSize = true;
            lblEndDate.Location = new Point(12, 430);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(56, 15);
            lblEndDate.TabIndex = 10;
            lblEndDate.Text = "End Date:";

            // dtpEndDate
            dtpEndDate.Location = new Point(80, 430);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 11;

            // btnAdd
            btnAdd.Location = new Point(12, 470);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // btnUpdate
            btnUpdate.Location = new Point(100, 470);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // btnDelete
            btnDelete.Location = new Point(188, 470);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // lblTotal
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(12, 505);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(52, 15);
            lblTotal.TabIndex = 15;
            lblTotal.Text = "Total: 0";

            // SaleManagementForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 530);
            Controls.Add(dgvSales);
            Controls.Add(lblProductId);
            Controls.Add(cmbProductId);
            Controls.Add(lblRequiredQuantity);
            Controls.Add(txtRequiredQuantity);
            Controls.Add(lblSalePrice);
            Controls.Add(txtSalePrice);
            Controls.Add(chkClub);
            Controls.Add(lblStartDate);
            Controls.Add(dtpStartDate);
            Controls.Add(lblEndDate);
            Controls.Add(dtpEndDate);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(lblTotal);
            Name = "SaleManagementForm";
            Text = "Sale Management";
            Load += SaleManagementForm_Load;

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSales;
        private Label lblProductId;
        private ComboBox cmbProductId;
        private Label lblRequiredQuantity;
        private TextBox txtRequiredQuantity;
        private Label lblSalePrice;
        private TextBox txtSalePrice;
        private CheckBox chkClub;
        private Label lblStartDate;
        private DateTimePicker dtpStartDate;
        private Label lblEndDate;
        private DateTimePicker dtpEndDate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lblTotal;
    }
}
