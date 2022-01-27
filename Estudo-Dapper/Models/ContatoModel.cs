namespace Estudo_Dapper.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string Telefone { get; set; }
        public string Celular { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
