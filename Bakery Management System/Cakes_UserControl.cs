using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bakery_Management_System
{
    public partial class Cakes_UserControl : UserControl
    {
        private static Cakes_UserControl _instance;

        public static Cakes_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Cakes_UserControl();
                }
                return _instance;
            }
        }

        public Cakes_UserControl()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Cakes_UserControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // OrderPage obj = new OrderPage();
            HomePage Home = new HomePage();
            this.Hide();
            Home.Hide();
           // obj.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\"; Integrated Security=True");
        SqlCommand cmd;

        private void button1_Click_1(object sender, EventArgs e)
        {
                  String items = "";
            foreach (Control c in Controls)
            {
                if(c is CheckBox)
                {
                    CheckBox b = (CheckBox)c;
                    if(b.Checked)
                    {
                        items = items + b.Text;
                    }
                }
            }
            if(!items.Equals(""))
            {
                label2.Hide();
                con.Open();
                String syntax = "UPDATE ORDER_DETAILS SET ITEM_NAMES='" + items + "' WHERE USERNAME ='" + textBox1.Text + "'";
                cmd = new SqlCommand(syntax, con);
                con.Close();
            }
            else
            {
                label2.Show();
            }

             HomePage pg = new HomePage();
             OrderPage ord = new OrderPage();
            pg.Hide();
            //this.Hide();
            ord.Show();

            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
