using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperShopManagementPro
{
    public partial class Login: Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = "select * from UserInfo where id  = '" + this.txtUserId.Text + "' and Password = '" + this.txtPassword.Text + "';";
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4S3SF4H\SQLEXPRESS;Initial Catalog=ShopUserDB;User ID=sa;Password=4407;Encrypt=False");
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var name = ds.Tables[0].Rows[0][1].ToString();
                var id = ds.Tables[0].Rows[0][0].ToString();
                MessageBox.Show("Valid User");
                this.Visible = false;

                if (ds.Tables[0].Rows[0][8].ToString().Equals("Admin"))
                {
                    new Admin(name, this).Visible = true;
                }
                else if (ds.Tables[0].Rows[0][8].ToString().Equals("Salesman"))
                {
                    new Member(name,id,this).Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Invalid User");
            }

            sqlcon.Close();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUserId.Text = "";
            this.txtPassword.Clear();
        }
    }
}
