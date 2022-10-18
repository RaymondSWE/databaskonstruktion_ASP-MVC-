using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
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

        public void DeleteKid(string PNR)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            string deleteString = "DELETE FROM kid WHERE PNR=@PNR;";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@PNR", PNR);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
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


        public DataTable SearchKids(string name)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM kid WHERE name LIKE @name;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@NAME", "%" + name + "%");
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable kidTable = ds.Tables["result"];
            dbcon.Close();
            return kidTable;
        }

        public void InsertKids(string PNR, string name, int birthday, int disobedience, int deliveryNr, string type)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            string deleteString = "INSERT INTO kid(PNR,name,birthday,disobedience,deliveryNr,type ) VALUES(@PNR,@name,@birthday,@disobedience, @deliveryNr, @type);";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@PNR", PNR);
            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@birthday", birthday);
            sqlCmd.Parameters.AddWithValue("@disobedience", disobedience);
            sqlCmd.Parameters.AddWithValue("@deliveryNr", deliveryNr);
            sqlCmd.Parameters.AddWithValue("@type", type);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }
    }
}
