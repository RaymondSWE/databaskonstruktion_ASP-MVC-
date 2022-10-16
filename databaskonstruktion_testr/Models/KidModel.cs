using MySql.Data.MySqlClient;
using System.Data;

namespace databaskonstruktion_testr.Models
{
    public class KidModel
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public KidModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetAllKids()
        {

            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM kid;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable kidTable = ds.Tables["result"];
            dbcon.Close();

            return kidTable;
        }


        public DataTable GetAllToys()
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM toy;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable toyTable = ds.Tables["result"];
            dbcon.Close();

            return toyTable;
        }
    }
}
