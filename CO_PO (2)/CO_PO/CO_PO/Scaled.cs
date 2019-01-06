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
    public partial class Scaled : Form
    {
        public Scaled()
        {
            InitializeComponent();
        }

       private void Scaled_Load_1(object sender, EventArgs e)
        {
            
            
        }
        public void Analyse(DataGridView dataGridView)
        {

            
            DataTable dt = new DataTable();
            for (int i = 1; i <= 4; i++)
                dt.Columns.Add(new DataColumn("CO " + i, typeof(string)));
            for (int i = 1; i <= 4; i++)
                dt.Columns.Add(new DataColumn("CO " + i + " Practical", typeof(string)));
            for (int i = 1; i <= 4; i++)
                dt.Columns.Add(new DataColumn("CO " + i + " Assignement", typeof(string)));
            for (int i = 1; i <= 4; i++)
                dt.Columns.Add(new DataColumn("CO " + i + " Total", typeof(string)));
            for (int i = 0; i < Form1.no_of_students; i++)
                dt.Rows.Add();
            dataGridView1.DataSource = dt;
            for (int rows = 0; rows < dataGridView.Rows.Count-1; rows++)
            {
                for (int col = 0; col < dataGridView.Rows[rows].Cells.Count-1; col++)
                {
                    dataGridView1.Rows[rows].Cells[col].Value = dataGridView.Rows[rows].Cells[col].Value;
                }
            }

            int coll = 12;
            for (int rows = 0; rows < dataGridView.Rows.Count-1; rows++)
            {
               dataGridView1.Rows[rows].Cells[coll].Value = Convert.ToInt64(dataGridView.Rows[rows].Cells[0].Value) + Convert.ToInt64(dataGridView.Rows[rows].Cells[4].Value)+ Convert.ToInt64(dataGridView.Rows[rows].Cells[8].Value);
               dataGridView1.Rows[rows].Cells[coll+1].Value = Convert.ToInt64(dataGridView.Rows[rows].Cells[1].Value) + Convert.ToInt64(dataGridView.Rows[rows].Cells[5].Value) + Convert.ToInt64(dataGridView.Rows[rows].Cells[9].Value);
               dataGridView1.Rows[rows].Cells[coll+2].Value = Convert.ToInt64(dataGridView.Rows[rows].Cells[2].Value) + Convert.ToInt64(dataGridView.Rows[rows].Cells[6].Value) + Convert.ToInt64(dataGridView.Rows[rows].Cells[10].Value);
               dataGridView1.Rows[rows].Cells[coll+3].Value = Convert.ToInt64(dataGridView.Rows[rows].Cells[3].Value) + Convert.ToInt64(dataGridView.Rows[rows].Cells[7].Value) + Convert.ToInt64(dataGridView.Rows[rows].Cells[11].Value);
            }



        }    //End of Function
    }
}
