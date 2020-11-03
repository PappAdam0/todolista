using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace todolista
{
    public partial class frmKezdo : Form
    {
        private List<string> todos = new List<string>();
        public frmKezdo()
        {
            InitializeComponent();
            StreamReader be = new StreamReader("todoitems.txt");
            while (!be.EndOfStream)
            {
                todos.Add(be.ReadLine());
            }

            be.Close();
        }


        private void mKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnListabol_Click(object sender, EventArgs e)
        {
            frmLista formLista = new frmLista(todos);
            var result = formLista.ShowDialog();

            if (result == DialogResult.OK)
            {
            tbBevitel.Text = formLista.SelectedTodo;

            }
            tbBevitel.Focus();
            tbBevitel.SelectionStart = tbBevitel.Text.Length;
            tbBevitel.SelectionLength = 0;
          

        }

        private void btnFelvitel_Click(object sender, EventArgs e)
        {
            string todo = tbBevitel.Text.Trim();

            if (todo != " " && !lbToDo.Items.Contains(todo))
            {
                lbToDo.Items.Add(todo);
                tbBevitel.Text = " ";
            }

           
        }

        private void btnEltavolit_Click(object sender, EventArgs e)
        {
            lbToDo.Items.Clear();
        }

        private void btnKivesz_Click(object sender, EventArgs e)
        {
            int index = lbToDo.SelectedIndex;

            if (index > -1)
            {
                lbToDo.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("Válassz ki egy elemet!", "Nincs kiválasztva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mBeolvasas_Click(object sender, EventArgs e)
        {
            if (ofdMegnyitas.ShowDialog() == DialogResult.OK)
            {
                lbToDo.Items.Clear();
                StreamReader be = new StreamReader(ofdMegnyitas.FileName);
                while (!be.EndOfStream)
                {
                    lbToDo.Items.Add(be.ReadLine());
                }

                be.Close();
                MessageBox.Show("Sikeres Beolvasás!", "Beolvasás", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mMentes_Click(object sender, EventArgs e)
        {
            if (lbToDo.Items.Count > 0)
            {
                sfdMentes.FileName = FileNameDate();
                if (sfdMentes.ShowDialog() == DialogResult.OK)
                {

                    StreamWriter ki = new StreamWriter(sfdMentes.FileName);
                    foreach (var i in lbToDo.Items)
                    {
                        ki.WriteLine(i);
                    }
                    ki.Close();
                    MessageBox.Show("Sikeres Mentés!", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            else
            {
                MessageBox.Show("Nincs mit menteni!", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string FileNameDate()
        {
            var datum = DateTime.Now;
            string ev = datum.Year.ToString();
            string honap = " ";
            string nap = " ";
            if (datum.Month < 10)
            {
                honap = "0" + datum.Month.ToString();
            }
            else
            {
                honap = datum.Month.ToString();
            }
            if (datum.Day < 10)
            {
                nap = "0" + datum.Day.ToString();
            }
            else
            {
                nap = datum.Day.ToString();
            }

            return ev + honap + nap;
        }
    }
}
