﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepublicSystemClasses;


namespace PlanetOuter
{
    public partial class PlanetOuterForm : Form
    {
        Form frm = new Form();
        ClasePlanetaOuter cpo = new ClasePlanetaOuter();
        RSA rs = new RSA();
        public PlanetOuterForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm = FindForm();
            cpo.form = frm;
            cpo.Start();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cpo.StartClient();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rs.GenerarKeys();
        }
    }
}