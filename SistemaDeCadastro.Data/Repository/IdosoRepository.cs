using Microsoft.EntityFrameworkCore;
using System.Linq;
using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastroIdososDomain.Context;
using SistemaDeCadastroIdososDomain.Model;
using Microsoft.VisualBasic;


namespace SistemaDeCadastro.Data.Repository
{
    public class IdosoRepository : Idoso //interface
    {
        private readonly SitemaDeCadastroContext context;
        public IdosoRepository(SitemaDeCadastroContext _context)
        {
            this.context = _context;
        }

        public async Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter)
        {
            try
            {
                var iRet = context.Idosos; 

                if (!string.IsNullOrWhiteSpace(filter.Nome))
                {
                    var lowerName = filter.Nome.ToLower();
                    //iRet = context.Idosos.Where(c => c.Nome.ToLower().StartsWith(filter.Nome.ToLower()) || c.Nome.ToLower()
                    //.EndsWith(filter.Nome.ToLower()) || c.Nome.ToLower() == filter.Nome.ToLower());
                     iRet = iRet.Where(c => c.Nome.ToLower().StartsWith(filter.Nome.ToLower())|| c.Nome.ToLower()
                        .EndsWith(filter.Nome.ToLower()) || c.Nome.EndsWith(filter.Nome.ToLower()));
                }
                //perguntar pq o Where não ta funcionando

            }catch (Exception ex)
            {

            }
        }
        public async Task<IdosoDTO> GetIdosoById(int id)
        {

        }
    }
}
