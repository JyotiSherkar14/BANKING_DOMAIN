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
    public partial class Form4 : Form
    {

        string ps = "", s;
        String cs = "", q, g;
        int c = 0;
        MySqlCommand cmd;
        MySqlConnection c1;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            cs = "server=localhost; database = bank; uid = root ; pwd=root";
            c1 = new MySqlConnection(cs);
            MessageBox.Show("DATABASE CONNECTED SUCCESSFULLY");
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "select status from registration where ac_no="+textBox1.Text   ;
                cmd = new MySqlCommand(q, c1);
                String i = Convert.ToString(cmd.ExecuteScalar());
                if (i == "Active")
                {
                    q = "update registration set status='Deactive' where ac_no=" + textBox1.Text;
                    cmd = new MySqlCommand(q, c1);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                        MessageBox.Show("Account Deactivated Successfully");
                    else
                        MessageBox.Show("Failed to Deactivate Account");
                }
                else
                    MessageBox.Show("Your Account Is Already Deactive");
            }
            catch (Exception ex)
            {
                MessageBox.Show("exception " + ex);
            
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
             
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "select status from registration where ac_no="+textBox1.Text;
                cmd = new MySqlCommand(q, c1);
                String i = Convert.ToString(cmd.ExecuteScalar());
                if (i == "Deactive")
                {
                    q = "update  registration set status='Active' where ac_no=" + textBox1.Text;
                    cmd = new MySqlCommand(q, c1);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                        MessageBox.Show("Account activated Successfully");
                    else
                        MessageBox.Show("Failed to activate Account");
                }

                else
                    MessageBox.Show("Your Account Is Already Active");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("exception " + ex);
            
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
             
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
