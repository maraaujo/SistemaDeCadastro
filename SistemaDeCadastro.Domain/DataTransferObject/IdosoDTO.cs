using SistemaDeCadastroIdososDomain.Model;


namespace SistemaDeCadastro.Domain.DataTransferObject
{
    public class IdosoDTO
    {
        public IdosoDTO()
        {
            
        }
        public IdosoDTO(Idoso idoso)
        {
            this.Id = idoso.Id;
            this.Nome = idoso.Nome;
            this.Sobrenome = idoso.Sobrenome;
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public List<Idoso> Idoso { get; set; }
    }
}
