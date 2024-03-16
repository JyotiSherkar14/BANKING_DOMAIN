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
    public partial class Form3 : Form
    {
        String cs = "", q;
        MySqlCommand cmd;
        MySqlConnection c1;
        MySqlDataReader d;
        float t2=0, t3=0, t5=0;
        public Form3()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
         
        }
        void clearall()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox5.Text = "";
            textBox6.Text = "";
            
        }
        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cs = "server=localhost; database = bank; uid = root ; pwd=root";
            c1 = new MySqlConnection(cs);
          //  MessageBox.Show("DATABASE CONNECTED SUCCESSFULLY");
            
            loadID();
           
        }
        void loadID()
        {
            c1.Open();
            try
            {
                q = "select max(tid) from transaction";
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

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBox1.SelectedIndex==0)
            {
                t2 = Convert.ToSingle(textBox2.Text);
                c1.Open();
                try
                {
                 
                    //t2 = Convert.ToSingle(textBox2.Text);
                    //t3 = Convert.ToSingle(textBox2.Text);
                    
                    t5 = t3 + t2;
                    textBox2.Text = t2.ToString();
                    textBox3.Text = t3.ToString();
                    textBox5.Text = t5.ToString();
                    q = "update registration set balance=" + textBox5.Text + " where ac_no=" + textBox4.Text;
                    cmd = new MySqlCommand(q, c1);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Amount deposited  Successfully");
                        q = "insert into transaction values(@tid,@tdate,@ac_no,@type,@amt,@tamt)";
                        cmd = new MySqlCommand(q, c1);
                        cmd.Parameters.AddWithValue("@tid", textBox1.Text);
                        cmd.Parameters.AddWithValue("@tdate", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@ac_no", textBox4.Text);
                        cmd.Parameters.AddWithValue("@type", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@amt", textBox2.Text);
                        cmd.Parameters.AddWithValue("@tamt", textBox5.Text);
                        //button2.Visible = true;
                         i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            MessageBox.Show("Transaction Successful");
                        else
                            MessageBox.Show("Transaction Fail");
                
                    }
                    else
                        MessageBox.Show("Falied to Deposit Amount");                     
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("exception " + ex);
                }
                finally
                {
                    if (c1.State == ConnectionState.Open)
                        c1.Close();
                    clearall();
                    loadID();


                }
            }
            else if (comboBox1 .SelectedIndex ==1)
            {
                t2 = Convert.ToSingle(textBox2.Text);
                c1.Open();
                try
                {
                        //t2 = Convert.ToSingle(textBox2.Text);
                        //t3 = Convert.ToSingle(textBox2.Text);
                        if (t2 > t3)
                            MessageBox.Show("Insufficient Balance");
                        else
                        {
                            t5 = t3 - t2;
                           // textBox2.Text = t2.ToString();
                            //textBox3.Text = t3.ToString();
                            textBox5.Text = t5.ToString();



                            q = "update registration set balance=" + textBox5.Text + " where ac_no=" + textBox4.Text;
                            cmd = new MySqlCommand(q, c1);
                            float i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Amount Withdrawl  Successfully");
                                q = "insert into transaction values(@tid,@tdate,@ac_no,@type,@amt,@tamt)";
                                cmd = new MySqlCommand(q, c1);
                                cmd.Parameters.AddWithValue("@tid", textBox1.Text);
                                cmd.Parameters.AddWithValue("@tdate", dateTimePicker1.Value.Date);
                                cmd.Parameters.AddWithValue("@ac_no", textBox4.Text);
                                cmd.Parameters.AddWithValue("@type", comboBox1.Text);
                                cmd.Parameters.AddWithValue("@amt", textBox2.Text);
                                cmd.Parameters.AddWithValue("@tamt", textBox5.Text);
                                //button2.Visible = true;
                                 i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                    MessageBox.Show("Transaction Successful");
                                else
                                    MessageBox.Show("Transaction Fail");
                
                            }
                            else
                                MessageBox.Show("Falied to Withdraw Amount");
                        }
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("exception " + ex);
                }
                finally
                {
                    if (c1.State == ConnectionState.Open)
                        c1.Close();
                    clearall();
                    loadID();
                 

                }
                    
            }
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox4.Text == "")
             {
                    MessageBox.Show("Enter Account Number");

                    textBox4.Focus();
             }

            c1.Open();
            try
            {
               
                 int n = Convert.ToInt32(textBox4.Text);
                 q = "select balance from registration where ac_no=" + n;
                 cmd = new MySqlCommand(q, c1);
                 t3 = Convert.ToSingle(cmd.ExecuteScalar());
               //  MessageBox.Show("Avail Bal = " + t3);
                 textBox3.Text = t3.ToString();
                //d = cmd.ExecuteReader();
                // if (d.Read())
                // {
                //     textBox3.Text = d["balance"].ToString();
                // }
                // else
                // {
                //     MessageBox.Show("Invalid Account Number");
                //     textBox4.Text = "";
                //     textBox4.Focus();
                // }
                
                
                
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
            c1.Open();
            try
            {
                q = "select status from registration where ac_no="+textBox4.Text;
                cmd = new MySqlCommand(q, c1);
                String i = Convert.ToString(cmd.ExecuteScalar());
                textBox6.Text = i.ToString();
                if (i == "Deactive")
                {
                    MessageBox.Show("Your Account is Deactivated\nYou can't Deposit or Withdraw Amount");
                    clearall();

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
            if (textBox2.Text =="")
            {
                MessageBox.Show("Enter Transaction Amount");
                textBox3.Focus();

            }

            c1.Open();
            try
            {
                q = "insert into transaction values(@tid,@tdate,@ac_no,@type,@amt,@tamt)";
                cmd = new MySqlCommand(q, c1);
                cmd.Parameters.AddWithValue("@tid", textBox1.Text);
                cmd.Parameters.AddWithValue("@tdate",dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@ac_no", textBox4.Text);
                cmd.Parameters.AddWithValue("@type ", comboBox1.Text);
                cmd.Parameters.AddWithValue("@amt", textBox2.Text);
                cmd.Parameters.AddWithValue("@tamt", textBox5.Text);
              //  button2.Visible = true;
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Transaction Successful");
                else
                    MessageBox.Show("Transaction Fail");
                
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          


        }
       
    }
}
