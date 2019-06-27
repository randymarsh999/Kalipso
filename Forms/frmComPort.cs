using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Kalipso
{
    /// <summary>
    /// Stuct contain active com port and device name
    /// </summary>
    public struct AllComPorts
    {
        /// <summary>
        /// Gets or sets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        public string DeviceName { get; set; }
        /// <summary>
        /// Gets or sets the active port.
        /// </summary>
        /// <value>
        /// The active port.
        /// </value>
        public SerialPort ActivePort { get; set; }
        /// <summary>
        /// Sets the information.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Port">The port.</param>
        public void SetInfo(string Name, SerialPort Port)
        {
            this.DeviceName = Name;
            this.ActivePort = Port;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class frmComPort : Form
    {
        /// <summary>
        /// Array of struct AllComPorts
        /// </summary>
        public AllComPorts[] allComPort = new AllComPorts[10];


        SerialPort ActivePort = new SerialPort();
        /// <summary>
        /// массив Com портов
        /// </summary>
        public SerialPort[] ActivePorts;
        /// <summary>
        /// массив названий устройств
        /// </summary>
        public string[] deviceName;
        /// <summary>
        /// Com port count
        /// </summary>
        public int ColPort { set; get; }
        /// <summary>
        /// Температура поступающая с термоконтроллера
        /// </summary>
        public string Temperature { set; get; }
        /// <summary>
        /// Температура поступающая с термоконтроллера (резервная)
        /// </summary>
        public string TemperatureReserv { set; get; }
        /// <summary>
        /// Controller name
        /// </summary>
        private string Controller { get; set; }

        public byte[] DevBuf; 
        
        /// <summary>
        /// Constrctor of comport class
        /// </summary>
        public frmComPort()
        {
            InitializeComponent();
            cbComDevice.SelectedIndex = 0;
            ColPort = 0;
            Temperature = 300.ToString();
            TemperatureReserv = 300.ToString();
        }
        /// <summary>
        /// Показать все возможные Com порты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowPorts_Click(object sender, EventArgs e)
        {
            //SerialPort port = new SerialPort();
            // получаем список доступных портов
            string[] ports = SerialPort.GetPortNames();
            cmbComPortList.Items.Clear();
            for (int i = 0; i < ports.Length; i++)
            //for (int i = ports.Length+1; i> 0  ; i--)
            {
                cmbComPortList.Items.Add(ports[i].ToString());
                ColPort = ports.Length;
            }
            cmbComPortList.SelectedIndex = 0;
            //инициализация массива Com портов
            ActivePorts = new SerialPort[cmbComPortList.Items.Count];
            deviceName = new string[cmbComPortList.Items.Count];
            for (int i = 0; i < cmbComPortList.Items.Count; i++)
            {
                ActivePorts[i] = new SerialPort();
            }
        }
        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmComPort_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Hide();
            if (tComPort.Enabled == true)
            {

            }
            this.Close();
        }


        ///it's not used
        /// <summary>
        /// Открытие выбранного Com порта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenComPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbComDevice.SelectedIndex == 0)
                {
                    //настройки порта Варта
                    ActivePort.PortName = cmbComPortList.SelectedItem.ToString();
                    ActivePort.BaudRate = 9600;
                    ActivePort.DataBits = 7;
                    ActivePort.Parity = System.IO.Ports.Parity.None;
                    ActivePort.StopBits = System.IO.Ports.StopBits.Two;

                    tComPortVarta.Enabled = true;
                }
                if (cbComDevice.SelectedIndex == 1)
                {
                    // настройки порта LakeShore
                    ActivePort.PortName = cmbComPortList.SelectedItem.ToString();
                    ActivePort.BaudRate = 9600;
                    ActivePort.DataBits = 8;
                    ActivePort.Parity = Parity.None;
                    //ActivePort.ErrorReceived = false;
                    ActivePort.DiscardNull = false;
                    //ActivePort.RtsEnable = RTS_CONTROL_DISABLE;
                    ActivePort.ReadTimeout = 5;

                    ActivePort.Parity = System.IO.Ports.Parity.None;
                    ActivePort.StopBits = System.IO.Ports.StopBits.One;
                }
                // настройки порта для ИТР2523
                if (cbComDevice.SelectedIndex == 2)
                {
                    // настройки порта
                    ActivePort.PortName = cmbComPortList.SelectedItem.ToString();
                    ActivePort.BaudRate = 9600;
                    ActivePort.DataBits = 7;
                    ActivePort.Parity = System.IO.Ports.Parity.None;
                    ActivePort.StopBits = System.IO.Ports.StopBits.Two;
                }
                ActivePort.Open();
                tComPort.Enabled = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: невозможно открыть порт:" + ex.ToString());
                return;
            }
        }
        /// <summary>
        /// Закрытие активного Com порта (it's not used)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseComPort_Click(object sender, EventArgs e)
        {
            try
            {
                tComPort.Enabled = false;
                ActivePort.Close();
                ActivePorts[cmbComPortList.SelectedIndex].Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: невозможно закрыть порт:" + ex.ToString());
                return;
            }
        }
        /// <summary>
        /// Передача строки в ComPort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransmitDataComPort_Click(object sender, EventArgs e)
        {
            //ActivePort.Write(txtTransmit.Text.ToString());
            ActivePorts[cmbComPortList.SelectedIndex].Write(txtTransmit.Text.ToString());
        }
        /// <summary>
        /// Работа таймера 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComPort_Tick(object sender, EventArgs e)
        {
            textBox2.Text = "2";

            switch (cbComDevice.Text)
            {
                case "Varta703I":
                    {
                        GetTempVarta703I(0);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// Gets the temporary varta703 i.
        /// </summary>
        public void GetTempVarta703I(int i)
        {
            string s = "";
            try
            {
                s = ActivePorts[i].ReadExisting();
                s = s.Substring(1, 4);
                Temperature = (Convert.ToInt32(s) + 273).ToString();
                TemperatureReserv = (Convert.ToInt32(s) + 273).ToString();
                txtReadString.Text = Temperature.ToString();
            }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
            catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
            {
                Temperature = TemperatureReserv;
                txtReadString.Text = Temperature.ToString();
            }
        }
        /// <summary>
        /// Задать тип термоконтроллера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTermoControllers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller = cbComDevice.SelectedItem.ToString();
        }
        /// <summary>
        /// Handles the Click event of the btnOpenPortDif control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOpenPortDif_Click(object sender, EventArgs e)
        {
            openRandomPort();
        }
        /// <summary>
        /// Open Com Port and configurate 
        /// </summary>
        private void openRandomPort()
        {
            SerialPort ComP = new SerialPort();
            try
            {
                for (int i = 0; i < allComPort.Count(); i++)
                {
                    switch (cbComDevice.Text)
                    {
                        case "Varta703I":
                            {
                                ComP.BaudRate = Convert.ToInt32(cmbBaudRate.Text);
                                ComP.DataBits = 7;
                                ComP.Parity = System.IO.Ports.Parity.None;
                                ComP.StopBits = System.IO.Ports.StopBits.Two;
                                break;
                            }
                        case "LakeShore":
                            {
                                ComP.BaudRate = Convert.ToInt32(cmbBaudRate.Text); ;
                                ComP.DataBits = 8;
                                ComP.Parity = Parity.None;
                                ComP.DiscardNull = false;
                                ComP.ReadTimeout = 5;
                                ComP.Parity = System.IO.Ports.Parity.None;
                                ComP.StopBits = System.IO.Ports.StopBits.One;
                                break;
                            }
                        case "ITR2523":
                            {
                                ComP.BaudRate = Convert.ToInt32(cmbBaudRate.Text); ;
                                ComP.DataBits = 7;
                                ComP.Parity = System.IO.Ports.Parity.None;
                                ComP.StopBits = System.IO.Ports.StopBits.Two;
                                break;
                            }
                        case "ArduinoUno":
                            {
                                ComP.BaudRate = Convert.ToInt32(cmbBaudRate.Text);
                                ComP.DataBits = 8;
                                ComP.Parity = System.IO.Ports.Parity.None;
                                ComP.StopBits = System.IO.Ports.StopBits.One;
                                break;
                            }
                        case "VoltageMeter HY-AV51-T":
                            {
                                ComP.BaudRate = Convert.ToInt32(cmbBaudRate.Text);
                                ComP.Handshake = Handshake.None;
                                ComP.DataBits = 8;
                                ComP.Parity = System.IO.Ports.Parity.None;
                                ComP.StopBits = System.IO.Ports.StopBits.One;
                                break;
                            }
                        case "E7-20":
                            {
                                ComP.BaudRate = Convert.ToInt32(cmbBaudRate.Text);
                                ComP.Handshake = Handshake.None;
                                ComP.DataBits = 8;
                                ComP.Parity = System.IO.Ports.Parity.None;
                                ComP.StopBits = System.IO.Ports.StopBits.One;

                                //timer1.Enabled = true;
                                break;
                            }
                        default:
                            {
                                break;
                            }

                    }

                    if (allComPort[i].DeviceName == null && ComP.IsOpen == false)
                    {
                        ComP.PortName = cmbComPortList.SelectedItem.ToString();
                        ComP.Open();
                        allComPort[i].ActivePort = ComP;
                        allComPort[i].DeviceName = cbComDevice.Text;
                        txtComLog.AppendText(Environment.NewLine+ cmbComPortList.SelectedItem.ToString() + " was opened" + Environment.NewLine);

                        //if (cbComDevice.Text == "Varta703I")
                        //    {
                        //        tComPortVarta.Enabled = true;
                        //    }
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: невозможно открыть порт:" + ex.ToString());
                return;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public void TransmitStringToArduiono(string s)
        {
            for (int i = 0; i < allComPort.Count(); i++)
            {
                if (allComPort[i].DeviceName == "ArduinoUno")
                {
                    try
                    {
                        if (allComPort[i].ActivePort.IsOpen)
                        {
                            allComPort[i].ActivePort.Write(s);
                        }
                    }
                    catch (Exception ex)
                    {
                        txtComLog.Text = ex.ToString();
                    }
                }
            }
        }
        /// <summary>
        /// Handles the Click event of the btnTransmitCMD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void btnTransmitCMD_Click(object sender, EventArgs e)
        {
            switch (cbComDevice.Text)
            {
                case "ArduinoUno":
                    {
                        SendDataToComPort(cbComDevice.Text, txtTransmit.Text);
                        txtComLog.AppendText(Environment.NewLine + GetDataFromComPort(cbComDevice.Text));
                        break;
                    }
                case "Varta703I":
                    {
                        bool was = tComPortVarta.Enabled;
                        if (was == true)
                        {
                            tComPortVarta.Enabled = false;
                            SendDataToComPort(cbComDevice.Text, txtTransmit.Text);
                            tComPortVarta.Enabled = true;
                        }
                        if (was == false)
                        {
                            SendDataToComPort(cbComDevice.Text, txtTransmit.Text);
                            txtComLog.AppendText(ComReadString() + Environment.NewLine);
                        }
                        break;
                    }
                case "VoltageMeter HY-AV51-T":
                    {

                        short[] values = new short[40];
                        values = GetDataFromVoltageMeter_HY_AV51_T1();

                        short[] valueArray = new short[2];
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
                            default:
                                break;
                        }
                        txtComLog.AppendText(Environment.NewLine + (valueConv[0]));
                        txtComLog.AppendText(Environment.NewLine + (val_out));
                        txtComLog.AppendText(Environment.NewLine + (23.81 * val_out - 16.464));
                        break;

                    }
                case "E7-20":
                    {
                        byte[] data = new byte[2];
                        //allComPort[j].ActivePort.Write(new byte[] { 0x01, 0x03, 0x00, 0x00, 0x00, 0x28, 0x45, 0xd4 }, 0, 8);
                        ////var byteBuffer = new byte[max];
                        ////allComPort[j].ActivePort.Read(byteBuffer, offset, byteBuffer.Length - offset);
                        //System.Threading.Thread.Sleep(300);
                        //int byteRecieved = allComPort[j].ActivePort.BytesToRead;
                        data[0] = 0x0;
                        SendDataToComPort(cbComDevice.Text, data);
                        break;
                    }
                default:
                    break;
            }
        }
        /// <summary>
        /// Handles the Tick event of the tComPortVarta control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void tComPortVarta_Tick(object sender, EventArgs e)
        {
            //GetDataFromVarta();
            GetDataFromVarta("Varta703I");
            if (Temperature != "")
            {
                txtComLog.AppendText(Temperature + Environment.NewLine);
            }
            else txtComLog.AppendText(TemperatureReserv + Environment.NewLine);
        }
        /// <summary>
        /// Gets the data from varta.
        /// </summary>
        /// <param name="dev">The dev.</param>
        public void GetDataFromVarta(string dev)
        {
            for (int j = 0; j < allComPort.Count(); j++)
            {
                if (allComPort[j].DeviceName == dev)
                {
                    string s = GetDataFromComPort(dev);
                    Temperature = ConvertDataToTempVarta(s);
                    if (s != "")
                    {
                        TemperatureReserv = ConvertDataToTempVarta(s);
                    }
                    return;
                }
            }

        }
        /// <summary>
        /// Get data from Varta 703I
        /// </summary>
        public void GetDataFromVarta()
        {
            bool varta=false;
            for (int j = 0; j < allComPort.Count() - 1; j++)
            {
                if (allComPort[j].DeviceName == "Varta703I")
                {
                    Temperature = ConvertDataToTempVarta(GetDataFromComPort(j));
                    varta = true;
                    if (Temperature != "")
                    {
                        TemperatureReserv = Temperature;
                    }
                    else Temperature = 27.ToString();

                }

            }
            if (varta==false)
            {
                Temperature = 27.ToString();
            }
        }
        /// <summary>
        /// Get data from Varta 703I
        /// </summary>
        /// <param name="i"></param>
        public void GetDataFromVarta(int i)
        {
            string s = "";
            try
            {
                s = allComPort[i].ActivePort.ReadExisting();
                s = s.Substring(1, 4);
                Temperature = (Convert.ToInt32(s) + 273).ToString();
                TemperatureReserv = (Convert.ToInt32(s) + 273).ToString();
                txtReadString.Text = Temperature.ToString();
            }
#pragma warning disable CS0168 // Переменная "ex" объявлена, но ни разу не использована.
            catch (Exception ex)
#pragma warning restore CS0168 // Переменная "ex" объявлена, но ни разу не использована.
            {
                Temperature = TemperatureReserv;
                txtReadString.Text = Temperature.ToString();
            }
        }
        /// <summary>
        /// Gets the temporary varta703 i in mas.
        /// </summary>
        public void GetTempVarta703IInMas()
        {
            for (int i = 0; i < deviceName.Length; i++)
            {
                if (deviceName[i] == "Varta703I")
                {
                    string s = "";
                    try
                    {
                        s = ActivePorts[i].ReadExisting();
                        s = s.Substring(1, 4);
                        Temperature = (Convert.ToInt32(s) + 273).ToString();
                        TemperatureReserv = (Convert.ToInt32(s) + 273).ToString();
                        txtReadString.Text = Temperature.ToString();
                    }
                    catch (Exception ex)
                    {
                        Temperature = TemperatureReserv;
                        txtReadString.Text = Temperature.ToString();
                        ex.ToString();
                    }
                }
            }
        }
        /// <summary>
        /// Get data from Com port using struct
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Data in string type</returns>
        public string GetDataFromComPort(int i)
        {
            try
            {
                return allComPort[i].ActivePort.ReadExisting();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        /// <summary>
        /// Gets the data from COM port.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns></returns>
        public string GetDataFromComPort(string device)
        {
            string s = "";
            try
            {
                for (int i = 0; i < allComPort.Count(); i++)
                {
                    if (allComPort[i].DeviceName == device)
                    {
                        s = allComPort[i].ActivePort.ReadExisting();
                        return s;
                    }
                }
                return s;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        /// <summary>
        /// Converting data from Varta
        /// </summary>
        /// <param name="s">Data to convert</param>
        /// <returns>Return temperature in string type</returns>
        public string ConvertDataToTempVarta(string s)
        {
            if (s != "")
            {
                Int32 ww = Convert.ToInt32(s.Substring(1, 4));
                return (Convert.ToInt32(s.Substring(1, 4))).ToString();
            }
            else return "";
        }

        private void btnClosePorts_Click(object sender, EventArgs e)
        {
            closeRandomPort(cbComDevice.Text);
        }
        /// <summary>
        /// Close for random com port
        /// </summary>
        public void closeRandomPort()
        {
            try
            {
                for (int i = 0; i < allComPort.Count(); i++)
                {
                    if (allComPort[i].ActivePort.PortName == cmbComPortList.Text)
                    {
                        if (allComPort[i].ActivePort.IsOpen == true)
                        {
                            allComPort[i].ActivePort.Close();
                            allComPort[i].DeviceName = "";
                            txtComLog.AppendText(Environment.NewLine + cmbComPortList.SelectedItem.ToString() + " closed");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtComLog.Text = "ERROR: com port is not closed " + ex.ToString();
                return;
            }
        }
        /// <summary>
        /// Closes the random port.
        /// </summary>
        /// <param name="i">The i.</param>
        public void closeRandomPort(int i)
        {
            try
            {
                if (allComPort[i].ActivePort.IsOpen == true)
                {
                    allComPort[i].ActivePort.Close();
                    allComPort[i].DeviceName = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                txtComLog.Text = "ERROR: com port is not closed " + ex.ToString();
                return;
            }
        }
        /// <summary>
        /// Closes the random port.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="device">The device.</param>
        public void closeRandomPort(int i, string device)
        {
            try
            {
                if (allComPort[i].DeviceName == device && allComPort[i].ActivePort.IsOpen == true)
                {
                    allComPort[i].ActivePort.Close();
                    allComPort[i].DeviceName = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                txtComLog.Text = "ERROR: com port is not closed " + ex.ToString();
                return;
            }
        }
        /// <summary>
        /// Closes the random port.
        /// </summary>
        /// <param name="device">The device.</param>
        public void closeRandomPort(string device)
        {
            try
            {
                for (int i = 0; i < allComPort.Count(); i++)
                {
                    if (allComPort[i].DeviceName == device && allComPort[i].ActivePort.IsOpen == true)
                    {
                        if (allComPort[i].DeviceName=="E7-20")
                        {
                            timer1.Enabled = false;
                        }
                        
                        allComPort[i].ActivePort.Close();
                        allComPort[i].DeviceName = "";
                        txtComLog.AppendText(Environment.NewLine+ cmbComPortList.SelectedItem + " closed");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                txtComLog.Text = "ERROR: com port is not closed " + ex.ToString();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            GetDataFromComPort("timerArduinoIn");
        }
        /// <summary>
        /// Send data to device via com port using com name
        /// </summary>
        /// <param name="device">Device name ITT, Varta ...</param>
        /// <param name="data">string to transmit</param>
        public void SendDataToComPort(string device, string data)
        {
            try
            {
                for (int i = 0; i < allComPort.Count(); i++)
                {
                    if (allComPort[i].DeviceName == device)
                    {
                        if (allComPort[i].ActivePort.IsOpen == true)
                        {
                            allComPort[i].ActivePort.Write(data + "\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtComLog.Text = "ERROR: " + ex.ToString();
                return;
            }
        }

        /// <summary>
        /// Sends the data to COM port.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="data">The data.</param>
        public void SendDataToComPort(string device, byte[] data)
        {
            try
            {
                for (int i = 0; i < allComPort.Count(); i++)
                {
                    if (allComPort[i].DeviceName == device)
                    {
                        if (allComPort[i].ActivePort.IsOpen == true)
                        {
                            allComPort[i].ActivePort.Write(data, 0, 1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtComLog.Text = "ERROR: " + ex.ToString();
                return;
            }
        }
        /// <summary>
        /// Sends the data to COM port.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="data">string to transmit</param>
        public void SendDataToComPort(object value, string data)
        {
            try
            {
                for (int i = 0; i < allComPort.Count(); i++)
                {
                    if (allComPort[i].ActivePort.PortName == Convert.ToString(value))
                    {
                        if (allComPort[i].ActivePort.IsOpen == true)
                        {
                            allComPort[i].ActivePort.Write(data);
                        }
                    }
                    else txtComLog.Text = "Com port " + cmbComPortList.Text + " is closed";
                }
            }
            catch (Exception ex)
            {
                txtComLog.Text = "ERROR: com " + ex.ToString();
                return;
            }
        }
        /// <summary>
        /// Send data to device via com port using com name, device name 
        /// </summary>
        /// <param name="Comport">Com port name COM1, COM2 ...</param>
        /// <param name="device">Device name ITT, Varta ...</param>
        /// <param name="data">string to transmit</param>
        public void SendDataToComPort(string Comport, string device, string data)
        {
            try
            {
                for (int i = 0; i < allComPort.Count(); i++)
                {
                    if (allComPort[i].ActivePort.PortName == Comport)
                    {
                        if (allComPort[i].ActivePort.IsOpen == true)
                        {
                            allComPort[i].ActivePort.Write(data);
                        }
                    }
                    else txtComLog.Text = "Com port " + cmbComPortList.Text + " is closed";
                }
            }
            catch (Exception ex)
            {
                txtComLog.Text = "ERROR: " + ex.ToString();
                return;
            }
        }
        /// <summary>
        /// Gets the data from voltage meter hy a V51 t.
        /// </summary>
        /// <returns></returns>
        //public byte[] GetDataFromVoltageMeter_HY_AV51_T()
        //{
        //    int offset = 0;
        //    int max = 85;
        //    byte[] byteBuffer = new byte[max];

        //    byte[] responce = new byte[max];

        //    short[] values = new short[max];
        //    for (int j = 0; j < allComPort.Count() - 1; j++)
        //    {
        //        if (allComPort[j].DeviceName == "VoltageMeter HY-AV51-T")
        //        {

        //            allComPort[j].ActivePort.Write(new byte[] { 0x01, 0x03, 0x00, 0x00, 0x00, 0x28, 0x45, 0xd4 }, 0, 8);
        //            //var byteBuffer = new byte[max];
        //            //allComPort[j].ActivePort.Read(byteBuffer, offset, byteBuffer.Length - offset);
        //            System.Threading.Thread.Sleep(300);
        //            int byteRecieved = allComPort[j].ActivePort.BytesToRead;

        //            allComPort[j].ActivePort.Read(byteBuffer, 0, byteRecieved);
        //            for (int i = 0; i < (byteBuffer.Length - 5) / 2; i++)
        //            {
        //                values[i] = byteBuffer[2 * i + 3];
        //                values[i] <<= 8;
        //                values[i] += byteBuffer[2 * i + 4];
        //            }

        //            return byteBuffer;
        //        }
        //    }
        //    return byteBuffer;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public short[] GetDataFromVoltageMeter_HY_AV51_T1()
        {
            int offset = 0;
            int max = 85;
            byte[] byteBuffer = new byte[max];

            byte[] responce = new byte[max];

            short[] values = new short[50];
            for (int j = 0; j < allComPort.Count() - 1; j++)
            {
                if (allComPort[j].DeviceName == "VoltageMeter HY-AV51-T")
                {

                    allComPort[j].ActivePort.Write(new byte[] { 0x01, 0x03, 0x00, 0x00, 0x00, 0x28, 0x45, 0xd4 }, offset, 8);
                    //var byteBuffer = new byte[max];
                    //allComPort[j].ActivePort.Read(byteBuffer, offset, byteBuffer.Length - offset);
                    System.Threading.Thread.Sleep(300);
                    //int byteRecieved = 0;
                    //try
                    //{
                    //    int byteRecieved = allComPort[j].ActivePort.BytesToRead;
                    //    allComPort[j].ActivePort.Read(byteBuffer, 0, byteRecieved);
                    //    //allComPort[j].ActivePort.Read(byteBuffer, 0, byteRecieved);
                    //    for (int i = 0; i < (byteBuffer.Length - 5) / 2; i++)
                    //    {
                    //        values[i] = byteBuffer[2 * i + 3];
                    //        values[i] <<= 8;
                    //        values[i] += byteBuffer[2 * i + 4];
                    //    }
                    //}
                    //catch (Exception e)
                    //{
                    //    e.ToString();
                    //    //GetDataFromVoltageMeter_HY_AV51_T1();
                    //    //  throw;
                    //}
                    ////int byteRecieved = allComPort[j].ActivePort.BytesToRead;

                    int byteRecieved = allComPort[j].ActivePort.BytesToRead;
                    allComPort[j].ActivePort.Read(byteBuffer, 0, byteRecieved);
                    //allComPort[j].ActivePort.Read(byteBuffer, 0, byteRecieved);
                    for (int i = 0; i < (byteBuffer.Length - 5) / 2; i++)
                    {
                        values[i] = byteBuffer[2 * i + 3];
                        values[i] <<= 8;
                        values[i] += byteBuffer[2 * i + 4];
                    }

                    // return values;
                }
            }
            return values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public short[] GetDataFromE7_20(string device)
        {
            int offset = 0;
            int max = 22;
            byte[] byteBuffer = new byte[max];
            byte[] responce = new byte[max];
            
            short[] values = new short[max];

                for (int i = 0; i < allComPort.Count(); i++)
                {
                    if (allComPort[i].DeviceName == device)
                    {
                        if (allComPort[i].ActivePort.IsOpen == true)
                        {
                        allComPort[i].ActivePort.DiscardInBuffer();
                        System.Threading.Thread.Sleep(400);
                        int byteRecieved = allComPort[i].ActivePort.BytesToRead;
                            
                            allComPort[i].ActivePort.Read(byteBuffer, offset, max);
                            for (int j = 0; j < (byteBuffer.Length - 5) / 2; j++)
                            {
                                values[j] = byteBuffer[2 * j + 3];
                                values[j] <<= 8;
                                values[j] += byteBuffer[2 * j + 4];
                            }

                        //txtComLog.AppendText(Environment.NewLine+ "---------"+ Environment.NewLine);
                        //for (int j = 0; j < max; j++)
                        //{
                        //    txtComLog.AppendText("[" + j.ToString() + "]" + Convert.ToString(byteBuffer[j], 16) + " ");  
                        //}
                        //txtComLog.AppendText(Environment.NewLine);

                        //for (int j = 0; j < max; j++)
                        //{
                        //    txtComLog.AppendText("["+j.ToString()+"]"+ byteBuffer[j].ToString() + " ");
                        //}
                        //txtComLog.AppendText(Environment.NewLine + "---------");


                        //txtComLog.AppendText(Environment.NewLine);

                        return values;
                        }
                    }
                }
            
            return values;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="offset"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public byte[] GetDataFromCOMDevice(string device, short offset, short max)
        {
            byte[] byteBuffer = new byte[max];
            byte[] responce = new byte[max];

            short[] values = new short[max];

            for (int i = 0; i < allComPort.Count(); i++)
            {
                if (allComPort[i].DeviceName == device)
                {
                    if (allComPort[i].ActivePort.IsOpen == true)
                    {
                        allComPort[i].ActivePort.DiscardInBuffer();
                        System.Threading.Thread.Sleep(400);
                        int byteRecieved = allComPort[i].ActivePort.BytesToRead;

                        allComPort[i].ActivePort.Read(byteBuffer, offset, max);
                        //for (int j = 0; j < (byteBuffer.Length - 5) / 2; j++)
                        //{
                        //    values[j] = byteBuffer[2 * j + 3];
                        //    values[j] <<= 8;
                        //    values[j] += byteBuffer[2 * j + 4];
                        //}
                        return byteBuffer;
                    }
                }
            }

            return byteBuffer;
        }



        static byte[] GetData(SerialPort serial)
        {
            int offset = 0;
            int max = 85;
            var byteBuffer = new byte[max];

            //serial.Read(byteBuffer1, 0, byteBuffer1.Length - offset);
            while (offset < max)
            {
                offset += serial.Read(byteBuffer, offset, byteBuffer.Length - offset);

            }
            return byteBuffer;
        }

        /// <summary>
        /// Send data to device via com port using number of struct
        /// </summary>
        /// <param name="i">number of struct</param>
        /// <param name="data">string to transmit</param>
        public void SendDataToComPort(int i, string data)
        {
            try
            {
                if (allComPort[i].ActivePort.IsOpen == true)
                {
                    allComPort[i].ActivePort.Write(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
                return;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the 1 event of the button1_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (tComPortVarta.Enabled == false)
            {
                tComPortVarta.Enabled = true;
            }
            else if (tComPortVarta.Enabled == true)
            {
                tComPortVarta.Enabled = false;
            }

        }
        /// <summary>
        /// Handles the 1 event of the button2_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            //string s = GetDataFromComPort("ArduinoUno");
            //string[] ss = s.Split('\n');
            //string s1 = "";
            //for (int i = 0; i < ss.Count(); i++)
            //{
            //    if (ss[i].Contains("Last average=") == true)
            //    {
            //        s1 = ss[i];
            //        txtComLog.AppendText(s1 + Environment.NewLine);

            //    }
            //}
            txtComLog.AppendText(ComReadString() + Environment.NewLine);

        }
        /// <summary>
        /// COMs the read string.
        /// </summary>
        /// <returns></returns>
        public string ComReadString()
        {
            string s = GetDataFromComPort("ArduinoUno");
            string[] ss = s.Split('\n');
            string s1 = "";
            for (int i = 0; i < ss.Count(); i++)
            {
                if (ss[i].Contains("Last average=") == true)
                {
                    s1 = ss[i];
                }
            }
            return s1;
        }

        private void frmComPort_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DevBuf= GetDataFromCOMDevice("E7-20", 0, 22);
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //GetDataFromE7_20("E7-20");
            
            byte[] buf = GetDataFromCOMDevice("E7-20", 0, 22);
            PiezoMathCalculation pm = new PiezoMathCalculation();
            byte[] bufo = { buf[12], buf[13], buf[14] };
            //byte[] bufo = { 0, 222, 111, 212 };
            double int_value1 = 0;
            double int_value2 = 0;
            byte c = 0xff;

            //if (BlockIn[18] and 128)<> 0 then

            if (buf[14] !=0)
            {
                bufo[0] =(byte)(buf[12] ^ c);
                bufo[1] = (byte) (buf[13]^c);
                bufo[2] = (byte)(buf[14]^c);
                int_value1 = (-1 - bufo[0] - (bufo[1] + bufo[2] * 256) * 256) * Math.Pow(Math.Pow(10, 256 - (int)(buf[15])), -1);
            }

            if (buf[18] != 0)
            {
                bufo[0] = (byte)(buf[16] ^ c);
                bufo[1] = (byte)(buf[17] ^ c);
                bufo[2] = (byte)(buf[18] ^ c);
                int_value2 = (-1 - bufo[0] - (bufo[1] + bufo[2] * 256) * 256) * Math.Pow(Math.Pow(10, 256 - (int)(buf[19])), -1); 
            }


            System.Threading.Thread.Sleep(500);
                double b2 = pm.BytesToDouble(buf, 12, 3) * Math.Pow(Math.Pow(10, 256 - (int)(buf[15])), -1);
                double b1 = pm.BytesToDouble(buf, 16, 3) * Math.Pow(Math.Pow(10, 256 - (int)(buf[19])), -1);
                txtComLog.AppendText(Environment.NewLine +int_value1.ToString() + "\t "+ int_value2.ToString());
                txtComLog.AppendText(Environment.NewLine + "b1=" + b2.ToString() + "\t"+buf[16] + "\t" + buf[17] + "\t" + buf[18] + "\t" + buf[19]);
                txtComLog.AppendText(Environment.NewLine + "b2=" + b1.ToString() + "\t"+buf[12] + "\t" + buf[13] + "\t" + buf[14] + "\t" + buf[15]);
            if (b2 > 1)
            {
                
                this.Refresh();
            }
            if (int_value1 < 0 || int_value2<0)
            {
                this.Refresh();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Crc16
    {
        const ushort polynomial = 0xA001;
        ushort[] table = new ushort[256];

        public ushort ComputeChecksum(byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(byte[] bytes)
        {
            ushort crc = ComputeChecksum(bytes);
            return BitConverter.GetBytes(crc);
        }

        public Crc16()
        {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Crc32
    {
        /// <summary>
        /// 
        /// </summary>
        uint[] table;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public uint ComputeChecksum(byte[] bytes)
        {
            uint crc = 0xffffffff;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(((crc) & 0xff) ^ bytes[i]);
                crc = (uint)((crc >> 8) ^ table[index]);
            }
            return ~crc;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public byte[] ComputeChecksumBytes(byte[] bytes)
        {
            return BitConverter.GetBytes(ComputeChecksum(bytes));
        }
        /// <summary>
        /// 
        /// </summary>
        public Crc32()
        {
            uint poly = 0xedb88320;
            table = new uint[256];
            uint temp = 0;
            for (uint i = 0; i < table.Length; ++i)
            {
                temp = i;
                for (int j = 8; j > 0; --j)
                {
                    if ((temp & 1) == 1)
                    {
                        temp = (uint)((temp >> 1) ^ poly);
                    }
                    else
                    {
                        temp >>= 1;
                    }
                }
                table[i] = temp;
            }
        }
    }


}


