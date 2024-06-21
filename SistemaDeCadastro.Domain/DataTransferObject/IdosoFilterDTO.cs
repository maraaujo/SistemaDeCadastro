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

        public int Page { get; set; }

        public IdosoDTO Idoso { get; set; }
    }
}
