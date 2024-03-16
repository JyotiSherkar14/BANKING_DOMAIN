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
    public partial class Form8 : Form
    {
        string cs = "",q;
        MySqlDataAdapter da;
        DataTable t;
        MySqlConnection c1;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=bank;Uid=root;pwd=root";
            c1 = new MySqlConnection(cs);
           
            MessageBox.Show("DATABASE CONNECTIVITY SUCCESSFUL");
            c1.Open();
         
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    q = "select * from transaction where type='Deposit' ";
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
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    q = "select * from transaction where type='Withdraw' ";
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
            else if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    q = "select * from transaction";
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
}
