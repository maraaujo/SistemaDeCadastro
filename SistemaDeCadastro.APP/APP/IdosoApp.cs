
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
        private readonly IFuncionarioRepository funcionarioRepository;

        public IdosoApp(IIdosoRepository idosoRepository)
        {
            _idosoRepository = idosoRepository;
        }

        public async Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter) => await this._idosoRepository.GetIdoso(filter);
        public async Task<Idoso> GetIdosoById(int id) => await this._idosoRepository.GetIdosoById(id);
        public async Task<ApiResponseDTO> Create(IdosoDTO idosoDTO)
        {
            ApiResponseDTO response = new ApiResponseDTO();

            try
            {
                if (string.IsNullOrEmpty(idosoDTO.Nome))
                    throw new Exception("O nome é obrigatório");

                if (string.IsNullOrEmpty(idosoDTO.Sobrenome))
                    throw new Exception("O sobrenome é obrigatório");


                Idoso model = new Idoso();
                model.Nome = idosoDTO.Nome;
                model.Sobrenome = idosoDTO.Sobrenome;

                await this._idosoRepository.Create(model);

                response.Success = true;
            }
            catch (Exception err)
            {
                response.Success = false;
                response.ErrorMessage = err.Message;
            }

            await funcionarioRepository.FindBy(c => c.Id == 2);

            return response;

        }
        public async Task Update(Idoso idoso) => await this._idosoRepository.Update(idoso);
        public async Task Delete(int idoso) => await this._idosoRepository.Delete(idoso);


    }
}
