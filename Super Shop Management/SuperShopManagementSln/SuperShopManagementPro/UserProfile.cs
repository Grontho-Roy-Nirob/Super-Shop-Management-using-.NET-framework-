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
    public partial class UserProfile: Form
    {
        private string userId;
        public DataAccess Da { get; set; }
        public Member Fp { get; set; }

        public UserProfile(string id, Member fp) 
        {
            InitializeComponent();
            this.userId = id;
            this.Fp = fp;       
            this.Da = new DataAccess();
            LoadProfileData();
        }

        

        private void LoadProfileData()
        {
            string sql = $"SELECT * FROM UserInfo WHERE ID = '{this.userId}'";
            var ds = Da.ExecuteQuery(sql);

            if (ds.Tables[0].Rows.Count == 1)
            {
                var row = ds.Tables[0].Rows[0];

                txtName.Text = row["Name"].ToString();
                txtID.Text = row["ID"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtPhone.Text = row["Phone"].ToString();
                txtBranch.Text = row["Branch"].ToString();
                
            }
            else
            {
                MessageBox.Show("User not found.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Back to the Member page");
            this.Hide();
            this.Fp.Show();
        }

        private void UserProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtPhone.ReadOnly = false;
            txtBranch.ReadOnly = false;

            btnUpdate.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string branch = txtBranch.Text.Trim();

            string sql = $"UPDATE UserInfo SET Name = '{name}', Email = '{email}', Phone = '{phone}', Branch = '{branch}' WHERE ID = '{this.userId}'";

            try
            {
                int result = this.Da.ExecuteDMLQuery(sql);

                if (result == 1)
                {
                    MessageBox.Show("Profile updated successfully!");

                    txtName.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    txtBranch.ReadOnly = true;
                    btnUpdate.Visible = false;
                }
                else
                {
                    MessageBox.Show("No changes were made.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

}

