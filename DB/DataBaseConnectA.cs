using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public abstract class DataBaseConnect
{
    public NpgsqlConnection pgconnection = new NpgsqlConnection();
    public NpgsqlCommand pgcommandSend = new NpgsqlCommand();
    public NpgsqlDataReader pgreader;


    #region variables
    /// <summary>
    /// 
    /// </summary>
    public string ServerIP
    {
        get; set;
    }
    /// <summary>
    /// connection port
    /// </summary>
    public string PortNumber
    {
        get; set;
    }
    /// <summary>
    /// user name
    /// </summary>
    public string UserName { get; set; }
    /// <summary>
    /// password for access
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// database name
    /// </summary>
    public string DataBaseTitle { get; set; }
    /// <summary>
    /// connection string
    /// </summary>
    public string ConnectionString { get; set; }
    /// <summary>
    /// If tru then db is connected
    /// </summary>
    public bool DataBaseConnected { get; set; }
    #endregion

    #region function
    /// <summary>
    /// 
    /// </summary>
    /// <param name="passwordDB"></param>
    public abstract void SetPassword(string passwordDB);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    public abstract void SetLogin(string UserID);

    /// <summary>
    /// Устанавливает сервер базы данных для соединения
    /// </summary>
    /// <param name="serverIP">The server identifier.</param>
    public abstract void SetSeverIP(string serverIP);

    /// <summary>
    /// Устанавливает базу данных для соединения
    /// </summary>
    /// <param name="DBId">The database identifier.</param>
    public abstract void SetDataBase(string DBId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="portId"></param>
    public abstract void SetPort(string portId);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string CollectConnectionString()
    {
        return ConnectionString = ServerIP + PortNumber + UserName + Password + DataBaseTitle;
    }
    #endregion

    /// <summary>
    /// Collect connection string to DB 
    /// </summary>
    public void SetConnectionString()
    {
        ConnectionString = ServerIP + PortNumber + UserName +
            Password + DataBaseTitle;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="server"></param>
    /// <param name="port"></param>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <param name="port"></param>
    /// <returns></returns>
    public abstract string CollectConnectionString(string server, string port, string userId, string password, string db);
    /// <summary>
    /// Sql request sended ones
    /// </summary>
    /// <param name="ConnectingString">Connection string</param>
    /// <param name="SQLcmd">SQL request</param>
    /// <returns></returns>
    public abstract bool DBSendCMDOnce(string ConnectingString, string SQLcmd);
    /// <summary>
    /// Variable for connection checking 
    /// </summary>
    /// <returns></returns>
    public abstract bool ConnectDBCheck();
    /// <summary>
    /// Open connection to Database
    /// </summary>
    public abstract bool DBOpen();
    /// <summary>
    /// Open connection to Database
    /// </summary>
    /// <param name="ConnectingString"></param>
    /// <returns>true if data base was connected</returns>
    public abstract bool DBOpen(string ConnectingString);
    /// <summary>
    /// Closу connection to database
    /// </summary>
    /// <param name="ConnectingString"></param>
    /// <param name="SQLcmd"></param>
    /// <returns>true if DataBase connection was close</returns>
    public abstract bool DBClose();
    /// <summary>
    /// Databases the send command.
    /// </summary>
    /// <param name="SQLcmd"></param>
    /// <returns></returns>
    public abstract bool DBSendCMD(string SQLcmd);
    /// <summary>
    /// Databases the export data random1.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns>bool</returns>
    public abstract bool DBExportDataRandom1Once(DataGridView DG, string ConnectingString, string TableName);
    /// <summary>
    /// Databases the export data string.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <param name="i">The i.</param>
    /// <returns></returns>
    public abstract string DBExportDataString(DataGridView DG, string TableName, int i);
    /// <summary>
    /// Databases the create table random meas.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public abstract bool DBCreateTableRandomMeasOnce(DataGridView DG, string TableName);
    /// <summary>
    /// Exports the SQL file.
    /// </summary>
    /// <param name="FileName">Name of the file.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <returns>boolean</returns>
    public abstract bool ExportSQLFileOnce(string FileName, string ConnectingString);
    /// <summary>
    /// Databases the create table random meas.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public abstract bool DBCreateTableRandomMeasOnce(DataGridView DG, string ConnectingString, string TableName);
    /// <summary>
    /// Databases the create table SQL command.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public abstract string DBCreateTableSQLCommand(DataGridView DG, string TableName);
    /// <summary>
    /// Databases the create table for meas.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public abstract bool DBCreateTableForMeasOnce(DataGridView DG, string ConnectingString, string TableName);
    /// <summary>
    /// Databases the export data random.
    /// </summary>
    /// <param name="DG"></param>
    /// <param name="ConnectingString"></param>
    /// <param name="TableName"></param>
    /// <returns></returns>
    public abstract bool DBExportDataRandomOnce(DataGridView DG, string ConnectingString, string TableName);
    /// <summary>
    /// Databases the export data common.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public abstract bool DBExportDataCommonOnce(DataGridView DG, string ConnectingString, string TableName);
    /// <summary>
    /// Corrects the input string.
    /// </summary>
    /// <param name="IN">The in.</param>
    /// <param name="CompareString">The compare string.</param>
    /// <returns></returns>
    public abstract string CorrectInputString(string IN, string CompareString);
    /// <summary>
    /// Replaces the common.
    /// </summary>
    /// <param name="IN">The in.</param>
    /// <returns></returns>
    public abstract string replaceCommon(string IN);

    /// <summary>
    /// Exports the data to data base from directory C:\temp.
    /// </summary>
    /// <param name="view">The view.</param>
    /// <param name="conDb">The con database.</param>
    public abstract void ExportDataToDataBaseTemp(DataGridView view, string conDb);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="view"></param>
    /// <param name="conDB"></param>
    public abstract void ExportDataToDataBaseTempAll(DataGridView view, string conDB);

    #region read data from DB
    /// <summary>
    /// Read result with out closing of connection
    /// </summary>
    public abstract bool DBDataReader_records(string sql);
    /// <summary>
    /// Read result only once and then close connection
    /// </summary>
    public abstract bool DBDataReader_records_once(string sql);
    #endregion

}