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

namespace CSE.GraphFeature
{
    public partial class Graph : Form
    {
        Dictionary<DateTime, decimal> dateAndPrice;
        Dictionary<DateTime, decimal> dateAndPriceYears;
        Dictionary<DateTime, decimal> dateAndPriceMonths;
        string productName;
        GraphOperations grapho = new GraphOperations();
        public Graph(Dictionary<DateTime, decimal> dap, string name)
        {
            InitializeComponent();
            dateAndPrice = dap;
            productName = name;
        }

        private void ChartTitle(string titles)
        {
            var titles1 = new System.Windows.Forms.DataVisualization.Charting.Title
            {
                Name = titles,
                Text = titles + " Graph Data",
                Visible = true,
            };

            this.chart1.Titles.Add(titles1);
        }

        private void ChartLegends(string name)
        {
            var legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend
            {
                Name = name,
            };
            this.chart1.Legends.Add(legend1);
        }

        private void ChartAreas()
        {
            try
            {
                DateTime minDate = dateAndPrice.Keys.Min();
                DateTime maxDate = dateAndPrice.Keys.Max();
                var axisX = new System.Windows.Forms.DataVisualization.Charting.Axis
                {
                    IntervalType = DateTimeIntervalType.Days,
                    Interval = 1,
                    IntervalOffset = 1,
                    Minimum = minDate.ToOADate(),
                    Maximum = maxDate.ToOADate(),
                    Title = "Date"
                };

                var axisY = new System.Windows.Forms.DataVisualization.Charting.Axis
                {
                    Minimum = (double)dateAndPrice.Values.Min(),
                    Maximum = (double)dateAndPrice.Values.Max(),
                    Title = "Price",
                };

                var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea
                {
                    AxisX = axisX,
                    AxisY = axisY,
                };

                this.chart1.ChartAreas.Add(chartArea1);
            }
            catch (InvalidOperationException) { Hide(); }
        }

        private void ChartSeries(string name)
        {
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                XValueType = ChartValueType.DateTime,
                Name = name,
                Color = System.Drawing.Color.Red,
                BorderWidth = 5,
                IsVisibleInLegend = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
            };

            foreach (var values in dateAndPrice)
            {
                series1.Points.AddXY(values.Key, values.Value);
            }


            this.chart1.Series.Add(series1);
            this.ChartLegends(name);
        }

        

        private void ChartAreasYears()
        {
            var axisX = new System.Windows.Forms.DataVisualization.Charting.Axis
            {
                IntervalType = DateTimeIntervalType.Years,
                Interval = 1,
                Minimum = (double)this.dateAndPriceYears.Keys.Min().AddYears(-1).ToOADate(),
                Maximum = (double)this.dateAndPriceYears.Keys.Max().AddYears(1).ToOADate(),
                Title = "Date"
            };

            var axisY = new System.Windows.Forms.DataVisualization.Charting.Axis
            {
                Minimum = 0,
                Maximum = (double)dateAndPriceYears.Values.Max(),
                Title = "Price"
            };

            var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX = axisX,
                AxisY = axisY,
            };

            this.chart1.ChartAreas.Add(chartArea1);
        }

        private void ChartSeriesYears(string name)
        {
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            { 
                XValueType = ChartValueType.DateTime,
                Name = name,
                Color = System.Drawing.Color.Red,
                BorderWidth = 5,
                IsVisibleInLegend = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
            };

            foreach (var values in dateAndPriceYears)
            {
                series1.Points.AddXY(values.Key, values.Value);
            }
            this.chart1.Series.Add(series1);
            this.ChartLegends(name);
        }

        private void ChartSeriesMonths(string name)
        {
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                XValueType = ChartValueType.DateTime,
                Name = name,
                Color = System.Drawing.Color.Red,
                BorderWidth = 5,
                IsVisibleInLegend = true,
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
            };

            foreach(var values in dateAndPriceMonths)
            {
                series1.Points.AddXY(values.Key, values.Value);
            }

            this.chart1.Series.Add(series1);
            this.ChartLegends(name);
        }

        private void ChartAreasMonths()
        {
            var axisX = new System.Windows.Forms.DataVisualization.Charting.Axis
            {
                IntervalType = DateTimeIntervalType.Months,
                Interval = 1,
                Minimum = (double)this.dateAndPriceMonths.Keys.Min().ToOADate(),
                Maximum = (double)this.dateAndPriceMonths.Keys.Max().ToOADate(),
                Title = "Date"
            };

            var axisY = new System.Windows.Forms.DataVisualization.Charting.Axis
            {
                Minimum = (double)dateAndPriceMonths.Values.Min(),
                Maximum = (double)dateAndPriceMonths.Values.Max(),
                Title = "Price"
            };

            var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea
            {
                AxisX = axisX,
                AxisY = axisY,
            };

            this.chart1.ChartAreas.Add(chartArea1);
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            this.RunReport();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }


        private void RunReportMonths()
        {
            //Clear Chart
            this.chart1.Series.Clear();
            this.chart1.Legends.Clear();
            this.chart1.ChartAreas.Clear();
            this.chart1.Titles.Clear();

            //Build Chart
            this.ChartSeriesMonths(productName);
            this.ChartAreasMonths();
            this.ChartTitle(productName);
            this.chart1.Invalidate();
        }
        private void RunReportYears()
        {
            //Clear Chart
            this.chart1.Series.Clear();
            this.chart1.Legends.Clear();
            this.chart1.ChartAreas.Clear();
            this.chart1.Titles.Clear();

            //Build Chart
            this.ChartSeriesYears(productName);
            this.ChartAreasYears();
            this.ChartTitle(productName);
            this.chart1.Invalidate();
        }

        private void RunReport()
        {
            try
            {
                //Clear Chart
                this.chart1.Series.Clear();
                this.chart1.Legends.Clear();
                this.chart1.ChartAreas.Clear();
                this.chart1.Titles.Clear();

                //Build Chart
                this.ChartSeries(productName);
                this.ChartAreas();
                this.ChartTitle(productName);
                this.chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                this.chart1.Invalidate();
            }
            catch (ArgumentException) { return; }
        }

        private void graphComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (graphComboBox.Text)
                {
                    case "Years":
                        this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
                        this.dateAndPriceYears = grapho.GetListYears(this.dateAndPrice);
                        this.RunReportYears();
                        break;
                    case "Months":
                        this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                        this.dateAndPriceMonths = grapho.GetListMonths(this.dateAndPrice);
                        this.RunReportMonths();
                        break;
                    case "Days":
                    default:
                        this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                        this.RunReport();
                        break;
                }
            }
            catch (ArgumentException) { return; }
        }

    }
}
