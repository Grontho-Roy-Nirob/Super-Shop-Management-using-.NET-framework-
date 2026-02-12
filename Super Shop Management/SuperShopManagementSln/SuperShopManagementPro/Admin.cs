using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SuperShopManagementPro
{
    public partial class Admin: Form
    {
        public Login Fl { get; set; }

        public Admin()
        {
            InitializeComponent();
        }

        public Admin(string nameInfo,Login fl) : this()
        {
            this.lblInfo.Text += nameInfo.ToUpper();
            this.Fl = fl;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged out from system");
            this.Hide();
            this.Fl.Show();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new ProductInformation(this).Visible = true;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new UserInformation(this).Visible = true;
        }

        private void btnVisit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new SalesInformation(this).Visible = true;
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("System terminating properly");
            Application.Exit();
        }

       
    }
}
