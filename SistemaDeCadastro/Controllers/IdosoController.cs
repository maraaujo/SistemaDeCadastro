using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.APP.Interface;
using SistemaDeCadastro.Domain.DataTransferObject;
using SistemaDeCadastro.Domain.Model;

namespace SistemaDeCadastro.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class IdosoController : ControllerBase
    {
        private readonly IIdosoApp idosoApp;
        private IConfiguration config;

        public IdosoController(IConfiguration _config, IIdosoApp _idosoApp)
        {
            this.config = _config;
            this.idosoApp = _idosoApp;
        }

        [HttpGet("GetIdoso")]
        public async Task<IActionResult> GetIdoso(IdosoFilterDTO filter)
        {
            ApiResponseDTO ret = new();
            try
            {
                ret.Data = await this.idosoApp.GetIdoso(filter);
                ret.Success = true;
            }
            catch (Exception ex)
            {
                ret.Success = false;
                ret.ErrorMessage = ex.Message;
            }
            return Ok(ret);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(IdosoDTO idosoDTO)
        {
            var response = await this.idosoApp.Create(idosoDTO);

            if (response.Success == false)
                return BadRequest(response.ErrorMessage);
            else
                return Ok(response);
        }
    }
}
