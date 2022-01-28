using Dapper;
using Estudo_Dapper.Models;
using System.Data.SqlClient;

namespace Estudo_Dapper.Services
{
    public interface IRepository_Usuario
    {
        Task CriarUsuario(UsuarioModel usuario);
        Task DeleteUsuario(int id);
        Task EditarUsuario(UsuarioModel usuario);
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

        public async Task CriarUsuario(UsuarioModel usuario)
        {
            using var connection = new SqlConnection(connectionString);
            usuario.Id = await connection.QuerySingleAsync<int>(@"INSERT INTO  Usuarios (Nome,Email,Sexo,RG,CPF,NomeMae,SituacaoCadastro,DataCadastro)
                                                VALUES (@Nome,@Email,@Sexo,@RG,@CPF,@NomeMae,@SituacaoCadastro,@DataCadastro);
                                                SELECT SCOPE_IDENTITY()", usuario);

           

        }
        public async Task EditarUsuario(UsuarioModel usuario)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"UPDATE USUARIOS SET Nome = @Nome,Email=@Email,Sexo=@Sexo,RG = @RG,CPF = @CPF,NomeMae=@NomeMae,SituacaoCadastro=@SituacaoCadastro,DataCadastro=@DataCadastro where ID = @Id ", usuario);
        }
         public async Task DeleteUsuario(int id)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"DELETE FROM Usuarios where Id = @Id", new { id });
        }
       
    }
}
