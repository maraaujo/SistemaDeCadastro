using SistemaDeCadastro.Data.Repository;
using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastro.Domain.Model;

namespace SistemaDeCadastro.Data.Interface
{
    public interface IIdosoRepository : IBaseRepository<Idoso>
    {     
        Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter);
        Task<Idoso> GetIdosoById(int id);
        //Task Create(Idoso idoso);
        Task Update(Idoso idoso);
        Task Delete(int idoso);
    }
}
