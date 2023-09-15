using ChartDirector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace KcopsAnalysis
{
    public partial class FrmRealTimeDemo : Form
    {
        // 눈에 보이는 데이터를 저장하는 데이터 배열. 데이터 배열은 실시간으로 업데이트됩니다. 인
        // 이 데모에서는 마지막 240개의 샘플을 그려봅니다.
        private const int sampleSize = 240;
        private DateTime[] timeStamps = new DateTime[sampleSize];
        private double[] dataSeriesA = new double[sampleSize];
        private double[] dataSeriesB = new double[sampleSize];
        private double[] dataSeriesC = new double[sampleSize];
        private System.Windows.Forms.Timer dataRateTimer;
        private System.Windows.Forms.Timer chartUpdateTimer;

        // 새 데이터 값이 추가되는 배열 위치의 인덱스입니다.
        private int currentIndex = 0;

        // 이 데모에서는 실시간 데이터를 생성하기 위해 타이머에 의해 구동되는 데이터 생성기를 사용합니다
        // nextDataTime은 데이터 생성기에서 사용하는 내부 변수입니다
        // 다음에 생성할 값입니다.
        private DateTime nextDataTime = new DateTime(DateTime.Now.Ticks / 10000000 * 10000000);

        public FrmRealTimeDemo()
        {
            InitializeComponent();
        }

        private void FrmRealTimeDemo_Load(object sender, EventArgs e)
        {
            dataRateTimer = new System.Windows.Forms.Timer();
            chartUpdateTimer = new System.Windows.Forms.Timer();
            dataRateTimer.Tick += new EventHandler(dataRateTimer_Tick);
           chartUpdateTimer.Tick += new System.EventHandler(chartUpdateTimer_Tick);
            // data 발생률
            dataRateTimer.Interval = 250;

            // 차트 업데이트 속도, 데이터 생성 속도와 다를 수 있습니다.
            chartUpdateTimer.Interval = (int)samplePeriod.Value;

            // Initialize data buffer to no data.
            for (int i = 0; i < timeStamps.Length; ++i)
                timeStamps[i] = DateTime.MinValue;

            // Enable RunPB button
           // runPB.Checked = true;

            // Now can start the timers for data collection and chart update
            dataRateTimer.Start();
            chartUpdateTimer.Start();
        }

        //
        // The data update routine. In this demo, it is invoked every 250ms to get new data.
        //
        private void dataRateTimer_Tick(object sender, EventArgs e)
        {
            do
            {
                //
                // In this demo, we use some formulas to generate new values. In real applications,
                // it may be replaced by some data acquisition code.
                //
                double p = nextDataTime.Ticks / 10000000.0 * 4;
                double dataA = 20 + Math.Cos(p * 2.2) * 10 + 1 / (Math.Cos(p) * Math.Cos(p) + 0.01);
                //double dataB = 150 + 100 * Math.Sin(p / 27.7) * Math.Sin(p / 10.1);
                //double dataC = 150 + 100 * Math.Cos(p / 6.7) * Math.Cos(p / 11.9);

                // After obtaining the new values, we need to update the data arrays.
                if (currentIndex < timeStamps.Length)
                {
                    // Store the new values in the current index position, and increment the index.
                    dataSeriesA[currentIndex] = dataA;
                    //dataSeriesB[currentIndex] = dataB;
                    //dataSeriesC[currentIndex] = dataC;
                    timeStamps[currentIndex] = nextDataTime;
                    ++currentIndex;
                }
                else
                {
                    // The data arrays are full. Shift the arrays and store the values at the end.
                    shiftData(dataSeriesA, dataA);
                    //shiftData(dataSeriesB, dataB);
                    //shiftData(dataSeriesC, dataC);
                    shiftData(timeStamps, nextDataTime);
                }

                // Update nextDataTime. This is needed by our data generator. In real applications,
                // you may not need this variable or the associated do/while loop.
                nextDataTime = nextDataTime.AddMilliseconds(dataRateTimer.Interval);
            }
            while (nextDataTime < DateTime.Now);

            // We provide some visual feedback to the numbers generated, so you can see the
            // values being generated.
            valueA.Text = dataSeriesA[currentIndex - 1].ToString(".##");
            valueB.Text = dataSeriesB[currentIndex - 1].ToString(".##");
            valueC.Text = dataSeriesC[currentIndex - 1].ToString(".##");
        }

        //
        // Utility to shift a double value into an array
        //
        private void shiftData(double[] data, double newValue)
        {
            for (int i = 1; i < data.Length; ++i)
                data[i - 1] = data[i];
            data[data.Length - 1] = newValue;
        }

        //
        // Utility to shift a DataTime value into an array
        //
        private void shiftData(DateTime[] data, DateTime newValue)
        {
            for (int i = 1; i < data.Length; ++i)
                data[i - 1] = data[i];
            data[data.Length - 1] = newValue;
        }

        //
        // Enable/disable chart update based on the state of the Run button.
        //
        private void runPB_CheckedChanged(object sender, EventArgs e)
        {
           // chartUpdateTimer.Enabled = runPB.Checked;
        }

        //
        // Updates the chartUpdateTimer interval if the user selects another interval.
        //
        private void samplePeriod_ValueChanged(object sender, EventArgs e)
        {
            chartUpdateTimer.Interval = (int)samplePeriod.Value;
        }

        //
        // The chartUpdateTimer Tick event - this updates the chart periodicially by raising
        // viewPortChanged events.
        //
        private void chartUpdateTimer_Tick(object sender, EventArgs e)
        {
            winChartViewer1.updateViewPort(true, false);
        }

        //
        // The viewPortChanged event handler. In this example, it just updates the chart. If you
        // have other controls to update, you may also put the update code here.
        //
        private void winChartViewer1_ViewPortChanged(object sender, WinViewPortEventArgs e)
        {
            drawChart(winChartViewer1);
        }

        //
        // Draw the chart and display it in the given viewer.
        //
        private void drawChart(WinChartViewer viewer)
        {
            // Create an XYChart object 600 x 270 pixels in size, with light grey (f4f4f4) 
            // background, black (000000) border, 1 pixel raised effect, and with a rounded frame.
            XYChart c = new XYChart(600, 270, 0xf4f4f4, 0x000000, 1);
            c.setRoundedFrame(Chart.CColor(BackColor));

            // Set the plotarea at (55, 55) and of size 520 x 185 pixels. Use white (ffffff) 
            // background. Enable both horizontal and vertical grids by setting their colors to 
            // grey (cccccc). Set clipping mode to clip the data lines to the plot area.
            c.setPlotArea(55, 55, 520, 185, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);
            c.setClipping();

            // Add a title to the chart using 15 pts Times New Roman Bold Italic font, with a light
            // grey (dddddd) background, black (000000) border, and a glass like raised effect.
            c.addTitle("Field Intensity at Observation Satellite", "Times New Roman Bold Italic", 15
                ).setBackground(0xdddddd, 0x000000, Chart.glassEffect());

            // Set the reference font size of the legend box
            c.getLegend().setFontSize(8);

            // Configure the y-axis with a 10pts Arial Bold axis title
            c.yAxis().setTitle("Intensity (V/m)", "Arial Bold", 10);

            // Configure the x-axis to auto-scale with at least 75 pixels between major tick and 15 
            // pixels between minor ticks. This shows more minor grid lines on the chart.
            c.xAxis().setTickDensity(75, 15);

            // Set the axes width to 2 pixels
            c.xAxis().setWidth(2);
            c.yAxis().setWidth(2);

            // Now we add the data to the chart
            DateTime firstTime = timeStamps[0];
            if (firstTime != DateTime.MinValue)
            {
                // Set up the x-axis scale. In this demo, we set the x-axis to show the 240 samples,
                // with 250ms per sample.
                c.xAxis().setDateScale(firstTime, firstTime.AddSeconds(
                    dataRateTimer.Interval * timeStamps.Length / 1000));

                // Set the x-axis label format
                c.xAxis().setLabelFormat("{value|hh:nn:ss}");

                // Create a line layer to plot the lines
                LineLayer layer = c.addLineLayer2();

                // The x-coordinates are the timeStamps.
                layer.setXData(timeStamps);

                // The 3 data series are used to draw 3 lines.
                layer.addDataSet(dataSeriesA, 0xff0000, "Alpha");
                //layer.addDataSet(dataSeriesB, 0x00cc00, "Beta");
                //layer.addDataSet(dataSeriesC, 0x0000ff, "Gamma");
            }

            // 범례가 있는 트랙 라인을 포함합니다. 마우스가 플롯 영역에 있으면 트랙을 표시합니다
            // 마우스 위치에 범례가 있는 줄을 그립니다. 그렇지 않으면 최신 데이터를 표시합니다
            // 값(즉, 가장 오른쪽 위치).
            trackLineLegend(c, viewer.IsMouseOnPlotArea ? viewer.PlotAreaMouseX :
                c.getPlotArea().getRightX());

            // Assign the chart to the WinChartViewer
            viewer.Chart = c;
        }

        //
        // Draw track cursor when mouse is moving over plotarea
        //
        private void winChartViewer1_MouseMovePlotArea(object sender, MouseEventArgs e)
        {
            WinChartViewer viewer = (WinChartViewer)sender;
            trackLineLegend((XYChart)viewer.Chart, viewer.PlotAreaMouseX);
            viewer.updateDisplay();
        }

        //
        // Draw the track line with legend
        //
        private void trackLineLegend(XYChart c, int mouseX)
        {
            // 현재 동적 레이어를 지우고 DrawArea 객체가 그 위에 그리도록 합니다.
            DrawArea d = c.initDynamicLayer();

            // 플롯 영역 객체
            PlotArea plotArea = c.getPlotArea();

            // 마우스에 가장 가까운 데이터 x 값을 얻고 해당 픽셀 좌표를 찾습니다.
            double xValue = c.getNearestXValue(mouseX);
            int xCoor = c.getXCoor(xValue);

            // x 위치에 수직 트랙 라인 그리기
            d.vline(plotArea.getTopY(), plotArea.getBottomY(), xCoor, d.dashLineColor(0x000000, 0x0101));

            // Container to hold the legend entries
            ArrayList legendEntries = new ArrayList();

            // Iterate through all layers to build the legend array
            for (int i = 0; i < c.getLayerCount(); ++i)
            {
                Layer layer = c.getLayerByZ(i);

                // The data array index of the x-value
                int xIndex = layer.getXIndexOf(xValue);

                // Iterate through all the data sets in the layer
                for (int j = 0; j < layer.getDataSetCount(); ++j)
                {
                    ChartDirector.DataSet dataSet = layer.getDataSetByZ(j);

                    // We are only interested in visible data sets with names
                    string dataName = dataSet.getDataName();
                    int color = dataSet.getDataColor();
                    if ((!string.IsNullOrEmpty(dataName)) && (color != Chart.Transparent))
                    {
                        // Build the legend entry, consist of the legend icon, name and data value.
                        double dataValue = dataSet.getValue(xIndex);
                        legendEntries.Add("<*block*>" + dataSet.getLegendIcon() + " " + dataName + ": " + ((
                            dataValue == Chart.NoValue) ? "N/A" : c.formatValue(dataValue, "{value|P4}")) +
                            "<*/*>");

                        // Draw a track dot for data points within the plot area
                        int yCoor = c.getYCoor(dataSet.getPosition(xIndex), dataSet.getUseYAxis());
                        if ((yCoor >= plotArea.getTopY()) && (yCoor <= plotArea.getBottomY()))
                        {
                            d.circle(xCoor, yCoor, 4, 4, color, color);
                        }
                    }
                }
            }

            // Create the legend by joining the legend entries
            legendEntries.Reverse();
            string legendText = "<*block,maxWidth=" + plotArea.getWidth() + "*><*block*><*font=Arial Bold*>["
                 + c.xAxis().getFormattedLabel(xValue, "hh:nn:ss.ff") + "]<*/*>        " + String.Join(
                "        ", (string[])legendEntries.ToArray(typeof(string))) + "<*/*>";

            // Display the legend on the top of the plot area
            TTFText t = d.text(legendText, "Arial", 8);
            t.draw(plotArea.getLeftX() + 5, plotArea.getTopY() - 3, 0x000000, Chart.BottomLeft);
        }
    }
}
