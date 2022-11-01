using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kalipso.Сalculations;
using System.Dynamic;
using System.Data.Common;

public class DBconnect : DataBaseConnect
{
    #region set function of connect string
    /// <summary>
    /// Set IP address of server with DB
    /// </summary>
    /// <param name="serverIP"></param>
    public override void SetSeverIP(string serverIP)
    {
        ServerIP += "Server=" + serverIP + ";";
    }
    /// <summary>
    /// Set data base title
    /// </summary>
    /// <param name="DBTitle">The database identifier.</param>
    public override void SetDataBase(string DBTitle)
    {
        DataBaseTitle += "Database=" + DBTitle + ";";
    }
    /// <summary>
    /// Устанавливает Логин для соединения
    /// </summary>
    public override void SetLogin(string login)
    {
        UserName += "User Id=" + login + ";";
    }
    /// <summary>
    /// Устанавливает порт сервера базы данных для соединения
    /// </summary>
    public override void SetPort(string portId)
    {
        PortNumber += "Port = " + portId + ";";
    }
    /// <summary>
    /// Устанавливает пароль базы данных для соединения
    /// </summary>
    /// <param name="passwordDB">The password database.</param>
    public override void SetPassword(string passwordDB)
    {
        Password += "Password=" + passwordDB + ";";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="server"></param>
    /// <param name="port"></param>
    /// <param name="userId"></param>
    /// <param name="password"></param>
    /// <param name="db"></param>
    /// <returns></returns>
    public override string CollectConnectionString(string server, string port, string userId, string password, string db)
    {
        return ConnectionString = server + port + userId + password + db;
    }
    #endregion

    #region check connection to DataBase
    public override bool ConnectDBCheck()
    {
        try
        {
            string connect = ServerIP + PortNumber + UserName + Password + DataBaseTitle;
            pgconnection.Open();
            pgconnection.Close();
            DataBaseConnected=true;
            return true;
        }
        catch (Exception msg)
        {
            // something went wrong, and you wanna know why
            MessageBox.Show(msg.ToString());
            throw;
        }
    }

    public override bool DBOpen()
    {
        try
        {
            pgconnection.ConnectionString = ConnectionString;
            pgconnection.Open();
            pgcommandSend.Connection = pgconnection;
            return true;
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg.ToString());
            return false;
        }
    }

    public override bool DBOpen(string ConnectingString)
    {
        try
        {
            pgconnection.ConnectionString = ConnectingString;
            pgconnection.Open();
            pgcommandSend.Connection = pgconnection;
            return true;
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg.ToString());
            return false;
        }
    }
    /// <summary>
    /// Closу connection to database
    /// </summary>
    /// <param name="ConnectingString"></param>
    /// <param name="SQLcmd"></param>
    /// <returns></returns>
    public override bool DBClose()
    {
        try
        {
            pgconnection.Close();
            return true;
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg.ToString());
            return false;
        }
    }
    #endregion

    #region send record
    /// <summary>
    /// Databases the send command.
    /// </summary>
    public override bool DBSendCMD(string SQLcmd)
    {
        try
        {
            pgcommandSend.Connection = pgconnection;
            pgcommandSend.CommandText = SQLcmd;
            pgcommandSend.ExecuteNonQuery();
            return true;
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg.ToString());
            return false;
        }
    }
    /// <summary>
    /// Databases the send command.
    /// </summary>
    public override bool DBSendCMDOnce(string ConnectingString, string SQLcmd)
    {
        try
        {
            pgconnection.ConnectionString = ConnectingString;
            pgconnection.Open();
            pgcommandSend.Connection = pgconnection;
            pgcommandSend.CommandText = SQLcmd;
            pgcommandSend.ExecuteNonQuery();
            pgconnection.Close();
            return true;
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg.ToString());
            return false;
        }
    }


    #endregion

    /// <summary>
    /// Exports the SQL file.
    /// </summary>
    /// <param name="FileName">Name of the file.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <returns>boolean</returns>
    public override bool ExportSQLFileOnce(string FileName, string ConnectingString)
    {
        FileJob fj = new FileJob();
        string[] sql = fj.ReadF(FileName);
        try
        {
            NpgsqlConnection pgcon = new NpgsqlConnection(ConnectingString);
            pgcon.Open();
            for (int i = 0; i < sql.Count(); i++)
            {
                NpgsqlCommand CSend = new NpgsqlCommand(sql[i], pgcon);
                CSend.ExecuteNonQuery();
            }
            pgcon.Close();
            return true;
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg.ToString());
            return false;
        }

    }

    #region create table

    /// <summary>
    /// Databases the create table random meas.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public override bool DBCreateTableRandomMeasOnce(DataGridView DG, string ConnectingString, string TableName)
    {
        string s = "";
        for (int i = 0; i < DG.Columns.Count; i++)
        {
            if (DG.Columns[i].HeaderText == "id")
            {
                s = s + DG.Columns[i].HeaderText + " SERIAL PRIMARY KEY, ";
            }
            if (DG.Columns[i].HeaderText == Constants.id_section ||
                DG.Columns[i].HeaderText == Constants.direction ||
                DG.Columns[i].HeaderText == Constants.meas_type ||
                DG.Columns[i].HeaderText == Constants.Operator)
            {
                s = s + DG.Columns[i].HeaderText + " text, ";
            }
            if (DG.Columns[i].HeaderText == Constants.id_sample)
            {
                s = s + DG.Columns[i].HeaderText + " INT, ";
            }
            if (DG.Columns[i].HeaderText == Constants.Tsint ||
                DG.Columns[i].HeaderText == Constants.h_cm ||
                DG.Columns[i].HeaderText == Constants.d_cm ||
                DG.Columns[i].HeaderText == Constants.T_K ||
                DG.Columns[i].HeaderText == Constants.Cs ||
                DG.Columns[i].HeaderText == Constants.Cp ||
                DG.Columns[i].HeaderText == Constants.e_re ||
                DG.Columns[i].HeaderText == Constants.tgd2 ||
                DG.Columns[i].HeaderText == Constants.e_im ||
                DG.Columns[i].HeaderText == Constants.tgd ||
                DG.Columns[i].HeaderText == Constants.Y ||
                DG.Columns[i].HeaderText == Constants.Ubias ||
                DG.Columns[i].HeaderText == Constants.Hbias ||
                DG.Columns[i].HeaderText == "Timer_disp" ||
                DG.Columns[i].HeaderText == Constants.cur_timer
                )
            {
                s = s + DG.Columns[i].HeaderText + " double precision, ";
            }
            if (DG.Columns[i].HeaderText == Constants.f ||
                DG.Columns[i].HeaderText == Constants.CycleNum
                )
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
        string sql = "Create table " + TableName + " (" + s + " description text);";

        NpgsqlConnection pgcon = new NpgsqlConnection(ConnectingString);
        NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
        try
        {
            pgcon.Open();
        }
        catch (Exception)
        {
            return false;
        }
        try
        {
            CSend.ExecuteNonQuery();
            pgcon.Close();
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            pgcon.Close();
            return false;
        }
    }

    /// <summary>
    /// Databases the create table random meas.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public override bool DBCreateTableRandomMeasOnce(DataGridView DG, string TableName)
    {
        string s = "";
        for (int i = 0; i < DG.Columns.Count; i++)
        {
            if (DG.Columns[i].HeaderText == "id")
            {
                s = s + DG.Columns[i].HeaderText + " SERIAL PRIMARY KEY, ";
            }
            if (DG.Columns[i].HeaderText == Constants.id_section ||
                DG.Columns[i].HeaderText == Constants.direction ||
                DG.Columns[i].HeaderText == Constants.meas_type ||
                DG.Columns[i].HeaderText == Constants.Operator)
            {
                s = s + DG.Columns[i].HeaderText + " text, ";
            }
            if (DG.Columns[i].HeaderText == Constants.id_sample)
            {
                s = s + DG.Columns[i].HeaderText + " INT, ";
            }
            if (DG.Columns[i].HeaderText == Constants.Tsint ||
                DG.Columns[i].HeaderText == Constants.h_cm ||
                DG.Columns[i].HeaderText == Constants.d_cm ||
                DG.Columns[i].HeaderText == Constants.T_K ||
                DG.Columns[i].HeaderText == Constants.Cs ||
                DG.Columns[i].HeaderText == Constants.Cp ||
                DG.Columns[i].HeaderText == Constants.e_re ||
                DG.Columns[i].HeaderText == Constants.tgd2 ||
                DG.Columns[i].HeaderText == Constants.e_im ||
                DG.Columns[i].HeaderText == Constants.tgd ||
                DG.Columns[i].HeaderText == Constants.Y ||
                DG.Columns[i].HeaderText == Constants.Ubias ||
                DG.Columns[i].HeaderText == Constants.Hbias ||
                DG.Columns[i].HeaderText == "Timer_disp" ||
                DG.Columns[i].HeaderText == Constants.cur_timer
                )
            {
                s = s + DG.Columns[i].HeaderText + " double precision, ";
            }
            if (DG.Columns[i].HeaderText == Constants.f ||
                DG.Columns[i].HeaderText == Constants.CycleNum
                )
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
        string sql = "Create table " + TableName + " (" + s + " description text);";
        try
        {
            DBSendCMD(sql);
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }
    /// <summary>
    /// Databases the create table for meas.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public override bool DBCreateTableForMeasOnce(DataGridView DG, string ConnectingString, string TableName)
    {
        NpgsqlConnection pgcon = new NpgsqlConnection(ConnectingString);
        try
        {
            pgcon.Open();
        }
        catch (Exception)
        {
            return false;
        }
        string sql = DBCreateTableSQLCommand(DG, TableName);
        NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
        try
        {
            CSend.ExecuteNonQuery();
            pgcon.Close();
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            pgcon.Close();
            return false;
        }
    }
    /// <summary>
    /// Databases the create table SQL command.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public override string DBCreateTableSQLCommand(DataGridView DG, string TableName)
    {
        string s = "";
        for (int i = 0; i < DG.Columns.Count; i++)
        {
            switch (DG.Columns[i].HeaderText)
            {
                case Constants.id: s = s + DG.Columns[i].HeaderText + " SERIAL PRIMARY KEY, "; break;
                case Constants.composition: s = s + DG.Columns[i].HeaderText + " text, "; break;
                case Constants.solid_state: s = s + DG.Columns[i].HeaderText + " text, "; break;
                case Constants.direction: s = s + DG.Columns[i].HeaderText + " text, "; break;
                case Constants.meas_type: s = s + DG.Columns[i].HeaderText + " text, "; break;
                case Constants.polarity: s = s + DG.Columns[i].HeaderText + " text, "; break;
                case Constants.Operator: s = s + DG.Columns[i].HeaderText + " text, "; break;
                case Constants.comments: s = s + DG.Columns[i].HeaderText + " text, "; break;
                case Constants.id_sample: s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case Constants.id_section: s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case Constants.step: s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case Constants.f: s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case Constants.CycleNum: s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case Constants.CurTime: s = s + DG.Columns[i].HeaderText + " time, "; break;
                case Constants.CurDate: s = s + DG.Columns[i].HeaderText + " date, "; break;
                default:
                    s = s + DG.Columns[i].HeaderText + " double precision, "; break;
            }
        }
        string sql = "Create table " + TableName + " (" + s + " description text);";
        return sql;
    }
    #endregion

    #region export data to DB
    public override bool DBExportDataCommonOnce(DataGridView DG, string ConnectingString, string TableName)
    {
        NpgsqlConnection pgcon = new NpgsqlConnection(ConnectingString);
        try
        {
            pgcon.Open();
        }
        catch (Exception)
        {
            return false;
        }
        for (int i = 0; i < DG.RowCount - 1; i++)
        {
            string sql = "";
            string sql_data = "";
            sql = "Insert into " + TableName + " (";
            for (int j = 0; j < DG.ColumnCount; j++)
            {
                if (j == DG.ColumnCount - 1)
                {
                    sql = sql + DG.Columns[j].Name + ") ";
                }
                else sql = sql + DG.Columns[j].Name + ", ";
            }

            for (int j = 0; j < DG.ColumnCount; j++)
            {
                string s1 = DG.Rows[i].Cells[j].Value.ToString();
                switch (DG.Columns[j].Name)
                {
                    case Constants.id_section: sql_data = sql_data + "'" + CorrectInputString(CorrectInputString(s1, "-"), "-") + "', "; break;
                    case Constants.direction: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                    case Constants.meas_type: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                    case Constants.Operator: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                    case Constants.CurTime: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                    case Constants.CurDate: sql_data = sql_data + " TO_DATE ( '" + CorrectInputString(s1 + "', 'DD.MM.YYYY')", "-") + ", "; break;
                    default: sql_data = sql_data + CorrectInputString(s1, "-") + ", "; break;
                }
            }
            sql_data = sql_data.Substring(0, sql_data.Length - 1);
            sql = sql + " values (" + sql_data + ");";
            NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
            try
            {
                CSend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pgcon.Close();
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        pgcon.Close();
        return true;
    }

    public override string DBExportDataString(DataGridView DG, string TableName, int i)
    {
        string sql = "";
        string sql_data = "";
        sql = "Insert into " + TableName + " (";

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
            string s2 = DG.Columns[j].Tag.ToString();
            if (DG.Rows[i].Cells[j].Value == null)
            {
                DG.Rows[i].Cells[j].Value = "";
            }
            string s1 = DG.Rows[i].Cells[j].Value.ToString();
            switch (DG.Columns[j].Name)
            {
                case Constants.id_section: sql_data = sql_data + "'" + s1 + "', "; break;
                case Constants.direction: sql_data = sql_data + "'" + s1 + "', "; break;
                case Constants.meas_type: sql_data = sql_data + "'" + s1 + "', "; break;
                case Constants.Operator: sql_data = sql_data + "'" + s1 + "', "; break;
                case Constants.CurTime: sql_data = sql_data + "'" + s1 + "', "; break;
                case Constants.CurDate: sql_data = sql_data + " TO_DATE ( '" + CorrectInputString(s1 + "', 'DD.MM.YYYY')", "-") + ", "; break;
                default: sql_data = sql_data + "'" + s1 + "', "; break;
            }
        }
        sql_data = sql_data.Substring(0, sql_data.Length - 2);
        sql = sql + " values (" + sql_data + ");";
        return sql;
    }

    public override bool DBExportDataRandomOnce(DataGridView DG, string ConnectingString, string TableName)
    {
        NpgsqlConnection pgcon = new NpgsqlConnection(ConnectingString);
        try
        {
            pgcon.Open();
        }
        catch (Exception)
        {
            return false;
        }
        for (int i = 0; i < DG.RowCount - 1; i++)
        {

            string sql = "";
            string sql_data = "";
            sql = "Insert into " + TableName + "(";
            for (int j = 0; j < DG.ColumnCount; j++)
            {
                if (j == DG.ColumnCount - 1)
                {
                    sql = sql + DG.Columns[j].Name + ") ";
                }
                else sql = sql + DG.Columns[j].Name + ", ";
            }
            for (int j = 0; j < DG.ColumnCount; j++)
            {
                string s1 = DG.Rows[i].Cells[j].Value.ToString();
                switch (DG.Columns[j].Name)
                {
                    case Constants.id_section: sql_data = sql_data + "'" + CorrectInputString(CorrectInputString(s1, "-"), "-") + "', "; break;
                    case Constants.direction: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                    case Constants.meas_type: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                    case Constants.Operator: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                    case Constants.CurTime: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                    case Constants.CurDate: sql_data = sql_data + " TO_DATE ( '" + CorrectInputString(s1 + "', 'DD.MM.YYYY')", "-") + ", "; break;
                    default: sql_data = sql_data + CorrectInputString(s1.Replace(',', '.'), "-") + ", "; break;
                }
            }

            sql_data = sql_data.Substring(0, sql_data.Length - 2);
            sql = sql + " values (" + sql_data + ");";
            NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
            try
            {
                CSend.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                pgcon.Close();
                MessageBox.Show(ex.ToString() + "\n " + sql);
                return false;
            }
        }
        pgcon.Close();
        return true;
    }

    public override bool DBExportDataRandom1Once(DataGridView DG, string ConnectingString, string TableName)
    {
        NpgsqlConnection pgcon = new NpgsqlConnection(ConnectingString);
        try
        {
            pgcon.Open();
        }
        catch (Exception)
        {
            return false;
        }
        for (int i = 0; i < DG.RowCount - 1; i++)
        {
            string sql_data1 = "";
            for (int j = 0; j < DG.ColumnCount; j++)
            {
                sql_data1 = sql_data1 + DG.Rows[i].Cells[j].Value.ToString();
            }
            if (sql_data1 != "")
            {
                string sql = "";
                string sql_data = "";
                sql = "Insert into " + TableName + "(";
                for (int j = 0; j < DG.ColumnCount; j++)
                {
                    if (j == DG.ColumnCount - 1)
                    {
                        sql = sql + DG.Columns[j].Name + ") ";
                    }
                    else sql = sql + DG.Columns[j].Name + ", ";
                }
                for (int j = 0; j < DG.ColumnCount; j++)
                {
                    string s1 = DG.Rows[i].Cells[j].Value.ToString();
                    switch (DG.Columns[j].Name)
                    {
                        case Constants.id_section: sql_data = sql_data + "'" + CorrectInputString(CorrectInputString(s1, "-"), "-") + "', "; break;
                        case Constants.direction: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                        case Constants.meas_type: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                        case Constants.Operator: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                        case Constants.CurTime: sql_data = sql_data + "'" + CorrectInputString(s1, "-") + "', "; break;
                        case Constants.CurDate: sql_data = sql_data + " TO_DATE ( '" + CorrectInputString(s1 + "', 'DD.MM.YYYY')", "-") + ", "; break;
                        default: sql_data = sql_data + CorrectInputString(s1.Replace(',', '.'), "-") + ", "; break;
                    }
                }
                sql_data = sql_data.Substring(0, sql_data.Length - 2);
                sql = sql + " values (" + sql_data + ");";
                NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
                try
                {
                    CSend.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    pgcon.Close();
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }
        pgcon.Close();
        return true;
    }
    #endregion

    #region chek input string
    public override string CorrectInputString(string IN, string CompareString)
    {
        if (IN == CompareString)
        {
            return IN = "-1";
        }
        return IN;
    }

    public override string replaceCommon(string IN)
    {
        return IN.Replace(',', '.');
    }
    #endregion

    public override void ExportDataToDataBaseTemp(DataGridView view, string conDb)
    {
        FileJob fileJ = new FileJob();
        string[] filesname = Directory.GetFiles(@"C:\\temp\\");
        for (int i = 0; i < filesname.Length; i++)
        {
            fileJ.Common_Import(filesname[i], view);
            string[] names = filesname[i].Split(Convert.ToChar(92)); //devide string to array using as delimeter '\'
            string[] s = names[names.Length - 1].Split(Convert.ToChar(46));//devide string to array using as delimeter '.'
            string[] s1 = s[0].Split('_'); //devide string to array using as delimeter '_'
            //export to database
            DBconnect dBConn = new DBconnect();
            dBConn.DBCreateTableRandomMeasOnce(view, conDb, s1[0]);
            dBConn.DBExportDataCommonOnce(view, conDb, s1[0]);
        }
        //copying files from C:\temp to subdirectory .\resolved
        fileJ.CopyResolvedFiles();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="view"></param>
    /// <param name="conDB"></param>
    public override void ExportDataToDataBaseTempAll(DataGridView view, string conDB)
    {
        FileJob fj = new FileJob();
        string[] filesname = Directory.GetFiles(@"C:\\temp\\");
        //ProgressDB.Maximum = filesname.Length;
        string name = "";
        for (int i = 0; i < filesname.Length; i++)
        {
            fj.DNON_RNON_Import(filesname[i], view);//импорт файла
            string[] names = filesname[i].Split(Convert.ToChar(92)); //разделение строки на массив по символу '\'
            string[] s = names[names.Length - 1].Split(Convert.ToChar(46));//разделение строки на массив по символу '.'
            name = s[s.Length - 2].Replace("DNON", "");//замена подстроки на "" 
            //кусок отвечающий за экспорт в базу данных 
            DBconnect dBConn = new DBconnect();
            dBConn.DBCreateTableRandomMeasOnce(view, conDB, name);
            dBConn.DBExportDataRandomOnce(view, conDB, name);
            //пропуск фалов с RNON.txt
            ++i;
            //ProgressDB.Value = i;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public override bool DBDataReader_records(string sql)
    {
        try
        {
            pgcommandSend.CommandText = sql;
            pgcommandSend.ExecuteNonQuery();
            pgreader = pgcommandSend.ExecuteReader();
            if (pgreader.HasRows)  return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
        return false;
    }


    //--------------------------------------------------------------------------------------------------
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public IEnumerable<dynamic> Execute(string sql)
    {

        pgconnection.ConnectionString = ConnectionString;
        pgconnection.Open();
        pgcommandSend.CommandText = sql;
        pgcommandSend.Connection = pgconnection;

        var names = new string[pgreader.FieldCount];
            var values = new object[pgreader.FieldCount];

            for (var i = 0; i < pgreader.FieldCount; i++)
            {
                names[i] = pgreader.GetName(i);
            }

            while (pgreader.Read())
            {
                pgreader.GetValues(values);
                yield return new SqlResult(names, values);
            }
    }


    public struct dbqq
    {
        public string[] names;
        public string[] values;
        public List<List<string>> val;
    }


    public void dbread(string sql)
    {
        pgconnection.ConnectionString = ConnectionString;
        pgconnection.Open();
        pgcommandSend.CommandText = sql;
        pgcommandSend.Connection = pgconnection;
        pgcommandSend.ExecuteNonQuery();
        pgreader = pgcommandSend.ExecuteReader();
        dbqq ss = new dbqq();
        int colcount = pgreader.FieldCount;
        ss.names  = new string[colcount];
            for (var i = 0; i < pgreader.FieldCount; i++)
            {
                ss.names[i] = pgreader.GetName(i);
            }
        int rowcount = 0;
        
        if (pgreader.HasRows)
        {
            foreach (DbDataRecord dbDataReader in pgreader)
            {
                ss.val.Add(new List<string>());
                for (int i = 0; i < pgreader.FieldCount; i++)
                {
                    string s = dbDataReader[dbDataReader.GetName(i)].ToString();
                    ss.val[ss.val.Count-1].Add(s);
                }
            }
            ss.values = new string[rowcount];

            foreach (DbDataRecord dbDataReader in pgreader)
            {

                int celsel = 0;
                for (int i = 0; i < pgreader.FieldCount; i++)
                {
                    ss.values[celsel] = dbDataReader[dbDataReader.GetName(i)].ToString();
                }
                ++celsel;
            }
        }

        //List<List<string>> myList = new List<List<string>>();
        //myList.Add(new List<string> { "a", "b" });
        //myList.Add(new List<string> { "c", "d", "e" });
        //myList.Add(new List<string> { "qwerty", "asdf", "zxcv" });
        //myList.Add(new List<string> { "a", "b" });
        //// To iterate over it.
        //foreach (List<string> subList in myList)
        //{
        //    foreach (string item in subList)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}


        //ss.values = new string[rowcount];

        //foreach (DbDataRecord dbDataReader in pgreader)
        //{

        //int celsel = 0;
        //for (int i = 0; i < pgreader.FieldCount; i++)
        //    {
        //        ss.values[celsel]= dbDataReader[dbDataReader.GetName(i)].ToString();
        //    }
        //    ++celsel;
        //}
        string pp = "fdf";
        pgconnection.Close();
    }

    void FillRequestData()
    {
        
        
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


    public override bool DBDataReader_records_once(string sql)
    {
        pgconnection.ConnectionString = ConnectionString;
        pgconnection.Open();
        pgcommandSend.CommandText = sql;
        pgcommandSend.Connection = pgconnection;
        try
        {
            pgcommandSend.ExecuteNonQuery();
            pgreader = pgcommandSend.ExecuteReader();
            
            if (pgreader.HasRows)
            {
                pgconnection.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }
}

public class SqlResult : DynamicObject
{
    private readonly Dictionary<string, object> _columns;

    public SqlResult(IList<string> names, IList<object> values)
    {
        _columns = new Dictionary<string, object>();

        for (var i = 0; i < names.Count; i++)
        {
            _columns.Add(names[i], values[i]);
        }
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        return _columns.TryGetValue(binder.Name, out result);
    }
}

