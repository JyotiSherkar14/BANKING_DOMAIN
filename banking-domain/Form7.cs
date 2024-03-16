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
    public partial class Form7 : Form
    {
        string cs = "",q;
        MySqlCommand cmd;
        MySqlConnection c1;
        MySqlDataReader d;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            cs = "server=localhost;database=bank;Uid=root;pwd=root";
            c1 = new MySqlConnection(cs);
            MessageBox.Show("DATABASE CONNECTIVITY SUCCESSFUL");
            
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
                MessageBox.Show("Please Enter Account Number");
            
            c1.Open();
            try
            {
                q = "select * from registration where ac_no=" + textBox1.Text;
                cmd = new MySqlCommand(q, c1);
                d = cmd.ExecuteReader();
                if(d.Read())
                {
                    textBox2.Text = d["ac_name"].ToString();
                    textBox3.Text = d["ac_type"].ToString();
                    textBox4.Text = d["status"].ToString();
                    textBox5.Text = d["balance"].ToString();
                    textBox6.Text = d["gender"].ToString();
                    textBox7.Text = d["mobile"].ToString();
                    textBox8.Text = d["pan"].ToString();
                    textBox9.Text = d["adhar"].ToString();
                    textBox10.Text = d["email"].ToString();
                    textBox11.Text = d["address"].ToString();
                    textBox12.Text = d["rdate"].ToString();
                    pictureBox1.Image = new Bitmap(d["photo"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            pictureBox1.Image = null;
        }
    }
}
