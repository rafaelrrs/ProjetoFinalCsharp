using AppAt_Entity;
using AppAt_Entity.Repository;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AppAt_Repositorio.Database
{
    public class RepositoryAmigo : IRepositoryAmigo
    {
        private string Connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GerenAnivDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Amigo amigo)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                var sql = @"dbo.Insertfriend";

                conn.Execute(sql, new
                {
                    Nome = amigo.Nome,
                    Sobrenome = amigo.Sobrenome,
                    Aniversario = amigo.Aniversario
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Delete(int idAmigo)
        {
            using (var connection = new SqlConnection(Connection))
            {
                var sql = "dbo.DeleteFriendById";
                connection.Execute(sql, new { IdFriend = idAmigo }, 
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Amigo> GetAll()
        {
            using (var connection = new SqlConnection(Connection))
            {
                var sql = "dbo.SelectAllFriend";

                return connection
                        .Query<Amigo>(sql, commandType: System.Data.CommandType.StoredProcedure)
                        .AsList();
            }
        }

        public Amigo GetAmigoById(int id)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                var sql = @"[dbo].[SelectFriendById]";

                return conn
                        .QueryFirstOrDefault<Amigo>(sql,
                            new { IdFriend = id },
                            commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Amigo> GetName(string nome)
        {
            using (var connection = new SqlConnection(Connection))
            {
                var sql = "dbo.SelectFriendByName";

                return connection.Query<Amigo>(sql, new { Name = nome }, 
                    commandType: System.Data.CommandType.StoredProcedure).AsList();
            }
        }

        public void Update(Amigo amigo, int id)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                var sql = @"dbo.Updatefriend";

                conn.Execute(sql, new
                {
                    Nome = amigo.Nome,
                    Sobrenome = amigo.Sobrenome,
                    Aniversario = amigo.Aniversario,
                    IdFriend = id
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
