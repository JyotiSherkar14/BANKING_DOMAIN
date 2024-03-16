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
    public partial class Form2 : Form
    {
        string ps = "",s;
        String cs = "", q,g;
        int c = 0;
        MySqlCommand cmd;
        MySqlConnection c1;
        int b=0;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("please enter account number");
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("please enter account name");
                textBox2.Focus();
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("please select account type");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("please enter account balance");
                textBox3.Focus();
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("please select gender");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("please enter pan card number");
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("please enter adhar card number");
                textBox5.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("please enter email");
                textBox6.Focus();
            }
            else if (!textBox6.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("please enter valid email");
                textBox6.Focus();
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("please enter address");
                textBox7.Focus();
            }
            
            else if (pictureBox1.Image == null)
            {
                MessageBox.Show("please upload photo & signature");
            }
            else
            {
                MessageBox.Show("all data enter");
            }
            c1.Open();
            try
            {
                q = "insert into registration values(@ac_no,@ac_name,@ac_type,@balance,@gender,@pan,@adhar,@email,@address,@rdate,@photo,@mobile,@status)";//parameterised querry
                cmd = new MySqlCommand(q, c1);
                cmd.Parameters.AddWithValue("@photo", ps);
                cmd.Parameters.AddWithValue("@ac_no", textBox1.Text);
                cmd.Parameters.AddWithValue("@ac_name", textBox2.Text);
                cmd.Parameters.AddWithValue("@ac_type",comboBox1.Text);
                cmd.Parameters.AddWithValue("@pan", textBox4.Text);
                cmd.Parameters.AddWithValue("@balance", textBox3.Text);
                cmd.Parameters.AddWithValue("@adhar", textBox5.Text);
                cmd.Parameters.AddWithValue("@email", textBox6.Text);
                cmd.Parameters.AddWithValue("@address", textBox7.Text);
                cmd.Parameters.AddWithValue("@rdate", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@mobile", textBox8.Text);
                cmd.Parameters.AddWithValue("@status","Active");
                cmd.Parameters.AddWithValue("@gender", g);
               
                int r = cmd.ExecuteNonQuery(); 
                if (r > 0)
                    MessageBox.Show("user created successfully");
                else
                    MessageBox.Show("user created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("exception" + ex);
            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
                loadID();
                clearall();
               
            }
            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cs = "server=localhost; database = bank; uid = root ; pwd=root";
            c1 = new MySqlConnection(cs);
           // MessageBox.Show("DATABASE CONNECTED SUCCESSFULLY");
          
            loadID();
           
        }
        void loadID()
        {
            c1.Open();
            try
            {
                q = "select max(ac_no) from registration";
                cmd = new MySqlCommand(q, c1);
                int u = Convert.ToInt32(cmd.ExecuteScalar());
                textBox1.Text = (u + 1).ToString();
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("exception " + ex);
                textBox1.Text = "1";

            }
            finally
            {
                if (c1.State == ConnectionState.Open)
                    c1.Close();
                textBox2.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           clearall();
        }
        void clearall()
        {
            pictureBox1.Image = null;
            //textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            comboBox1.SelectedIndex = -1 ;
            button1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog a1 = new OpenFileDialog();
            a1.Filter = "IMAGE FILES(*.jpeg;*.jpg;*.png)|*.jpeg;*.jpg;*.png";
            if (a1.ShowDialog() == DialogResult.OK) 
            {
                pictureBox1.Image = new Bitmap(a1.FileName);
                ps= a1.FileName;
                button1.Visible = true;
                MessageBox.Show("IMAGE LOCATION" + ps);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text =="SAVING")
            {
                b = 500;
                textBox3.Text = b.ToString();
             
                
                
                
            }
            else if (comboBox1.Text == "CURRENT")
            {
                b = 5000;
                textBox3.Text = b.ToString();
             
               

            }
            else if (comboBox1.Text == "STUDENT")
            {
                b = 00;
                textBox3.Text = b.ToString();
              
               

            }
                
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "SAVING")
            {
                b = 500;
                textBox3.Text = b.ToString();
                



            }
            else if (comboBox1.Text == "CURRENT")
            {
                b = 5000;
                textBox3.Text = b.ToString();
                


            }
            else if (comboBox1.Text == "STUDENT")
            {
                b = 00;


                textBox3.Text = b.ToString();
              
            }
          
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                g = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                g = radioButton2.Text;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                g = radioButton3.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
