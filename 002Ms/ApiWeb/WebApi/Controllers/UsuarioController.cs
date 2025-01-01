using Businnes.Contratos;
using Common;
using Common.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region Inyección y Constructor
        private readonly ICrud _crudService;

        public UsuarioController(ICrud crudService)
        {
            _crudService = crudService;
        }
        #endregion

        #region Crear Usuario
        [HttpPost("Create")]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 201)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 400)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 500)]
        public async Task<IActionResult> CreateAsync([FromBody] UsuarioDto usuarioDto)
        {
            var result = await _crudService.CreateAsync(usuarioDto);

            return result.ResponseCode switch
            {
                ResponseCode.Created => CreatedAtAction(nameof(GetByIdAsync), new { idUsuario = result.Data.IdUsuario }, result),
                ResponseCode.BadRequest => BadRequest(result),
                _ => StatusCode(500, result)
            };
        }
        #endregion

        #region Obtener Usuario por ID
        [HttpGet("GetById/{id:int}")]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 404)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 500)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _crudService.GetByIdAsync(id);

            return result.ResponseCode switch
            {
                ResponseCode.OK => Ok(result),
                ResponseCode.NotFound => NotFound(result),
                _ => StatusCode(500, result)
            };
        }
        #endregion

        #region Obtener Todos los Usuarios
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(Result<List<UsuarioDto>>), 200)]
        [ProducesResponseType(typeof(Result<List<UsuarioDto>>), 404)]
        [ProducesResponseType(typeof(Result<List<UsuarioDto>>), 500)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _crudService.GetAllAsync();

            return result.ResponseCode switch
            {
                ResponseCode.OK => Ok(result),
                ResponseCode.NotFound => NotFound(result),
                _ => StatusCode(500, result)
            };
        }
        #endregion

        #region Actualizar Usuario
        [HttpPut("Update/{idUsuario:int}")]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 400)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 404)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 500)]
        public async Task<IActionResult> UpdateAsync(int idUsuario, [FromBody] UsuarioDto usuarioDto, bool esActualizacionCompleta = false)
        {
            var result = await _crudService.UpdateAsync(idUsuario, usuarioDto, esActualizacionCompleta);

            return result.ResponseCode switch
            {
                ResponseCode.OK => Ok(result),
                ResponseCode.BadRequest => BadRequest(result),
                ResponseCode.NotFound => NotFound(result),
                _ => StatusCode(500, result)
            };
        }
        #endregion

        #region Eliminar Usuario
        [HttpDelete("Delete/{idUsuario:int}")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result<string>), 404)]
        [ProducesResponseType(typeof(Result<string>), 500)]
        public async Task<IActionResult> DeleteAsync(int idUsuario)
        {
            var result = await _crudService.DeleteAsync(idUsuario);

            return result.ResponseCode switch
            {
                ResponseCode.OK => Ok(result),
                ResponseCode.NotFound => NotFound(result),
                _ => StatusCode(500, result)
            };
        }
        #endregion
    }
}
