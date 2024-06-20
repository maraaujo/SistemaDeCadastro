
namespace SistemaDeCadastroIdososDomain.Model
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public ICollection<MedicamentoIdosoDoenca> MedicamentoIdosoDoencas { get; set; }
    }
}
