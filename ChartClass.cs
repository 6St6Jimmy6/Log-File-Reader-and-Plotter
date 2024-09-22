using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Log_File_Reader_and_Plotter
{
/*
Thanks for EETechStuff this awesome video that shows how to build a Chart class.
https://www.youtube.com/watch?v=YH5psj_dN1Q
 */
    class ChartClass
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
        //FormChartSettings axs = new FormChartSettings();
        public bool XAxisMinorEnabled { get; set; } = false;

        SeriesChartType ChartType;

        #endregion

        #region Constructor

        public ChartClass(System.Windows.Forms.DataVisualization.Charting.Chart chartName, SeriesChartType chartType, Color backColor, Color scrollBarButtonColor, Color legendColor)
        {
            chartName.Series["Series1"].ChartType = chartType;
            ChartType = chartType;

            chartName.ChartAreas["ChartArea1"].BorderColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].BorderDashStyle = ChartDashStyle.Solid;
            chartName.ChartAreas["ChartArea1"].BorderWidth = 3;

            chartName.BackColor = backColor;
            chartName.ChartAreas["ChartArea1"].BackColor = backColor;
            chartName.ChartAreas["ChartArea1"].BackSecondaryColor = Color.Empty;

            chartName.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.None;
            chartName.ChartAreas["ChartArea1"].BackHatchStyle = ChartHatchStyle.None;



            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonColor = scrollBarButtonColor;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.LineColor = backColor;

            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.BackColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.ButtonColor = scrollBarButtonColor;
            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.LineColor = backColor;

            chartName.ChartAreas["ChartArea1"].BackImage = "";
            chartName.ChartAreas["ChartArea1"].BackImageAlignment = ChartImageAlignmentStyle.TopLeft;
            chartName.ChartAreas["ChartArea1"].BackImageTransparentColor = Color.Empty;
            chartName.ChartAreas["ChartArea1"].BackImageWrapMode = ChartImageWrapMode.Tile;

            chartName.ChartAreas["ChartArea1"].ShadowColor = Color.Black;
            chartName.ChartAreas["ChartArea1"].ShadowOffset = 0;

            chartName.Legends["Legend1"].BackColor = Color.Transparent;
            chartName.Legends["Legend1"].ForeColor = legendColor;
        }

        #endregion

        #region Methods
        // First call Major Grid, then Minor Grid
        public void XAxisSetLabel(Chart chartName, string familyName, float sizef, FontStyle style, Color textColor, int decimals) 
        {
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font(familyName, sizef, style);
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = textColor;
            chartName.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F" + Convert.ToString(decimals);

            chartName.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = false;
            chartName.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMaxFontSize = 10; 
        }
        public void XAxisSetGrid(Chart chartName,  bool isLog, double logBase, double min, double max, double majorInterval, Color majorColor, int majorLineWidth, bool minorEnabled, ChartDashStyle dashStyle, int minorLineWidth, double intervalFraction, Color minorColor)
        {
            chartName.ChartAreas["ChartArea1"].AxisX.Crossing = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisX.Enabled = AxisEnabled.Auto;

            chartName.ChartAreas["ChartArea1"].AxisX.IsInterlaced = false;
            chartName.ChartAreas["ChartArea1"].AxisX.InterlacedColor = Color.Red;

            chartName.ChartAreas["ChartArea1"].AxisX.IsLogarithmic = isLog;
            chartName.ChartAreas["ChartArea1"].AxisX.LogarithmBase = logBase;

            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = min;
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = max;
            chartName.ChartAreas["ChartArea1"].AxisX.Interval = majorInterval;

            chartName.ChartAreas["ChartArea1"].AxisX.LineColor = majorColor;// Only the X1 axis color at the bottom
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = majorColor;// Sets color for all X axis major grids
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = majorLineWidth;

            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Enabled = minorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineDashStyle = dashStyle;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineWidth = minorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.LineColor = minorColor;
            chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.Interval = majorInterval / intervalFraction;
            //chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.IntervalType = DateTimeIntervalType.Number;
            //chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.IntervalOffset = 0;
            //chartName.ChartAreas["ChartArea1"].AxisX.MinorGrid.IntervalOffsetType = DateTimeIntervalType.Auto;

            chartName.ChartAreas["ChartArea1"].CursorX.Interval = majorInterval;
            chartName.ChartAreas["ChartArea1"].CursorX.AutoScroll = true;
            chartName.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
            chartName.ChartAreas["ChartArea1"].AxisX.ScaleView.Zoomable = true;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = true;
            chartName.ChartAreas["ChartArea1"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
        }

        public void YAxisSetLabelLegendMarkers(Chart chartName, string legendText, string labelMajorFamilyName, float labelMajorEmSize, FontStyle labelMajorStyle, Color labelColor, int labelDecimals)
        {
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

            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font(labelMajorFamilyName, labelMajorEmSize, labelMajorStyle);
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "F" + Convert.ToString(labelDecimals);
            chartName.ChartAreas["ChartArea1"].AxisY.LabelStyle.ForeColor = labelColor;
        }

        public void YAxisSetGrid(Chart chartName, bool isLog, double logBase, double min, double max, double majorInt, Color majorColor, int majorLineWidth, bool minorEnabled, ChartDashStyle dashStyle, int minorLineWidth, double minorIntFrac, Color minorColor) // min and max need to be divisible by 1, 2 or 5
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

            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 1;

            chartName.ChartAreas["ChartArea1"].AxisY.IsLogarithmic = isLog;
            chartName.ChartAreas["ChartArea1"].AxisY.LogarithmBase = logBase;

            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = min;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = max;
            chartName.ChartAreas["ChartArea1"].AxisY.Interval = majorInt;
            chartName.ChartAreas["ChartArea1"].AxisY.LineColor = majorColor;// Only the X1 axis color at the bottom
            chartName.ChartAreas["ChartArea1"].AxisY.LineWidth = majorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = majorColor;// Sets color for all Y axis major grids. Gets behind Y2 Axis, so only shows on zoom/scroll
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = majorLineWidth;

            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.Enabled = minorEnabled;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.Interval = majorInt / minorIntFrac;

            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineDashStyle = dashStyle;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineWidth = minorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisY.MinorGrid.LineColor = minorColor;

            chartName.ChartAreas["ChartArea1"].CursorY.Interval = majorInt;
            chartName.ChartAreas["ChartArea1"].CursorY.AutoScroll = true;
            chartName.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;
            chartName.ChartAreas["ChartArea1"].AxisY.ScaleView.Zoomable = true;
            chartName.ChartAreas["ChartArea1"].AxisY.ScrollBar.Enabled = true;
        }
        public void Y2Axis(Chart chartName, string legendText, string labelMajorFamilyName, float labelMajorEmSize, FontStyle labelMajorStyle, Color labelColor, int labelDecimals, double min, double max, int majorLineWidth, Color majorColor, Color minorColor)// Others are used from the main YAxis
        {
            chartName.ChartAreas["ChartArea1"].AxisY2.MajorGrid.LineWidth = 1;

            int numMajorGridLines = Convert.ToInt32((YAxisMax - YAxisMin) / YAxisMajorInt);
            //Console.WriteLine(numMajorGridLines);
            chartName.Series.Add("Series2");
            chartName.ChartAreas["ChartArea1"].AxisY2.LineWidth = majorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisY2.MajorGrid.LineWidth = majorLineWidth;
            chartName.Series["Series2"].LegendText = legendText;
            chartName.Series["Series2"].ChartType = ChartType;

            chartName.Series["Series2"].MarkerStyle = MarkerStyle.Circle;
            chartName.Series["Series2"].MarkerStep = 1;

            chartName.Series["Series2"].MarkerSize = 3;
            chartName.Series["Series2"].MarkerColor = Color.Orange;
            chartName.Series["Series2"].MarkerBorderWidth = 0;
            chartName.Series["Series2"].MarkerBorderColor = Color.Orange;

            chartName.Series["Series2"].YAxisType = AxisType.Secondary;

            chartName.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Font = new Font(labelMajorFamilyName, labelMajorEmSize, labelMajorStyle);

            chartName.ChartAreas["ChartArea1"].AxisY2.LabelStyle.Format = "F" + Convert.ToString(labelDecimals);
            chartName.ChartAreas["ChartArea1"].AxisY2.LabelStyle.ForeColor = labelColor;

            chartName.ChartAreas["ChartArea1"].AxisY2.Minimum = min;
            chartName.ChartAreas["ChartArea1"].AxisY2.Maximum = max;

            chartName.ChartAreas["ChartArea1"].AxisY2.LineColor = majorColor;// Only the X1 axis color at the bottom
            //chartName.ChartAreas["ChartArea1"].AxisY2.LineWidth = majorLineWidth;
            chartName.ChartAreas["ChartArea1"].AxisY2.MajorGrid.LineColor = majorColor;// Sets color for all X axis major grids
            //chartName.ChartAreas["ChartArea1"].AxisY2.MajorGrid.LineWidth = majorLineWidth;
            
            chartName.ChartAreas["ChartArea1"].AxisY2.MinorGrid.LineColor = minorColor;
            //**********************************************************************************
            // NOTE: Make these values divisible by 1, 2 or 5
            chartName.ChartAreas["ChartArea1"].AxisY2.Interval = (max - min) / numMajorGridLines;
            //**********************************************************************************
            chartName.ChartAreas["ChartArea1"].AxisY2.ScaleView.Zoomable = true;
            chartName.ChartAreas["ChartArea1"].AxisY2.ScrollBar.Enabled = true;
        }

        public void AutoScaleX(System.Windows.Forms.DataVisualization.Charting.Chart chartName)
        {
            chartName.ChartAreas["ChartArea1"].AxisX.Minimum = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisX.Maximum = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisX.MajorGrid.Interval = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisX.Interval = 0;
        }
        public void AutoScaleY(System.Windows.Forms.DataVisualization.Charting.Chart chartName)
        {
            chartName.ChartAreas["ChartArea1"].AxisY.Minimum = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisY.Maximum = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisY.MajorGrid.Interval = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisY.Interval = 0;
        }
        public void AutoScaleY2(System.Windows.Forms.DataVisualization.Charting.Chart chartName)
        {
            chartName.ChartAreas["ChartArea1"].AxisY2.Minimum = double.NaN;
            chartName.ChartAreas["ChartArea1"].AxisY2.Maximum = double.NaN;
        }

        #endregion
    }
}
