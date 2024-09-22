using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace Log_File_Reader_and_Plotter
{
    
    public static class ChartSettings
    {
        public static char DefaultDelimiter { get; set; } = ';';
        /// <summary>
        /// X and Y values
        /// </summary>
        public static List<double> X1Values { get; set; } = new List<double>();
        public static List<double> X2Values { get; set; } = new List<double>();
        public static List<double> Y1Values { get; set; } = new List<double>();
        public static List<double> Y2Values { get; set; } = new List<double>();

        /// <summary>
        /// Later stuff
        /// </summary>
        public static Thread update;
        public static int sleep { get; set; } = 50;
        public static bool updatedStartedOnce { get; set; } = false;
        public static bool plotted { get; set; } = false;
        // How long array is.
        public static double[] flsTempArray { get; set; } = new double[300];
        public static double[] fliTempArray { get; set; } = new double[300];
        public static string LogFileSaveLocationFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\PhysicsDebugger\";

        /// <summary>
        /// Some Font size max mins
        /// </summary>
        public static int FontSizeMin { get; } = 4;
        public static int FontSizeMax { get; } = 28;
        public static int FontSizeDivided { get; } = 4;

        // Default values
        /// <summary>
        /// Background
        /// </summary>
        public static Color DefaultBackgroundColor { get; set; } = Color.Black;
        public static Color DefaultLegendColor { get; set; } = Color.White;
        public static bool OtherDefaults { get; set; } = true;
        public static bool X1Defaults { get; set; } = true;
        /// <summary>
        /// X1 defaults
        /// </summary>
        // Font
        public static int X1DefaultFontIndex { get; set; } = 153;
        public static string X1DefaultFontString { get;  set; } = "Microsoft Sans Serif";// Get X1DefaultFont as a string
        public static float X1DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle X1DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color X1DefaultFontColor { get; set; } = Color.White;
        // Logaritmic
        public static bool X1DefaultIsLog { get; set; } = false;
        public static double X1DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color X1DefaultMajorColor { get; set; } = Color.Indigo;
        public static int X1DefaultMajorDecimals { get; set; } = 0;
        public static double X1DefaultMajorInterval { get; set; } = 15;
        public static int X1DefaultMajorLineWidth { get; set; } = 3;
        public static double X1DefaultMin { get; set; } = -45;
        public static double X1DefaultMax { get; set; } = 45;
        // Minor grid
        public static bool X1DefaultMinorEnabled { get; set; } = true;
        public static double X1DefaultMinorIntervalFraction { get; set; } = 5;
        public static int X1DefaultMinorLineWidth { get; set; } = 1;
        public static Color X1DefaultMinorColor { get; set; } = Color.Indigo;
        public static ChartDashStyle X1DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dot;

        public static bool Y1Defaults { get; set; } = true;
        /// <summary>
        /// Y1 defaults
        /// </summary>
        // Marker stuff
        public static MarkerStyle Y1DefaultMarkerStyle { get; set; } = MarkerStyle.Circle;
        public static int Y1DefaultMarkerSize { get; set; } = 3;
        public static Color Y1DefaultMarkerColor { get; set; } = Color.Blue;
        public static int Y1DefaultMarkerBorderSize { get; set; } = 1;
        public static Color Y1DefaultMarkerBorderColor { get; set; } = Color.Blue;

        // Font
        public static int Y1DefaultFontIndex { get; set; } = 153;
        public static string Y1DefaultFontString { get; set; } = "Microsoft Sans Serif";// Get Y1DefaultFont as a string
        public static float Y1DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle Y1DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color Y1DefaultFontColor { get; set; } = Color.Blue;
        // Logaritmic
        public static bool Y1DefaultIsLog { get; set; } = false;
        public static double Y1DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color Y1DefaultMajorColor { get; set; } = Color.Indigo;
        public static int Y1DefaultMajorDecimals { get; set; } = 0;
        public static double Y1DefaultMajorInterval { get; set; } = 1000;
        public static int Y1DefaultMajorLineWidth { get; set; } = 3;
        public static double Y1DefaultMin { get; set; } = -10000;
        public static double Y1DefaultMax { get; set; } = 10000;
        // Minor grid
        public static bool Y1DefaultMinorEnabled { get; set; } = true;
        public static double Y1DefaultMinorIntervalFraction { get; set; } = 5;
        public static int Y1DefaultMinorLineWidth { get; set; } = 1;
        public static Color Y1DefaultMinorColor { get; set; } = Color.Indigo;
        public static ChartDashStyle Y1DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dot;

        public static bool Y2Defaults { get; set; } = true;
        /// <summary>
        /// Y2 defaults
        /// </summary>
        // Marker stuff
        public static MarkerStyle Y2DefaultMarkerStyle { get; set; } = MarkerStyle.Circle;
        public static int Y2DefaultMarkerSize { get; set; } = 3;
        public static Color Y2DefaultMarkerColor { get; set; } = Color.Orange;
        public static int Y2DefaultMarkerBorderSize { get; set; } = 1;
        public static Color Y2DefaultMarkerBorderColor { get; set; } = Color.Orange;
        // Font
        public static int Y2DefaultFontIndex { get; set; } = 153;
        public static string Y2DefaultFontString { get; set; } = "Microsoft Sans Serif";// Get Y2DefaultFont as a string
        public static float Y2DefaultFontSize { get; set; } = 8.25f;
        public static FontStyle Y2DefaultFontStyle { get; set; } = FontStyle.Regular;// Regular Style
        public static Color Y2DefaultFontColor { get; set; } = Color.Orange;
        // Logaritmic
        public static bool Y2DefaultIsLog { get; set; } = false;
        public static double Y2DefaultLogBase { get; set; } = 10;
        // Major grid
        public static Color Y2DefaultMajorColor { get; set; } = Color.Indigo;
        public static int Y2DefaultMajorDecimals { get; set; } = 2;
        public static double Y2DefaultMajorInterval { get; set; } = 0.5;
        public static int Y2DefaultMajorLineWidth { get; set; } = 3;
        public static double Y2DefaultMin { get; set; } = -2;
        public static double Y2DefaultMax { get; set; } = 2;
        // Minor grid
        public static bool Y2DefaultMinorEnabled { get; set; } = true;
        public static double Y2DefaultMinorIntervalFraction { get; set; } = 5;
        public static int Y2DefaultMinorLineWidth { get; set; } = 1;
        public static Color Y2DefaultMinorColor { get; set; } = Color.Indigo;
        public static ChartDashStyle Y2DefaultMinorDashStyle { get; set; } = ChartDashStyle.Dot;

        ///////////////////////////////////////////////////////////////////////////////////

        // Changable values
        public static char Delimiter { get; set; } = DefaultDelimiter;

        /// <summary>
        /// Background
        /// </summary>
        public static Color BackgroundColor { get; set; } = DefaultBackgroundColor;
        public static Color LegendColor { get; set; } = DefaultLegendColor;
        /// <summary>
        /// X1 Axis
        /// </summary>
        // Font
        public static int X1FontIndex { get; set; } = X1DefaultFontIndex;
        public static string X1FontString { get; set; } = X1DefaultFontString;
        public static float X1FontSize { get; set; } = X1DefaultFontSize;
        public static FontStyle X1FontStyle { get; set; } = X1DefaultFontStyle;
        public static Color X1FontColor { get; set; } = X1DefaultFontColor;
        // Logaritmic
        public static bool X1IsLog { get; set; } = X1DefaultIsLog;
        public static double X1LogBase { get; set; } = X1DefaultLogBase;
        // Major Grid
        public static Color X1MajorColor { get; set; } = X1DefaultMajorColor;
        public static int X1MajorDecimals { get; set; } = X1DefaultMajorDecimals;
        public static double X1MajorInterval { get; set; } = X1DefaultMajorInterval;
        public static int X1MajorLineWidth { get; set; } = X1DefaultMajorLineWidth;
        public static double X1Min { get; set; } = X1DefaultMin;
        public static double X1Max { get; set; } = X1DefaultMax;
        // Minor grid
        public static bool X1MinorEnabled { get; set; } = X1DefaultMinorEnabled;
        public static double X1MinorIntervalFraction { get; set; } = X1DefaultMinorIntervalFraction;
        public static int X1MinorLineWidth { get; set; } = X1DefaultMinorLineWidth;
        public static Color X1MinorColor { get; set; } = X1DefaultMinorColor;
        public static ChartDashStyle X1MinorDashStyle { get; set; } = X1DefaultMinorDashStyle;

        /// <summary>
        /// Y1 Axis
        /// </summary>
        // Marker stuff
        public static MarkerStyle Y1MarkerStyle { get; set; } = Y1DefaultMarkerStyle;
        public static int Y1MarkerSize { get; set; } = Y1DefaultMarkerSize;
        public static Color Y1MarkerColor { get; set; } = Y1DefaultMarkerColor;
        public static int Y1MarkerBorderSize { get; set; } = Y1DefaultMarkerBorderSize;
        public static Color Y1MarkerBorderColor { get; set; } = Y1DefaultMarkerBorderColor;

        // Font
        public static int Y1FontIndex { get; set; } = Y1DefaultFontIndex;
        public static string Y1FontString { get; set; } = Y1DefaultFontString;
        public static float Y1FontSize { get; set; } = Y1DefaultFontSize;
        public static FontStyle Y1FontStyle { get; set; } = Y1DefaultFontStyle;
        public static Color Y1FontColor { get; set; } = Y1DefaultFontColor;
        // Logaritmic
        public static bool Y1IsLog { get; set; } = Y1DefaultIsLog;
        public static double Y1LogBase { get; set; } = Y1DefaultLogBase;
        // Major Grid
        public static Color Y1MajorColor { get; set; } = Y1DefaultMajorColor;
        public static int Y1MajorDecimals { get; set; } = Y1DefaultMajorDecimals;
        public static double Y1MajorInterval { get; set; } = Y1DefaultMajorInterval;
        public static int Y1MajorLineWidth { get; set; } = Y1DefaultMajorLineWidth;
        public static double Y1Min { get; set; } = Y1DefaultMin;
        public static double Y1Max { get; set; } = Y1DefaultMax;
        // Minor grid
        public static bool Y1MinorEnabled { get; set; } = Y1DefaultMinorEnabled;
        public static double Y1MinorIntervalFraction { get; set; } = Y1DefaultMinorIntervalFraction;
        public static int Y1MinorLineWidth { get; set; } = Y1DefaultMinorLineWidth;
        public static Color Y1MinorColor { get; set; } = Y1DefaultMinorColor;
        public static ChartDashStyle Y1MinorDashStyle { get; set; } = Y1DefaultMinorDashStyle;

        /// <summary>
        /// Y2 Axis
        /// </summary>

        public static bool Y2Enabled { get; set; } = true;

        // Marker stuff
        public static MarkerStyle Y2MarkerStyle { get; set; } = Y2DefaultMarkerStyle;
        public static int Y2MarkerSize { get; set; } = Y2DefaultMarkerSize;
        public static Color Y2MarkerColor { get; set; } = Y2DefaultMarkerColor;
        public static int Y2MarkerBorderSize { get; set; } = Y2DefaultMarkerBorderSize;
        public static Color Y2MarkerBorderColor { get; set; } = Y2DefaultMarkerBorderColor;
        // Font
        public static int Y2FontIndex { get; set; } = Y2DefaultFontIndex;
        public static string Y2FontString { get; set; } = Y2DefaultFontString;
        public static float Y2FontSize { get; set; } = Y2DefaultFontSize;
        public static FontStyle Y2FontStyle { get; set; } = Y2DefaultFontStyle;
        public static Color Y2FontColor { get; set; } = Y2DefaultFontColor;
        // Logaritmic
        public static bool Y2IsLog { get; set; } = Y2DefaultIsLog;
        public static double Y2LogBase { get; set; } = Y2DefaultLogBase;
        // Major Grid
        public static Color Y2MajorColor { get; set; } = Y2DefaultMajorColor;
        public static int Y2MajorDecimals { get; set; } = Y2DefaultMajorDecimals;
        public static double Y2MajorInterval { get; set; } = Y2DefaultMajorInterval;
        public static int Y2MajorLineWidth { get; set; } = Y2DefaultMajorLineWidth;
        public static double Y2Min { get; set; } = Y2DefaultMin;
        public static double Y2Max { get; set; } = Y2DefaultMax;
        // Minor grid
        public static bool Y2MinorEnabled { get; set; } = Y2DefaultMinorEnabled;
        public static double Y2MinorIntervalFraction { get; set; } = Y2DefaultMinorIntervalFraction;
        public static int Y2MinorLineWidth { get; set; } = Y2DefaultMinorLineWidth;
        public static Color Y2MinorColor { get; set; } = Y2DefaultMinorColor;
        public static ChartDashStyle Y2MinorDashStyle { get; set; } = Y2DefaultMinorDashStyle;
    }
}
