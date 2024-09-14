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

namespace Library_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string classification;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnregister_Click(object sender, EventArgs e)
        {

            string dbpath;
            dbpath = "Data Source=DESKTOP-M9CSU4V;Initial Catalog=LMS;Integrated Security=True;Trust Server Certificate=True";
            if (rdbborrow.Checked == true) 
            {
                classification = "Borrow";
            }
            if (rdbref.Checked == true)
            {
                classification = "Reference";
            }
            SqlConnection connect = new SqlConnection(dbpath);  
            connect.Open();
            SqlCommand register = new SqlCommand("insert into Bookinfo values('"+txtid.Text+"','"+txtname.Text+"','"+txttitle.Text+"'," + "'"+txtauther.Text+"',"+txtpages.Text+"')",connect);

            connect.Close();
        }
    }
}
