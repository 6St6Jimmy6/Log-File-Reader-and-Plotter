using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Log_File_Reader_and_Plotter
{
    /*
    Font ComboBox example https://stackoverflow.com/questions/46037189/how-to-make-a-font-combobox-in-c
    REMEMBER TO PUT COMBOBOX AS DroDownList, so it shows the name right.
     */
    public partial class FormChartSettings : Form
    {
        public FormChartSettings()
        {
            InitializeComponent();
            X1ComboBoxFonts.DropDownStyle = ComboBoxStyle.DropDownList;// Shows font name right this way and you can't write on it
            Y1ComboBoxFonts.DropDownStyle = ComboBoxStyle.DropDownList;// Shows font name right this way and you can't write on it
            Y2ComboBoxFonts.DropDownStyle = ComboBoxStyle.DropDownList;// Shows font name right this way and you can't write on it

            // Font slection and draw stuff
            LegendColorComboBox.DrawItem += LegendColorComboBox_DrawItem;
            LegendColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            LegendColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            BackgroundColorComboBox.DrawItem += BackgroundColorComboBox_DrawItem;
            BackgroundColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            BackgroundColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            X1ComboBoxFonts.DrawItem += X1ComboBoxFonts_DrawItem;
            X1ComboBoxFonts.DataSource = System.Drawing.FontFamily.Families.ToList();
            X1ComboBoxFonts.DrawMode = DrawMode.OwnerDrawFixed;
            Y1ComboBoxFonts.DrawItem += Y1ComboBoxFonts_DrawItem;
            Y1ComboBoxFonts.DataSource = System.Drawing.FontFamily.Families.ToList();
            Y1ComboBoxFonts.DrawMode = DrawMode.OwnerDrawFixed;
            Y2ComboBoxFonts.DrawItem += Y2ComboBoxFonts_DrawItem;
            Y2ComboBoxFonts.DataSource = System.Drawing.FontFamily.Families.ToList();
            Y2ComboBoxFonts.DrawMode = DrawMode.OwnerDrawFixed;

            X1FontSizeComboBox.DrawItem += X1FontSizeComboBox_DrawItem;
            X1FontSizeComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1FontSizeComboBox.DrawItem += Y1FontSizeComboBox_DrawItem;
            Y1FontSizeComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y2FontSizeComboBox.DrawItem += Y2FontSizeComboBox_DrawItem;
            Y2FontSizeComboBox.DrawMode = DrawMode.OwnerDrawFixed;

            X1FontStyleComboBox.DrawItem += X1FontStyleComboBox_DrawItem;
            X1FontStyleComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            X1FontStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y1FontStyleComboBox.DrawItem += Y1FontStyleComboBox_DrawItem;
            Y1FontStyleComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1FontStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y2FontStyleComboBox.DrawItem += Y2FontStyleComboBox_DrawItem;
            Y2FontStyleComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y2FontStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            X1FontColorComboBox.DrawItem += X1FontColorComboBox_DrawItem;
            X1FontColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            X1FontColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y1FontColorComboBox.DrawItem += Y1FontColorComboBox_DrawItem;
            Y1FontColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1FontColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y2FontColorComboBox.DrawItem += Y2FontColorComboBox_DrawItem;
            Y2FontColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y2FontColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            X1MajorColorComboBox.DrawItem += X1MajorColorComboBox_DrawItem;
            X1MajorColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            X1MajorColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y1MajorColorComboBox.DrawItem += Y1MajorColorComboBox_DrawItem;
            Y1MajorColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y1MajorColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            Y2MajorColorComboBox.DrawItem += Y2MajorColorComboBox_DrawItem;
            Y2MajorColorComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            Y2MajorColorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            AddInComboBoxes();

            LoadX1Defaults();
            LoadY1Defaults();
            LoadY2Defaults();
            LoadOtherDefaults();
        }

        private void AddInComboBoxes()
        {
            // Add Font sizes in comboboxes
            for (int i = ChartSettings.FontSizeMin * ChartSettings.FontSizeDivided; i < ChartSettings.FontSizeMax * ChartSettings.FontSizeDivided + 1f / ChartSettings.FontSizeDivided; i++) // +1f/fontSizeDivided adds the last one missing.
            {
                X1FontSizeComboBox.Items.Add(i * 1f / ChartSettings.FontSizeDivided);
                Y1FontSizeComboBox.Items.Add(i * 1f / ChartSettings.FontSizeDivided);
                Y2FontSizeComboBox.Items.Add(i * 1f / ChartSettings.FontSizeDivided);

            }
            // Add FontStyles in the comboboxes
            foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
            {
                X1FontStyleComboBox.Items.Add(style);
                Y1FontStyleComboBox.Items.Add(style);
                Y2FontStyleComboBox.Items.Add(style);
            }
            // Add Colors in the comboboxes
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in colors)
            {
                Color color = Color.FromKnownColor(knowColor);
                BackgroundColorComboBox.Items.Add(color);
                LegendColorComboBox.Items.Add(color);
                // X1
                X1FontColorComboBox.Items.Add(color);
                X1MajorColorComboBox.Items.Add(color);
                X1MinorColorComboBox.Items.Add(color);
                // Y1
                Y1FontColorComboBox.Items.Add(color);
                Y1MajorColorComboBox.Items.Add(color);
                Y1MinorColorComboBox.Items.Add(color);
                // Y2
                Y2FontColorComboBox.Items.Add(color);
                Y2MajorColorComboBox.Items.Add(color);
                Y2MinorColorComboBox.Items.Add(color);

            }
            // Add DashStyles in the comboboxes
            foreach (ChartDashStyle style in Enum.GetValues(typeof(ChartDashStyle)))
            {
                X1MinorDashStyleComboBox.Items.Add(style);
                Y1MinorDashStyleComboBox.Items.Add(style);
                Y2MinorDashStyleComboBox.Items.Add(style);
            }
            // Add Line Widths in the comboboxes
            for (int i = 1; i < 10; i++)
            {
                // X1
                X1MajorLineWidthComboBox.Items.Add(i);
                X1MinorLineWidthComboBox.Items.Add(i);
                // Y1
                Y1MajorLineWidthComboBox.Items.Add(i);
                Y1MinorLineWidthComboBox.Items.Add(i);
                // Y2
                Y2MajorLineWidthComboBox.Items.Add(i);
                Y2MinorLineWidthComboBox.Items.Add(i);
            }
            // Add Minor Interval in comboboxes
            for (double i = 1; i < 10; i++)
            {
                // X1
                X1MinorIntervalComboBox.Items.Add(i);
                // Y1
                Y1MinorIntervalComboBox.Items.Add(i);
                // Y2
                //Y2MinorIntervalComboBox.Items.Add(i);
            }
            // Add Decimals in the comboboxes
            for (int i = 0; i < 10; i++)
            {
                // X1
                X1MajorDecimalsComboBox.Items.Add(i);
                // Y1
                Y1MajorDecimalsComboBox.Items.Add(i);
                // Y2
                Y2MajorDecimalsComboBox.Items.Add(i);
            }
        }

        public void LoadOtherDefaults()
        {
            //Default background color
            if (DefaultsCheckBox.Checked == true)
            {
                BackgroundColorComboBox.SelectedItem = ChartSettings.DefaultBackgroundColor;
                LegendColorComboBox.SelectedItem = ChartSettings.DefaultLegendColor;
            }
            else
            {
                BackgroundColorComboBox.SelectedItem = ChartSettings.BackgroundColor;
                LegendColorComboBox.SelectedItem = ChartSettings.LegendColor;
            }
        }

        public void LoadX1Defaults()
        {
            // Default X1 selections
            if (X1DefaultsCheckBox.Checked == true)
            {
                X1ComboBoxFonts.SelectedItem = X1ComboBoxFonts.Items[ChartSettings.X1DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                ChartSettings.X1DefaultFontString = X1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                X1FontSizeComboBox.SelectedItem = ChartSettings.X1DefaultFontSize;

                X1FontStyleComboBox.SelectedItem = ChartSettings.X1DefaultFontStyle;

                X1FontColorComboBox.SelectedItem = ChartSettings.X1DefaultFontColor;

                X1IsLogCheckBox.Checked = ChartSettings.X1DefaultIsLog;
                X1LogBaseTextBox.Text = ChartSettings.X1DefaultLogBase.ToString();
                X1MajorColorComboBox.SelectedItem = ChartSettings.X1DefaultMajorColor;
                X1MajorDecimalsComboBox.SelectedItem = ChartSettings.X1DefaultMajorDecimals;
                X1MajorIntervalTextBox.Text = ChartSettings.X1DefaultMajorInterval.ToString();
                X1MajorLineWidthComboBox.SelectedItem = ChartSettings.X1DefaultMajorLineWidth;
                X1MaxMaskedTextBox.Text = ChartSettings.X1DefaultMax.ToString();
                X1MinMaskedTextBox.Text = ChartSettings.X1DefaultMin.ToString();
                X1MinorColorComboBox.SelectedItem = ChartSettings.X1DefaultMinorColor;
                X1MinorDashStyleComboBox.SelectedItem = ChartSettings.X1DefaultMinorDashStyle;
                X1MinorEnabledCheckBox.Checked = ChartSettings.X1DefaultMinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = ChartSettings.X1DefaultMinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = ChartSettings.X1DefaultMinorLineWidth;
            }
            else
            {
                X1ComboBoxFonts.SelectedItem = X1ComboBoxFonts.Items[ChartSettings.X1FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                ChartSettings.X1FontString = X1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                X1FontSizeComboBox.SelectedItem = ChartSettings.X1FontSize;

                X1FontStyleComboBox.SelectedItem = ChartSettings.X1FontStyle;

                X1FontColorComboBox.SelectedItem = ChartSettings.X1FontColor;

                X1IsLogCheckBox.Checked = ChartSettings.X1IsLog;
                X1LogBaseTextBox.Text = ChartSettings.X1LogBase.ToString();
                X1MajorColorComboBox.SelectedItem = ChartSettings.X1MajorColor;
                X1MajorDecimalsComboBox.SelectedItem = ChartSettings.X1MajorDecimals;
                X1MajorIntervalTextBox.Text = ChartSettings.X1MajorInterval.ToString();
                X1MajorLineWidthComboBox.SelectedItem = ChartSettings.X1MajorLineWidth;
                X1MaxMaskedTextBox.Text = ChartSettings.X1Max.ToString();
                X1MinMaskedTextBox.Text = ChartSettings.X1Min.ToString();
                X1MinorColorComboBox.SelectedItem = ChartSettings.X1MinorColor;
                X1MinorDashStyleComboBox.SelectedItem = ChartSettings.X1MinorDashStyle;
                X1MinorEnabledCheckBox.Checked = ChartSettings.X1MinorEnabled;
                X1MinorIntervalComboBox.SelectedItem = ChartSettings.X1MinorIntervalFraction;
                X1MinorLineWidthComboBox.SelectedItem = ChartSettings.X1MinorLineWidth;
            }
        }
        public void LoadY1Defaults()
        {
            // Default Y1 selections
            if (Y1DefaultsCheckBox.Checked == true)
            {
                Y1ComboBoxFonts.SelectedItem = Y1ComboBoxFonts.Items[ChartSettings.Y1DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                ChartSettings.Y1DefaultFontString = Y1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y1FontSizeComboBox.SelectedItem = ChartSettings.Y1DefaultFontSize;

                Y1FontStyleComboBox.SelectedItem = ChartSettings.Y1DefaultFontStyle;

                Y1FontColorComboBox.SelectedItem = ChartSettings.Y1DefaultFontColor;

                Y1IsLogCheckBox.Checked = ChartSettings.Y1DefaultIsLog;
                Y1LogBaseTextBox.Text = ChartSettings.Y1DefaultLogBase.ToString();
                Y1MajorColorComboBox.SelectedItem = ChartSettings.Y1DefaultMajorColor;
                Y1MajorDecimalsComboBox.SelectedItem = ChartSettings.Y1DefaultMajorDecimals;
                Y1MajorIntervalTextBox.Text = ChartSettings.Y1DefaultMajorInterval.ToString();
                Y1MajorLineWidthComboBox.SelectedItem = ChartSettings.Y1DefaultMajorLineWidth;
                Y1MaxMaskedTextBox.Text = ChartSettings.Y1DefaultMax.ToString();
                Y1MinMaskedTextBox.Text = ChartSettings.Y1DefaultMin.ToString();
                Y1MinorColorComboBox.SelectedItem = ChartSettings.Y1DefaultMinorColor;
                Y1MinorDashStyleComboBox.SelectedItem = ChartSettings.Y1DefaultMinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = ChartSettings.Y1DefaultMinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = ChartSettings.Y1DefaultMinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = ChartSettings.Y1DefaultMinorLineWidth;
            }
            else
            {
                Y1ComboBoxFonts.SelectedItem = Y1ComboBoxFonts.Items[ChartSettings.Y1FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                ChartSettings.Y1FontString = Y1ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y1FontSizeComboBox.SelectedItem = ChartSettings.Y1FontSize;

                Y1FontStyleComboBox.SelectedItem = ChartSettings.Y1FontStyle;

                Y1FontColorComboBox.SelectedItem = ChartSettings.Y1FontColor;

                Y1IsLogCheckBox.Checked = ChartSettings.Y1IsLog;
                Y1LogBaseTextBox.Text = ChartSettings.Y1LogBase.ToString();
                Y1MajorColorComboBox.SelectedItem = ChartSettings.Y1MajorColor;
                Y1MajorDecimalsComboBox.SelectedItem = ChartSettings.Y1MajorDecimals;
                Y1MajorIntervalTextBox.Text = ChartSettings.Y1MajorInterval.ToString();
                Y1MajorLineWidthComboBox.SelectedItem = ChartSettings.Y1MajorLineWidth;
                Y1MaxMaskedTextBox.Text = ChartSettings.Y1Max.ToString();
                Y1MinMaskedTextBox.Text = ChartSettings.Y1Min.ToString();
                Y1MinorColorComboBox.SelectedItem = ChartSettings.Y1MinorColor;
                Y1MinorDashStyleComboBox.SelectedItem = ChartSettings.Y1MinorDashStyle;
                Y1MinorEnabledCheckBox.Checked = ChartSettings.Y1MinorEnabled;
                Y1MinorIntervalComboBox.SelectedItem = ChartSettings.Y1MinorIntervalFraction;
                Y1MinorLineWidthComboBox.SelectedItem = ChartSettings.Y1MinorLineWidth;
            }
        }
        public void LoadY2Defaults()
        {
            // Default Y2 selections
            if (Y2DefaultsCheckBox.Checked == true)
            {
                Y2ComboBoxFonts.SelectedItem = Y2ComboBoxFonts.Items[ChartSettings.Y2DefaultFontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                ChartSettings.Y2DefaultFontString = Y2ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y2FontSizeComboBox.SelectedItem = ChartSettings.Y2DefaultFontSize;

                Y2FontStyleComboBox.SelectedItem = ChartSettings.Y2DefaultFontStyle;

                Y2FontColorComboBox.SelectedItem = ChartSettings.Y2DefaultFontColor;

                //Y2IsLogCheckBox.Checked = ChartSettings.Y2DefaultIsLog;
                //Y2LogBaseTextBox.Text = ChartSettings.Y2DefaultLogBase.ToString();
                Y2MajorColorComboBox.SelectedItem = ChartSettings.Y2DefaultMajorColor;
                Y2MajorDecimalsComboBox.SelectedItem = ChartSettings.Y2DefaultMajorDecimals;
                //Y2MajorIntervalTextBox.Text = ChartSettings.Y2DefaultMajorInterval.ToString();
                Y2MajorLineWidthComboBox.SelectedItem = ChartSettings.Y2DefaultMajorLineWidth;
                Y2MaxMaskedTextBox.Text = ChartSettings.Y2DefaultMax.ToString();
                Y2MinMaskedTextBox.Text = ChartSettings.Y2DefaultMin.ToString();
                Y2MinorColorComboBox.SelectedItem = ChartSettings.Y2DefaultMinorColor;
                Y2MinorDashStyleComboBox.SelectedItem = ChartSettings.Y2DefaultMinorDashStyle;
                Y2MinorEnabledCheckBox.Checked = ChartSettings.Y2DefaultMinorEnabled;
                //Y2MinorIntervalComboBox.SelectedItem = ChartSettings.Y2DefaultMinorIntervalFraction;
                Y2MinorLineWidthComboBox.SelectedItem = ChartSettings.Y2DefaultMinorLineWidth;
            }
            else
            {
                Y2ComboBoxFonts.SelectedItem = Y2ComboBoxFonts.Items[ChartSettings.Y2FontIndex];//Sets default SelectedItem to Microsoft Sans Serif

                ChartSettings.Y2FontString = Y2ComboBoxFonts.SelectedItem.ToString();//Gets default SelectedItem's string "Microsoft Sans Serif"

                Y2FontSizeComboBox.SelectedItem = ChartSettings.Y2FontSize;

                Y2FontStyleComboBox.SelectedItem = ChartSettings.Y2FontStyle;

                Y2FontColorComboBox.SelectedItem = ChartSettings.Y2FontColor;

                //Y2IsLogCheckBox.Checked = ChartSettings.Y2IsLog;
                //Y2LogBaseTextBox.Text = ChartSettings.Y2LogBase.ToString();
                Y2MajorColorComboBox.SelectedItem = ChartSettings.Y2MajorColor;
                Y2MajorDecimalsComboBox.SelectedItem = ChartSettings.Y2MajorDecimals;
                //Y2MajorIntervalTextBox.Text = ChartSettings.Y2MajorInterval.ToString();
                Y2MajorLineWidthComboBox.SelectedItem = ChartSettings.Y2MajorLineWidth;
                Y2MaxMaskedTextBox.Text = ChartSettings.Y2Max.ToString();
                Y2MinMaskedTextBox.Text = ChartSettings.Y2Min.ToString();
                Y2MinorColorComboBox.SelectedItem = ChartSettings.Y2MinorColor;
                Y2MinorDashStyleComboBox.SelectedItem = ChartSettings.Y2MinorDashStyle;
                Y2MinorEnabledCheckBox.Checked = ChartSettings.Y2MinorEnabled;
                //Y2MinorIntervalComboBox.SelectedItem = ChartSettings.Y2MinorIntervalFraction;
                Y2MinorLineWidthComboBox.SelectedItem = ChartSettings.Y2MinorLineWidth;
            }
        }

        private void ApplySettings()
        {
            if (DefaultsCheckBox.Checked == true)
            {
                ChartSettings.BackgroundColor = ChartSettings.DefaultBackgroundColor;
                ChartSettings.LegendColor = ChartSettings.DefaultLegendColor;
            }
            else
            {
                ChartSettings.BackgroundColor = (Color)BackgroundColorComboBox.SelectedItem;
                ChartSettings.LegendColor = (Color)LegendColorComboBox.SelectedItem;
            }

            if (X1DefaultsCheckBox.Checked == true)
            {
                ChartSettings.X1Defaults = true;

                ChartSettings.X1FontString = ChartSettings.X1DefaultFontString;
                ChartSettings.X1FontSize = ChartSettings.X1DefaultFontSize;
                ChartSettings.X1FontStyle = ChartSettings.X1DefaultFontStyle;
                ChartSettings.X1FontColor = ChartSettings.X1DefaultFontColor;

                ChartSettings.X1IsLog = ChartSettings.X1DefaultIsLog;
                ChartSettings.X1LogBase = ChartSettings.X1DefaultLogBase;

                ChartSettings.X1MajorColor = ChartSettings.X1DefaultMajorColor;
                ChartSettings.X1MajorDecimals = ChartSettings.X1DefaultMajorDecimals;
                ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                ChartSettings.X1MajorLineWidth = ChartSettings.X1DefaultMajorLineWidth;
                ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                ChartSettings.X1Min = ChartSettings.X1DefaultMin;

                ChartSettings.X1MinorEnabled = ChartSettings.X1DefaultMinorEnabled;
                ChartSettings.X1MinorIntervalFraction = ChartSettings.X1DefaultMinorIntervalFraction;
                ChartSettings.X1MinorLineWidth = ChartSettings.X1DefaultMinorLineWidth;
                ChartSettings.X1MinorColor = ChartSettings.X1DefaultMinorColor;
                ChartSettings.X1MinorDashStyle = ChartSettings.X1DefaultMinorDashStyle;

            }
            else
            {
                ChartSettings.X1Defaults = false;

                ChartSettings.X1FontString = X1ComboBoxFonts.Text;
                ChartSettings.X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
                ChartSettings.X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
                ChartSettings.X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;

                ChartSettings.X1IsLog = X1IsLogCheckBox.Checked;

                if (double.TryParse(X1LogBaseTextBox.Text, out double parseLogBase))
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parseLogBase >= 0) // It's a positive number.
                    {
                        ChartSettings.X1LogBase = parseLogBase;
                    }
                    else // Negative returns to default
                    {
                        X1LogBaseTextBox.Text = "Invalid negative value!";
                        ChartSettings.X1LogBase = ChartSettings.X1DefaultLogBase;
                    }
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    X1LogBaseTextBox.Text = "Invalid value!";
                    ChartSettings.X1LogBase = ChartSettings.X1DefaultLogBase;
                }

                ChartSettings.X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;
                ChartSettings.X1MajorDecimals = (int)X1MajorDecimalsComboBox.SelectedItem;

                
                if (double.TryParse(X1MajorIntervalTextBox.Text, out double parseX1MajorInterval))
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parseX1MajorInterval >=0)
                    {
                        ChartSettings.X1MajorInterval = parseX1MajorInterval;
                    }
                    else // Negative returns to default
                    {
                        X1MajorIntervalTextBox.Text = "Invalid negative value!";
                        ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                    }
                }
                else
                {
                    X1MajorIntervalTextBox.Text = "Invalid value!";
                    ChartSettings.X1MajorInterval = ChartSettings.X1DefaultMajorInterval;
                }

                ChartSettings.X1MajorLineWidth = (int)X1MajorLineWidthComboBox.SelectedItem;

                if (double.TryParse(X1MaxMaskedTextBox.Text, out double parseX1Max))
                {
                    // Here you already can use a valid double 'doubleValue'
                    ChartSettings.X1Max = parseX1Max;
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    X1MaxMaskedTextBox.Text = "Invalid value!";
                    ChartSettings.X1Max = ChartSettings.X1DefaultMax;
                } 
                
                if (double.TryParse(X1MinMaskedTextBox.Text, out double parseX1Min))
                {
                    // Here you already can use a valid double 'doubleValue'
                    ChartSettings.X1Min = parseX1Min;
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    X1MinMaskedTextBox.Text = "Invalid value!";
                    ChartSettings.X1Min = ChartSettings.X1DefaultMin;
                }

                ChartSettings.X1MinorEnabled = X1MinorEnabledCheckBox.Checked;
                ChartSettings.X1MinorIntervalFraction = (double)X1MinorIntervalComboBox.SelectedItem;
                ChartSettings.X1MinorLineWidth = (int)X1MinorLineWidthComboBox.SelectedItem;
                ChartSettings.X1MinorColor = (Color)X1MinorColorComboBox.SelectedItem;
                ChartSettings.X1MinorDashStyle = (ChartDashStyle)X1MinorDashStyleComboBox.SelectedItem;
            }

            if (Y1DefaultsCheckBox.Checked == true)
            {
                ChartSettings.Y1Defaults = true;

                ChartSettings.Y1FontString = ChartSettings.Y1DefaultFontString;
                ChartSettings.Y1FontSize = ChartSettings.Y1DefaultFontSize;
                ChartSettings.Y1FontStyle = ChartSettings.Y1DefaultFontStyle;
                ChartSettings.Y1FontColor = ChartSettings.Y1DefaultFontColor;

                ChartSettings.Y1IsLog = ChartSettings.Y1DefaultIsLog;
                ChartSettings.Y1LogBase = ChartSettings.Y1DefaultLogBase;

                ChartSettings.Y1MajorColor = ChartSettings.Y1DefaultMajorColor;
                ChartSettings.Y1MajorDecimals = ChartSettings.Y1DefaultMajorDecimals;
                ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                ChartSettings.Y1MajorLineWidth = ChartSettings.Y1DefaultMajorLineWidth;
                ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;

                ChartSettings.Y1MinorEnabled = ChartSettings.Y1DefaultMinorEnabled;
                ChartSettings.Y1MinorIntervalFraction = ChartSettings.Y1DefaultMinorIntervalFraction;
                ChartSettings.Y1MinorLineWidth = ChartSettings.Y1DefaultMinorLineWidth;
                ChartSettings.Y1MinorColor = ChartSettings.Y1DefaultMinorColor;
                ChartSettings.Y1MinorDashStyle = ChartSettings.Y1DefaultMinorDashStyle;

            }
            else
            {
                ChartSettings.Y1Defaults = false;

                ChartSettings.Y1FontString = Y1ComboBoxFonts.Text;
                ChartSettings.Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
                ChartSettings.Y1FontSize = (float)Y1FontSizeComboBox.SelectedItem;
                ChartSettings.Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;

                ChartSettings.Y1IsLog = Y1IsLogCheckBox.Checked;

                if (double.TryParse(Y1LogBaseTextBox.Text, out double parseLogBase))
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parseLogBase >= 0) // It's a positive number.
                    {
                        ChartSettings.Y1LogBase = parseLogBase;
                    }
                    else // Negative returns to default
                    {
                        Y1LogBaseTextBox.Text = "Invalid negative value!";
                        ChartSettings.Y1LogBase = ChartSettings.Y1DefaultLogBase;
                    }
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    Y1LogBaseTextBox.Text = "Invalid value!";
                    ChartSettings.Y1LogBase = ChartSettings.Y1DefaultLogBase;
                }

                ChartSettings.Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;
                ChartSettings.Y1MajorDecimals = (int)Y1MajorDecimalsComboBox.SelectedItem;


                if (double.TryParse(Y1MajorIntervalTextBox.Text, out double parseY1MajorInterval))
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parseY1MajorInterval >= 0)
                    {
                        ChartSettings.Y1MajorInterval = parseY1MajorInterval;
                    }
                    else // Negative returns to default
                    {
                        Y1MajorIntervalTextBox.Text = "Invalid negative value!";
                        ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                    }
                }
                else
                {
                    Y1MajorIntervalTextBox.Text = "Invalid value!";
                    ChartSettings.Y1MajorInterval = ChartSettings.Y1DefaultMajorInterval;
                }

                ChartSettings.Y1MajorLineWidth = (int)Y1MajorLineWidthComboBox.SelectedItem;

                if (double.TryParse(Y1MaxMaskedTextBox.Text, out double parseY1Max))
                {
                    // Here you already can use a valid double 'doubleValue'
                    ChartSettings.Y1Max = parseY1Max;
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    Y1MaxMaskedTextBox.Text = "Invalid value!";
                    ChartSettings.Y1Max = ChartSettings.Y1DefaultMax;
                }

                if (double.TryParse(Y1MinMaskedTextBox.Text, out double parseY1Min))
                {
                    // Here you already can use a valid double 'doubleValue'
                    ChartSettings.Y1Min = parseY1Min;
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    Y1MinMaskedTextBox.Text = "Invalid value!";
                    ChartSettings.Y1Min = ChartSettings.Y1DefaultMin;
                }

                ChartSettings.Y1MinorEnabled = Y1MinorEnabledCheckBox.Checked;
                ChartSettings.Y1MinorIntervalFraction = (double)Y1MinorIntervalComboBox.SelectedItem;
                ChartSettings.Y1MinorLineWidth = (int)Y1MinorLineWidthComboBox.SelectedItem;
                ChartSettings.Y1MinorColor = (Color)Y1MinorColorComboBox.SelectedItem;
                ChartSettings.Y1MinorDashStyle = (ChartDashStyle)Y1MinorDashStyleComboBox.SelectedItem;
            }

            if (Y2DefaultsCheckBox.Checked == true)
            {
                ChartSettings.Y2Defaults = true;

                ChartSettings.Y2FontString = ChartSettings.Y2DefaultFontString;
                ChartSettings.Y2FontSize = ChartSettings.Y2DefaultFontSize;
                ChartSettings.Y2FontStyle = ChartSettings.Y2DefaultFontStyle;
                ChartSettings.Y2FontColor = ChartSettings.Y2DefaultFontColor;

                ChartSettings.Y2IsLog = ChartSettings.Y2DefaultIsLog;
                ChartSettings.Y2LogBase = ChartSettings.Y2DefaultLogBase;

                ChartSettings.Y2MajorColor = ChartSettings.Y2DefaultMajorColor;
                ChartSettings.Y2MajorDecimals = ChartSettings.Y2DefaultMajorDecimals;
                ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                ChartSettings.Y2MajorLineWidth = ChartSettings.Y2DefaultMajorLineWidth;
                ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;

                ChartSettings.Y2MinorEnabled = ChartSettings.Y2DefaultMinorEnabled;
                ChartSettings.Y2MinorIntervalFraction = ChartSettings.Y2DefaultMinorIntervalFraction;
                ChartSettings.Y2MinorLineWidth = ChartSettings.Y2DefaultMinorLineWidth;
                ChartSettings.Y2MinorColor = ChartSettings.Y2DefaultMinorColor;
                ChartSettings.Y2MinorDashStyle = ChartSettings.Y2DefaultMinorDashStyle;

            }
            else
            {
                ChartSettings.Y2Defaults = true;

                ChartSettings.Y2FontString = Y2ComboBoxFonts.Text;
                ChartSettings.Y2FontColor = (Color)Y2FontColorComboBox.SelectedItem;
                ChartSettings.Y2FontSize = (float)Y2FontSizeComboBox.SelectedItem;
                ChartSettings.Y2FontStyle = (FontStyle)Y2FontStyleComboBox.SelectedItem;

                //ChartSettings.Y2IsLog = Y2IsLogCheckBox.Checked;
                /*
                if (double.TryParse(Y2LogBaseTextBox.Text, out double parseLogBase))
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parseLogBase >= 0) // It's a positive number.
                    {
                        ChartSettings.Y2LogBase = parseLogBase;
                    }
                    else // Negative returns to default
                    {
                        Y2LogBaseTextBox.Text = "Invalid negative value!";
                        ChartSettings.Y2LogBase = ChartSettings.Y2DefaultLogBase;
                    }
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    Y2LogBaseTextBox.Text = "Invalid value!";
                    ChartSettings.Y2LogBase = ChartSettings.Y2DefaultLogBase;
                }*/

                ChartSettings.Y2MajorColor = (Color)Y2MajorColorComboBox.SelectedItem;
                ChartSettings.Y2MajorDecimals = (int)Y2MajorDecimalsComboBox.SelectedItem;

                /*
                if (double.TryParse(Y2MajorIntervalTextBox.Text, out double parseY2MajorInterval))
                {
                    // Here you already can use a valid double 'doubleValue'
                    if (parseY2MajorInterval >= 0)
                    {
                        ChartSettings.Y2MajorInterval = parseY2MajorInterval;
                    }
                    else // Negative returns to default
                    {
                        Y2MajorIntervalTextBox.Text = "Invalid negative value!";
                        ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                    }
                }
                else
                {
                    Y2MajorIntervalTextBox.Text = "Invalid value!";
                    ChartSettings.Y2MajorInterval = ChartSettings.Y2DefaultMajorInterval;
                }
                */
                ChartSettings.Y2MajorLineWidth = (int)Y2MajorLineWidthComboBox.SelectedItem;

                if (double.TryParse(Y2MaxMaskedTextBox.Text, out double parseY2Max))
                {
                    // Here you already can use a valid double 'doubleValue'
                    ChartSettings.Y2Max = parseY2Max;
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    Y2MaxMaskedTextBox.Text = "Invalid value!";
                    ChartSettings.Y2Max = ChartSettings.Y2DefaultMax;
                }

                if (double.TryParse(Y2MinMaskedTextBox.Text, out double parseY2Min))
                {
                    // Here you already can use a valid double 'doubleValue'
                    ChartSettings.Y2Min = parseY2Min;
                }
                else
                {
                    // Here you can display an error message like 'Invalid value'
                    Y2MinMaskedTextBox.Text = "Invalid value!";
                    ChartSettings.Y2Min = ChartSettings.Y2DefaultMin;
                }

                ChartSettings.Y2MinorEnabled = Y2MinorEnabledCheckBox.Checked;
                //ChartSettings.Y2MinorIntervalFraction = (double)Y2MinorIntervalComboBox.SelectedItem;
                ChartSettings.Y2MinorLineWidth = (int)Y2MinorLineWidthComboBox.SelectedItem;
                ChartSettings.Y2MinorColor = (Color)Y2MinorColorComboBox.SelectedItem;
                ChartSettings.Y2MinorDashStyle = (ChartDashStyle)Y2MinorDashStyleComboBox.SelectedItem;
            }
        }

        private void CheckFontColorAndSetBackGroundColor(ComboBox cb, Color fontColor)
        {
            if (fontColor == Color.White || fontColor == Color.WhiteSmoke || fontColor == Color.AntiqueWhite || fontColor == Color.FloralWhite || fontColor == Color.NavajoWhite)
            {
                cb.BackColor = Color.Black;
            }
            else
            {
                cb.BackColor = SystemColors.Window;
            }
            cb.ForeColor = fontColor;
        }

        private void AxisSettings_Load(object sender, EventArgs e)
        {
            //p1.AxisSettingsIsOpen = true;
            //p1.ButtonVisibilities();
            //AxisSettingsIsOpen = true;
            //ButtonVisibilities();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Close();
        }

        private void AxisSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplySettings();
        }

        private void AxisSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            //p1.AxisSettingsIsOpen = false;
            //p1.ButtonVisibilities();
            //AxisSettingsIsOpen = false;
            //ButtonVisibilities();
            FormPlotter.ChartSettingsOpen = 0;// Sets to 0, so Axis Settings it can be opened again.
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        //////////////////////////////////////////////////////////////////////////////////////////77
        ///X1 STUFF
        ///
        private void X1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, ChartSettings.X1DefaultFontSize, ChartSettings.X1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            //ChartSettings.X1Font = font.Name;
        }

        private void X1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            X1ComboBoxFonts.Font = new Font(ChartSettings.X1FontString, ChartSettings.X1DefaultFontSize, ChartSettings.X1DefaultFontStyle);

            //X1ComboBoxFonts.Text = ChartSettings.X1Font;
        }

        private void X1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.X1FontStyle = (FontStyle)X1FontStyleComboBox.SelectedItem;
            X1FontStyleComboBox.Font = new Font(ChartSettings.X1DefaultFontString, ChartSettings.X1DefaultFontSize, ChartSettings.X1FontStyle);
        }

        private void X1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.Items[e.Index];
            var font = new Font((string)ChartSettings.X1DefaultFontString, comboBox.Font.SizeInPoints, fontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontStyle.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void X1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.X1FontColor = (Color)X1FontColorComboBox.SelectedItem;
            X1FontColorComboBox.Font = new Font(ChartSettings.X1DefaultFontString, ChartSettings.X1DefaultFontSize, ChartSettings.X1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(X1FontColorComboBox, ChartSettings.X1FontColor);
        }

        private void X1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font((string)ChartSettings.X1DefaultFontString, ChartSettings.X1DefaultFontSize, ChartSettings.X1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(X1FontColorComboBox, ChartSettings.X1FontColor);
        }

        private void X1FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.X1FontSize = (float)X1FontSizeComboBox.SelectedItem;
            X1FontSizeComboBox.Font = new Font(ChartSettings.X1DefaultFontString, ChartSettings.X1FontSize, ChartSettings.X1DefaultFontStyle);
            //textBox8.Text = ChartSettings.X1FontSize.ToString();
            //comboBox7.Text = p.GetX1FontSize().ToString();
        }

        private void X1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.Items[e.Index];
            var font = new Font((string)ChartSettings.X1DefaultFontString, (float)fontSize, ChartSettings.X1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontSize.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }
        private void X1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.X1MajorColor = (Color)X1MajorColorComboBox.SelectedItem;
            X1MajorColorComboBox.Font = new Font(ChartSettings.X1DefaultFontString, ChartSettings.X1DefaultFontSize, ChartSettings.X1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(X1MajorColorComboBox, ChartSettings.X1MajorColor);
        }
        private void X1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font((string)ChartSettings.X1DefaultFontString, ChartSettings.X1DefaultFontSize, ChartSettings.X1FontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(X1MajorColorComboBox, ChartSettings.X1MajorColor);
        }


        //////////////////////////////////////////////////////////////////////////////////////////77
        ///Y1 STUFF
        ///
        private void Y1ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, ChartSettings.Y1DefaultFontSize, ChartSettings.Y1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            //ChartSettings.Y1Font = font.Name;
        }

        private void Y1ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            Y1ComboBoxFonts.Font = new Font(ChartSettings.Y1FontString, ChartSettings.Y1DefaultFontSize, ChartSettings.Y1DefaultFontStyle);

            Y1ComboBoxFonts.Text = ChartSettings.Y1FontString;
        }

        private void Y1FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y1FontStyle = (FontStyle)Y1FontStyleComboBox.SelectedItem;
            Y1FontStyleComboBox.Font = new Font(ChartSettings.Y1DefaultFontString, ChartSettings.Y1DefaultFontSize, ChartSettings.Y1FontStyle);
        }

        private void Y1FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.Items[e.Index];
            var font = new Font((string)ChartSettings.Y1DefaultFontString, comboBox.Font.SizeInPoints, fontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontStyle.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void Y1FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y1FontColor = (Color)Y1FontColorComboBox.SelectedItem;
            Y1FontColorComboBox.Font = new Font(ChartSettings.Y1DefaultFontString, ChartSettings.Y1DefaultFontSize, ChartSettings.Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(Y1FontColorComboBox, ChartSettings.Y1FontColor);
        }

        private void Y1FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font((string)ChartSettings.Y1DefaultFontString, ChartSettings.Y1DefaultFontSize, ChartSettings.Y1DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y1FontColorComboBox, ChartSettings.Y1FontColor);
        }

        private void Y1FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y1FontSize = (float)Y1FontSizeComboBox.SelectedItem;
            Y1FontSizeComboBox.Font = new Font(ChartSettings.Y1DefaultFontString, ChartSettings.Y1FontSize, ChartSettings.Y1DefaultFontStyle);
            //textBox8.Text = ChartSettings.Y1FontSize.ToString();
            //comboBox7.Text = p.GetY1FontSize().ToString();
        }

        private void Y1FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.Items[e.Index];
            var font = new Font((string)ChartSettings.Y1DefaultFontString, (float)fontSize, ChartSettings.Y1DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontSize.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }
        private void Y1MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y1MajorColor = (Color)Y1MajorColorComboBox.SelectedItem;
            Y1MajorColorComboBox.Font = new Font(ChartSettings.Y1DefaultFontString, ChartSettings.Y1DefaultFontSize, ChartSettings.Y1DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(Y1MajorColorComboBox, ChartSettings.Y1MajorColor);
        }
        private void Y1MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font((string)ChartSettings.Y1DefaultFontString, ChartSettings.Y1DefaultFontSize, ChartSettings.Y1FontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y1MajorColorComboBox, ChartSettings.Y1MajorColor);
        }

        //////////////////////////////////////////////////////////////////////////////////////////77
        ///Y2 STUFF
        ///
        private void Y2ComboBoxFonts_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            //ChartSettings.Y2Font = font.Name;
        }

        private void Y2ComboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            Y2ComboBoxFonts.Font = new Font(ChartSettings.Y2FontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);

            Y2ComboBoxFonts.Text = ChartSettings.Y2FontString;
        }

        private void Y2FontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y2FontStyle = (FontStyle)Y2FontStyleComboBox.SelectedItem;
            Y2FontStyleComboBox.Font = new Font(ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2FontStyle);
        }

        private void Y2FontStyleComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontStyle = (FontStyle)comboBox.Items[e.Index];
            var font = new Font((string)ChartSettings.Y2DefaultFontString, comboBox.Font.SizeInPoints, fontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontStyle.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void Y2FontColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y2FontColor = (Color)Y2FontColorComboBox.SelectedItem;
            Y2FontColorComboBox.Font = new Font(ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(Y2FontColorComboBox, ChartSettings.Y2FontColor);
        }

        private void Y2FontColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font((string)ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2FontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y2FontColorComboBox, ChartSettings.Y2FontColor);
        }

        private void Y2FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y2FontSize = (float)Y2FontSizeComboBox.SelectedItem;
            Y2FontSizeComboBox.Font = new Font(ChartSettings.Y2DefaultFontString, ChartSettings.Y2FontSize, ChartSettings.Y2DefaultFontStyle);
            //textBox8.Text = ChartSettings.Y2FontSize.ToString();
            //comboBox7.Text = p.GetY2FontSize().ToString();
        }

        private void Y2FontSizeComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var fontSize = comboBox.Items[e.Index];
            var font = new Font((string)ChartSettings.Y2DefaultFontString, (float)fontSize, ChartSettings.Y2DefaultFontStyle);
            e.DrawBackground();
            e.Graphics.DrawString(fontSize.ToString(), font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }
        private void Y2MajorColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y2MajorColor = (Color)Y2MajorColorComboBox.SelectedItem;
            Y2MajorColorComboBox.Font = new Font(ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(Y2MajorColorComboBox, ChartSettings.Y2MajorColor);
        }
        private void Y2MajorColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font((string)ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(Y2MajorColorComboBox, ChartSettings.Y2MajorColor);
        }


        private void LegendColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font((string)ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(LegendColorComboBox, ChartSettings.LegendColor);
        }

        private void LegendColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y2MajorColor = (Color)Y2MajorColorComboBox.SelectedItem;
            LegendColorComboBox.Font = new Font(ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(LegendColorComboBox, ChartSettings.LegendColor);
        }

        private void BackgroundColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            var comboBox = (ComboBox)sender;
            var color = (Color)comboBox.Items[e.Index];
            SolidBrush brush = new SolidBrush(color);
            var font = new Font((string)ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);
            string colorRemovePart1 = color.ToString().Replace("Color [", "");
            string colorRemovePart2 = colorRemovePart1.Replace("]", "");
            string colorName = colorRemovePart2;
            e.DrawBackground();
            e.Graphics.DrawString(colorName, font, brush, e.Bounds.X, e.Bounds.Y);
            CheckFontColorAndSetBackGroundColor(BackgroundColorComboBox, ChartSettings.BackgroundColor);
        }

        private void BackgroundColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ChartSettings ChartSettings = new ChartSettings();
            //ChartSettings.Y2MajorColor = (Color)Y2MajorColorComboBox.SelectedItem;
            BackgroundColorComboBox.Font = new Font(ChartSettings.Y2DefaultFontString, ChartSettings.Y2DefaultFontSize, ChartSettings.Y2DefaultFontStyle);
            CheckFontColorAndSetBackGroundColor(BackgroundColorComboBox, ChartSettings.BackgroundColor);
        }
        private void LoadCurrentValuesButton_Click(object sender, EventArgs e)
        {
            LoadX1Defaults();
            LoadY1Defaults();
            LoadY2Defaults();
            LoadOtherDefaults();
        }

        private void DefaultsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultsCheckBox.Checked == true)
            {
                ChartSettings.OtherDefaults = true;
            }
            else
            {
                ChartSettings.OtherDefaults = false;
            }
        }
    }
}
