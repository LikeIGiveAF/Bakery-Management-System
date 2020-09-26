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

namespace Bakery_Management_System
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.Show();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

       /* private void button2_Click_1(object sender, EventArgs e)
        {
            if (!ContentPannel.Controls.Contains(Cookies__UserControl.Instance))
            {
                ContentPannel.Controls.Add(Cookies__UserControl.Instance);
                Cookies__UserControl.Instance.Dock = DockStyle.Fill;
                Cookies__UserControl.Instance.BringToFront();
            }
            else
            {
                Cookies__UserControl.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ContentPannel.Controls.Contains(Breads_UserControl.Instance))
            {
                ContentPannel.Controls.Add(Breads_UserControl.Instance);
                Breads_UserControl.Instance.Dock = DockStyle.Fill;
                Breads_UserControl.Instance.BringToFront();
            }
            else
            {
                Breads_UserControl.Instance.BringToFront();
            }
        }*/

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\"; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private Boolean checkusername(String uname)
        {
            //checking if username entered is present in database.
            con.Open();
            String syntax = "SELECT COUNT(USERNAME) FROM CUSTOMER WHERE USERNAME='" + uname + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = dr[0].ToString();
            con.Close();
            if (temp.Equals("1"))
                return true;
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String items = "";
            foreach (Control c in groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox b = (CheckBox)c;
                    if (b.Checked)
                    {
                        items = b.Text + "\n" + items;
                        con.Open();
                       
                        String syntax = "SELECT TOTAL_AMOUNT+(SELECT ITEM_PRICE FROM ITEM WHERE ITEM_NAME='" + b.Text + "') FROM ORDER_DETAILS WHERE USERNAME='"+ textBox1.Text + "'";
                        SqlCommand cmd1;                
                        cmd1 = new SqlCommand(syntax, con);
                        dr = cmd1.ExecuteReader();
                        dr.Read();
                        String temp = dr[0].ToString();

                        con.Close();

                        con.Open();
                        SqlCommand cmd = new SqlCommand("Money_SP", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TOTAL_AMOUNT  ", temp);

                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Invalid SQL Operation\n" + ex);
                        }

                        con.Close();
                    }
                }
                
            }


          //  MessageBox.Show(items);

            if(textBox1.Text.Equals(""))
            {
                label9.Show();
            } 
            else
            {
                label9.Hide();
                if (checkusername(textBox1.Text))
                {
                    if (!items.Equals(""))
                    {
                        label8.Hide();

                        con.Open();
                        /*String syntax = "UPDATE ORDER_DETAILS SET ITEM_NAMES='" + items + "'  WHERE USERNAME ='" + textBox1.Text + "'";
                        cmd = new SqlCommand(syntax, con);
                        */
                        SqlCommand cmd = new SqlCommand("UpdateOrder", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ITEM_NAMES", items);
                        cmd.Parameters.AddWithValue("@USERNAME", textBox1.Text);

                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Invalid SQL Operation\n" + ex);
                        }

                        con.Close();

                        Random ran = new Random();
                        int staffId = ran.Next(1, 3);

                        con.Open();
                        String syntax = "SELECT ORDER_NO FROM ORDER_DETAILS WHERE USERNAME='" + textBox1.Text + "'";
                        cmd = new SqlCommand(syntax, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        String temp = dr[0].ToString();
                        con.Close();

                        cmd = new SqlCommand("AddDelivery", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ORDER_NO", temp);
                        cmd.Parameters.AddWithValue("@STAFF_ID", staffId);
                        con.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Invalid SQL Operation\n" + ex);
                        }

                        con.Close();

                        button3.Show();
                        
                        /* HomePage obj = new HomePage();
                         PaymentPage pay = new PaymentPage();
                         this.Hide();
                         obj.Hide();
                         pay.Show();*/

                    }
                    else
                    {
                        label8.Show();

                    }
                }
                else
                {
                    label9.Show();
                }


            }


            /*  if (textBox1.Text.Equals(""))
              {
                  label9.Show();

              }
              else {
                  label9.Hide();
              }*/


            /* OrderPage obj = new OrderPage();
             this.Hide();
             obj.Show();*/
            label10.Show();
        }

       /* private void cakes_Click(object sender, EventArgs e)
        {
            if(!ContentPannel.Controls.Contains(Cakes_UserControl.Instance))
            {
                ContentPannel.Controls.Add(Cakes_UserControl.Instance);
                Cakes_UserControl.Instance.Dock = DockStyle.Fill;
                Cakes_UserControl.Instance.BringToFront();
            }
            else
            {
                Cakes_UserControl.Instance.BringToFront();
            }
        }

        private void donuts_Click(object sender, EventArgs e)
        {
            if (!ContentPannel.Controls.Contains(Donuts_UserControl.Instance))
            {
                ContentPannel.Controls.Add(Donuts_UserControl.Instance);
                Donuts_UserControl.Instance.Dock = DockStyle.Fill;
                Donuts_UserControl.Instance.BringToFront();
            }
            else
            {
                Donuts_UserControl.Instance.BringToFront();
            }
        }

        private void others_Click(object sender, EventArgs e)
        {
            if (!ContentPannel.Controls.Contains(Others_UserControl.Instance))
            {
                ContentPannel.Controls.Add(Others_UserControl.Instance);
                Others_UserControl.Instance.Dock = DockStyle.Fill;
                Others_UserControl.Instance.BringToFront();
            }
            else
            {
                Others_UserControl.Instance.BringToFront();
            }
        }*/

        private void ContentPannel_Paint(object sender, PaintEventArgs e)
        {
        }
/*
        private void button4_Click_1(object sender, EventArgs e)
        {
            Cakes_UserControl ck = new Cakes_UserControl();
            ck.label;
        }*/

        private void checkBox32_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           /* label10.Show();
            label11.Show();
            label12.Show();
            label13.Show();
            label14.Show();*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\"; Integrated Security=True");
            SqlCommand cmd;
            SqlDataReader dr;
             label12.Show();
            con.Open();
            String syntax = "SELECT ITEM_NAMES FROM ORDER_DETAILS WHERE USERNAME='" + textBox1.Text + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = dr[0].ToString();
            
            con.Close();
            label12.Text = temp;

            label10.Show();
            label11.Show();
           
            label13.Show();
            label14.Show();
           */

            dataGridView1.Show();
            button2.Show();
            refresh_DataGridView();
            

           
            
               


        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        public void refresh_DataGridView()
        {
            try
            {
                String syntax = "SELECT * FROM ORDER_DETAILS WHERE USERNAME ='" + textBox1.Text + "'";
                cmd = new SqlCommand(syntax, con);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid SQL Operation\n" + ex);
                }

                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            PaymentPage pg = new PaymentPage();
            this.Hide();
            pg.Show();
        }
    }
}
