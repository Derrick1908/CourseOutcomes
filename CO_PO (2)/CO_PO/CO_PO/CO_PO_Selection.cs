using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CO_PO
{
    public partial class CO_PO_Selection : Form
    {
        public CO_PO_Selection()
        {
            InitializeComponent();
        }
        public static int no_po, no_co, no_pso;

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            no_po = Convert.ToInt32(textBox1.Text);
            no_co = Convert.ToInt32(textBox2.Text);
            no_pso = Convert.ToInt32(textBox4.Text);

            for (int i = 0; i < no_po; i++)
            {
                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                cmb.HeaderText = "PO-" + (i + 1);
                cmb.Name = "cmb";
                cmb.MaxDropDownItems = 3;
                cmb.Items.Add("1");
                cmb.Items.Add("2");
                cmb.Items.Add("3");
                cmb.Width = 50;
                dataGridView1.Columns.Add(cmb);

            }
            for (int i = 0; i < no_pso; i++)
            {
                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                cmb.HeaderText = "PSO-" + (i + 1);
                cmb.Name = "cmb";
                cmb.MaxDropDownItems = 3;
                cmb.Items.Add("1");
                cmb.Items.Add("2");
                cmb.Items.Add("3");
                cmb.Width = 50;
                dataGridView1.Columns.Add(cmb);

            }
            for (int i = 0; i < no_co; i++)
            {
                DataGridViewRow c = new DataGridViewRow();
                c.HeaderCell.Value = "CO-" + i;
                dataGridView1.Rows.Add(c);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string final = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                final += "\n CO-" + (row.Index + 1) + " ---> ";

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)row.Cells[col.Index];
                    if (combo.Value != null && (col.Index + 1) < no_po)
                        final += " PO-" + (col.Index + 1) + "( " + combo.Value.ToString() + ") ,";
                    else if (combo.Value != null && (col.Index + 1) > no_po)
                        final += " PSO-" + (col.Index + 1 - no_po) + "( " + combo.Value.ToString() + ") ,";                    
                }
            }
            label4.Text = final;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.ResetText();
            CheckBox headerCheckBox = new CheckBox();
            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)row.Cells[col.Index];
                    if (combo.Value != null)
                        combo.Value = null;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Hide();
            Data_Grid s = new Data_Grid();
            s.Show();
        }

        private void CO_PO_Selection_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Analyse d = new Analyse();
            d.Show();
            Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
