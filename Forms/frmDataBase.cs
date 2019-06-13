using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            ConnString();
        }
		/// <summary>
		/// Устанавливает Логин для соединения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetLogin_Click(object sender, EventArgs e)
		{
            ConnString();
        }
		/// <summary>
		/// Устанавливает порт сервера базы данных для соединения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetPort_Click(object sender, EventArgs e)
		{
            ConnString();
        }
		/// <summary>
		/// Устанавливает пароль базы данных для соединения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSetPass_Click(object sender, EventArgs e)
		{
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
