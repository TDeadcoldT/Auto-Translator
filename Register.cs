using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AutoTranslator
{
    public partial class Register : Form
    {
        string connectionString = @"Data Source = TDEADCOLDT\SQL2017; Initial Catalog = RegisterDB; Integrated Security=True;";
        public Register()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Please fill in important fields");
            else if (txtPassword.Text != txtConfirmPassword.Text)
                MessageBox.Show("Passwords do not match");
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Registration is complete");
                    Clear();
                }
            }
            void Clear()
            {
                txtFirstName.Text = txtSurname.Text = txtMobile.Text = txtEmail.Text = txtUsername.Text = txtPassword.Text = txtConfirmPassword.Text = "";
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            Login.Show();
            this.Hide();
        }
    }
}