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
    public partial class ProductInformation: Form
    {
        public Admin Fa { get; set; }
        public DataAccess Da { get; set; }

        public ProductInformation()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.PopulateGridView();
            this.AutoIdGenerate();
        }

        public ProductInformation(Admin fa) : this()
        {
            this.Fa = fa;
        }

        private void PopulateGridView(string sql = "select * from ProductInfo;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvProduct.AutoGenerateColumns = false;
            this.dgvProduct.DataSource = ds.Tables[0];
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from ProductInfo where ProductName = '" + this.txtSearch.Text + "';";
            this.PopulateGridView(sql);
        }

        private void ProductInformation_Load(object sender, EventArgs e)
        {
            this.dgvProduct.ClearSelection();
            this.AutoIdGenerate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }


        private void ClearAll()
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.txtPrice.Clear();
            this.txtAvailability.Clear();
            this.cmbUnit.SelectedIndex = -1;
            this.cmbCategory.SelectedIndex = -1;
            this.dtpReleaseDate.Text = "";

            this.txtSearch.Text = "";

            this.dgvProduct.ClearSelection();
            this.AutoIdGenerate();
        }

        private void AutoIdGenerate()
        {
            var sql = "select max(ProductId) from ProductInfo;";
            DataTable dt = this.Da.ExecuteQueryTable(sql);
            var oldId = dt.Rows[0][0].ToString();
            var temp = oldId.Split('-');
            var num = Convert.ToInt32(temp[1]);
            var currentId = "P-" + (++num).ToString("d3");
            this.txtID.Text = currentId;
        }

        private void dgvProduct_DoubleClick(object sender, EventArgs e)
        {
            this.txtID.Text = this.dgvProduct.CurrentRow.Cells[0].Value.ToString();
            this.txtName.Text = this.dgvProduct.CurrentRow.Cells["ProductName"].Value.ToString();
            this.txtPrice.Text = this.dgvProduct.CurrentRow.Cells["ProductPrice"].Value.ToString();
            this.txtAvailability.Text = this.dgvProduct.CurrentRow.Cells[3].Value.ToString();
            this.cmbUnit.Text = this.dgvProduct.CurrentRow.Cells["ProductUnit"].Value.ToString();
            this.cmbCategory.Text = this.dgvProduct.CurrentRow.Cells["Category"].Value.ToString();
            this.dtpReleaseDate.Text = this.dgvProduct.CurrentRow.Cells[6].Value.ToString();
           

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the empty fields");
                    return;
                }

                // Check if the same ID already exists
                var query = "select * from ProductInfo where ProductId = '" + this.txtID.Text + "';";
                var ds = this.Da.ExecuteQuery(query);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show("A record with this ID already exists. Please use a unique ID.");
                    return;
                }

                // Insert new data
                var sql = "insert into ProductInfo (ProductId, ProductName, ProductPrice, ProductAvailabilty, ProductUnit, Category, ImportDate) " +
                          "values ('" + this.txtID.Text + "', '" + this.txtName.Text + "', " + this.txtPrice.Text +
                          ", '" + this.txtAvailability.Text + "', '" + this.cmbUnit.Text + "', '" + this.cmbCategory.Text + "'," +
                          " '" + this.dtpReleaseDate.Text + "');";

                var count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show("Data has been added to the list");
                else
                    MessageBox.Show("Data hasn't been added to the list");

                this.PopulateGridView();
                this.ClearAll();
            }

            catch (Exception exc)
            {
                MessageBox.Show("An error occurred while inserting data.\n" + exc.Message);
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the empty fields");
                    return;
                }

                // Check if the record exists
                var query = "select * from ProductInfo where ProductId = '" + this.txtID.Text + "';";
                var ds = this.Da.ExecuteQuery(query);

                if (ds.Tables[0].Rows.Count != 1)
                {
                    MessageBox.Show("Record not found with this ID.");
                    return;
                }

                // Update data
                var sql = @"update ProductInfo
                    set ProductName = '" + this.txtName.Text + @"',
                        ProductPrice = " + this.txtPrice.Text + @",
                        ProductAvailabilty = '" + this.txtAvailability.Text + @"',
                        ProductUnit = '" + this.cmbUnit.Text + @"',
                        Category = '" + this.cmbCategory.Text + @"',
                        ImportDate = '" + this.dtpReleaseDate.Text + @"'
                    where ProductId = '" + this.txtID.Text + "';";

                var count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show("Data has been updated successfully");
                else
                    MessageBox.Show("Data hasn't been updated");

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error occurred while updating data.\n" + exc.Message);
            }
        }

        private bool IsValidToSave()
        {
            if (string.IsNullOrEmpty(this.txtID.Text) || string.IsNullOrEmpty(this.txtName.Text) ||
                string.IsNullOrEmpty(this.txtPrice.Text) || string.IsNullOrEmpty(this.txtAvailability.Text) ||
                string.IsNullOrEmpty(this.cmbUnit.Text) || string.IsNullOrEmpty(this.cmbCategory.Text) ||
                string.IsNullOrEmpty(this.dtpReleaseDate.Text))
                return false;
            else
                return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvProduct.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                var id = this.dgvProduct.CurrentRow.Cells["ProductId"].Value.ToString();
                var name = this.dgvProduct.CurrentRow.Cells["ProductName"].Value.ToString();

                var result = MessageBox.Show("Are you sure to delete data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No)
                    return;

                var sql = "delete from ProductInfo where ProductId = '" + id + "';";
                var count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show(name.ToUpper() + " has been removed from the list");
                else
                    MessageBox.Show("Data hasn't been deleted from the list");

                this.PopulateGridView();
                this.ClearAll();
            }

            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred in the system, please try again.\n" + exc.Message);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Back to the Admin page");
            this.Hide();
            this.Fa.Show();
        }

        private void ProductInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("System terminating properly");
            Application.Exit();
        }
    }
}
