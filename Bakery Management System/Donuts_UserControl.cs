﻿using System;
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
    public partial class Donuts_UserControl : UserControl
    {
        private static Donuts_UserControl _instance;

        public static Donuts_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Donuts_UserControl();
                }
                return _instance;
            }
        }

        public Donuts_UserControl()
        {
            InitializeComponent();
        }

        private void Donuts_UserControl_Load(object sender, EventArgs e)
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
