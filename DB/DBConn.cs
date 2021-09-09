using Npgsql;



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;






class DBConn
{
    /// <summary>
    /// Databases the send command.
    /// </summary>
    public bool DBSendCMD(string ConnectingString, string SQLcmd)
    {
        try
        {
            NpgsqlConnection pgcon = new NpgsqlConnection(ConnectingString);
            pgcon.Open();
            NpgsqlCommand CSend = new NpgsqlCommand(SQLcmd, pgcon);
            CSend.ExecuteNonQuery();
            pgcon.Close();
            return true;
        }
        catch (Exception msg)
        {
            Console.WriteLine(msg.ToString());
            return false;
        }
    }
    /// <summary>
    /// Exports the SQL file.
    /// </summary>
    /// <param name="FileName">Name of the file.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <returns>boolean</returns>
    public bool ExportSQLFile(string FileName, string ConnectingString)
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
    /// <summary>
    /// Databases the create table random meas.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public bool DBCreateTableRandomMeas(DataGridView DG, string ConnectingString, string TableName)
    {
        string s = "";
        for (int i = 0; i < DG.Columns.Count; i++)
        {
            if (DG.Columns[i].HeaderText == "id")
            {
                s = s + DG.Columns[i].HeaderText + " SERIAL PRIMARY KEY, ";
            }
            if (DG.Columns[i].HeaderText == "id_section" ||
                DG.Columns[i].HeaderText == "Direct" ||
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
                DG.Columns[i].HeaderText == "t_cm" ||
                DG.Columns[i].HeaderText == "d_cm" ||
                DG.Columns[i].HeaderText == "T_K" ||
                DG.Columns[i].HeaderText == "C_pF" ||
                DG.Columns[i].HeaderText == "e_re" ||
                DG.Columns[i].HeaderText == "tgd1e2" ||
                DG.Columns[i].HeaderText == "e_im" ||
                DG.Columns[i].HeaderText == "tgd" ||
                DG.Columns[i].HeaderText == "Y" ||
                DG.Columns[i].HeaderText == "Ubias_V" ||
                DG.Columns[i].HeaderText == "Hbias_T" ||
                DG.Columns[i].HeaderText == "Timer_disp" ||
                DG.Columns[i].HeaderText == "Timer"
                )
            {
                s = s + DG.Columns[i].HeaderText + " double precision, ";
            }
            if (DG.Columns[i].HeaderText == "f_Hz" ||
                DG.Columns[i].HeaderText == "Cycle"
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
    /// Databases the create table for meas.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public bool DBCreateTableForMeas(DataGridView DG, string ConnectingString, string TableName)
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
    public string DBCreateTableSQLCommand(DataGridView DG, string TableName)
    {
        string s = "";
        for (int i = 0; i < DG.Columns.Count; i++)
        {
            switch (DG.Columns[i].HeaderText)
            {
                case "id": s = s + DG.Columns[i].HeaderText + " SERIAL PRIMARY KEY, "; break;

                case "composition": s = s + DG.Columns[i].HeaderText + " text, "; break;
                case "solid_state": s = s + DG.Columns[i].HeaderText + " text, "; break;
                case "Direction": s = s + DG.Columns[i].HeaderText + " text, "; break;
                case "Meas_type": s = s + DG.Columns[i].HeaderText + " text, "; break;
                case "Direct": s = s + DG.Columns[i].HeaderText + " text, "; break;
                case "Polarity": s = s + DG.Columns[i].HeaderText + " text, "; break;
                case "operator": s = s + DG.Columns[i].HeaderText + " text, "; break;
                case "comments": s = s + DG.Columns[i].HeaderText + " text, "; break;

                case "id_sample": s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case "Step": s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case "f_Hz": s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case "Cycle": s = s + DG.Columns[i].HeaderText + " INT, "; break;
                case "Timer": s = s + DG.Columns[i].HeaderText + " double precision, "; break;


                case "Tsint_K": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "t_cm": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "d_cm": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "T_K": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "C_pF": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "e_re": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "tgd1e2": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "e_im": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "tgd": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "Y": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "Ubias_V": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "Hbias_T": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "Xi": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "Xi0": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "Xi-Xi0": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "Uout_V": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "E_kV_Div_cm": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "k_10_E_4": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "d33rev_m_V": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "d33rev": s = s + DG.Columns[i].HeaderText + " double precision, "; break;
                case "Timer_disp": s = s + DG.Columns[i].HeaderText + " double precision, "; break;

                case "Time": s = s + DG.Columns[i].HeaderText + " time, "; break;

                case "Date": s = s + DG.Columns[i].HeaderText + " date, "; break;

                default:
                    s = s + DG.Columns[i].HeaderText + " double precision, "; break;
            }
            #region comments
            //if (DG.Columns[i].HeaderText == "id")
            //{
            //    s = s + DG.Columns[i].HeaderText + " SERIAL PRIMARY KEY, ";
            //}
            //if (DG.Columns[i].HeaderText == "id_section" ||
            //    DG.Columns[i].HeaderText == "Direction" ||
            //    DG.Columns[i].HeaderText == "Meas_type" ||
            //    DG.Columns[i].HeaderText == "Direct" ||
            //    DG.Columns[i].HeaderText == "Polarity" ||
            //    DG.Columns[i].HeaderText == "operator")
            //{
            //    s = s + DG.Columns[i].HeaderText + " text, ";
            //}
            //if (DG.Columns[i].HeaderText == "id_sample" ||
            //    DG.Columns[i].HeaderText == "Step")
            //{
            //    s = s + DG.Columns[i].HeaderText + " INT, ";
            //}


            //if (DG.Columns[i].HeaderText == "Tsint_K" ||
            //    DG.Columns[i].HeaderText == "t_cm" ||
            //    DG.Columns[i].HeaderText == "d_cm" ||
            //    DG.Columns[i].HeaderText == "T_K" ||
            //    DG.Columns[i].HeaderText == "T_K" ||
            //    DG.Columns[i].HeaderText == "C_pF" ||
            //    DG.Columns[i].HeaderText == "e_re" ||
            //    DG.Columns[i].HeaderText == "tgd1e2" ||
            //    DG.Columns[i].HeaderText == "e_im" ||
            //    DG.Columns[i].HeaderText == "tgd" ||
            //    DG.Columns[i].HeaderText == "Y" ||
            //    DG.Columns[i].HeaderText == "Ubias_V" ||
            //    DG.Columns[i].HeaderText == "Hbias_T" ||
            //    DG.Columns[i].HeaderText == "Xi" ||
            //    DG.Columns[i].HeaderText == "Xi0" ||
            //    DG.Columns[i].HeaderText == "Xi-Xi0" ||
            //    DG.Columns[i].HeaderText == "Uout_V" ||
            //    DG.Columns[i].HeaderText == "E_kV_Div_cm" ||

            //    DG.Columns[i].HeaderText == "k_10_E_4" ||
            //    DG.Columns[i].HeaderText == "d33rev_m_V" ||
            //    DG.Columns[i].HeaderText == "d33rev" ||
            //    DG.Columns[i].HeaderText == "Timer_disp"
            //    )
            //{
            //    s = s + DG.Columns[i].HeaderText + " double precision, ";
            //}

            //if (DG.Columns[i].HeaderText == "f_Hz" ||
            //    DG.Columns[i].HeaderText == "Cycle" ||
            //    DG.Columns[i].HeaderText == "Timer")
            //{
            //    s = s + DG.Columns[i].HeaderText + " INT, ";
            //}
            //if (DG.Columns[i].HeaderText == "Time")
            //{
            //    s = s + DG.Columns[i].HeaderText + " time, ";
            //}
            //if (DG.Columns[i].HeaderText == "Date")
            //{
            //    s = s + DG.Columns[i].HeaderText + " date, ";
            //}
            #endregion
        }

        string sql = "Create table " + TableName + " (" + s + " description text);";
        return sql;
    }

    /// <summary>
    /// Databases the export data common.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns></returns>
    public bool DBExportDataCommon(DataGridView DG, string ConnectingString, string TableName)
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
            //for (int j = 1; j < DG.ColumnCount; j++)
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
                switch (DG.Columns[j].Name)
                {
                    case "id_section": sql_data = sql_data + "'" + CorrectInputString(CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-"), "-") + "', "; break;
                    case "Direct": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                    case "Meas_type": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                    case "operator": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                    case "Time": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                    case "Date": sql_data = sql_data + " TO_DATE ( '"+ CorrectInputString(DG.Rows[i].Cells[j].Value.ToString() + "', 'DD.MM.YYYY')", "-") + ", "; break;
                    default: sql_data = sql_data + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + ", "; break;
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
    /// <summary>
    /// Databases the export data string.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <param name="i">The i.</param>
    /// <returns></returns>
    public string DBExportDataString(DataGridView DG, string TableName, int i)
    {
        string sql = "";
        string sql_data = "";
        sql = "Insert into " + TableName + " (";
        //for (int j = 1; j < DG.ColumnCount-1 ; j++)
        for (int j = 1; j < DG.ColumnCount; j++)
        {
            if (j == DG.ColumnCount-1)
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
                    case "id_section": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                    case "Direct": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                    case "Meas_type": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                    case "operator": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                    case "Time": sql_data = sql_data + "'" + DG.Rows[i].Cells[j].Value.ToString() + "', "; break;
                    case "Date": sql_data = sql_data + " TO_DATE ( '"+ CorrectInputString(DG.Rows[i].Cells[j].Value.ToString() + "', 'DD.MM.YYYY')", "-") + ", "; break;
                    default: sql_data = sql_data + "'" + s1 + "', "; break;
                }
        }
        //sql_data = sql_data + "'" + DG.Rows[i].Cells[DG.ColumnCount-1].Value.ToString() + "'";
        

        sql_data = sql_data.Substring(0, sql_data.Length - 2);
        sql = sql + " values (" + sql_data + ");";
        return sql;
    }

    /// <summary>
    /// Databases the export data random.
    /// </summary>
    /// <param name="DG"></param>
    /// <param name="ConnectingString"></param>
    /// <param name="TableName"></param>
    /// <returns></returns>
    public bool DBExportDataRandom(DataGridView DG, string ConnectingString, string TableName)
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
                switch (DG.Columns[j].Name)
                {
                    case "id_section": sql_data = sql_data + "'" + CorrectInputString(CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-"), "-") + "', "; break;
                    case "Direct": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                    case "Meas_type": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                    case "operator": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                    case "Time": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                    case "Date": sql_data = sql_data + " TO_DATE ( '"+ CorrectInputString(DG.Rows[i].Cells[j].Value.ToString() + "', 'DD.MM.YYYY')", "-") + ", "; break;
                    default: sql_data = sql_data + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString().Replace(',', '.'), "-") + ", "; break;
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


    /// <summary>
    /// Databases the export data random1.
    /// </summary>
    /// <param name="DG">The dg.</param>
    /// <param name="ConnectingString">The connecting string.</param>
    /// <param name="TableName">Name of the table.</param>
    /// <returns>bool</returns>
    public bool DBExportDataRandom1(DataGridView DG, string ConnectingString, string TableName)
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
                    switch (DG.Columns[j].Name)
                    {
                        case "id_section": sql_data = sql_data + "'" + CorrectInputString(CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-"), "-") + "', "; break;
                        case "Direct": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                        case "Meas_type": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                        case "operator": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                        case "Time": sql_data = sql_data + "'" + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString(), "-") + "', "; break;
                        case "Date": sql_data = sql_data + " TO_DATE ( '"+ CorrectInputString(DG.Rows[i].Cells[j].Value.ToString() + "', 'DD.MM.YYYY')", "-") + ", "; break;
                        default: sql_data = sql_data + CorrectInputString(DG.Rows[i].Cells[j].Value.ToString().Replace(',', '.'), "-") + ", "; break;
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

    /// <summary>
    /// Corrects the input string.
    /// </summary>
    /// <param name="IN">The in.</param>
    /// <param name="CompareString">The compare string.</param>
    /// <returns></returns>
    public string CorrectInputString(string IN, string CompareString)
    {
        if (IN == CompareString)
        {
            return IN = "-1";
        }
        return IN;
    }
    /// <summary>
    /// Replaces the common.
    /// </summary>
    /// <param name="IN">The in.</param>
    /// <returns></returns>
    public string replaceCommon(string IN)
    {
        return IN.Replace(',', '.');
    }
#pragma warning disable CS1572 // Комментарий XML имеет тег param для "name", но параметр с таким именем отсутствует.
    /// <summary>
    /// Exports the data to data base from directory C:\temp.
    /// </summary>
    /// <param name="view">The view.</param>
    /// <param name="conDb">The con database.</param>
    /// <param name="name">The name.</param>
    public void ExportDataToDataBaseTemp(DataGridView view, string conDb)
#pragma warning restore CS1572 // Комментарий XML имеет тег param для "name", но параметр с таким именем отсутствует.
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
            DBConn dBConn = new DBConn();
            dBConn.DBCreateTableRandomMeas(view, conDb, s1[0]);
            dBConn.DBExportDataCommon(view, conDb, s1[0]);
        }
        //copying files from C:\temp to subdirectory .\resolved
        fileJ.CopyResolvedFiles();
    }


    public void ExportDataToDataBaseTempAll(DataGridView view, string conDB)
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
            DBConn dBConn = new DBConn();
            dBConn.DBCreateTableRandomMeas(view, conDB, name);
            dBConn.DBExportDataRandom(view, conDB, name);
            //пропуск фалов с RNON.txt
            ++i;
            //ProgressDB.Value = i;
        }
    }



}



