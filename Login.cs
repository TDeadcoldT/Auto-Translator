using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace AutoTranslator
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection();
        public Login()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Data Source=TDEADCOLDT\\SQL2017;Initial Catalog=RegisterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ("Data Source=TDEADCOLDT\\SQL2017;Initial Catalog=RegisterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            {
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=TDEADCOLDT\\SQL2017;Initial Catalog=RegisterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con.Open();
            string Username = txtUsername.Text;
            string Password = txtPassword.Text;
            SqlCommand cmd = new SqlCommand("select Username, Password from tblUser where Username='" + txtUsername.Text + "'and Password='" + txtPassword.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Welcome");
                Translator Translator = new Translator();
                Translator.Show();
            }
            else
            {
                MessageBox.Show("Access denied");
            }
            con.Close();


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register Register = new Register();
            Register.Show();
        }
    }
}