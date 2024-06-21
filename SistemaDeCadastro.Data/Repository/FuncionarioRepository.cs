using Microsoft.Identity.Client;
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
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public SitemaDeCadastroContext context;
        public FuncionarioRepository(SitemaDeCadastroContext context)
            : base(context)
        {
            

        }
    }
}
