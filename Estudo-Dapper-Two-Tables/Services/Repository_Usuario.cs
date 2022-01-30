using Microsoft.Data.SqlClient;
using Dapper;
using Estudo_Dapper_Two_Tables.Models;

namespace Estudo_Dapper_Two_Tables.Services
{
    public interface IRepository_Usuario
    {
        Task<IEnumerable<Contato>> GetAllUser();
    }
    public class Repository_Usuario : IRepository_Usuario
    {
        private readonly string connectionString;

        public Repository_Usuario(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }
        public async Task<IEnumerable<Contato>> GetAllUser()
        {
            using var connecton = new SqlConnection(connectionString);
            return await connecton.QueryAsync<Contato,Usuario,Contato>(@"SELECT * FROM Contatos CO WITH(NOLOCK)
            LEFT JOIN Usuarios US WITH(NOLOCK)
            ON CO.Id = US.ContatoId",
            (contato, usuario) =>
            {
               contato.usuario = usuario ;
                contato.Nome = usuario.Nome;
                contato.Email = usuario.Email;
                return contato;
            });
        }
    }
}
