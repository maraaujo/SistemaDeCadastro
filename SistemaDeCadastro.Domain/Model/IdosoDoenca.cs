using SistemaDeCadastro.Domain.Model;


namespace SistemaDeCadastroIdososDomain.Model
{
    public class IdosoDoenca
    {
        public int Id { get; set; }
        public int IdosoId { get; set; }
        public Idoso Idosos { get; set; }
        public int DoencaId { get; set; }
        public Doenca Doencas { get; set; }
    }
}
