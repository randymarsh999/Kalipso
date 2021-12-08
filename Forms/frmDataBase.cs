using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Kalipso
{
#pragma warning disable CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmDataBase"
	public partial class frmDataBase : Form
#pragma warning restore CS1591 // Отсутствует комментарий XML для публично видимого типа или члена "frmDataBase"
	{
        DataBasePostgres Dbpostgres = new DataBasePostgres();
/// <summary>
/// 
/// </summary>
        public string Server { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Port { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string DB { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public bool DataBaseConnected { get; set; }
        /// <summary>
        /// Gets or sets the connection string to database.
        /// </summary>
        /// <value>
        /// The connection string to database.
        /// </value>
        public string ConnectionStringToDB { set; get; }
		/// <summary>
		/// Конструктор класса формы DataBase
		/// </summary>
		public frmDataBase()
		{
			InitializeComponent();
            //инициализация параметров для входа в базу данных
            Dbpostgres.SetSever("Server=" + eServer.Text + ";");
            Server += "Server=" + eServer.Text + ";";
			DB += "Database=" + eDB.Text + ";";
			UserId += "User Id=" + eLogin.Text + ";";
			Port += "Port = " + ePort.Text + ";";
			Password += "Password=" + ePass.Text + ";";
            ConnectionStringToDB = Server + Port + UserId + Password + DB;
            DataBaseConnected = false;
        }
		/// <summary>
		/// Устанавливает сервер базы данных для соединения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>				
		private void btnSetSever_Click(object sender, EventArgs e)
		{
            Server += "Server=" + eServer.Text + ";"; 
            ConnString();
        }
        /// <summary>
        /// 
        /// </summary>
        public void ConnString()
        {
           //ConnString();
            ConnectionStringToDB = Server + Port + UserId + Password + DB;
        }
		/// <summary>
		/// Устанавливает базу данных для соединения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void btnSetDB_Click(object sender, EventArgs e)
		{
            DB += "Database=" + eDB.Text + ";";
            ConnString();
        }
		/// <summary>
		/// Устанавливает Логин для соединения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetLogin_Click(object sender, EventArgs e)
		{
            UserId += "User Id=" + eLogin.Text + ";";
            ConnString();
        }
		/// <summary>
		/// Устанавливает порт сервера базы данных для соединения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetPort_Click(object sender, EventArgs e)
		{
            Port += "Port = " + ePort.Text + ";";
            ConnString();
        }
		/// <summary>
		/// Устанавливает пароль базы данных для соединения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetPass_Click(object sender, EventArgs e)
		{
            Password += "Password=" + ePass.Text + ";";
            ConnString();
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
                ConnString();
                NpgsqlConnection pgcon = new NpgsqlConnection(ConnectionStringToDB);
				pgcon.Open();
                //string sql = "create table ss(id int);";
                //NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
                //CSend.ExecuteNonQuery();
                DataBaseConnected = true;
                pgcon.Close();
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
            ConnString();
        }

        private void eDB_TextChanged(object sender, EventArgs e)
        {
            ConnString();
        }

        private void eLogin_TextChanged(object sender, EventArgs e)
        {
            ConnString();
        }

        private void ePass_TextChanged(object sender, EventArgs e)
        {
            ConnString();
        }

        private void ePort_TextChanged(object sender, EventArgs e)
        {
            ConnString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmDataBase_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection pgcon = new NpgsqlConnection(ConnectionStringToDB);
            pgcon.Open();
            string sql =txtRequsetDB.Text;
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
            pgcon.Close();
        }
        /// <summary>
        /// Handles the 1 event of the button1_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            DBDataReader_records();
        }
        /// <summary>
        /// Databases the data comporison.
        /// </summary>
        /// <returns>boolen true if find compare string</returns>
        public bool DBData_Comporison(string InitVal, string compareVal, string DBColumn)
        {
            
            try
            {
                NpgsqlConnection pgcon = new NpgsqlConnection(ConnectionStringToDB);
                pgcon.Open();
                string sql = txtRequsetDB.Text;
                NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
                CSend.ExecuteNonQuery();
                NpgsqlDataReader reader = CSend.ExecuteReader();
                if (reader.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in reader)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (compareVal == dbDataRecord[DBColumn].ToString())
                            {
                                pgcon.Close();
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
        public void DBDataReader_records()
        {
            NpgsqlConnection pgcon = new NpgsqlConnection(ConnectionStringToDB);
            pgcon.Open();
            string sql = txtRequsetDB.Text;
            NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
            try
            {
                CSend.ExecuteNonQuery();
                NpgsqlDataReader reader = CSend.ExecuteReader();
                if (reader.HasRows)
                {

                    dbView.Columns.Clear();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dbView.Columns.Add(reader.GetName(i), reader.GetName(i));

                    }
                    int celsel = 0;
                    foreach (DbDataRecord dbDataReader in reader)
                    {
                        dbView.Rows.Add(1);
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            dbView[dbDataReader.GetName(i), celsel].Value = dbDataReader[dbDataReader.GetName(i)];
                        }
                        ++celsel;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            pgcon.Close();
        }
    }

    /// <summary>
    /// DataBase Class
    /// </summary>
    class DataBasePostgres
    {
        private string server;
        private string Port;
        private string UserId;
        private string pass;
        private string db;


        public DataBasePostgres()
        {
           
            //инициализация параметров для входа в базу данных
            //server += "Server=" + eServer.Text + ";";
            //db += "Database=" + eDB.Text + ";";
            //UserId += "User Id=" + eLogin.Text + ";";
            //Port += "Port = " + ePort.Text + ";";
            //pass += "Password=" + ePass.Text + ";";
        }
        /// <summary>
        /// Устанавливает сервер базы данных для соединения
        /// </summary>
        /// <param name="serverId">The server identifier.</param>
        public void SetSever(string serverId)
        {
            server += "Server=" +server + ";";
        }
        /// <summary>
        /// Устанавливает базу данных для соединения
        /// </summary>
        /// <param name="DBId">The database identifier.</param>
        public void SetDB(string DBId)
        {
            db += "Database=" + DBId + ";";
        }
        /// <summary>
        /// Устанавливает Логин для соединения
        /// </summary>
        public void SetLogin(string elogin)
        {
            UserId += "User Id=" + elogin + ";";
        }
        /// <summary>
        /// Устанавливает порт сервера базы данных для соединения
        /// </summary>
        public void SetPort(string portId)
        {
            Port += "Port = " + portId + ";";
        }
        /// <summary>
        /// Устанавливает пароль базы данных для соединения
        /// </summary>
        /// <param name="passwordDB">The password database.</param>
        public void SetPass(string passwordDB)
        {
            pass += "Password=" + passwordDB + ";";
        }
        /// <summary>
        /// Устанавливает пробное соединение
        /// </summary>
        public void ConnectDB()
        {
            try
            {
                string connect = server + Port + UserId + pass + db;
                NpgsqlConnection pgcon = new NpgsqlConnection(connect);
                pgcon.Open();
                //string sql = "create table ss(id int);";
                //NpgsqlCommand CSend = new NpgsqlCommand(sql, pgcon);
                //CSend.ExecuteNonQuery();
                pgcon.Close();
            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                throw;
            }
        }


        //NpgsqlConnection npgSqlConnection = new NpgsqlConnection(connectionString);
        //npgSqlConnection.Open();
        //Console.WriteLine("Соединение с БД открыто");
        //NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM example", npgSqlConnection);
        //NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();
        //if (npgSqlDataReader.HasRows)
        //{
        //    Console.WriteLine("Таблица: example");
        //    Console.WriteLine("id value");
        //    foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
        //        Console.WriteLine(dbDataRecord["id"] + "   " + dbDataRecord["value"]);
        //}
        //else
        //    Console.WriteLine("Запрос не вернул строк");

    }
}
