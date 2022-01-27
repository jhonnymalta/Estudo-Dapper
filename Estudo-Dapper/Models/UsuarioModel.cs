namespace Estudo_Dapper.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string  Sexo { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string NomeMae { get; set; }
        public string SituacaoCadastro{ get; set; }
        public DateTimeOffset DataCadastro { get; set; }

        public ContatoModel Contato { get; set; }
        public ICollection<EnderecoEntregaModel> EnderecosEntrega { get; set; }

        public ICollection<DepartamentoModel> Departamentos { get; set; }

    }
}
