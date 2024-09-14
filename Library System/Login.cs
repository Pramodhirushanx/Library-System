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

namespace Library_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-M9CSU4V; Initial catalog=BookSystem; Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
     

        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters
                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = textBox2.Text;

                // Use SqlDataReader to read result set
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // You can read each column from the reader here
                            string username = dr["username"].ToString();
                            // Other columns...

                            MessageBox.Show("Login Success");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
