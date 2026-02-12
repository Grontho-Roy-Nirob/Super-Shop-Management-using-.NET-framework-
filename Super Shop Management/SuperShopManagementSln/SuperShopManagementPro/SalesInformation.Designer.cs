namespace SuperShopManagementPro
{
    partial class SalesInformation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesInformation));
            this.dgvSalesInformation = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShowDetails = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCheck = new System.Windows.Forms.CheckBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.dtpSearchSaleDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSalemanId = new System.Windows.Forms.Button();
            this.txtSearchSalesmanId = new System.Windows.Forms.TextBox();
            this.txtSearchBranch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesInformation)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalesInformation
            // 
            this.dgvSalesInformation.AllowUserToAddRows = false;
            this.dgvSalesInformation.AllowUserToDeleteRows = false;
            this.dgvSalesInformation.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesInformation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesInformation.ColumnHeadersHeight = 35;
            this.dgvSalesInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SalesId,
            this.ProductNames,
            this.Price,
            this.Quantity,
            this.TotalPrice,
            this.Date,
            this.Branch,
            this.paymentMethod});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesInformation.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesInformation.Location = new System.Drawing.Point(3, 319);
            this.dgvSalesInformation.Name = "dgvSalesInformation";
            this.dgvSalesInformation.ReadOnly = true;
            this.dgvSalesInformation.RowHeadersWidth = 157;
            this.dgvSalesInformation.Size = new System.Drawing.Size(1074, 293);
            this.dgvSalesInformation.TabIndex = 18;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "SALESMAN ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 110;
            // 
            // SalesId
            // 
            this.SalesId.DataPropertyName = "SalesId";
            this.SalesId.HeaderText = "SALES ID";
            this.SalesId.Name = "SalesId";
            this.SalesId.ReadOnly = true;
            this.SalesId.Width = 80;
            // 
            // ProductNames
            // 
            this.ProductNames.DataPropertyName = "ProductNames";
            this.ProductNames.HeaderText = "PRODUCT NAME";
            this.ProductNames.Name = "ProductNames";
            this.ProductNames.ReadOnly = true;
            this.ProductNames.Width = 120;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "PRODUCT PRICE";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 120;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "QUANTITY";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 80;
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "TOTAL PRICE";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Width = 110;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "SALE DATE";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Branch
            // 
            this.Branch.DataPropertyName = "Branch";
            this.Branch.HeaderText = "BRANCH";
            this.Branch.Name = "Branch";
            this.Branch.ReadOnly = true;
            this.Branch.Width = 70;
            // 
            // paymentMethod
            // 
            this.paymentMethod.DataPropertyName = "paymentMethod";
            this.paymentMethod.HeaderText = "PAYMENT METHOD";
            this.paymentMethod.Name = "paymentMethod";
            this.paymentMethod.ReadOnly = true;
            this.paymentMethod.Width = 150;
            // 
            // btnShowDetails
            // 
            this.btnShowDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnShowDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowDetails.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnShowDetails.Location = new System.Drawing.Point(3, 256);
            this.btnShowDetails.Name = "btnShowDetails";
            this.btnShowDetails.Size = new System.Drawing.Size(137, 52);
            this.btnShowDetails.TabIndex = 110;
            this.btnShowDetails.Text = "Show Details ";
            this.btnShowDetails.UseVisualStyleBackColor = false;
            this.btnShowDetails.Click += new System.EventHandler(this.btnShowDetails_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.cbCheck);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.dtpSearchSaleDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnSalemanId);
            this.panel1.Controls.Add(this.txtSearchSalesmanId);
            this.panel1.Controls.Add(this.txtSearchBranch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnShowDetails);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1074, 311);
            this.panel1.TabIndex = 111;
            // 
            // cbCheck
            // 
            this.cbCheck.AutoSize = true;
            this.cbCheck.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbCheck.Location = new System.Drawing.Point(796, 198);
            this.cbCheck.Name = "cbCheck";
            this.cbCheck.Size = new System.Drawing.Size(111, 25);
            this.cbCheck.TabIndex = 135;
            this.cbCheck.Text = "ADD DATE";
            this.cbCheck.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Maroon;
            this.btnBack.Font = new System.Drawing.Font("Lucida Bright", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBack.Location = new System.Drawing.Point(947, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(124, 50);
            this.btnBack.TabIndex = 134;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtpSearchSaleDate
            // 
            this.dtpSearchSaleDate.CustomFormat = "yyyy-MM-dd";
            this.dtpSearchSaleDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearchSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearchSaleDate.Location = new System.Drawing.Point(767, 155);
            this.dtpSearchSaleDate.Name = "dtpSearchSaleDate";
            this.dtpSearchSaleDate.Size = new System.Drawing.Size(187, 31);
            this.dtpSearchSaleDate.TabIndex = 133;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(793, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 16);
            this.label3.TabIndex = 132;
            this.label3.Text = "Search by Sale Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(479, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 131;
            this.label2.Text = "Search by Salesman Id";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(162, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 16);
            this.label9.TabIndex = 130;
            this.label9.Text = "Search by Branch";
            // 
            // btnSalemanId
            // 
            this.btnSalemanId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnSalemanId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalemanId.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSalemanId.Location = new System.Drawing.Point(500, 198);
            this.btnSalemanId.Name = "btnSalemanId";
            this.btnSalemanId.Size = new System.Drawing.Size(101, 41);
            this.btnSalemanId.TabIndex = 128;
            this.btnSalemanId.Text = "Search";
            this.btnSalemanId.UseVisualStyleBackColor = false;
            this.btnSalemanId.Click += new System.EventHandler(this.btnSalemanId_Click);
            // 
            // txtSearchSalesmanId
            // 
            this.txtSearchSalesmanId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSalesmanId.Location = new System.Drawing.Point(449, 155);
            this.txtSearchSalesmanId.Name = "txtSearchSalesmanId";
            this.txtSearchSalesmanId.Size = new System.Drawing.Size(205, 31);
            this.txtSearchSalesmanId.TabIndex = 127;
            // 
            // txtSearchBranch
            // 
            this.txtSearchBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBranch.Location = new System.Drawing.Point(121, 155);
            this.txtSearchBranch.Name = "txtSearchBranch";
            this.txtSearchBranch.Size = new System.Drawing.Size(205, 31);
            this.txtSearchBranch.TabIndex = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(348, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 57);
            this.label1.TabIndex = 121;
            this.label1.Text = "<--Sales Records -->";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClear.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Location = new System.Drawing.Point(955, 255);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(116, 55);
            this.btnClear.TabIndex = 136;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // SalesInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 611);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSalesInformation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesInformation";
            this.Text = "SalesInformation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SalesInformation_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesInformation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethod;
        private System.Windows.Forms.Button btnShowDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchBranch;
        private System.Windows.Forms.TextBox txtSearchSalesmanId;
        private System.Windows.Forms.Button btnSalemanId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpSearchSaleDate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.CheckBox cbCheck;
        private System.Windows.Forms.Button btnClear;
    }
}