using SistemaDeCadastro.Data.Repository;
using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastro.Domain.Model;

namespace SistemaDeCadastro.Data.Interface
{
    public interface IIdosoRepository : IBaseRepository<Idoso>
    {     
        Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter);
        Task<List<Idoso>> GetIdosoByName(string nome);
        Task<List<Idoso>> GetIdosoById(int id);
        Task<List<Idoso>> GetIdosoByCpf(string cpf);
        Task<List<Idoso>> GetIdosoByIdade(int idade);
    }
}
