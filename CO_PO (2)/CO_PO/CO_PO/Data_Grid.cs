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
    public partial class Data_Grid : Form
    {
        public Data_Grid()
        {
            InitializeComponent();
        }

        private void Data_Grid_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int i=1;i<=4;i++)
                dt.Columns.Add(new DataColumn("CO "+ i, typeof(string)));
            for (int i = 1; i <= 4; i++)
                dt.Columns.Add(new DataColumn("CO "+ i +" Practical", typeof(string)));
            for (int i = 1; i <= 4; i++)
                dt.Columns.Add(new DataColumn("CO "+ i +" Assignement", typeof(string)));
            for (int i = 0; i < Form1.no_of_students; i++)
                dt.Rows.Add();
            dataGridView1.DataSource = dt;
            
        }

   
        // PasteInData pastes clipboard data into the grid passed to it.
        static void PasteInData(DataGridView dgv)
        {
            char[] rowSplitter = { '\n', '\r' };  // Cr and Lf.
            char columnSplitter = '\t';         // Tab.

            IDataObject dataInClipboard = Clipboard.GetDataObject();

            string stringInClipboard =
                dataInClipboard.GetData(DataFormats.Text).ToString();

            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter,
                StringSplitOptions.RemoveEmptyEntries);

            int r = dgv.SelectedCells[0].RowIndex;
            int c = dgv.SelectedCells[0].ColumnIndex;

            if (dgv.Rows.Count < (r + rowsInClipboard.Length))
                dgv.Rows.Add(r + rowsInClipboard.Length + 1 - dgv.Rows.Count);

            // Loop through lines:

            int iRow = 0;
            while (iRow < rowsInClipboard.Length)
            {
                // Split up rows to get individual cells:

                string[] valuesInRow =
                    rowsInClipboard[iRow].Split(columnSplitter);

                // Cycle through cells.
                // Assign cell value only if within columns of grid:

                int jCol = 0;
                while (jCol < valuesInRow.Length)
                {
                    if ((dgv.ColumnCount - 1) >= (c + jCol))
                        dgv.Rows[r + iRow].Cells[c + jCol].Value =
                        valuesInRow[jCol];

                    jCol += 1;
                } // end while

                iRow += 1;
            } // end while
        } // PasteInData

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { PasteInData(dataGridView1); }
            catch 
            {
                MessageBox.Show("No of Items Copied More than No of Students Selected. Go Back and Edit no. of Students", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CO_PO_Selection c = new CO_PO_Selection();
            c.Show();
            Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            Hide();
            c.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Scaled f = new Scaled();
            f.Analyse(dataGridView1);

            double temp;
            for (int rows = 0; rows < dataGridView1.Rows.Count-1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count-1; col++)
                {
                    switch (col)
                    {
                        case 0:
                            temp = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                            temp = temp * 15 / Form1.CO_1;
                            dataGridView1.Rows[rows].Cells[col].Value = temp;
                            break;
                        case 1:
                            temp = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                            temp = temp * 15 / Form1.CO_2;
                            dataGridView1.Rows[rows].Cells[col].Value = temp;
                            break;
                        case 2:
                            temp = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                            temp = temp * 15 / Form1.CO_3;
                            dataGridView1.Rows[rows].Cells[col].Value = temp;
                            break;
                        case 3:
                            temp = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                            temp = temp * 15 / Form1.CO_4;
                            dataGridView1.Rows[rows].Cells[col].Value = temp;
                            break;
                    }

                }
            }
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    dataGridView1.Rows[rows].Cells[col].ReadOnly = true;
                }
            }
            button4.Enabled = false;
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;

            double temp;
            for (int rows = 0; rows < dataGridView1.Rows.Count-1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count-1; col++)
                {

                    switch (col)
                    {
                        case 0:
                            temp = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                            temp = Math.Ceiling(temp * Form1.CO_1 / 15);
                            dataGridView1.Rows[rows].Cells[col].Value = temp;
                            break;
                        case 1:
                            temp = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                            temp = Math.Ceiling(temp * Form1.CO_2 / 15);
                            dataGridView1.Rows[rows].Cells[col].Value = temp;
                            break;
                        case 2:
                            temp = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                            temp = Math.Ceiling(temp * Form1.CO_3 / 15);
                            dataGridView1.Rows[rows].Cells[col].Value = temp;
                            break;
                        case 3:
                            temp = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value.ToString());
                            temp = Math.Ceiling(temp * Form1.CO_4 / 15);
                            dataGridView1.Rows[rows].Cells[col].Value = temp;
                            break;
                    }

                }
            }

            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    dataGridView1.Rows[rows].Cells[col].ReadOnly = false;
                }
            }
        }
    }
}
