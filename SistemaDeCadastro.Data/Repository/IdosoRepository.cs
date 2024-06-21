using Microsoft.EntityFrameworkCore;
using System.Linq;
using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastro.Data.Interface;
using SistemaDeCadastro.Domain.Context;
using SistemaDeCadastro.Domain.Model;


namespace SistemaDeCadastro.Data.Repository
{
    public class IdosoRepository : IdosoDTO, IIdosoRepository //interface
    {
        private readonly SitemaDeCadastroContext context;
        public IdosoRepository(SitemaDeCadastroContext _context)
        {
            this.context = _context;
        }

        public async Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter)
        {
            //para fazer os filtros
            try
            {
                var iRet = context.Idosos.AsQueryable(); 

                if (!string.IsNullOrWhiteSpace(filter.Nome))
                {
                    var lowerName = filter.Nome.ToLower();
                     iRet = iRet.Where(c => c.Nome.ToLower().StartsWith(lowerName) || c.Nome.ToLower()
                        .EndsWith(lowerName) || c.Nome.EndsWith(lowerName));
                }
                if (!string.IsNullOrWhiteSpace(filter.Sobrenome))
                {
                    var lowerName = filter.Sobrenome.ToLower();
                    iRet = iRet.Where(c => c.Sobrenome.ToLower().StartsWith(lowerName) || c.Sobrenome.ToLower()
                       .EndsWith(lowerName) || c.Sobrenome.EndsWith(lowerName));
                }
               
                //é onde armazeno o resultado da consulta
                PagedIdosoDTO ret = new ();
                ret.Page = filter.Page;
                ret.Count = await iRet.CountAsync();
                ret.TotalPages = ret.Count % 10 > 0 ? (ret.Count / 10) + 1 : ret.Count / 10;

                //calcula o indice da pagina atual
                int page = filter.Page - 1;
                 
                //ordena por id, decrescente. 
                ret.Idoso = await iRet.OrderByDescending(c => c.Id).Skip(page * ret.ItensPerPage).Take(ret.ItensPerPage).Select(c=> new IdosoDTO
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Sobrenome = c.Sobrenome,
                }).ToListAsync();
                return ret;
            }catch (Exception err)
            {
                throw err;
            }
        }
        public async Task<Idoso> GetIdosoById(int id)
        {
            return await context.Idosos.Where(c => c.Id == id).FirstOrDefaultAsync();
          
        }
        public async Task<IdosoDTO> Create(IdosoDTO idosoDTO)
        {
            context.Idosos.AddAsync(idosoDTO);
            context.SaveChangesAsync();
              return idosoDTO;
        }

        public async Task Update(Idoso idoso)
        {
            context.Idosos.Update(idoso);
        }

        public async Task Delete(int id)
        {
            var ret = await context.Idosos.FindAsync(id);
            context.Idosos.Remove(ret);
            await context.SaveChangesAsync();
          
        }
    }
}
