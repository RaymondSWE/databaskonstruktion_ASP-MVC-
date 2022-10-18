using MySql.Data.MySqlClient;
using System.Data;

namespace databaskonstruktion_testr.Models
{
    public class ToyModel
    {

        private readonly IConfiguration _configuration;
        private string _connectionString;

        public ToyModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
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

        public void DeleteToy(int toyId)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            string deleteString = "DELETE FROM toy WHERE toyId=@toyId;";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@toyId", toyId);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }


    }
}
