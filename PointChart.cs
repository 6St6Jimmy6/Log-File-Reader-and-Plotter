using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Log_File_Reader_and_Plotter
{
/*
Thanks for EETechStuff this awesome video that shows how to build a Chart class.
https://www.youtube.com/watch?v=YH5psj_dN1Q
 */
    class PointChart
    {
        #region Docs

        /* This Class defines a Line Chart which has the following features:
         *  - Ability to define Prmary & Secondary (Y1 & Y2) Axes
         *  - Ability to do Manual or Auto scaling to Y1 & Y2 Axes
         *  - Ability to instantate one or more instances of this class to configure multiple charts 
         *  
         *  Secondary (Y2) Axis:
         *  The "Y2Axis()" method adds a new Series to the chart and configures the Y2 Axis. When configuring Secondary (Y2) axis gridlines, 
         *  it uses the existing Major & Minor grid lines of the Primary (Y1) axis, and doesn't draw Y2 gridlines. 
         *  It calculates a Y2 interval that corresponds to the Y1 gridlines.
         *  
         *  At any time the user can call one of the Class methods "AutoScaleY()" or "AutoScaleY2()" to do either manual or auto scaling of either Y1 or Y2 axes.
         */

        #endregion

        #region Fields

        /*
         * These fields are used to calculate Secondary (Y2) Axis intervals to ensure they match the Primary (Y1) Axis intervals, since no Y2 axis gridlines are drawn.
        */
        double YAxisMin;
        double YAxisMax;
        double YAxisMajorInt;

        /*
         * Define the Font used for all axes
         */
        //Font AxisFont = new Font("Microsoft Sans Serif", 8f, FontStyle.Bold);

        #endregion

        #region Constructor

        public PointChart(Chart chartName)
        {
            chartName.Series["Series1"].ChartType = SeriesChartType.Point;



            chartName.ChartAreas["ChartArea1"].BorderColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].BorderDashStyle = ChartDashStyle.Solid;
            chartName.ChartAreas["ChartArea1"].BorderWidth = 1;

            chartName.ChartAreas["ChartArea1"].BackColor = System.Drawing.Color.White;
            chartName.ChartAreas["ChartArea1"].BackSecondaryColor = Color.Empty;

            chartName.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.None;
            chartName.ChartAreas["ChartArea1"].BackHatchStyle = ChartHatchStyle.None;

            chartName.ChartAreas["ChartArea1"].BackImage = "";
            chartName.ChartAreas["ChartArea1"].BackImageAlignment = ChartImageAlignmentStyle.TopLeft;
            chartName.ChartAreas["ChartArea1"].BackImageTransparentColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].BackImageWrapMode = ChartImageWrapMode.Tile;

            chartName.ChartAreas["ChartArea1"].ShadowColor = Color.Black;
            chartName.ChartAreas["ChartArea1"].ShadowOffset = 0;

            //chart.Legends.Clear();
        }

        #endregion

        #region Methods
        public void XAxis(Chart chartName, string labelMajorFamilyName, float labelMajorEmSizef, FontStyle labelMajorStyle, Color labelTextColor, int labelMajorDecimals, double min, double max, double majorInterval, bool minorEnabled, ChartDashStyle minorDashStyle, double minorIntFrac) // ChartName, sMajorLabelFontName, MajorLabelFontSizef, MajorLabelFont.Style, MinValue, MaxValue, MajorGridInterval, MinorGridEnabled, MinorGridIntervalFraction
        {


            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font(labelMajorFamilyName, labelMajorEmSizef, labelMajorStyle);
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = labelTextColor;
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F" + Convert.ToString(labelMajorDecimals);

            chartName.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = false;
            chartName.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMaxFontSize = 20;

            chartName.ChartAreas["ChartArea1"].AxisX.Crossing = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisX.Enabled = AxisEnabled.Auto;

            chartName.ChartAreas["ChartArea1"].AxisX.IsInterlaced = false;
            chartName.ChartAreas["ChartArea1"].AxisX.InterlacedColor = Color.Black;

            chartName.ChartAreas["ChartArea1"].AxisX.IsLogarithmic = false;
            chartName.ChartAreas["ChartArea1"].AxisX.LogarithmBase = 10d;



            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = min;
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = max;
            chartName.ChartAreas["ChartArea1"].AxisX.Interval = majorInterval;

            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = minorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineDashStyle = minorDashStyle;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = Color.DarkGray;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineWidth = 1;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = majorInterval / minorIntFrac;
            //chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Number;
            //chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.IntervalOffset = 0;
            //chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.IntervalOffsetType = DateTimeIntervalType.Auto;

        }
        public void YAxis(Chart chartName, string legendText, string labelMajorFamilyName, float labelMajorEmSize, FontStyle labelMajorStyle, int labelDecimals, double min, double max, double majorInt, bool minorEnabled, double minorIntFrac) // min and max need to be divisible by 1, 2 or 5
        { // min and max need to be divisible by 1, 2 or 5
            YAxisMin = min;
            YAxisMax = max;
            // Getting rid of divided by 0 error for Y2 axis calculation
            if (majorInt <= 0d)
            {
                YAxisMajorInt = 1;
            }
            else
            {
                YAxisMajorInt = majorInt;
            }

            chartName.Series["Series1"].Enabled = true;

            //chartName.Series["Series1"].ToolTip = "Series tooltip";

            //chartName.Series["Series1"].LabelToolTip = "Label tooltip?";

            chartName.Series["Series1"].IsVisibleInLegend = true;
            chartName.Series["Series1"].LegendText = legendText;
            //chartName.Series["Series1"].LegendToolTip = "Legend tooltip";

            chartName.Series["Series1"].MarkerStyle = MarkerStyle.Circle;
            chartName.Series["Series1"].MarkerStep = 1;

            chartName.Series["Series1"].MarkerSize = 3;
            chartName.Series["Series1"].MarkerColor = Color.Blue;
            chartName.Series["Series1"].MarkerBorderWidth = 0;
            chartName.Series["Series1"].MarkerBorderColor = Color.Blue;

            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = min;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = max;
            chartName.ChartAreas["ChartArea1"].AxisY.Interval = majorInt;

            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = minorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = majorInt / minorIntFrac;

            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = Color.DarkGray;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = ChartDashStyle.Dash;

            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font(labelMajorFamilyName, labelMajorEmSize, labelMajorStyle);
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "F" + Convert.ToString(labelDecimals);
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = Color.Blue;
        }
        public void Y2Axis(Chart chartName, string legendText, string labelMajorFamilyName, float labelMajorEmSize, FontStyle labelMajorStyle, int labelDecimals, double min, double max)// Others are used from the main YAxis
        {
            int numMajorGridLines = Convert.ToInt32((YAxisMax - YAxisMin) / YAxisMajorInt);
            //Console.WriteLine(numMajorGridLines);
            chartName.Series.Add("Series2");
            chartName.Series["Series2"].LegendText = legendText;
            chartName.Series["Series2"].ChartType = SeriesChartType.Point;

            chartName.Series["Series2"].MarkerStyle = MarkerStyle.Circle;
            chartName.Series["Series2"].MarkerStep = 1;

            chartName.Series["Series2"].MarkerSize = 3;
            chartName.Series["Series2"].MarkerColor = Color.Orange;
            chartName.Series["Series2"].MarkerBorderWidth = 0;
            chartName.Series["Series2"].MarkerBorderColor = Color.Orange;

            chartName.Series["Series2"].YAxisType = AxisType.Secondary;

            chartName.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Font = new Font(labelMajorFamilyName, labelMajorEmSize, labelMajorStyle);

            chartName.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Format = "F" + Convert.ToString(labelDecimals);
            chartName.ChartAreas["ChartArea1"].AxisY2.LabelStyle.ForeColor = Color.Orange;

            chartName.ChartAreas["ChartArea1"].AxisY2.Minimum = min;
            chartName.ChartAreas["ChartArea1"].AxisY2.Maximum = max;

            //**********************************************************************************
            // NOTE: Make these values divisible by 1, 2 or 5
            chartName.ChartAreas["ChartArea1"].AxisY2.Interval = (max - min) / numMajorGridLines;
            //**********************************************************************************
        }

        public void AutoScaleX(Chart chart)
        {
            chart.ChartAreas["ChartArea1"].AxisX.Minimum = double.NaN;
            chart.ChartAreas["ChartArea1"].AxisX.Maximum = double.NaN;
            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = double.NaN;
            chart.ChartAreas["ChartArea1"].AxisX.Interval = 0;
        }
        public void AutoScaleY(Chart chart)
        {
            chart.ChartAreas["ChartArea1"].AxisY.Minimum = double.NaN;
            chart.ChartAreas["ChartArea1"].AxisY.Maximum = double.NaN;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Interval = double.NaN;
            chart.ChartAreas["ChartArea1"].AxisY.Interval = 0;
        }
        public void AutoScaleY2(Chart chart)
        {
            chart.ChartAreas["ChartArea1"].AxisY2.Minimum = double.NaN;
            chart.ChartAreas["ChartArea1"].AxisY2.Maximum = double.NaN;
        }

        #endregion
    }
}
