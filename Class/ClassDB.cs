using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using IniParser;

//ExecuteNonQuery: Used to execute a command that will not return any data, for example Insert, update or delete.
//ExecuteReader: Used to execute a command that will return 0 or more records, for example Select.
//ExecuteScalar: Used to execute a command that will return only 1 value, for example Select Count(*).

namespace penjadwalan.Class
{
    class ClassDbConnect
    {
        private MySqlConnection _connection;
        private string _host;
        private string _database;
        private string _username;
        private string _password;
        private string _port;

        public ClassDbConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            var parser = new FileIniDataParser();
            var data = parser.LoadFile("config.ini");
            _host = data["database"]["hostname"];
            _database = data["database"]["database"];
            _username = data["database"]["user"];
            _password = data["database"]["password"];
            _port = data["database"]["port"];

            var conString = string.Format(
                "SERVER={0};PORT={1};DATABASE={2};UID={3};PASSWORD={4};",
                _host, _port, _database, _username, _password);

            _connection = new MySqlConnection(conString);
        }

        private bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;

            }
            catch (MySqlException)
            {
                return false;
            }
        }

        private void CloseConnection()
        {
            try
            {
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Used to execute a command that will not return any data, 
        //for example Insert, update or delete. 
        public void ExecuteNonQuery(string query)
        {
            if (!OpenConnection()) return;
            var cmd = new MySqlCommand(query, _connection);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }

        public string ExecuteScalar(string query)
        {
            string str = null;
            if (OpenConnection())
            {
                var cmd = new MySqlCommand(query, _connection);
                str = (string)cmd.ExecuteScalar();
                CloseConnection();
            }
            return str;
        }

        public DataTable GetRecord(string query)
        {
            var adapter = new MySqlDataAdapter(query, _connection);
            var ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
