
using SistemaDeCadastro.APP.Interface;
using SistemaDeCadastro.Data.Interface;
using SistemaDeCadastro.Data.Repository;
using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastro.Domain.Model;
namespace SistemaDeCadastro.APP
{
    public class IdosoApp : IIdosoApp
    {
        private readonly IIdosoRepository _idosoRepository;

        public IdosoApp(IIdosoRepository idosoRepository)
        {
            _idosoRepository = idosoRepository;
        }

        public async Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter) => await this._idosoRepository.GetIdoso(filter);
        public async Task<Idoso> GetIdosoById(int id) => await this._idosoRepository.GetIdosoById(id);
        public async Task<IdosoDTO> Create(IdosoDTO idosoDTO) => await this._idosoRepository.Create(idosoDTO);
         public async Task Update(Idoso idoso) => await this._idosoRepository.Update(idoso);
        public async Task Delete(int idoso) => await this._idosoRepository.Delete(idoso);
      
        
    }
}
