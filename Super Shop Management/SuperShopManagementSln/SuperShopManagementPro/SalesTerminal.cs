using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopManagementPro
{
    public partial class SalesTerminal: Form
    {
        public Member Fs { get; set; }
        public DataAccess Da { get; set; }

        public SalesTerminal()
        {
            InitializeComponent();

            this.Da = new DataAccess();

            this.PopulateGridView();
            this.AutoIdGenerate();
        }

        public SalesTerminal(String id,Member fs) : this()
        {
            this.Fs = fs;
        }

        private void PopulateGridView(string sql = "select * from ProductInfo;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvProduct.AutoGenerateColumns = false;
            this.dgvProduct.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from ProductInfo where ProductName = '" + this.txtSearch.Text + "';";
            this.PopulateGridView(sql);
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
            this.txtSearch.Text = "";
        }

        private void SalesTerminal_Load(object sender, EventArgs e)
        {
            this.dgvProduct.ClearSelection();
            this.AutoIdGenerate();
        }

        private void AutoIdGenerate()
        {
            var sql = "select max(SalesId) from SalesTable;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            var oldId = dt.Rows[0][0].ToString();

            if (string.IsNullOrEmpty(oldId))
            {
                this.txtSalesID.Text = "SA-001";
            }
            else
            {
                var temp = oldId.Split('-');
                var num = Convert.ToInt32(temp[1]);
                var currentId = "SA-" + (++num).ToString("d3");
                this.txtSalesID.Text = currentId;
            }
        }

        private void dgvProduct_DoubleClick(object sender, EventArgs e)
        {
            this.txtProductName.Text = this.dgvProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            this.txtProductPrice.Text = this.dgvProduct.CurrentRow.Cells["ProductPrice"].Value.ToString();
            this.cmbProductUnit.Text = this.dgvProduct.CurrentRow.Cells["ProductUnit"].Value.ToString();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtProductPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                cmbProductUnit.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtTotalPrice.Text))
            {
                MessageBox.Show("Please fill all the required fields before adding to the cart.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string SalesId = txtSalesID.Text;
            string ProductName = txtProductName.Text;
            string Price = txtProductPrice.Text;
            string Quantity = txtQuantity.Text;
            string Unit = cmbProductUnit.SelectedItem.ToString();
            string TotalPrice = txtTotalPrice.Text;
            string Date = dtpSaleDate.Value.ToString("yyyy-MM-dd");

            // Check for duplicate product
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[1].Value?.ToString() == ProductName)
                {
                    MessageBox.Show("This product is already in the cart.", "Duplicate Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Add to cart
            dgvSales.Rows.Add(SalesId, ProductName, Price, Quantity, Unit, TotalPrice, Date);

            this.UpdateTotalAmount();
            this.ClearAll();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSales.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvSales.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvSales.Rows.Remove(row);
                    }
                }

                // Update total after deletion
                UpdateTotalAmount();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (decimal.TryParse(txtProductPrice.Text, out decimal price) &&
                int.TryParse(txtQuantity.Text, out int quantity))
            {
                decimal total = price * quantity;
                txtTotalPrice.Text = total.ToString("0.00"); // Optional: format to 2 decimal places
            }
            else
            {
                txtTotalPrice.Text = ""; // Clear if input is invalid
            }
        }

        private void ClearAll()
        {
            //this.txtSalesID.Clear();
            this.txtProductName.Clear();
            this.txtProductPrice.Clear();
            this.txtQuantity.Clear();
            this.cmbProductUnit.SelectedIndex = -1;
            this.txtTotalPrice.Clear();
            this.dtpSaleDate.Text = "";

            this.dgvSales.ClearSelection();
            //this.AutoIdGenerate();
        }

        private void UpdateTotalAmount()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                if (row.IsNewRow) continue;

                if (decimal.TryParse(row.Cells[5].Value?.ToString(), out decimal value)) // Assuming TotalPrice is column index 5
                {
                    total += value;
                }
            }

            lblTotalAmount.Text = "Total: " + total.ToString("0.00") + " Tk";
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            // Check if a payment method is selected
            if (!rdbtnCash.Checked && !rdbtnOnline.Checked && !rdbtnCard.Checked)
            {
                MessageBox.Show("Please select a payment method before checkout.", "Payment Method Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvSales.Rows.Count == 0 || (dgvSales.Rows.Count == 1 && dgvSales.Rows[0].IsNewRow))
            {
                MessageBox.Show("No transaction found. Please add items to the cart before checkout.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected payment method
            string paymentMethod = "";
            if (rdbtnCash.Checked) paymentMethod = "Cash";
            else if (rdbtnOnline.Checked) paymentMethod = "Online";
            else if (rdbtnCard.Checked) paymentMethod = "Card";

            try
            {
                string salesmanId = this.Fs.Id.ToUpper();

                // Check if salesman exists
                string checkQuery = $"SELECT COUNT(*) FROM Userinfo WHERE ID = '{salesmanId}'";
                DataTable dtCheck = this.Da.ExecuteQueryTable(checkQuery);

                if (dtCheck.Rows.Count == 0 || Convert.ToInt32(dtCheck.Rows[0][0]) == 0)
                {
                    MessageBox.Show($"Salesman ID '{salesmanId}' does not exist in Userinfo table.", "Foreign Key Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Process each item in cart
                foreach (DataGridViewRow row in dgvSales.Rows)
                {
                    if (row.IsNewRow) continue;

                    string salesId = row.Cells[0].Value.ToString();
                    string productName = row.Cells[1].Value.ToString();
                    decimal price = Convert.ToDecimal(row.Cells[2].Value);
                    int quantity = Convert.ToInt32(row.Cells[3].Value);
                    string unit = row.Cells[4].Value.ToString();
                    decimal total = Convert.ToDecimal(row.Cells[5].Value);
                    string date = Convert.ToDateTime(row.Cells[6].Value).ToString("yyyy-MM-dd");

                    // Check stock
                    string queryAvailability = $"SELECT ProductAvailabilty FROM ProductInfo WHERE ProductName = '{productName}'";
                    DataTable dt = this.Da.ExecuteQueryTable(queryAvailability);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show($"Product not found: {productName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    int currentAvailability = Convert.ToInt32(dt.Rows[0]["ProductAvailabilty"]);

                    if (currentAvailability < quantity)
                    {
                        MessageBox.Show($"Not enough stock for '{productName}'. Available: {currentAvailability}", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    // Update inventory
                    int newAvailability = currentAvailability - quantity;
                    string updateQuery = $"UPDATE ProductInfo SET ProductAvailabilty = {newAvailability} WHERE ProductName = '{productName}'";
                    this.Da.ExecuteDMLQuery(updateQuery);

                    // Insert sale with payment method
                    string insertQuery = $@" INSERT INTO SalesTable 
                                        (SalesId, ID, ProductNames, Price, Quantity, Unit, TotalPrice, Date, PaymentMethod)
                                        VALUES 
                                        ('{salesId}', '{salesmanId}', '{productName}', {price}, {quantity}, '{unit}', {total}, '{date}', '{paymentMethod}');";
                   
                    this.Da.ExecuteDMLQuery(insertQuery);
                }

                // Final message & reset
                MessageBox.Show("Checkout successful. Inventory updated & sales recorded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvSales.Rows.Clear();
                this.UpdateTotalAmount();
                this.AutoIdGenerate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Checkout error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Back to the Member page");
            this.Hide();
            this.Fs.Show();
        }

        private void SalesTerminal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }

}
