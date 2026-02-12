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
    public partial class UserInformation : Form
    {
        private string previousRole = "";
        private string previousId = "";
        private bool isLoadingFromGrid = false;

        public Admin Fu { get; set; }
        public DataAccess Da { get; set; }

        public UserInformation()
        {
            InitializeComponent();
            this.Da = new DataAccess();

            // Wire up the event handler
            this.cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;

            this.PopulateGridView();
        }

        public UserInformation(Admin fu) : this()
        {
            this.Fu = fu;
        }

        private void UserInformation_Load(object sender, EventArgs e)
        {
            this.dgvUser.ClearSelection();

            //this.cmbGender.Items.Clear();
            // Disable txtID initially when form loads
            this.txtID.Enabled = false;
        }

        private void PopulateGridView(string sql = "SELECT * FROM UserInfo;")
        {
            var ds = this.Da.ExecuteQuery(sql);
            this.dgvUser.AutoGenerateColumns = false;
            this.dgvUser.DataSource = ds.Tables[0];
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM UserInfo WHERE Name = '" + this.txtSearch.Text + "';";
            this.PopulateGridView(sql);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void ClearAll()
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.cmbGender.SelectedIndex = -1;
            this.txtEmail.Clear();
            this.txtPhone.Clear();
            this.txtSalary.Clear();
            this.txtPassword.Clear();
            this.txtBranch.Clear();
            this.cmbRole.SelectedIndex = -1;
            this.txtSearch.Clear();
            this.dgvUser.ClearSelection();

            // Disable ID textbox on clear as well
            this.txtID.Enabled = false;
        }

        private void AutoIdGenerate()
        {
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select a role first (Admin or Salesman).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = cmbRole.SelectedItem.ToString();
            string prefix = role == "Admin" ? "A-" : "S-";
            string sql = $"SELECT MAX(ID) FROM UserInfo WHERE ID LIKE '{prefix}%';";

            DataTable dt = this.Da.ExecuteQueryTable(sql);
            string lastId = dt.Rows[0][0]?.ToString();
            int newNumber = 1;

            if (!string.IsNullOrEmpty(lastId))
            {
                string numericPart = lastId.Replace(prefix, "");
                if (int.TryParse(numericPart, out int lastNumber))
                {
                    newNumber = lastNumber + 1;
                }
            }

            string newId = prefix + newNumber.ToString("d3");
            this.txtID.Text = newId;
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingFromGrid)
                return;

            if (cmbRole.SelectedIndex >= 0)
            {
                string selectedRole = cmbRole.SelectedItem.ToString();

                if (selectedRole == previousRole)
                {
                    // If user switched back to original role, restore previous ID
                    this.txtID.Text = previousId;
                }
                else
                {
                    // Generate new ID for new role
                    this.txtID.Enabled = true;
                    AutoIdGenerate();
                }
            }
            else
            {
                txtID.Enabled = false;
                txtID.Clear();
            }
        }

        private void dgvUser_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvUser.CurrentRow != null)
            {
                isLoadingFromGrid = true;

                this.txtID.Text = this.dgvUser.CurrentRow.Cells[0].Value.ToString();
                this.txtName.Text = this.dgvUser.CurrentRow.Cells["Name"].Value.ToString();
              
                string genderValue = this.dgvUser.CurrentRow.Cells["Gender"].Value.ToString().Trim();
                if (genderValue.Equals("Male", StringComparison.OrdinalIgnoreCase))
                    this.cmbGender.SelectedItem = "Male";
                else if (genderValue.Equals("Female", StringComparison.OrdinalIgnoreCase))
                    this.cmbGender.SelectedItem = "Female";
                else
                    this.cmbGender.SelectedIndex = -1;

                this.txtEmail.Text = this.dgvUser.CurrentRow.Cells["Email"].Value.ToString();
                this.txtPhone.Text = this.dgvUser.CurrentRow.Cells["Phone"].Value.ToString();
                this.txtSalary.Text = this.dgvUser.CurrentRow.Cells["Salary"].Value.ToString();
                this.txtPassword.Text = this.dgvUser.CurrentRow.Cells["Password"].Value.ToString();
                this.txtBranch.Text = this.dgvUser.CurrentRow.Cells["Branch"].Value.ToString();
                this.cmbRole.Text = this.dgvUser.CurrentRow.Cells["Role"].Value.ToString();

                // Save previous ID and Role
                this.previousId = this.txtID.Text;
                this.previousRole = this.cmbRole.Text;

                this.txtID.Enabled = false;

                isLoadingFromGrid = false;
            }
        }

        private bool IsValidToSave()
        {
            if (string.IsNullOrEmpty(this.txtID.Text) || string.IsNullOrEmpty(this.txtName.Text) ||
                string.IsNullOrEmpty(this.cmbGender.Text) || string.IsNullOrEmpty(this.txtEmail.Text) ||
                string.IsNullOrEmpty(this.txtPhone.Text) || string.IsNullOrEmpty(this.txtSalary.Text) ||
                string.IsNullOrEmpty(this.txtPassword.Text) || string.IsNullOrEmpty(this.txtBranch.Text) ||
                string.IsNullOrEmpty(this.cmbRole.Text))
                return false;
            else
                return true;
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
                var query = "SELECT * FROM UserInfo WHERE ID = '" + this.txtID.Text + "';";
                var ds = this.Da.ExecuteQuery(query);

                if (ds.Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show("A user with this ID already exists. Please select a different role or re-open the form to generate a new ID.");
                    return;
                }

                // Insert new user
                var sql = "INSERT INTO UserInfo (ID, Name, Gender, Email, Phone, Salary, Password, Branch, Role) " +
                          "VALUES ('" + this.txtID.Text + "', '" + this.txtName.Text + "', '" + this.cmbGender.Text + "', " +
                          "'" + this.txtEmail.Text + "', '" + this.txtPhone.Text + "', " + this.txtSalary.Text + ", '" +
                          this.txtPassword.Text + "', '" + this.txtBranch.Text + "', '" + this.cmbRole.Text + "');";

                var count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show("User has been added successfully.");
                else
                    MessageBox.Show("Failed to add user.");

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting the user.\n" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if all fields are valid
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ensure the ID exists before attempting update
                string id = this.txtID.Text;
                string checkQuery = $"SELECT * FROM UserInfo WHERE ID = '{id}';";
                var ds = this.Da.ExecuteQuery(checkQuery);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("No user found with this ID. Please select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Confirm update from user
                var confirmResult = MessageBox.Show($"Are you sure you want to update user with ID: {id}?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.No)
                    return;

                // Build the SQL update query
                string sql = $@"
            UPDATE UserInfo
            SET Name = '{this.txtName.Text}',
                Gender = '{this.cmbGender.Text}',
                Email = '{this.txtEmail.Text}',
                Phone = '{this.txtPhone.Text}',
                Salary = {this.txtSalary.Text},
                Password = '{this.txtPassword.Text}',
                Branch = '{this.txtBranch.Text}',
                Role = '{this.cmbRole.Text}'
            WHERE ID = '{id}';
        ";

                // Execute the update
                int count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show("User has been updated successfully.");
                else
                    MessageBox.Show("Update failed. No rows were affected.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the user.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUser.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = this.dgvUser.CurrentRow.Cells["ID"].Value.ToString();
                var name = this.dgvUser.CurrentRow.Cells["Name"].Value.ToString();

                var result = MessageBox.Show($"Are you sure you want to delete {name} (ID: {id})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                var sql = "DELETE FROM UserInfo WHERE ID = '" + id + "';";
                var count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show($"{name.ToUpper()} has been removed from the system.");
                else
                    MessageBox.Show("Deletion failed. Please try again.");

                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the user.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Back to the Admin page");
            this.Hide();
            this.Fu.Show();
        }

        private void UserInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("System terminating properly");
            Application.Exit();
        }
    }
}
