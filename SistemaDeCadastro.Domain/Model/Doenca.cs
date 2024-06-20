using SistemaDeCadastroIdososDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Domain.Model
{
    public class Doenca
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public ICollection<MedicamentoIdosoDoenca> MedicamentoIdosoDoencas { get; set; }
        public ICollection<IdosoDoenca> IdosoDoencas { get; set; }
    }
}
