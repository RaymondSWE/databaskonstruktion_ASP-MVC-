using MySql.Data.MySqlClient;
using System.Data;

namespace databaskonstruktion_testr.Models
{
    public class WishlistrowModel
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public WishlistrowModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public DataTable SearchWishlistRow(int wishlistrow, int wishlistYear, int toyId)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM wishlistrow WHERE wishlistrow=@wishlistrow AND wishlistYear=@wishlistYear AND toyId=@toyId;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@wishlistrow", wishlistrow);
            adapter.SelectCommand.Parameters.AddWithValue("@wishlistYear", wishlistYear);
            adapter.SelectCommand.Parameters.AddWithValue("@toyId", toyId);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable WishlistRowTable = ds.Tables["result"];
            dbcon.Close();
            return WishlistRowTable;
        }
    }
}
