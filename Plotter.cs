using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
namespace Log_File_Reader_and_Plotter
{
    public class Plotter
    {
        //ChartSettings cs = new ChartSettings();

        public List<double> X1Values { get; set; } = new List<double>();
        public List<double> X2Values { get; set; } = new List<double>();
        public List<double> Y1Values { get; set; } = new List<double>();
        public List<double> Y2Values { get; set; } = new List<double>();

        /*
        //
        //public string X1FontFamily;
        public string GetX1FontFamily()
        {
            //X1FontFamily = chartSettings.X1Font;
            return ChartSettings.X1Font;
        }

        public float X1FontSize
        {
            get
            {
                return ChartSettings.X1FontSize;
            }
        }

        public float GetX1FontSize()
        {
            //X1FontSize = chartSettings.X1FontSize;
            return ChartSettings.X1FontSize;
        }

        //public FontStyle X1FontStyle;
        public FontStyle GetX1FontStyle()
        {
            //X1FontStyle = chartSettings.X1FontStyle;
            return ChartSettings.X1FontStyle;
        }
        //
        public Color GetX1FontColor()
        {
            return ChartSettings.X1FontColor;
        }
        */
        // 

        public Thread update;
        public int sleep { get; set; } = 50;
        public bool updatedStartedOnce { get; set; } = false;
        public bool plotted { get; set; } = false;

        // How long array is.
        public readonly double[] flsTempArray = new double[300];
        public readonly double[] fliTempArray = new double[300];

        // ComboBox stuff Headers etc.
        //List<string> headerList = new List<string>();

        public string LogFileSaveLocationFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\PhysicsDebugger\";
    }
}
