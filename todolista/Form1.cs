using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todolista
{
    public partial class frmKezdo : Form
    {
        public frmKezdo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmKezdo_Shown(object sender, EventArgs e)
        {
            tbBevitel.Text = "";
            lbToDo.Items.Clear();
            tbBevitel.Focus();
        }

        private void btnEltavolit_Click(object sender, EventArgs e)
        {

        }

  
    }
}
