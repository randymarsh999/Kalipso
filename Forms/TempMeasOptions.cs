using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kalipso.Сalculations;

namespace Kalipso
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class frmMeasTempOpt : Form
    {

        /// <summary>
        /// The pp
        /// </summary>
        public PiezoParameters PP = new PiezoParameters();
        /// <summary>
        ///Constructor of measurment options form
        /// </summary>
        public frmMeasTempOpt()
        {
            InitializeComponent();
            FillCbFreqMode();
            FillCbMeasType();
            FillcdExportTypeToDB();
            FillMeasModel();
            cFreqMode.SelectedIndex = 0;
            cbGPIBDevModel.SelectedIndex = 0;
            cFreqMode.SelectedIndex = 0;
            cWorkMode.SelectedIndex = 0;
            cFreqMode.SelectedItem = 0;
            cDirect.SelectedIndex = 0;
            cbTempMode.SelectedIndex = 0;
            cCUCycle.SelectedIndex = 0;
            cbExportDBMeasTemp.SelectedIndex = 0;
            cbGraphOptions.SelectedIndex = 0;
        }

        private void frmMeasTempOpt_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmMeasTempOpt_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the btnAddFreq control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnAddFreq_Click(object sender, EventArgs e)
        {
            switch (cbGPIBDevModel.Text)
            {
                case "Agilent4980A":
                    {
                        tFreqList.Clear();
                        dGridFreqMeas.Rows.Clear();

                        switch (cFreqMode.Text)
                        {
                            case "Step":
                                {
                                    for (int i = 0; i < chListFreq.CheckedItems.Count; i++)
                                    {
                                        tFreqList.AppendText(chListFreq.CheckedItems[i].ToString() + Environment.NewLine);
                                        dGridFreqMeas.Rows.Add(i.ToString(), chListFreq.CheckedItems[i].ToString());
                                        PP.array_f_dispersion = new int[dGridFreqMeas.Rows.Count];
                                        for (int j = 0; j < PP.array_f_dispersion.Count(); j++)
                                        {
                                            PP.array_f_dispersion[j] = Convert.ToInt32(tFreqList.Lines[j]);
                                        }
                                    }
                                    break;
                                }
                            case "Auto":
                                {
                                    int start = Convert.ToInt32(txtStartFreq.Text);
                                    int end = Convert.ToInt32(txtEndFreq.Text);
                                    int step = Convert.ToInt32(txtStepFreq.Text);
                                    int a;
                                    a = (end - start) / step;
                                    tFreqList.AppendText(start.ToString() + Environment.NewLine);
                                    for (int i = 0; i < a; i++)
                                    {
                                        start = start + step;
                                        if (start < end)
                                        {
                                            tFreqList.AppendText(start.ToString() + Environment.NewLine);
                                            dGridFreqMeas.Rows.Add(i.ToString(), start.ToString());
                                        }
                                        if (start >= end)
                                        {
                                            tFreqList.AppendText(end.ToString());
                                            dGridFreqMeas.Rows.Add(i.ToString(), end.ToString());
                                            PP.array_f_dispersion = new int[dGridFreqMeas.Rows.Count];
                                            for (int j = 0; j < PP.array_f_dispersion.Count(); j++)
                                            {
                                                PP.array_f_dispersion[j] = Convert.ToInt32(tFreqList.Lines[j]);
                                            }
                                            return;
                                        }
                                    }
                                    break;
                                }
                            case "Logarithm":
                                {


                                    int start = Convert.ToInt32(txtStartFreq.Text);
                                    int end = Convert.ToInt32(txtEndFreq.Text);
                                    double step = Convert.ToDouble(txtCoefficient.Text);
                                    tFreqList.AppendText(start.ToString() + Environment.NewLine);
                                    
                                    for (int i = 0; i < end; i++)
                                    {
                                        start = Convert.ToInt32(Convert.ToDouble(start) * step);
                                        if (start < end)
                                        {
                                            dGridFreqMeas.Rows.Add(i.ToString(), start.ToString());
                                            tFreqList.AppendText(start.ToString() + Environment.NewLine);
                                        }
                                        if (start >= end)
                                        {
                                            dGridFreqMeas.Rows.Add(i.ToString(), end.ToString());
                                            tFreqList.AppendText(end.ToString());
                                            PP.array_f_dispersion = new int[dGridFreqMeas.Rows.Count];
                                            for (int j = 0; j < PP.array_f_dispersion.Count(); j++)
                                            {
                                                PP.array_f_dispersion[j] = Convert.ToInt32(tFreqList.Lines[j]);
                                            }
                                            return;
                                        }
                                    }
                                    break;
                                }
                            default:
                                break;
                        }
                        break;
                    }
                case "Agilent4263B":
                    {
                        tFreqList.Clear();
                        tFreqList.AppendText("100" + Environment.NewLine);
                        tFreqList.AppendText("120" + Environment.NewLine);
                        tFreqList.AppendText("1000" + Environment.NewLine);
                        tFreqList.AppendText("10000" + Environment.NewLine);
                        tFreqList.AppendText("100000");

                        dGridFreqMeas.Rows.Add(1.ToString(), "100");
                        dGridFreqMeas.Rows.Add(2.ToString(), "120");
                        dGridFreqMeas.Rows.Add(3.ToString(), "1000");
                        dGridFreqMeas.Rows.Add(4.ToString(), "10000");
                        dGridFreqMeas.Rows.Add(5.ToString(), "100000");
                        PP.array_f_dispersion = new int[dGridFreqMeas.Rows.Count];
                        for (int j = 0; j < PP.array_f_dispersion.Count(); j++)
                        {
                            PP.array_f_dispersion[j] = Convert.ToInt32(tFreqList.Lines[j]);
                        }
                        break;
                    }
                case "WayneKerr4300":
                    {
                        tFreqList.Clear();
                        if (cFreqMode.Text == "Logarithm")
                        {
                            int start = Convert.ToInt32(txtStartFreq.Text);
                            int end = Convert.ToInt32(txtEndFreq.Text);
                            double step = Convert.ToDouble(txtCoefficient.Text);
                            tFreqList.AppendText(start.ToString() + Environment.NewLine);
                            for (int i = 0; i < end; i++)
                            {
                                start = Convert.ToInt32(Convert.ToDouble(start) * step);
                                if (start < end)
                                {
                                    tFreqList.AppendText(start.ToString() + Environment.NewLine);
                                }
                                if (start >= end)
                                {
                                    tFreqList.AppendText(end.ToString());
                                    PP.array_f_dispersion = new int[dGridFreqMeas.Rows.Count];
                                    for (int j = 0; j < PP.array_f_dispersion.Count(); j++)
                                    {
                                        PP.array_f_dispersion[j] = Convert.ToInt32(tFreqList.Lines[j]);
                                    }
                                    return;
                                }
                            }
                        }
                        break;
                    }
                case "E7-20":
                    {
                        tFreqList.Clear();
                        tFreqList.AppendText("25" + Environment.NewLine);
                        tFreqList.AppendText("50" + Environment.NewLine);
                        tFreqList.AppendText("60" + Environment.NewLine);
                        tFreqList.AppendText("100" + Environment.NewLine);
                        tFreqList.AppendText("120" + Environment.NewLine);
                        tFreqList.AppendText("200" + Environment.NewLine);
                        tFreqList.AppendText("500" + Environment.NewLine);
                        tFreqList.AppendText("1000" + Environment.NewLine);
                        tFreqList.AppendText("2000" + Environment.NewLine);
                        tFreqList.AppendText("5000" + Environment.NewLine);
                        tFreqList.AppendText("10000" + Environment.NewLine);
                        tFreqList.AppendText("20000" + Environment.NewLine);
                        tFreqList.AppendText("50000" + Environment.NewLine);
                        tFreqList.AppendText("100000" + Environment.NewLine);
                        tFreqList.AppendText("200000" + Environment.NewLine);
                        tFreqList.AppendText("500000" + Environment.NewLine);
                        tFreqList.AppendText("1000000");
                        PP.array_f_dispersion = new int[dGridFreqMeas.Rows.Count];
                        for (int j = 0; j < PP.array_f_dispersion.Count(); j++)
                        {
                            PP.array_f_dispersion[j] = Convert.ToInt32(tFreqList.Lines[j]);
                        }
                        break;
                    }
                default:
                    {
                        if (cFreqMode.Text == "Logarithm")
                        {
                            tFreqList.Clear();
                            int start = Convert.ToInt32(txtStartFreq.Text);
                            int end = Convert.ToInt32(txtEndFreq.Text);
                            double step = Convert.ToDouble(txtCoefficient.Text);
                            tFreqList.AppendText(start.ToString() + Environment.NewLine);

                            for (int i = 0; i < end; i++)
                            {
                                start = Convert.ToInt32(Convert.ToDouble(start) * step);
                                if (start < end)
                                {
                                    tFreqList.AppendText(start.ToString() + Environment.NewLine);
                                }
                                if (start >= end)
                                {
                                    tFreqList.AppendText(end.ToString());
                                    PP.array_f_dispersion = new int[dGridFreqMeas.Rows.Count];
                                    for (int j = 0; j < PP.array_f_dispersion.Count(); j++)
                                    {
                                        PP.array_f_dispersion[j] = Convert.ToInt32(tFreqList.Lines[j]);
                                    }
                                    return;
                                }
                            }
                        }
                    }
                    break;
            }
        }
        /// <summary>
        /// Add all frequnces for the current device
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbAllFreq_CheckedChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Clear frequency list
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbClear_CheckedChanged(object sender, EventArgs e)
        {
            tFreqList.Text = "";
            cbAllFreq.Checked = false;
            cbDefaultFreq.Checked = false;
        }

        //private void btnAddUList_Click(object sender, EventArgs e)
        //{
        //    //int a;
        //    double n = 0;
        //    //int t=0;
        //    //double tt = 0;
        //    //int r;
        //    //double ee;


        //    double step = 0;
        //    double increment = 0;
        //    if (cWorkMode.Text == "C(dU)_man" || cWorkMode.Text == "C(dU)_auto")
        //    {
        //        if (cCUCycle.Text == "Full cycle")
        //        {
        //            step = (Double)((Convert.ToDouble(txtPointCountU.Text) / (4 * Convert.ToDouble(txtPeriodU.Text))));
        //        }
        //        else if (cCUCycle.Text == "Half cycle")
        //        {
        //            step = (Double)Convert.ToDouble(txtPointCountU.Text) / (2 * Convert.ToDouble(txtPeriodU.Text));
        //        }

        //        else if (cCUCycle.Text == "Points full cycle")
        //        {
        //            step = (Double)Convert.ToDouble(txtUmax.Text) / Convert.ToDouble(txtPointCountU.Text);
        //        }
        //        else if (cCUCycle.Text == "Points hulf cycle")
        //        {
        //            step = (Double)Convert.ToDouble(txtUmax.Text) / Convert.ToDouble(txtPointCountU.Text);
        //        }

        //        n = (double)Convert.ToDouble(txtUmax.Text) / step;


        //        if (cCUCycle.Text == "Points full cycle")
        //        {
        //            //tVoltageList.AppendText("0" + Environment.NewLine);
        //            increment = halfplus(increment, step);
        //            increment = halfplus_1(increment, step);
        //            increment = halfminus(increment, step);
        //            increment = halfminus_1(increment, step);
        //        }

        //        if (cCUCycle.Text == "Points hulf cycle")
        //        {
        //            increment = 0;
        //            //tVoltageList.AppendText("0" + Environment.NewLine);
        //            increment = halfplus(increment, step);
        //            increment = halfplus_1(increment, step);
        //        }
        //    }
        //}

        /// <summary>
        /// Halfpluses the 1.
        /// </summary>
        /// <param name="increment">The increment.</param>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        private double halfplus_1(double increment, double step)
        {
            //do
            //{
            //    increment = increment - step;
            //    tVoltageList.AppendText(increment.ToString() + Environment.NewLine);
            //} while (increment > 1);
            return increment;
        }
        private void txtCBF_TextChanged(object sender, EventArgs e)
        {

        }

        private void chTest_CheckedChanged(object sender, EventArgs e)
        {
            //if (chTest.Checked == true)
            //{
            //    cmbOperator.SelectedIndex = 0;
            //    txtComposition.Text = "FFFFF";
            //    cFreqMode.SelectedIndex = 2;
            //    txtTempEnd.Text = "310";
            //    cbGPIBDevModel.Text = "Agilent4980A";
            //    cbExportDBMeasTemp.SelectedIndex = 2;
            //}
            //else if (chTest.Checked == false)
            //{
            //    cmbOperator.SelectedIndex = -1;
            //    txtComposition.Text = "";
            //    cFreqMode.SelectedIndex = -1;
            //    txtTempEnd.Text = "973";
            //}

        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            //FileJob fj = new FileJob();
            //string[] str = new string[fj.ReadF("F:\\temp\\time.txt").Length];
            //str = fj.ReadF("F:\\temp\\time.txt");
            //tTimerList.Clear();
            //for (int i = 0; i < str.Length; i++)
            //{
            //    tTimerList.AppendText(str[i] + Environment.NewLine);
            //}


            //str = new string[fj.ReadF("F:\\temp\\volt.txt").Length];
            //str = fj.ReadF("F:\\temp\\volt.txt");
            //tVoltageList.Clear();
            //for (int i = 0; i < str.Length; i++)
            //{
            //    tVoltageList.AppendText(str[i] + Environment.NewLine);
            //}

        }

        private void txtUcur_TextChanged(object sender, EventArgs e)
        {

        }

        private void chExportToDB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbExportDBMeasTemp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cFreqMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPointCountU_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cDirect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void openFilevoltageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Objects ob = new Objects();
            ob.ExcelToDataGridView(dGridVolt);
            //opnFileVoltage.ShowDialog();
        }

        private void openFiletimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opnFileTimer.ShowDialog();
        }

        private void opnFileVoltage_FileOk(object sender, CancelEventArgs e)
        {



            //FileJob fj = new FileJob();
            //string[] str = new string[fj.ReadF(opnFileVoltage.FileName).Length];
            //str = fj.ReadF(opnFileVoltage.FileName);
            //tVoltageList.Clear();
            //for (int i = 0; i < str.Length; i++)
            //{
            //    tVoltageList.AppendText(str[i] + Environment.NewLine);
            //}
        }

        private void opnFileTimer_FileOk(object sender, CancelEventArgs e)
        {
            //FileJob fj = new FileJob();
            //string[] str = new string[fj.ReadF(opnFileTimer.FileName).Length];
            //str = fj.ReadF(opnFileTimer.FileName);
            //tTimerList.Clear();
            //for (int i = 0; i < str.Length; i++)
            //{
            //    tTimerList.AppendText(str[i] + Environment.NewLine);
            //}
        }
        /// <summary>
        /// Handles the Click event of the openFileexcelToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void openFileexcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opnFileExcel.ShowDialog();
            Objects objects = new Objects();
            objects.ExcelToDataGridView(dGridVolt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void opnFileExcel_FileOk(object sender, CancelEventArgs e)
        {
            //FileJob fj = new FileJob();
            //fj.LoadExcelFileToTxt(tVoltageList, tTimerList, opnFileExcel.FileName);
        }

        private void cbGPIBDevModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbGPIBDevModel.Text)
            {
                case "WayneKerr4300":
                    {
                        txtEndFreq.Text = "1000000";
                        break;
                    }
                default:
                    {
                        txtEndFreq.Text = "2000000";
                        break;
                    }
            }

        }

        private void FrmMeasTempOpt_Shown(object sender, EventArgs e)
        {
            txtHeight.Text = Properties.Settings.Default.defHeight;
            txtDiameter.Text = Properties.Settings.Default.defWidth;
        }

        private void FrmMeasTempOpt_VisibleChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defHeight = txtHeight.Text;
            Properties.Settings.Default.defWidth = txtDiameter.Text;
            Properties.Settings.Default.defTempEnd = txtTempEnd.Text;
            Properties.Settings.Default.defTempSint = txtTempSint.Text;
            Properties.Settings.Default.defOperator = cmbOperator.Text;
            Properties.Settings.Default.defDevice = cbGPIBDevModel.Text;
            Properties.Settings.Default.defExportMod = cbExportDBMeasTemp.Text;
            Properties.Settings.Default.defComposition = txtComposition.Text;
            Properties.Settings.Default.deftempStep = txtTempStep.Text;
            Properties.Settings.Default.defNewCycleTemp = txtNewCycleTemp.Text;
            Properties.Settings.Default.defFreq = tFreqList.Text;
            Properties.Settings.Default.defGraphMode = cbGraphOptions.Text;
            Properties.Settings.Default.defWorkMode = cWorkMode.Text;
            Properties.Settings.Default.defTempList = tTempList.Text;
            Properties.Settings.Default.defFreqStart = txtStartFreq.Text;
            Properties.Settings.Default.defFreqEnd = txtEndFreq.Text;
            Properties.Settings.Default.defFreqStep = Convert.ToInt32(txtStepFreq.Text);

            Properties.Settings.Default.defParamACTE = txtApproxCTE_A_20.Text;
            Properties.Settings.Default.defParamBCTE = txtApproxCTE_B_20.Text;

            Properties.Settings.Default.defParamSolidState = cmbSolidState.Text;
            Properties.Settings.Default.defParam_r_exp = Convert.ToDouble(txtRoExp.Text);
            Properties.Settings.Default.defParamSampleNum = txtSampleNumber.Text;

            Properties.Settings.Default.defFreqMode = cFreqMode.Text;

            #region d33 approximation 
            //Properties.Settings.Default.defParamA_d33_20 = Convert.ToDouble(txtApproxD33_A_20.Text);
            //Properties.Settings.Default.defParamB_d33_20 = Convert.ToDouble(txtApproxD33_B_20.Text);

            //Properties.Settings.Default.defParamA_d33_200 = Convert.ToDouble(txtApproxD33_A_200.Text);
            //Properties.Settings.Default.defParamB_d33_200 = Convert.ToDouble(txtApproxD33_B_200.Text);
            //Properties.Settings.Default.defParamA_d33_2000 = Convert.ToDouble(txtApproxD33_A_2000.Text);
            //Properties.Settings.Default.defParamB_d33_2000 = Convert.ToDouble(txtApproxD33_B_2000.Text);
            #endregion
            switch (cWorkMode.Text)
            {
                case "Magnit_hand":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAMagnit;
                        txtApproxB.Text = Properties.Settings.Default.defParamBMagnit;
                        txtApproxC.Text = Properties.Settings.Default.defParamCMagnit;
                        break;
                    }
                case "C(dU)_hand_reversive":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAReversive;
                        txtApproxB.Text = Properties.Settings.Default.defParamBReversive;
                        txtApproxC.Text = Properties.Settings.Default.defParamCReversive;
                        break;
                    }
                case "d33Rev":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAd33;
                        txtApproxB.Text = Properties.Settings.Default.defParamBd33;
                        txtApproxC.Text = Properties.Settings.Default.defParamCd33;
                        break;
                    }
                default:
                    break;
            }





            Properties.Settings.Default.Save();
        }
        /// <summary>
        /// Handles the Load event of the frmMeasTempOpt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void frmMeasTempOpt_Load(object sender, EventArgs e)
        {
            txtHeight.Text = Properties.Settings.Default.defHeight;
            txtDiameter.Text = Properties.Settings.Default.defWidth;
            txtTempEnd.Text = Properties.Settings.Default.defTempEnd;
            txtTempSint.Text = Properties.Settings.Default.defTempSint;
            cmbOperator.Text = Properties.Settings.Default.defOperator;
            cbGPIBDevModel.Text = Properties.Settings.Default.defDevice;
            cbExportDBMeasTemp.Text = Properties.Settings.Default.defExportMod;
            txtComposition.Text = Properties.Settings.Default.defComposition;
            txtTempStep.Text = Properties.Settings.Default.deftempStep;
            txtNewCycleTemp.Text = Properties.Settings.Default.defNewCycleTemp;
            tFreqList.Text = Properties.Settings.Default.defFreq;
            cbGraphOptions.Text = Properties.Settings.Default.defGraphMode;
            cWorkMode.Text = Properties.Settings.Default.defWorkMode;
            tTempList.Text = Properties.Settings.Default.defTempList;
            txtStartFreq.Text = Properties.Settings.Default.defFreqStart;
            txtEndFreq.Text = Properties.Settings.Default.defFreqEnd;
            txtApproxCTE_A_20.Text = Properties.Settings.Default.defParamA_CTE_20.ToString();
            txtApproxCTE_B_20.Text = Properties.Settings.Default.defParamB_CTE_20.ToString();
            txtApproxCTE_A_200.Text = Properties.Settings.Default.defParamA_CTE_200.ToString();
            txtApproxCTE_B_200.Text = Properties.Settings.Default.defParamB_CTE_200.ToString();
            txtApproxCTE_A_2000.Text = Properties.Settings.Default.defParamA_CTE_2000.ToString();
            txtApproxCTE_B_2000.Text = Properties.Settings.Default.defParamB_CTE_2000.ToString();

            txtApproxD33_A_20.Text = Properties.Settings.Default.defParamA_d33_20.ToString();
            txtApproxD33_B_20.Text = Properties.Settings.Default.defParamB_d33_20.ToString();
            txtApproxD33_A_200.Text = Properties.Settings.Default.defParamA_d33_200.ToString();
            txtApproxD33_B_200.Text = Properties.Settings.Default.defParamB_d33_200.ToString();
            txtApproxD33_A_2000.Text = Properties.Settings.Default.defParamA_d33_2000.ToString();
            txtApproxD33_B_2000.Text = Properties.Settings.Default.defParamB_d33_2000.ToString();

            txtApproxU_d33_A.Text = Properties.Settings.Default.defParamA_U_d33.ToString();
            txtApproxU_d33_B.Text = Properties.Settings.Default.defParamB_U_d33.ToString();
            cmbSolidState.Text = Properties.Settings.Default.defParamSolidState;
            txtRoExp.Text = Properties.Settings.Default.defParam_r_exp.ToString();
            txtSampleNumber.Text = Properties.Settings.Default.defParamSampleNum.ToString();

            cFreqMode.Text = Properties.Settings.Default.defFreqMode;


            switch (cWorkMode.Text)
            {
                case "Magnit_hand":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAMagnit;
                        txtApproxB.Text = Properties.Settings.Default.defParamBMagnit;
                        txtApproxC.Text = Properties.Settings.Default.defParamCMagnit;
                        break;
                    }
                case "C(dU)_hand_reversive":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAReversive;
                        txtApproxB.Text = Properties.Settings.Default.defParamBReversive;
                        txtApproxC.Text = Properties.Settings.Default.defParamCReversive;
                        break;
                    }
                case "d33Rev":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAd33;
                        txtApproxB.Text = Properties.Settings.Default.defParamBd33;
                        txtApproxC.Text = Properties.Settings.Default.defParamCd33;
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// fill combobox meas model 
        /// </summary>
        void FillMeasModel()
        { 
        foreach (var item in Constants.MeasModel)
            {
                cbGPIBDevModel.Items.Add(item);
            }
        }
        /// <summary>
        /// fill combobox export type for DB
        /// </summary>
        void FillcdExportTypeToDB()
        {
            foreach (var item in Constants.export_types_DB)
            {
                cbExportDBMeasTemp.Items.Add(item);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        void FillCbMeasType()
        {
            foreach (var item in Constants.MeasurmentTypes)
            {
                cWorkMode.Items.Add(item);
            }
        }
        /// <summary>
        /// Fill list of frequency type
        /// </summary>
        void FillCbFreqMode()
        {
            foreach (var item in Constants.freqTypes)
            {
                cFreqMode.Items.Add(item);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the CWorkMode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CWorkMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cWorkMode.Text)
            {
                case "Magnit_hand":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAMagnit;
                        txtApproxB.Text = Properties.Settings.Default.defParamBMagnit;
                        txtApproxC.Text = Properties.Settings.Default.defParamCMagnit;
                        break;
                    }
                case "C(dU)_hand_reversive":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAReversive;
                        txtApproxB.Text = Properties.Settings.Default.defParamBReversive;
                        txtApproxC.Text = Properties.Settings.Default.defParamCReversive;
                        break;
                    }
                case "d33Rev":
                    {
                        txtApproxA.Text = Properties.Settings.Default.defParamAd33;
                        txtApproxB.Text = Properties.Settings.Default.defParamBd33;
                        txtApproxC.Text = Properties.Settings.Default.defParamCd33;
                        break;
                    }
                default:
                    break;
            }

        }

        private void Label37_Click(object sender, EventArgs e)
        {

        }

        private void TxtApproxA_TextChanged(object sender, EventArgs e)
        {
            switch (cWorkMode.Text)
            {
                case "Magnit_hand":
                    {
                        Properties.Settings.Default.defParamAMagnit = txtApproxA.Text;
                        break;
                    }
                case "C(dU)_hand_reversive":
                    {
                        Properties.Settings.Default.defParamAReversive = txtApproxA.Text;
                        break;
                    }
                case "d33Rev":
                    {
                        Properties.Settings.Default.defParamAd33 = txtApproxA.Text;
                        break;
                    }
                default:
                    break;
            }
        }

        private void TxtApproxB_TextChanged(object sender, EventArgs e)
        {
            switch (cWorkMode.Text)
            {
                case "Magnit_hand":
                    {
                        Properties.Settings.Default.defParamBMagnit = txtApproxB.Text;
                        break;
                    }
                case "C(dU)_hand_reversive":
                    {
                        Properties.Settings.Default.defParamBReversive = txtApproxB.Text;
                        break;
                    }
                case "d33Rev":
                    {
                        Properties.Settings.Default.defParamBd33 = txtApproxB.Text;
                        break;
                    }
                default:
                    break;
            }

        }

        private void TxtApproxC_TextChanged(object sender, EventArgs e)
        {
            switch (cWorkMode.Text)
            {
                case "Magnit_hand":
                    {
                        Properties.Settings.Default.defParamCMagnit = txtApproxC.Text;
                        break;
                    }
                case "C(dU)_hand_reversive":
                    {
                        Properties.Settings.Default.defParamCReversive = txtApproxC.Text;
                        break;
                    }
                case "d33Rev":
                    {
                        Properties.Settings.Default.defParamCd33 = txtApproxC.Text;
                        break;
                    }
                default:
                    break;
            }

        }

        private void txtApproxCTE_A_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamA_CTE_20 = Convert.ToDouble(txtApproxCTE_A_20.Text);
        }

        private void txtApproxCTE_B_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamB_CTE_20 = Convert.ToDouble(txtApproxCTE_B_20.Text);
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void txtApproxD33_A_20_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamA_d33_20 = Convert.ToDouble(txtApproxD33_A_20.Text);

        }

        private void txtApproxD33_B_20_TextChanged(object sender, EventArgs e)
        {

            Properties.Settings.Default.defParamB_d33_20 = Convert.ToDouble(txtApproxD33_B_20.Text);

        }

        private void txtApproxD33_A_200_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamA_d33_200 = Convert.ToDouble(txtApproxD33_A_200.Text);

        }

        private void txtApproxD33_B_200_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamB_d33_200 = Convert.ToDouble(txtApproxD33_B_200.Text);
        }

        private void txtApproxD33_A_2000_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamA_d33_2000 = Convert.ToDouble(txtApproxD33_A_2000.Text);

        }

        private void txtApproxD33_B_2000_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamB_d33_2000 = Convert.ToDouble(txtApproxD33_B_2000.Text);
        }

        private void txtApproxU_d33_A_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamA_U_d33 = Convert.ToDouble(txtApproxU_d33_A.Text);
        }

        private void txtApproxU_d33_B_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamB_U_d33 = Convert.ToDouble(txtApproxU_d33_B.Text);
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamA_CTE_2000 = Convert.ToDouble(txtApproxCTE_A_2000.Text);
        }

        private void txtApproxCTE_A_200_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamA_CTE_200 = Convert.ToDouble(txtApproxCTE_A_200.Text);
        }

        private void txtApproxCTE_B_200_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamB_CTE_200 = Convert.ToDouble(txtApproxCTE_B_200.Text);
        }

        private void txtApproxCTE_B_2000_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamB_CTE_2000 = Convert.ToDouble(txtApproxCTE_B_2000.Text);
        }

        private void DGTempData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Objects ob = new Objects();

                ob.ExcelToDataGridView(DGTempData);
                //int rCnt;
                //int cCnt;
                //OpenFileDialog opf = new OpenFileDialog();
                //opf.Filter = "Файл Excel|*.XLSX;*.XLS";
                //opf.ShowDialog();
                //System.Data.DataTable tb = new System.Data.DataTable();
                //string filename = opf.FileName;
                //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                //Microsoft.Office.Interop.Excel._Workbook ExcelWorkBook;
                //Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Microsoft.Office.Interop.Excel.Range ExcelRange;

                //ExcelWorkBook = ExcelApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false,
                //    false, 0, true, 1, 0);
                //ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                //ExcelRange = ExcelWorkSheet.UsedRange;
                //for (rCnt = 2; rCnt <= ExcelRange.Rows.Count; rCnt++)
                //{
                //    DGTempData.Rows.Add(1);
                //    for (cCnt = 1; cCnt <= 2; cCnt++)
                //    {
                //        //DGTempData.Rows.Add(1);
                //        DGTempData.Rows[rCnt-2].Cells[cCnt-1].Value = ExcelApp.Cells[rCnt, cCnt].Value;
                //    }
                //}
                //ExcelWorkBook.Close(true, null, null);
                //ExcelApp.Quit();
            }
        }

        private void DGTempData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DGTempData_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void btnAddTemp_Click_1(object sender, EventArgs e)
        {

        }

        private void cmbSolidState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamSolidState = cmbSolidState.Text;
        }

        private void txtRoExp_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParam_r_exp = Convert.ToDouble(txtRoExp.Text);
        }

        private void txtSampleNumber_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defParamSampleNum = txtSampleNumber.Text;
        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {

        }

        private void cWorkMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        
        private void btnAddFreqUbias_Click(object sender, EventArgs e)
        {
            if (cWorkMode.Text == "CTE_S33_fr")
            {
                PiezoMathCalculation PM = new PiezoMathCalculation();
                #region cleardatagridview
                int rowsCount = dGridVolt.Rows.Count;
                for (int i = 0; i < rowsCount-1; i++)
                {
                    dGridVolt.Rows.Remove(dGridVolt.Rows[0]);
                }
                #endregion
                

                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!rebuild function of array filling
                PP.array_u = new int[Convert.ToInt32(txtStepFreq.Text)];
                PP.array_f_fr = new int[Convert.ToInt32(txtPointCountU.Text)];
                PP.array_u = PM.getArrayFromStartEndCountVals(Convert.ToInt32(txtUmin.Text), Convert.ToInt32(txtUmax.Text), Convert.ToInt32(txtPointCountU.Text));
                PP.array_f_fr = PM.getArrayFromStartEndCountVals(Convert.ToInt32(txtStartFreq.Text), Convert.ToInt32(txtEndFreq.Text), Convert.ToInt32(txtStepFreq.Text));
                for (int i = 0; i < PP.array_u.Count(); i++)
                {
                    for (int j = 0; j < PP.array_f_fr.Count(); j++)
                    {
                        this.dGridVolt.Rows.Add(i.ToString(), 300,1, PP.array_u[i].ToString(), PP.array_f_fr[j].ToString());
                    }
                }

                for (int i = PP.array_u.Count() - 2; i > -1; i--)
                {
                    for (int j = 0; j < PP.array_f_fr.Count(); j++)
                    {
                        this.dGridVolt.Rows.Add(i.ToString(), 300, 1, (PP.array_u[i]).ToString(), PP.array_f_fr[j].ToString());
                    }
                }

                for (int i = 0; i < PP.array_u.Count(); i++)
                {
                    for (int j = 0; j < PP.array_f_fr.Count(); j++)
                    {
                        this.dGridVolt.Rows.Add(i.ToString(), 300, 1, (-1* PP.array_u[i]).ToString(), PP.array_f_fr[j].ToString());
                    }
                }

                for (int i = PP.array_u.Count()-2; i > -1; i--)
                {
                    for (int j = 0; j < PP.array_f_fr.Count(); j++)
                    {
                        this.dGridVolt.Rows.Add(i.ToString(), 300, 1, (-1*PP.array_u[i]).ToString(), PP.array_f_fr[j].ToString());
                    }
                }
            }
        }

        private void cFreqMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (cFreqMode.Text)
            {
                case "f1_f3":
                    {
                        txtStartFreq.Text = 200000.ToString();
                        txtEndFreq.Text = 300000.ToString();
                        txtStepFreq.Text = 100.ToString();
                        break;
                    }
                default:
                    {
                        txtStartFreq.Text = 20.ToString();
                        txtEndFreq.Text = 2000000.ToString();
                        txtStepFreq.Text = 1000.ToString();
                        txtCoefficient.Text = 1.3.ToString();
                    }
                    break;
            }
            
        }



    }
}
