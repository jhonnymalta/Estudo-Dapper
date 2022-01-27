using Dapper;
using Estudo_Dapper.Models;
using System.Data.SqlClient;

namespace Estudo_Dapper.Services
{
    public interface IRepository_Usuario
    {
        Task<IEnumerable<UsuarioModel>> GetAllUser();
        Task<UsuarioModel> GetById(int id);
    }
    public class Repository_Usuario : IRepository_Usuario
    {
        private readonly string connectionString;
        public Repository_Usuario(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<UsuarioModel>> GetAllUser()
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<UsuarioModel>(@"Select * from Usuarios");
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<UsuarioModel>(@"Select * from Usuarios where Id = @id", new { Id = id });
        }

       
    }
}
