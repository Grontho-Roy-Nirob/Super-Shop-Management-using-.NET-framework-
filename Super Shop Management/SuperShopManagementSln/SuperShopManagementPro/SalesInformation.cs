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
    public partial class SalesInformation: Form
    {

        public DataAccess Da { get; set; }
        public Admin Fi { get; set; }
        public SalesInformation()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            this.PopulateGridView();
        }

        public SalesInformation(Admin fi) : this()
        {
            this.Fi = fi;
        }

        private void PopulateGridView(string sql = "select s.SalesId, s.ID, s.ProductNames,s.Price, s.Quantity, s.TotalPrice,s.Date ,u.branch,s.paymentMethod\r\nfrom SalesTable s, UserInfo u\r\nWhere s.ID = u.ID;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvSalesInformation.AutoGenerateColumns = false;
            this.dgvSalesInformation.DataSource = ds.Tables[0];
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        

        private void btnSalemanId_Click(object sender, EventArgs e)
        {
            string sql = "SELECT s.SalesId, s.ID, s.ProductNames, s.Price, s.Quantity, s.TotalPrice, s.Date, u.branch, s.paymentMethod " +
                 "FROM SalesTable s, UserInfo u " +
                 "WHERE s.ID = u.ID";


            if (!string.IsNullOrWhiteSpace(txtSearchSalesmanId.Text))
            {
                sql += " AND s.ID = '" + txtSearchSalesmanId.Text + "'";
            }

            if (!string.IsNullOrWhiteSpace(txtSearchBranch.Text))
            {
                sql += " AND u.branch = '" + txtSearchBranch.Text + "'";
            }

            if (cbCheck.Checked) // only if user selects a date
            {
                string selectedDate = dtpSearchSaleDate.Value.ToString("yyyy-MM-dd");
                sql += " AND CAST(s.Date AS DATE) = '" + selectedDate + "'";
            }

            this.PopulateGridView(sql);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Back to the Admin page");
            this.Hide();
            this.Fi.Show();
        }

        private void SalesInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void ClearAll()
        {
            this.txtSearchBranch.Clear();
            this.txtSearchSalesmanId.Clear();
            this.dtpSearchSaleDate.Text = "";
        }
    }
}
