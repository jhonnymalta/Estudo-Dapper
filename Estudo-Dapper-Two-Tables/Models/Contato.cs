namespace Estudo_Dapper_Two_Tables.Models
{
    public class Contato : Usuario
    {
        public int Id{ get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

        public Usuario usuario { get; set; }
        public int usuarioId { get; set; }
    }
}
