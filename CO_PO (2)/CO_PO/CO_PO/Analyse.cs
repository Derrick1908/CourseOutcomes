using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CO_PO
{
    public partial class Analyse : Form
    {
        public Analyse()
        {
            InitializeComponent();
        }

        private void Analyse_Load(object sender, EventArgs e)
        {
            string[] name = { "CO-1", "CO-2", "CO-3", "CO-4" };
            chart1.Series["Marks"].Points.AddXY(name[0], 10);
            chart1.Series["Marks"].Points.AddXY(name[1], 20);
            chart1.Series["Marks"].Points.AddXY(name[2], 30);
            chart1.Series["Marks"].Points.AddXY(name[3], 40);
            this.chart1.Titles.Add("Percentage Attainment (%)");
            chart1.Series["Marks"].ChartType = SeriesChartType.StackedColumn;
            chart1.Series["Marks"].IsValueShownAsLabel = true;
            chart1.Series["Marks"].Color = Color.Maroon;
            chart1.Series["Marks"].LabelForeColor = Color.White;

            StripLine stripline = new StripLine();
            stripline.Interval = 0;
            stripline.IntervalOffset = 50;
            stripline.StripWidth = 0.7;
            stripline.BackColor = Color.Black;
            chart1.ChartAreas[0].AxisY.StripLines.Add(stripline);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
