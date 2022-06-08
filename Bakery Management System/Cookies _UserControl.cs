using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bakery_Management_System
{
    public partial class Cookies__UserControl : UserControl
    {
        private static Cookies__UserControl _instance;

        public static Cookies__UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Cookies__UserControl();
                }
                return _instance;
            }
        }
        public Cookies__UserControl()
        {
            InitializeComponent();
        }

        private void Cookies__UserControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderPage obj = new OrderPage();
            this.Hide();
            obj.Show();
        }
    }
}
