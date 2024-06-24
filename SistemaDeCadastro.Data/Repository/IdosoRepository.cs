using Microsoft.EntityFrameworkCore;
using System.Linq;
using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastro.Data.Interface;
using SistemaDeCadastro.Domain.Context;
using SistemaDeCadastro.Domain.Model;


namespace SistemaDeCadastro.Data.Repository
{
    public class IdosoRepository : BaseRepository<Idoso>,  IIdosoRepository //interface
    {
        private readonly SitemaDeCadastroContext context;

        public IdosoRepository(SitemaDeCadastroContext _context)
            : base(_context)
        {
            this.context = _context;
        }
        //criarAdiminRepository
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
                    var lowerSobrenome = filter.Sobrenome.ToLower();
                    iRet = iRet.Where(c => c.Sobrenome.ToLower().StartsWith(lowerSobrenome) || c.Sobrenome.ToLower()
                       .EndsWith(lowerSobrenome) || c.Sobrenome.EndsWith(lowerSobrenome));
                }
                if (!string.IsNullOrWhiteSpace(filter.Cpf))
                {
                    var lowerCpf = filter.Cpf.ToLower();
                    iRet = iRet.Where(c => c.Cpf.ToLower().StartsWith(lowerCpf) || c.Cpf.ToLower()
                       .EndsWith(lowerCpf) || c.Cpf.EndsWith(lowerCpf));
                }
                if (filter.Doenca != null && !string.IsNullOrEmpty(filter.Doenca.Nome))
                {
                    iRet = iRet.Where(c => c.Doenca.Nome.ToLower() == filter.Doenca.Nome.ToLower());
                }
                if(filter.Familia != null && !string.IsNullOrEmpty(filter.Familia.Nome))
                {
                    iRet = iRet.Where(c => c.Familia.Nome.ToLower() == filter.Familia.Nome.ToLower());
                }
                if (filter.Medicamento != null && !string.IsNullOrEmpty(filter.Medicamento.Nome))
                {
                    iRet = iRet.Where(c => c.Medicamento.Nome.ToLower() == filter.Medicamento.Nome.ToLower());
                }
                if(filter.DataNascimento.DayOfYear == filter.DataNascimento.DayOfYear) 
                {
                    iRet = iRet.Where(c => c.DataDeNascimento == filter.DataNascimento.());
                }


                //é onde armazeno o resultado da consulta
                PagedIdosoDTO ret = new();
                ret.Page = filter.Page;
                ret.Count = await iRet.CountAsync();
                ret.TotalPages = ret.Count % 10 > 0 ? (ret.Count / 10) + 1 : ret.Count / 10;

                //calcula o indice da pagina atual
                int page = filter.Page - 1;

                //ordena por id, decrescente. 
                ret.Idoso = await iRet.OrderByDescending(c => c.Id).Skip(page * ret.ItensPerPage).Take(ret.ItensPerPage).Select(c => new IdosoDTO
                {
                   
                    Nome = c.Nome,
                    Sobrenome = c.Sobrenome,
                    Cpf = c.Cpf,
                    Doenca = c.Doenca,
                    Medicamento = c.Medicamento,
                    Familia = c.Familia,
                }).ToListAsync();
                return ret;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        public async Task<List<Idoso>> GetIdosoById(int id)
        {
            try
            {
                return await this.FindBy(c => c.Id == id);
            }
            catch (Exception err) { throw err; }
        }
        public async Task <List<Idoso>> GetIdosoByName(string nome)
        {
            try
            {
                return await this.FindBy(c => c.Nome == nome);
            }catch (Exception err) { throw err; }
        }

        public async Task<List<Idoso>> GetIdosoByCpf(string cpf)
        {
            try
            {
                return await this.FindBy(c => c.Cpf == cpf);
            }catch(Exception err) { throw err; }
        }
        public async Task<List<Idoso>> GetIdosoByIdade(int idade)
        {
            try
            {
                return await this.FindBy(c => c.Idade == idade);
            }catch(Exception err) { throw err; }
        }
      
      
    }
}
