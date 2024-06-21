using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastro.Domain.Model;

namespace SistemaDeCadastro.Data.Interface
{
    public interface IIdosoRepository
    {
        Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter);
        Task<Idoso> GetIdosoById(int id);
        Task<IdosoDTO> Create(IdosoDTO idosoDTO);
        Task Update(Idoso idoso);
        Task Delete(int idoso);
    }
}
