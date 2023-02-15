using Dapper;
using Microsoft.Data.SqlClient;

namespace DatingAppPractice1.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private IConfiguration _configuration;
        public DbInitializer(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async void Initialize()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (var conn = new SqlConnection(connectionString))
            {
                var res = await conn.ExecuteScalarAsync("select * from [dbo].[Records]");

                if(res == null)
                {
                    var query = "insert into [dbo].[Records] values('Value 101'),('Value 102'),('Value 103')";
                    await conn.QueryAsync(query);
                }
                conn.Close();
            }
        }
    }
}
