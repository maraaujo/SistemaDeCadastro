

namespace SistemaDeCadastro.Domain.Model
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
       
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<SistemaDeCadastroIdososDomain.Model.IdosoFuncionario> Idosos { get; set; }
    }
}