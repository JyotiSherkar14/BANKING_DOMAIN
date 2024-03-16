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
    public partial class Form1 : Form
    {
        String cs = "", q, p, n;
        int c = 0;
        MySqlCommand cmd;
        MySqlConnection c1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == 1)
            {
                MessageBox.Show("password already created you can update password");

            }
            else
            {
                p = textBox1.Text;
                if (textBox1.Text == "")
                {
                    MessageBox.Show("please enter password od minimum 6 length");
                    textBox1.Focus();
                }
                else if (p.Contains(" "))
                {
                    MessageBox.Show("space not allowed");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else if (p.Length < 6)
                {
                    MessageBox.Show("minimum 6 charactar required ");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    c1.Open();
                    try
                    {
                        q = "insert into login values('" + textBox1.Text + "')";
                        cmd = new MySqlCommand(q, c1);
                        int r = cmd.ExecuteNonQuery();
                        MessageBox.Show("valid password");
                        if (r > 0)
                        {
                            MessageBox.Show("PASSWORD CREATED SUCCESSFULLY:");
                            c++;
                            textBox1.Text = "";

                        }
                        else
                        {
                            MessageBox.Show("PASSWORD NOT CREATED:");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("exception" + ex);

                    }
                    finally
                    {
                        if (c1.State == ConnectionState.Open)
                            c1.Close();
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            c1.Open();
            try
            {
                q = "select pwd from login";
                cmd = new MySqlCommand(q, c1);
                string r = cmd.ExecuteScalar().ToString();
                if (r.Equals(textBox1.Text))
                {
                    MessageBox.Show("LOGIN SUCCESSFULLY");
                    Form6 f6 = new Form6();
                    f6.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("invalid password");
                    textBox1.Text = "";
                    textBox1.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("exception");
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cs = "server=localhost; database = bank; uid = root ; pwd=root";
            c1 = new MySqlConnection(cs);
            MessageBox.Show("DATABASE CONNECTED SUCCESSFULLY");
            c1.Open();
            try
            {
                q = "Select count(pwd) from login";
                cmd = new MySqlCommand(q, c1);
                c = Convert.ToInt32(cmd.ExecuteScalar());
                MessageBox.Show("no of password records:" + c);
            }
            catch (Exception ex)
            {
                MessageBox.Show("exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
        }
    }
}
