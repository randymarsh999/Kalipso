using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using Npgsql;
using System.IO;
using System.Diagnostics;
using TChart = System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;
//это типа define
using ExcelObj = Microsoft.Office.Interop.Excel;
using Kalipso.Forms;
using System.Reflection;
using System.Xml;
using Microsoft.Office.Core;

namespace Kalipso
{
    /// <summary>
    /// Class for main form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class frmMain : Form
    {
        /// <summary>
        /// The pp
        /// </summary>
        public PiezoParameters PP = new PiezoParameters();
        /// <summary>
        /// The COM
        /// </summary>
        public frmComPort Com = new frmComPort();
        /// <summary>
        /// The FRM database connection
        /// </summary>
        public frmDataBase frmDBConnection = new frmDataBase();
        /// <summary>
        /// The FRM m opt
        /// </summary>
        public frmMeasTempOpt frmMOpt = new frmMeasTempOpt();
        /// <summary>
        /// The FRM gpib
        /// </summary>
        public frmGPIBConfig frmGPIB = new frmGPIBConfig();
        /// <summary>
        /// Flag of hand measurments
        /// </summary>
        public bool hand { get; set; }
        /// <summary>
        /// The graphs
        /// </summary>
        public Graphs graphs = new Graphs();
        /// <summary>
        /// Initializes a new instance of the <see cref="frmMain"/> class.
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
            cmbTreatment.SelectedIndex = 0;
            frmMOpt.Enabled = true;
            hand = false;
            this.Text = "Kalipso " + Application.ProductVersion.ToString();
            //Vers();
        }

        private void HHH1()
        {

            PP.DBTableName = frmMOpt.txtComposition.Text;
            PP.DBSQLConnctionString = frmDBConnection.ConnectionStringToDB;
            PP.LCR_model = frmMOpt.cbGPIBDevModel.Text;

            PP.BiasUCurrent = Convert.ToDouble(frmMOpt.txtUcur.Text);
            PP.BiasUmax = Convert.ToDouble(frmMOpt.txtUmax.Text);
            PP.TimeStartU = Convert.ToInt32(frmMOpt.txtTimeStartU.Text) * 1000;
            PP.TimePeriodU = Convert.ToInt32(frmMOpt.txtPeriodU.Text) * 1000;

            PP.thicknes = Convert.ToDouble(frmMOpt.txtHeight.Text);
            PP.diametr = Convert.ToDouble(frmMOpt.txtDiameter.Text);
            PP.TemperatureStep = Convert.ToDouble(frmMOpt.txtTempStep.Text);
            Thread.Sleep(1000);
        }

        private void HHH(object state, ElapsedEventArgs e)
        {
            PP.DBTableName = frmMOpt.txtComposition.Text;
            PP.DBSQLConnctionString = frmDBConnection.ConnectionStringToDB;
            PP.LCR_model = frmMOpt.cbGPIBDevModel.Text;

            PP.BiasUCurrent = Convert.ToDouble(frmMOpt.txtUcur.Text);
            PP.BiasUmax = Convert.ToDouble(frmMOpt.txtUmax.Text);
            PP.TimeStartU = Convert.ToInt32(frmMOpt.txtTimeStartU.Text) * 1000;
            PP.TimePeriodU = Convert.ToInt32(frmMOpt.txtPeriodU.Text) * 1000;

            PP.thicknes = Convert.ToDouble(frmMOpt.txtHeight.Text);
            PP.diametr = Convert.ToDouble(frmMOpt.txtDiameter.Text);
            PP.TemperatureStep = Convert.ToDouble(frmMOpt.txtTempStep.Text);
        }
        /// <summary>
        /// Handles the 1 event of the btnCalcPiezo_Click control.
        /// Calculate all piezo properties
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCalcPiezo_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbOperator.SelectedIndex == -1)
                {
                    MessageBox.Show("You must choice operator");
                }

                for (int i = 0; i < dGridPiezo.RowCount - 1; i++)
                {

                    PiezoMathCalculation pm = new PiezoMathCalculation();
                    //расчет диэлектрической проницаемости до поляризации
                    if (dGridPiezo["C_pF", i].Value.ToString() != "" &&
                                    dGridPiezo["composition", i].Value.ToString() != "" &&
                                    dGridPiezo["d_cm", i].Value.ToString() != "")
                    {
                        dGridPiezo["e_re", i].Value = pm.e_re(Convert.ToDouble(dGridPiezo["composition", i].Value.ToString()),
                        Convert.ToDouble(dGridPiezo["d_cm", i].Value.ToString().ToString()),
                        Convert.ToDouble(dGridPiezo["C_pF", i].Value.ToString().ToString())).ToString();
                    }
                    //расчет диэлектрической проницаемости после поляризации
                    if (dGridPiezo["C_pF_ap", i].Value.ToString() != "" &&
                        dGridPiezo["composition", i].Value.ToString() != "" &&
                        dGridPiezo["d_cm", i].Value.ToString() != "")
                    {
                        dGridPiezo["e33t_e0", i].Value = pm.e_re(Convert.ToDouble(dGridPiezo["composition", i].Value.ToString()),
                                                               Convert.ToDouble(dGridPiezo["d_cm", i].Value.ToString()),
                                                               Convert.ToDouble(dGridPiezo["C_pF_ap", i].Value.ToString())).ToString();
                    }
                    //расчет Kp
                    if (dGridPiezo["fr1_Hz", i].Value.ToString() != "" &&
                        dGridPiezo["fa1_Hz", i].Value.ToString() != "" &&
                        dGridPiezo["fr3_Hz", i].Value.ToString() != "")
                    {
                        dGridPiezo["Kp", i].Value = pm.Kp(Convert.ToInt32(dGridPiezo["fr1_Hz", i].Value.ToString()),
                                                           Convert.ToInt32(dGridPiezo["fa1_Hz", i].Value.ToString()),
                                                           Convert.ToInt32(dGridPiezo["fr3_Hz", i].Value.ToString())).ToString();
                    }
                    //расчет Kt
                    if (dGridPiezo["fa5_Hz", i].Value.ToString() != "" &&
                        dGridPiezo["fr5_Hz", i].Value.ToString() != "")
                    {
                        dGridPiezo["Kt", i].Value = pm.Kt(Convert.ToInt32(dGridPiezo["fr5_Hz", i].Value.ToString()),
                                                   Convert.ToInt32(dGridPiezo["fa5_Hz", i].Value.ToString())).ToString();
                    }
                    //расчет пьезомодуля d31 
                    if (dGridPiezo["e33t_e0", i].Value.ToString() != "" &&
                                dGridPiezo["pexp", i].Value.ToString() != "" &&
                                dGridPiezo["Kp", i].Value.ToString() != "" &&
                                dGridPiezo["d_cm", i].Value.ToString() != "" &&
                                dGridPiezo["fr1_Hz", i].Value.ToString() != ""
                                )
                    {
                        dGridPiezo["d31", i].Value = pm.d31(Convert.ToInt32(dGridPiezo["e33t_e0", i].Value.ToString()),
                                                           Convert.ToDouble(dGridPiezo["pexp", i].Value.ToString()),
                                                           Convert.ToDouble(dGridPiezo["Kp", i].Value.ToString()),
                                                           Convert.ToDouble(dGridPiezo["d_cm", i].Value.ToString()),
                                                           Convert.ToInt32(dGridPiezo["fr1_Hz", i].Value.ToString())).ToString();
                    }
                    //расчет пьезомодуля Qm 
                    if (dGridPiezo["fr1_Hz", i].Value.ToString() != "" &&
                                dGridPiezo["fa1_Hz", i].Value.ToString() != "" &&
                                dGridPiezo["C_pF_ap", i].Value.ToString() != "" &&
                                dGridPiezo["Rr_Om", i].Value.ToString() != "")
                    {
                        dGridPiezo["Qm", i].Value = pm.Qm(Convert.ToInt32(dGridPiezo["fr1_Hz", i].Value.ToString()),
                                                           Convert.ToInt32(dGridPiezo["fa1_Hz", i].Value.ToString()),
                                                           Convert.ToDouble(dGridPiezo["C_pF_ap", i].Value.ToString()),
                                                           Convert.ToDouble(dGridPiezo["Rr_Om", i].Value.ToString())).ToString();
                    }
                    //расчет пьезомодуля Y11E
                    if (dGridPiezo["fr1_Hz", i].Value.ToString() != "" &&
                                dGridPiezo["d_cm", i].Value.ToString() != "" &&
                                dGridPiezo["pexp", i].Value.ToString() != "" &&
                                dGridPiezo["Kp", i].Value.ToString() != "")
                    {
                        dGridPiezo["Y11E", i].Value = pm.Y11E(Convert.ToInt32(dGridPiezo["fr1_Hz", i].Value.ToString()),
                                                   Convert.ToDouble(dGridPiezo["d_cm", i].Value.ToString()),
                                                   Convert.ToDouble(dGridPiezo["pexp", i].Value.ToString())).ToString();
                    }
                    //расчет пьезомодуля V1E (скорость звука)
                    if (dGridPiezo["fr1_Hz", i].Value.ToString() != "" &&
                               dGridPiezo["d_cm", i].Value.ToString() != "" &&
                               dGridPiezo["Kp", i].Value.ToString() != "")
                    {
                        dGridPiezo["V1E", i].Value = pm.V1E(Convert.ToDouble(dGridPiezo["d_cm", i].Value.ToString()),
                            Convert.ToInt32(dGridPiezo["fr1_Hz", i].Value.ToString())).ToString();
                    }
                    //расчет пьезочувствительности g31 
                    if (dGridPiezo["d31", i].Value.ToString() != "" &&
                        dGridPiezo["e33t_e0", i].Value.ToString() != "")
                    {
                        dGridPiezo["g31", i].Value = pm.g31(Convert.ToDouble(dGridPiezo["d31", i].Value.ToString()),
                            Convert.ToInt32(dGridPiezo["e33t_e0", i].Value.ToString())).ToString();
                    }
                    //расчет пьезочувствительности g33 
                    if (dGridPiezo["d33", i].Value.ToString() != "" &&
                               dGridPiezo["e33t_e0", i].Value.ToString() != "")
                    {
                        dGridPiezo["g33", i].Value = pm.g33(Convert.ToInt32(dGridPiezo["d33", i].Value.ToString()),
                            Convert.ToInt32(dGridPiezo["e33t_e0", i].Value.ToString())).ToString();
                    }
                    //расчет d33/sqr(e33t_e0)
                    if (dGridPiezo["d33", i].Value.ToString() != "" &&
                               dGridPiezo["e33t_e0", i].Value.ToString() != "")
                    {
                        dGridPiezo["d33_re_sqr_e33", i].Value = pm.d33_re_sqr_e33(Convert.ToInt32(dGridPiezo["d33", i].Value.ToString()),
                            Convert.ToInt32(dGridPiezo["e33t_e0", i].Value.ToString())).ToString();
                    }
                    dGridPiezo["Time", i].Value = DateTime.Now.ToLongTimeString();
                    dGridPiezo["Date", i].Value = DateTime.Now.Date.ToShortDateString();

                    if (cmbOperator.SelectedIndex != -1)
                    {
                        dGridPiezo["Time", i].Value = cmbOperator.SelectedItem.ToString();

                    }
                    else MessageBox.Show("You must choice operator");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        /// <summary>
        /// Handles the Click event of the comPortToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Com.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            PiezoMathCalculation tt = new PiezoMathCalculation();
            tt.SetSigmaMas();
        }
        /// <summary>
        /// Handles the Activated event of the frmMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmMain_Activated(object sender, EventArgs e)
        {
            try
            {
                lbTemp.Text = Com.Temperature;
            }
            catch (Exception ex)
            {
                ex.ToString();
                //MessageBox.Show("ERROR: " + ex.ToString());
                lbTemp.Text = "None";
                return;
            }
        }
        /// <summary>
        /// Handles the Click event of the button3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connect = "Server=10.11.0.2;Port=5432;User Id=postgres;Password=nii011235813;Database=postgres";
                NpgsqlConnection pgcon = new NpgsqlConnection(connect);
                pgcon.Open();
                string sql = "create table ss(id int);";
                NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
                CSend.ExecuteNonQuery();
                pgcon.Close();
            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
        /// <summary>
        /// Handles the Click event of the dataBaseConnectionToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataBaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the closeToolStripMenuItem control. Close Main form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain.ActiveForm.Close();
        }
        /// <summary>
        /// Handles the Click event of the button4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the button5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button5_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the piezoToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void piezoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oDlgPiezo.ShowDialog();
        }
        /// <summary>
        /// Handles the FileOk event of the oDlgPiezo control.
        /// Show open file dialog for Piezo
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void oDlgPiezo_FileOk(object sender, CancelEventArgs e)
        {
            FileJob fj = new FileJob();
            fj.LoadExcelFileToDataGridView(dGridPiezo, oDlgPiezo.FileName);
        }
        /// <summary>
        /// Handles the Tick event of the Time control.
        /// Showyime in status bar
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Time_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Time: " + DateTime.Now.ToLongTimeString();
            //с милисекундами
            //string dateformat = "hh:mm: ss.fff";
            //DateTime dateT = new DateTime();
            //dateT = DateTime.Now;
            //dateT.AddMilliseconds(1);
            //toolStripStatusLabel1.Text = "Time: " + dateT.ToString(dateformat);

            //toolStripStatusLabel1.Text = "Time: " + DateTime.Now.AddMilliseconds();
            //формат даты 01.01.2000
            //toolStripStatusLabel1.Text = "Time: " + DateTime.Now.ToShortDateString();
        }
        /// <summary>
        /// Handles the Click event of the tempmeasToolStripMenuItem control.
        /// Show save dialog for temperature measurments
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tempmeasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (frmMOpt.cWorkMode.Text)
            {
                case "Cycle":
                    {
                        sDlg.FileName = frmMOpt.txtComposition.Text + "_cycle_" + DateTime.Now.ToShortDateString();
                        break;
                    }
                case "Cycle_ramp":
                    {
                        sDlg.FileName = frmMOpt.txtComposition.Text + "_CycleRamp_" + DateTime.Now.ToShortDateString();
                        break;
                    }
                default:
                    sDlg.FileName = frmMOpt.txtComposition.Text + "_" + DateTime.Now.ToShortDateString();
                    PP.FileNameSaveTempMeasDB = frmMOpt.txtComposition.Text + "_DB_" + DateTime.Now.ToShortDateString();
                    PP.FileNameSaveTempMeasDBLog = frmMOpt.txtComposition.Text + "_Log_" + DateTime.Now.ToShortDateString();
                    break;
            }
            //tempMeasFullToolStripMenuItem.Enabled = true;
            //sDlg.FileName = PP.FileNameSaveTempMeasDB;
            sDlg.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the piezoToolStripMenuItem1 control.
        /// Show save dialog for piezo measurments
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void piezoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sDlgPiezo.ShowDialog();
        }
        /// <summary>
        /// Handles the FileOk event of the sDlgPiezo control.
        /// Save data to excel from datagrid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void sDlgPiezo_FileOk(object sender, CancelEventArgs e)
        {
            FileJob nn = new FileJob();
            nn.SaveToExcelFromDataGridView(dGridPiezo, sDlgPiezo.FileName);
        }
        /// <summary>
        /// Handles the Click event of the tempMeasOptionsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tempMeasOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMOpt.Show();
        }
        /// <summary>
        /// Handles the Click event of the gPIBConfigurationToolStripMenuItem control.
        /// Show frmGPIB form
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gPIBConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGPIB.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the FileOk event of the oDlgTreat control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void oDlgTreat_FileOk(object sender, CancelEventArgs e)
        {
            switch (PP.OpenSortingType)
            {
                case "DNON_RNON":
                    {
                        DNON_RNON_Import(oDlgTreatConverting.FileName);
                        break;
                    }
                case "Simple":
                    {
                        int cst = 0;
                        DataTable dt = new DataTable();
                        toolStripStatusLabel2.Text = "Open file: " + oDlgTreatConverting.FileName;
                        DataRow row;
                        FileJob FJ = new FileJob();

                        string[] s;
                        try
                        {
                            s = FJ.ReadF(oDlgTreatConverting.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return;
                        }
                        for (int i = 0; i < s.GetLength(0); i++)
                        {
                            ParseStringTab p = new ParseStringTab();
                            ParseStringTab p1 = new ParseStringTab();
                            p.AddString(s[i]);
                            //создание заголовков таблицы 
                            if (i == 0)
                            {
                                p.AddString(s[i]);
                                IEnumerable<string> pdis = p.Distinct();
                                cst = pdis.Count();
                                foreach (string st in pdis)
                                {
                                    p1.Add(st);
                                }
                                for (int j = 0; j < p1.Count; j++)
                                {
                                    p1[j] = FJ.CorrectHead(p1[j]);
                                    dt.Columns.Add(p1[j]);
                                }
                            }
                            else
                            {
                                //цикл для сортировки
                                int x = 0;
                                row = dt.NewRow();
                                for (int j = 0; j < p.Count(); j++)
                                {
                                    try
                                    {
                                        row[x] = p[j];
                                        ++x;
                                        if (x == cst)
                                        {
                                            dt.Rows.Add(row);
                                            row = dt.NewRow();
                                            x = 0;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }
                            }
                            p.Clear();
                        }
                        dTreatmentIn.DataSource = dt;
                        break;
                    }
                case "LoadFileExcel":
                    {
                        FileJob FJ = new FileJob();
                        FJ.LoadExcelFileToDataGridView(dTreatmentIn, oDlgTreatConverting.FileName);
                        break;
                    }
                case "LoadFileText":
                    {
                        int cst = 0;
                        DataTable dt = new DataTable();
                        toolStripStatusLabel2.Text = "Open file: " + oDlgTreatConverting.FileName;
                        DataRow row;
                        FileJob FJ = new FileJob();
                        string[] s;
                        try
                        {
                            s = FJ.ReadF(oDlgTreatConverting.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                            return;
                        }
                        for (int i = 0; i < s.Length; i++)
                        {
                            ParseStringTab p = new ParseStringTab();
                            ParseStringTab p1 = new ParseStringTab();
                            p.AddString(s[i]);
                            //создание заголовков таблицы 
                            if (i == 0)
                            {
                                p.AddString(s[i]);
                                IEnumerable<string> pdis = p.Distinct();
                                cst = pdis.Count();

                                foreach (string st in pdis)
                                {
                                    p1.Add(st);
                                }
                                for (int j = 0; j < p1.Count; j++)
                                {
                                    dt.Columns.Add(p1[j]);
                                }
                            }
                            else
                            {
                                //цикл для сортировки
                                int x = 0;
                                row = dt.NewRow();
                                for (int j = 0; j < p.Count(); j++)
                                {
                                    try
                                    {
                                        row[x] = p[j];
                                        ++x;
                                        if (x == cst)
                                        {
                                            dt.Rows.Add(row);
                                            row = dt.NewRow();
                                            x = 0;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                }
                            }
                            p.Clear();
                        }
                        dTreatmentIn.DataSource = dt;
                        break;
                    }
                default: break;
            }
        }
        /// <summary>
        /// DNON\RNON import.
        /// </summary>
        public void DNON_RNON_Import(string OpenFileDNON)
        {
            int cst = 0;
            DataTable dt = new DataTable();
            toolStripStatusLabel2.Text = "Open file: " + OpenFileDNON;
            string fileN1 = OpenFileDNON;
            string fileN2 = OpenFileDNON.Substring(0, OpenFileDNON.Length - 8) + "RNON.txt";
            DataRow row;
            FileJob FJ = new FileJob();
            string[] s;
            try
            {
                s = FJ.ReadF(OpenFileDNON);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            for (int i = 0; i < s.GetLength(0); i++)
            {
                ParseStringTab p = new ParseStringTab();
                ParseStringTab p1 = new ParseStringTab();
                p.AddString(s[i]);
                //создание заголовков таблицы 
                if (i == 0)
                {
                    p.AddString(s[i]);
                    IEnumerable<string> pdis = p.Distinct();
                    cst = pdis.Count();
                    foreach (string st in pdis)
                    {
                        p1.Add(st);
                    }
                    for (int j = 0; j < p1.Count; j++)
                    {
                        p1[j] = FJ.CorrectHead(p1[j]);
                        dt.Columns.Add(p1[j]);
                    }
                }
                else
                {
                    //цикл для сортировки
                    int x = 0;
                    row = dt.NewRow();
                    for (int j = 0; j < p.Count(); j++)
                    {
                        try
                        {
                            row[x] = p[j];
                            ++x;
                            if (x == cst)
                            {
                                dt.Rows.Add(row);
                                row = dt.NewRow();
                                x = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                p.Clear();
            }

            try
            {
                s = FJ.ReadF(fileN2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            for (int i = 1; i < s.GetLength(0); i++)
            {
                ParseStringTab p = new ParseStringTab();
                ParseStringTab p1 = new ParseStringTab();
                p.AddString(s[i]);
                int x = 0;
                row = dt.NewRow();
                for (int j = 0; j < p.Count(); j++)
                {
                    try
                    {
                        row[x] = p[j];
                        ++x;
                        if (x == cst)
                        {
                            dt.Rows.Add(row);
                            row = dt.NewRow();
                            x = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                p.Clear();
            }
            dTreatmentIn.DataSource = dt;

            string[] s1 = OpenFileDNON.Split('\\');
            string[] s2 = s1[s1.Length - 1].Split('.');
            PP.DBTableName = s2[0].Substring(0, s2[0].Length - 4);

        }
        /// <summary>
        /// Handles the FileOk event of the sDlg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs" /> instance containing the event data.</param>
        private void sDlg_FileOk(object sender, CancelEventArgs e)
        {
            PP.FileNameSaveTempMeas = "";
            PP.FileNameSaveTempMeasDB = "";

            switch (frmMOpt.cbExportDBMeasTemp.Text)
            {
                //None
                //Export to DB parallel
                //Export to DB(only)
                case "Export to DB parallel": PP.FileNameSaveTempMeasDB = sDlg.FileName; break;
                case "Export to DB(only)":
                    {
                        //экспорт данных в текстовый файл во время измерения                        
                        this.txtLog.AppendText(sDlg.FileName + Environment.NewLine);
                        FileJob fj = new FileJob();
                        PP.FileNameSaveTempMeasDB = sDlg.FileName;
                        string[] s = sDlg.FileName.Split('\\');
                        for (int i = 0; i < s.Length - 1; i++)
                        {
                            PP.FileNameSaveTempMeas += s[i] + '\\';
                        }
                        PP.FileNameSaveTempMeas += frmMOpt.txtComposition.Text + "_temperature_" + DateTime.Now.Date.ToShortDateString() + ".txt";
                        //PP.FileNameSaveTempMeas = sDlg.FileName + "_temperature.txt";

                        Logo(this.txtLog, PP.FileNameSaveTempMeasDB + Environment.NewLine);
                        Logo(this.txtLog, PP.FileNameSaveTempMeas + Environment.NewLine);
                        //this.txtLog.AppendText(PP.FileNameSaveTempMeasDB + Environment.NewLine);
                        break;
                    }
                default:
                    PP.FileNameSaveTempMeas = sDlg.FileName;
                    break;
            }

        }
        /// <summary>
        /// логирование данных в окно логирования если включен переключатель chkLogo
        /// </summary>
        /// <param name="txtlog"></param>
        /// <param name="LoggingText"></param>
        public void Logo(TextBox txtlog, string LoggingText)

        {
            if (chkLogo.Checked == true)
            {
                txtlog.AppendText(LoggingText);
            }
        }
        /// <summary>
        /// Handles the Click event of the treatmentToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void treatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oDlgTreatConverting.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the treatmentToolStripMenuItem1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void treatmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the FileOk event of the sTreatment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void sTreatment_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                ExcelObj.Application app = new ExcelObj.Application();
                ExcelObj.Workbook workbook = app.Workbooks.Add();
                ExcelObj.Worksheet worksheet = workbook.ActiveSheet;

                for (int i = 1; i < dTreatmentIn.RowCount + 1; i++)
                {
                    for (int j = 1; j < dTreatmentIn.ColumnCount + 1; j++)
                    {
                        worksheet.Rows[i].Columns[j] = dTreatmentIn.Rows[i - 1].Cells[j - 1].Value;
                    }
                }
                app.AlertBeforeOverwriting = false;
                workbook.SaveAs(sTreatment.FileName);
                app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        /// <summary>
        /// Handles the Click event of the label3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void label3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the TextChanged event of the textBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the btnTreatment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTreatment_Click(object sender, EventArgs e)
        {
            //расчет глубины дисперсии для всех температур
            if (cmbTreatment.SelectedIndex == 0)
            {
                //min f
                int minf;
                //max f
                int maxf;
                //e/e0 at min f
                double e_e0_f_min;
                //e/e0 at max f
                double e_e0_f_max;

                //int min_cycle;
                //int max_cycle;

                int mint;
                int maxt;
                //int mini = 0;
                //int maxi = 0;

                mint = Convert.ToInt32(dTreatmentIn["T_K", 0].Value.ToString());
                maxt = Convert.ToInt32(dTreatmentIn["T_K", 0].Value.ToString());
                minf = Convert.ToInt32(dTreatmentIn["f_Hz", 0].Value.ToString());
                maxf = Convert.ToInt32(dTreatmentIn["f_Hz", 0].Value.ToString());
                //min_cycle = Convert.ToInt32(dTreatment["Timer_disp", 0].Value.ToString());
                //max_cycle = Convert.ToInt32(dTreatment["Timer_disp", 0].Value.ToString());
                e_e0_f_min = Convert.ToDouble(dTreatmentIn["e_re", 0].Value.ToString());
                e_e0_f_max = Convert.ToDouble(dTreatmentIn["e_re", 0].Value.ToString());

                string s = "id";
                dTreatmentIn.Columns.Add(s, "id");

                s = "DispersionDepth";
                dTreatmentIn.Columns.Add(s, "DispersionDepth");
                MessageBox.Show((dTreatmentIn.RowCount - 2).ToString());
                try
                {
                    for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                    {
                        dTreatmentIn["id", i].Value = i.ToString();
                        if (dTreatmentIn["T_K", i].Value.ToString() == "")
                        {
                            ++i;
                            dTreatmentIn["id", i].Value = i.ToString();
                        }
                        else
                        {
                            if (mint == Convert.ToInt32(dTreatmentIn["T_K", i].Value.ToString()))
                            {
                                if (minf < Convert.ToInt32(dTreatmentIn["f_Hz", i].Value.ToString()) &&
                                    maxf < Convert.ToInt32(dTreatmentIn["f_Hz", i].Value.ToString())
                                    )
                                {
                                    maxf = Convert.ToInt32(dTreatmentIn["f_Hz", i].Value.ToString());
                                    e_e0_f_max = Convert.ToDouble(dTreatmentIn["e_re", i].Value.ToString());
                                }
                            }
                            else if (mint < Convert.ToInt32(dTreatmentIn["T_K", i].Value.ToString()))
                            {
                                PiezoMathCalculation pm = new PiezoMathCalculation();
                                double dd = pm.DisperionDepth(e_e0_f_min, e_e0_f_max);
                                dTreatmentIn["DispersionDepth", i - 1].Value = dd.ToString();
                                mint = Convert.ToInt32(dTreatmentIn["T_K", i].Value.ToString());
                                minf = Convert.ToInt32(dTreatmentIn["f_Hz", i].Value.ToString());
                                maxf = Convert.ToInt32(dTreatmentIn["f_Hz", i].Value.ToString());
                                e_e0_f_min = Convert.ToDouble(dTreatmentIn["e_re", i].Value.ToString());
                            }
                            if (i == dTreatmentIn.RowCount - 2)
                            {
                                PiezoMathCalculation pm = new PiezoMathCalculation();
                                double dd = pm.DisperionDepth(e_e0_f_min, e_e0_f_max);
                                dTreatmentIn["DispersionDepth", i].Value = dd.ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            //Degree of blurring (степень размытия)
            if (cmbTreatment.SelectedIndex == 1)
            {
                return;
            }
            //Find maximum from T range
            if (cmbTreatment.SelectedIndex == 2)
            {

                DataTable dt = new DataTable();
#pragma warning disable CS0168 // Переменная "row" объявлена, но ни разу не использована.
                DataRow row;
#pragma warning restore CS0168 // Переменная "row" объявлена, но ни разу не использована.
                FileJob FJ = new FileJob();
                ParseStringTab parse = new ParseStringTab();
                ParseStringTab f = new ParseStringTab();
                ParseStringTab T_K = new ParseStringTab();

                for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                {
                    parse.AddString(dTreatmentIn["f_Hz", i].Value.ToString());
                }
                IEnumerable<string> pdis = parse.Distinct();
                int cst = pdis.Count();
                foreach (string st in pdis)
                {
                    f.Add(st);
                }
                dt.Columns.Add("f_Hz");
                dt.Columns.Add("T_K");
                dt.Columns.Add("e_re");
                dt.Columns.Add("e_im");
                dTreatmentOut.DataSource = dt;
                ((DataTable)dTreatmentOut.DataSource).Rows.Add();
                for (int j = 0; j < f.Count; j++)
                {
                    dTreatmentOut["f_Hz", j].Value = f[j];
                    ((DataTable)dTreatmentOut.DataSource).Rows.Add();
                }

                parse.Clear();
                for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                {
                    parse.AddString(dTreatmentIn["T_K", i].Value.ToString());
                }
                pdis = parse.Distinct();
                foreach (string st in pdis)
                {
                    T_K.Add(st);
                }

                //MessageBox.Show(T_K.Count.ToString());

                Int32[] f_hz = new Int32[f.Count];
                //string[,] e_re = new string[f.Count, T_K.Count];
                double[,] e_re = new double[f.Count, T_K.Count];
                //string[,] e_im = new string[f.Count, T_K.Count];
                double[,] e_im = new double[f.Count, T_K.Count];
                //string[,] Y = new string[f.Count, T_K.Count];
                double[,] Y = new double[f.Count, T_K.Count];
                double[] T = new double[T_K.Count];

                //заполнение массива Т
                {
                    int o = 0;
                    for (int i = 0; i < T.Length; i++)
                    {
                        try
                        {
                            if (double.TryParse(T_K[i], out T[i]) == true)
                            {
                                T[i] = Convert.ToDouble(T_K[i]);
                            }
                            o = i;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString() + " " + o.ToString() + " shit_T");
                            return;
                        }
                    }
                }
                //заполнение массива e_re
                {
                    int CurL = 0;
                    for (int r = 0; r < dTreatmentOut.RowCount - 1; r++)
                    {
                        for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                        {
                            if (dTreatmentIn["f_Hz", i].Value.ToString() == dTreatmentOut["f_Hz", r].Value.ToString())
                            {
                                try
                                {
                                    //string q = dTreatmentIn["e_re", i].Value.ToString();
                                    //dTreatmentIn["e_re", i].Value = q.Substring(0, q.Length);
                                    //e_re[r, CurL] = (dTreatmentIn["e_re", i].Value.ToString());
                                    if (double.TryParse(dTreatmentIn["e_re", i].Value.ToString(), out e_re[r, CurL]) == true)
                                    {
                                        e_re[r, CurL] = (Convert.ToDouble(dTreatmentIn["e_re", i].Value.ToString()));
                                    }
                                    CurL++;
                                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                {
                                    MessageBox.Show(i.ToString() + " " + dTreatmentIn["e_re", i].Value.ToString() + " e_re");
                                    return;
                                }
                            }
                        }
                        CurL = 0;
                    }
                }

                //заполнение массива e_im
                {
                    int CurL = 0;
                    for (int r = 0; r < dTreatmentOut.RowCount - 1; r++)
                    {
                        for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                        {
                            if (dTreatmentIn["f_Hz", i].Value.ToString() == dTreatmentOut["f_Hz", r].Value.ToString())
                            {
                                if (double.TryParse(dTreatmentIn["e_im", i].Value.ToString(), out e_im[r, CurL]) == true)
                                {
                                    e_im[r, CurL] = (Convert.ToDouble(dTreatmentIn["e_im", i].Value.ToString()));
                                }
                                try
                                {
                                    //e_im[r, CurL] = (dTreatmentIn["e_im", i].Value.ToString());
                                    CurL++;
                                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                {
                                    MessageBox.Show(i.ToString() + " shit_e_im");
                                    return;
                                }
                            }
                        }
                        CurL = 0;
                    }

                }

                //заполнение массива Y
                {
                    int CurL = 0;
                    for (int r = 0; r < dTreatmentOut.RowCount - 1; r++)
                    {
                        for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                        {
                            if (dTreatmentIn["f_Hz", i].Value.ToString() == dTreatmentOut["f_Hz", r].Value.ToString())
                            {
                                if (double.TryParse(dTreatmentIn["Y", i].Value.ToString(), out Y[r, CurL]) == true)
                                {
                                    Y[r, CurL] = (Convert.ToDouble(dTreatmentIn["Y", i].Value.ToString()));
                                }
                                try
                                {
                                    //Y[r, CurL] = (dTreatmentIn["e_im", i].Value.ToString());
                                    CurL++;
                                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                {
                                    MessageBox.Show(i.ToString() + " shit_Y");
                                    return;
                                }
                            }
                        }
                        CurL = 0;
                    }
                }

                //chart построение графика
                {
                    chartTreatment.Series.Clear();
                    chartTreatment.Series.Add("e_re");
                    chartTreatment.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    chartTreatment.Series[0].Color = Color.Red;

                    double[] e_re_ap = new double[Convert.ToInt32(txtTreatMaxT.Text) - Convert.ToInt32(txtTreatMinT.Text)];
                    double[] T_ap = new double[Convert.ToInt32(txtTreatMaxT.Text) - Convert.ToInt32(txtTreatMinT.Text)];
                    int j = 0;
                    for (int i = Convert.ToInt32(txtTreatMinT.Text); i < Convert.ToInt32(txtTreatMaxT.Text); i++)
                    {
                        int o = 0;

                        try
                        {
                            o = i;
                            chartTreatment.Series[0].Points.AddXY(T[i], Convert.ToDouble(e_re[0, i].ToString()));
                            e_re_ap[j] = Convert.ToDouble(e_re[0, i].ToString());
                            T_ap[j] = T[i];
                        }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                        catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                        {
                            MessageBox.Show(o.ToString() + " " + T[i].ToString() + " " + e_re[0, i].ToString());
                            return;
                        }
                        j++;
                    }

                    //аппроксимация кривой пока не надо, но есть

#pragma warning disable CS0168 // Переменная "cc1" объявлена, но ни разу не использована.
                    alglib.spline1dinterpolant cc1;
#pragma warning restore CS0168 // Переменная "cc1" объявлена, но ни разу не использована.
                    alglib.spline1dfitreport rep;
                    int info;
                    double rho = Convert.ToDouble(txtRho.Text);//number of regularization
                    Int32 M = Convert.ToInt32(txtM.Text); // number of basis functions
                    double v;
                    alglib.spline1dfitpenalized(T_ap, e_re_ap, M, rho, out info, out alglib.spline1dinterpolant cc, out rep);
                    chartTreatment.Series.Add("e_re_ap");
                    chartTreatment.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    chartTreatment.Series[1].Color = Color.Green;

                    //for (int i = 300; i < 700; i++)
                    for (int i = Convert.ToInt32(T_K[Convert.ToInt32(txtTreatMinT.Text)]); i < Convert.ToInt32(T_K[Convert.ToInt32(txtTreatMaxT.Text)]); i++)
                    {
                        alglib.spline1ddiff(cc, (double)i / 100, out double s, out double ds, out double d2s);
                        v = alglib.spline1dcalc(cc, (double)i / 1.0);
                        chartTreatment.Series[1].Points.AddXY(i, v);
                    }
                }

                //конечная обработка данных
                for (int i = 0; i < dTreatmentOut.RowCount - 2; i++)
                {
                    double[] tt = new double[e_re.GetLength(1)];
                    for (int q = 0; q < tt.Length; q++)
                    {
                        tt[q] = Convert.ToDouble(e_re[i, q]);
                    }
                    PiezoMathCalculation PM = new PiezoMathCalculation();
                    Int32 o = PM.FindIndexOfMaxValFromArrayInterval(tt, Convert.ToInt32(txtTreatMinT.Text), Convert.ToInt32(txtTreatMaxT.Text));
                    tBoxTreatment.AppendText(o.ToString() + Environment.NewLine);
                    dTreatmentOut["e_re", i].Value = e_re[i, o];
                    dTreatmentOut["e_im", i].Value = e_im[i, o];
                    dTreatmentOut["T_K", i].Value = T[o];
                }
            }

            if (cmbTreatment.SelectedIndex == 3)
            {

                DataTable dt = new DataTable();
#pragma warning disable CS0168 // Переменная "row" объявлена, но ни разу не использована.
                DataRow row;
#pragma warning restore CS0168 // Переменная "row" объявлена, но ни разу не использована.
                FileJob FJ = new FileJob();
                ParseStringTab parse = new ParseStringTab();
                ParseStringTab f = new ParseStringTab();
                ParseStringTab T_K = new ParseStringTab();
                ParseStringTab cyc = new ParseStringTab();

                //заполнение структуры f
                for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                {
                    parse.AddString(dTreatmentIn["f_Hz", i].Value.ToString());
                }
                IEnumerable<string> pdis = parse.Distinct();
                int cst = pdis.Count();
                foreach (string st in pdis)
                {
                    f.Add(st);
                }


                dt.Columns.Add("f_Hz");
                dt.Columns.Add("T_K");
                dt.Columns.Add("e_re");
                dt.Columns.Add("e_im");
                dt.Columns.Add("Cycle");
                dTreatmentOut.DataSource = dt;

                ((DataTable)dTreatmentOut.DataSource).Rows.Add();

                //for (int j = 0; j < f.Count; j++)
                //{
                //    dTreatmentOut["f_Hz", j].Value = f[j];
                //    ((DataTable)dTreatmentOut.DataSource).Rows.Add();
                //}


                //Заполнение структуры T
                {
                    parse.Clear();
                    for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                    {
                        parse.AddString(dTreatmentIn["T_K", i].Value.ToString());
                    }
                    pdis = parse.Distinct();
                    foreach (string st in pdis)
                    {
                        T_K.Add(st);
                    }
                }

                //заполнение структуры cycle
                parse.Clear();
                for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                {
                    parse.AddString(dTreatmentIn["Cycle", i].Value.ToString());
                }
                pdis = parse.Distinct();
                foreach (string st in pdis)
                {
                    cyc.Add(st);
                }



                Int32[] f_hz = new Int32[f.Count];
                string[,] e_re = new string[f.Count, T_K.Count];
                string[,] e_im = new string[f.Count, T_K.Count];
                string[,] Y = new string[f.Count, T_K.Count];
                double[] T = new double[T_K.Count];
                double[] cycle = new double[cyc.Count];

                //заполнение массива Т
                {
                    for (int i = 0; i < T.Length; i++)
                    {
                        T[i] = Convert.ToDouble(T_K[i]);
                    }
                }

                //заполнение массива e_re
                {
                    int CurL = 0;
                    for (int r = 0; r < dTreatmentOut.RowCount - 1; r++)
                    {
                        for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                        {
                            if (dTreatmentIn["f_Hz", i].Value.ToString() == dTreatmentOut["f_Hz", r].Value.ToString())
                            {
                                try
                                {
                                    e_re[r, CurL] = (dTreatmentIn["e_re", i].Value.ToString());
                                    CurL++;
                                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                {
                                    MessageBox.Show(i.ToString() + " shit");
                                    return;
                                }
                            }
                        }
                        CurL = 0;
                    }

                }

                //заполнение массива e_im
                {
                    int CurL = 0;
                    for (int r = 0; r < dTreatmentOut.RowCount - 1; r++)
                    {
                        for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                        {
                            if (dTreatmentIn["f_Hz", i].Value.ToString() == dTreatmentOut["f_Hz", r].Value.ToString())
                            {
                                try
                                {
                                    e_im[r, CurL] = (dTreatmentIn["e_im", i].Value.ToString());
                                    CurL++;
                                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                {
                                    MessageBox.Show(i.ToString() + " shit");
                                    return;
                                }
                            }
                        }
                        CurL = 0;
                    }

                }

                //заполнение массива Y
                {
                    int CurL = 0;
                    for (int r = 0; r < dTreatmentOut.RowCount - 1; r++)
                    {
                        for (int i = 0; i < dTreatmentIn.RowCount - 1; i++)
                        {
                            if (dTreatmentIn["f_Hz", i].Value.ToString() == dTreatmentOut["f_Hz", r].Value.ToString())
                            {
                                try
                                {
                                    Y[r, CurL] = (dTreatmentIn["e_im", i].Value.ToString());
                                    CurL++;
                                }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
                                {
                                    MessageBox.Show(i.ToString() + " shit");
                                    return;
                                }
                            }
                        }
                        CurL = 0;
                    }
                }
                //заполнение массива cycle
                {
                    for (int i = 0; i < T.Length; i++)
                    {
                        cycle[i] = Convert.ToDouble(T_K[i]);
                    }
                }


                //chart построение графика
                {
                    chartTreatment.Series.Clear();
                    chartTreatment.Series.Add("e_re");
                    chartTreatment.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    chartTreatment.Series[0].Color = Color.Red;

                    for (int i = Convert.ToInt32(txtTreatMinT.Text); i < Convert.ToInt32(txtTreatMaxT.Text); i++)
                    {
                        chartTreatment.Series[0].Points.AddXY(T[i], Convert.ToDouble(e_re[0, i].ToString()));
                    }







                    ////int count = 7;
                    //int counti = 500;
                    //double[] x = new double[counti];
                    //double[] y = new double[counti];
                    //double[] yi = new double[counti];
                    //double[] si = new double[counti];
                    //double[] vi = new double[counti];
                    //double s, ds, d2s;

                    //for (int i = 0; i < counti; i++)
                    //{
                    //    x[i] = i;
                    //    y[i] = Math.Sin(i / 100);
                    //}

                    //DataTable dt = new DataTable();
                    //dt.Columns.Add("id");
                    //dt.Columns.Add("x");
                    //dt.Columns.Add("y");
                    //dt.Columns.Add("s");
                    //dt.Columns.Add("yi");
                    //dt.Columns.Add("vi");
                    //dt.Columns.Add("1/vi");
                    //dTreatmentIn.DataSource = dt;
                    //((DataTable)dTreatmentIn.DataSource).Rows.Add();

                    //alglib.spline1dinterpolant cc;
                    //alglib.spline1dinterpolant cc1;
                    ////alglib.spline1dbuildakima(x, y, 3, out cc);
                    //alglib.spline1dfitreport rep;

                    //int info;
                    //double rho = 2.5; //number of regularization
                    //int M = 60; // number of basis functions
                    //double v;
                    ////alglib.minlb

                    //alglib.spline1dbuildcubic(x, y, out cc1);
                    //alglib.spline1dfitpenalized(x, y, M, rho, out info, out cc, out rep);
                    ////v = alglib.spline1dcalc(cc, 0.0);
                    //chartTreatment.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    //chartTreatment.Series[0].Color = Color.Green;

                    //for (int i = 0; i < counti; i++)
                    //{
                    //    yi[i] = alglib.spline1dcalc(cc1, (double)i);
                    //    alglib.spline1ddiff(cc, (double)i / 100, out s, out ds, out d2s);
                    //    chartTreatment.Series[0].Points.AddXY(i, ds);
                    //    si[i] = s;

                    //    v = alglib.spline1dcalc(cc, (double)i / 1.0);
                    //    chartTreatment.Series[0].Points.AddXY(i, v);


                    //    vi[i] = alglib.spline1dcalc(cc, (double)i / 1.0);

                    //}


                    //chartTreatment.Series.Add("original");
                    //chartTreatment.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    //chartTreatment.Series[1].Color = Color.Red;

                    //chartTreatment.Series.Add("yi");
                    //chartTreatment.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    //chartTreatment.Series[2].Color = Color.Blue;


                    //for (int i = 0; i < counti; i++)
                    //{
                    //    chartTreatment.Series[1].Points.AddXY(i, y[i]);
                    //}

                    //chart1.Series.Add("yi");
                    //chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    //chart1.Series[0].Color = Color.Blue;

                    //for (int i = 0; i < counti; i++)
                    //{
                    //    dTreatmentIn["id", i].Value = i.ToString();
                    //    dTreatmentIn["x", i].Value = x[i].ToString();
                    //    dTreatmentIn["y", i].Value = y[i].ToString();
                    //    dTreatmentIn["s", i].Value = si[i].ToString();
                    //    dTreatmentIn["yi", i].Value = yi[i].ToString();
                    //    dTreatmentIn["vi", i].Value = vi[i].ToString();
                    //    dTreatmentIn["1/vi", i].Value = (1.0 / vi[i]).ToString();
                    //    chart1.Series[0].Points.AddXY(i, 1.0 / vi[i]);
                    //    chartTreatment.Series[2].Points.AddXY(i, yi[i]);
                    //    ((DataTable)dTreatmentIn.DataSource).Rows.Add();
                    //}



                }

                //for (int j = 0; j < f.Count; j++)
                //{
                //    dTreatmentOut["f_Hz", j].Value = f[j];
                //    ((DataTable)dTreatmentOut.DataSource).Rows.Add();
                //}


                //конечная обработка данных
                for (int w = 0; w < cycle.Length; w++)
                {
                    for (int i = 0; i < dTreatmentOut.RowCount - 2; i++)
                    {
                        double[] tt = new double[e_re.GetLength(1)];
                        for (int q = 0; q < tt.Length; q++)
                        {
                            tt[q] = Convert.ToDouble(e_re[i, q]);
                        }
                        PiezoMathCalculation PM = new PiezoMathCalculation();
                        Int32 o = PM.FindIndexOfMaxValFromArrayInterval(tt, Convert.ToInt32(txtTreatMinT.Text), Convert.ToInt32(txtTreatMaxT.Text));
                        tBoxTreatment.AppendText(o.ToString() + Environment.NewLine);
                        dTreatmentOut["e_re", i].Value = e_re[i, o];
                        dTreatmentOut["e_im", i].Value = e_im[i, o];
                        dTreatmentOut["T_K", i].Value = T[o];
                    }
                }
            }


            switch (cmbTreatment.Text)
            {
                case "Sorting Meas t(f)":
                    {
                        SortingTf(dTreatmentIn, dTreatmentOut);
                        break;
                    }
                default: break;
            }
        }

        /// <summary>
        /// Сортировка измерений
        /// </summary>
        /// <param name="DGIn"></param>
        /// <param name="DGOut"></param>
        public void SortingTf(DataGridView DGIn, DataGridView DGOut)
        {

#pragma warning disable CS0219 // Переменной "cst" присвоено значение, но оно ни разу не использовано.
#pragma warning disable CS0219 // Переменной "countf" присвоено значение, но оно ни разу не использовано.
            int countf = 0, cst = 0;
#pragma warning restore CS0219 // Переменной "countf" присвоено значение, но оно ни разу не использовано.
#pragma warning restore CS0219 // Переменной "cst" присвоено значение, но оно ни разу не использовано.

            FileJob FJ = new FileJob();
            DataGridJob DGJ = new DataGridJob();

            List<string> lst_e_re = new List<string>();
            List<string> lst_e_im = new List<string>();
            List<string> lst_f = new List<string>();

            for (int i = 0; i < DGIn.RowCount - 2; i++)
            {
                lst_f.Add(DGIn["f_Hz", i].Value.ToString());
                lst_e_re.Add(DGIn["e_re", i].Value.ToString());
                lst_e_im.Add(DGIn["e_im", i].Value.ToString());
            }
            IEnumerable<string> ief = lst_f.Distinct();


            DGJ.AddColumn(DGOut, "T_K", "double precision");

            foreach (string st in ief)
            {
                DGJ.AddColumn(DGOut, "C_pF_" + st, "double precision");
            }

            foreach (string st in ief)
            {
                DGJ.AddColumn(DGOut, "e_re_" + st, "double precision");
            }
            foreach (string st in ief)
            {
                DGJ.AddColumn(DGOut, "e_im_" + st, "double precision");
            }

            foreach (string st in ief)
            {
                DGJ.AddColumn(DGOut, "tgd_" + st, "double precision");
            }


            //MessageBox.Show(ief.Count().ToString());

            DGOut.Rows.Add();
            int cell = 0;
            for (int i = 0; i < ief.Count(); i++)
            {
                for (int j = 0; j < DGIn.RowCount - 2; j++)
                {
                    if (DGIn["f_Hz", j].Value.ToString() == ief.ElementAt(i))
                    {
                        DGOut["e_re_" + lst_f[i], cell].Value = DGIn["e_re", j].Value.ToString();
                        DGOut["e_im_" + lst_f[i], cell].Value = DGIn["e_im", j].Value.ToString();
                        DGOut["tgd_" + lst_f[i], cell].Value = DGIn["tgd", j].Value.ToString();
                        DGOut["C_pF_" + lst_f[i], cell].Value = DGIn["C_pF", j].Value.ToString();
                        DGOut["T_K", cell].Value = DGIn["T_K", j].Value;
                        ++cell;
                        DGOut.Rows.Add();
                    }

                }
                cell = 0;
            }
        }
        /// <summary>
        /// Handles the MouseClick event of the cmbTreatment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void cmbTreatment_MouseClick(object sender, MouseEventArgs e)
        {

        }
        /// <summary>
        /// Handles the MeasureItem event of the cmbTreatment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MeasureItemEventArgs"/> instance containing the event data.</param>
        private void cmbTreatment_MeasureItem(object sender, MeasureItemEventArgs e)
        {

        }
        /// <summary>
        /// Handles the 1 event of the button1_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            //int count = 7;
            int counti = 500;
            double[] x = new double[counti];
            double[] y = new double[counti];
            double[] yi = new double[counti];
            double[] si = new double[counti];
            double[] vi = new double[counti];
            double ds, d2s;

            for (int i = 0; i < counti; i++)
            {
                x[i] = i;
                y[i] = Math.Sin(i / 100);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("x");
            dt.Columns.Add("y");
            dt.Columns.Add("s");
            dt.Columns.Add("yi");
            dt.Columns.Add("vi");
            dt.Columns.Add("1/vi");
            dTreatmentIn.DataSource = dt;
            ((DataTable)dTreatmentIn.DataSource).Rows.Add();

            alglib.spline1dinterpolant cc;
            alglib.spline1dinterpolant cc1;
            //alglib.spline1dbuildakima(x, y, 3, out cc);
            alglib.spline1dfitreport rep;

            int info;
            double rho = 2.5; //number of regularization
            int M = 60; // number of basis functions
            double v;

            alglib.spline1dbuildcubic(x, y, out cc1);
            alglib.spline1dfitpenalized(x, y, M, rho, out info, out cc, out rep);
            //v = alglib.spline1dcalc(cc, 0.0);
            chartTreatment.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chartTreatment.Series[0].Color = Color.Green;

            for (int i = 0; i < counti; i++)
            {
                yi[i] = alglib.spline1dcalc(cc1, (double)i);
                alglib.spline1ddiff(cc, (double)i / 100, out double s, out ds, out d2s);
                chartTreatment.Series[0].Points.AddXY(i, ds);
                si[i] = s;

                v = alglib.spline1dcalc(cc, (double)i / 1.0);
                chartTreatment.Series[0].Points.AddXY(i, v);


                vi[i] = alglib.spline1dcalc(cc, (double)i / 1.0);

            }


            chartTreatment.Series.Add("original");
            chartTreatment.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chartTreatment.Series[1].Color = Color.Red;

            chartTreatment.Series.Add("yi");
            chartTreatment.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chartTreatment.Series[2].Color = Color.Blue;


            for (int i = 0; i < counti; i++)
            {
                chartTreatment.Series[1].Points.AddXY(i, y[i]);
            }

            chart1.Series.Add("yi");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[0].Color = Color.Blue;

            for (int i = 0; i < counti; i++)
            {
                dTreatmentIn["id", i].Value = i.ToString();
                dTreatmentIn["x", i].Value = x[i].ToString();
                dTreatmentIn["y", i].Value = y[i].ToString();
                dTreatmentIn["s", i].Value = si[i].ToString();
                dTreatmentIn["yi", i].Value = yi[i].ToString();
                dTreatmentIn["vi", i].Value = vi[i].ToString();
                dTreatmentIn["1/vi", i].Value = (1.0 / vi[i]).ToString();
                chart1.Series[0].Points.AddXY(i, 1.0 / vi[i]);
                chartTreatment.Series[2].Points.AddXY(i, yi[i]);
                ((DataTable)dTreatmentIn.DataSource).Rows.Add();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Enable timer for measurments hi tempereature
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            switch (frmMOpt.cWorkMode.Text)
            {
                case "d33Rev":
                    {
                        frmGPIB.WriteCommandDev("init");
                        break;
                    }
                case "CTE":
                    {
                        break;
                    }
                default:
                    if (frmGPIB.GPIBdev == "GPIB device not initialized try again")
                    {
                        MessageBox.Show("You must find gpib device");
                        return;
                    }
                    break;
            }
            if (frmMOpt.cmbOperator.Text == "")
            {
                MessageBox.Show("You must choice operator");
                return;
            }
            switch (btnStart.Text)
            {
                case "Stop":
                    {
                        btnStart.Text = "Start";
                        InitializationOfParametersForMeas();
                        MeasTimerInitializationEnable();
                        break;
                    }
                case "Start":
                    {
                        btnStart.Text = "Stop";
                        timerMeas.Enabled = false;
                        TimeCurrentMeas.Enabled = false;
                        MessageBox.Show("Done");
                        if (frmMOpt.cWorkMode.Text == "C(dU)_auto_reversive")
                        {
                            Com.TransmitStringToArduiono("e");
                            System.Threading.Thread.Sleep(400);
                            Com.TransmitStringToArduiono("x");
                            System.Threading.Thread.Sleep(400);
                            Com.TransmitStringToArduiono("v");
                        }
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// Meas the timer initialization enable.
        /// </summary>
        void MeasTimerInitializationEnable()
        {
            switch (frmMOpt.cWorkMode.Text)
            {
                case "Auto": timerMeas.Interval = 1000; break;
                case "Man": timerMeas.Interval = 1000; break;
                case "Cycle": timerMeas.Interval = 1000; break;
                case "C(dU)_man": timerMeas.Interval = 100; break;
                case "C(dU)_auto": timerMeas.Interval = 1000; break;
                case "C(dU)_relaxation": timerMeas.Interval = 1000; break;
                case "C(dU_df_dT)": timerMeas.Interval = 1000; break;
                case "Piezo": timerMeas.Interval = 1000; break;
                case "Ramp": timerMeas.Interval = 1000; break;
                case "C(dU)_auto_reversive": timerMeas.Interval = 1000; break;
                case "d33Rev": timerMeas.Interval = 500; break;
                default:
                    timerMeas.Interval = 1000;
                    break;
            }
            TimeCurrentMeas.Enabled = true;
            timerMeas.Enabled = true;
        }

        void Input_validation()
        { 
        
        }
        /// <summary>
        /// Initializes the grid for temperatures measurments.
        /// </summary>
        public void InitializationOfParametersForMeas()
        {
            Input_validation();


            FileJob FJ = new FileJob();
            FJ.ClearDataGridView(dGridTempMeas);

            if (frmMOpt.txtHeight.Text == "" || frmMOpt.txtDiameter.Text == "" ||
                frmMOpt.txtTempStart.Text == "" || frmMOpt.txtCycleCount.Text == "" ||
                frmMOpt.txtComposition.Text == "" || frmMOpt.txtTempEnd.Text == "" ||
                frmMOpt.txtTempSint.Text == "" || frmMOpt.tFreqList.Text == "")
            {
                txtLog.AppendText(Environment.NewLine + "You must check parameters");
                //MessageBox.Show("You must check parameters");
                return;
            }




            DataGridJob DGJ = new DataGridJob();
            DGJ.AddColumn(dGridTempMeas, "id", "serial");
            DGJ.AddColumn(dGridTempMeas, "composition", "text");
            DGJ.AddColumn(dGridTempMeas, "Tsint_K", "double precision");
            DGJ.AddColumn(dGridTempMeas, "id_sample", "INT");
            DGJ.AddColumn(dGridTempMeas, "h_cm", "double precision");
            DGJ.AddColumn(dGridTempMeas, "d_cm", "double precision");
            DGJ.AddColumn(dGridTempMeas, "T_K", "double precision");
            DGJ.AddColumn(dGridTempMeas, "f_Hz", "INT");
            DGJ.AddColumn(dGridTempMeas, "C_pF", "double precision");
            DGJ.AddColumn(dGridTempMeas, "e_re", "double precision");
            DGJ.AddColumn(dGridTempMeas, "tgd1e2", "double precision");
            DGJ.AddColumn(dGridTempMeas, "e_im", "double precision");
            DGJ.AddColumn(dGridTempMeas, "tgd", "double precision");
            DGJ.AddColumn(dGridTempMeas, "Y", "double precision");
            DGJ.AddColumn(dGridTempMeas, "Ubias_V", "double precision");
            DGJ.AddColumn(dGridTempMeas, "Hbias_T", "double precision");
            DGJ.AddColumn(dGridTempMeas, "Cycle", "INT");
            DGJ.AddColumn(dGridTempMeas, "Step", "INT");
            DGJ.AddColumn(dGridTempMeas, "Direction", "text");
            DGJ.AddColumn(dGridTempMeas, "Polarity", "text");
            DGJ.AddColumn(dGridTempMeas, "Time", "time");
            DGJ.AddColumn(dGridTempMeas, "Date", "date");
            DGJ.AddColumn(dGridTempMeas, "Timer", "INT");
            DGJ.AddColumn(dGridTempMeas, "Meas_type", "text");
            DGJ.AddColumn(dGridTempMeas, "operator", "text");
            DGJ.AddColumn(dGridTempMeas, "ro_exp", "double precision");
            DGJ.AddColumn(dGridTempMeas, "solid_state", "text");
            dGridTempMeas.Rows.Add();
            PP.CelSel = 0;

            for (int i = 0; i < Com.allComPort.Count() - 1; i++)
            {
                if (Com.allComPort[i].DeviceName == "Varta703I")
                {
                    GetTempFromVarta();
                }
            }
            PP.Temperature1 = Convert.ToDouble(lbTemp.Text);
            PP.Temperature2 = PP.Temperature1 + PP.TemperatureStep;
            PP.Temperature3 = Convert.ToDouble(frmMOpt.txtTempEnd.Text);
            PP.TemperatureStep = Convert.ToDouble(frmMOpt.txtTempStep.Text);
            PP.NewCycleTemperature = Convert.ToDouble(frmMOpt.txtNewCycleTemp.Text);
            lbDirect.Text = PP.heating;
            PP.Direction = PP.heating;
            PP.cycleCurrentNum = 0;
            PP.TimeMeas = 0;
            PP.CurrentTimeStep = 0;
            PP.CurrentTime = 0;
            PP.ListVoltage = new string[frmMOpt.tVoltageList.Lines.Count()];

            for (int i = 0; i < frmMOpt.tVoltageList.Lines.Count(); i++)
            {
                PP.ListVoltage[i] = frmMOpt.tVoltageList.Lines[i];
            }
            PP.BiasUCurrent = Convert.ToDouble(PP.ListVoltage[0]);

            PP.ListFreq = new string[frmMOpt.tFreqList.Lines.Count()];
            for (int i = 0; i < frmMOpt.tFreqList.Lines.Count(); i++)
            {
                PP.ListFreq[i] = frmMOpt.tFreqList.Lines[i];
            }


            switch (frmMOpt.cWorkMode.Text)
            {
                case "Man":
                    {
                        hand = true;
                        break;
                    }
                case "Magnit_hand":
                    {
                        hand = true;
                        break;
                    }
                case "Cycle":
                    {
                        PP.cycleCount = Convert.ToInt32(frmMOpt.txtCycleCount.Text);
                        PP.NewCycleTemperature = Convert.ToDouble(frmMOpt.txtNewCycleTemp.Text);
                        PP.CelSelTemp = 0;
                        initXMFT();


                        break;
                    }
                case "Cycle_ramp":
                    {
                        break;
                    }
                case "Piezo":
                    {
                        DGJ.AddColumn(dGridTempPiezoMeas, "id", "serial");
                        DGJ.AddColumn(dGridTempPiezoMeas, "composition", "text");
                        DGJ.AddColumn(dGridTempPiezoMeas, "Tsint_K", "double precision");
                        DGJ.AddColumn(dGridTempPiezoMeas, "id_sample", "INT");
                        DGJ.AddColumn(dGridTempPiezoMeas, "composition", "double precision");
                        DGJ.AddColumn(dGridTempPiezoMeas, "d_cm", "double precision");
                        DGJ.AddColumn(dGridTempPiezoMeas, "T_K", "double precision");
                        DGJ.AddColumn(dGridTempPiezoMeas, "f_Hz", "INT");
                        DGJ.AddColumn(dGridTempPiezoMeas, "Y_sm", "double precision");
                        DGJ.AddColumn(dGridTempPiezoMeas, "R_Om", "double precision");
                        DGJ.AddColumn(dGridTempPiezoMeas, "Ubias_V", "double precision");
                        DGJ.AddColumn(dGridTempPiezoMeas, "Hbias_T", "double precision");
                        DGJ.AddColumn(dGridTempPiezoMeas, "Time", "time");
                        DGJ.AddColumn(dGridTempPiezoMeas, "Date", "date");
                        DGJ.AddColumn(dGridTempPiezoMeas, "operator", "text");
                        DGJ.AddRow(dGridTempPiezoMeas);
                        break;
                    }
                case "C(dU)_auto_reversive":
                    {
                        PP.Steps = Convert.ToInt32(frmMOpt.txtPointCountU.Text);
                        PP.CurrentStep = 0;
                        PP.Direction = "Inc";
                        GetCurrentUfromArduino();
                        Thread.Sleep(500);
                        while (PP.BiasUCurrent > 0.02)
                        {
                            DecBiasU();
                            System.Threading.Thread.Sleep(500);
                            GetCurrentUfromArduino();
                            System.Threading.Thread.Sleep(500);
                        }
                        PP.Polarity = "Positive";
                        PP.StepReversiveLong = Convert.ToInt32(frmMOpt.txtTimerReversive.Text);
                        PP.cycleCurrentNum = 0;
                        PP.NextCurrentStep = 1;
                        PP.BiasUmax = Convert.ToDouble(frmMOpt.txtUmax.Text);
                        PiezoMathCalculation PM = new PiezoMathCalculation();
                        txtUbias.Text = PM.ConvertUafterDivider(PP.BiasUCurrent).ToString();
                        break;
                    }
                case "C(dU_dt)_auto_reversive":
                    {
                        PP.Steps = Convert.ToInt32(frmMOpt.txtPointCountU.Text);
                        PP.CurrentStep = 0;
                        PP.Direction = "Inc";
                        PP.BiasUCurrent = 0;
                        PP.Polarity = "Positive";
                        PP.StepReversiveLong = Convert.ToInt32(frmMOpt.txtTimerReversive.Text);
                        Com.TransmitStringToArduiono("r");
                        Thread.Sleep(400);
                        Com.TransmitStringToArduiono("z");
                        PP.cycleCurrentNum = 0;
                        PP.NextCurrentStep = 1;
                        break;
                    }
                case "C(dU_dT)_auto_reversive":
                    {
                        PP.Steps = Convert.ToInt32(frmMOpt.txtPointCountU.Text);
                        PP.CurrentStep = 0;
                        PP.Direction = "Inc";
                        PP.BiasUCurrent = 0;
                        PP.Polarity = "Positive";
                        PP.StepReversiveLong = Convert.ToInt32(frmMOpt.txtTimerReversive.Text);
                        Com.TransmitStringToArduiono("r");
                        Thread.Sleep(400);
                        Com.TransmitStringToArduiono("z");
                        PP.cycleCurrentNum = 0;
                        PP.NextCurrentStep = 1;
                        break;
                    }
                case "C(dU,dt,df)_relaxation_(law from file)":
                    {
                        PiezoMathCalculation PM = new PiezoMathCalculation();
                        PP.ListTimer = new string[frmMOpt.tTimerList.Lines.Count()];
                        for (int i = 0; i < frmMOpt.tTimerList.Lines.Count(); i++)
                        {
                            PP.ListTimer[i] = frmMOpt.tTimerList.Lines[i];
                        }
                        PP.CurrentTime = Convert.ToDouble(PP.ListTimer[0]);
                        PP.CurrentTimeStep = 0;
                        frmGPIB.WriteCommandDev(PP.BiasAgilent4980 + PP.ListVoltage[PP.CurrentTimeStep]);
                        frmGPIB.WriteCommandDev(PP.FreqAgilent4980 + PP.ListFreq[PP.CurrentTimeStep]);
                        break;
                    }
                case "d33Rev":
                    {
                        PP.ListTimer = new string[frmMOpt.tTimerList.Lines.Count()];
                        for (int i = 0; i < frmMOpt.tTimerList.Lines.Count(); i++)
                        {
                            PP.ListTimer[i] = frmMOpt.tTimerList.Lines[i];
                        }
                        DGJ.AddColumn(dGridTempMeas, "Uin_voltmeter", "double precision"); 
                        DGJ.AddColumn(dGridTempMeas, "Ubias_V_conv", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "Xi", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "Xi0", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "conv_coef", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "Uout_V", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "E_kV_Div_cm", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "k_10_E_4", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "d33rev", "double precision");
                        PP.Xi0.Clear();
                        break;
                    }
                case "d33Rev_auto":
                    {
                        PP.ListTimer = new string[frmMOpt.tTimerList.Lines.Count()];
                        for (int i = 0; i < frmMOpt.tTimerList.Lines.Count(); i++)
                        {
                            PP.ListTimer[i] = frmMOpt.tTimerList.Lines[i];
                        }
                        DGJ.AddColumn(dGridTempMeas, "Ubias_V_conv", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "Xi", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "Xi0", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "Xi-Xi0", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "Uout_V", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "E_kV_Div_cm", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "k_10_E_4", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "d33rev", "double precision");
                        PP.Xi0.Clear();
                        break;
                    }
                case "CTE":
                    {
                        PP.ListTimer = new string[frmMOpt.tTimerList.Lines.Count()];
                        for (int i = 0; i < frmMOpt.tTimerList.Lines.Count(); i++)
                        {
                            PP.ListTimer[i] = frmMOpt.tTimerList.Lines[i];
                        }
                        DGJ.AddColumn(dGridTempMeas, "precision", "INT");
                        DGJ.AddColumn(dGridTempMeas, "Uout_V", "double precision");
                        DGJ.AddColumn(dGridTempMeas, "Xi", "double precision");
                        PP.Xi0.Clear();
                        break;
                    }
                default:

                    break;
            }

            if (frmMOpt.cWorkMode.Text == "C(dU)_auto" ||
                frmMOpt.cWorkMode.Text == "C(dU)_man" ||
                frmMOpt.cWorkMode.Text == "C(dU_df_dT)" ||
                frmMOpt.cWorkMode.Text == "C(dU_dT)" ||
                frmMOpt.cWorkMode.Text == "C(dU_df)" ||
                frmMOpt.cWorkMode.Text == "C(dU)_relaxation"
                )
            {
                PP.BiasUCurrent = Convert.ToDouble(frmMOpt.txtUcur.Text);
                PP.BiasUmax = Convert.ToDouble(frmMOpt.txtUmax.Text);
                PP.TimeStartU = Convert.ToInt32(frmMOpt.txtTimeStartU.Text) * 1000;
                PP.TimePeriodU = Convert.ToInt32(frmMOpt.txtPeriodU.Text) * 1000;
                PP.TimeCurrentU = 0;
                PP.BiasUmin = Convert.ToDouble(frmMOpt.txtUmin.Text);
                PP.MeasuringFrequency = Convert.ToInt32(frmMOpt.tFreqList.Lines[0]);
                frmGPIB.WriteCommandDev(PP.BiasAgilent4980 + PP.ListVoltage[PP.CurrentTimeStep]);
                frmGPIB.WriteCommandDev(PP.FreqAgilent4980 + PP.ListFreq[PP.CurrentTimeStep]);
            }

            switch (frmMOpt.cWorkMode.Text)
            {
                case "d33Rev":
                    {
                        break;
                    }
                default:
                    {
                        switch (frmMOpt.cWorkMode.Text)
                        {
                            default:
                                switch (frmMOpt.cbGPIBDevModel.Text)
                                {
                                    case "Agilent4980A":
                                        {
                                            frmGPIB.WriteCommandDev("FUNC:IMP CPD");
                                            frmGPIB.WriteCommandDev(PP.FreqAgilent4980 + PP.ListFreq[0]);
                                            break;
                                        }
                                    case "Agilent4285A":
                                        {
                                            frmGPIB.WriteCommandDev(PP.FuncAgilent4285 + "CPD");
                                            frmGPIB.WriteCommandDev(PP.FreqAgilent4285 + PP.ListFreq[0]);
                                            break;
                                        }
                                    case "Agilent4263B":
                                        {
                                            frmGPIB.WriteCommandDev(PP.SensFuncAgilent4263);
                                            frmGPIB.WriteCommandDev(PP.FuncAgilent4263Ch1 + "CP");
                                            frmGPIB.WriteCommandDev(PP.FuncAgilent4263Ch2 + "D");
                                            frmGPIB.WriteCommandDev(PP.TrigBusAgilent4263);
                                            frmGPIB.WriteCommandDev(PP.FormAgilent4263 + "ASCii");
                                            frmGPIB.WriteCommandDev(PP.FreqAgilent4263 + PP.ListFreq[0]);
                                            break;
                                        }
                                    case "WayneKerr6500B":
                                        {
                                            frmGPIB.WriteCommandDev(PP.RLCWayneKerr6500B + "1 C;2 D");
                                            frmGPIB.WriteCommandDev(PP.FreqWayneKerr6500B + PP.ListFreq[0]);
                                            break;
                                        }
                                    case "E7-20":
                                        {
                                            byte[] data = new byte[2];
                                            data[0] = 0xD;
                                            Com.SendDataToComPort("E7 - 20", data);
                                            break;
                                        }
                                    default: break;
                                }
                                break;
                        }
                    }
                    break;
            }


            #region initialize graphics
            //create graphics
            chartMeasTemp1.Series.Clear();
            chartMeasTemp2.Series.Clear();
            switch (frmMOpt.cWorkMode.Text)
            {
                case "d33Rev":
                    {
                        Random rnd = new Random();
                        //graphs.IninitialezedGrafSeries("Xi", rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), chartMeasTemp1);
                        graphs.IninitialezedGrafSeries("Xi", 0, 0, 0, chartMeasTemp1);
                        graphs.IninitialezedGrafSeries("Xi", 0, 0, 0, chartMeasTemp2);
                        //graphs.IninitialezedGrafSeries("d33rev", rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), chartMeasTemp2);
                        break;
                    }
                default:
                    {
                        string[] serS = new string[frmMOpt.tFreqList.Text.Split('\n').Length];
                        serS = frmMOpt.tFreqList.Text.Split('\n');
                        Random rnd = new Random();
                        if (serS.Length <= 10)
                        {
                            for (int i = 0; i < serS.Length; i++)
                            {
                                graphs.IninitialezedGrafSeries(serS[i], rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), chartMeasTemp1);
                                graphs.IninitialezedGrafSeries(serS[i], rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), chartMeasTemp2);
                            }
                        }
                        if (serS.Length > 10)
                        {
                            int p = 1;
                            int c = 0;
                            int j = serS.Length;
                            while (j > 10)
                            {
                                j = serS.Length / p;
                                p = p + 1;
                            }
                            c = p;
                            while (p < serS.Length)
                            {
                                graphs.IninitialezedGrafSeries(serS[p], rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), chartMeasTemp1);
                                graphs.IninitialezedGrafSeries(serS[p], rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), chartMeasTemp2);
                                p = p + c;
                            }
                        }
                        break;
                    }

            }

            #endregion



            switch (frmMOpt.cbExportDBMeasTemp.Text)
            {
                case "Export to DB parallel": break;
                case "Export to DB(only)":
                    {
                        PiezoMathCalculation PM = new PiezoMathCalculation();
                        PP.DBTableName = frmMOpt.txtComposition.Text;
                        PP.DBSQLConnctionString = frmDBConnection.ConnectionStringToDB;
                        DBConn dBConn = new DBConn();
                        PP.DB_SQL_CMD = dBConn.DBCreateTableSQLCommand(this.dGridTempMeas, PP.DBTableName);
                        FJ.WriteF(PP.DB_SQL_CMD, PP.FileNameSaveTempMeasDB);
                        txtLog.AppendText(PP.DB_SQL_CMD + Environment.NewLine);
                        txtLog.AppendText(PP.FileNameSaveTempMeasDB + Environment.NewLine);
                        break;
                    }
                default:
                    break;
            }

            if (frmGPIB.cbInterfaceType.Text == "ETHERNET")
            {
                PP.IpAddress = frmGPIB.txtIpHost.Text;
            }
            Directory.CreateDirectory(@"C:\\temp\\");
        }

        /// <summary>
        /// Initializes the XMFT.
        /// </summary>
        void initXMFT()
        {
            Com.WriteDataToXMFT(0, Convert.ToInt32(frmMOpt.DGTempData["Temp", 0].Value));
            System.Threading.Thread.Sleep(250);
            Com.WriteDataToXMFT(0, Convert.ToInt32(frmMOpt.DGTempData["TimeS", 0].Value));
        }

        /// <summary>
        /// Gets the current ufrom arduino.
        /// </summary>
        public void GetCurrentUfromArduino()
        {
            double temps = 0;
            string[] s_u = Regex.Split(Com.GetDataFromComPort("ArduinoUno"), "Last average=  ");
            var list = new List<double>();
            for (int t = 0; t < s_u.Count() - 1; t++)
            {
                var q1 = Regex.Split(s_u[t], "\r\n");
                double q;
                bool isNum = double.TryParse(q1[0], out q);
                if (isNum)
                {
                    list.Add(q);
                }
            }
            for (int t = 1; t < list.Count(); t++)
            {
                temps = temps + Convert.ToDouble(list[1]);
            }
            int e = list.Count() - 1;
            double Uloss = 0.02;
            PP.BiasUCurrent = Math.Round(temps / e, 3) + Uloss;
        }

        /// <summary>
        /// Gets the current ufrom arduino1.
        /// </summary>
        public void GetCurrentUfromArduino1()
        {
            string s = Com.GetDataFromComPort("ArduinoUno");
            string[] ss = s.Split('\n');
            string s1 = "";
            for (int i = 0; i < ss.Count(); i++)
            {
                if (ss[i].Contains("Last average=") == true)
                {
                    s1 = ss[i];
                    ss = s1.Split('=');
                    s1 = ss[1];
                    ss = s1.Split('\r');
                    s1 = ss[0];
                    PP.BiasUCurrent = Convert.ToDouble(s1);
                }
            }
        }
        /// <summary>
        /// Creates the freq list series.
        /// </summary>
        void CreateFreqListSeries()
        {
            cbChartGrafItems.Items.Clear();
            switch (frmMOpt.cWorkMode.Text)
            {
                case "C(dU)_man":
                    {
                        cbChartGrafItems.Items.Add(frmMOpt.tFreqList.Lines[0]);
                        cbChartGrafItems.SelectedIndex = 0;
                        break;
                    }
                case "C(dU)_auto": cbChartGrafItems.Items.Add(frmMOpt.tFreqList.Lines[0]); cbChartGrafItems.SelectedIndex = 0; break;
                case "C(U)_relaxation": cbChartGrafItems.Items.Add(frmMOpt.tFreqList.Lines[0]); cbChartGrafItems.SelectedIndex = 0; break;

                default:
                    {
                        for (int i = 0; i < frmMOpt.tFreqList.Lines.Count() - 1; i++)
                        {
                            cbChartGrafItems.Items.Add(frmMOpt.tFreqList.Lines[i]);
                        }
                        break;
                    }
            }
            if (frmMOpt.cWorkMode.Text == "C(dU)_auto_reversive")
            {
                lbTemp.Text = "300";
            }
        }
        /// <summary>
        /// Creates the series.
        /// </summary>
        /// <param name="s">The s.</param>
        void CreateSeries(string s)
        {
            chartTreatment.Series.Clear();
            chartTreatment.Series.Add(s);
            chartTreatment.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chartTreatment.Series[0].Color = Color.Red;
        }
        /// <summary>
        /// Adds the points.
        /// </summary>
        /// <param name="CH">The ch.</param>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <param name="seriya">The seriya.</param>
        void AddPoints(TChart.Chart CH, double X, double Y, int seriya)
        {
            CH.Series[seriya].Points.AddXY(X, Y);
        }
        /// <summary>
        /// 
        /// </summary>
        public void WriteTempToFile()
        {
            FileJob FJ = new FileJob();
            string s = "";
            s = PP.TimeMeas + "\t" + PP.Temperature1;
            FJ.WriteF(s, PP.FileNameSaveTempMeas);
        }
        /// <summary>
        /// Description of timerMeas
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void timerMeas_Tick(object sender, EventArgs e)
        {
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            WriteTempToFile();


            IncTimerMeas();
            myStopwatch.Stop();
            PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;
            m();
        }

        void IncTimerMeas()
        {
            PP.TimeMeas += 0.001;
        }

        /// <summary>
        /// Incs the bias u.
        /// </summary>
        public void IncBiasU()
        {
            Com.SendDataToComPort("ArduinoUno", "+");
            //PP.BiasUCurrent = PP.BiasUCurrent + 250;
            //this.txtUbias.Text = PP.BiasUCurrent.ToString();
        }
        /// <summary>
        /// Decimals the bias u.
        /// </summary>
        public void DecBiasU()
        {
            Com.SendDataToComPort("ArduinoUno", "-");
        }


        void getTempFromTermocontroller()
        {
            switch (frmMOpt.cbTermocontrollerDevModel.Text)
            {
                case "Varta":
                    {
                        GetTempFromVarta();
                        break;
                    }
                case "XMFT":
                    {
                        GetTempFromXMFT();
                        break;
                    }
                default:
                    break;
            } 

            
        }
        /// <summary>
        /// GetTempFromXMFT()
        /// </summary>
        void GetTempFromXMFT()
        {
            try
            {
                PiezoMathCalculation PM = new PiezoMathCalculation();
                Com.GetTemperatureFromXMFT();
                PP.Temperature1 = PM.ConvertCelciusToKelvin(Convert.ToDouble(Com.Temperature));
                PP.TemperatureReserv = PP.Temperature1;
                lbTemp.Text = PP.Temperature1.ToString();
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Get Temp From Varta
        /// </summary>
        public void GetTempFromVarta()
        {
            PiezoMathCalculation PM = new PiezoMathCalculation();

            if (frmMOpt.chTest.Checked == false)
            {
                try
                {
                    Com.GetDataFromVarta();
                    PP.Temperature1 = PM.ConvertCelciusToKelvin(Convert.ToDouble(Com.Temperature));
                    PP.TemperatureReserv = PP.Temperature1;
                    lbTemp.Text = PP.Temperature1.ToString();
                    System.Threading.Thread.Sleep(400);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    PP.Temperature1 = Convert.ToDouble(PP.TemperatureReserv);
                    lbTemp.Text = PP.TemperatureReserv.ToString();
                    System.Threading.Thread.Sleep(400);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        void WorkMode_Auto()
        {
            if (PP.Temperature1 >= PP.Temperature3 && PP.Direction == PP.heating)
            {
                PP.Direction = PP.cooling;
            }
            if (PP.Direction == PP.cooling)
            {
                PP.Direction = PP.cooling;
            }

            MainMeas();
            //PP.BiasUCurrent = Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]);
            //if (PP.Temperature1 >= PP.Temperature2 && PP.Direction == PP.heating)
            //{
            //    PP.Temperature2 = PP.Temperature1 + PP.TemperatureStep;
            //    MainMeas();
            //    PP.Direction = PP.heating;
            //}
            //if (PP.Temperature1 >= PP.Temperature3 && PP.Direction == PP.heating)
            //{
            //    frmMOpt.cDirect.SelectedIndex = 1;
            //    lbDirect.Text = PP.cooling;
            //    PP.Direction = PP.cooling;
            //    PP.Temperature2 = PP.Temperature3 - PP.TemperatureStep;
            //    MainMeas();
            //}
            //if (PP.Temperature2 >= PP.Temperature1 && PP.Direction == PP.cooling)
            //{
            //    PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
            //    MainMeas();
            //}
        }
        /// <summary>
        /// Cycle
        /// </summary>
        void WorkMode_Cycle()
        {
            getTempFromTermocontroller();
            
            if (PP.TimeMeas<Convert.ToInt32(frmMOpt.DGTempData["TimerS", PP.CelSelTemp].Value))
            {
                PP.cycleCurrentNum = Convert.ToInt32(frmMOpt.DGTempData["Cycle", PP.CelSelTemp].Value);
                MainMeas();
                
            }
            if (PP.TimeMeas >= Convert.ToInt32(frmMOpt.DGTempData["TimerS", PP.CelSelTemp].Value )
                && frmMOpt.DGTempData["TimerS", PP.CelSelTemp+1].Value!="")
            {
                PP.CelSelTemp = PP.CelSelTemp + 1;
                PP.cycleCurrentNum = Convert.ToInt32(frmMOpt.DGTempData["Cycle", PP.CelSelTemp].Value);
                Com.WriteDataToXMFT(0, Convert.ToInt32(frmMOpt.DGTempData["Temp", PP.CelSelTemp].Value));
                MainMeas();
            }
            if (PP.TimeMeas >= Convert.ToInt32(frmMOpt.DGTempData["TimerS", PP.CelSelTemp].Value)
                && frmMOpt.DGTempData["TimerS", PP.CelSelTemp + 1].Value == "")
            {
                timerMeas.Enabled = false;
                MessageBox.Show("Measuring is done");

            }

            //if (PP.Direction == PP.heating && PP.Temperature1 >= PP.Temperature2 && PP.Temperature1 < PP.Temperature3)
            //{
            //    PP.Temperature2 = PP.Temperature1 + PP.TemperatureStep;
            //    lbDirect.Text = PP.heating;
            //    PP.Direction = PP.heating;
            //    MainMeas();
            //    endcycleAgilent4980();
            //}
            ////------------------------------------------------------------------------
            //if (PP.Direction == PP.heating &&
            //    PP.Temperature1 >= PP.Temperature3
            //   )
            //{
            //    PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
            //    lbDirect.Text = PP.cooling;
            //    PP.Direction = PP.cooling;
            //    frmMOpt.cDirect.SelectedIndex = 1;
            //    MainMeas();
            //    endcycleAgilent4980();
            //}
            ////------------------------------------------------------------------------
            //if (PP.Direction == PP.cooling &&
            //    PP.Temperature1 >= PP.NewCycleTemperature &&
            //    PP.Temperature1 <= PP.Temperature2 &&
            //    PP.cycleCurrentNum <= PP.cycleCount)
            //{
            //    PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
            //    MainMeas();
            //    endcycleAgilent4980();
            //}
            ////------------------------------------------------------------------------
            //if (PP.Direction == PP.cooling &&
            //    PP.Temperature1 <= PP.NewCycleTemperature &&
            //    PP.cycleCurrentNum <= PP.cycleCount
            //    )
            //{
            //    ++PP.cycleCurrentNum;
            //    lbCycleNum.Text = PP.cycleCurrentNum.ToString();
            //    lbDirect.Text = PP.heating;
            //    PP.Direction = PP.heating;
            //    frmMOpt.cDirect.SelectedIndex = 0;
            //    MainMeas();
            //    endcycleAgilent4980();
            //}
            ////------------------------------------------------------------------------
            //if (PP.Direction == PP.cooling &&
            //    PP.cycleCurrentNum > PP.cycleCount &&
            //    PP.Temperature1 <= PP.NewCycleTemperature)
            //{
            //    MainMeas();
            //    endcycleAgilent4980();
            //}
        }
        /// <summary>
        /// WorkMode C(dU_df)
        /// </summary>
        void WorkMode_C_on_dU_df()
        {
            if (PP.Temperature1 >= PP.Temperature2 && PP.Direction == PP.heating)
            {
                PP.Temperature2 = PP.Temperature1 + PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }
            if (PP.Temperature1 >= PP.Temperature3 && PP.Direction == PP.heating)
            {
                frmMOpt.cDirect.SelectedIndex = 1;
                lbDirect.Text = PP.cooling;
                PP.Direction = PP.cooling;
                PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }
            if (PP.Temperature2 >= PP.Temperature1 && PP.Direction == PP.cooling)
            {
                PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }
        }
        /// <summary>
        /// WorkMode_C(dU_dT)
        /// </summary>
        void WorkMode_C_on_dU_dT()
        {
            if (PP.Temperature1 >= PP.Temperature2 && PP.Direction == PP.heating)
            {
                PP.Temperature2 = PP.Temperature1 + PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }
            if (PP.Temperature1 >= PP.Temperature3 && PP.Direction == PP.heating)
            {
                frmMOpt.cDirect.SelectedIndex = 1;
                lbDirect.Text = PP.cooling;
                PP.Direction = PP.cooling;
                PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }
            if (PP.Temperature2 >= PP.Temperature1 && PP.Direction == PP.cooling)
            {
                PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }
        }
        /// <summary>
        /// Works the mode c on d u relaxation.
        /// </summary>
        void WorkMode_C_on_dU_relaxation()
        {
            txtLog.AppendText(PP.TimeCurrentU.ToString() + Environment.NewLine);
            txtUbias.Text = PP.BiasUCurrent.ToString();
            MainMeasuringUnderBiasU();
            PP.TimeCurrentU = PP.TimeCurrentU + 1000;
            if (PP.TimeCurrentU >= PP.TimeStartU)
            {
                PP.BiasUCurrent = Convert.ToDouble(frmMOpt.txtUmax.Text);
            }

            if (PP.TimeCurrentU >= PP.TimeStartU + PP.TimePeriodU)
            {
                PP.BiasUCurrent = PP.BiasUmin;
            }
            this.Refresh();
        }
        /// <summary>
        /// Works the mode c on d u df d t.
        /// </summary>
        void WorkMode_C_on_dU_df_dT()
        {
            if (PP.Temperature1 >= PP.Temperature2 && PP.Direction == PP.heating)
            {
                PP.Temperature2 = PP.Temperature1 + PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }
            if (PP.Temperature1 >= PP.Temperature3 && PP.Direction == PP.heating)
            {
                frmMOpt.cDirect.SelectedIndex = 1;
                lbDirect.Text = PP.cooling;
                PP.Direction = PP.cooling;
                PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }

            if (PP.Temperature2 >= PP.Temperature1 && PP.Direction == PP.cooling)
            {
                PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
                MainMeasuringUnderBiasU();
            }
        }
        /// <summary>
        /// Works the mode c on d u automatic reversive.
        /// </summary>
        void WorkMode_C_on_dU_auto_reversive()
        {
            double Uon = 20;
            PiezoMathCalculation PM = new PiezoMathCalculation();
            int delaytimeURealaxation = 15000;
            System.Threading.Thread.Sleep(delaytimeURealaxation);
            GetCurrentUfromArduino1();

            switch (PP.Polarity)
            {
                case "Negative":
                    {
                        txtUbias.Text = "-" + PM.ConvertUafterDivider(PP.BiasUCurrent).ToString();
                        break;
                    }
                case "Positive":
                    {
                        txtUbias.Text = PM.ConvertUafterDivider(PP.BiasUCurrent).ToString();
                        break;
                    }
            }
            this.Refresh();
            if (PP.Polarity == "Negative" && PP.Direction == "Dec" && PM.ConvertUafterDivider(PP.BiasUCurrent) < Uon && PP.BiasUCurrent >= 0.00)
            {
                MainMeas();
                System.Threading.Thread.Sleep(500);
                Com.TransmitStringToArduiono("x");
                btnStart.Text = "Stop";
                timerMeas.Enabled = false;
                return;
            }
            if (PP.Polarity == "Negative" && PP.Direction == "Dec" && PM.ConvertUafterDivider(PP.BiasUCurrent) > Uon)
            {

                MainMeas();
                DecBiasU();
            }
            //equal to max step
            if (PP.Polarity == "Negative" && PP.Direction == "Inc" && PM.ConvertUafterDivider(PP.BiasUCurrent) >= PP.BiasUmax)
            {

                MainMeas();
                PP.Direction = "Dec";
                DecBiasU();
            }

            if (PP.Polarity == "Negative" && PP.Direction == "Inc" && PM.ConvertUafterDivider(PP.BiasUCurrent) < PP.BiasUmax)
            {
                MainMeas();
                IncBiasU();
            }
            //dec equal to min step
            if (PP.Polarity == "Positive" && PP.Direction == "Dec" && PM.ConvertUafterDivider(PP.BiasUCurrent) < Uon && PP.BiasUCurrent >= 0.00)
            {
                //DecBiasU();
                MainMeas();
                //Com.TransmitStringToArduiono("-");
                System.Threading.Thread.Sleep(500);
                //включение реле отрицательной полярности
                Com.TransmitStringToArduiono("z");
                System.Threading.Thread.Sleep(500);
                PP.Direction = "Inc";
                frmMOpt.cDirect.Text = "Negative";
                PP.Polarity = "Negative";
                return;
            }

            if (PP.Polarity == "Positive" && PP.Direction == "Dec" && PM.ConvertUafterDivider(PP.BiasUCurrent) > Uon)
            {
                MainMeas();
                DecBiasU();
                //Com.TransmitStringToArduiono("-");
                System.Threading.Thread.Sleep(delaytimeURealaxation);
            }
            //        equal to max step
            if (PP.Polarity == "Positive" && PP.Direction == "Inc" && PM.ConvertUafterDivider(PP.BiasUCurrent) >= PP.BiasUmax)
            {
                MainMeas();
                PP.Direction = "Dec";
                DecBiasU();
            }
            if (PP.Polarity == "Positive" && PP.Direction == "Inc" && PM.ConvertUafterDivider(PP.BiasUCurrent) < PP.BiasUmax)
            {
                MainMeas();
                IncBiasU();
            }
            this.Refresh();
        }
        /// <summary>
        /// Works the mode C on dU dT automatic reversive.
        /// </summary>
        void WorkMode_C_on_dU_dT_auto_reversive()
        {
            if (PP.Temperature1 >= PP.Temperature2 && frmMOpt.cDirect.SelectedIndex == 0)
            {
                PP.Temperature2 = PP.Temperature1 + PP.TemperatureStep;
                ++PP.TimerReversive;
                if (PP.TimerReversive >= PP.StepReversiveLong)
                {
                    PP.TimerReversive = 0;

                    if (PP.Polarity == "Negative" && PP.Direction == "Dec" &&
                    PP.CurrentStep == 0)
                    {
                        DecBiasU();

                        Com.TransmitStringToArduiono("-");
                        //System.Threading.Thread.Sleep(300);
                        System.Threading.Thread.Sleep(Convert.ToInt32(frmMOpt.txtTimerReversive.Text) * 1000);
                        //отключение реле положительной полярности
                        //Com.TransmitStringToArduiono("x");
                        //System.Threading.Thread.Sleep(300);
                        MainMeas();
                        //frmMOpt.cDirect.Text = "Negative";
                        //включение реле отрицательной полярности
                        //Com.TransmitStringToArduiono("c");
                        //System.Threading.Thread.Sleep(300);

                        //    DecBiasU();
                        //    MainMeas();
                        //    //отключение реле отрицательной полярности
                        //    Com.TransmitStringToArduiono("e");
                        System.Threading.Thread.Sleep(300);
                        Com.TransmitStringToArduiono("e");
                        System.Threading.Thread.Sleep(400);
                        Com.TransmitStringToArduiono("x");
                        System.Threading.Thread.Sleep(400);
                        Com.TransmitStringToArduiono("v");
                        btnStart.Text = "Stop";
                    }

                    if (PP.Polarity == "Negative" && PP.Direction == "Dec" &&
                        PP.CurrentStep > 0
                        )
                    {

                        MainMeas();
                        DecBiasU();
                        --PP.CurrentStep;
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }
                    //equal to max step
                    if (PP.Polarity == "Negative" && PP.Direction == "Inc" &&
                        PP.CurrentStep >= PP.Steps
                        )
                    {
                        MainMeas();
                        --PP.CurrentStep;
                        //DecBiasU();
                        PP.Direction = "Dec";
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }

                    if (PP.Polarity == "Negative" && PP.Direction == "Inc" &&
                    PP.CurrentStep < PP.Steps
                    )
                    {
                        MainMeas();
                        //PP.Polarity = "Positive";
                        IncBiasU();
                        ++PP.CurrentStep;
                        ++PP.NextCurrentStep;
                        Com.TransmitStringToArduiono("+");
                        System.Threading.Thread.Sleep(300);
                    }


                    //dec equal to min step
                    if (PP.Polarity == "Positive" && PP.Direction == "Dec" &&
                        PP.CurrentStep == 0)
                    {
                        DecBiasU();

                        Com.TransmitStringToArduiono("-");
                        //System.Threading.Thread.Sleep(300);
                        //System.Threading.Thread.Sleep(Convert.ToInt32(frmMOpt.txtTimerReversive.Text) * 1000);
                        //отключение реле положительной полярности
                        Com.TransmitStringToArduiono("x");
                        System.Threading.Thread.Sleep(300);
                        //MainMeas();
                        frmMOpt.cDirect.Text = "Negative";
                        //включение реле отрицательной полярности
                        Com.TransmitStringToArduiono("c");
                        System.Threading.Thread.Sleep(300);
                        PP.Direction = "Inc";
                        PP.Polarity = "Negative";
                        return;
                    }



                    if (PP.Polarity == "Positive" && PP.Direction == "Dec" &&
                        PP.CurrentStep > 0
                        )
                    {

                        MainMeas();
                        DecBiasU();
                        --PP.CurrentStep;
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                        // --PP.NextCurrentStep;
                    }

                    //equal to max step
                    if (PP.Polarity == "Positive" && PP.Direction == "Inc" &&
                        PP.CurrentStep >= PP.Steps
                        )
                    {

                        MainMeas();
                        --PP.CurrentStep;
                        //DecBiasU();
                        PP.Direction = "Dec";
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }

                    if (PP.Polarity == "Positive" && PP.Direction == "Inc" &&
                    PP.CurrentStep < PP.Steps
                    )
                    {
                        MainMeas();
                        PP.Polarity = "Positive";
                        IncBiasU();
                        ++PP.CurrentStep;
                        ++PP.NextCurrentStep;
                        Com.TransmitStringToArduiono("+");
                        System.Threading.Thread.Sleep(300);
                    }
                }

            }
            if (PP.Temperature1 >= PP.Temperature3 && frmMOpt.cDirect.SelectedIndex == 0)
            {
                ++PP.TimerReversive;
                if (PP.TimerReversive >= PP.StepReversiveLong)
                {
                    PP.TimerReversive = 0;

                    if (PP.Polarity == "Negative" && PP.Direction == "Dec" &&
                    PP.CurrentStep == 0)
                    {
                        DecBiasU();

                        Com.TransmitStringToArduiono("-");
                        //System.Threading.Thread.Sleep(300);
                        System.Threading.Thread.Sleep(Convert.ToInt32(frmMOpt.txtTimerReversive.Text) * 1000);
                        //отключение реле положительной полярности
                        //Com.TransmitStringToArduiono("x");
                        //System.Threading.Thread.Sleep(300);
                        MainMeas();
                        //frmMOpt.cDirect.Text = "Negative";
                        //включение реле отрицательной полярности
                        //Com.TransmitStringToArduiono("c");
                        //System.Threading.Thread.Sleep(300);

                        //    DecBiasU();
                        //    MainMeas();
                        //    //отключение реле отрицательной полярности
                        //    Com.TransmitStringToArduiono("e");
                        System.Threading.Thread.Sleep(300);
                        Com.TransmitStringToArduiono("e");
                        System.Threading.Thread.Sleep(400);
                        Com.TransmitStringToArduiono("x");
                        System.Threading.Thread.Sleep(400);
                        Com.TransmitStringToArduiono("v");
                        btnStart.Text = "Stop";
                    }



                    if (PP.Polarity == "Negative" && PP.Direction == "Dec" &&
                        PP.CurrentStep > 0
                        )
                    {

                        MainMeas();
                        DecBiasU();
                        --PP.CurrentStep;
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }

                    //equal to max step
                    if (PP.Polarity == "Negative" && PP.Direction == "Inc" &&
                        PP.CurrentStep >= PP.Steps
                        )
                    {

                        MainMeas();
                        --PP.CurrentStep;
                        //DecBiasU();
                        PP.Direction = "Dec";
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }

                    if (PP.Polarity == "Negative" && PP.Direction == "Inc" &&
                    PP.CurrentStep < PP.Steps
                    )
                    {
                        MainMeas();
                        //PP.Polarity = "Positive";
                        IncBiasU();
                        ++PP.CurrentStep;
                        ++PP.NextCurrentStep;
                        Com.TransmitStringToArduiono("+");
                        System.Threading.Thread.Sleep(300);
                    }
                    //dec equal to min step
                    if (PP.Polarity == "Positive" && PP.Direction == "Dec" &&
                        PP.CurrentStep == 0)
                    {
                        DecBiasU();

                        Com.TransmitStringToArduiono("-");
                        //System.Threading.Thread.Sleep(300);
                        //System.Threading.Thread.Sleep(Convert.ToInt32(frmMOpt.txtTimerReversive.Text) * 1000);
                        //отключение реле положительной полярности
                        Com.TransmitStringToArduiono("x");
                        System.Threading.Thread.Sleep(300);
                        //MainMeas();
                        frmMOpt.cDirect.Text = "Negative";
                        //включение реле отрицательной полярности
                        Com.TransmitStringToArduiono("c");
                        System.Threading.Thread.Sleep(300);
                        PP.Direction = "Inc";
                        PP.Polarity = "Negative";
                        return;
                    }



                    if (PP.Polarity == "Positive" && PP.Direction == "Dec" &&
                        PP.CurrentStep > 0
                        )
                    {

                        MainMeas();
                        DecBiasU();
                        --PP.CurrentStep;
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                        // --PP.NextCurrentStep;
                    }

                    //equal to max step
                    if (PP.Polarity == "Positive" && PP.Direction == "Inc" &&
                        PP.CurrentStep >= PP.Steps
                        )
                    {

                        MainMeas();
                        --PP.CurrentStep;
                        //DecBiasU();
                        PP.Direction = "Dec";
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }

                    if (PP.Polarity == "Positive" && PP.Direction == "Inc" &&
                    PP.CurrentStep < PP.Steps
                    )
                    {
                        MainMeas();
                        PP.Polarity = "Positive";
                        IncBiasU();
                        ++PP.CurrentStep;
                        ++PP.NextCurrentStep;
                        Com.TransmitStringToArduiono("+");
                        System.Threading.Thread.Sleep(300);
                    }
                }

            }
            if (PP.Temperature2 >= PP.Temperature1 && frmMOpt.cDirect.SelectedIndex == 1)
            {
                PP.Temperature2 = PP.Temperature1 - PP.TemperatureStep;
                ++PP.TimerReversive;
                if (PP.TimerReversive >= PP.StepReversiveLong)
                {
                    PP.TimerReversive = 0;

                    if (PP.Polarity == "Negative" && PP.Direction == "Dec" &&
                    PP.CurrentStep == 0)
                    {
                        DecBiasU();

                        Com.TransmitStringToArduiono("-");
                        //System.Threading.Thread.Sleep(300);
                        System.Threading.Thread.Sleep(Convert.ToInt32(frmMOpt.txtTimerReversive.Text) * 1000);
                        //отключение реле положительной полярности
                        //Com.TransmitStringToArduiono("x");
                        //System.Threading.Thread.Sleep(300);
                        MainMeas();
                        //frmMOpt.cDirect.Text = "Negative";
                        //включение реле отрицательной полярности
                        //Com.TransmitStringToArduiono("c");
                        //System.Threading.Thread.Sleep(300);

                        //    DecBiasU();
                        //    MainMeas();
                        //    //отключение реле отрицательной полярности
                        //    Com.TransmitStringToArduiono("e");
                        System.Threading.Thread.Sleep(300);
                        Com.TransmitStringToArduiono("e");
                        System.Threading.Thread.Sleep(400);
                        Com.TransmitStringToArduiono("x");
                        System.Threading.Thread.Sleep(400);
                        Com.TransmitStringToArduiono("v");
                        btnStart.Text = "Stop";
                    }



                    if (PP.Polarity == "Negative" && PP.Direction == "Dec" &&
                        PP.CurrentStep > 0
                        )
                    {

                        MainMeas();
                        DecBiasU();
                        --PP.CurrentStep;
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }

                    //equal to max step
                    if (PP.Polarity == "Negative" && PP.Direction == "Inc" &&
                        PP.CurrentStep >= PP.Steps
                        )
                    {

                        MainMeas();
                        --PP.CurrentStep;
                        //DecBiasU();
                        PP.Direction = "Dec";
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }

                    if (PP.Polarity == "Negative" && PP.Direction == "Inc" &&
                    PP.CurrentStep < PP.Steps
                    )
                    {
                        MainMeas();
                        //PP.Polarity = "Positive";
                        IncBiasU();
                        ++PP.CurrentStep;
                        ++PP.NextCurrentStep;
                        Com.TransmitStringToArduiono("+");
                        System.Threading.Thread.Sleep(300);
                    }


                    //dec equal to min step
                    if (PP.Polarity == "Positive" && PP.Direction == "Dec" &&
                        PP.CurrentStep == 0)
                    {
                        DecBiasU();

                        Com.TransmitStringToArduiono("-");
                        //System.Threading.Thread.Sleep(300);
                        //System.Threading.Thread.Sleep(Convert.ToInt32(frmMOpt.txtTimerReversive.Text) * 1000);
                        //отключение реле положительной полярности
                        Com.TransmitStringToArduiono("x");
                        System.Threading.Thread.Sleep(300);
                        //MainMeas();
                        frmMOpt.cDirect.Text = "Negative";
                        //включение реле отрицательной полярности
                        Com.TransmitStringToArduiono("c");
                        System.Threading.Thread.Sleep(300);
                        PP.Direction = "Inc";
                        PP.Polarity = "Negative";
                        return;
                    }



                    if (PP.Polarity == "Positive" && PP.Direction == "Dec" &&
                        PP.CurrentStep > 0
                        )
                    {

                        MainMeas();
                        DecBiasU();
                        --PP.CurrentStep;
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                        // --PP.NextCurrentStep;
                    }

                    //equal to max step
                    if (PP.Polarity == "Positive" && PP.Direction == "Inc" &&
                        PP.CurrentStep >= PP.Steps
                        )
                    {

                        MainMeas();
                        --PP.CurrentStep;
                        //DecBiasU();
                        PP.Direction = "Dec";
                        Com.TransmitStringToArduiono("-");
                        System.Threading.Thread.Sleep(300);
                    }

                    if (PP.Polarity == "Positive" && PP.Direction == "Inc" &&
                    PP.CurrentStep < PP.Steps
                    )
                    {
                        MainMeas();
                        PP.Polarity = "Positive";
                        IncBiasU();
                        ++PP.CurrentStep;
                        ++PP.NextCurrentStep;
                        Com.TransmitStringToArduiono("+");
                        System.Threading.Thread.Sleep(300);
                    }
                }

            }
        }
        /// <summary>
        /// Works the mode c on d u dt df relaxation law from file.
        /// </summary>
        void WorkMode_C_on_dU_dt_df_relaxation_LawFromFile()
        {
            MainMeas();
            //PP.BiasUCurrent = Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]);
            if (PP.CurrentTime >= PP.TimeMeas && PP.CurrentTimeStep >= PP.ListTimer.Length - 1)
            {
                //timerMeas.Enabled = false;
                //TimeCurrentMeas.Enabled = false;
                return;
            }

            if (PP.TimeMeas >= PP.CurrentTime && PP.CurrentTimeStep < PP.ListTimer.Length - 1)
            {
                Stopwatch myStopwatch = new Stopwatch();
                myStopwatch.Start();
                PP.CurrentTime = Convert.ToDouble(PP.ListTimer[PP.CurrentTimeStep]);
                PP.BiasUCurrent = Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]);
                frmGPIB.WriteCommandDev(PP.BiasAgilent4980 + PP.ListVoltage[PP.CurrentTimeStep]);
                ++PP.CurrentTimeStep;
                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;

            }
        }
        /// <summary>
        /// Works the mode cycle ramp.
        /// </summary>
        void WorkMode_Cycle_ramp()
        {
            //MainMeas_cycle_ramp();
            MainMeas();
        }
        /// <summary>
        /// Mains the meas cycle ramp.
        /// </summary>
        void MainMeas_cycle_ramp()
        {
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            WriteTempToFile();
            PiezoMathCalculation PM = new PiezoMathCalculation();
            //измерение и получение данных с прибора
            for (int i = 0; i < PP.ListFreq.Length; i++)
            {
                InitialiezeFreq(i);
                InitialiezeTrig();

                switch (frmMOpt.cbGPIBDevModel.Text)
                {
                    case "Agilent4980A":
                        Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9]{1}");
                        Regex reg1 = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{1}");

                        switch (frmGPIB.cbInterfaceType.Text)
                        {
                            case "ETHERNET":
                                frmGPIB.WriteCommandDev(PP.FetchGPIBDevices);

                                string s1 = "";
                                string[] rr;
                                bool match = false;
                                do
                                {
                                    char splitchar = (char)'\n';
                                    string[] sss = frmGPIB.answer.Split(splitchar);
                                    if (sss.Count() > 1)
                                    {
                                        s1 = sss[2];
                                        s1 = s1.Substring(12, 28);
                                        string ff = s1;
                                        rr = sss[2].Split('\0');
                                        rr = rr[0].Split((char)3);
                                        if (reg.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                        if (reg1.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                    }
                                } while (match == false);
                                break;
                            case "GPIB":
                                frmGPIB.WriteCommandDev(PM.ReplaceCommonEscapeSequences(PP.FetchAgilent4980));
                                frmGPIB.ReadDeviceAnswer();
                                break;
                            default:
                                break;
                        }

                        break;
                    default:
                        break;
                }

                if (PP.Temperature1 >= PP.Temperature3 && PP.Direction == PP.heating)
                {
                    PP.Direction = PP.cooling;
                }

                if (PP.Temperature1 <= PP.NewCycleTemperature && PP.Direction == PP.cooling)
                {
                    ++PP.cycleCurrentNum;
                    lbCycleNum.Text = PP.cycleCurrentNum.ToString();
                    PP.Direction = PP.heating;
                }
                //------------------------------------------------------------------------



                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;
                MeasTemp(PP.ListFreq[i], PP.CelSel);
                ++PP.CelSel;
                this.Refresh();
            }
            //-------------------------------------------------------------
            InitialiezeFreq(0);
            this.Refresh();
        }

        /// <summary>
        /// Main procedure for measurments.
        /// </summary>
        public void m()
        {
            //get temp from varta
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            WriteTempToFile();
            myStopwatch.Stop();
            PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;

            switch (frmMOpt.cWorkMode.Text)
            {
                case "Auto":
                    {
                        WorkMode_Auto();
                        break;
                    }
                case "Cycle":
                    {
                        WorkMode_Cycle();
                        break;
                    }
                case "Cycle_ramp":
                    {
                        WorkMode_Cycle_ramp();
                        break;
                    }
                case "C(dU)_man":
                    {
                        MainMeasuringUnderBiasU();
                        break;
                    }
                case "C(dU)_auto":
                    {
                        MainMeasuringUnderBiasU();
                        break;
                    }
                case "C(dU_df)":
                    {
                        WorkMode_C_on_dU_df();
                        break;
                    }
                case "C(dU_dT)":
                    {
                        WorkMode_C_on_dU_dT();
                        break;
                    }
                case "C(dU)_relaxation":
                    {
                        WorkMode_C_on_dU_relaxation();
                        break;
                    }
                case "C(dU_df_dT)":
                    {
                        WorkMode_C_on_dU_df_dT();
                        break;
                    }
                case "Ramp":
                    {
                        MainMeas();
                        break;
                    }
                case "Piezo":
                    {
                        MeasTempPiezo();
                        break;
                    }
                case "C(dU)_auto_reversive":
                    {
                        WorkMode_C_on_dU_auto_reversive();
                        break;
                    }

                case "C(dU)_hand_reversive":
                    {
                        WorkMode_C_on_dU_hand_reversive();
                        break;
                    }
                case "C(dU_dT)_auto_reversive":
                    {
                        WorkMode_C_on_dU_dT_auto_reversive();
                        break;
                    }
                case "C(dU,dt,df)_relaxation_(law from file)":
                    {
                        WorkMode_C_on_dU_dt_df_relaxation_LawFromFile();
                        break;
                    }
                case "d33Rev":
                    {
                        WorkModeD33rev();
                        break;
                    }
                case "d33Rev_auto":
                    {
                        WorkModeD33rev_auto();
                        break;
                    }
                case "Magnit_hand":
                    {
                        MeasMagnit_Hand();
                        break;
                    }
                case "CTE":
                    {
                        CTE_meas();
                        break;
                    }
                default:
                    break;
            }
            this.Refresh();
        }

        private void CTE_meas()
        {
            ParseStringTab PS = new ParseStringTab();
            //string s = "";
            #region  Get_data_from_Varta703I
            getTempFromTermocontroller();
            //GetTempFromVarta();
            #endregion

            #region  Get_data_from_micron
            //do
            //{
            //    Com.SendDataToComPort("ArduinoUno", "m");
            //    s = Com.ComReadString();
            //} while (s.Length < 7);
            //PS.AddUMicron(s);


            frmGPIB.WriteCommandDev("init;fetch?");
            frmGPIB.ReadDeviceAnswer();
            
            #endregion

            double Uin = Convert.ToDouble(frmGPIB.answer);

            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            double timeCoef = 0.001;
            PiezoMathCalculation PM = new PiezoMathCalculation();
            switch (frmMOpt.cbExportDBMeasTemp.Text)
            {
                case "Export to DB(only)":
                    {
                        myStopwatch.Stop();
                        PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;

                        AddParametersVal();
                        //PM.SetXiMas();
                        //PM.SetUMicronOutMas();
                        dGridTempMeas["Uout_V", 0].Value = Uin.ToString();//PM.XiVal(PM.FindUmicron(Uin));
                                                                          //dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxCTE_A.Text), Convert.ToDouble(frmMOpt.txtApproxCTE_B.Text)).ToString();//PM.XiVal(PM.FindUmicron(Uin));
                        //if direction is heating
                        if (PP.Temperature1 <= Convert.ToDouble(frmMOpt.txtTempEnd.Text) && PP.Direction == PP.heating)
                        {
                            
                            dGridTempMeas["Direction", 0].Value = PP.heating;
                            lbDirect.Text = PP.heating;
                        }
                        // if heating and max temperature
                        if (PP.Temperature1 >= Convert.ToDouble(frmMOpt.txtTempEnd.Text) && PP.Direction == PP.heating)
                        {
                            dGridTempMeas["Direction", 0].Value = PP.Direction;
                            lbDirect.Text = PP.cooling;
                            PP.Direction = PP.cooling;
                        }
                        //if direction is cooling
                        if ( PP.Direction == "Cooling")
                        {
                            PP.Direction = PP.cooling;
                            dGridTempMeas["Direction", 0].Value = PP.Direction;
                            lbDirect.Text = PP.Direction;

                        }
                        
                        //limits
                        switch (cbCTE_Limit.Text)
                        {
                            case "20":
                                {
                                    //dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxCTE_A_20.Text),  1.2904).ToString();
                                    dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxCTE_A_20.Text), Convert.ToDouble(frmMOpt.txtApproxCTE_B_20.Text)).ToString();
                                    dGridTempMeas["precision", 0].Value = "20";
                                    break;
                                }
                            case "200":
                                {
                                    //dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, 207.72,  13.621).ToString();
                                    dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxCTE_A_200.Text), Convert.ToDouble(frmMOpt.txtApproxCTE_B_200.Text)).ToString();
                                    dGridTempMeas["precision", 0].Value = "200";
                                    break;
                                }
                            case "2000":
                                {
                                    //dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, 2069.5,  133.15).ToString();
                                    dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxCTE_A_2000.Text), Convert.ToDouble(frmMOpt.txtApproxCTE_B_2000.Text)).ToString();
                                    dGridTempMeas["precision", 0].Value = "2000";
                                    break;
                                }
                            default:
                                break;
                        }
                            //double ave = 0;
                            //for (int j = 0; j < PP.Xi0.Count(); j++)
                            //{
                            //    ave += PP.Xi0[j];
                            //}
                        ++PP.CelSel;
                        switch (frmMOpt.cWorkMode.Text)
                        {
                            case "CTE":
                                {
                                    chartMeasTemp1.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["T_K", 0].Value), Convert.ToDouble(dGridTempMeas["Xi", 0].Value));
                                    chartMeasTemp2.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["Timer", 0].Value), Convert.ToDouble(dGridTempMeas["T_K", 0].Value));
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        DBConn dBConn = new DBConn();
                        string sql = dBConn.DBExportDataString(this.dGridTempMeas, PP.DBTableName, 0);
                        FileJob FJ = new FileJob();
                        FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
                        break;
                    }
                default:
                    break;

            }

        }

        /// <summary>
        /// 
        /// </summary>
        void WorkModeMagnit_hand()
        {
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            WriteTempToFile();
            PiezoMathCalculation PM = new PiezoMathCalculation();
            if (PP.Temperature1 > Convert.ToDouble(frmMOpt.txtTempEnd.Text)) PP.Direction = "Cooling";
            //измерение и получение данных с прибора
            for (int i = 0; i < PP.ListFreq.Length; i++)
            {
                InitialiezeFreq(i);
                InitialiezeTrig();

                switch (frmMOpt.cbGPIBDevModel.Text)
                {
                    case "Agilent4980A":
                        Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9]{1}");
                        Regex reg1 = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{1}");

                        switch (frmGPIB.cbInterfaceType.Text)
                        {
                            case "ETHERNET":
                                frmGPIB.WriteCommandDev(PP.FetchGPIBDevices);

                                string s1 = "";
                                string[] rr;
                                bool match = false;
                                do
                                {
                                    char splitchar = (char)'\n';
                                    string[] sss = frmGPIB.answer.Split(splitchar);
                                    if (sss.Count() > 1)
                                    {
                                        s1 = sss[2];
                                        s1 = s1.Substring(12, 28);
                                        string ff = s1;
                                        rr = sss[2].Split('\0');
                                        rr = rr[0].Split((char)3);
                                        if (reg.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                        if (reg1.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                    }
                                } while (match == false);
                                break;
                            case "GPIB":
                                frmGPIB.WriteCommandDev(PM.ReplaceCommonEscapeSequences(PP.FetchAgilent4980));
                                frmGPIB.ReadDeviceAnswer();
                                break;
                            default:
                                break;
                        }

                        break;
                    case "Agilent4263B":
                        break;
                    default:
                        frmGPIB.ReadDeviceAnswer();
                        break;
                }

                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;
                MeasMagnit(PP.ListFreq[i]);
                ++PP.CelSel;
                this.Refresh();
            }
            //-------------------------------------------------------------
            InitialiezeFreq(0);
            this.Refresh();
        }

        /// <summary>
        /// 
        /// </summary>
        public void WorkMode_C_on_dU_hand_reversive()
        {
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            WriteTempToFile();
            PiezoMathCalculation PM = new PiezoMathCalculation();
            if (PP.Temperature1 > Convert.ToDouble(frmMOpt.txtTempEnd.Text)) PP.Direction = "Cooling";
            //измерение и получение данных с прибора
            for (int i = 0; i < PP.ListFreq.Length; i++)
            {
                InitialiezeFreq(i);
                InitialiezeTrig();

                switch (frmMOpt.cbGPIBDevModel.Text)
                {
                    case "Agilent4980A":
                        Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9]{1}");
                        Regex reg1 = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{1}");

                        switch (frmGPIB.cbInterfaceType.Text)
                        {
                            case "ETHERNET":
                                frmGPIB.WriteCommandDev(PP.FetchGPIBDevices);

                                string s1 = "";
                                string[] rr;
                                bool match = false;
                                do
                                {
                                    char splitchar = (char)'\n';
                                    string[] sss = frmGPIB.answer.Split(splitchar);
                                    if (sss.Count() > 1)
                                    {
                                        s1 = sss[2];
                                        s1 = s1.Substring(12, 28);
                                        string ff = s1;
                                        rr = sss[2].Split('\0');
                                        rr = rr[0].Split((char)3);
                                        if (reg.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                        if (reg1.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                    }
                                } while (match == false);
                                break;
                            case "GPIB":
                                frmGPIB.WriteCommandDev(PM.ReplaceCommonEscapeSequences(PP.FetchAgilent4980));
                                frmGPIB.ReadDeviceAnswer();
                                break;
                            default:
                                break;
                        }

                        break;
                    case "Agilent4263B":
                        break;
                    default:
                        frmGPIB.ReadDeviceAnswer();
                        break;
                }

                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;
                MeasReversive(PP.ListFreq[i]);
                ++PP.CelSel;
                this.Refresh();
            }
            //-------------------------------------------------------------
            InitialiezeFreq(0);
            this.Refresh();

        }

        private void MeasMagnit_Hand()
        {

            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            WriteTempToFile();
            PiezoMathCalculation PM = new PiezoMathCalculation();
            //измерение и получение данных с прибора
            for (int i = 0; i < PP.ListFreq.Length; i++)
            {
                InitialiezeFreq(i);
                InitialiezeTrig();

                switch (frmMOpt.cbGPIBDevModel.Text)
                {
                    case "Agilent4980A":
                        Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9]{1}");
                        Regex reg1 = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{1}");
                        switch (frmGPIB.cbInterfaceType.Text)
                        {
                            case "ETHERNET":
                                frmGPIB.WriteCommandDev(PP.FetchGPIBDevices);
                                string s1 = "";
                                string[] rr;
                                bool match = false;
                                do
                                {
                                    char splitchar = (char)'\n';
                                    string[] sss = frmGPIB.answer.Split(splitchar);
                                    if (sss.Count() > 1)
                                    {
                                        s1 = sss[2];
                                        s1 = s1.Substring(12, 28);
                                        string ff = s1;
                                        rr = sss[2].Split('\0');
                                        rr = rr[0].Split((char)3);
                                        if (reg.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                        if (reg1.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                    }
                                } while (match == false);
                                break;
                            case "GPIB":
                                frmGPIB.WriteCommandDev(PM.ReplaceCommonEscapeSequences(PP.FetchAgilent4980));
                                frmGPIB.ReadDeviceAnswer();
                                break;
                            case "USB":
                                {
                                    frmGPIB.ReadDeviceAnswer(PP.FetchAgilent4980);
                                    break;
                                }

                            default:
                                break;
                        }
                        break;
                    case "E7-20":
                        {
                            PiezoMathCalculation pm = new PiezoMathCalculation();
                            do
                            {
                                System.Threading.Thread.Sleep(500);
                                PP.bufE7_20 = Com.GetDataFromCOMDevice("E7-20", 0, 22);
                                if (PP.bufE7_20[14] != 0)
                                {
                                    PP.bufE7_20[12] = (byte)(PP.bufE7_20[12] ^ 0xff);
                                    PP.bufE7_20[13] = (byte)(PP.bufE7_20[13] ^ 0xff);
                                    PP.bufE7_20[14] = (byte)(PP.bufE7_20[14] ^ 0xff);
                                    PP.param2_E7_20 = (-1 - PP.bufE7_20[12] - (PP.bufE7_20[13] + PP.bufE7_20[14] * 256) * 256) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[15])), -1);
                                }
                                else PP.param2_E7_20 = pm.BytesToDouble(PP.bufE7_20, 12, 3) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[15])), -1);
                                if (PP.bufE7_20[18] != 0)
                                {
                                    PP.bufE7_20[16] = (byte)(PP.bufE7_20[16] ^ 0xff);
                                    PP.bufE7_20[17] = (byte)(PP.bufE7_20[17] ^ 0xff);
                                    PP.bufE7_20[18] = (byte)(PP.bufE7_20[18] ^ 0xff);
                                    PP.param1_E7_20 = (-1 - PP.bufE7_20[16] - (PP.bufE7_20[17] + PP.bufE7_20[18] * 256) * 256) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[19])), -1);

                                }
                                else PP.param1_E7_20 = pm.BytesToDouble(PP.bufE7_20, 16, 3) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[19])), -1);
                                //if (m1 == false) PP.param1_E7_20 = pm.BytesToDouble(PP.bufE7_20, 16, 3) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[19])), -1);
                                //if (m2 == false) PP.param2_E7_20 = pm.BytesToDouble(PP.bufE7_20, 12, 3) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[15])), -1);
                            } while (PP.bufE7_20[3] == 0 || PP.param1_E7_20 > 1e25);

                            break;
                        }
                    default:
                        break;
                }

                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;
                MeasMagnit(PP.ListFreq[i]);
                ++PP.CelSel;
                this.Refresh();
            }
            //-------------------------------------------------------------
            InitialiezeFreq(0);
            this.Refresh();


            //System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            //myStopwatch.Start();
            //GetTempFromVarta();
            //WriteTempToFile();


            //double timeCoef = 0.001;
            //string s = frmGPIB.answer;
            //double e_e0;
            //double tgper, Y;
            //double e_e2;
            ////double emk;
            //double t;
            //double d;
            //double val1 = 0;
            //double val2 = 0;
            //PiezoMathCalculation PM = new PiezoMathCalculation();
            //ParseStringTab PS = new ParseStringTab();
            //switch (frmMOpt.cbGPIBDevModel.Text)
            //{
            //    case "Agilent4980A":
            //        {
            //            PS.AddMeasStringAgilent4980(s);
            //            switch (frmGPIB.cbInterfaceType.Text)
            //            {
            //                case "GPIB":
            //                    val1 = Convert.ToDouble(PS.ElementAt(0));
            //                    val2 = Convert.ToDouble(PS.ElementAt(1));
            //                    break;
            //                case "ETHERNET":
            //                    val1 = Convert.ToDouble(PS.ElementAt(1));
            //                    val2 = Convert.ToDouble(PS.ElementAt(2));
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;
            //        }
            //    case "Agilent4285A": PS.AddMeasStringAgilent4980(s); break;
            //    case "Agilent4263B":
            //        {
            //            PS.AddMeasStringAgilent4263(s);
            //            val1 = Convert.ToDouble(PS.ElementAt(1));
            //            val2 = Convert.ToDouble(PS.DeleteZero(PS.ElementAt(2)));
            //            break;
            //        }
            //    case "Agilent34401A": PS.AddMeasStringAgilent4980(s); break;
            //    case "WayneKerr6500B": PS.AddMeasStringWayneKerr6500B(s); break;
            //    case "WayneKerr4300":
            //        {
            //            //+8.2556835e-13,-1.6205449e+00
            //            PS.AddMeasStringWayneKerr4300(s);
            //            val1 = Convert.ToDouble(PS.ElementAt(0));
            //            val2 = Convert.ToDouble(PS.ElementAt(1));
            //            break;
            //        }
            //    default:
            //        PS.AddMeasStringAgilent4980(s);
            //        break;
            //}

            //if (txtHBias.Text == "")
            //{
            //    txtHBias.Text = "0";
            //}
            //if (txtUbias.Text == "")
            //{
            //    txtUbias.Text = "0";
            //}

            //if (frmMOpt.cbExportDBMeasTemp.Text == "Export to DB(only)")
            //{
            //    string dateformat = "hh:mm:ss.fff";
            //    DateTime dateT = new DateTime();
            //    dateT = DateTime.Now;
            //    dateT.AddMilliseconds(1);
            //    dGridTempMeas["id", 0].Value = PP.CelSel.ToString();
            //    dGridTempMeas["composition", 0].Value = frmMOpt.txtComposition.Text;
            //    dGridTempMeas["id_sample", 0].Value = frmMOpt.txtSampleNumber.Text;
            //    dGridTempMeas["Tsint_K", 0].Value = frmMOpt.txtTempSint.Text;
            //    dGridTempMeas["composition", 0].Value = frmMOpt.txtHeight.Text;
            //    t = Convert.ToDouble(frmMOpt.txtHeight.Text);
            //    dGridTempMeas["d_cm", 0].Value = frmMOpt.txtDiameter.Text;
            //    d = Convert.ToDouble(frmMOpt.txtDiameter.Text);
            //    dGridTempMeas["T_K", 0].Value = lbTemp.Text;
            //    dGridTempMeas["f_Hz", 0].Value = freq;
            //    dGridTempMeas["C_pF", 0].Value = (Convert.ToDouble(val1) * 1e12).ToString();
            //    e_e0 = PM.e_re(t, d, Convert.ToDouble(dGridTempMeas["C_pF", 0].Value));
            //    dGridTempMeas["e_re", 0].Value = e_e0.ToString();
            //    dGridTempMeas["tgd", 0].Value = val2;
            //    tgper = Convert.ToDouble(dGridTempMeas["tgd", 0].Value);
            //    dGridTempMeas["tgd1e2", 0].Value = PM.tgdE2(tgper).ToString();
            //    e_e2 = PM.e_im(e_e0, Convert.ToDouble(dGridTempMeas["tgd", 0].Value));
            //    dGridTempMeas["e_im", 0].Value = e_e2.ToString();
            //    Y = e_e2 * Convert.ToInt32(freq) * 2 * 3.14;
            //    dGridTempMeas["Y", 0].Value = Y.ToString();

            //    PP.BiasUCurrent = GetUFromVoltmeter();
            //    if (chPolarity.Checked == true)
            //    {
            //        PP.Polarity = PP.PolarityPositive;
            //    }
            //    if (chPolarity.Checked == false)
            //    {
            //        PP.Polarity = PP.PolarityNegative;
            //    }


            //    if (PP.Polarity == PP.PolarityPositive)
            //    {
            //        if (PP.BiasUCurrent != 0)
            //        {
            //            PP.BiasHCurrent = 6e-8 * Math.Pow(PP.BiasUCurrent,3)- 4e-5 * Math.Pow(PP.BiasUCurrent,2) + 0.0098 * PP.BiasUCurrent - 0.0312;
            //            dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent;
            //            txtHBias.Text = PP.BiasHCurrent.ToString();
            //        }
            //        else { dGridTempMeas["Hbias_T", 0].Value = 0;
            //        }
            //    }
            //    if (PP.Polarity == PP.PolarityNegative)
            //    {
            //        if (PP.BiasUCurrent != 0)
            //        {
            //            PP.BiasHCurrent = (6e-8 * Math.Pow(PP.BiasUCurrent, 3) - 4e-5 * Math.Pow(PP.BiasUCurrent, 2) + 0.0098 * PP.BiasUCurrent - 0.0312)*(-1);
            //            dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent;
            //            txtHBias.Text = PP.BiasHCurrent.ToString();
            //        }
            //        else { dGridTempMeas["Hbias_T", 0].Value = 0; }
            //    }

            //    dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent.ToString(); 
            //    dGridTempMeas["Cycle", 0].Value = PP.cycleCurrentNum.ToString();
            //    dGridTempMeas["Date", 0].Value = DateTime.Now.ToShortDateString();
            //    dGridTempMeas["Time", 0].Value = dateT.ToString(dateformat);
            //    dGridTempMeas["Step", 0].Value = PP.CurrentStep;
            //    dGridTempMeas["Direction", 0].Value = PP.Direction;
            //    dGridTempMeas["Polarity", 0].Value = PP.Polarity;
            //    dGridTempMeas["operator", 0].Value = frmMOpt.cmbOperator.Text;
            //    myStopwatch.Stop();
            //    PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;


            //    dGridTempMeas["Timer", 0].Value = (PP.TimeMeas).ToString();
            //    dGridTempMeas["Meas_type", 0].Value = frmMOpt.cWorkMode.Text;
            //    txtUbias.Text = dGridTempMeas["Ubias_V", 0].Value.ToString();

            //    //if (frmMOpt.cWorkMode.Text == "Magnit_hand")
            //    //{
            //    //    dGridTempMeas["Step", 0].Value = PP.CurrentStep.ToString();
            //    //    dGridTempMeas["Direction", 0].Value = PP.Direction.ToString();
            //    //    dGridTempMeas["Polarity", 0].Value = PP.Polarity.ToString();
            //    //}

            //    switch (frmMOpt.cWorkMode.Text)
            //    {
            //        default:
            //            {
            //                for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
            //                {
            //                    if (chartMeasTemp1.Series[u].Name.ToString() == (dGridTempMeas["f_Hz", 0].Value + "\r").ToString() ||
            //                        chartMeasTemp1.Series[u].Name.ToString() == dGridTempMeas["f_Hz", 0].Value.ToString())
            //                    {
            //                        double num0;
            //                        bool isNum0 = double.TryParse(dGridTempMeas["e_re", 0].Value.ToString(), out num0);
            //                        double num1;
            //                        bool isNum1 = double.TryParse(dGridTempMeas["e_im", 0].Value.ToString(), out num1);

            //                        if (Convert.ToDouble(dGridTempMeas["e_re", 0].Value) < 1e40 &&
            //                            Convert.ToDouble(dGridTempMeas["e_re", 0].Value) > -1e10 &&
            //                            Convert.ToDouble(dGridTempMeas["e_im", 0].Value) < 1e40 &&
            //                            Convert.ToDouble(dGridTempMeas["e_im", 0].Value) > -1e40 &&
            //                            isNum0 == true && isNum1 == true)
            //                        {
            //                            switch (frmMOpt.cbGraphOptions.Text)
            //                            {
            //                                case "e(T)":
            //                                    {
            //                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["T_K", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
            //                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["T_K", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));
            //                                        break;
            //                                    }
            //                                case "e(E)":
            //                                    {
            //                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
            //                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));
            //                                        break;
            //                                    }
            //                                case "e(f)":
            //                                    {
            //                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["f_Hz", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
            //                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["f_Hz", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));
            //                                        break;
            //                                    }
            //                                default:
            //                                    {
            //                                        break;
            //                                    }

            //                            }
            //                        }

            //                    }
            //                }
            //                break;
            //            }
            //    }
            //    DBConn dBConn = new DBConn();
            //    string sql = dBConn.DBExportDataString(this.dGridTempMeas, PP.DBTableName, 0);
            //    FileJob FJ = new FileJob();
            //    FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
            //}
            //this.Refresh();
        }


        private void MeasMagnit(string freq)
        {

            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            WriteTempToFile();

            if (frmMOpt.cWorkMode.Text == "Magnit_hand")
            {
                PP.BiasUCurrent = GetUFromVoltmeter();
                txtHBias.Text = PP.BiasUCurrent.ToString();


                if (PP.Polarity == PP.PolarityPositive)
                {
                    if (PP.BiasUCurrent != 0)
                    {
                        PP.BiasHCurrent = 6e-8 * Math.Pow(PP.BiasUCurrent, 3) - 4e-5 * Math.Pow(PP.BiasUCurrent, 2) + 0.0098 * PP.BiasUCurrent - 0.0312;
                        dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent;
                        txtHBias.Text = PP.BiasHCurrent.ToString();
                    }
                    else { dGridTempMeas["Hbias_T", 0].Value = 0; }
                }
                if (PP.Polarity == PP.PolarityNegative)
                {
                    if (PP.BiasUCurrent != 0)
                    {
                        PP.BiasHCurrent = (6e-8 * Math.Pow(PP.BiasUCurrent, 3) - 4e-5 * Math.Pow(PP.BiasUCurrent, 2) + 0.0098 * PP.BiasUCurrent - 0.0312) * (-1);
                        dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent;
                        txtHBias.Text = PP.BiasHCurrent.ToString();
                    }
                    else { dGridTempMeas["Hbias_T", 0].Value = 0; }
                }

            }

            double timeCoef = 0.001;
            //string s = frmGPIB.answer;
            double e_e0;
            double tgper, Y;
            double e_e2;
            double emk;
            double t;
            double d;
            double val1 = 0;
            double val2 = 0;

            PiezoMathCalculation PM = new PiezoMathCalculation();
            ParseStringTab PS = new ParseStringTab();

            PP.BiasHCurrent = Convert.ToDouble(txtHBias.Text);
            switch (frmMOpt.cbGPIBDevModel.Text)
            {
                case "Agilent4980A":
                    {
                        PS.AddMeasStringAgilent4980(frmGPIB.answer);
                        switch (frmGPIB.cbInterfaceType.Text)
                        {
                            case "GPIB":
                                val1 = Convert.ToDouble(PS.ElementAt(0));
                                val2 = Convert.ToDouble(PS.ElementAt(1));
                                break;
                            case "ETHERNET":
                                val1 = Convert.ToDouble(PS.ElementAt(1));
                                val2 = Convert.ToDouble(PS.ElementAt(2));
                                break;
                            default:
                                val1 = Convert.ToDouble(PS.ElementAt(0));
                                val2 = Convert.ToDouble(PS.ElementAt(1));
                                break;
                        }
                        break;
                    }
                case "Agilent4285A":
                    PS.AddMeasStringAgilent4285A(frmGPIB.answer);
                    try
                    {
                        val1 = Convert.ToDouble(PS.ElementAt(0));
                        val2 = Convert.ToDouble(PS.ElementAt(1));
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                    break;

                case "Agilent4263B":
                    {
                        PS.AddMeasStringAgilent4263(frmGPIB.answer);
                        val1 = Convert.ToDouble(PS.ElementAt(1));
                        val2 = Convert.ToDouble(PS.DeleteZero(PS.ElementAt(2)));
                        break;
                    }
                case "Agilent34401A": PS.AddMeasStringAgilent4980(frmGPIB.answer); break;
                case "WayneKerr6500B": PS.AddMeasStringWayneKerr6500B(frmGPIB.answer); break;
                case "WayneKerr4300":
                    {
                        //+8.2556835e-13,-1.6205449e+00
                        PS.AddMeasStringWayneKerr4300(frmGPIB.answer);
                        val1 = Convert.ToDouble(PS.ElementAt(0));
                        val2 = Convert.ToDouble(PS.ElementAt(1));
                        break;
                    }
                case "E7-20":
                    {
                        val2 = PP.param2_E7_20;
                        val1 = PP.param1_E7_20;
                        break;
                    }
                default:
                    PS.AddMeasStringAgilent4980(frmGPIB.answer);
                    break;
            }
            if (frmMOpt.cWorkMode.Text != "Magnit_hand")
            {
                if (txtHBias.Text == "")
                {
                    txtHBias.Text = "0";
                }
                if (txtUbias.Text == "")
                {
                    txtUbias.Text = "0";
                }
            }
            if (frmMOpt.cbExportDBMeasTemp.Text == "None")
            {
                try
                {
                    string dateformat = "hh:mm:ss.fff";
                    DateTime dateT = new DateTime();
                    dateT = DateTime.Now;
                    dateT.AddMilliseconds(1);
                    dGridTempMeas["id", PP.CelSel].Value = PP.CelSel.ToString();
                    dGridTempMeas["composition", 0].Value = frmMOpt.txtComposition.Text;
                    dGridTempMeas["id_sample", 0].Value = frmMOpt.txtSampleNumber.Text;
                    dGridTempMeas["Tsint_K", 0].Value = frmMOpt.txtTempSint.Text;
                    dGridTempMeas["composition", 0].Value = frmMOpt.txtHeight.Text;
                    t = Convert.ToDouble(frmMOpt.txtHeight.Text);
                    dGridTempMeas["d_cm", 0].Value = frmMOpt.txtDiameter.Text;
                    d = Convert.ToDouble(frmMOpt.txtDiameter.Text);
                    dGridTempMeas["T_K", 0].Value = lbTemp.Text;
                    dGridTempMeas["f_Hz", 0].Value = freq;
                    emk = val1 * 1e12;
                    dGridTempMeas["C_pF", 0].Value = emk.ToString();
                    e_e0 = PM.e_re(t, d, emk);
                    dGridTempMeas["e_re", 0].Value = e_e0.ToString();
                    dGridTempMeas["tgd", 0].Value = val2;
                    tgper = Convert.ToDouble(dGridTempMeas["tgd", 0].Value);
                    dGridTempMeas["tgd1e2", 0].Value = PM.tgdE2(tgper).ToString();
                    e_e2 = PM.e_im(e_e0, tgper);
                    dGridTempMeas["e_im", 0].Value = e_e2.ToString();
                    Y = e_e2 * Convert.ToInt32(freq) * 2 * 3.14;
                    dGridTempMeas["Y", 0].Value = Y.ToString();
                    //dGridTempMeas["Direct", i].Value = lbDirect.Text;
                    dGridTempMeas["Ubias_V", 0].Value = txtUbias.Text;
                    dGridTempMeas["Hbias_T", 0].Value = txtHBias.Text;
                    dGridTempMeas["Cycle", 0].Value = PP.cycleCurrentNum.ToString();
                    dGridTempMeas["Date", 0].Value = DateTime.Now.ToShortDateString();
                    dGridTempMeas["Time", 0].Value = dateT.ToString(dateformat);
                    dGridTempMeas["operator", 0].Value = frmMOpt.cmbOperator.Text;

                    myStopwatch.Stop();
                    PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;

                    dGridTempMeas["Timer", 0].Value = (PP.TimeMeas).ToString();
                    dGridTempMeas["Polarity", 0].Value = PP.Polarity;
                    dGridTempMeas["Direction", 0].Value = PP.Direction;
                    dGridTempMeas["Step", 0].Value = PP.CurrentStep;
                    dGridTempMeas["Meas_type", 0].Value = frmMOpt.cWorkMode.Text;
                    dGridTempMeas.Rows.Add();
                    AutoSaveMeas(PP.FileNameSaveTempMeas);
                    this.Refresh();

                    for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
                    {
                        if (chartMeasTemp1.Series[u].Name == freq)
                        {
                            chartMeasTemp1.Series[u].Points.AddXY(lbTemp, e_e0);
                            chartMeasTemp2.Series[u].Points.AddXY(lbTemp, tgper);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }


            if (frmMOpt.cbExportDBMeasTemp.Text == "Export to DB parallel" && frmDBConnection.DataBaseConnected == true)
            {
                try
                {
                    NpgsqlConnection pgcon = new NpgsqlConnection(frmDBConnection.ConnectionStringToDB);
                    pgcon.Open();
                    string sql = "";
                    NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
                    string sql_data = "";
                    for (int j = 1; j < dGridTempMeas.ColumnCount + 1; j++)
                    {
                        sql_data = sql_data + dGridTempMeas.Rows[0].Cells[j].Value.ToString() + ", ";
                    }
                    sql_data = sql_data.Substring(0, sql_data.Length - 2);
                    sql = "Insert into " + frmMOpt.txtComposition + " values (" + sql_data + ");";
                    CSend.ExecuteNonQuery();
                    FileJob FJ = new FileJob();
                    FJ.WriteF(sql, PP.FileNameSaveTempMeas + ".log");
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            if (frmMOpt.cbExportDBMeasTemp.Text == "Export to DB(only)")
            {
                string dateformat = "hh:mm:ss.fff";
                DateTime dateT = new DateTime();
                dateT = DateTime.Now;
                dateT.AddMilliseconds(1);
                dGridTempMeas["id", 0].Value = PP.CelSel.ToString();
                dGridTempMeas["composition", 0].Value = frmMOpt.txtComposition.Text;
                dGridTempMeas["id_sample", 0].Value = frmMOpt.txtSampleNumber.Text;
                dGridTempMeas["Tsint_K", 0].Value = frmMOpt.txtTempSint.Text;
                dGridTempMeas["composition", 0].Value = frmMOpt.txtHeight.Text;
                t = Convert.ToDouble(frmMOpt.txtHeight.Text);
                dGridTempMeas["d_cm", 0].Value = frmMOpt.txtDiameter.Text;
                d = Convert.ToDouble(frmMOpt.txtDiameter.Text);
                dGridTempMeas["T_K", 0].Value = lbTemp.Text;
                dGridTempMeas["f_Hz", 0].Value = freq;
                dGridTempMeas["C_pF", 0].Value = (Convert.ToDouble(val1) * 1e12).ToString();
                e_e0 = PM.e_re(t, d, Convert.ToDouble(dGridTempMeas["C_pF", 0].Value));
                dGridTempMeas["e_re", 0].Value = e_e0.ToString();
                dGridTempMeas["tgd", 0].Value = val2;
                tgper = Convert.ToDouble(dGridTempMeas["tgd", 0].Value);
                dGridTempMeas["tgd1e2", 0].Value = PM.tgdE2(tgper).ToString();
                e_e2 = PM.e_im(e_e0, Convert.ToDouble(dGridTempMeas["tgd", 0].Value));
                dGridTempMeas["e_im", 0].Value = e_e2.ToString();
                Y = e_e2 * Convert.ToInt32(freq) * 2 * 3.14;
                dGridTempMeas["Y", 0].Value = Y.ToString();
                dGridTempMeas["Ubias_V", 0].Value = PP.BiasUCurrent;







                PP.BiasHCurrent = GetUFromVoltmeter();
                txtHBias.Text = PP.BiasHCurrent.ToString();
                //PP.BiasUCurrent = 0.0825 * (PP.BiasUCurrent) + 0.1728;


                if (chPolarity.Checked == true)
                {
                    PP.Polarity = PP.PolarityPositive;
                }
                if (chPolarity.Checked == false)
                {
                    PP.Polarity = PP.PolarityNegative;
                }






                if (PP.Polarity == PP.PolarityPositive)
                {
                    if (PP.BiasUCurrent != 0)
                    {
                        //dGridTempMeas["Ubias_V", 0].Value = Convert.ToDouble(frmMOpt.txtApproxA) * PP.BiasUCurrent + Convert.ToDouble(frmMOpt.txtApproxB);
                        dGridTempMeas["Ubias_V", 0].Value = PP.BiasHCurrent;
                    }
                    else { dGridTempMeas["Hbias_T", 0].Value = 0; }
                }
                if (PP.Polarity == PP.PolarityNegative)
                {
                    if (PP.BiasUCurrent != 0)
                    {
                        //dGridTempMeas["Ubias_V", 0].Value = (21.13 * PP.BiasUCurrent - 3.9299) * (-1);
                        dGridTempMeas["Ubias_V", 0].Value = PP.BiasHCurrent * (-1);
                    }
                    else { dGridTempMeas["Hbias_T", 0].Value = 0; }
                }

                //dGridTempMeas["Hbias_T", 0].Value = txtHBias.Text;



                dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent;
                dGridTempMeas["Cycle", 0].Value = PP.cycleCurrentNum.ToString();
                dGridTempMeas["Date", 0].Value = DateTime.Now.ToShortDateString();
                dGridTempMeas["Time", 0].Value = dateT.ToString(dateformat);
                dGridTempMeas["Step", 0].Value = PP.CurrentStep;
                dGridTempMeas["Direction", 0].Value = PP.Direction;
                dGridTempMeas["Polarity", 0].Value = PP.Polarity;
                dGridTempMeas["operator", 0].Value = frmMOpt.cmbOperator.Text;
                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;

                dGridTempMeas["Timer", 0].Value = (PP.TimeMeas).ToString();
                dGridTempMeas["Meas_type", 0].Value = frmMOpt.cWorkMode.Text;

                if (frmMOpt.cWorkMode.Text == "C(dU)_auto_reversive")
                {
                    dGridTempMeas["Step", 0].Value = PP.CurrentStep.ToString();
                    dGridTempMeas["Direction", 0].Value = PP.Direction.ToString();
                    dGridTempMeas["Polarity", 0].Value = PP.Polarity.ToString();
                }

                switch (frmMOpt.cWorkMode.Text)
                {
                    case "C(dU,dt,df)_relaxation_(law from file)":
                        {
                            for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
                            {
                                if (chartMeasTemp1.Series[u].Name == freq)
                                {
                                    chartMeasTemp1.Series[u].Points.AddXY(PP.TimeMeas, e_e0);
                                    chartMeasTemp2.Series[u].Points.AddXY(PP.TimeMeas, tgper);
                                    chartMeasTemp1.Update();
                                    chartMeasTemp2.Update();
                                }
                            }
                            break;
                        }
                    default:
                        {
                            for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
                            {
                                if (chartMeasTemp1.Series[u].Name == freq + "\r")
                                {
                                    if (frmMOpt.cbGraphOptions.Text == "e(T)" && e_e0 > 0 && e_e0 < 1e25)
                                    {
                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(PP.Temperature1), e_e0);
                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(PP.Temperature1), tgper);
                                        chartMeasTemp1.Update();
                                        chartMeasTemp2.Update();
                                    }
                                    if (frmMOpt.cbGraphOptions.Text == "e(E)" && e_e0 > 0 && e_e0 < 1e25)
                                    {
                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(PP.BiasUCurrent), e_e0);
                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(PP.BiasUCurrent), tgper);
                                        chartMeasTemp1.Update();
                                        chartMeasTemp2.Update();
                                    }

                                    if (frmMOpt.cbGraphOptions.Text == "e(f)" && e_e0 > 0 && e_e0 < 1e25)
                                    {
                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(freq), e_e0);
                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(freq), tgper);
                                        chartMeasTemp1.Update();
                                        chartMeasTemp2.Update();
                                    }
                                }
                            }
                            break;
                        }
                }
                DBConn dBConn = new DBConn();
                string sql = dBConn.DBExportDataString(this.dGridTempMeas, PP.DBTableName, 0);
                FileJob FJ = new FileJob();
                FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
            }
            this.Refresh();











            //System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            //myStopwatch.Start();
            //GetTempFromVarta();
            //WriteTempToFile();


            //double timeCoef = 0.001;
            //string s = frmGPIB.answer;
            //double e_e0;
            //double tgper, Y;
            //double e_e2;
            ////double emk;
            //double t;
            //double d;
            //double val1 = 0;
            //double val2 = 0;
            //PiezoMathCalculation PM = new PiezoMathCalculation();
            //ParseStringTab PS = new ParseStringTab();
            //switch (frmMOpt.cbGPIBDevModel.Text)
            //{
            //    case "Agilent4980A":
            //        {
            //            PS.AddMeasStringAgilent4980(s);
            //            switch (frmGPIB.cbInterfaceType.Text)
            //            {
            //                case "GPIB":
            //                    val1 = Convert.ToDouble(PS.ElementAt(0));
            //                    val2 = Convert.ToDouble(PS.ElementAt(1));
            //                    break;
            //                case "ETHERNET":
            //                    val1 = Convert.ToDouble(PS.ElementAt(1));
            //                    val2 = Convert.ToDouble(PS.ElementAt(2));
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;
            //        }
            //    case "Agilent4285A": PS.AddMeasStringAgilent4980(s); break;
            //    case "Agilent4263B":
            //        {
            //            PS.AddMeasStringAgilent4263(s);
            //            val1 = Convert.ToDouble(PS.ElementAt(1));
            //            val2 = Convert.ToDouble(PS.DeleteZero(PS.ElementAt(2)));
            //            break;
            //        }
            //    case "Agilent34401A": PS.AddMeasStringAgilent4980(s); break;
            //    case "WayneKerr6500B": PS.AddMeasStringWayneKerr6500B(s); break;
            //    case "WayneKerr4300":
            //        {
            //            //+8.2556835e-13,-1.6205449e+00
            //            PS.AddMeasStringWayneKerr4300(s);
            //            val1 = Convert.ToDouble(PS.ElementAt(0));
            //            val2 = Convert.ToDouble(PS.ElementAt(1));
            //            break;
            //        }
            //    default:
            //        PS.AddMeasStringAgilent4980(s);
            //        break;
            //}

            //if (txtHBias.Text == "")
            //{
            //    txtHBias.Text = "0";
            //}
            //if (txtUbias.Text == "")
            //{
            //    txtUbias.Text = "0";
            //}

            //if (frmMOpt.cbExportDBMeasTemp.Text == "Export to DB(only)")
            //{
            //    string dateformat = "hh:mm:ss.fff";
            //    DateTime dateT = new DateTime();
            //    dateT = DateTime.Now;
            //    dateT.AddMilliseconds(1);
            //    dGridTempMeas["id", 0].Value = PP.CelSel.ToString();
            //    dGridTempMeas["composition", 0].Value = frmMOpt.txtComposition.Text;
            //    dGridTempMeas["id_sample", 0].Value = frmMOpt.txtSampleNumber.Text;
            //    dGridTempMeas["Tsint_K", 0].Value = frmMOpt.txtTempSint.Text;
            //    dGridTempMeas["composition", 0].Value = frmMOpt.txtHeight.Text;
            //    t = Convert.ToDouble(frmMOpt.txtHeight.Text);
            //    dGridTempMeas["d_cm", 0].Value = frmMOpt.txtDiameter.Text;
            //    d = Convert.ToDouble(frmMOpt.txtDiameter.Text);
            //    dGridTempMeas["T_K", 0].Value = lbTemp.Text;
            //    dGridTempMeas["f_Hz", 0].Value = freq;
            //    dGridTempMeas["C_pF", 0].Value = (Convert.ToDouble(val1) * 1e12).ToString();
            //    e_e0 = PM.e_re(t, d, Convert.ToDouble(dGridTempMeas["C_pF", 0].Value));
            //    dGridTempMeas["e_re", 0].Value = e_e0.ToString();
            //    dGridTempMeas["tgd", 0].Value = val2;
            //    tgper = Convert.ToDouble(dGridTempMeas["tgd", 0].Value);
            //    dGridTempMeas["tgd1e2", 0].Value = PM.tgdE2(tgper).ToString();
            //    e_e2 = PM.e_im(e_e0, Convert.ToDouble(dGridTempMeas["tgd", 0].Value));
            //    dGridTempMeas["e_im", 0].Value = e_e2.ToString();
            //    Y = e_e2 * Convert.ToInt32(freq) * 2 * 3.14;
            //    dGridTempMeas["Y", 0].Value = Y.ToString();
            //    //dGridTempMeas["Direct", 0].Value = lbDirect.Text;

            //    PP.BiasHCurrent = GetUFromVoltmeter();
            //    txtHBias.Text= PP.BiasHCurrent.ToString();
            //    //PP.BiasUCurrent = 0.0825 * (PP.BiasUCurrent) + 0.1728;


            //    if (chPolarity.Checked == true)
            //    {
            //        PP.Polarity = PP.PolarityPositive;
            //    }
            //    if (chPolarity.Checked == false)
            //    {
            //        PP.Polarity = PP.PolarityNegative;
            //    }






            //    if (PP.Polarity == PP.PolarityPositive)
            //    {
            //        if (PP.BiasUCurrent != 0)
            //        {
            //            //dGridTempMeas["Ubias_V", 0].Value = Convert.ToDouble(frmMOpt.txtApproxA) * PP.BiasUCurrent + Convert.ToDouble(frmMOpt.txtApproxB);
            //            dGridTempMeas["Ubias_V", 0].Value = PP.BiasHCurrent;
            //        }
            //        else { dGridTempMeas["Hbias_V", 0].Value = 0; }
            //    }
            //    if (PP.Polarity == PP.PolarityNegative)
            //    {
            //        if (PP.BiasUCurrent != 0)
            //        {
            //            //dGridTempMeas["Ubias_V", 0].Value = (21.13 * PP.BiasUCurrent - 3.9299) * (-1);
            //            dGridTempMeas["Hbias_V", 0].Value = PP.BiasHCurrent*(-1);
            //        }
            //        else { dGridTempMeas["Hbias_V", 0].Value = 0; }
            //    }

            //    //dGridTempMeas["Hbias_T", 0].Value = txtHBias.Text;
            //    dGridTempMeas["Cycle", 0].Value = PP.cycleCurrentNum.ToString();
            //    dGridTempMeas["Date", 0].Value = DateTime.Now.ToShortDateString();
            //    dGridTempMeas["Time", 0].Value = dateT.ToString(dateformat);
            //    dGridTempMeas["Step", 0].Value = PP.CurrentStep;
            //    dGridTempMeas["Direction", 0].Value = PP.Direction;
            //    dGridTempMeas["Polarity", 0].Value = PP.Polarity;
            //    dGridTempMeas["operator", 0].Value = frmMOpt.cmbOperator.Text;
            //    myStopwatch.Stop();
            //    PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;


            //    dGridTempMeas["Timer", 0].Value = (PP.TimeMeas).ToString();
            //    dGridTempMeas["Meas_type", 0].Value = frmMOpt.cWorkMode.Text;
            //    txtUbias.Text = dGridTempMeas["Ubias_V", 0].Value.ToString();

            //    if (frmMOpt.cWorkMode.Text == "C(dU)_auto_reversive")
            //    {
            //        dGridTempMeas["Step", 0].Value = PP.CurrentStep.ToString();
            //        dGridTempMeas["Direction", 0].Value = PP.Direction.ToString();
            //        dGridTempMeas["Polarity", 0].Value = PP.Polarity.ToString();
            //    }

            //    switch (frmMOpt.cWorkMode.Text)
            //    {
            //        default:
            //            {
            //                for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
            //                {
            //                    if (chartMeasTemp1.Series[u].Name.ToString() == (dGridTempMeas["f_Hz", 0].Value + "\r").ToString() ||
            //                        chartMeasTemp1.Series[u].Name.ToString() == dGridTempMeas["f_Hz", 0].Value.ToString())
            //                    {
            //                        double num0;
            //                        bool isNum0 = double.TryParse(dGridTempMeas["e_re", 0].Value.ToString(), out num0);
            //                        double num1;
            //                        bool isNum1 = double.TryParse(dGridTempMeas["e_im", 0].Value.ToString(), out num1);

            //                        if (Convert.ToDouble(dGridTempMeas["e_re", 0].Value) < 1e40 &&
            //                            Convert.ToDouble(dGridTempMeas["e_re", 0].Value) > -1e10 &&
            //                            Convert.ToDouble(dGridTempMeas["e_im", 0].Value) < 1e40 &&
            //                            Convert.ToDouble(dGridTempMeas["e_im", 0].Value) > -1e40 &&
            //                            isNum0 == true && isNum1 == true)
            //                        {
            //                            switch (frmMOpt.cbGraphOptions.Text)
            //                            {
            //                                case "e(T)":
            //                                    {
            //                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["T_K", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
            //                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["T_K", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));
            //                                        break;
            //                                    }
            //                                case "e(E)":
            //                                    {
            //                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
            //                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));
            //                                        break;
            //                                    }
            //                                case "e(f)":
            //                                    {
            //                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["f_Hz", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
            //                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["f_Hz", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));

            //                                        break;
            //                                    }
            //                                default:
            //                                    {
            //                                        break;
            //                                    }

            //                            }
            //                        }

            //                    }
            //                }
            //                break;
            //            }
            //    }
            //    DBConn dBConn = new DBConn();
            //    string sql = dBConn.DBExportDataString(this.dGridTempMeas, PP.DBTableName, 0);
            //    FileJob FJ = new FileJob();
            //    FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
            //}
            //this.Refresh();
        }



        private void MeasReversive(string freq)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            WriteTempToFile();


            double timeCoef = 0.001;
            string s = frmGPIB.answer;
            double e_e0;
            double tgper, Y;
            double e_e2;
            //double emk;
            double t;
            double d;
            double val1 = 0;
            double val2 = 0;
            PiezoMathCalculation PM = new PiezoMathCalculation();
            ParseStringTab PS = new ParseStringTab();
            switch (frmMOpt.cbGPIBDevModel.Text)
            {
                case "Agilent4980A":
                    {
                        PS.AddMeasStringAgilent4980(s);
                        switch (frmGPIB.cbInterfaceType.Text)
                        {
                            case "GPIB":
                                val1 = Convert.ToDouble(PS.ElementAt(0));
                                val2 = Convert.ToDouble(PS.ElementAt(1));
                                break;
                            case "ETHERNET":
                                val1 = Convert.ToDouble(PS.ElementAt(1));
                                val2 = Convert.ToDouble(PS.ElementAt(2));
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case "Agilent4285A": PS.AddMeasStringAgilent4980(s); break;
                case "Agilent4263B":
                    {
                        PS.AddMeasStringAgilent4263(s);
                        val1 = Convert.ToDouble(PS.ElementAt(1));
                        val2 = Convert.ToDouble(PS.DeleteZero(PS.ElementAt(2)));
                        break;
                    }
                case "Agilent34401A": PS.AddMeasStringAgilent4980(s); break;
                case "WayneKerr6500B": PS.AddMeasStringWayneKerr6500B(s); break;
                case "WayneKerr4300":
                    {
                        //+8.2556835e-13,-1.6205449e+00
                        PS.AddMeasStringWayneKerr4300(s);
                        val1 = Convert.ToDouble(PS.ElementAt(0));
                        val2 = Convert.ToDouble(PS.ElementAt(1));
                        break;
                    }
                default:
                    PS.AddMeasStringAgilent4980(s);
                    break;
            }

            if (txtHBias.Text == "")
            {
                txtHBias.Text = "0";
            }
            if (txtUbias.Text == "")
            {
                txtUbias.Text = "0";
            }

            if (frmMOpt.cbExportDBMeasTemp.Text == "Export to DB(only)")
            {
                string dateformat = "hh:mm:ss.fff";
                DateTime dateT = new DateTime();
                dateT = DateTime.Now;
                dateT.AddMilliseconds(1);
                dGridTempMeas["id", 0].Value = PP.CelSel.ToString();
                dGridTempMeas["composition", 0].Value = frmMOpt.txtComposition.Text;
                dGridTempMeas["id_sample", 0].Value = frmMOpt.txtSampleNumber.Text;
                dGridTempMeas["Tsint_K", 0].Value = frmMOpt.txtTempSint.Text;
                dGridTempMeas["composition", 0].Value = frmMOpt.txtHeight.Text;
                t = Convert.ToDouble(frmMOpt.txtHeight.Text);
                dGridTempMeas["d_cm", 0].Value = frmMOpt.txtDiameter.Text;
                d = Convert.ToDouble(frmMOpt.txtDiameter.Text);
                dGridTempMeas["T_K", 0].Value = lbTemp.Text;
                dGridTempMeas["f_Hz", 0].Value = freq;
                dGridTempMeas["C_pF", 0].Value = (Convert.ToDouble(val1) * 1e12).ToString();
                e_e0 = PM.e_re(t, d, Convert.ToDouble(dGridTempMeas["C_pF", 0].Value));
                dGridTempMeas["e_re", 0].Value = e_e0.ToString();
                dGridTempMeas["tgd", 0].Value = val2;
                tgper = Convert.ToDouble(dGridTempMeas["tgd", 0].Value);
                dGridTempMeas["tgd1e2", 0].Value = PM.tgdE2(tgper).ToString();
                e_e2 = PM.e_im(e_e0, Convert.ToDouble(dGridTempMeas["tgd", 0].Value));
                dGridTempMeas["e_im", 0].Value = e_e2.ToString();
                Y = e_e2 * Convert.ToInt32(freq) * 2 * 3.14;
                dGridTempMeas["Y", 0].Value = Y.ToString();
                //dGridTempMeas["Direct", 0].Value = lbDirect.Text;

                PP.BiasUCurrent = GetUFromVoltmeter();

                //PP.BiasUCurrent = 0.0825 * (PP.BiasUCurrent) + 0.1728;


                if (chPolarity.Checked == true)
                {
                    PP.Polarity = PP.PolarityPositive;
                }
                if (chPolarity.Checked == false)
                {
                    PP.Polarity = PP.PolarityNegative;
                }


                if (PP.Polarity == PP.PolarityPositive)
                {
                    if (PP.BiasUCurrent != 0)
                    {
                        dGridTempMeas["Ubias_V", 0].Value = Convert.ToDouble(frmMOpt.txtApproxA) * PP.BiasUCurrent + Convert.ToDouble(frmMOpt.txtApproxB);
                    }
                    else { dGridTempMeas["Ubias_V", 0].Value = 0; }
                }
                if (PP.Polarity == PP.PolarityNegative)
                {
                    if (PP.BiasUCurrent != 0)
                    {
                        dGridTempMeas["Ubias_V", 0].Value = (21.13 * PP.BiasUCurrent - 3.9299) * (-1);
                    }
                    else { dGridTempMeas["Ubias_V", 0].Value = 0; }
                }

                dGridTempMeas["Hbias_T", 0].Value = txtHBias.Text;
                dGridTempMeas["Cycle", 0].Value = PP.cycleCurrentNum.ToString();
                dGridTempMeas["Date", 0].Value = DateTime.Now.ToShortDateString();
                dGridTempMeas["Time", 0].Value = dateT.ToString(dateformat);
                dGridTempMeas["Step", 0].Value = PP.CurrentStep;
                dGridTempMeas["Direction", 0].Value = PP.Direction;
                dGridTempMeas["Polarity", 0].Value = PP.Polarity;
                dGridTempMeas["operator", 0].Value = frmMOpt.cmbOperator.Text;
                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;


                dGridTempMeas["Timer", 0].Value = (PP.TimeMeas).ToString();
                dGridTempMeas["Meas_type", 0].Value = frmMOpt.cWorkMode.Text;
                txtUbias.Text = dGridTempMeas["Ubias_V", 0].Value.ToString();

                if (frmMOpt.cWorkMode.Text == "C(dU)_auto_reversive")
                {
                    dGridTempMeas["Step", 0].Value = PP.CurrentStep.ToString();
                    dGridTempMeas["Direction", 0].Value = PP.Direction.ToString();
                    dGridTempMeas["Polarity", 0].Value = PP.Polarity.ToString();
                }

                switch (frmMOpt.cWorkMode.Text)
                {
                    default:
                        {
                            for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
                            {
                                if (chartMeasTemp1.Series[u].Name.ToString() == (dGridTempMeas["f_Hz", 0].Value + "\r").ToString() ||
                                    chartMeasTemp1.Series[u].Name.ToString() == dGridTempMeas["f_Hz", 0].Value.ToString())
                                {
                                    double num0;
                                    bool isNum0 = double.TryParse(dGridTempMeas["e_re", 0].Value.ToString(), out num0);
                                    double num1;
                                    bool isNum1 = double.TryParse(dGridTempMeas["e_im", 0].Value.ToString(), out num1);

                                    if (Convert.ToDouble(dGridTempMeas["e_re", 0].Value) < 1e40 &&
                                        Convert.ToDouble(dGridTempMeas["e_re", 0].Value) > -1e10 &&
                                        Convert.ToDouble(dGridTempMeas["e_im", 0].Value) < 1e40 &&
                                        Convert.ToDouble(dGridTempMeas["e_im", 0].Value) > -1e40 &&
                                        isNum0 == true && isNum1 == true)
                                    {
                                        switch (frmMOpt.cbGraphOptions.Text)
                                        {
                                            case "e(T)":
                                                {
                                                    chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["T_K", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
                                                    chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["T_K", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));
                                                    break;
                                                }
                                            case "e(E)":
                                                {
                                                    chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
                                                    chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));
                                                    break;
                                                }
                                            case "e(f)":
                                                {
                                                    chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["f_Hz", 0].Value), Convert.ToDouble(dGridTempMeas["e_re", 0].Value));
                                                    chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(dGridTempMeas["f_Hz", 0].Value), Convert.ToDouble(dGridTempMeas["e_im", 0].Value));

                                                    break;
                                                }
                                            default:
                                                {
                                                    break;
                                                }

                                        }
                                    }

                                }
                            }
                            break;
                        }
                }
                DBConn dBConn = new DBConn();
                string sql = dBConn.DBExportDataString(this.dGridTempMeas, PP.DBTableName, 0);
                FileJob FJ = new FileJob();
                FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
            }
            this.Refresh();
        }
        /// <summary>
        /// Gets the data from voltage meter hy a V51 t.
        /// </summary>
        /// <returns></returns>
        public double GetDataFromVoltageMeter_HY_AV51_T()
        {
            short[] values = new short[40];
            values = Com.GetDataFromVoltageMeter_HY_AV51_T1();
            //short[] valueArray = new short[2];
            int[] valueConv = new int[2];

            valueConv[0] = values[37];
            valueConv[1] = values[35];


            double val_out = 0;
            switch (valueConv[1])
            {
                case 257:
                    {
                        val_out = valueConv[0] * 0.001;
                        break;
                    }
                case 513:
                    {
                        val_out = valueConv[0] * 0.01;
                        break;
                    }
                case 769:
                    {
                        val_out = valueConv[0] * 0.1;
                        break;
                    }
                case 1025:
                    {
                        val_out = valueConv[0] * 1;
                        break;
                    }
                default:
                    break;
            }
            //if (val_out == 0)
            //{
            //    PP.BiasUCurrent = 0;
            //}
            //if (val_out != 0)
            //{
            //    PP.BiasUCurrent = 23.81 * val_out - 16.464;
            //}
            return val_out;
        }
        /// <summary>
        /// Works the mode d33rev automatic.
        /// </summary>
        public void WorkModeD33rev_auto()
        {
            ParseStringTab PS = new ParseStringTab();
            string s = "";
            //Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9]{1}");

            #region  Get_data_from_micron
            do
            {
                Com.SendDataToComPort("ArduinoUno", "m");
                s = Com.ComReadString();
            } while (s.Length < 7);
            PS.AddUMicron(s);
            #endregion

            #region Get_data_from_voltage_meter_E=U/t
            GetDataFromVoltageMeter_HY_AV51_T();
            #endregion


            MeasD33Rev(Convert.ToDouble(PS.ElementAt(0)), 0);

            if (PP.CurrentTime >= PP.TimeMeas && PP.CurrentTimeStep >= PP.ListTimer.Length - 1)
            {
                TimeCurrentMeas.Enabled = false;
                return;
            }

            if (PP.TimeMeas >= Convert.ToDouble(PP.ListTimer[PP.CurrentTimeStep]) && PP.CurrentTimeStep < PP.ListTimer.Length - 1)
            {
                Stopwatch myStopwatch = new Stopwatch();
                myStopwatch.Start();
                ++PP.CurrentTimeStep;
                PP.CurrentTime = Convert.ToDouble(PP.ListTimer[PP.CurrentTimeStep]);


                if (Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]) > Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep - 1]))
                {
                    Com.SendDataToComPort("ArduinoUno", "+");

                }
                if (Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]) < Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep - 1]))
                {
                    Com.SendDataToComPort("ArduinoUno", "-");
                }


                //frmGPIB.WriteCommandDev(PP.BiasAgilent4980 + PP.ListVoltage[PP.CurrentTimeStep]);
                //PP.BiasUCurrent = Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]);
                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;

            }
            Thread.Sleep(100);
            PP.TimeMeas += 0.100;
        }
        /// <summary>
        /// Works the mode d33rev.
        /// </summary>
        public void WorkModeD33rev()
        {
            ParseStringTab PS = new ParseStringTab();
            #region Get_data_from_micron
            /*
            string s = "";
            do
            {
                Com.SendDataToComPort("ArduinoUno", "m");
                s = Com.ComReadString();
            } while (s.Length < 7);
            PS.AddUMicron(s);
            */
            frmGPIB.WriteCommandDev("init;fetch?");
            frmGPIB.ReadDeviceAnswer();
            #endregion

            //bool Ubias = false;
            //for (int i = 0; i < Com.allComPort.Count(); i++)
            //{
            //    if (Com.allComPort[i].DeviceName == "VoltageMeter HY-AV51-T")
            //    {
            //        GetDataFromVoltageMeter_HY_AV51_T();
            //        Ubias = true;
            //    }
            //}

            //if (Ubias == false)
            //{
            //    PP.BiasUCurrent = Convert.ToDouble(txtUbias.Text);
            //}

            GetUFromVoltmeter();

            //MeasD33Rev(Convert.ToDouble(PS.ElementAt(0)), 0);
            MeasD33Rev(Convert.ToDouble(PP.BiasUCurrent), 0);

            //if (PP.CurrentTime >= PP.TimeMeas && PP.CurrentTimeStep >= PP.ListTimer.Length - 1)
            //{
            //    TimeCurrentMeas.Enabled = false;
            //    return;
            //}

            //if (PP.TimeMeas >= Convert.ToDouble(PP.ListTimer[PP.CurrentTimeStep]) && PP.CurrentTimeStep < PP.ListTimer.Length - 1)
            //{
            //    Stopwatch myStopwatch = new Stopwatch();
            //    myStopwatch.Start();
            //    ++PP.CurrentTimeStep;
            //    PP.CurrentTime = Convert.ToDouble(PP.ListTimer[PP.CurrentTimeStep]);


            //    if (Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]) > Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep - 1]))
            //    {
            //        Com.SendDataToComPort("ArduinoUno", "+");

            //    }
            //    if (Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]) < Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep - 1]))
            //    {
            //        Com.SendDataToComPort("ArduinoUno", "-");
            //    }


            //    //frmGPIB.WriteCommandDev(PP.BiasAgilent4980 + PP.ListVoltage[PP.CurrentTimeStep]);
            //    //PP.BiasUCurrent = Convert.ToDouble(PP.ListVoltage[PP.CurrentTimeStep]);
            //    myStopwatch.Stop();
            //    PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;

            //}
            Thread.Sleep(100);
            PP.TimeMeas += 0.100;
        }

        /// <summary>
        /// Main void for measurments the piezo parameters at different temperatures.
        /// </summary>
        public void MeasTempPiezo()
        {
            PiezoMathCalculation PMC = new PiezoMathCalculation();
            int range = Convert.ToInt32(txtPointCount.Text);
            double[] freq_range = new double[range];
            double[] Ymeas = new double[range];
            double[] Rmeas = new double[range];

            string CMDBias = txtUbias.Text;
            string CMD = "";
            int start = Convert.ToInt32(txtStartFreq.Text);
            int end = Convert.ToInt32(txtEndFreq.Text);

            freq_range = PMC.FindFreqs(start, end, range);

            for (int i = 0; i < freq_range.Length; i++)
            {
                CMD = freq_range[i].ToString();

                frmGPIB.WriteCommandDev(PP.FreqAgilent4980 + CMD);
                frmGPIB.WriteCommandDev(PP.TrigAgilent4980);
                frmGPIB.WriteCommandDev(PP.FetchGPIBDevices);
                frmGPIB.ReadDeviceAnswer();
                string s = frmGPIB.answer;
                ParseStringTab PS = new ParseStringTab();
                PS.AddMeasStringAgilent4980(s);
                Ymeas[i] = (double)s.ElementAt(0);
                Rmeas[i] = (double)s.ElementAt(1);
                dGridPiezo["Y", PP.CelSelPiezo].Value = Ymeas[i];
                dGridPiezo["R", PP.CelSelPiezo].Value = Rmeas[i];
            }
            FindResonances(freq_range, Ymeas, Rmeas);
        }
        /// <summary>
        /// Finds the resonances.
        /// </summary>
        /// <param name="freqs">array of frequnces</param>
        /// <param name="Y">array of Y</param>
        /// <param name="R">array of R</param>
        private void FindResonances(double[] freqs, double[] Y, double[] R)
        {
            alglib.spline1dinterpolant Yval;
            alglib.spline1dinterpolant Rval;
            alglib.spline1dfitreport repY;
            alglib.spline1dfitreport repR;

            double[] Yi = new double[Y.Length];
            double[] Ri = new double[R.Length];
            PP.RHO = Convert.ToDouble(frmMOpt.txtRHO.Text);
            PP.CBF = Convert.ToInt32(frmMOpt.txtCBF.Text);

            int infoY;
            int infoR;

            double maxY;
#pragma warning disable CS0168 // Переменная "maxR" объявлена, но ни разу не использована.
            double maxR;
#pragma warning restore CS0168 // Переменная "maxR" объявлена, но ни разу не использована.
            double minY;
#pragma warning disable CS0168 // Переменная "minR" объявлена, но ни разу не использована.
            double minR;
#pragma warning restore CS0168 // Переменная "minR" объявлена, но ни разу не использована.
#pragma warning disable CS0168 // Переменная "maxFreq" объявлена, но ни разу не использована.
            double maxFreq;
#pragma warning restore CS0168 // Переменная "maxFreq" объявлена, но ни разу не использована.
#pragma warning disable CS0168 // Переменная "minFreq" объявлена, но ни разу не использована.
            double minFreq;
#pragma warning restore CS0168 // Переменная "minFreq" объявлена, но ни разу не использована.

            alglib.spline1dfitpenalized(freqs, Y, PP.CBF, PP.RHO, out infoY, out Yval, out repY);
            alglib.spline1dfitpenalized(freqs, R, PP.CBF, PP.RHO, out infoR, out Rval, out repR);
            //v = alglib.spline1dcalc(Yval_mas, 0.0);
            chartTreatment.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chartTreatment.Series[0].Color = Color.Green;

            for (int i = 0; i < freqs.Length; i++)
            {
                Yi[i] = alglib.spline1dcalc(Yval, (double)freqs[i]);
                Ri[i] = alglib.spline1dcalc(Rval, (double)freqs[i]);
            }
            PiezoMathCalculation PMC = new PiezoMathCalculation();
            maxY = PMC.MaxValFromArray(Yi);
            PP.fr1 = (Int32)PMC.MaxNumFromArray(Yi);
            minY = PMC.MinValFromArray(Yi);
            PP.fa1 = (Int32)PMC.MinNumFromArray(Yi);
        }
        /// <summary>
        /// End cycling the agilent4980.
        /// </summary>
        public void endcycleAgilent4980()
        {
            if (PP.cycleCurrentNum > PP.cycleCount)
            {
                AutoSaveMeas(PP.FileNameSaveTempMeas);
                btnStart.Text = "Stop";
                timerMeas.Enabled = false;
                lbDirect.Text = "Meusuring is done";
            }
        }
        /// <summary>
        /// Main measuring under bias u.
        /// </summary>
        public void MainMeasuringUnderBiasU()
        {
            //C(dU)_man
            //C(dU)_auto
            //C(dU_df)
            //C(U)_relaxation
            //C(dU_df_dT)
            //C(dU_dT)

            switch (frmMOpt.cWorkMode.Text)
            {
                case "C(dU)_man":
                    {
                        frmGPIB.WriteCommandeSync(PP.BiasAgilent4980 + PP.BiasUCurrent.ToString());
                        SendCommandMeasAtUbias();
                        MeasTemp(PP.MeasuringFrequency.ToString(), PP.CelSel);
                        ++PP.CelSel;
                        this.Refresh();
                        break;
                    }
                case "C(dU)_auto":
                    {
                        for (int j = 0; j < frmMOpt.tVoltageList.Lines.Count() - 1; j++)
                        {
                            PP.BiasUCurrent = Convert.ToDouble(frmMOpt.tVoltageList.Lines[j]);
                            this.txtUbias.Text = PP.BiasUCurrent.ToString();
                            this.txtCurFreq.Text = PP.MeasuringFrequency.ToString();
                            SendCommandMeasAtUbias();
                            MeasTemp(PP.MeasuringFrequency.ToString(), PP.CelSel);
                            ++PP.CelSel;
                            this.Refresh();
                        }
                        this.Refresh();
                        break;
                    }
                case "C(dU_df)":
                    {
                        for (int i = 0; i < frmMOpt.tFreqList.Lines.Count() - 1; i++)
                        {
                            PP.MeasuringFrequency = Convert.ToInt32(frmMOpt.tFreqList.Lines[i]);
                            for (int j = 0; j < frmMOpt.tVoltageList.Lines.Count() - 1; j++)
                            {
                                PP.BiasUCurrent = Convert.ToDouble(frmMOpt.tVoltageList.Lines[j]);
                                this.txtUbias.Text = PP.BiasUCurrent.ToString();
                                this.txtCurFreq.Text = PP.MeasuringFrequency.ToString();
                                SendCommandMeasAtUbias();
                                MeasTemp(PP.MeasuringFrequency.ToString(), PP.CelSel);
                                ++PP.CelSel;
                                this.Refresh();
                            }
                        }
                        this.Refresh();
                        break;
                    }
                case "C(dU_df_dT)":
                    {
                        for (int i = 0; i < frmMOpt.tFreqList.Lines.Count() - 1; i++)
                        {
                            PP.MeasuringFrequency = Convert.ToInt32(frmMOpt.tFreqList.Lines[i]);
                            for (int j = 0; j < frmMOpt.tVoltageList.Lines.Count() - 1; j++)
                            {
                                PP.BiasUCurrent = Convert.ToDouble(frmMOpt.tVoltageList.Lines[j]);
                                this.txtUbias.Text = PP.BiasUCurrent.ToString();
                                this.txtCurFreq.Text = PP.MeasuringFrequency.ToString();
                                SendCommandMeasAtUbias();
                                MeasTemp(PP.MeasuringFrequency.ToString(), PP.CelSel);
                                ++PP.CelSel;
                                this.Refresh();
                            }
                        }
                        this.Refresh();
                        break;
                    }
                case "C(dU_dT)":
                    {
                        PP.MeasuringFrequency = Convert.ToInt32(frmMOpt.tFreqList.Lines[0]);
                        for (int j = 0; j < frmMOpt.tVoltageList.Lines.Count() - 1; j++)
                        {
                            PP.BiasUCurrent = Convert.ToDouble(frmMOpt.tVoltageList.Lines[j]);
                            this.txtUbias.Text = PP.BiasUCurrent.ToString();
                            this.txtCurFreq.Text = PP.MeasuringFrequency.ToString();
                            SendCommandMeasAtUbias();
                            MeasTemp(PP.MeasuringFrequency.ToString(), PP.CelSel);
                            ++PP.CelSel;
                            this.Refresh();
                        }
                        this.Refresh();
                        break;
                    }
                case "C(dU)_relaxation":
                    {
                        SendCommandMeasAtUbias();
                        MeasTemp(PP.MeasuringFrequency.ToString(), PP.CelSel);
                        ++PP.CelSel;
                        this.Refresh();
                        break;
                    }
                default:
                    break;
            }
            this.Refresh();
        }
        /// <summary>
        /// Send Command to Meas at Ubias
        /// </summary>
        void SendCommandMeasAtUbias_1()
        {
            if (frmMOpt.cbGPIBDevModel.Text == "Agilent4980A")
            {
                frmGPIB.WriteCommandeSync(PP.FreqAgilent4980 + PP.MeasuringFrequency.ToString());
                frmGPIB.WriteCommandeSync(PP.TrigAgilent4980);
                frmGPIB.WriteCommandeSync(PP.FetchGPIBDevices);
                frmGPIB.ReadDeviceAnswer();
            }

            if (frmMOpt.cbGPIBDevModel.Text == "WayneKerr6500B")
            {
                frmGPIB.WriteCommandeSync(PP.FreqWayneKerr6500B + PP.MeasuringFrequency.ToString());
                frmGPIB.WriteCommandeSync(PP.TrigWayneKerr6500B);
                frmGPIB.WriteCommandeSync(PP.FetchGPIBDevices);
                frmGPIB.ReadDeviceAnswer();
            }
        }
        /// <summary>
        /// Send Command to Meas at Ubias
        /// </summary>
        void SendCommandMeasAtUbias()
        {
            switch (frmMOpt.cbGPIBDevModel.Text)
            {
                case "Agilent4980A":
                    {
                        frmGPIB.WriteCommandeSync(PP.FreqAgilent4980 + PP.MeasuringFrequency.ToString());
                        frmGPIB.WriteCommandeSync(PP.BiasAgilent4980 + PP.BiasUCurrent.ToString());
                        frmGPIB.WriteCommandeSync(PP.TrigAgilent4980);
                        frmGPIB.WriteCommandeSync(PP.FetchGPIBDevices);
                        frmGPIB.ReadDeviceAnswer();
                        break;
                    }
                case "WayneKerr6500B":
                    {
                        frmGPIB.WriteCommandeSync(PP.FreqWayneKerr6500B + PP.MeasuringFrequency.ToString());
                        frmGPIB.WriteCommandeSync(PP.BiasWayneKerr6500B + PP.BiasUCurrent.ToString());
                        frmGPIB.WriteCommandeSync(PP.TrigWayneKerr6500B);
                        frmGPIB.WriteCommandeSync(PP.FetchGPIBDevices);
                        frmGPIB.ReadDeviceAnswer();
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// Initialiezes the freq.
        /// </summary>
        /// <param name="i">The i.</param>
        void InitialiezeFreq(int i)
        {
            switch (frmMOpt.cbGPIBDevModel.Text)
            {
                case "Agilent4980A":
                    {
                        frmGPIB.WriteCommandDev(PP.FreqAgilent4980 + PP.ListFreq[i]);
                        frmGPIB.WriteCommandDev(PP.TrigAgilent4980);
                        break;
                    }
                case "Agilent4285A":
                    {
                        //System.Threading.Thread.Sleep(100);
                        frmGPIB.WriteCommandDev(PP.FreqAgilent4285 + PP.ListFreq[i]+";");
                        //frmGPIB.WriteCommandeSync(PP.TrigAgilent4285);
                        break;
                    }
                case "Agilent4263B":
                    {
                        frmGPIB.WriteCommandDev(PP.FreqAgilent4263 + PP.ListFreq[i] + ";" + PP.TrigFetchAgilent4263);
                        frmGPIB.ReadDeviceAnswer();
                        break;
                    }
                case "Agilent34401A":
                    {
                        break;
                    }
                case "WayneKerr6500B":
                    {
                        frmGPIB.WriteCommandDev(PP.FreqWayneKerr6500B + PP.ListFreq[i]);
                        frmGPIB.WriteCommandDev(PP.TrigWayneKerr6500B);
                        break;
                    }
                case "WayneKerr4300":
                    {
                        frmGPIB.WriteCommandDev(PP.FreqWayneKerr4300 + PP.ListFreq[i]);
                        frmGPIB.WriteCommandDev(PP.TrigWayneKerr4300);
                        frmGPIB.ReadDeviceAnswer();
                        break;
                    }
                case "E7-20":
                    {
                        byte[] data = new byte[2];
                        PiezoMathCalculation pm = new PiezoMathCalculation();
                        do
                        {
                            PP.bufE7_20 = Com.GetDataFromCOMDevice("E7-20", 0, 22);
                        } while (PP.bufE7_20[4] == 0);

                        PP.frequencyE7_20 = (int)pm.BytesToDouble(PP.bufE7_20, 4, 2);
                        PP.frequencyE7_20 = PP.frequencyE7_20 * (int)Math.Pow(10, pm.BytesToDouble(PP.bufE7_20, 6, 1));

                        if (PP.frequencyE7_20.ToString() != PP.ListFreq[i])
                        {
                            do
                            {
                                data[0] = 0x1;
                                Com.SendDataToComPort("E7-20", data);
                                System.Threading.Thread.Sleep(300);
                                do
                                {
                                    PP.bufE7_20 = Com.GetDataFromCOMDevice("E7-20", 0, 22);
                                } while (PP.bufE7_20[4] == 0);
                                PP.frequencyE7_20 = (int)pm.BytesToDouble(PP.bufE7_20, 4, 2);
                                PP.frequencyE7_20 = PP.frequencyE7_20 * (int)Math.Pow(10, pm.BytesToDouble(PP.bufE7_20, 6, 1));
                            } while (PP.frequencyE7_20.ToString() != PP.ListFreq[i]);
                        }





                        break;
                    }
                default:
                    break;
            }
            txtCurFreq.Text = PP.ListFreq[i];
        }
        /// <summary>
        /// Initialiezes the trig.
        /// </summary>
        void InitialiezeTrig()
        {
            switch (frmMOpt.cbGPIBDevModel.Text)
            {
                case "Agilent4980A":
                    {

                        frmGPIB.WriteCommandDev(PP.TrigAgilent4980);
                        break;
                    }
                case "Agilent4285A":
                    {
                        frmGPIB.WriteCommandDev(PP.TrigAgilent4285+PP.FetchAgilent4285);
                        frmGPIB.ReadDeviceAnswer();
                        break;
                    }
                case "Agilent4263B":
                    {
                        frmGPIB.WriteCommandDev(PP.TrigFetchAgilent4263);
                        frmGPIB.ReadGPIBAnswer();
                        break;
                    }
                case "Agilent34401A":
                    {
                        break;
                    }
                case "WayneKerr6500B":
                    {

                        frmGPIB.WriteCommandDev(PP.TrigWayneKerr6500B);
                        break;
                    }
                case "WayneKerr4300":
                    {

                        string s = "O\\R,O\\R\n";
                        for (int i = 0; i < 7; i++)
                        {
                            frmGPIB.WriteCommandDev(PP.TrigWayneKerr4300);
                            frmGPIB.ReadDeviceAnswer();
                            if (s != frmGPIB.answer)
                            {
                                break;
                            }
                        }
                        if (s == frmGPIB.answer)
                        {
                            frmGPIB.answer = "+0.0000000e-00,+0.0000000e+00\n";
                        }
                        break;
                    }
                default:
                    break;
            }
        }



        /// <summary>
        /// Mains the meas.
        /// </summary>
        public void MainMeas()
        {
            Stopwatch myStopwatch = new Stopwatch();
            myStopwatch.Start();
            getTempFromTermocontroller();
            //GetTempFromVarta();
            WriteTempToFile();
            PiezoMathCalculation PM = new PiezoMathCalculation();
            //измерение и получение данных с прибора
            for (int i = 0; i < PP.ListFreq.Length; i++)
            {
                InitialiezeFreq(i);
                InitialiezeTrig();

                switch (frmMOpt.cbGPIBDevModel.Text)
                {
                    case "Agilent4980A":
                        Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9]{1}");
                        Regex reg1 = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{1}");
                        switch (frmGPIB.cbInterfaceType.Text)
                        {
                            case "ETHERNET":
                                frmGPIB.WriteCommandDev(PP.FetchGPIBDevices);
                                string s1 = "";
                                string[] rr;
                                bool match = false;
                                do
                                {
                                    char splitchar = (char)'\n';
                                    string[] sss = frmGPIB.answer.Split(splitchar);
                                    if (sss.Count() > 1)
                                    {
                                        s1 = sss[2];
                                        s1 = s1.Substring(12, 28);
                                        string ff = s1;
                                        rr = sss[2].Split('\0');
                                        rr = rr[0].Split((char)3);
                                        if (reg.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                        if (reg1.IsMatch(rr[1]) == true)
                                        {
                                            match = true;
                                            frmGPIB.answer = rr[1];
                                        }
                                    }
                                } while (match == false);
                                break;
                            case "GPIB":
                                frmGPIB.WriteCommandDev(PM.ReplaceCommonEscapeSequences(PP.FetchAgilent4980));
                                frmGPIB.ReadDeviceAnswer();
                                break;
                            case "USB":
                                {
                                    frmGPIB.ReadDeviceAnswer(PP.FetchAgilent4980);
                                    break;
                                }

                            default:
                                break;
                        }
                        break;
                    case "E7-20":
                        {
                            PiezoMathCalculation pm = new PiezoMathCalculation();
                            do
                            {
                                System.Threading.Thread.Sleep(500);
                                PP.bufE7_20 = Com.GetDataFromCOMDevice("E7-20", 0, 22);
                                if (PP.bufE7_20[14] != 0)
                                {
                                    PP.bufE7_20[12] = (byte)(PP.bufE7_20[12] ^ 0xff);
                                    PP.bufE7_20[13] = (byte)(PP.bufE7_20[13] ^ 0xff);
                                    PP.bufE7_20[14] = (byte)(PP.bufE7_20[14] ^ 0xff);
                                    PP.param2_E7_20 = (-1 - PP.bufE7_20[12] - (PP.bufE7_20[13] + PP.bufE7_20[14] * 256) * 256) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[15])), -1);
                                }
                                else PP.param2_E7_20 = pm.BytesToDouble(PP.bufE7_20, 12, 3) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[15])), -1);
                                if (PP.bufE7_20[18] != 0)
                                {
                                    PP.bufE7_20[16] = (byte)(PP.bufE7_20[16] ^ 0xff);
                                    PP.bufE7_20[17] = (byte)(PP.bufE7_20[17] ^ 0xff);
                                    PP.bufE7_20[18] = (byte)(PP.bufE7_20[18] ^ 0xff);
                                    PP.param1_E7_20 = (-1 - PP.bufE7_20[16] - (PP.bufE7_20[17] + PP.bufE7_20[18] * 256) * 256) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[19])), -1);

                                }
                                else PP.param1_E7_20 = pm.BytesToDouble(PP.bufE7_20, 16, 3) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[19])), -1);
                                //if (m1 == false) PP.param1_E7_20 = pm.BytesToDouble(PP.bufE7_20, 16, 3) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[19])), -1);
                                //if (m2 == false) PP.param2_E7_20 = pm.BytesToDouble(PP.bufE7_20, 12, 3) * Math.Pow(Math.Pow(10, 256 - (int)(PP.bufE7_20[15])), -1);
                            } while (PP.bufE7_20[3] == 0 || PP.param1_E7_20 > 1e25);

                            break;
                        }
                    default:
                        break;
                }

                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * 0.001) + PP.AvarageIncTime;
                MeasTemp(PP.ListFreq[i], PP.CelSel);
                ++PP.CelSel;
                this.Refresh();
            }
            //-------------------------------------------------------------
            InitialiezeFreq(0);
            this.Refresh();
        }
        /// <summary>
        /// Automatics the save meas.
        /// </summary>
        /// <param name="file">The file.</param>
        public void AutoSaveMeas(string file)
        {
            FileJob fj = new FileJob();
            fj.WriteStrToFileFromDataGrid(dGridTempMeas, file, PP.CelSel);
        }

        private void MeasD33RevHand(double Uin, int i)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            double timeCoef = 0.001;
            string s = frmGPIB.answer;
            double t;
            double d;
            //double val1 = 0;
            //double val2 = 0;
            PiezoMathCalculation PM = new PiezoMathCalculation();
            ParseStringTab PS = new ParseStringTab();

            if (frmMOpt.cbExportDBMeasTemp.Text == "Export to DB(only)")
            {
                string dateformat = "hh:mm:ss.fff";
                DateTime dateT = new DateTime();
                dateT = DateTime.Now;
                dateT.AddMilliseconds(1);

                dGridTempMeas["id", 0].Value = PP.CelSel.ToString();
                dGridTempMeas["composition", 0].Value = frmMOpt.txtComposition.Text;
                dGridTempMeas["id_sample", 0].Value = frmMOpt.txtSampleNumber.Text;
                dGridTempMeas["Tsint_K", 0].Value = frmMOpt.txtTempSint.Text;
                dGridTempMeas["composition", 0].Value = frmMOpt.txtHeight.Text;
                t = Convert.ToDouble(frmMOpt.txtHeight.Text);
                dGridTempMeas["d_cm", 0].Value = frmMOpt.txtDiameter.Text;
                d = Convert.ToDouble(frmMOpt.txtDiameter.Text);
                dGridTempMeas["T_K", 0].Value = lbTemp.Text;
                //dGridTempMeas["Direct", 0].Value = lbDirect.Text;
                dGridTempMeas["Ubias_V", 0].Value = PP.BiasUCurrent;
                dGridTempMeas["Hbias_T", 0].Value = txtHBias.Text;
                dGridTempMeas["Cycle", 0].Value = PP.cycleCurrentNum.ToString();
                dGridTempMeas["Date", 0].Value = DateTime.Now.ToShortDateString();
                dGridTempMeas["Time", 0].Value = dateT.ToString(dateformat);
                dGridTempMeas["operator", 0].Value = frmMOpt.cmbOperator.Text;
                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;

                dGridTempMeas["Timer", 0].Value = (PP.TimeMeas).ToString();
                dGridTempMeas["Meas_type", 0].Value = frmMOpt.cWorkMode.Text;



                if (PP.BiasUCurrent == 0)
                {
                    dGridTempMeas["Xi", 0].Value = 0;
                    dGridTempMeas["Uout_V", 0].Value = 0;
                    dGridTempMeas["E_kV_Div_cm", 0].Value = 0;
                    dGridTempMeas["k_10_E_4", 0].Value = 0;
                    dGridTempMeas["d33rev_m_V", 0].Value = 0;
                    dGridTempMeas["d33rev", 0].Value = 0;
                }
                if (PP.BiasUCurrent != 0)
                {
                    PM.SetXiMas();
                    PM.SetUMicronOutMas();
                    dGridTempMeas["Xi", 0].Value = PM.XiVal(PM.FindUmicron(Uin));
                    dGridTempMeas["Uout_V", 0].Value = Uin.ToString();
                    dGridTempMeas["E_kV_Div_cm", 0].Value = (Convert.ToDouble(PP.BiasUCurrent) / Convert.ToDouble(frmMOpt.txtHeight.Text) / 1000).ToString();
                    dGridTempMeas["k_10_E_4", 0].Value = (Convert.ToDouble(dGridTempMeas["Xi", 0].Value) / Convert.ToDouble(frmMOpt.txtHeight.Text)).ToString();
                    dGridTempMeas["d33rev_m_V", 0].Value = (Convert.ToDouble(dGridTempMeas["k_10_E_4", 0].Value) / Convert.ToDouble(dGridTempMeas["E_kV_Div_cm", 0].Value) * 1000).ToString();
                    dGridTempMeas["d33rev", 0].Value = (Convert.ToDouble(dGridTempMeas["k_10_E_4", 0].Value) * 1000 / Convert.ToDouble(dGridTempMeas["E_kV_Div_cm", 0].Value)).ToString();
                }
                ++PP.CelSel;

                //switch (frmMOpt.cWorkMode.Text)
                //{
                //    case "d33Rev":
                //        {
                //            chartMeasTemp1.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["E_kV_Div_cm", 0].Value), Convert.ToDouble(dGridTempMeas["k_10_E_4", 0].Value));
                //            chartMeasTemp2.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["E_kV_Div_cm", 0].Value), Convert.ToDouble(dGridTempMeas["d33rev", 0].Value));
                //            break;
                //        }
                //    default:
                //        {

                //            break;
                //        }
                //}
                DBConn dBConn = new DBConn();
                string sql = dBConn.DBExportDataString(this.dGridTempMeas, PP.DBTableName, 0);
                FileJob FJ = new FileJob();
                FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
            }
        }
        /// <summary>
        /// Adds the parameters value.
        /// </summary>
        public void AddParametersVal()
        {
            //string dateformat = "hh:mm:ss.fff";
            DateTime dateT = DateTime.Now;
            //new DateTime();
            //dateT = DateTime.Now;
            //DateTime dateT = new DateTime();
            //dateT = DateTime.Now;

            dGridTempMeas["id", 0].Value = PP.CelSel.ToString();
            dGridTempMeas["composition", 0].Value = frmMOpt.txtComposition.Text;
            dGridTempMeas["id_sample", 0].Value = frmMOpt.txtSampleNumber.Text;
            dGridTempMeas["Tsint_K", 0].Value = frmMOpt.txtTempSint.Text;
            dGridTempMeas["d_cm", 0].Value = frmMOpt.txtDiameter.Text;
            dGridTempMeas["h_cm", 0].Value = frmMOpt.txtHeight.Text;
            dGridTempMeas["T_K", 0].Value = PP.Temperature1;
            dGridTempMeas["Direction", 0].Value = PP.Direction;
            dGridTempMeas["Ubias_V", 0].Value = PP.BiasUCurrent;
            dGridTempMeas["Hbias_T", 0].Value = txtHBias.Text;
            dGridTempMeas["Cycle", 0].Value = PP.cycleCurrentNum.ToString();
            dGridTempMeas["Date", 0].Value = DateTime.Now.ToShortDateString();
            dGridTempMeas["Time", 0].Value = dateT.ToString("hh:mm:ss.fff");
            dGridTempMeas["operator", 0].Value = frmMOpt.cmbOperator.Text;
            dGridTempMeas["Timer", 0].Value = (PP.TimeMeas).ToString();
            dGridTempMeas["Meas_type", 0].Value = frmMOpt.cWorkMode.Text;
            dGridTempMeas["Step", 0].Value = PP.CurrentStep;
            dGridTempMeas["Polarity", 0].Value = PP.Polarity;
            dGridTempMeas["ro_exp", 0].Value = frmMOpt.txtRoExp.Text;
            dGridTempMeas["solid_state", 0].Value = frmMOpt.cmbSolidState.Text;
        }

        /// <summary>
        /// Meases the D33 rev.
        /// </summary>
        /// <param name="Uin">The uin.</param>
        /// <param name="i">The i.</param>
        private void MeasD33Rev(double Uin, int i)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            GetTempFromVarta();
            double timeCoef = 0.001;
            
            string Uin_Xi = frmGPIB.answer;
            PiezoMathCalculation PM = new PiezoMathCalculation();
            ParseStringTab PS = new ParseStringTab();
            txtUbias.Text = PP.BiasUCurrent.ToString();
            
            switch (frmMOpt.cbExportDBMeasTemp.Text)
            {
                case "Export to DB(only)":
                    {

                        AddParametersVal();
                        myStopwatch.Stop();
                        PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;

                        if (chPolarity.Checked == true)
                        {
                            dGridTempMeas["Uout_V", 0].Value = Uin.ToString();
                            dGridTempMeas["Ubias_V_conv", 0].Value = (Uin *Convert.ToDouble(frmMOpt.txtApproxU_d33_A.Text) + Convert.ToDouble(frmMOpt.txtApproxU_d33_B.Text)).ToString();
                        } 
                        if (chPolarity.Checked == false)
                        {
                            dGridTempMeas["Uout_V", 0].Value = (Uin* (-1)).ToString();
                            dGridTempMeas["Ubias_V_conv", 0].Value = ((Uin * Convert.ToDouble(frmMOpt.txtApproxU_d33_A.Text) + Convert.ToDouble(frmMOpt.txtApproxU_d33_B.Text)) *(-1)).ToString();
                        }
                        txtUbias.Text = dGridTempMeas["Ubias_V_conv", 0].Value.ToString();
                        lbField.Text = "U= " + dGridTempMeas["Ubias_V_conv", 0].Value.ToString();
                        dGridTempMeas["Uin_voltmeter", 0].Value = Uin_Xi;


                        switch (cbCTE_Limit.Text)
                        {
                            case "20":
                                {
                                    dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Convert.ToDouble(Uin_Xi), Convert.ToDouble(frmMOpt.txtApproxD33_A_20.Text), Convert.ToDouble(frmMOpt.txtApproxD33_B_20.Text)).ToString();
                                    dGridTempMeas["conv_coef", 0].Value = "20";
                                    break;
                                }
                            case "200":
                                {
                                    dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxD33_A_200.Text), Convert.ToDouble(frmMOpt.txtApproxD33_B_200.Text)).ToString();
                                    dGridTempMeas["conv_coef", 0].Value = "200";
                                    break;
                                }
                            case "2000":
                                {
                                    dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxD33_A_2000.Text), Convert.ToDouble(frmMOpt.txtApproxD33_B_2000.Text)).ToString();
                                    dGridTempMeas["conv_coef", 0].Value = "2000";
                                    break;
                                }
                            default:
                                break;
                        }




                        /*if (PP.BiasUCurrent == 0)
                        {
                            //dGridTempMeas["Xi", 0].Value = PM.XiVal_1(Uin).ToString();
                            dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxA.Text), Convert.ToDouble(frmMOpt.txtApproxB.Text)).ToString();//PM.XiVal(PM.FindUmicron(Uin));
                            // PM.XiVal(PM.FindUmicron(Uin));
                            dGridTempMeas["Uout_V", 0].Value = Uin.ToString();
                            dGridTempMeas["E_kV_Div_cm", 0].Value = (Convert.ToDouble(dGridTempMeas["Xi", 0].Value) / Convert.ToDouble(frmMOpt.txtHeight.Text)).ToString(); ;

                            PP.Xi0.Add(Convert.ToDouble(dGridTempMeas["Xi", 0].Value));

                            double ave = 0;
                            for (int j = 0; j < PP.Xi0.Count(); j++)
                            {
                                ave += PP.Xi0[j];
                            }
                            dGridTempMeas["Ubias_V_conv", 0].Value = 0;
                            dGridTempMeas["Xi0", 0].Value = ave / PP.Xi0.Count();
                            dGridTempMeas["Xi-Xi0", 0].Value = Convert.ToDouble(dGridTempMeas["Xi", 0].Value) - Convert.ToDouble(dGridTempMeas["Xi0", 0].Value);
                            dGridTempMeas["Uout_V", 0].Value = Uin.ToString();
                            dGridTempMeas["E_kV_Div_cm", 0].Value = (Convert.ToDouble(PP.BiasUCurrent) / Convert.ToDouble(frmMOpt.txtHeight.Text) / 1000).ToString();
                        }
                        if (PP.BiasUCurrent != 0)
                        {
                            PM.SetXiMas();
                            PM.SetUMicronOutMas();
                            
                            //dGridTempMeas["Xi", 0].Value = PM.XiVal_1(Uin).ToString();//PM.XiVal(PM.FindUmicron(Uin));
                            dGridTempMeas["Xi", 0].Value = PM.XiVal_Law_linear(Uin, Convert.ToDouble(frmMOpt.txtApproxA.Text), Convert.ToDouble(frmMOpt.txtApproxB.Text)).ToString();//PM.XiVal(PM.FindUmicron(Uin));
                            double ave = 0;
                            for (int j = 0; j < PP.Xi0.Count(); j++)
                            {
                                ave += PP.Xi0[j];
                            }
                            if (PP.Polarity == PP.PolarityPositive)
                            {
                                dGridTempMeas["Ubias_V_conv", 0].Value = 49.516 * Convert.ToDouble(dGridTempMeas["Ubias_V", 0].Value) - 50.798;
                            }
                            if (PP.Polarity == PP.PolarityNegative)
                            {
                                dGridTempMeas["Ubias_V_conv", 0].Value = (49.516 * Convert.ToDouble(dGridTempMeas["Ubias_V", 0].Value) - 50.798) *(-1);
                            }
                            lbField.Text = "U= " + dGridTempMeas["Ubias_V_conv", 0].Value;

                            dGridTempMeas["Xi0", 0].Value = ave / PP.Xi0.Count();
                            dGridTempMeas["Xi-Xi0", 0].Value = Convert.ToDouble(dGridTempMeas["Xi", 0].Value) - Convert.ToDouble(dGridTempMeas["Xi0", 0].Value);
                            dGridTempMeas["E_kV_Div_cm", 0].Value = (Convert.ToDouble(dGridTempMeas["Ubias_V_conv", 0].Value) / Convert.ToDouble(frmMOpt.txtHeight.Text) / 1000).ToString();
                            dGridTempMeas["k_10_E_4", 0].Value = (Convert.ToDouble(dGridTempMeas["Xi", 0].Value) / Convert.ToDouble(frmMOpt.txtHeight.Text)).ToString();
                            dGridTempMeas["d33rev", 0].Value = ((Convert.ToDouble(dGridTempMeas["k_10_E_4", 0].Value) / Convert.ToDouble(dGridTempMeas["E_kV_Div_cm", 0].Value)*1000)).ToString();
                        }
                        */

                        ++PP.CelSel;

                        switch (frmMOpt.cWorkMode.Text)
                        {
                            case "d33Rev":
                                {
                                    chartMeasTemp1.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V_conv", 0].Value), Convert.ToDouble(dGridTempMeas["Xi", 0].Value));
                                    //chartMeasTemp2.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V_conv", 0].Value), Convert.ToDouble(dGridTempMeas["d33rev", 0].Value));

                                    //if (PP.BiasUCurrent != 0)
                                    //{
                                    //    if (dGridTempMeas["k_10_E_4", 0].Value.ToString() != "")
                                    //    {
                                    //        chartMeasTemp1.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V_conv", 0].Value), Convert.ToDouble(dGridTempMeas["Xi", 0].Value));
                                    //        chartMeasTemp2.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["Ubias_V_conv", 0].Value), Convert.ToDouble(dGridTempMeas["d33rev", 0].Value));
                                    //    }
                                    //    if (dGridTempMeas["k_10_E_4", 0].Value.ToString() == "")
                                    //    {
                                    //        chartMeasTemp1.Series[0].Points.AddXY(Convert.ToDouble(dGridTempMeas["Timer", 0].Value), Convert.ToDouble(dGridTempMeas["Xi", 0].Value));
                                    //    }
                                    //}
                                    break;
                                }
                            default:
                                {

                                    break;
                                }
                        }
                        DBConn dBConn = new DBConn();
                        string sql = dBConn.DBExportDataString(this.dGridTempMeas, PP.DBTableName, 0);

                        FileJob FJ = new FileJob();
                        FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// Meases the temporary.
        /// </summary>
        /// <param name="freq">The freq.</param>
        /// <param name="i">The i.</param>
        private void MeasTemp(string freq, int i)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            getTempFromTermocontroller();
            //GetTempFromVarta();
            WriteTempToFile();
            
                if (frmMOpt.cWorkMode.Text == "Magnit_hand")
                {
                    PP.BiasUCurrent = GetUFromVoltmeter();
                    txtHBias.Text = PP.BiasUCurrent.ToString();


                    if (PP.Polarity == PP.PolarityPositive)
                    {
                        if (PP.BiasUCurrent != 0)
                        {
                            PP.BiasHCurrent = 6e-8 * Math.Pow(PP.BiasUCurrent, 3) - 4e-5 * Math.Pow(PP.BiasUCurrent, 2) + 0.0098 * PP.BiasUCurrent - 0.0312;
                            dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent;
                            txtHBias.Text = PP.BiasHCurrent.ToString();
                        }
                        else { dGridTempMeas["Hbias_T", 0].Value = 0; }
                    }
                    if (PP.Polarity == PP.PolarityNegative)
                    {
                        if (PP.BiasUCurrent != 0)
                        {
                            PP.BiasHCurrent = (6e-8 * Math.Pow(PP.BiasUCurrent, 3) - 4e-5 * Math.Pow(PP.BiasUCurrent, 2) + 0.0098 * PP.BiasUCurrent - 0.0312) * (-1);
                            dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent;
                            txtHBias.Text = PP.BiasHCurrent.ToString();
                        }
                        else { dGridTempMeas["Hbias_T", 0].Value = 0; }
                    }
                    
                }
            
            double timeCoef = 0.001;
            //string s = frmGPIB.answer;
            double e_e0;
            double tgper, Y;
            double e_e2;
            double emk;
            double t;
            double d;
            double val1 = 0;
            double val2 = 0;

            PiezoMathCalculation PM = new PiezoMathCalculation();
            ParseStringTab PS = new ParseStringTab();

            PP.BiasHCurrent = Convert.ToDouble(txtHBias.Text);
            switch (frmMOpt.cbGPIBDevModel.Text)
            {
                case "Agilent4980A":
                    {
                        PS.AddMeasStringAgilent4980(frmGPIB.answer);
                        switch (frmGPIB.cbInterfaceType.Text)
                        {
                            case "GPIB":
                                val1 = Convert.ToDouble(PS.ElementAt(0));
                                val2 = Convert.ToDouble(PS.ElementAt(1));
                                break;
                            case "ETHERNET":
                                val1 = Convert.ToDouble(PS.ElementAt(1));
                                val2 = Convert.ToDouble(PS.ElementAt(2));
                                break;
                            default:
                                val1 = Convert.ToDouble(PS.ElementAt(0));
                                val2 = Convert.ToDouble(PS.ElementAt(1));
                                break;
                        }
                        break;
                    }
                case "Agilent4285A": 
                    try
                    {
                        PS.AddMeasStringAgilent4285A(frmGPIB.answer);
                        val1 = Convert.ToDouble(PS.ElementAt(0));
                        val2 = Convert.ToDouble(PS.ElementAt(1));
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                    break;

                case "Agilent4263B":
                    {
                        PS.AddMeasStringAgilent4263(frmGPIB.answer);
                        val1 = Convert.ToDouble(PS.ElementAt(1));
                        val2 = Convert.ToDouble(PS.DeleteZero(PS.ElementAt(2)));
                        break;
                    }
                case "Agilent34401A": PS.AddMeasStringAgilent4980(frmGPIB.answer); break;
                case "WayneKerr6500B": PS.AddMeasStringWayneKerr6500B(frmGPIB.answer); break;
                case "WayneKerr4300":
                    {
                        //+8.2556835e-13,-1.6205449e+00
                        PS.AddMeasStringWayneKerr4300(frmGPIB.answer);
                        val1 = Convert.ToDouble(PS.ElementAt(0));
                        val2 = Convert.ToDouble(PS.ElementAt(1));
                        break;
                    }
                case "E7-20":
                    {
                        val2 = PP.param2_E7_20;
                        val1 = PP.param1_E7_20;
                        break;
                    }
                default:
                    PS.AddMeasStringAgilent4980(frmGPIB.answer);
                    break;
            }
            if (frmMOpt.cWorkMode.Text != "Magnit_hand")
            {
                if (txtHBias.Text == "")
                {
                    txtHBias.Text = "0";
                }
                if (txtUbias.Text == "")
                {
                    txtUbias.Text = "0";
                }
            }
            if (frmMOpt.cbExportDBMeasTemp.Text == "None")
            {
                try
                {
                    string dateformat = "hh:mm:ss.fff";
                    DateTime dateT = new DateTime();
                    dateT = DateTime.Now;
                    dateT.AddMilliseconds(1);
                    dGridTempMeas["id", PP.CelSel].Value = PP.CelSel.ToString();
                    dGridTempMeas["composition", i].Value = frmMOpt.txtComposition.Text;
                    dGridTempMeas["id_sample", i].Value = frmMOpt.txtSampleNumber.Text;
                    dGridTempMeas["Tsint_K", i].Value = frmMOpt.txtTempSint.Text;
                    dGridTempMeas["composition", i].Value = frmMOpt.txtHeight.Text;
                    t = Convert.ToDouble(frmMOpt.txtHeight.Text);
                    dGridTempMeas["d_cm", i].Value = frmMOpt.txtDiameter.Text;
                    d = Convert.ToDouble(frmMOpt.txtDiameter.Text);
                    dGridTempMeas["T_K", i].Value = lbTemp.Text;
                    dGridTempMeas["f_Hz", i].Value = freq;
                    emk = val1 * 1e12;
                    dGridTempMeas["C_pF", i].Value = emk.ToString();
                    e_e0 = PM.e_re(t, d, emk);
                    dGridTempMeas["e_re", i].Value = e_e0.ToString();
                    dGridTempMeas["tgd", i].Value = val2;
                    tgper = Convert.ToDouble(dGridTempMeas["tgd", i].Value);
                    dGridTempMeas["tgd1e2", i].Value = PM.tgdE2(tgper).ToString();
                    e_e2 = PM.e_im(e_e0, tgper);
                    dGridTempMeas["e_im", i].Value = e_e2.ToString();
                    Y = e_e2 * Convert.ToInt32(freq) * 2 * 3.14;
                    dGridTempMeas["Y", i].Value = Y.ToString();
                    //dGridTempMeas["Direct", i].Value = lbDirect.Text;
                    dGridTempMeas["Ubias_V", i].Value = txtUbias.Text;
                    dGridTempMeas["Hbias_T", i].Value = txtHBias.Text;
                    dGridTempMeas["Cycle", i].Value = PP.cycleCurrentNum.ToString();
                    dGridTempMeas["Date", i].Value = DateTime.Now.ToShortDateString();
                    dGridTempMeas["Time", i].Value = dateT.ToString(dateformat);
                    dGridTempMeas["operator", i].Value = frmMOpt.cmbOperator.Text;
                    myStopwatch.Stop();
                    PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;
                    dGridTempMeas["Timer", i].Value = (PP.TimeMeas).ToString();
                    dGridTempMeas["Polarity", i].Value = PP.Polarity;
                    dGridTempMeas["Direction", i].Value = PP.Direction;
                    dGridTempMeas["Step", i].Value = PP.CurrentStep;
                    dGridTempMeas["Meas_type", i].Value = frmMOpt.cWorkMode.Text;
                    dGridTempMeas.Rows.Add();
                    AutoSaveMeas(PP.FileNameSaveTempMeas);
                    this.Refresh();

                    for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
                    {
                        if (chartMeasTemp1.Series[u].Name == freq)
                        {
                            chartMeasTemp1.Series[u].Points.AddXY(lbTemp, e_e0);
                        }
                    }
                    chartMeasTemp2.Series[0].Points.AddXY(PP.TimeMeas, lbTemp);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            if (frmMOpt.cbExportDBMeasTemp.Text == "Export to DB parallel" && frmDBConnection.DataBaseConnected == true)
            {
                try
                {
                    NpgsqlConnection pgcon = new NpgsqlConnection(frmDBConnection.ConnectionStringToDB);
                    pgcon.Open();
                    string sql = "";
                    NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
                    string sql_data = "";
                    for (int j = 1; j < dGridTempMeas.ColumnCount + 1; j++)
                    {
                        sql_data = sql_data + dGridTempMeas.Rows[i].Cells[j].Value.ToString() + ", ";
                    }
                    sql_data = sql_data.Substring(0, sql_data.Length - 2);
                    sql = "Insert into " + frmMOpt.txtComposition + " values (" + sql_data + ");";
                    CSend.ExecuteNonQuery();
                    FileJob FJ = new FileJob();
                    FJ.WriteF(sql, PP.FileNameSaveTempMeas + ".log");
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            if (frmMOpt.cbExportDBMeasTemp.Text == "Export to DB(only)")
            {
                string dateformat = "hh:mm:ss.fff";
                DateTime dateT = new DateTime();
                dateT = DateTime.Now;
                dateT.AddMilliseconds(1);
                dGridTempMeas["id", 0].Value = PP.CelSel.ToString();
                dGridTempMeas["composition", 0].Value = frmMOpt.txtComposition.Text;
                dGridTempMeas["id_sample", 0].Value = frmMOpt.txtSampleNumber.Text;
                dGridTempMeas["Tsint_K", 0].Value = frmMOpt.txtTempSint.Text;
                dGridTempMeas["composition", 0].Value = frmMOpt.txtHeight.Text;
                t = Convert.ToDouble(frmMOpt.txtHeight.Text);
                dGridTempMeas["d_cm", 0].Value = frmMOpt.txtDiameter.Text;
                d = Convert.ToDouble(frmMOpt.txtDiameter.Text);
                dGridTempMeas["T_K", 0].Value = lbTemp.Text;
                dGridTempMeas["f_Hz", 0].Value = freq;
                dGridTempMeas["C_pF", 0].Value = (Convert.ToDouble(val1) * 1e12).ToString();
                e_e0 = PM.e_re(t, d, Convert.ToDouble(dGridTempMeas["C_pF", 0].Value));
                dGridTempMeas["e_re", 0].Value = e_e0.ToString();
                dGridTempMeas["tgd", 0].Value = val2;
                tgper = Convert.ToDouble(dGridTempMeas["tgd", 0].Value);
                dGridTempMeas["tgd1e2", 0].Value = PM.tgdE2(tgper).ToString();
                e_e2 = PM.e_im(e_e0, Convert.ToDouble(dGridTempMeas["tgd", 0].Value));
                dGridTempMeas["e_im", 0].Value = e_e2.ToString();
                Y = e_e2 * Convert.ToInt32(freq) * 2 * 3.14;
                dGridTempMeas["Y", 0].Value = Y.ToString();
                dGridTempMeas["Ubias_V", 0].Value = PP.BiasUCurrent;
                dGridTempMeas["Hbias_T", 0].Value = PP.BiasHCurrent;

                //Update cyclenum
                UpdateCycleNum();
                dGridTempMeas["Cycle", 0].Value = PP.cycleCurrentNum.ToString();
                dGridTempMeas["Date", 0].Value = DateTime.Now.ToShortDateString();
                dGridTempMeas["Time", 0].Value = dateT.ToString(dateformat);
                dGridTempMeas["Step", 0].Value = PP.CurrentStep;
                
                //Update direction
                DirectionChoice();
                
                dGridTempMeas["Direction", 0].Value = PP.Direction;
                dGridTempMeas["Polarity", 0].Value = PP.Polarity;
                dGridTempMeas["operator", 0].Value = frmMOpt.cmbOperator.Text;
                myStopwatch.Stop();
                PP.TimeMeas = PP.TimeMeas + (Convert.ToDouble(myStopwatch.ElapsedMilliseconds.ToString()) * timeCoef) + 0.14;
                dGridTempMeas["Timer", 0].Value = (PP.TimeMeas).ToString();
                dGridTempMeas["Meas_type", 0].Value = frmMOpt.cWorkMode.Text;
                AddParametersVal();

                //additional data
                dGridTempMeas["ro_exp", 0].Value = frmMOpt.txtRoExp.ToString();
                dGridTempMeas["solid_state", 0].Value = frmMOpt.cmbSolidState.ToString();

                if (frmMOpt.cWorkMode.Text == "C(dU)_auto_reversive")
                {
                    dGridTempMeas["Step", 0].Value = PP.CurrentStep.ToString();
                    dGridTempMeas["Direction", 0].Value = PP.Direction.ToString();
                    dGridTempMeas["Polarity", 0].Value = PP.Polarity.ToString();
                }

                switch (frmMOpt.cWorkMode.Text)
                {
                    case "C(dU,dt,df)_relaxation_(law from file)":
                        {
                            for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
                            {
                                if (chartMeasTemp1.Series[u].Name == freq)
                                {
                                    chartMeasTemp1.Series[u].Points.AddXY(PP.TimeMeas, e_e0);
                                    chartMeasTemp2.Series[u].Points.AddXY(PP.TimeMeas, tgper);
                                    chartMeasTemp1.Update();
                                    chartMeasTemp2.Update();
                                }
                            }
                            break;
                        }
                    default:
                        {
                            for (int u = 0; u < chartMeasTemp1.Series.Count; u++)
                            {
                                if (chartMeasTemp1.Series[u].Name == freq + "\r")
                                {
                                    if (frmMOpt.cbGraphOptions.Text == "e(T)" && e_e0 > 0 && e_e0 < 1e25)
                                    {
                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(PP.Temperature1), e_e0);
                                        chartMeasTemp2.Series[u].Points.AddXY(PP.TimeMeas, Convert.ToDouble(PP.Temperature1));
                                        chartMeasTemp1.Update();
                                        chartMeasTemp2.Update();
                                    }
                                    if (frmMOpt.cbGraphOptions.Text == "e(E)" && e_e0 > 0 && e_e0 < 1e25)
                                    {
                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(PP.BiasUCurrent), e_e0);
                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(PP.BiasUCurrent), tgper);
                                        chartMeasTemp1.Update();
                                        chartMeasTemp2.Update();
                                    }

                                    if (frmMOpt.cbGraphOptions.Text == "e(f)" && e_e0 > 0 && e_e0 < 1e25)
                                    {
                                        chartMeasTemp1.Series[u].Points.AddXY(Convert.ToDouble(freq), e_e0);
                                        chartMeasTemp2.Series[u].Points.AddXY(Convert.ToDouble(freq), tgper);
                                        chartMeasTemp1.Update();
                                        chartMeasTemp2.Update();
                                    }
                                }
                            }
                            break;
                        }
                }
                DBConn dBConn = new DBConn();
                string sql = dBConn.DBExportDataString(this.dGridTempMeas, PP.DBTableName, 0);
                FileJob FJ = new FileJob();
                FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
            }
            this.Refresh();
        }


        void UpdateCycleNum()
        {
            if (PP.Direction == PP.cooling && PP.Temperature1 <= PP.NewCycleTemperature)
            {
                ++PP.cycleCurrentNum;
                PP.Direction = PP.heating;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        void DirectionChoice()
        {
            if (PP.Temperature1 < PP.Temperature3 && PP.Direction == PP.heating)
            {
                lbDirect.Text = PP.heating;
                dGridTempMeas["Direction", 0].Value = PP.heating;
            }

            if (PP.Temperature1 >= PP.Temperature3 && PP.Direction == PP.heating)
            {
                lbDirect.Text = "Cooling";
                PP.Direction = PP.cooling;
                dGridTempMeas["Direction", 0].Value = PP.cooling;
            }
            if (PP.Direction==PP.cooling)
            {
                lbDirect.Text = "Cooling";
                PP.Direction = PP.cooling;
                dGridTempMeas["Direction", 0].Value = PP.cooling;
            }

            //{
            //    dGridTempMeas["Direction", 0].Value = PP.Direction;
            //    lbDirect.Text = "Cooling";
            //    PP.Direction = "Cooling";
            //}

            ////if direction is heating
            //if (PP.Temperature1 <= Convert.ToDouble(frmMOpt.txtTempEnd.Text) && PP.Direction == "Heating")
            //{

            //    dGridTempMeas["Direction", 0].Value = "Heating";
            //    lbDirect.Text = "Heating";
            //}
            //// if heating and max temperature
            //if (PP.Temperature1 >= Convert.ToDouble(frmMOpt.txtTempEnd.Text) && PP.Direction == "Heating")
            //{
            //    dGridTempMeas["Direction", 0].Value = PP.Direction;
            //    lbDirect.Text = "Cooling";
            //    PP.Direction = "Cooling";
            //}
            ////if direction is cooling
            //if (PP.Direction == "Cooling")
            //{
            //    PP.Direction = "Cooling";
            //    dGridTempMeas["Direction", 0].Value = PP.Direction;
            //    lbDirect.Text = PP.Direction;
            //}
        }

        /// <summary>
        /// Handles the Click event of the btnSetUNegative control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSetUNegative_Click(object sender, EventArgs e)
        {
            PP.BiasUCurrent = Convert.ToDouble(txtUbias.Text);
            //PP.MeasuringFrequency = Convert.ToInt32(txtCurFreq.Text);
        }
        /// <summary>
        /// Handles the Click event of the btnHandMeas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHandMeas_Click(object sender, EventArgs e)
        {
            //PP.CelSel = dGridTempMeas.CurrentRow.Index;
            if (PP.hand == true)
            {
                InitializationOfParametersForMeas();
                PP.hand = false;
            }


            MainMeas();
        }
        /// <summary>
        /// Handles the FormClosing event of the frmMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Properties.Settings.Default.SaveHeight = frmMOpt.txtHeight.Text;


            if (PP.FileNameSaveTempMeas != "")
            {
                FileJob FJ = new FileJob();
                string[] s = PP.FileNameSaveTempMeas.Split('\\');
                FJ.CopyFileToTempDir(PP.FileNameSaveTempMeas, "c:\\temp\\" + s[s.Count() - 1]);
                MessageBox.Show("Backup");
            }
            //else MessageBox.Show("No backup");
            //Close of all class
            frmDBConnection.Close();
            frmGPIB.Close();
            frmMOpt.Close();
            //// Display a MsgBox asking the user to save changes or abort.
            //if (MessageBox.Show("Do you want to save changes to your data?", "Kalipso",
            //   MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    // Cancel the Closing event from closing the form.
            //    e.Cancel = true;
            //    // Call method to save file...
            //}
            Application.Exit();
        }
        /// <summary>
        /// Handles the Click event of the updateToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vers();
        }


        /// <summary>
        /// Downloads the completed.
        /// dont work now
        /// </summary>
        private void download_Completed()
        {
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            if (File.Exists("U:\\update\\Kalipso_C\\Kalipso.exe"))
            {
                FileVersionInfo WebApplication = FileVersionInfo.GetVersionInfo("U:\\update\\Kalipso_C\\Kalipso.exe");
                if (myFileVersionInfo.ProductVersion.ToString() != WebApplication.ProductVersion.ToString())
                {
                    FileJob FJ = new FileJob();
                    FJ.CopyFileToTempDir("U:\\update\\Kalipso_C\\Kalipso.exe", "temp_Kalipso");
                    try
                    {
                        Process.Start("updater.exe", "temp_Kalipso Kalipso.exe");
                        Process.GetCurrentProcess().Kill();
                    }
                    catch (Exception) { }
                }
            }


        }
        /// <summary>
        /// Handles the FormClosed event of the frmMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> instance containing the event data.</param>
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the btnSetTemp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSetTemp_Click(object sender, EventArgs e)
        {
            try
            {
                lbTemp.Text = 300.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Handles the Click event of the btnUpTemp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpTemp_Click(object sender, EventArgs e)
        {
            try
            {
                lbTemp.Text = (Convert.ToInt32(lbTemp.Text) + 1).ToString();
                PP.Temperature1 = Convert.ToDouble(lbTemp.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Handles the Click event of the btnDounTemp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDounTemp_Click(object sender, EventArgs e)
        {
            try
            {
                lbTemp.Text = (Convert.ToInt32(lbTemp.Text) - 1).ToString();
                dGridTempMeas["id", PP.CelSel].Value = PP.CelSel.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Handles the CellContentClick event of the dGridTempMeas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void dGridTempMeas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dGridTempMeas.CurrentRow.Index.ToString());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DataGridJob dg = new DataGridJob();
            dg.AddColumn(dTreatmentIn, "id", "serial");
            dg.AddColumn(dTreatmentIn, "ss", "text");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dTreatmentIn.Rows.Add();
        }

        private void TimeCurrentMeas_Tick(object sender, EventArgs e)
        {
            IncTimerMeas();

        }
        /// <summary>
        /// Handles the FileOk event of the sDlgFull control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void sDlgFull_FileOk(object sender, CancelEventArgs e)
        {
            FileJob fj = new FileJob();
            fj.WriteFileFullDataGrid(dGridTempMeas, sDlgFull.FileName);
            //PP.FileNameSaveTempMeas = sDlg.FileName;
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            //dGridTempMeas.RowCount = 0;

            //while (dGridTempMeas.Rows.Count != 0)
            //    dGridTempMeas.Rows.Remove(dGridTempMeas.Rows[dGridTempMeas.Rows.Count - 1]);

            //string dateformat = "fff";
            //DateTime dateT = new DateTime();
            //dateT = DateTime.Now;
            //dateT.AddMilliseconds(1);
            //txtHBias.Text = dateT.ToString(dateformat);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {


        }

        private void tBoxTreatment_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            NpgsqlConnection pgcon = new NpgsqlConnection(frmDBConnection.ConnectionStringToDB);
            pgcon.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT  * FROM f23_45", pgcon)
            {
                CommandTimeout = 200
            };
            // Новый адаптер нужен для заполнения набора данных
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            // Создадим новый набор данных
            DataTable dt = new DataTable();
            //dt.Clear();
            // Заполняем набор данных данными, которые вернул запрос
            da.Fill(dt);
            //Связываем элемент DataGridView1 с набором данных
            dTreatmentIn.DataSource = dt;
            pgcon.Close();
        }

        private void saveAgilentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sTreatment.ShowDialog();
        }
        /// <summary>
        /// Handles the FileOk event of the sTreatmentText control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void sTreatmentText_FileOk(object sender, CancelEventArgs e)
        {
            //эксперт данных в Excel дата грид IN
            if (PP.SaveSortingType == "ExcelInTreat")
            {
                try
                {
                    ExcelObj.Application app = new ExcelObj.Application();
                    ExcelObj.Workbook workbook = app.Workbooks.Add();
                    ExcelObj.Worksheet worksheet = workbook.ActiveSheet;

                    for (int i = 1; i < dTreatmentIn.RowCount + 1; i++)
                    {
                        for (int j = 1; j < dTreatmentIn.ColumnCount + 1; j++)
                        {
                            worksheet.Rows[i].Columns[j] = dTreatmentIn.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }
                    app.AlertBeforeOverwriting = false;
                    workbook.SaveAs(sTreatment.FileName + ".xls");
                    app.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            //эксперт данных в Текстовый файл дата грид IN
            if (PP.SaveSortingType == "TextInTreat")
            {
                FileJob FJ = new FileJob();
                FJ.WriteFileFullDataGrid(dTreatmentIn, sTreatment.FileName);
            }

            //эксперт данных в Excel дата грид Out
            if (PP.SaveSortingType == "ExcelOutTreat")
            {
                try
                {
                    ExcelObj.Application app = new ExcelObj.Application();
                    ExcelObj.Workbook workbook = app.Workbooks.Add();
                    ExcelObj.Worksheet worksheet = workbook.ActiveSheet;

                    for (int i = 1; i < dTreatmentOut.RowCount + 1; i++)
                    {
                        for (int j = 1; j < dTreatmentOut.ColumnCount + 1; j++)
                        {
                            worksheet.Rows[i].Columns[j] = dTreatmentOut.Rows[i - 1].Cells[j - 1].Value;
                        }
                    }
                    app.AlertBeforeOverwriting = false;
                    workbook.SaveAs(sTreatment.FileName + ".xls");
                    app.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            //эксперт данных в Текстовый файл дата грид Out
            if (PP.SaveSortingType == "TextOutTreat")
            {
                FileJob FJ = new FileJob();
                FJ.WriteFileFullDataGrid(dTreatmentOut, sTreatment.FileName + ".txt");
            }
        }

        private void oDlgTreatment_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the sortingFileOldFormatToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void sortingFileOldFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the excelFileForTreatmentToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name = "e" > The <see cref="EventArgs"/> instance containing the event data.</param>
        private void excelFileForTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP.OpenSortingType = "LoadFileExcel";
            oDlgTreatConverting.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the sortingOldFormatToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void sortingOldFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP.OpenSortingType = "Simple";
            oDlgTreatConverting.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the textFileForTreatmentToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void textFileForTreatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP.OpenSortingType = "LoadFileText";
            oDlgTreatConverting.ShowDialog();
        }

        private void trToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void chartTreatment_Click(object sender, EventArgs e)
        {

        }

        private void txtTreatMinT_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTreatment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void excelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PP.SaveSortingType = "ExcelInTreat";
            sTreatment.ShowDialog();
        }



        private void textToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PP.SaveSortingType = "TextInTreat";
            sTreatment.ShowDialog();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void excelOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP.SaveSortingType = "ExcelOutTreat";
            sTreatment.ShowDialog();
        }

        private void textoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP.SaveSortingType = "TextOutTreat";
            sTreatment.ShowDialog();
        }

        private void dBConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDBConnection.ShowDialog();
        }

        private void exportMeasDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportMeasInformationToDataBase();
        }
        /// <summary>
        /// 
        /// </summary>
        public void ExportMeasInformationToDataBase()
        {
            NpgsqlConnection pgcon = new NpgsqlConnection(frmDBConnection.ConnectionStringToDB);
            pgcon.Open();
            string s = "";
            for (int i = 0; i < dGridTempMeas.Columns.Count; i++)
            {
                s = s + dGridTempMeas.Columns[i].HeaderText + " " + dGridTempMeas.Columns[i].Tag.ToString() + ", ";
            }
            string sql = "Create table " + frmMOpt.txtComposition + " (" + s + " description text);";
            NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
            try
            {
                CSend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            for (int i = 0; i < dGridTempMeas.RowCount + 1; i++)
            {
                sql = "";
                string sql_data = "";
                for (int j = 0; j < dGridTempMeas.ColumnCount + 1; j++)
                {
                    sql_data = sql_data + dGridTempMeas.Rows[i].Cells[j].Value.ToString() + ", ";
                }
                sql_data = sql_data.Substring(0, sql_data.Length - 2);
                sql = "Insert into " + frmMOpt.txtComposition + " values (" + sql_data + ");";
                CSend.ExecuteNonQuery();
                try
                {
                    CSend.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            pgcon.Close();
        }
        /// <summary>
        /// Exports the meas to data base from data grid.
        /// </summary>
        /// <param name="DG">The dg.</param>
        public void ExportMeasToDataBaseFromDataGrid(DataGridView DG)
        {
            NpgsqlConnection pgcon = new NpgsqlConnection(frmDBConnection.ConnectionStringToDB);
            pgcon.Open();
            string s = "";
            for (int i = 0; i < dGridTempMeas.Columns.Count; i++)
            {
                s = s + dGridTempMeas.Columns[i].HeaderText + " " + dGridTempMeas.Columns[i].Tag + ", ";
            }
            string sql = "Create table " + frmMOpt.txtComposition + " (" + s + " description text);"; ;
            NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
            try
            {
                CSend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            for (int i = 0; i < dGridTempMeas.RowCount + 1; i++)
            {
                sql = "";
                string sql_data = "";
                for (int j = 0; j < dGridTempMeas.ColumnCount + 1; j++)
                {
                    sql_data = sql_data + dGridTempMeas.Rows[i].Cells[j].Value.ToString() + ", ";
                }
                sql_data = sql_data.Substring(0, sql_data.Length - 2);
                sql = "Insert into " + frmMOpt.txtComposition + " values (" + sql_data + ");";
                CSend.ExecuteNonQuery();
                try
                {
                    CSend.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            pgcon.Close();
        }
        /// <summary>
        /// Creates the table to export meas to data base from data grid.
        /// </summary>
        /// <param name="DG">The dg.</param>
        public void CreateTableToExportMeasToDataBaseFromDataGrid(DataGridView DG)
        {
            //NpgsqlConnection pgcon = new NpgsqlConnection(frmDBConnection.ConnectionStringToDB);
            //pgcon.Open();
            string s = "";
            for (int i = 0; i < dGridTempMeas.Columns.Count; i++)
            {
                s = s + dGridTempMeas.Columns[i].HeaderText + " " + dGridTempMeas.Columns[i].Tag + ", ";
            }
            //создать пустой файл
            System.IO.File.Create(PP.FileNameSaveTempMeasDB);

            string sql = "Create table " + frmMOpt.txtComposition + " (" + s + " description text);";
            DBConn dBConn = new DBConn();
            bool check = dBConn.DBSendCMD(PP.DBSQLConnctionString, sql);
            if (check == false)
            {
                FileJob FJ = new FileJob();
                FJ.WriteF(sql, PP.FileNameSaveTempMeasDB);
            }
        }

        /// <summary>
        /// Exports the treatment information to data base.
        /// </summary>
        public void ExportTreatmentInformationToDataBase(DataGridView DG)
        {
            PiezoMathCalculation PM = new PiezoMathCalculation();
            DBConn dBConn = new DBConn();
            dBConn.DBCreateTableForMeas(DG, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
            dBConn.DBExportDataCommon(DG, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
            NpgsqlConnection pgcon = new NpgsqlConnection(frmDBConnection.ConnectionStringToDB);
            pgcon.Open();
            string s = "";
            for (int i = 0; i < DG.Columns.Count; i++)
            {
                if (DG.Columns[i].HeaderText == "id")
                {
                    s = s + DG.Columns[i].HeaderText + " SERIAL, ";
                }
                if (DG.Columns[i].HeaderText == "composition" ||
                    DG.Columns[i].HeaderText == "Direction" ||
                    DG.Columns[i].HeaderText == "Meas_type" ||
                    DG.Columns[i].HeaderText == "operator")
                {
                    s = s + DG.Columns[i].HeaderText + " text, ";
                }
                if (DG.Columns[i].HeaderText == "id_sample")
                {
                    s = s + DG.Columns[i].HeaderText + " INT, ";
                }
                if (DG.Columns[i].HeaderText == "Tsint_K" ||
                    DG.Columns[i].HeaderText == "composition" ||
                    DG.Columns[i].HeaderText == "d_cm" ||
                    DG.Columns[i].HeaderText == "T_K" ||
                    DG.Columns[i].HeaderText == "T_K" ||
                    DG.Columns[i].HeaderText == "C_pF" ||
                    DG.Columns[i].HeaderText == "e_re" ||
                    DG.Columns[i].HeaderText == "tgd1e2" ||
                    DG.Columns[i].HeaderText == "e_im" ||
                    DG.Columns[i].HeaderText == "tgd" ||
                    DG.Columns[i].HeaderText == "Y" ||
                    DG.Columns[i].HeaderText == "Ubias_V" ||
                    DG.Columns[i].HeaderText == "Hbias_T"
                    )
                {
                    s = s + DG.Columns[i].HeaderText + " double precision, ";
                }
                if (DG.Columns[i].HeaderText == "f_Hz" ||
                    DG.Columns[i].HeaderText == "Cycle" ||
                    DG.Columns[i].HeaderText == "Timer")
                {
                    s = s + DG.Columns[i].HeaderText + " INT, ";
                }
                if (DG.Columns[i].HeaderText == "Time")
                {
                    s = s + DG.Columns[i].HeaderText + " time, ";
                }
                if (DG.Columns[i].HeaderText == "Date")
                {
                    s = s + DG.Columns[i].HeaderText + " date, ";
                }
            }


            string sql = "Create table " + frmMOpt.txtComposition.Text + " (" + s + " description text);";
            NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
            try
            {
                CSend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            sql = "";
            string sql_data = "";


            //tBoxTreatment.AppendText(sql + Environment.NewLine);

            for (int i = 0; i < DG.RowCount - 1; i++)
            {

                sql = "";
                sql_data = "";
                sql = "Insert into " + frmMOpt.txtComposition.Text + "(";
                for (int j = 1; j < DG.ColumnCount; j++)
                {
                    if (j == DG.ColumnCount - 1)
                    {
                        sql = sql + DG.Columns[j].Name + ") ";
                    }
                    else sql = sql + DG.Columns[j].Name + ", ";
                }
                for (int j = 1; j < DG.ColumnCount; j++)
                {
                    switch (DG.Columns[j].Name)
                    {
                        case "composition": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                        case "Direction": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                        case "Meas_type": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                        case "operator": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                        case "Time": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                        case "Date": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                        default: sql_data = sql_data + DG.Rows[i].Cells[j].Value.ToString() + ", "; break;

                    }
                }

                sql_data = sql_data.Substring(0, sql_data.Length - 2);
                sql = sql + " values (" + sql_data + ");";

                tBoxTreatment.AppendText(sql + Environment.NewLine);
                NpgsqlCommand CSend1 = new NpgsqlCommand(sql, pgcon);
                try
                {
                    CSend1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            pgcon.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportTreatmentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBConn dBConn = new DBConn();
            dBConn.DBCreateTableForMeas(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
            dBConn.DBExportDataCommon(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressDB_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Ininitialezeds the main meas graf.
        /// </summary>
        public void IninitialezedMainMeasGraf()
        {
            for (int i = 0; i < dGridTempMeas.ColumnCount; i++)
            {
                Color myRgbColor = new Color();
                myRgbColor = Color.FromArgb(i, 255, i + 5);

                chartMeasTemp1.Series.Clear();
                chartMeasTemp1.Series.Add(dGridTempMeas.Columns[i].HeaderText);
                chartMeasTemp1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                chartMeasTemp1.Series[i].Color = myRgbColor;
            }
        }


        private void chartMeasTemp_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_3(object sender, EventArgs e)
        {
        }

        private void cbChartGrafItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int o = cbChartGrafItems.SelectedIndex;
                for (int i = 0; i < dGridTempMeas.RowCount - 1; i++)
                {
                    chartMeasTemp1.Series[i].Points.AddXY(Convert.ToDouble(dGridTempMeas["T_K", i].Value.ToString()), Convert.ToDouble(dGridTempMeas["C_pF", i].Value.ToString()));
                }
            }
            catch
            {
#pragma warning disable CS0219 // Переменной "i" присвоено значение, но оно ни разу не использовано.
                int i = 0;
#pragma warning restore CS0219 // Переменной "i" присвоено значение, но оно ни разу не использовано.
            }
        }

        private void exportAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //кусок отвечающий за экспорт в базу данных 
            DBConn dBConn = new DBConn();
            dBConn.DBCreateTableRandomMeas(this.dTreatmentIn, PP.DBSQLConnctionString, PP.DBTableName);
            dBConn.DBExportDataRandom(this.dTreatmentIn, PP.DBSQLConnctionString, PP.DBTableName);
            //пропуск фалов с RNON.txt
            this.Refresh();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void button2_Click_4(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void treatmentToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void sortingTfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dTreatmentOut

        }
        /// <summary>
        /// Handles the Click event of the exportTreatmentDataAllFormatsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exportTreatmentDataAllFormatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBConn dBConn = new DBConn();
            dBConn.DBCreateTableRandomMeas(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
            dBConn.DBExportDataCommon(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
        }
        /// <summary>
        /// Handles the Click event of the sortingOldFormatdnonrnonToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void sortingOldFormatdnonrnonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP.OpenSortingType = "DNON_RNON";
            oDlgTreatConverting.ShowDialog();
        }
        /// <summary>
        /// Handles the Click event of the exportTreatmentDatatempRandomFormatToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exportTreatmentDatatempRandomFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP.DBSQLConnctionString = frmDBConnection.ConnectionStringToDB;
            DBConn dB = new DBConn();
            dB.ExportDataToDataBaseTempAll(this.dTreatmentIn, PP.DBSQLConnctionString);


            string[] filesname = Directory.GetFiles(@"C:\\temp\\");
            //ProgressDB.Maximum = filesname.Length;
            //for (int i = 0; i < filesname.Length; i++)
            //{
            //    DNON_RNON_Import(filesname[i]);//импорт файла
            //    string[] names = filesname[i].Split(Convert.ToChar(92)); //разделение строки на массив по символу '\'
            //    string[] s = names[names.Length - 1].Split(Convert.ToChar(46));//разделение строки на массив по символу '.'
            //    frmMOpt.txtComposition.Text = s[s.Length - 2].Replace("DNON", "");//замена подстроки на "" 
            //    PP.DBTableName = frmMOpt.txtComposition.Text;
            //    PP.DBSQLConnctionString = frmDBConnection.ConnectionStringToDB;
            //    //кусок отвечающий за экспорт в базу данных 
            //    DBConn dBConn = new DBConn();
            //    dBConn.DBCreateTableRandomMeas(this.dTreatmentIn, PP.DBSQLConnctionString, PP.DBTableName);
            //    dBConn.DBExportDataRandom(this.dTreatmentIn, PP.DBSQLConnctionString, PP.DBTableName);
            //    //пропуск фалов с RNON.txt
            //    ++i;
            //    this.Refresh();
            //    ProgressDB.Value = i;
            //}



            //копирование файлов из temp в подкаталог resolved
            for (int i = 0; i < filesname.Length; i++)
            {
                //создаем директорию
                Directory.CreateDirectory(@"C:\\temp\\resolved\\");
                char delimiter = Convert.ToChar(92);
                string[] filespath = filesname[i].Split(delimiter);
                //проверка существует ли в конечной папке копируемый файл
                if (File.Exists(@"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]))
                {
                    File.Delete(@"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]);
                }
                File.Move(filesname[i], @"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]);
            }
        }
        /// <summary>
        /// Handles the Click event of the importDataToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportTreatmentDatatempCommonFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileJob fj = new FileJob();
            string[] filesname = Directory.GetFiles(@"C:\\temp\\");
            //for (int i = 0; i < filesname.Length - 1; i++)
            for (int i = 0; i < filesname.Length; i++)
            {
                fj.Common_Import(filesname[i], this.dTreatmentIn);
                string[] names = filesname[i].Split(Convert.ToChar(92)); //разделение строки на массив по символу '\'
                string[] s = names[names.Length - 1].Split(Convert.ToChar(46));//разделение строки на массив по символу '.'
                string[] s1 = s[0].Split('_');//разделение строки на массив по символу '_'
                frmMOpt.txtComposition.Text = s1[0];//замена подстроки на ""
                txtLog.AppendText(filesname[i] + Environment.NewLine);
                //кусок отвечающий за экспорт в базу данных
                DBConn dBConn = new DBConn();
                dBConn.DBCreateTableRandomMeas(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
                dBConn.DBExportDataCommon(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
            }
            //копирование файлов из temp в подкаталог resolved
            fj.CopyResolvedFiles();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string filesname =
            //DNON_RNON_Import(filesname);//импорт файла
            //string[] names = filesname.Split(Convert.ToChar(92)); //разделение строки на массив по символу '\'
            //string[] s = names[names.Length - 1].Split(Convert.ToChar(46));//разделение строки на массив по символу '.'
            //frmMOpt.txtComposition.Text = s[s.Length - 2].Replace("DNON", "");//замена подстроки на "" 
        }

        private void dGridPiezo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timerRev_Tick(object sender, EventArgs e)
        {
            //++PP.TimerReversive;
            //PP.TimerReversive = PP.TimerReversive / 1000;


            PP.BiasUCurrent=GetUFromVoltmeter();
            lbField.Text = "U= " + PP.BiasUCurrent.ToString();

        }

        private void mainStatus_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exportAllDataFromTempTxtOldDormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //кусок отвечающий за экспорт в базу данных 
            FileJob fj = new FileJob();
            string[] filesname = Directory.GetFiles(@"C:\\temp\\");
            ProgressDB.Maximum = filesname.Length;
            for (int i = 0; i < filesname.Length; i++)
            {
                DNON_RNON_Import(filesname[i]);//импорт файла
                ++i;
                frmDBConnection.ConnString();
                PP.DBSQLConnctionString = frmDBConnection.ConnectionStringToDB;
                DBConn dBConn = new DBConn();
                dBConn.DBCreateTableRandomMeas(this.dTreatmentIn, PP.DBSQLConnctionString, PP.DBTableName);
                dBConn.DBExportDataRandom1(this.dTreatmentIn, PP.DBSQLConnctionString, PP.DBTableName);
                ProgressDB.Value = i;
            }
            //пропуск фалов с RNON.txt
            this.Refresh();
            fj.CopyResolvedFiles();
            DeleteFileFromTemp();
        }


        //#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMain.CopyResolvedFiles()"
        //        public void CopyResolvedFiles()
        //#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMain.CopyResolvedFiles()"
        //        {

        //            string[] filesname = Directory.GetFiles(@"C:\\temp\\");
        //            for (int i = 0; i < filesname.Length; i++)
        //            {
        //                //создаем директорию
        //                Directory.CreateDirectory(@"C:\\temp\\resolved\\");
        //                string[] filespath = filesname[i].Split(Convert.ToChar(92));
        //                //проверка существует ли в конечной папке копируемый файл
        //                if (File.Exists(@"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]))
        //                {
        //                    File.Delete(@"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]);
        //                }
        //                File.Move(filesname[i], @"C:\\temp\\resolved\\" + filespath[filespath.Length - 1]);
        //            }
        //        }

#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMain.DeleteFileFromTemp()"
        public void DeleteFileFromTemp()
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmMain.DeleteFileFromTemp()"
        {
            string[] filesname = Directory.GetFiles(@"C:\\temp\\");
            for (int i = 0; i < filesname.Length; i++)
            {
                File.Delete(@"C:\\temp\\" + filesname[i]);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void sqlFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBConn dBConn = new DBConn();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            try
            {
                openFileDialog.OpenFile();
                dBConn.ExportSQLFile(openFileDialog.FileName, frmDBConnection.ConnectionStringToDB);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void exportTreatmentDatatempCommonFormatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new DBConn().ExportDataToDataBaseTemp(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB);


            //FileJob fj = new FileJob();
            //string[] filesname = Directory.GetFiles(@"C:\\temp\\");
            ////for (int i = 0; i < filesname.Length - 1; i++)
            //for (int i = 0; i < filesname.Length; i++)
            //{
            //    fj.Common_Import(filesname[i], this.dTreatmentIn);
            //    string[] names = filesname[i].Split(Convert.ToChar(92)); //разделение строки на массив по символу '\'
            //    string[] s = names[names.Length - 1].Split(Convert.ToChar(46));//разделение строки на массив по символу '.'
            //    string[] s1 = s[0].Split('_');//разделение строки на массив по символу '_'
            //    frmMOpt.txtComposition.Text = s1[0];//замена подстроки на ""
            //    txtLog.AppendText(filesname[i] + Environment.NewLine);
            //    //кусок отвечающий за экспорт в базу данных
            //    DBConn dBConn = new DBConn();
            //    dBConn.DBCreateTableRandomMeas(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
            //    dBConn.DBExportDataCommon(this.dTreatmentIn, frmDBConnection.ConnectionStringToDB, frmMOpt.txtComposition.Text);
            //}
            ////копирование файлов из temp в подкаталог resolved
            //fj.CopyResolvedFiles();
        }

        private void exportDatatempDnonrnonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PP.DBSQLConnctionString = frmDBConnection.ConnectionStringToDB;
            DBConn dB = new DBConn();
            dB.ExportDataToDataBaseTempAll(this.dTreatmentIn, PP.DBSQLConnctionString);
            FileJob fj = new FileJob();
            fj.CopyResolvedFiles();
        }

        private void exportDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

        }

        private void lbTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDounTemp_Click_1(object sender, EventArgs e)
        {
            try
            {
                lbTemp.Text = (Convert.ToInt32(lbTemp.Text) - 1).ToString();
                PP.Temperature1 = Convert.ToDouble(lbTemp.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private double GetUFromVoltmeter()
        {
            double volt = 0;
            for (int i = 0; i < Com.allComPort.Count(); i++)
            {
                if (Com.allComPort[i].DeviceName == "VoltageMeter HY-AV51-T")
                {
                    switch (frmMOpt.cWorkMode.Text)
                    {
                        case "C(dU)_auto_reversive":
                            {
                                volt = GetDataFromVoltageMeter_HY_AV51_T();
                                if (volt == 0)
                                {
                                    PP.BiasUCurrent = 0;
                                }
                                if (volt != 0)
                                {
                                    PP.BiasUCurrent = 23.81 * volt - 16.464;
                                }
                                break;
                            }
                        case "C(dU)_hand_reversive":
                            {
                                volt = GetDataFromVoltageMeter_HY_AV51_T();
                                if (volt == 0)
                                {
                                    PP.BiasUCurrent = 0;
                                }
                                if (volt != 0)
                                {
                                    PP.BiasUCurrent = 23.81 * volt - 16.464;
                                }
                                break;
                            }
                        case "C(dU_dt)_auto_reversive":
                            {
                                volt = GetDataFromVoltageMeter_HY_AV51_T();
                                if (volt == 0)
                                {
                                    PP.BiasUCurrent = 0;
                                }
                                if (volt != 0)
                                {
                                    PP.BiasUCurrent = 23.81 * volt - 16.464;
                                }
                                break;
                            }
                        case "C(dU_dT)_auto_reversive":
                            {
                                volt = GetDataFromVoltageMeter_HY_AV51_T();
                                if (volt == 0)
                                {
                                    PP.BiasUCurrent = 0;
                                }
                                if (volt != 0)
                                {
                                    PP.BiasUCurrent = 23.81 * volt - 16.464;
                                }
                                break;
                            }
                        case "d33Rev_Auto":
                            {
                                volt = GetDataFromVoltageMeter_HY_AV51_T();
                                if (volt == 0)
                                {
                                    PP.BiasUCurrent = 0;
                                }
                                if (volt != 0)
                                {
                                    PP.BiasUCurrent = 0.0825 * volt - 0.1728;
                                }
                                break;
                            }
                        case "d33Rev":
                            {
                                volt = GetDataFromVoltageMeter_HY_AV51_T();
                                if (volt == 0)
                                {
                                    PP.BiasUCurrent = 0;

                                }
                                if (volt != 0)
                                {
                                    PP.BiasUCurrent = volt;
                                }
                                break;
                            }
                        case "Magnit_hand":
                            {
                                volt = GetDataFromVoltageMeter_HY_AV51_T();
                                if (volt == 0)
                                {
                                    PP.BiasUCurrent = 0;

                                }
                                if (volt != 0)
                                {
                                    PP.BiasUCurrent = volt;
                                }
                                break;
                            }
                        default:
                            {
                                volt = GetDataFromVoltageMeter_HY_AV51_T();
                                if (volt == 0)
                                {
                                    PP.BiasUCurrent = 0;

                                }
                                if (volt != 0)
                                {
                                    PP.BiasUCurrent = volt;
                                }
                                break;
                            }
                    
                    
                    }
                    return volt;
                }
            }
            return volt;

        }

        private void button2_Click_5(object sender, EventArgs e)
        {
            //Vers();
            //for (int i = 0; i < Com.allComPort.Count(); i++)
            //{
            //    if (Com.allComPort[i].DeviceName == "VoltageMeter HY-AV51-T")
            //    {
            //        GetDataFromVoltageMeter_HY_AV51_T();

            //        txtLog.AppendText(Environment.NewLine + "1 " + GetDataFromVoltageMeter_HY_AV51_T().ToString());
            //        txtLog.AppendText(Environment.NewLine + "2 " + (GetUFromVoltmeter() / 10).ToString());
            //        txtLog.AppendText(Environment.NewLine + "3 " + (0.0825 * (GetUFromVoltmeter()) + 0.1728).ToString());
            //    }
            //}

            timerRev.Enabled = true;
        }
        /// <summary>
        /// Verses this instance.
        /// </summary>
        public void Vers()
        {
            string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var ves = Assembly.GetExecutingAssembly().GetName().Version;
            DateTime creation = File.GetCreationTime(@"C:\test.txt");
            DateTime sr = File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
            DateTime dest = File.GetLastWriteTime(@"F:\Kalipso\Debug\Kalipso.exe");

            txtLog.AppendText(Environment.NewLine + "Ok3");
            if (sr < dest)
            {
                txtLog.AppendText(Environment.NewLine + "Ok");

                try
                {
                    Process.Start("updater1.exe", Assembly.GetExecutingAssembly().Location.ToString());
                    Process.GetCurrentProcess().Kill();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        void сreateXMLDocument()
        {
            try
            {
                string[] filesname = Directory.GetFiles(@"\\10.11.0.14\update\kalipso", "*.*", SearchOption.AllDirectories);
                var xmlWriter = new XmlTextWriter("update.xml", null);
                xmlWriter.WriteStartDocument();                  // <?xml version="1.0"?>
                xmlWriter.WriteStartElement("Update_param");      // <ListOfBooks>
                for (int i = 0; i < filesname.Count(); i++)
                {
                    xmlWriter.WriteStartElement("path" + i.ToString());             //      <Book>
                    xmlWriter.WriteString(filesname[i]);   //Title-1
                    xmlWriter.WriteEndElement();                     //       </Book>
                }
                xmlWriter.WriteStartElement("version");             //      <Book>
                xmlWriter.WriteString(Assembly.GetExecutingAssembly().GetName().Version.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();                     // </ListOfBooks>
                xmlWriter.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
                //throw;
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (chPolarity.Checked)
            {
                case true:
                    PP.Polarity = PP.PolarityPositive;
                    break;
                case false:
                    PP.Polarity = PP.PolarityNegative;
                    break;
                default:
                    break;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void createXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createXMLDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            сreateXMLDocument();
        }

        private void btnSetAxis1_Click(object sender, EventArgs e)
        {

            chartMeasTemp1.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(txtXmin1.Text);
            chartMeasTemp1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(txtXmax1.Text);
        }

        private void button3_Click_4(object sender, EventArgs e)
        {
            chartMeasTemp1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtYmin1.Text);
            chartMeasTemp1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtYmax1.Text);
        }

        private void button3_Click_5(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnSetX2_Click(object sender, EventArgs e)
        {
            chartMeasTemp2.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(txtXmin2.Text);
            chartMeasTemp2.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(txtXmax2.Text);
        }

        private void btnSetY2_Click(object sender, EventArgs e)
        {
            chartMeasTemp2.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(txtYmin2.Text);
            chartMeasTemp2.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(txtYmax2.Text);
        }

        private void DasdaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        //static void func()
        //    {
        //        for (int i = 0; i < 10; i++)
        //        {
        //            Console.WriteLine("Поток 2 выводит " + i.ToString());
        //            Thread.Sleep(0);
        //        }
        //    }
        //static void func1()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("Поток 2 выводит " + i.ToString());
        //        Thread.Sleep(0);
        //    }
        //}


        //private void button5_Click_2(object sender, EventArgs e)
        //{
        //    Thread t = new Thread(func);
        //    Thread t1 = new Thread(func1);
        //    t.Start();
        //    t1.Start();
        //}
    }
}
