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
    }
}
