using SistemaDeCadastro.Data.Interface;
using SistemaDeCadastro.Domain.Context;
using SistemaDeCadastro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastro.Data.Repository
{
    public class IdosoDoencaRepository : BaseRepository<IdosoDoenca>, IIdosoDoencaRepository
    {
        public IdosoDoencaRepository(SitemaDeCadastroContext context)
            : base(context)
        {

        }
    }
}
