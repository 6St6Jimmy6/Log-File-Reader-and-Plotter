using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Log_File_Reader_and_Plotter
{
    public partial class FormPlotter : Form
    {
        #region Parameters
        private readonly CSVReadWrite csv = new CSVReadWrite();

        private Plotter plotter = new Plotter();

        

        public static int ChartSettingsOpen = 0; // Deactivates Chart Settings button if other than 0

        public FormPlotter()
        {
            InitializeComponent();
            chart1.ChartAreas["ChartArea1"].BackColor = ChartSettings.BackgroundColor;
            chart1.BackColor = ChartSettings.BackgroundColor;
            plotToChart1.Visible = false;
            /*
            //TimeIntervalLineChart stuff
            update = new Thread(new ThreadStart(getData));
            update.IsBackground = true;
            */
        }

        #endregion


        #region Properties

        #endregion

        #region Methods

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
            if (comboBox1.Text == csv.header001) // Race Time
            {
                plotter.X1Values = csv.dVals001;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header001 + "\r\n");
            }
            else if (comboBox1.Text == csv.header002) // Tire Travel Speed
            {
                plotter.X1Values = csv.dVals002;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header002 + "\r\n");
            }
            else if (comboBox1.Text == csv.header003) // Angular Velocity
            {
                plotter.X1Values = csv.dVals003;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header003 + "\r\n");
            }
            else if (comboBox1.Text == csv.header004) // Vertical Load
            {
                plotter.X1Values = csv.dVals004;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header004 + "\r\n");
            }
            else if (comboBox1.Text == csv.header005) // Vertical Deflection
            {
                plotter.X1Values = csv.dVals005;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header005 + "\r\n");
            }
            else if (comboBox1.Text == csv.header006) // Loaded Radius
            {
                plotter.X1Values = csv.dVals006;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header006 + "\r\n");
            }
            else if (comboBox1.Text == csv.header007) // Effective Radius
            {
                plotter.X1Values = csv.dVals007;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header007 + "\r\n");
            }
            else if (comboBox1.Text == csv.header008)// Contact Length
            {
                plotter.X1Values = csv.dVals008;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header008 + "\r\n");
            }
            else if (comboBox1.Text == csv.header009) // Brake Torque
            {
                plotter.X1Values = csv.dVals009;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header009 + "\r\n");
            }
            else if (comboBox1.Text == csv.header010) // Max Brake Torque
            {
                plotter.X1Values = csv.dVals010;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header010 + "\r\n");
            }
            else if (comboBox1.Text == csv.header011) // Steer Angle
            {
                plotter.X1Values = csv.dVals011;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header011 + "\r\n");
            }
            else if (comboBox1.Text == csv.header012) // Camber Angle
            {
                plotter.X1Values = csv.dVals012;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header012 + "\r\n");
            }
            else if (comboBox1.Text == csv.header013) // Lateral Load
            {
                plotter.X1Values = csv.dVals013;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header013 + "\r\n");
            }
            else if (comboBox1.Text == csv.headersList[13]) // Slip Angle
            {
                plotter.X1Values = csv.dVals014;
                //textBox2.AppendText(comboBox1.Text + " is equal " + csv.header014 + "\r\n");
            }
            else if (comboBox1.Text == csv.header015) // Lateral Friction
            {
                plotter.X1Values = csv.dVals015;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header015 + "\r\n");
            }
            else if (comboBox1.Text == csv.header016) // Lateral Slip Speed
            {
                plotter.X1Values = csv.dVals016;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header016 + "\r\n");
            }
            else if (comboBox1.Text == csv.header017) // Longitudinal Load
            {
                plotter.X1Values = csv.dVals017;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header017 + "\r\n");
            }
            else if (comboBox1.Text == csv.header018) // Slip Ratio
            {
                plotter.X1Values = csv.dVals018;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header018 + "\r\n");
            }
            else if (comboBox1.Text == csv.header019) // Longitudinal Friction
            {
                plotter.X1Values = csv.dVals019;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header019 + "\r\n");
            }
            else if (comboBox1.Text == csv.header020) // Longitudinal Slip Speed
            {
                plotter.X1Values = csv.dVals020;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header020 + "\r\n");
            }
            else if (comboBox1.Text == csv.header021) // Tread Temperature
            {
                plotter.X1Values = csv.dVals021;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header021 + "\r\n");
            }
            else if (comboBox1.Text == csv.header022) // Inner Temperature
            {
                plotter.X1Values = csv.dVals022;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header022 + "\r\n");
            }
            else if (comboBox1.Text == csv.header023) // Total Friction
            {
                plotter.X1Values = csv.dVals023;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header023 + "\r\n");
            }
            else if (comboBox1.Text == csv.header024) // Total Friction Angle
            {
                plotter.X1Values = csv.dVals024;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header024 + "\r\n");
            }
            else if (comboBox1.Text == csv.header025)
            {
                plotter.X1Values = csv.dVals025;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header025 + "\r\n");
            }
            else if (comboBox1.Text == csv.header026)
            {
                plotter.X1Values = csv.dVals026;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header026 + "\r\n");
            }
            else if (comboBox1.Text == csv.header027)
            {
                plotter.X1Values = csv.dVals027;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header027 + "\r\n");
            }
            else if (comboBox1.Text == csv.header028)
            {
                plotter.X1Values = csv.dVals028;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header028 + "\r\n");
            }
            else if (comboBox1.Text == csv.header029)
            {
                plotter.X1Values = csv.dVals029;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header029 + "\r\n");
            }
            else if (comboBox1.Text == csv.header030)
            {
                plotter.X1Values = csv.dVals030;
                //textBox2.AppendText(comboBox1.SelectedItem + " is equal " + csv.header030 + "\r\n");
            }
            else
            {
                plotter.X1Values = csv.dVals001;
                //textBox2.AppendText("No item found. Default " + csv.header001 + " chosen for X1" + "\r\n");
            }
        }
        private void Y1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues()
        {
            if (comboBox2.Text == csv.header001)
            {
                plotter.Y1Values = csv.dVals001;
                //textBox2.AppendText(csv.header001 + " values selected" + "\r\n");
            }
            else if (comboBox2.Text == csv.header002)
            {
                plotter.Y1Values = csv.dVals002;
            }
            else if (comboBox2.Text == csv.header003)
            {
                plotter.Y1Values = csv.dVals003;
            }
            else if (comboBox2.Text == csv.header004)
            {
                plotter.Y1Values = csv.dVals004;
            }
            else if (comboBox2.Text == csv.header005)
            {
                plotter.Y1Values = csv.dVals005;
            }
            else if (comboBox2.Text == csv.header006)
            {
                plotter.Y1Values = csv.dVals006;
            }
            else if (comboBox2.Text == csv.header007)
            {
                plotter.Y1Values = csv.dVals007;
            }
            else if (comboBox2.Text == csv.header008)
            {
                plotter.Y1Values = csv.dVals008;
            }
            else if (comboBox2.Text == csv.header009)
            {
                plotter.Y1Values = csv.dVals009;
            }
            else if (comboBox2.Text == csv.header010)
            {
                plotter.Y1Values = csv.dVals010;
            }
            else if (comboBox2.Text == csv.header011)
            {
                plotter.Y1Values = csv.dVals011;
            }
            else if (comboBox2.Text == csv.header012)
            {
                plotter.Y1Values = csv.dVals012;
            }
            else if (comboBox2.Text == csv.header013)
            {
                plotter.Y1Values = csv.dVals013;
            }
            else if (comboBox2.Text == csv.header014)
            {
                plotter.Y1Values = csv.dVals014;
            }
            else if (comboBox2.Text == csv.header015)
            {
                plotter.Y1Values = csv.dVals015;
            }
            else if (comboBox2.Text == csv.header016)
            {
                plotter.Y1Values = csv.dVals016;
            }
            else if (comboBox2.Text == csv.header017)
            {
                plotter.Y1Values = csv.dVals017;
            }
            else if (comboBox2.Text == csv.header018)
            {
                plotter.Y1Values = csv.dVals018;
            }
            else if (comboBox2.Text == csv.header019)
            {
                plotter.Y1Values = csv.dVals019;
            }
            else if (comboBox2.Text == csv.header020)
            {
                plotter.Y1Values = csv.dVals020;
            }
            else if (comboBox2.Text == csv.header021)
            {
                plotter.Y1Values = csv.dVals021;
            }
            else if (comboBox2.Text == csv.header022)
            {
                plotter.Y1Values = csv.dVals022;
            }
            else if (comboBox2.Text == csv.header023)
            {
                plotter.Y1Values = csv.dVals023;
            }
            else if (comboBox2.Text == csv.header024)
            {
                plotter.Y1Values = csv.dVals024;
            }
            else if (comboBox2.Text == csv.header025)
            {
                plotter.Y1Values = csv.dVals025;
            }
            else if (comboBox2.Text == csv.header026)
            {
                plotter.Y1Values = csv.dVals026;
            }
            else if (comboBox2.Text == csv.header027)
            {
                plotter.Y1Values = csv.dVals027;
            }
            else if (comboBox2.Text == csv.header028)
            {
                plotter.Y1Values = csv.dVals028;
            }
            else if (comboBox2.Text == csv.header029)
            {
                plotter.Y1Values = csv.dVals029;
            }
            else if (comboBox2.Text == csv.header030)
            {
                plotter.Y1Values = csv.dVals030;
            }
            else
            {
                plotter.Y1Values = csv.dVals002;
                //textBox2.AppendText("No item found. Default " + csv.header002 + " chosen for Y1" + "\r\n");
            }
        }
        private void Y2CheckIfCBSelectionsTextIsHeaderAndChooseItsValues()
        {
            if (comboBox3.Text == csv.header001)
            {
                plotter.Y2Values = csv.dVals001;
                //textBox2.AppendText(csv.header001 + " values selected" + "\r\n");
            }
            else if (comboBox3.Text == csv.header002)
            {
                plotter.Y2Values = csv.dVals002;
            }
            else if (comboBox3.Text == csv.header003)
            {
                plotter.Y2Values = csv.dVals003;
            }
            else if (comboBox3.Text == csv.header004)
            {
                plotter.Y2Values = csv.dVals004;
            }
            else if (comboBox3.Text == csv.header005)
            {
                plotter.Y2Values = csv.dVals005;
            }
            else if (comboBox3.Text == csv.header006)
            {
                plotter.Y2Values = csv.dVals006;
            }
            else if (comboBox3.Text == csv.header007)
            {
                plotter.Y2Values = csv.dVals007;
            }
            else if (comboBox3.Text == csv.header008)
            {
                plotter.Y2Values = csv.dVals008;
            }
            else if (comboBox3.Text == csv.header009)
            {
                plotter.Y2Values = csv.dVals009;
            }
            else if (comboBox3.Text == csv.header010)
            {
                plotter.Y2Values = csv.dVals010;
            }
            else if (comboBox3.Text == csv.header011)
            {
                plotter.Y2Values = csv.dVals011;
            }
            else if (comboBox3.Text == csv.header012)
            {
                plotter.Y2Values = csv.dVals012;
            }
            else if (comboBox3.Text == csv.header013)
            {
                plotter.Y2Values = csv.dVals013;
            }
            else if (comboBox3.Text == csv.header014)
            {
                plotter.Y2Values = csv.dVals014;
            }
            else if (comboBox3.Text == csv.header015)
            {
                plotter.Y2Values = csv.dVals015;
            }
            else if (comboBox3.Text == csv.header016)
            {
                plotter.Y2Values = csv.dVals016;
            }
            else if (comboBox3.Text == csv.header017)
            {
                plotter.Y2Values = csv.dVals017;
            }
            else if (comboBox3.Text == csv.header018)
            {
                plotter.Y2Values = csv.dVals018;
            }
            else if (comboBox3.Text == csv.header019)
            {
                plotter.Y2Values = csv.dVals019;
            }
            else if (comboBox3.Text == csv.header020)
            {
                plotter.Y2Values = csv.dVals020;
            }
            else if (comboBox3.Text == csv.header021)
            {
                plotter.Y2Values = csv.dVals021;
            }
            else if (comboBox3.Text == csv.header022)
            {
                plotter.Y2Values = csv.dVals022;
            }
            else if (comboBox3.Text == csv.header023)
            {
                plotter.Y2Values = csv.dVals023;
            }
            else if (comboBox3.Text == csv.header024)
            {
                plotter.Y2Values = csv.dVals024;
            }
            else if (comboBox3.Text == csv.header025)
            {
                plotter.Y2Values = csv.dVals025;
            }
            else if (comboBox3.Text == csv.header026)
            {
                plotter.Y2Values = csv.dVals026;
            }
            else if (comboBox3.Text == csv.header027)
            {
                plotter.Y2Values = csv.dVals027;
            }
            else if (comboBox3.Text == csv.header028)
            {
                plotter.Y2Values = csv.dVals028;
            }
            else if (comboBox3.Text == csv.header029)
            {
                plotter.Y2Values = csv.dVals029;
            }
            else if (comboBox3.Text == csv.header030)
            {
                plotter.Y2Values = csv.dVals030;
            }
            else
            {
                plotter.Y2Values = csv.dVals003;
                //textBox2.AppendText("No item found. Default " + csv.header003 + " chosen for Y2" + "\r\n");
            }
        }

        private void OtherDefaults()
        {
            if (ChartSettings.OtherDefaults == true)
            {
                ChartSettings.BackgroundColor = ChartSettings.DefaultBackgroundColor;
                ChartSettings.LegendColor = ChartSettings.DefaultLegendColor;
            }
            else
            {

            }
        }
        private void X1AxisDefaults()
        {
            
            if (comboBox1.Text == "Race Time")
            {
                ChartSettings.X1DefaultMax = double.NaN;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 1000;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 10;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Tire Travel Speed")
            {
                ChartSettings.X1DefaultMax = 400;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax / 2;
                ChartSettings.X1DefaultMajorInterval = 100;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Angular Velocity")
            {
                ChartSettings.X1DefaultMax = 400;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax / 2;
                ChartSettings.X1DefaultMajorInterval = 100;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Vertical Load")
            {
                ChartSettings.X1DefaultMax = 10000;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 1000;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Vertical Deflection")
            {
                ChartSettings.X1DefaultMax = 0.15;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 0.03;
                ChartSettings.X1DefaultMajorDecimals = 3;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Loaded Radius")
            {
                ChartSettings.X1DefaultMax = 0.5;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 0.1;
                ChartSettings.X1DefaultMajorDecimals = 3;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Effective Radius")
            {
                ChartSettings.X1DefaultMax = 0.5;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 0.1;
                ChartSettings.X1DefaultMajorDecimals = 3;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Contact Length")
            {
                ChartSettings.X1DefaultMax = 0.5;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 0.1;
                ChartSettings.X1DefaultMajorDecimals = 3;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Brake Torque")
            {
                ChartSettings.X1DefaultMax = 5000;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 500;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Max Brake Torque")
            {
                ChartSettings.X1DefaultMax = 5000;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 500;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Steer Angle")
            {
                // Default Axis values
                ChartSettings.X1DefaultMax = 45;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 15;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Camber Angle")
            {
                ChartSettings.X1DefaultMax = 10;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 4;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Lateral Load")
            {
                ChartSettings.X1DefaultMax = 10000;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 1000;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Slip Angle")
            {
                ChartSettings.X1DefaultMax = 45;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 15;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Lateral Friction")
            {
                ChartSettings.X1DefaultMax = 2;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 0.5;
                ChartSettings.X1DefaultMajorDecimals = 2;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Lateral Slip Speed")
            {
                ChartSettings.X1DefaultMax = 20;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 5;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Longitudinal Load")
            {
                ChartSettings.X1DefaultMax = 10000;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 1000;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Slip Ratio")
            {
                ChartSettings.X1DefaultMax = 1;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 0.2;
                ChartSettings.X1DefaultMajorDecimals = 2;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Longitudinal Friction")
            {
                ChartSettings.X1DefaultMax = 2;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 0.5;
                ChartSettings.X1DefaultMajorDecimals = 2;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Longitudinal Slip Speed")
            {
                ChartSettings.X1DefaultMax = 20;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 5;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Tread Temperature")
            {
                ChartSettings.X1DefaultMax = 380;
                ChartSettings.X1DefaultMin = -20;
                ChartSettings.X1DefaultMajorInterval = 20;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Inner Temperature")
            {
                ChartSettings.X1DefaultMax = 380;
                ChartSettings.X1DefaultMin = -20;
                ChartSettings.X1DefaultMajorInterval = 20;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Total Friction")
            {
                ChartSettings.X1DefaultMax = 2;
                ChartSettings.X1DefaultMin = -ChartSettings.X1DefaultMax;
                ChartSettings.X1DefaultMajorInterval = 0.5;
                ChartSettings.X1DefaultMajorDecimals = 2;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox1.Text == "Total Friction Angle")
            {
                ChartSettings.X1DefaultMax = 360;
                ChartSettings.X1DefaultMin = 0;
                ChartSettings.X1DefaultMajorInterval = 90;
                ChartSettings.X1DefaultMajorDecimals = 0;
                ChartSettings.X1DefaultMinorEnabled = true;
                ChartSettings.X1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.X1Defaults == true)
                {
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                    ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                    ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                }
            }
            /*
            else if (comboBox1.Text == "")
            {

            }*/
            
            else
            {
                // Defaults auto scale
                ChartSettings.X1DefaultMax = double.NaN;
                ChartSettings.X1DefaultMin = double.NaN;
                ChartSettings.X1DefaultMajorInterval = 0;
                ChartSettings.X1DefaultMajorDecimals = 2;
                ChartSettings.X1DefaultMinorEnabled = false;
                ChartSettings.X1DefaultMinorIntervalFraction = 1;
            }
        }

        private void Y1AxisDefaults()
        {
            
            if (comboBox2.Text == "Race Time")
            {
                ChartSettings.Y1DefaultMax = double.NaN;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 1000;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 10;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Tire Travel Speed")
            {
                ChartSettings.Y1DefaultMax = 400;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax / 2;
                ChartSettings.Y1DefaultMajorInterval = 100;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Angular Velocity")
            {
                ChartSettings.Y1DefaultMax = 400;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax / 2;
                ChartSettings.Y1DefaultMajorInterval = 100;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Vertical Load")
            {
                ChartSettings.Y1DefaultMax = 10000;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 1000;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Vertical Deflection")
            {
                ChartSettings.Y1DefaultMax = 0.15;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 0.03;
                ChartSettings.Y1DefaultMajorDecimals = 3;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Loaded Radius")
            {
                ChartSettings.Y1DefaultMax = 0.5;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 0.1;
                ChartSettings.Y1DefaultMajorDecimals = 3;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Effective Radius")
            {
                ChartSettings.Y1DefaultMax = 0.5;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 0.1;
                ChartSettings.Y1DefaultMajorDecimals = 3;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Contact Length")
            {
                ChartSettings.Y1DefaultMax = 0.5;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 0.1;
                ChartSettings.Y1DefaultMajorDecimals = 3;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Brake Torque")
            {
                ChartSettings.Y1DefaultMax = 5000;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 500;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Max Brake Torque")
            {
                ChartSettings.Y1DefaultMax = 5000;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 500;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Steer Angle")
            {
                // Default Axis values
                ChartSettings.Y1DefaultMax = 45;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 15;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Camber Angle")
            {
                ChartSettings.Y1DefaultMax = 10;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 4;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Lateral Load")
            {
                ChartSettings.Y1DefaultMax = 10000;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 1000;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Slip Angle")
            {
                ChartSettings.Y1DefaultMax = 45;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 15;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Lateral Friction")
            {
                ChartSettings.Y1DefaultMax = 2;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 0.5;
                ChartSettings.Y1DefaultMajorDecimals = 2;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Lateral Slip Speed")
            {
                ChartSettings.Y1DefaultMax = 20;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 5;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Longitudinal Load")
            {
                ChartSettings.Y1DefaultMax = 10000;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 1000;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Slip Ratio")
            {
                ChartSettings.Y1DefaultMax = 1;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 0.2;
                ChartSettings.Y1DefaultMajorDecimals = 2;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Longitudinal Friction")
            {
                ChartSettings.Y1DefaultMax = 2;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 0.5;
                ChartSettings.Y1DefaultMajorDecimals = 2;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Longitudinal Slip Speed")
            {
                ChartSettings.Y1DefaultMax = 20;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 5;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Tread Temperature")
            {
                ChartSettings.Y1DefaultMax = 380;
                ChartSettings.Y1DefaultMin = -20;
                ChartSettings.Y1DefaultMajorInterval = 20;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Inner Temperature")
            {
                ChartSettings.Y1DefaultMax = 380;
                ChartSettings.Y1DefaultMin = -20;
                ChartSettings.Y1DefaultMajorInterval = 20;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Total Friction")
            {
                ChartSettings.Y1DefaultMax = 2;
                ChartSettings.Y1DefaultMin = -ChartSettings.Y1DefaultMax;
                ChartSettings.Y1DefaultMajorInterval = 0.5;
                ChartSettings.Y1DefaultMajorDecimals = 2;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox2.Text == "Total Friction Angle")
            {
                ChartSettings.Y1DefaultMax = 360;
                ChartSettings.Y1DefaultMin = 0;
                ChartSettings.Y1DefaultMajorInterval = 90;
                ChartSettings.Y1DefaultMajorDecimals = 0;
                ChartSettings.Y1DefaultMinorEnabled = true;
                ChartSettings.Y1DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y1Defaults == true)
                {
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                    ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                    ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                }
            }
            /*
            else if (comboBox2.Text == "")
            {

            }*/
            
            else
            {
                // Defaults auto scale
                ChartSettings.Y1DefaultMax = double.NaN;
                ChartSettings.Y1DefaultMin = double.NaN;
                ChartSettings.Y1DefaultMajorInterval = 0;
                ChartSettings.Y1DefaultMajorDecimals = 2;
                ChartSettings.Y1DefaultMinorEnabled = false;
                ChartSettings.Y1DefaultMinorIntervalFraction = 1;
            }
            
        }

        private void Y2AxisDefaults()
        {
            
            if (comboBox3.Text == "Race Time")
            {
                ChartSettings.Y2DefaultMax = double.NaN;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 1000;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 10;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Tire Travel Speed")
            {
                ChartSettings.Y2DefaultMax = 400;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax / 2;
                ChartSettings.Y2DefaultMajorInterval = 100;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Angular Velocity")
            {
                ChartSettings.Y2DefaultMax = 400;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax / 2;
                ChartSettings.Y2DefaultMajorInterval = 100;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Vertical Load")
            {
                ChartSettings.Y2DefaultMax = 10000;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 1000;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Vertical Deflection")
            {
                ChartSettings.Y2DefaultMax = 0.15;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 0.03;
                ChartSettings.Y2DefaultMajorDecimals = 3;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Loaded Radius")
            {
                ChartSettings.Y2DefaultMax = 0.5;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 0.1;
                ChartSettings.Y2DefaultMajorDecimals = 3;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Effective Radius")
            {
                ChartSettings.Y2DefaultMax = 0.5;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 0.1;
                ChartSettings.Y2DefaultMajorDecimals = 3;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Contact Length")
            {
                ChartSettings.Y2DefaultMax = 0.5;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 0.1;
                ChartSettings.Y2DefaultMajorDecimals = 3;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Brake Torque")
            {
                ChartSettings.Y2DefaultMax = 5000;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 500;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Max Brake Torque")
            {
                ChartSettings.Y2DefaultMax = 5000;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 500;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Steer Angle")
            {
                // Default Axis values
                ChartSettings.Y2DefaultMax = 45;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 15;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Camber Angle")
            {
                ChartSettings.Y2DefaultMax = 10;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 4;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Lateral Load")
            {
                ChartSettings.Y2DefaultMax = 10000;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 1000;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Slip Angle")
            {
                ChartSettings.Y2DefaultMax = 45;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 15;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Lateral Friction")
            {
                ChartSettings.Y2DefaultMax = 2;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 0.5;
                ChartSettings.Y2DefaultMajorDecimals = 2;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Lateral Slip Speed")
            {
                ChartSettings.Y2DefaultMax = 20;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 5;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Longitudinal Load")
            {
                ChartSettings.Y2DefaultMax = 10000;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 1000;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Slip Ratio")
            {
                ChartSettings.Y2DefaultMax = 1;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 0.2;
                ChartSettings.Y2DefaultMajorDecimals = 2;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Longitudinal Friction")
            {
                ChartSettings.Y2DefaultMax = 2;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 0.5;
                ChartSettings.Y2DefaultMajorDecimals = 2;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Longitudinal Slip Speed")
            {
                ChartSettings.Y2DefaultMax = 20;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 5;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Tread Temperature")
            {
                ChartSettings.Y2DefaultMax = 380;
                ChartSettings.Y2DefaultMin = -20;
                ChartSettings.Y2DefaultMajorInterval = 20;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Inner Temperature")
            {
                ChartSettings.Y2DefaultMax = 380;
                ChartSettings.Y2DefaultMin = -20;
                ChartSettings.Y2DefaultMajorInterval = 20;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Total Friction")
            {
                ChartSettings.Y2DefaultMax = 2;
                ChartSettings.Y2DefaultMin = -ChartSettings.Y2DefaultMax;
                ChartSettings.Y2DefaultMajorInterval = 0.5;
                ChartSettings.Y2DefaultMajorDecimals = 2;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            else if (comboBox3.Text == "Total Friction Angle")
            {
                ChartSettings.Y2DefaultMax = 360;
                ChartSettings.Y2DefaultMin = 0;
                ChartSettings.Y2DefaultMajorInterval = 90;
                ChartSettings.Y2DefaultMajorDecimals = 0;
                ChartSettings.Y2DefaultMinorEnabled = true;
                ChartSettings.Y2DefaultMinorIntervalFraction = 5;

                if (ChartSettings.Y2Defaults == true)
                {
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                    ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                    ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                }
            }
            /*
            else if (comboBox3.Text == "")
            {

            }*/
            
            else
            {
                // Defaults auto scale
                ChartSettings.Y2DefaultMax = double.NaN;
                ChartSettings.Y2DefaultMin = double.NaN;
                ChartSettings.Y2DefaultMajorInterval = 0;
                ChartSettings.Y2DefaultMajorDecimals = 2;
                ChartSettings.Y2DefaultMinorEnabled = false;
                ChartSettings.Y2DefaultMinorIntervalFraction = 1;
            }
            
        }

        private void PlotToChart()
        {
            if (plotter.plotted == false)
            {

                ChartClass pointChart = new ChartClass(chart1, SeriesChartType.Point, ChartSettings.BackgroundColor, ChartSettings.X1MajorColor, ChartSettings.LegendColor);
                pointChart.XAxisSetLabel(chart1, ChartSettings.X1FontString, ChartSettings.X1FontSize, ChartSettings.X1FontStyle, ChartSettings.X1FontColor, ChartSettings.X1MajorDecimals);
                pointChart.XAxisSetGrid(chart1, ChartSettings.X1IsLog, ChartSettings.X1LogBase, ChartSettings.X1Min, ChartSettings.X1Max, ChartSettings.X1MajorInterval, ChartSettings.X1MajorColor, ChartSettings.X1MajorLineWidth, ChartSettings.X1MinorEnabled, ChartSettings.X1MinorDashStyle, ChartSettings.X1MinorLineWidth, ChartSettings.X1MinorIntervalFraction, ChartSettings.X1MinorColor);
                pointChart.YAxisSetLabelLegendMarkers(chart1, comboBox2.Text, ChartSettings.Y1FontString, ChartSettings.Y1FontSize, ChartSettings.Y1FontStyle, ChartSettings.Y1FontColor, ChartSettings.Y1MajorDecimals);
                pointChart.YAxisSetGrid(chart1, ChartSettings.Y1IsLog, ChartSettings.Y1LogBase, ChartSettings.Y1Min, ChartSettings.Y1Max, ChartSettings.Y1MajorInterval, ChartSettings.Y1MajorColor, ChartSettings.Y1MajorLineWidth, ChartSettings.Y1MinorEnabled, ChartSettings.Y1MinorDashStyle, ChartSettings.Y1MinorLineWidth, ChartSettings.Y1MinorIntervalFraction, ChartSettings.Y1MinorColor);
                //pointChart.AutoScaleX(chart1);
                //pointChart.AutoScaleY(chart1);
                //pointChart.AutoScaleY2(chart1);

                chart1.Series["Series1"].Points.DataBindXY(plotter.X1Values, plotter.Y1Values);

                if (ChartSettings.Y2Enabled == true)
                {
                    pointChart.Y2Axis(chart1, comboBox3.Text, ChartSettings.Y2FontString, ChartSettings.Y2FontSize, ChartSettings.Y2FontStyle, ChartSettings.Y2FontColor, ChartSettings.Y2MajorDecimals, ChartSettings.Y2Min, ChartSettings.Y2Max, ChartSettings.Y2MajorLineWidth, ChartSettings.Y2MajorColor, ChartSettings.Y2MinorColor);
                    chart1.Series["Series2"].Points.DataBindXY(plotter.X1Values, plotter.Y2Values);
                }

                plotter.plotted = true;
                plotToChart1.Text = "Clear chart";
                loadCSVButton.Hide();
            }
            else if (plotter.plotted == true)
            {
                chart1.Series.Clear();
                chart1.Series.Add("Series1");

                plotter.plotted = false;
                plotToChart1.Text = "Plot to chart";
                loadCSVButton.Show();
            }
        }
        private void PrintToTextBox()
        {
            textBox1.Text = CSVReadWrite.fileText;
        }

        #endregion

        #region Form buttons etc.
        private void Plotter1_Load(object sender, EventArgs e)
        {
            plotter.updatedStartedOnce = false;
        }

        private void Plotter1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (plotter.updatedStartedOnce == true)
            {
                plotter.update.Suspend();
            }
            plotter.updatedStartedOnce = false;
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
            OtherDefaults();
            PlotToChart();
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.AppendText("X axis: " + comboBox1.Text + "\r\n");
            X1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            X1AxisDefaults();
            OtherDefaults();


            if (plotter.plotted == true)
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

            if (plotter.plotted == true)
            {
                PlotToChart();
                PlotToChart();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.AppendText("Y2 axis: " + comboBox3.Text + "\r\n");
            if (comboBox3.Text == "")
            {
                ChartSettings.Y2Enabled = false;
                if (plotter.plotted == true)
                {
                    PlotToChart();
                    PlotToChart();
                }
            }
            else
            {
                ChartSettings.Y2Enabled = true;
                Y2CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
                Y2AxisDefaults();
                if (plotter.plotted == true)
                {
                    PlotToChart();
                    PlotToChart();
                }
            }
        }
        private void loadCSVButton_Click(object sender, EventArgs e)
        {

            csv.ReadFile(plotter.LogFileSaveLocationFolder);

            PrintToTextBox();
            textBox2.Text = plotter.LogFileSaveLocationFolder + CSVReadWrite.fileName + csv.header021 + "\r\n";
            ClearComboBoxes();
            foreach (string header in csv.headersList)
            {
                comboBox1.Items.Add(header);
                comboBox2.Items.Add(header);
                comboBox3.Items.Add(header);
            }

            plotter.X1Values = csv.dVals014;
            comboBox1.SelectedItem = csv.header014;
            plotter.Y1Values = csv.dVals013;
            comboBox2.SelectedItem = csv.header013;
            plotter.Y2Values = csv.dVals015;
            comboBox3.SelectedItem = csv.header015;
            plotToChart1.Visible = true;
        }


        private void plotToChart1_Click(object sender, EventArgs e)
        {
            X1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            X1AxisDefaults();
            Y1CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            Y1AxisDefaults();
            Y2CheckIfCBSelectionsTextIsHeaderAndChooseItsValues();
            Y2AxisDefaults();
            OtherDefaults();
            PlotToChart();
        }


        private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //do something here

                chart1.ChartAreas["ChartArea1"].AxisX.ScaleView.ZoomReset();
                chart1.ChartAreas["ChartArea1"].AxisY.ScaleView.ZoomReset();
            }
            else//left or middle click
            {
                //do something here
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toChartSettings_Click(object sender, EventArgs e)
        {
            FormChartSettings s = new FormChartSettings();
            if (ChartSettingsOpen == 0)
            {
                s.Show(); //Open FormChartSettings only if its not active and formcheck == 0
                          // Do Somethin

                ChartSettingsOpen = 1; //Set it to 1 indicating that FormChartSettings have been opened
            }
        }
    }
}
