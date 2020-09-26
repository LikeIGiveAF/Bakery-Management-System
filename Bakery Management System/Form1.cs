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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\"; Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        private Boolean checkUsername(String username)
        {
            //verifying the existing of username in the database
            con.Open();
            String syntax = "SELECT COUNT(USERNAME) FROM CUSTOMER WHERE USERNAME='" + username + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = dr[0].ToString();
            con.Close();
            if (temp.Equals("1"))
                return true;
            return false;
        }

        private String getPassword(String username)
        {
            //searching for password associated with the username entered
            con.Open();
            String syntax = "SELECT PASSWORD FROM CUSTOMER WHERE USERNAME='" + username + "'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            String temp = dr[0].ToString();
            con.Close();
            return temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String upass = null, name, pass;
            name = textBox1.Text;
            pass = textBox2.Text;
            if (checkUsername(name).Equals(true))
            {
                upass = getPassword(name);
                if (upass.Equals(pass))
                {
                    label4.Hide();
                    HomePage obj = new HomePage();
                    this.Hide();
                    obj.Show();
                }
                else
                {
                    label4.Show();
                }
            }
            else
            {
                //login failed
                label4.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp din = new SignUp();
            this.Hide();
            din.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
