using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Log_File_Reader_and_Plotter
{
    public partial class Plotter1 : Form
    {
        #region Parameters
        CSVReadWrite csv = new CSVReadWrite();

        public List<double> X1Values = new List<double>();
        public List<double> X2Values = new List<double>();
        public List<double> Y1Values = new List<double>();
        public List<double> Y2Values = new List<double>();

        private int XAxisMajorLabelDecimals = 0;
        private double XAxisMin = double.NaN;
        private double XAxisMax = double.NaN;
        private double XAxisMajorInterval = 0;
        private bool XAxisMinorEnabled = false;
        private double XAxisMinorIntervalFraction = 0;

        private int Y1AxisMajorLabelDecimals = 0;
        private double Y1AxisMin = double.NaN;
        private double Y1AxisMax = double.NaN;
        private double Y1AxisMajorInterval = 0;
        private bool Y1AxisMinorEnabled;
        //private double Y1AxisMinorInterval = 0;
        private double Y1AxisMinorIntervalFraction = 0;

        //**********************************************************************************
        private int Y2AxisMajorLabelDecimals;
        // NOTE: Make these values divisible by 1, 2 or 5
        // chartName.ChartAreas["ChartArea1"].AxisY2.Interval = (Y2AxisMin - Y2AxisMax) / numMajorGridLines;
        private double Y2AxisMin;
        private double Y2AxisMax;
        //**********************************************************************************

        private Thread update;
        private int sleep = 50;
        private bool updatedStartedOnce = false;
        private bool plotted = false;

        // How long array is.
        private readonly double[] flsTempArray = new double[300];
        private readonly double[] fliTempArray = new double[300];

        // ComboBox stuff Headers etc.
        //List<string> headerList = new List<string>();

        public static string LogFileSaveLocationFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\PhysicsDebugger\";

        public Plotter1()
        {
            InitializeComponent();


            //ComboBox Stuff
            /*
            comboBox1.Text = "Select X axis item:";
            comboBox2.Text = "Select Y axis item:";
            comboBox3.Text = "Select Y2 axis item:";
            */
            /*
            //TimeIntervalLineChart stuff
            update = new Thread(new ThreadStart(getData));
            update.IsBackground = true;
            */
        }

        #endregion


        #region Properties
        public string initialDir = LogFileSaveLocationFolder;//Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);//@"C:\Users\";
        public string filePath = LogFileSaveLocationFolder;//Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        /*public List<string> fileLinesList;
        public List<LogData> infoList = new List<LogData>();
        */



        #endregion
        /*
        public TestChartPage()
        {
            InitializeComponent();
        }

        #region Methods

        private void ReadCSVFile()
        {
            // Open file, create Class objects, & set properties for each pbject

            using (StreamReader reader = new StreamReader(fileName))
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",// Changes the delimiter from , to ;
                    //AllowComments = true,// allows comment with the Comment. Default #
                    //Comment = '/',//# is the default comment
                    //HasHeaderRecord = false,// Don't expect header
                };

                using (CsvReader csv = new CsvReader(reader, csvConfig))
                {
                    infoList = csv.GetRecords<LogData>().ToList();
                }
                GetSummaryInfo();
            }
        }

        private void GetSummaryInfo()
        {

        }
        */

        #region Methods

        /* ComboBox Stuff
         public List<string> GetHeaders()
        {
            return headerList;
        }
         */

        /* TimeIntervalLineChart stuff
        private void getData()
        {
            while (true)
            {


                if (chart1.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { TemperatureSeries(); });
                }
                else
                {
                    //....
                }
                Thread.Sleep(sleep);
            }
        }

        private void TemperatureSeries()
        {
            flsTempArray[flsTempArray.Length - 1] = Math.Round(LiveData.FL_TreadTemperature, 10);//Bigger round value gives smoother drawing.
            fliTempArray[fliTempArray.Length - 1] = Math.Round(LiveData.FL_InnerTemperature, 10);

            Array.Copy(flsTempArray, 1, flsTempArray, 0, flsTempArray.Length - 1);
            Array.Copy(fliTempArray, 1, fliTempArray, 0, fliTempArray.Length - 1);

            chart1.Series["Series1"].Points.Clear();

            for (int i = 0; i < flsTempArray.Length - 1; ++i)
            {
                chart1.Series["Series1"].Points.AddY(flsTempArray[i]);
            }

            chart1.Series["Series2"].Points.Clear();

            for (int i = 0; i < fliTempArray.Length - 1; ++i)
            {
                chart1.Series["Series2"].Points.AddY(fliTempArray[i]);
            }
        }
        */


        private void ClearComboBoxes()
        {
            comboBox1.DataSource = null;
            comboBox2.DataSource = null;
            comboBox3.DataSource = null;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
        }

        private void X1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues()
        {
            if (comboBox1.SelectedItem == csv.header001) // Race Time
            {
                X1Values = csv.dVals001;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header001 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header002) // Tire Travel Speed
            {
                X1Values = csv.dVals002;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header002 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header003) // Angular Velocity
            {
                X1Values = csv.dVals003;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header003 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header004) // Vertical Load
            {
                X1Values = csv.dVals004;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header004 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header005) // Vertical Deflection
            {
                X1Values = csv.dVals005;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header005 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header006) // Loaded Radius
            {
                X1Values = csv.dVals006;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header006 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header007) // Effective Radius
            {
                X1Values = csv.dVals007;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header007 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header008)// Contact Length
            {
                X1Values = csv.dVals008;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header008 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header009) // Brake Torque
            {
                X1Values = csv.dVals009;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header009 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header010) // Max Brake Torque
            {
                X1Values = csv.dVals010;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header010 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header011) // Steer Angle
            {
                X1Values = csv.dVals011;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header011 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header012) // Camber Angle
            {
                X1Values = csv.dVals012;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header012 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header013) // Lateral Load
            {
                X1Values = csv.dVals013;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header013 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header014) // Slip Angle
            {
                X1Values = csv.dVals014;
                textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header014 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header015) // Lateral Friction
            {
                X1Values = csv.dVals015;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header015 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header016) // Lateral Slip Speed
            {
                X1Values = csv.dVals016;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header016 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header017) // Longitudinal Load
            {
                X1Values = csv.dVals017;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header017 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header018) // Slip Ratio
            {
                X1Values = csv.dVals018;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header018 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header019) // Longitudinal Friction
            {
                X1Values = csv.dVals019;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header019 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header020) // Longitudinal Slip Speed
            {
                X1Values = csv.dVals020;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header020 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header021) // Tread Temperature
            {
                X1Values = csv.dVals021;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header021 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header022) // Inner Temperature
            {
                X1Values = csv.dVals022;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header022 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header023) // Total Friction
            {
                X1Values = csv.dVals023;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header023 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header024) // Total Friction Angle
            {
                X1Values = csv.dVals024;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header024 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header025)
            {
                X1Values = csv.dVals025;
                textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header025 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header026)
            {
                X1Values = csv.dVals026;
                textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header026 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header027)
            {
                X1Values = csv.dVals027;
                textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header027 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header028)
            {
                X1Values = csv.dVals028;
                textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header028 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header029)
            {
                X1Values = csv.dVals029;
                textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header029 + "\r\n");
            }
            else if (comboBox1.SelectedItem == csv.header030)
            {
                X1Values = csv.dVals030;
                textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header030 + "\r\n");
            }
            else
            {
                X1Values = csv.dVals001;
                textBox2.AppendText("No item found. Default " + csv.header001 + " chosen for X1" + "\r\n");
            }
        }

        private void Y1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues()
        {
            if (comboBox2.Text == csv.header001)
            {
                Y1Values = csv.dVals001;
                //textBox2.AppendText(csv.header001 + " values selected" + "\r\n");
            }
            else if (comboBox2.Text == csv.header002)
            {
                Y1Values = csv.dVals002;
            }
            else if (comboBox2.Text == csv.header003)
            {
                Y1Values = csv.dVals003;
            }
            else if (comboBox2.Text == csv.header004)
            {
                Y1Values = csv.dVals004;
            }
            else if (comboBox2.Text == csv.header005)
            {
                Y1Values = csv.dVals005;
            }
            else if (comboBox2.Text == csv.header006)
            {
                Y1Values = csv.dVals006;
            }
            else if (comboBox2.Text == csv.header007)
            {
                Y1Values = csv.dVals007;
            }
            else if (comboBox2.Text == csv.header008)
            {
                Y1Values = csv.dVals008;
            }
            else if (comboBox2.Text == csv.header009)
            {
                Y1Values = csv.dVals009;
            }
            else if (comboBox2.Text == csv.header010)
            {
                Y1Values = csv.dVals010;
            }
            else if (comboBox2.Text == csv.header011)
            {
                Y1Values = csv.dVals011;
            }
            else if (comboBox2.Text == csv.header012)
            {
                Y1Values = csv.dVals012;
            }
            else if (comboBox2.Text == csv.header013)
            {
                Y1Values = csv.dVals013;
            }
            else if (comboBox2.Text == csv.header014)
            {
                Y1Values = csv.dVals014;
            }
            else if (comboBox2.Text == csv.header015)
            {
                Y1Values = csv.dVals015;
            }
            else if (comboBox2.Text == csv.header016)
            {
                Y1Values = csv.dVals016;
            }
            else if (comboBox2.Text == csv.header017)
            {
                Y1Values = csv.dVals017;
            }
            else if (comboBox2.Text == csv.header018)
            {
                Y1Values = csv.dVals018;
            }
            else if (comboBox2.Text == csv.header019)
            {
                Y1Values = csv.dVals019;
            }
            else if (comboBox2.Text == csv.header020)
            {
                Y1Values = csv.dVals020;
            }
            else if (comboBox2.Text == csv.header021)
            {
                Y1Values = csv.dVals021;
            }
            else if (comboBox2.Text == csv.header022)
            {
                Y1Values = csv.dVals022;
            }
            else if (comboBox2.Text == csv.header023)
            {
                Y1Values = csv.dVals023;
            }
            else if (comboBox2.Text == csv.header024)
            {
                Y1Values = csv.dVals024;
            }
            else if (comboBox2.Text == csv.header025)
            {
                Y1Values = csv.dVals025;
            }
            else if (comboBox2.Text == csv.header026)
            {
                Y1Values = csv.dVals026;
            }
            else if (comboBox2.Text == csv.header027)
            {
                Y1Values = csv.dVals027;
            }
            else if (comboBox2.Text == csv.header028)
            {
                Y1Values = csv.dVals028;
            }
            else if (comboBox2.Text == csv.header029)
            {
                Y1Values = csv.dVals029;
            }
            else if (comboBox2.Text == csv.header030)
            {
                Y1Values = csv.dVals030;
            }
            else
            {
                Y1Values = csv.dVals002;
                textBox2.AppendText("No item found. Default " + csv.header002 + " chosen for Y1" + "\r\n");
            }
        }
        private void Y2CheckIfCBSelectionsTextIsHeaderAndChooseItsValues()
        {
            if (comboBox3.Text == csv.header001)
            {
                Y2Values = csv.dVals001;
                //textBox2.AppendText(csv.header001 + " values selected" + "\r\n");
            }
            else if (comboBox3.Text == csv.header002)
            {
                Y2Values = csv.dVals002;
            }
            else if (comboBox3.Text == csv.header003)
            {
                Y2Values = csv.dVals003;
            }
            else if (comboBox3.Text == csv.header004)
            {
                Y2Values = csv.dVals004;
            }
            else if (comboBox3.Text == csv.header005)
            {
                Y2Values = csv.dVals005;
            }
            else if (comboBox3.Text == csv.header006)
            {
                Y2Values = csv.dVals006;
            }
            else if (comboBox3.Text == csv.header007)
            {
                Y2Values = csv.dVals007;
            }
            else if (comboBox3.Text == csv.header008)
            {
                Y2Values = csv.dVals008;
            }
            else if (comboBox3.Text == csv.header009)
            {
                Y2Values = csv.dVals009;
            }
            else if (comboBox3.Text == csv.header010)
            {
                Y2Values = csv.dVals010;
            }
            else if (comboBox3.Text == csv.header011)
            {
                Y2Values = csv.dVals011;
            }
            else if (comboBox3.Text == csv.header012)
            {
                Y2Values = csv.dVals012;
            }
            else if (comboBox3.Text == csv.header013)
            {
                Y2Values = csv.dVals013;
            }
            else if (comboBox3.Text == csv.header014)
            {
                Y2Values = csv.dVals014;
            }
            else if (comboBox3.Text == csv.header015)
            {
                Y2Values = csv.dVals015;
            }
            else if (comboBox3.Text == csv.header016)
            {
                Y2Values = csv.dVals016;
            }
            else if (comboBox3.Text == csv.header017)
            {
                Y2Values = csv.dVals017;
            }
            else if (comboBox3.Text == csv.header018)
            {
                Y2Values = csv.dVals018;
            }
            else if (comboBox3.Text == csv.header019)
            {
                Y2Values = csv.dVals019;
            }
            else if (comboBox3.Text == csv.header020)
            {
                Y2Values = csv.dVals020;
            }
            else if (comboBox3.Text == csv.header021)
            {
                Y2Values = csv.dVals021;
            }
            else if (comboBox3.Text == csv.header022)
            {
                Y2Values = csv.dVals022;
            }
            else if (comboBox3.Text == csv.header023)
            {
                Y2Values = csv.dVals023;
            }
            else if (comboBox3.Text == csv.header024)
            {
                Y2Values = csv.dVals024;
            }
            else if (comboBox3.Text == csv.header025)
            {
                Y2Values = csv.dVals025;
            }
            else if (comboBox3.Text == csv.header026)
            {
                Y2Values = csv.dVals026;
            }
            else if (comboBox3.Text == csv.header027)
            {
                Y2Values = csv.dVals027;
            }
            else if (comboBox3.Text == csv.header028)
            {
                Y2Values = csv.dVals028;
            }
            else if (comboBox3.Text == csv.header029)
            {
                Y2Values = csv.dVals029;
            }
            else if (comboBox3.Text == csv.header030)
            {
                Y2Values = csv.dVals030;
            }
            else
            {
                Y2Values = csv.dVals003;
                textBox2.AppendText("No item found. Default " + csv.header003 + " chosen for Y2" + "\r\n");
            }
        }

        private void X1AxisDefaults()
        {
            if (comboBox1.Text == "Race Time")
            {
                XAxisMax = double.NaN;
                XAxisMin = 0;
                XAxisMajorInterval = 1000;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 10;
            }
            else if (comboBox1.Text == "Tire Travel Speed")
            {
                XAxisMax = 400;
                XAxisMin = -XAxisMax / 2;
                XAxisMajorInterval = 100;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Angular Velocity")
            {
                XAxisMax = 400;
                XAxisMin = -XAxisMax / 2;
                XAxisMajorInterval = 100;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Vertical Load")
            {
                XAxisMax = 10000;
                XAxisMin = 0;
                XAxisMajorInterval = 1000;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Vertical Deflection")
            {
                XAxisMax = 0.15;
                XAxisMin = 0;
                XAxisMajorInterval = 0.03;
                XAxisMajorLabelDecimals = 3;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Loaded Radius")
            {
                XAxisMax = 0.5;
                XAxisMin = 0;
                XAxisMajorInterval = 0.1;
                XAxisMajorLabelDecimals = 3;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Effective Radius")
            {
                XAxisMax = 0.5;
                XAxisMin = 0;
                XAxisMajorInterval = 0.1;
                XAxisMajorLabelDecimals = 3;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Contact Length")
            {
                XAxisMax = 0.5;
                XAxisMin = 0;
                XAxisMajorInterval = 0.1;
                XAxisMajorLabelDecimals = 3;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Brake Torque")
            {
                XAxisMax = 5000;
                XAxisMin = 0;
                XAxisMajorInterval = 500;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Max Brake Torque")
            {
                XAxisMax = 5000;
                XAxisMin = 0;
                XAxisMajorInterval = 500;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Steer Angle")
            {
                // Default Axis values
                XAxisMax = 45;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 15;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Camber Angle")
            {
                XAxisMax = 10;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 4;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Lateral Load")
            {
                XAxisMax = 10000;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 1000;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Slip Angle")
            {
                XAxisMax = 45;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 15;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Lateral Friction")
            {
                XAxisMax = 2;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 0.5;
                XAxisMajorLabelDecimals = 2;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Lateral Slip Speed")
            {
                XAxisMax = 20;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 5;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Longitudinal Load")
            {
                XAxisMax = 10000;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 1000;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Slip Ratio")
            {
                XAxisMax = 1;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 0.2;
                XAxisMajorLabelDecimals = 2;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Longitudinal Friction")
            {
                XAxisMax = 2;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 0.5;
                XAxisMajorLabelDecimals = 2;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Longitudinal Slip Speed")
            {
                XAxisMax = 20;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 5;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Tread Temperature")
            {
                XAxisMax = 380;
                XAxisMin = -20;
                XAxisMajorInterval = 20;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Inner Temperature")
            {
                XAxisMax = 380;
                XAxisMin = -20;
                XAxisMajorInterval = 20;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Total Friction")
            {
                XAxisMax = 2;
                XAxisMin = -XAxisMax;
                XAxisMajorInterval = 0.5;
                XAxisMajorLabelDecimals = 2;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            else if (comboBox1.Text == "Total Friction Angle")
            {
                XAxisMax = 360;
                XAxisMin = 0;
                XAxisMajorInterval = 90;
                XAxisMajorLabelDecimals = 0;
                XAxisMinorEnabled = true;
                XAxisMinorIntervalFraction = 5;
            }
            /*
            else if (comboBox1.Text == "")
            {

            }*/
            else
            {
                // Defaults auto scale
                XAxisMax = double.NaN;
                XAxisMin = double.NaN;
                XAxisMajorInterval = 0;
                XAxisMajorLabelDecimals = 2;
                XAxisMinorEnabled = false;
                XAxisMinorIntervalFraction = 1;
            }
            // Debug shit
            /*
            textBox2.AppendText(comboBox1.SelectedItem.ToString() + " equals " + "Slip Angle" + "\r\n");
            textBox2.AppendText(XAxisMax.ToString() + "\r\n");
            textBox2.AppendText(XAxisMin.ToString() + "\r\n");
            textBox2.AppendText(XAxisMajorInterval.ToString() + "\r\n");
            textBox2.AppendText(XAxisMajorLabelDecimals.ToString() + "\r\n");
            textBox2.AppendText(XAxisMinorEnabled.ToString() + "\r\n");
            textBox2.AppendText(XAxisMinorIntervalFraction.ToString() + "\r\n");
            */
        }

        private void Y1AxisDefaults()
        {
            if (comboBox2.Text == "Race Time")
            {
                Y1AxisMax = double.NaN;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 1000;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 10;
            }
            else if (comboBox2.Text == "Tire Travel Speed")
            {
                Y1AxisMax = 400;
                Y1AxisMin = -Y1AxisMax / 2;
                Y1AxisMajorInterval = 100;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Angular Velocity")
            {
                Y1AxisMax = 400;
                Y1AxisMin = -Y1AxisMax / 2;
                Y1AxisMajorInterval = 100;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Vertical Load")
            {
                Y1AxisMax = 10000;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 1000;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Vertical Deflection")
            {
                Y1AxisMax = 0.15;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 0.03;
                Y1AxisMajorLabelDecimals = 3;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Loaded Radius")
            {
                Y1AxisMax = 0.5;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 0.1;
                Y1AxisMajorLabelDecimals = 3;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Effective Radius")
            {
                Y1AxisMax = 0.5;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 0.1;
                Y1AxisMajorLabelDecimals = 3;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Contact Length")
            {
                Y1AxisMax = 0.5;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 0.1;
                Y1AxisMajorLabelDecimals = 3;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Brake Torque")
            {
                Y1AxisMax = 5000;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 500;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Max Brake Torque")
            {
                Y1AxisMax = 5000;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 500;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Steer Angle")
            {
                // Default Axis values
                Y1AxisMax = 45;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 15;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Camber Angle")
            {
                Y1AxisMax = 10;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 4;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Lateral Load")
            {
                Y1AxisMax = 10000;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 1000;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Slip Angle")
            {
                Y1AxisMax = 45;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 15;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Lateral Friction")
            {
                Y1AxisMax = 2;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 0.5;
                Y1AxisMajorLabelDecimals = 2;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Lateral Slip Speed")
            {
                Y1AxisMax = 20;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 5;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Longitudinal Load")
            {
                Y1AxisMax = 10000;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 1000;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Slip Ratio")
            {
                Y1AxisMax = 1;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 0.2;
                Y1AxisMajorLabelDecimals = 2;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Longitudinal Friction")
            {
                Y1AxisMax = 2;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 0.5;
                Y1AxisMajorLabelDecimals = 2;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Longitudinal Slip Speed")
            {
                Y1AxisMax = 20;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 5;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Tread Temperature")
            {
                Y1AxisMax = 380;
                Y1AxisMin = -20;
                Y1AxisMajorInterval = 20;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Inner Temperature")
            {
                Y1AxisMax = 380;
                Y1AxisMin = -20;
                Y1AxisMajorInterval = 20;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Total Friction")
            {
                Y1AxisMax = 2;
                Y1AxisMin = -Y1AxisMax;
                Y1AxisMajorInterval = 0.5;
                Y1AxisMajorLabelDecimals = 2;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            else if (comboBox2.Text == "Total Friction Angle")
            {
                Y1AxisMax = 360;
                Y1AxisMin = 0;
                Y1AxisMajorInterval = 90;
                Y1AxisMajorLabelDecimals = 0;
                Y1AxisMinorEnabled = true;
                Y1AxisMinorIntervalFraction = 5;
            }
            /*
            else if (comboBox2.Text == "")
            {

            }*/
            else
            {
                // Defaults auto scale
                Y1AxisMax = double.NaN;
                Y1AxisMin = double.NaN;
                Y1AxisMajorInterval = 0;
                Y1AxisMajorLabelDecimals = 2;
                Y1AxisMinorEnabled = false;
                Y1AxisMinorIntervalFraction = 1;
            }
        }

        private void Y2AxisDefaults()
        {
            if (comboBox3.Text == "Race Time")
            {
                Y2AxisMax = double.NaN;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Tire Travel Speed")
            {
                Y2AxisMax = 400;
                Y2AxisMin = -Y2AxisMax / 2;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Angular Velocity")
            {
                Y2AxisMax = 400;
                Y2AxisMin = -Y2AxisMax / 2;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Vertical Load")
            {
                Y2AxisMax = 10000;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Vertical Deflection")
            {
                Y2AxisMax = 0.15;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 4;
            }
            else if (comboBox3.Text == "Loaded Radius")
            {
                Y2AxisMax = 0.5;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 4;
            }
            else if (comboBox3.Text == "Effective Radius")
            {
                Y2AxisMax = 0.5;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 4;
            }
            else if (comboBox3.Text == "Contact Length")
            {
                Y2AxisMax = 0.5;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 4;
            }
            else if (comboBox3.Text == "Brake Torque")
            {
                Y2AxisMax = 5000;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Max Brake Torque")
            {
                Y2AxisMax = 5000;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Steer Angle")
            {
                Y2AxisMax = 45;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Camber Angle")
            {
                Y2AxisMax = 10;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Lateral Load")
            {
                Y2AxisMax = 10000;
                Y2AxisMin = Y2AxisMax;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Slip Angle")
            {
                Y2AxisMax = 45;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Lateral Friction")
            {
                Y2AxisMax = 2;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 2;
            }
            else if (comboBox3.Text == "Lateral Slip Speed")
            {
                Y2AxisMax = 20;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Longitudinal Load")
            {
                Y2AxisMax = 10000;
                Y2AxisMin = Y2AxisMax;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Slip Ratio")
            {
                Y2AxisMax = 1;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 2;
            }
            else if (comboBox3.Text == "Longitudinal Friction")
            {
                Y2AxisMax = 2;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 2;
            }
            else if (comboBox3.Text == "Longitudinal Slip Speed")
            {
                Y2AxisMax = 20;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Tread Temperature")
            {
                Y2AxisMax = 380;
                Y2AxisMin = -20;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Inner Temperature")
            {
                Y2AxisMax = 380;
                Y2AxisMin = -20;
                Y2AxisMajorLabelDecimals = 0;
            }
            else if (comboBox3.Text == "Total Friction")
            {
                Y2AxisMax = 2;
                Y2AxisMin = -Y2AxisMax;
                Y2AxisMajorLabelDecimals = 2;
            }
            else if (comboBox3.Text == "Total Friction Angle")
            {
                Y2AxisMax = 360;
                Y2AxisMin = 0;
                Y2AxisMajorLabelDecimals = 0;
            }
            /*
            else if (comboBox3.Text == "")
            {

            }*/
            else
            {
                // Defaults auto scale
                Y2AxisMax = double.NaN;
                Y2AxisMin = double.NaN;
                Y2AxisMajorLabelDecimals = 2;
            }
        }
        private void PlotToChart()
        {
            if (plotted == false)
            {
                //SelectHeadersComboBox cb1 = new SelectHeadersComboBox(comboBox1);

                //cb1.GetSetHeaders(comboBox1);

                PointChart pointChart = new PointChart(chart1);
                pointChart.XAxis(chart1, "Microsoft Sans Serif", 7f, FontStyle.Regular, Color.Black, XAxisMajorLabelDecimals, XAxisMin, XAxisMax, XAxisMajorInterval, XAxisMinorEnabled, ChartDashStyle.Dash, XAxisMinorIntervalFraction);
                pointChart.YAxis(chart1, comboBox2.Text, "Microsoft Sans Serif", 7f, FontStyle.Regular, Y1AxisMajorLabelDecimals, Y1AxisMin, Y1AxisMax, Y1AxisMajorInterval, Y1AxisMinorEnabled, Y1AxisMinorIntervalFraction);
                pointChart.Y2Axis(chart1, comboBox3.Text, "Microsoft Sans Serif", 7f, FontStyle.Regular, Y2AxisMajorLabelDecimals, Y2AxisMin, Y2AxisMax);

                //pointChart.AutoScaleX(chart1);
                //pointChart.AutoScaleY(chart1);
                //pointChart.AutoScaleY2(chart1);

                chart1.Series["Series1"].Points.DataBindXY(X1Values, Y1Values);
                chart1.Series["Series2"].Points.DataBindXY(X1Values, Y2Values); //1 time, 14 slip angle, 15 lateral friction, 21 tread, 22 inner, 23 total friction
                plotted = true;
                plotToChart1.Text = "Clear chart";
                //textBox2.AppendText("what?" + csv.header001);
                loadCSVButton.Hide();
            }
            else if (plotted == true)
            {
                //csv.ClearListValues();
                //ClearComboBoxes();
                chart1.Series.Clear();
                chart1.Series.Add("Series1");

                plotted = false;
                plotToChart1.Text = "Plot to chart";
                loadCSVButton.Show();
            }
        }

        #endregion

        #region Form buttons etc.

        private void loadCSVButton_Click(object sender, EventArgs e)
        {

        }

        private void PrintToTextBox()
        {
            textBox1.Text = CSVReadWrite.fileText;
        }

        private void Plotter1_Load(object sender, EventArgs e)
        {
            updatedStartedOnce = false;
        }

        private void Plotter1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (updatedStartedOnce == true)
            {
                update.Suspend();
            }
            updatedStartedOnce = false;
        }
        #endregion

        private void plotToChart_Click(object sender, EventArgs e)
        {
            X1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            X1AxisDefaults();
            Y1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            Y1AxisDefaults();
            Y2CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            Y2AxisDefaults();
            PlotToChart();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.AppendText("X axis: " + comboBox1.Text + "\r\n");
            X1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            X1AxisDefaults();
            if (plotted == true)
            {
                PlotToChart();
                PlotToChart();
            }
            /*
            textBox1.Clear();
            foreach (double value in X1Values)
            {
                textBox1.AppendText(value.ToString());
            }*/
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.AppendText("Y1 axis: " + comboBox2.Text + "\r\n");
            Y1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            Y1AxisDefaults();
            if (plotted == true)
            {
                PlotToChart();
                PlotToChart();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.AppendText("Y2 axis: " + comboBox3.Text + "\r\n");
            Y2CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            Y2AxisDefaults();
            if (plotted == true)
            {
                PlotToChart();
                PlotToChart();
            }
        }

        private void plotToChart1_Click(object sender, EventArgs e)
        {
            X1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            X1AxisDefaults();
            Y1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            Y1AxisDefaults();
            Y2CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            Y2AxisDefaults();
            PlotToChart();
        }

        private void loadCSVButton_Click_1(object sender, EventArgs e)
        {
            //ClearComboBoxes();

            csv.ReadFile(initialDir);
            /*
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = initialDir;
            ofd.Filter = "CSV files (*csv)|*.csv";

            //Show the open file dialog to allow user to select file
            DialogResult result = ofd.ShowDialog();

            if(result == DialogResult.OK)
            {
                fileName = ofd.FileName;

                ReadCSVFile();
            }
            */

            PrintToTextBox();
            textBox2.Text = filePath + CSVReadWrite.fileName + csv.header021 + "\r\n";
            ClearComboBoxes();
            foreach (string header in csv.headersList)
            {
                comboBox1.Items.Add(header);
                comboBox2.Items.Add(header);
                comboBox3.Items.Add(header);
            }

            X1Values = csv.dVals014;
            comboBox1.SelectedItem = csv.header014;
            Y1Values = csv.dVals013;
            comboBox2.SelectedItem = csv.header013;
            Y2Values = csv.dVals015;
            comboBox3.SelectedItem = csv.header015;
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
