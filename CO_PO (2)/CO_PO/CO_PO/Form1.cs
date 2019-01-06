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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static int no_of_students;
        public static int CO_1,CO_2,CO_3,CO_4;
        public static int CO_1_P, CO_2_P, CO_3_P, CO_4_P;
        public static int CO_1_A, CO_2_A, CO_3_A, CO_4_A;

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        flag = 1;
                        break;
                    }
                }

                //if (c is GroupBox)
                //{
                //    foreach (Control tb in c.Controls)
                //    {
                //        if (tb is TextBox)
                //        {
                //            flag = 1;
                //            break;
                //        }
                //    }
                //}


            }



            if (flag == 0)
            {
                Data_Grid f = new Data_Grid();
                try {
                    no_of_students = Convert.ToInt32(textBox1.Text);
                    CO_1 = Convert.ToInt32(textBox2.Text); CO_2 = Convert.ToInt32(textBox3.Text); CO_3 = Convert.ToInt32(textBox4.Text); CO_4 = Convert.ToInt32(textBox5.Text);
                    CO_4_A = Convert.ToInt32(textBox6.Text); CO_3_A = Convert.ToInt32(textBox7.Text); CO_2_A = Convert.ToInt32(textBox8.Text); CO_1_A = Convert.ToInt32(textBox9.Text);
                    CO_4_P = Convert.ToInt32(textBox10.Text); CO_3_P = Convert.ToInt32(textBox11.Text); CO_2_P = Convert.ToInt32(textBox12.Text); CO_1_P = Convert.ToInt32(textBox13.Text);
                }
                catch
                {
                    f.Show();
                    Hide();
                }
                
            }
            else
                MessageBox.Show("Please Fill in all the Textboxes", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
