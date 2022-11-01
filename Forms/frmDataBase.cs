using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Kalipso
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmDataBase : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public DBconnect DBcon = new DBconnect();
        /// <summary>
        /// 
        /// </summary>
        //public DataBasePostgres DBpostgres = new DataBasePostgres();
        ///// <summary>
        ///// 
        ///// </summary>
        //public string Server { set; get; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string Port { set; get; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string UserId { set; get; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string Password { set; get; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string DB { set; get; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public bool DataBaseConnected { get; set; }
        ///// <summary>
        ///// Gets or sets the connection string to database.
        ///// </summary>
        ///// <value>
        ///// The connection string to database.
        ///// </value>
        //public string ConnectionStringToDB { set; get; }
        /// <summary>
        /// Конструктор класса формы DataBase
        /// </summary>
        public frmDataBase()
        {
            InitializeComponent();
            //инициализация параметров для входа в базу данных

            DBcon.ServerIP += "Server=" + eServer.Text + ";";
            DBcon.DataBaseTitle += "Database=" + eDB.Text + ";";
            DBcon.UserName += "User Id=" + eLogin.Text + ";";
            DBcon.PortNumber += "Port = " + ePort.Text + ";";
            DBcon.Password += "Password=" + ePass.Text + ";";
            DBcon.ConnectionString = DBcon.ServerIP + DBcon.PortNumber + DBcon.PortNumber + DBcon.UserName +
            DBcon.Password + DBcon.DataBaseTitle;
            DBcon.DataBaseConnected = false;
        }
        /// <summary>
        /// Устанавливает сервер базы данных для соединения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>				
        private void btnSetSever_Click(object sender, EventArgs e)
        {
            SetIPServer();
        }
        /// <summary>
        /// 
        /// </summary>
        void SetIPServer()
        {
            if (eServer.Text != "")
            {
                DBcon.ServerIP = "";
                DBcon.ServerIP += "Server=" + eServer.Text + ";";
                DBcon.SetConnectionString();
            }
        }

        /// <summary>
        /// Устанавливает базу данных для соединения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSetDB_Click(object sender, EventArgs e)
        {
            setDb();            
        }
        /// <summary>
        /// 
        /// </summary>
        void setDb()
        {
            if (eDB.Text != "")
            {
                DBcon.DataBaseTitle = "";
                DBcon.DataBaseTitle += "Database=" + eDB.Text + ";";
                DBcon.SetConnectionString();
            }
        }
        /// <summary>
        /// Устанавливает Логин для соединения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetLogin_Click(object sender, EventArgs e)
        {
            setLogin();
        }
        /// <summary>
        /// 
        /// </summary>
        void setLogin()
        {
            if (eLogin.Text != "")
            {
                DBcon.UserName = "";
                DBcon.UserName += "User Id=" + eLogin.Text + ";";
                DBcon.SetConnectionString();
            }
        }
        /// <summary>
        /// Устанавливает порт сервера базы данных для соединения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetPort_Click(object sender, EventArgs e)
        {
            SetPort();
        }
        void SetPort()
        {
            if (ePort.Text != "")
            {
                DBcon.PortNumber = "";
                DBcon.PortNumber += "Port = " + ePort.Text + ";";
                DBcon.SetConnectionString();
            }
        }
        /// <summary>
        /// Устанавливает пароль базы данных для соединения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetPass_Click(object sender, EventArgs e)
        {
            setPassword();
        }
        /// <summary>
        /// 
        /// </summary>
        void setPassword()
        {
            if (ePass.Text != "")
            {
                DBcon.Password = "";
                DBcon.Password += "Password=" + ePass.Text + ";";
                DBcon.SetConnectionString();
            }
        }
        /// <summary>
        /// Устанавливает пробное соединение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnectDB_Click(object sender, EventArgs e)
        {
            
            try
            {
                DBcon.SetConnectionString();
                if (DBcon.ConnectionString != "")
                {
                    NpgsqlConnection pgcon = new NpgsqlConnection(DBcon.ConnectionString);
                    pgcon.Open();
                    DBcon.DataBaseConnected = true;
                    pgcon.Close();
                    MessageBox.Show("Connection to database was opened and closed successful");
                }
            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                //throw;
            }
        }

        private void eServer_TextChanged(object sender, EventArgs e)
        {
            DBcon.SetConnectionString();
        }

        private void eDB_TextChanged(object sender, EventArgs e)
        {
            DBcon.SetConnectionString();
        }

        private void eLogin_TextChanged(object sender, EventArgs e)
        {
            DBcon.SetConnectionString();
        }

        private void ePass_TextChanged(object sender, EventArgs e)
        {
            DBcon.SetConnectionString();
        }

        private void ePort_TextChanged(object sender, EventArgs e)
        {
            DBcon.SetConnectionString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void frmDataBase_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //DBcon.pgconnection.ConnectionString = DBcon.ConnectionString;
                //NpgsqlConnection pgcon = new NpgsqlConnection(DBcon.ConnectionString);
                //DBcon.pgconnection.Open();
                string sql_str = txtRequsetDB.Text;
                //NpgsqlCommand CSend = new NpgsqlCommand(sql_str, DBcon.pgconnection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql_str, DBcon.pgconnection.ConnectionString);
                

                //CSend.ExecuteNonQuery();
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dbView.DataSource = dataSet.Tables[0];

                DBcon.pgconnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// Handles the 1 event of the button1_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click_1(object sender, EventArgs e)
        {

            DBDataReader_records(this.txtRequsetDB.Text);
        }
        /// <summary>
        /// Databases the data comporison.
        /// </summary>
        /// <returns>boolen true if find compare string</returns>
        public bool DBData_Comporison(string InitVal, string compareVal, string DBColumn)
        {

            try
            {
                DBcon.pgconnection.ConnectionString = DBcon.ConnectionString;
                //NpgsqlConnection pgcon = new NpgsqlConnection(dbConnectionStringToDB);
                DBcon.pgconnection.Open();
                string sql = txtRequsetDB.Text;
                DBcon.pgcommandSend.CommandText = sql;
                DBcon.pgcommandSend.Connection = DBcon.pgconnection;
                //NpgsqlCommand CSend = new NpgsqlCommand(sql, DBcon.pgconnection);
                DBcon.pgcommandSend.ExecuteNonQuery();
                DBcon.pgreader = DBcon.pgcommandSend.ExecuteReader();
                //NpgsqlDataReader reader = CSend.ExecuteReader();
                if (DBcon.pgreader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in DBcon.pgreader)
                    {
                        for (int i = 0; i < DBcon.pgreader.FieldCount; i++)
                        {
                            if (compareVal == dbDataRecord[DBColumn].ToString())
                            {
                                DBcon.pgconnection.Close();
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }


        }
        /// <summary>
        /// Databases the data reader records.
        /// </summary>
        public void DBDataReader_records(string sql)
        {

            DBcon.pgcommandSend.CommandText = sql;
            if (DBcon.DBDataReader_records_once(sql) == true)
            {
                DBcon.pgconnection.ConnectionString = DBcon.ConnectionString;
                DBcon.pgconnection.Open();
                DBcon.pgcommandSend.Connection = DBcon.pgconnection;
                DBcon.pgcommandSend.ExecuteNonQuery();
                DBcon.pgreader = DBcon.pgcommandSend.ExecuteReader();
                if (DBcon.pgreader.HasRows)
                {
                    dbView.Columns.Clear();
                    for (int i = 0; i < DBcon.pgreader.FieldCount; i++)
                    {
                        dbView.Columns.Add(DBcon.pgreader.GetName(i), DBcon.pgreader.GetName(i));
                    }
                    int celsel = 0;
                    foreach (DbDataRecord dbDataReader in DBcon.pgreader)
                    {
                        dbView.Rows.Add(1);
                        for (int i = 0; i < DBcon.pgreader.FieldCount; i++)
                        {
                            dbView[dbDataReader.GetName(i), celsel].Value = dbDataReader[dbDataReader.GetName(i)];
                        }
                        ++celsel;
                    }
                }
            }
            //DBcon.pgconnection.ConnectionString=DBcon.ConnectionString;
            //DBcon.pgconnection.Open();
            ////NpgsqlConnection pgcon = new NpgsqlConnection(ConnectionStringToDB);
            ////pgcon.Open();
            //string sql = txtRequsetDB.Text;
            //DBcon.pgcommandSend.CommandText = sql;
            //DBcon.pgcommandSend.Connection = DBcon.pgconnection;
            ////NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
            //try
            //{
            //    //CSend.ExecuteNonQuery();
            //    DBcon.pgcommandSend.ExecuteNonQuery();
            //    DBcon.pgreader = DBcon.pgcommandSend.ExecuteReader();
            //    //NpgsqlDataReader reader = CSend.ExecuteReader();
            //    //if (reader.HasRows)
            //    if (DBcon.pgreader.HasRows)
            //    {
            //        dbView.Columns.Clear();
            //        for (int i = 0; i < DBcon.pgreader.FieldCount; i++)
            //        {
            //            dbView.Columns.Add(DBcon.pgreader.GetName(i), DBcon.pgreader.GetName(i));

            //        }
            //        int celsel = 0;
            //        foreach (DbDataRecord dbDataReader in DBcon.pgreader)
            //        {
            //            dbView.Rows.Add(1);
            //            for (int i = 0; i < DBcon.pgreader.FieldCount; i++)
            //            {
            //                dbView[dbDataReader.GetName(i), celsel].Value = dbDataReader[dbDataReader.GetName(i)];
            //            }
            //            ++celsel;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //    return;
            //}
            //DBcon.pgconnection.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //IEnumerable<dynamic> Exe;
            //Exe= DBcon.Execute(txtRequsetDB.Text).Select();

            //DBcon.Execute(txtRequsetDB.Text);
            DBcon.dbread(txtRequsetDB.Text);
            string s = "gg";

            //DBcon.pgcommandSend.CommandText = sql;
            //if (DBcon.DBDataReader_records_once(sql) == true)
            //{
            //    DBcon.pgconnection.ConnectionString = DBcon.ConnectionString;
            //    DBcon.pgconnection.Open();
            //    DBcon.pgcommandSend.Connection = DBcon.pgconnection;
            //    DBcon.pgcommandSend.ExecuteNonQuery();
            //    DBcon.pgreader = DBcon.pgcommandSend.ExecuteReader();
            //    if (DBcon.pgreader.HasRows)
            //    {
            //        dbView.Columns.Clear();
            //        for (int i = 0; i < DBcon.pgreader.FieldCount; i++)
            //        {
            //            dbView.Columns.Add(DBcon.pgreader.GetName(i), DBcon.pgreader.GetName(i));
            //        }
            //        int celsel = 0;
            //        foreach (DbDataRecord dbDataReader in DBcon.pgreader)
            //        {
            //            dbView.Rows.Add(1);
            //            for (int i = 0; i < DBcon.pgreader.FieldCount; i++)
            //            {
            //                dbView[dbDataReader.GetName(i), celsel].Value = dbDataReader[dbDataReader.GetName(i)];
            //            }
            //            ++celsel;
            //        }
            //    }
            //}
        }

    }
}



/// <summary>
/// DataBase Class
/// </summary>
//public class DataBasePostgres
//{
//    public string server;
//    public string Port;
//    public string UserId;
//    public string pass;
//    public string db;
//    private string connect;

//    NpgsqlConnection pgcon = new NpgsqlConnection();
//    NpgsqlCommand CommandSend = new NpgsqlCommand();

//    public DataBasePostgres()
//    {
//        server = "";
//        Port = "";
//        UserId = "";
//        pass = "";
//        db = "";
//        connect = server + Port + UserId + pass + db;

//        //инициализация параметров для входа в базу данных
//        //server += "Server=" + eServer.Text + ";";
//        //db += "Database=" + eDB.Text + ";";
//        //UserId += "User Id=" + eLogin.Text + ";";
//        //Port += "Port = " + ePort.Text + ";";
//        //pass += "Password=" + ePass.Text + ";";
//    }
//    /// <summary>
//    /// Устанавливает сервер базы данных для соединения
//    /// </summary>
//    /// <param name="serverId">The server identifier.</param>
//    public void SetSever(string serverId)
//    {
//        server += "Server=" + server + ";";
//    }
//    /// <summary>
//    /// Устанавливает базу данных для соединения
//    /// </summary>
//    /// <param name="DBId">The database identifier.</param>
//    public void SetDB(string DBId)
//    {
//        db += "Database=" + DBId + ";";
//    }
//    /// <summary>
//    /// Устанавливает Логин для соединения
//    /// </summary>
//    public void SetLogin(string elogin)
//    {
//        UserId += "User Id=" + elogin + ";";
//    }
//    /// <summary>
//    /// Устанавливает порт сервера базы данных для соединения
//    /// </summary>
//    public void SetPort(string portId)
//    {
//        Port += "Port = " + portId + ";";
//    }
//    /// <summary>
//    /// Устанавливает пароль базы данных для соединения
//    /// </summary>
//    /// <param name="passwordDB">The password database.</param>
//    public void SetPass(string passwordDB)
//    {
//        pass += "Password=" + passwordDB + ";";
//    }
//    /// <summary>
//    /// Устанавливает пробное соединение
//    /// </summary>
//    public bool ConnectDBCheck()
//    {
//        try
//        {
//            string connect = server + Port + UserId + pass + db;
//            pgcon.Open();
//            pgcon.Close();
//            return true;
//        }
//        catch (Exception msg)
//        {
//            // something went wrong, and you wanna know why
//            MessageBox.Show(msg.ToString());
//            throw;
//        }
//    }
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="sql"></param>
//    public void SendDataToDB(string sql)
//    {
//        try
//        {
//            string connect = server + Port + UserId + pass + db;
//            pgcon.Open();
//            NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
//            CSend.ExecuteNonQuery();
//            pgcon.Close();
//        }
//        catch (Exception msg)
//        {
//            // something went wrong, and you wanna know why
//            MessageBox.Show(msg.ToString());
//            throw;
//        }
//    }


//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="sql"></param>
//    /// <param name="connection_string"></param>
//    public void SendDataToDB(string sql, string connection_string)
//    {
//        try
//        {
//            pgcon.ConnectionString = connection_string;
//            pgcon.Open();
//            CommandSend.Connection = pgcon;
//            CommandSend.CommandText = sql;
//            CommandSend.ExecuteNonQuery();
//            pgcon.Close();
//        }
//        catch (Exception msg)
//        {
//            // something went wrong, and you wanna know why
//            MessageBox.Show(msg.ToString());
//            throw;
//        }
//    }
//}
//}
