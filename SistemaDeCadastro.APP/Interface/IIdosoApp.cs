using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastro.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeCadastro.APP.Interface
{
    public interface IIdosoApp
    {
        Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter);
        Task<Idoso> GetIdosoById(int id);
        Task<ApiResponseDTO> Create(IdosoDTO idosoDTO);
        Task Update(Idoso idoso);
        Task Delete(int idoso);
    }
}
