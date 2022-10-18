using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System.Data;

namespace databaskonstruktion_testr.Models
{
    public class WishlistModel
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public WishlistModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetAllWishlist()
        {

            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM wishlist;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable wishlistTable = ds.Tables["result"];
            dbcon.Close();

            return wishlistTable;
        }

        public void DeleteWishlist(int year, String PNR, int toyId)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            string deleteString = "DELETE FROM wishlist WHERE year=@year AND PNR=@PNR AND toyId=@toyId;";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@year", year);
            sqlCmd.Parameters.AddWithValue("@PNR", PNR);
            sqlCmd.Parameters.AddWithValue("@toyId", toyId);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }
    }
}
