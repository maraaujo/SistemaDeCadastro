using SistemaDeCadastro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Domain.DataTransferObject
{
    public class IdosoFilterDTO
    {

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string Cpf { get; set; }
        public DateOnly DataNascimento { get; set; }
        public Medicamento Medicamento  { get; set; }
        public Familia Familia { get; set; }
        public Doenca Doenca { get; set; }
        public int Page { get; set; }
    }
}
