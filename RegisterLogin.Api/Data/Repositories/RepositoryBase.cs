using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace RegisterLogin.Api.Data.Repositories
{
    public class RepositoryBase
    {
        protected IConfiguration configuration;

        internal IDbConnection Connection
        {
            get
            {
                var connect = new NpgsqlConnection(configuration["ConnectionString"]);

                connect.Open();

                return connect;
                //Aqui você substitui pelos seus dados
                //var connString = "Server=localhost;Database=test;Uid=usuario;Pwd=senha";
                //var connection = new MySqlConnection(connect);
                //var command = connection.CreateCommand();
                //connect.Open();
                //return connect;
            }
        }
    }
}
