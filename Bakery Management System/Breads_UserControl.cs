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
    public partial class Breads_UserControl : UserControl
    {
        private static Breads_UserControl _instance;

        public static Breads_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Breads_UserControl();
                }
                return _instance;
            }
        }
        public Breads_UserControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderPage obj = new OrderPage();
            this.Hide();
            obj.Show();
        }
    }
}
