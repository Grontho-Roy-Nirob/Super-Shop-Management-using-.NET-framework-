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
    public partial class Member: Form
    {
        public Login Fl { get; set; }
       // public string UserName { get; set; }
        public string Id { get; set; }

        public Member()
        {
            InitializeComponent();
        }

        public Member(string nameInfo, string id, Login fl) : this()
        {
           // this.UserName = nameInfo;
            this.Id = id;
            this.lblInfo.Text += nameInfo.ToUpper();
            this.Fl = fl;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged out from system");
            this.Hide();
            this.Fl.Show();
        }

        private void Member_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MessageBox.Show("Logged out from system");
            this.Fl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged out from system");
            this.Hide();
            this.Fl.Show();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new SalesTerminal(Id,this).Visible = true;
        }

        private void btnVisit_Click(object sender, EventArgs e)
        {
            try
            {
                UserProfile profilePage = new UserProfile(Id, this);
                profilePage.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
