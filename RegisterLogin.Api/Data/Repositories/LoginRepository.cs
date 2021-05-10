using Dapper;
using Microsoft.Extensions.Configuration;
using RegisterLogin.Api.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RegisterLogin.Api.Data.Repositories
{
    public class LoginRepository : RepositoryBase
    {
        public LoginRepository(IConfiguration configuration)
        {
            base.configuration = configuration;
        }
        public int Insert(LoginEntity login)
        {
            using var db = Connection;

            var query = @"INSERT INTO login 
                                (nome, 
                                 email, 
                                 senha) 
                         VALUES (@Nome, 
                                 @Email, 
                                 @Senha);";

            return db.ExecuteScalar<int>(query, new
            {
                login.Nome,
                login.Email,
                login.Senha
            });
        }
        public int Update(LoginEntity login)
        {
            using var db = Connection;

            var query = @"UPDATE login
                            SET nome  = @Nome,
                                email = @Email,
                                senha = @Senha
                            WHERE id_users = @IdUsers = 1;";

            return db.Execute(query, new
            {
                login.Nome,
                login.Email,
                login.Senha
            });
        }
        public LoginEntity GetLogin(int idUsers)
        {
            using var db = Connection;

            var query = @"Select id_users
                          From login
                                WHERE id_users = @IdUsers;";

            return db.QueryFirstOrDefault<LoginEntity>(query, new { idUsers });
        }
        public string GetLoginById(int idLogin)
        {
            using var db = Connection;

            var query = @"SELECT id_users
                             FROM login
                          WHERE id_users = @IdUsers;";

            return db.ExecuteScalar<string>(query, new { idLogin });
        }
        public string GetNomeLoginById(int idLogin)
        {
            using var db = Connection;

            var query = @"SELECT nome
                            FROM login 
                        WHERE id_users = @IdUsers;";

            return db.ExecuteScalar<string>(query, new { idLogin });
        }
        public int GetIdByNome(string Nome)
        {
            using var db = Connection;

            var query = @"SELECT 
                                 id_users
                          FROM login
                                 WHERE nome = @Nome;";

            return db.ExecuteScalar<int>(query, new { Nome });
        }
        public IEnumerable<LoginEntity> GetAllLogin()
        {
            using var db = Connection;

            var query = @"SELECT * from login
                             id_users,
                             nome,
                             email,
                             senha,
                             status
                        FROM Login
                            WHERE status = 1; ";

            return db.Query<LoginEntity>(query);
        }
        public int Delete(int id)
        {
            using var db = Connection;

            var query = @"UPDATE login      
                        SET status = 2
                      WHERE id_users = @id";

            return db.Execute(query, new { id });
        }

    }
}
