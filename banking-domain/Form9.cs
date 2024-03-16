using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace banking_domain
{
    public partial class Form9 : Form
    {
        string cs = "", q;
        MySqlDataAdapter da;
        DataTable t;
        MySqlConnection c1;
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=bank;Uid=root;pwd=root";
            c1 = new MySqlConnection(cs);

            MessageBox.Show("DATABASE CONNECTIVITY SUCCESSFUL");
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }   

        private void button1_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "select * from transaction where ac_no=" + textBox1.Text;
                da = new MySqlDataAdapter(q, c1);
                t = new DataTable();
                da.Fill(t);
                dataGridView1.DataSource = t;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
        }
        
    }
}
