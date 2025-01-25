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
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ICrud crudService, ILogger<UsuarioController> logger)
        {
            _crudService = crudService;
            _logger = logger;
        }
        #endregion

        #region Crear Usuario
        [HttpPost("Create")]
        [ProducesResponseType(typeof(Result<UsuarioDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 500)]
        public async Task<IActionResult> CreateAsync([FromBody] UsuarioDto usuarioDto)
        {
            if (!ModelState.IsValid) //Esto sirve para validar con lo contenido en las datanotations del DTO 
            {
                return BadRequest(ModelState);
            }
            if (usuarioDto == null)
            {
                return BadRequest();
            }
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
                ResponseCode.NotFound => NotFound(new Result<UsuarioDto>
                {
                    ResponseCode = ResponseCode.NotFound,
                    IsExitoso = false,
                    Message = result.Message,
                    Data = null, // Data está vacío en caso de error
                    Errors = result.Errors,
                    TraceId = result.TraceId
                }),
                _ => StatusCode(500, new Result<UsuarioDto>
                {
                    ResponseCode = ResponseCode.InternalServerError,
                    IsExitoso = false,
                    Message = result.Message,
                    Data = null, // Data está vacío en caso de error
                    Errors = result.Errors,
                    TraceId = result.TraceId
                })
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
                ResponseCode.NotFound => NotFound(new Result<List<UsuarioDto>>
                {
                    ResponseCode = ResponseCode.NotFound,
                    IsExitoso = false,
                    Message = result.Message,
                    Data = null, // Data está vacío en caso de error
                    Errors = result.Errors,
                    TraceId = result.TraceId
                }),
                _ => StatusCode(500, new Result<List<UsuarioDto>>
                {
                    ResponseCode = ResponseCode.InternalServerError,
                    IsExitoso = false,
                    Message = result.Message,
                    Data = null, // Data está vacío en caso de error
                    Errors = result.Errors,
                    TraceId = result.TraceId
                })
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
                ResponseCode.NotFound => NotFound(new Result<UsuarioDto>
                {
                    ResponseCode = ResponseCode.NotFound,
                    IsExitoso = false,
                    Message = result.Message,
                    Data = null, // Data está vacío en caso de error
                    Errors = result.Errors,
                    TraceId = result.TraceId
                }),
                _ => StatusCode(500, new Result<UsuarioDto>
                {
                    ResponseCode = ResponseCode.InternalServerError,
                    IsExitoso = false,
                    Message = result.Message,
                    Data = null, // Data está vacío en caso de error
                    Errors = result.Errors,
                    TraceId = result.TraceId
                })
            };
        }
        #endregion

        #region Eliminar Usuario
        [HttpDelete("Delete/{idUsuario:int}")]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 200)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 404)]
        [ProducesResponseType(typeof(Result<UsuarioDto>), 500)]
        public async Task<IActionResult> DeleteAsync(int idUsuario)
        {
            var result = await _crudService.DeleteAsync(idUsuario);

            return result.ResponseCode switch
            {
                ResponseCode.OK => Ok(result),
                ResponseCode.NotFound => NotFound(new Result<string>
                {
                    ResponseCode = ResponseCode.NotFound,
                    IsExitoso = false,
                    Message = result.Message,
                    Data = null, // Data está vacío en caso de error
                    Errors = result.Errors,
                    TraceId = result.TraceId
                }),
                _ => StatusCode(500, new Result<string>
                {
                    ResponseCode = ResponseCode.InternalServerError,
                    IsExitoso = false,
                    Message = result.Message,
                    Data = null, // Data está vacío en caso de error
                    Errors = result.Errors,
                    TraceId = result.TraceId
                })
            };
        }
        #endregion
    }
}
