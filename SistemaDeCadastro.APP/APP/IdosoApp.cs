﻿
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
        private readonly IIdosoDoencaRepository idosoDoencaRepository;

        public IdosoApp(IIdosoRepository idosoRepository)
        {
            _idosoRepository = idosoRepository;
        }

        public async Task<PagedIdosoDTO> GetIdoso(IdosoFilterDTO filter) => await this._idosoRepository.GetIdoso(filter);
        public async Task<List<Idoso>> GetIdosoById(int id) => await this._idosoRepository.GetIdosoById(id);
        public async Task<ApiResponseDTO> Create(IdosoDTO idosoDTO)
        {
            ApiResponseDTO response = new ();

            try
            {
                if (string.IsNullOrEmpty(idosoDTO.Nome))
                    throw new Exception("O nome é obrigatório");

                if (string.IsNullOrEmpty(idosoDTO.Sobrenome))
                    throw new Exception("O sobrenome é obrigatório");


                Idoso model = new Idoso();
                model.Nome = idosoDTO.Nome;
                model.Sobrenome = idosoDTO.Sobrenome;
                model.Funcionarios = new List<IdosoFuncionario> { new IdosoFuncionario { Funcionarios = new Funcionario { } } };

                await this._idosoRepository.Create(model);

                response.Success = true;
            }
            catch (Exception err)
            {
                response.Success = false;
                response.ErrorMessage = err.Message;
            }


            return response;

        }

        public async Task GetIdososComecandoComLetraAEDoecnaComLetraP()
        {
            var ret = (await idosoDoencaRepository.FindBy(c => c.Idosos.Nome.StartsWith("a")
            && c.Doencas.Nome.StartsWith("p"))).Select(c => new
            {
                Nome = c.Idosos.Nome,
                Doenca = c.Doencas.Nome
            }).ToList();
        }

        public async Task Update(Idoso idoso) => await this._idosoRepository.Update(idoso);
        public async Task Delete(int idoso) => await this._idosoRepository.Delete(idoso);


    }
}
