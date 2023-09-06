using ChartDirector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace KcopsAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string getName() { return "Simple Bar Chart (2)"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }
        //private void winChartViewer1_Click(object sender, EventArgs e)
        //{

        //}

        public void LinecreateChart(WinChartViewer viewer, int chartIndex)
        {
            // The data for the line chart
            double[] data = { 0, 0, 10 };

            // The labels for the line chart
            string[] labels = { "0", "13.328231" };

            // Create a XYChart object of size 250 x 250 pixels
            XYChart c = new XYChart(350, 350);

            // Set the plotarea at (30, 20) and of size 200 x 200 pixels
            c.setPlotArea(30, 9, 300, 300);

            // Add a line chart layer using the given data
            c.addLineLayer(data);

            // Set the labels on the x axis.
            c.xAxis().setLabels(labels);

            // Display 1 out of 3 labels on the x-axis.
            c.xAxis().setLabelStep(1);

            // Output the chart
            viewer.Chart = c;

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='Hour {xLabel}: Traffic {value} GBytes'");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RanSeries r = new RanSeries(127);
            double[] data0 = r.getSeries(100, 100, -15, 15);
            BarcreateChart(winChartViewer1, 0);
        }

        //Note: the argument chartIndex is unused because this demo only has 1 chart.
        public void BarcreateChart(WinChartViewer viewer, int chartIndex)
        {
            // The data for the bar chart
            double[] data = { 0, 13, 0 };

            // The labels for the bar chart
            string[] labels = { "0", "0.0633", "13.00" };

            // Create a XYChart object of size 600 x 400 pixels
            XYChart c = new XYChart(500, 400);

            // Set default text color to dark grey (0x333333)
            c.setColor(Chart.TextColor, 0x333333);

            // Add a title box using grey (0x555555) 24pt Arial Bold font
            c.addTitle("분석결과", "Arial Bold", 24, 0x555555);

            // Set the plotarea at (70, 60) and of size 500 x 300 pixels, with transparent
            // background and border and light grey (0xcccccc) horizontal grid lines
            c.setPlotArea(70, 60, 400, 200, Chart.Transparent, -1, Chart.Transparent, 0xcccccc);

            // Set the x and y axis stems to transparent and the label font to 12pt Arial
            c.xAxis().setColors(Chart.Transparent);
            c.yAxis().setColors(Chart.Transparent);
            c.xAxis().setLabelStyle("Arial", 12);
            c.yAxis().setLabelStyle("Arial", 12);

            // Add a blue (0x6699bb) bar chart layer with transparent border using the given data
            c.addBarLayer(data, 0x6699bb).setBorderColor(Chart.Transparent);

            // Set the labels on the x axis.
            c.xAxis().setLabels(labels);

            // For the automatic y-axis labels, set the minimum spacing to 40 pixels.
            c.yAxis().setTickDensity(30);

            // Add a title to the y axis using dark grey (0x555555) 14pt Arial Bold font
            c.yAxis().setTitle("Y-Axis Title Placeholder", "Arial Bold", 14, 0x555555);

            // Output the chart
            viewer.Chart = c;

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "", "title='{xLabel}: {value} kg'");
        }

        private void vlcControl1_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {

        }
    }
}

