using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.NI4882;
using NationalInstruments.VisaNS;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;




namespace Kalipso
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class frmGPIBConfig : Form
    {
        Device device = null;
#pragma warning disable CS0414 // Полю "frmGPIBConfig.deviceUSB" присвоено значение, но оно ни разу не использовано.
        UsbSession deviceUSB = null;
#pragma warning restore CS0414 // Полю "frmGPIBConfig.deviceUSB" присвоено значение, но оно ни разу не использовано.

        public MessageBasedSession mbSession;
        /// <summary>
        /// Answer from device
        /// </summary>
        public string answer { get; set; }
        /// <summary>
        /// Flag of end trasmiting
        /// </summary>
        public bool writeEND { get; set; }
        /// <summary>
        /// GPIBdev
        /// </summary>
        public string GPIBdev { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmGPIBConfig"/> class.
        /// </summary>


        public frmGPIBConfig()
        {
            InitializeComponent();
            ControllerAddressUD.Value = 0;
            DeviceAddressUD.Value = 17;
            writeEND = false;
            GPIBdev = "";
            btnCloseGPIB.Enabled = false;
            btnSendCommand.Enabled = false;
            btnReadGPIB.Enabled = false;
            txtAnswer.Enabled = false;
            txtElementsTransferred.Enabled = false;
            txtLastIOStatus.Enabled = false;
            cbInterfaceType.SelectedIndex = 0;
            cbInterfaceType.SelectedIndex = 0;
            txtCommand.Text = ":FREQ 20";

        }
        /// <summary>
        /// Handles the Click event of the btnSendCommand control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        WriteCommandDev(txtCommand.Text);
                        ReadDeviceAnswer();
                        break;
                    }
                case "USB":
                    {
                        try
                        {
                            string textToWrite = ReplaceCommonEscapeSequences(txtCommand.Text);
                            string responseString = mbSession.Query(textToWrite);
                            txtAnswer.AppendText(Environment.NewLine + InsertCommonEscapeSequences(responseString));
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                        break;
                    }
                default:
                    break;
            }

        }
        /// <summary>
        /// Sends the command ehternet.
        /// </summary>
        public void SendCmdEhternet()
        {
            if (cbInterfaceType.Text == "GPIB")
            {
                WriteCommand(txtCommand.Text);
            }
            if (cbInterfaceType.Text == "ETHERNET")
            {
                // Устанавливаем для сокета локальную конечную точку
                int port = 5024; // порт для приема входящих запросов
                string ip = txtIpHost.Text;
                // Создаем сокет Tcp/Ip
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
                try
                {
                    PiezoParameters piezo = new PiezoParameters();
                    string msg = txtCommand.Text + '\n';
                    socket.Connect(ipPoint);
                    //byte[] data = Encoding.Unicode.GetBytes(msg);
                    byte[] data = Encoding.ASCII.GetBytes(msg);
                    socket.Send(data);
                    // получаем ответ
                    data = new byte[70]; // буфер для ответа
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байт

                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);

                    int gg = data.Count();
                    MessageBox.Show(gg.ToString());
                    Console.WriteLine("ответ сервера: " + builder.ToString());


                    int uu = socket.Receive(data);
                    MessageBox.Show(uu.ToString());
                    byte[] data2 = new byte[70];

                    for (int i = 6; i < data.Count(); i++)
                    {
                        data2[i - 6] = data[i];
                    }
                    MessageBox.Show(Encoding.ASCII.GetString(data2));
                    txtAnswer.Text = Encoding.ASCII.GetString(data2);
                    // закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    Console.ReadLine();
                }

            }
        }
        /// <summary>
        /// Sends the command via ehternet.
        /// </summary>
        public string SendCmdViaEhternet()
        {
            if (cbInterfaceType.Text == "ETHERNET")
            {
                try
                {
                    // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
                    // Устанавливаем для сокета локальную конечную точку
                    int port = 5024; // порт для приема входящих запросов
                    string ip = txtIpHost.Text;
                    // Создаем сокет Tcp/Ip
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    PiezoParameters piezo = new PiezoParameters();
                    string msg = txtCommand.Text + '\n';
                    socket.Connect(ipPoint);
                    byte[] data = Encoding.ASCII.GetBytes(msg);
                    socket.Send(data);
                    // получаем ответ
                    System.Threading.Thread.Sleep(400);
                    data = new byte[70]; // буфер для ответа
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байт
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);

                    //int gg = data.Count();
                    //MessageBox.Show(gg.ToString());
                    //Console.WriteLine("ответ сервера: " + builder.ToString());
                    //int uu = socket.Receive(data);
                    //MessageBox.Show(uu.ToString());
                    byte[] data2 = new byte[70];
                    for (int i = 6; i < data.Count(); i++)
                    {
                        data2[i - 6] = data[i];
                    }
                    // закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    string ss = Encoding.ASCII.GetString(data2);
                    txtAnswer.Text = ss;

                    Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9]{1}");
                    if (reg.IsMatch(ss))
                    {
                        MessageBox.Show("Ok");
                        ParseStringTab PS = new ParseStringTab();
                        PS.AddMeasStringAgilent4980(ss);
                        txtAnswer.Text = PS.ElementAt(1);
                    }
                    else
                    {
                        txtAnswer.Text = "no";
                    }
                    txtAnswer.Text = ss;

                    char splitchar = (char)'\n';
                    string[] sss = ss.Split(splitchar);
                    string s1 = sss[2];
                    s1 = s1.Substring(12, 24);

                    string sss1 = ss.Substring(0, 10);
                    txtAnswer.AppendText(Environment.NewLine + sss1);

                    return ss;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex.ToString());
                    return ex.ToString();
                }
            }
            else
            {
                return "";
            }

            //"SCPI> 4980A SCPI parser.\r\n\r\nSCPI> ??\u0001??\u0003-1.27856E-08,-3.91647E-0\0\0\0\0\0\0"
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="port"></param>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public string SendCmdViaEhternet(string command, int port, string ipAddress)
        {
            if (cbInterfaceType.Text == "ETHERNET")
            {
                // Устанавливаем для сокета локальную конечную точку
                // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
                try
                {
                    // Создаем сокет Tcp/Ip
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //PiezoParameters piezo = new PiezoParameters();
                    string msg = command + '\n';
                    socket.Connect(ipPoint);
                    //byte[] data = Encoding.Unicode.GetBytes(msg);
                    byte[] data = Encoding.ASCII.GetBytes(msg);
                    socket.Send(data);
                    // получаем ответ
                    System.Threading.Thread.Sleep(800);
                    data = new byte[70]; // буфер для ответа
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байт
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);

                    byte[] data2 = new byte[70];
                    for (int i = 6; i < data.Count(); i++)
                    {
                        data2[i - 6] = data[i];
                    }
                    // закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    answer = Encoding.ASCII.GetString(data2);
                    return Encoding.ASCII.GetString(data2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex.ToString());
                    return ex.ToString();
                }
            }
            return "";

        }

        /// <summary>
        /// Sends the command via ehternet.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="port">The port number.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <returns>Andswer</returns>
        public string SendCmdViaEhternet1(string command, int port, string ipAddress)
        {
            if (cbInterfaceType.Text == "ETHERNET")
            {
                try
                {
                    // Создаем сокет Tcp/Ip
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    //PiezoParameters piezo = new PiezoParameters();
                    string msg = txtCommand.Text + '\n';
                    socket.Connect(ipPoint);
                    byte[] data = Encoding.ASCII.GetBytes(msg);
                    socket.Send(data);
                    // получаем ответ
                    data = new byte[70]; // буфер для ответа
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0; // количество полученных байт
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);
                    byte[] data2 = new byte[70];
                    for (int i = 6; i < data.Count(); i++)
                    {
                        data2[i - 6] = data[i];
                    }
                    // закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    string ss = Encoding.ASCII.GetString(data2);
                    return Encoding.ASCII.GetString(data2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return ex.ToString();
                }
            }
            else
            {
                return "";
            }
        }

#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.Agilent4980Ans(string)"
        public string Agilent4980Ans(string instring)
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.Agilent4980Ans(string)"
        {
            //-1.26499E-08,-2.76283E+00,+0
            Regex reg = new Regex(@"^[-+]\d{1}[.]\d{5}[E][-+]d{2}[,][-+]\d{1}[.]\d{5}[E][-+]d{2}[,][,][-+]d{1}$");

            return "";
        }


        /// <summary>
        /// Sends the command ehternet.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="port">The port.</param>
        /// <param name="ipAddress">The ip address.</param>
        public void SendCmdEhternet(string command, int port, int ipAddress)
        {

        }
        /// <summary>
        /// Sends the command ehternet.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="port">The port.</param>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="socket">The socket.</param>
        public void SendCmdEhternet(string command, int port, int ipAddress, Socket socket)
        {

        }

#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.GetAnswerEthernet()"
        public string GetAnswerEthernet()
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmGPIBConfig.GetAnswerEthernet()"
        {
            return "";
        }
        /// <summary>
        /// Writes the command.
        /// </summary>
        /// <param name="s">The s.</param>
        public void WriteCommand(string s)
        {
            writeEND = false;
            try
            {
                device.BeginWrite(s, new AsyncCallback(OnWriteComplete), null);
                device.BeginWrite(ReplaceCommonEscapeSequences(s), new AsyncCallback(OnWriteComplete), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Called when [write complete].
        /// </summary>
        /// <param name="result">The result.</param>
        private void OnWriteComplete(IAsyncResult result)
        {
            try
            {
                device.EndWrite(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtElementsTransferred.Text = device.LastCount.ToString();
            txtLastIOStatus.Text = device.LastStatus.ToString();
            writeEND = true;
        }
        /// <summary>
        /// Replaces the common escape sequences.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }
        /// <summary>
        /// Inserts the common escape sequences.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        private string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }
        /// <summary>
        /// Handles the Click event of the btnFind control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        try
                        {
                            int currentSecondaryAddress = 0;
                            device = new Device((int)ControllerAddressUD.Value,
                                (byte)DeviceAddressUD.Value,
                                (byte)currentSecondaryAddress);

#if NETFX2_0
                //For .NET Framework 2.0, use SynchronizeCallbacks to specify that the object 
                //marshals callbacks across threads appropriately.
                device.SynchronizeCallbacks = true;
#else
                            //For .NET Framework 1.1, set SynchronizingObject to the Windows Form to specify 
                            //that the object marshals callbacks across threads appropriately.
#pragma warning disable CS0618 // 'Device.SynchronizingObject" является устаревшим: 'Use SynchronizeCallbacks to specify that the object marshals callbacks across threads appropriately.'
                            device.SynchronizingObject = this;
#pragma warning restore CS0618 // 'Device.SynchronizingObject" является устаревшим: 'Use SynchronizeCallbacks to specify that the object marshals callbacks across threads appropriately.'
#endif
                            SetupControlState(true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }

                        try
                        {
                            WriteCommandDev("*IDN?");
                            ReadDeviceAnswer();
                            GPIBdev = answer;
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            GPIBdev = "GPIB device not initialized try again";
                            txtAnswer.Text = GPIBdev;
                            return;
                        }
                        break;
                    }
                case "USB":
                    {
                        //deviceUSB = viFindRsrc
                        string[] resources = ResourceManager.GetLocalManager().FindResources("?*");
                        try
                        {
                            string ResourceName = resources[0];
                            mbSession = (MessageBasedSession)ResourceManager.GetLocalManager().Open(ResourceName);
                            txtAnswer.AppendText(Environment.NewLine + ResourceName);

                            //foreach (string s in resources)
                            //{
                            //    HardwareInterfaceType intType;
                            //    short intNum;
                            //    ResourceManager.GetLocalManager().ParseResource(s, out intType, out intNum);
                            //}
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }

                ////var rmSession = new ResourceManager.;
                //foreach (string s in resources)
                //{
                //    txtAnswer.AppendText(Environment.NewLine+ s);
                //}

                //foreach (string s in rmSession.Find("(ASRL|GPIB|TCPIP|USB)?*INSTR"))
                //{
                //    Console.WriteLine(s);
                //}
                //rmSession.Dispose();




                //deviceUSB.Write("");
                //mbSession = (MessageBasedSession)ResourceManager.GetLocalManager().Open("GPIB0::17::INSTR");
                //try
                //{
                //    mbSession = (MessageBasedSession)ResourceManager.GetLocalManager().
                //    Open("GPIB0::17::INSTR");
                //    mbSession.Write(":FREQ 20");
                //}
                //catch (InvalidCastException)
                //{
                //    MessageBox.Show("Resource selected must be a message-based session");
                //}
                //catch (Exception exp)
                //{
                //    MessageBox.Show(exp.Message);
                //}
                //break;
                case "ETHERNET":
                    WriteCommandDev("idn?");
                    txtAnswer.Text = answer;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Setups the state of the control.
        /// </summary>
        /// <param name="isSessionOpen">if set to <c>true</c> [is session open].</param>
        public void SetupControlState(bool isSessionOpen)
        {
            btnCloseGPIB.Enabled = isSessionOpen;
            btnSendCommand.Enabled = isSessionOpen;
            btnReadGPIB.Enabled = isSessionOpen;
            txtAnswer.Enabled = isSessionOpen;
            txtElementsTransferred.Enabled = isSessionOpen;
            txtLastIOStatus.Enabled = isSessionOpen;
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (device != null)
                {
                    device.Dispose();
                }
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Handles the Click event of the btnCloseGPIB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCloseGPIB_Click(object sender, EventArgs e)
        {
            try
            {
                device.Dispose();
                SetupControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Handles the Click event of the btnReadGPIB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnReadGPIB_Click(object sender, EventArgs e)
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        try
                        {
                            device.BeginRead(new AsyncCallback(OnReadComplete), null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                case "USB":
                    {
                        answer = mbSession.ReadString();
                        break;
                    }
                default:
                    break;
            }

        }
        /// <summary>
        /// Reads the gpib answer.
        /// </summary>
        public void ReadGPIBAnswer()
        {
            try
            {
                device.BeginRead(new AsyncCallback(OnReadCompletefromGPIB), null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Called when [read complete from gpib].
        /// </summary>
        /// <param name="result">The result.</param>
        private void OnReadCompletefromGPIB(IAsyncResult result)
        {
            try
            {
                txtAnswer.Text = InsertCommonEscapeSequences(device.EndReadString(result));
                answer = InsertCommonEscapeSequences(device.EndReadString(result));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Reads the gpib answer string.
        /// </summary>
        /// <param name="result">The result.</param>
        public void ReadGPIBAnswerString(IAsyncResult result)
        {
            try
            {
                device.BeginRead(new AsyncCallback(OnReadCompletefromGPIB), null);
                answer = InsertCommonEscapeSequences(device.EndReadString(result));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Called when [read complete].
        /// </summary>
        /// <param name="result">The result.</param>
        private void OnReadComplete(IAsyncResult result)
        {
            try
            {
                txtAnswer.Text = InsertCommonEscapeSequences(device.EndReadString(result));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtElementsTransferred.Text = device.LastCount.ToString();
            txtLastIOStatus.Text = device.LastStatus.ToString();
        }
        /// <summary>
        /// Handles the FormClosing event of the frmGPIBConfig control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmGPIBConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
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
        /// Writes the commande synchronize.
        /// </summary>
        /// <param name="command">The command.</param>
        public void WriteCommandeSync(string command)
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        if (device == null)
                        {
                            MessageBox.Show("Chek device");
                            return;
                        }
                        device.Write(ReplaceCommonEscapeSequences(command));
                        //device.Write(command);
                        break;
                    }
                case "USB": break;
                case "ETHERNET":
                    {
                        SendCmdViaEhternet(command, Convert.ToInt32(txtIpPort.Text), txtIpHost.Text);
                        break;
                    }
                default: break;
            }
        }
        /// <summary>
        /// Writes the command dev.11
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        public bool WriteCommandDev(string command)
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        if (device == null)
                        {
                            MessageBox.Show("Chek device");
                            return false;
                        }
                        device.Write(ReplaceCommonEscapeSequences(command));
                        return true;
                    }
                case "USB":
                    mbSession.Write(ReplaceCommonEscapeSequences(command));
                    //txtAnswer.AppendText(Environment.NewLine + InsertCommonEscapeSequences(responseString));
                    return true;
                case "ETHERNET":
                    {
                        answer = SendCmdViaEhternet(command, Convert.ToInt32(txtIpPort.Text), txtIpHost.Text);
                        return true;
                    }
                default:
                    return true;
            }
        }
        /// <summary>
        /// Writes the command dev.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="ipPort">The ip port.</param>
        /// <returns></returns>
        public bool WriteCommandDev(string command, string ipPort)
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        if (device == null)
                        {
                            MessageBox.Show("Chek device");
                            return false;
                        }
                        device.Write(ReplaceCommonEscapeSequences(command));
                        return true;
                    }
                case "USB":
                    return true;
                case "ETHERNET":
                    {
                        SendCmdViaEhternet(command, Convert.ToInt32(ipPort), txtIpHost.Text);
                        return true;
                    }
                default:
                    return false;
            }
        }
        /// <summary>
        /// Writes the command dev.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="ipPort">The ip port.</param>
        /// <param name="IpHost">The ip host.</param>
        /// <returns></returns>
        public bool WriteCommandDev(string command, string ipPort, string IpHost)
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        if (device == null)
                        {
                            MessageBox.Show("Chek device");
                            return false;
                        }
                        device.Write(ReplaceCommonEscapeSequences(command));
                        return true;
                    }
                case "USB":
                    return true;
                case "Ethernet":
                    {
                        SendCmdViaEhternet(command, Convert.ToInt32(ipPort), IpHost);
                        return true;
                    }
                default:
                    return false;
            }
        }

        /// <summary>
        /// Reads the gpib answer string synchronize. 1
        /// </summary>
        public void ReadDeviceAnswer()
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        answer = "";
                        try
                        {
                            answer = device.ReadString();
                            txtAnswer.Text = answer;
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            switch (cbInterfaceType.Text)
                            {
                                default:
                                    {
                                        txtAnswer.Text = "+0,+1.00000E-00,+1.00000E-00\n";
                                        answer = "+0,+1.00000E-00,+1.00000E-00\n";
                                        break;
                                    }
                            }


                        }


                        break;
                    }
                case "USB":
                    {
                        answer = mbSession.ReadString();
                        txtAnswer.Text = answer;
                        break;
                    }

                case "ETHERNET":
                    break;
                default:
                    break;
            }
        }

        public void ReadDeviceAnswer(string query)
        {
            switch (cbInterfaceType.Text)
            {
                case "GPIB":
                    {
                        answer = "";
                        try
                        {
                            answer = device.ReadString();
                            txtAnswer.Text = answer;
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            switch (cbInterfaceType.Text)
                            {
                                default:
                                    {
                                        txtAnswer.Text = "+0,+1.00000E-00,+1.00000E-00\n";
                                        answer = "+0,+1.00000E-00,+1.00000E-00\n";
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case "USB":
                    {
                        answer = mbSession.Query(query);
                        break;
                    }
                case "ETHERNET":
                    break;
                default:
                    break;
            }
        }


        private void txtAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmGPIBConfig_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void txtIpHost_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbInterfaceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbInterfaceType.Text)
            {
                case "ETHERNET":
                    {
                        txtAnswer.Enabled = true;
                        btnSendCommand.Enabled = true;
                        break;
                    }
                case "GPIB":
                    {
                        txtAnswer.Enabled = true;
                        btnSendCommand.Enabled = true;
                        break;
                    }
                case "USB":
                    {
                        txtAnswer.Enabled = true;
                        btnSendCommand.Enabled = true;
                        btnReadGPIB.Enabled = true;
                        break;
                    }
                default:
                    break;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            WriteCommandDev(":SOUR:FREQ 1000;:TRIG;FETCh?");
            ReadDeviceAnswer();




            //work it
            //txtAnswer.Text = SendCmdViaEhternet(txtCommand.Text, Convert.ToInt32(txtIpPort.Text), txtIpHost.Text);
            //Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{1}");
            //string s = "-2.41884E-08,-2.96171E-0";
            //if (reg.IsMatch(s) == true)
            //{
            //    txtAnswer.Text = "Ok";
            //}








            ////(@"^[-+]\d{1}[.]\d{5}[E][-+]d{2}[,][-+]\d{1}[.]\d{5}[E][-+]d{2}[,][,][-+]d{1}$");
            //if (cbInterfaceType.Text == "ETHERNET")
            //{
            //    txtAnswer.Enabled = true;
            //    btnSendCommand.Enabled = true;
            //    //Regex reg = new Regex(@"^[-+][1-9][.][1-9]{4}[A-Z][-+][1-9]{1}");
            //    Regex reg = new Regex(@"^[-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9][.][0-9]{5}[E][-+][0-9]{2}[,][-+][0-9]{1}");
            //    string s = "-1.56798E-08,+2.66017E-01,+0";
            //    if (reg.IsMatch(s))
            //    {
            //        MessageBox.Show("Ok");
            //    }
            //    else
            //    {
            //        MessageBox.Show("No");
            //    }
            //}
            ////-1.26499E-08,-2.76283E+00,+0
            ////-1.56798E-08,+2.66017E-01,+0
            ////-2.41884E-08,-2.96171E-0



        }




    }
}
