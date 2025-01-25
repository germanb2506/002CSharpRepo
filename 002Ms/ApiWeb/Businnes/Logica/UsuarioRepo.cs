using AutoMapper;
using Business.Contratos;
using Businnes.Contratos;
using Common;
using Common.Dto;
using Data.Entidades;
using System.Linq.Expressions;

namespace Business.Logica
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly IGenericRepo<Usuario> _usuarioRepo;
        private readonly IMapper _mapper;

        public UsuarioRepo(IGenericRepo<Usuario> usuarioRepo, IMapper mapper)
        {
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
        }

        public async Task<Result<UsuarioDto>> CrearUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                // Mapeo de UsuarioDto a Usuario
                var usuario = _mapper.Map<Usuario>(usuarioDto);

                await _usuarioRepo.Crear(usuario);

                return Result<UsuarioDto>.Success(usuarioDto, "Usuario creado exitosamente");
            }
            catch (Exception ex)
            {
                return Result<UsuarioDto>.Error(ResponseCode.InternalServerError, "Error al crear el usuario", new List<string> { ex.Message });
            }
        }

        public async Task<Result<List<UsuarioDto>>> ObtenerUsuarios()
        {
            try
            {
                // Obtener todos los usuarios y mapear a UsuarioDto
                var usuarios = await _usuarioRepo.ObtenerTodos();
                var usuariosDto = _mapper.Map<List<UsuarioDto>>(usuarios);

                return Result<List<UsuarioDto>>.Success(usuariosDto, "Usuarios obtenidos exitosamente");
            }
            catch (Exception ex)
            {
                return Result<List<UsuarioDto>>.Error(ResponseCode.InternalServerError, "Error al obtener los usuarios", new List<string> { ex.Message });
            }
        }

        public async Task<Result<UsuarioDto>> ObtenerUsuarioPorId(int id)
        {
            try
            {
                // Consulta con filtro
                var usuario = await _usuarioRepo.Obtener(u => u.IdUsuario == id);

                if (usuario == null)
                {
                    return Result<UsuarioDto>.Error(ResponseCode.NotFound, "Usuario no encontrado");
                }

                var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
                return Result<UsuarioDto>.Success(usuarioDto, "Usuario obtenido exitosamente");
            }
            catch (Exception ex)
            {
                return Result<UsuarioDto>.Error(ResponseCode.InternalServerError, "Error al obtener el usuario", new List<string> { ex.Message });
            }
        }

        public async Task<Result<UsuarioDto>> ActualizarUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                // Mapeo de UsuarioDto a Usuario
                var usuario = _mapper.Map<Usuario>(usuarioDto);

                // Validar existencia
                var existente = await _usuarioRepo.Obtener(u => u.IdUsuario == usuario.IdUsuario);
                if (existente == null)
                {
                    return Result<UsuarioDto>.Error(ResponseCode.NotFound, "Usuario no encontrado");
                }

                // Actualizar
                _mapper.Map(usuarioDto, existente);
                await _usuarioRepo.Grabar();

                return Result<UsuarioDto>.Success(usuarioDto, "Usuario actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return Result<UsuarioDto>.Error(ResponseCode.InternalServerError, "Error al actualizar el usuario", new List<string> { ex.Message });
            }
        }

        public async Task<Result<bool>> EliminarUsuario(int id)
        {
            try
            {
                // Validar existencia
                var usuario = await _usuarioRepo.Obtener(u => u.IdUsuario == id);
                if (usuario == null)
                {
                    return Result<bool>.Error(ResponseCode.NotFound, "Usuario no encontrado");
                }

                // Eliminar
                await _usuarioRepo.Remover(usuario);
                return Result<bool>.Success(true, "Usuario eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return Result<bool>.Error(ResponseCode.InternalServerError, "Error al eliminar el usuario", new List<string> { ex.Message });
            }
        }

        public async Task<Result<UsuarioDto>> GetProyUsuario(int id)
        {
            try
            {
                // Proyección parcial
                Expression<Func<Usuario, UsuarioDto>> selector = u => new UsuarioDto
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombre,
                    Correo = u.Correo
                };

                var usuarioDto = await _usuarioRepo.GetProy(u => u.IdUsuario == id, selector);

                if (usuarioDto == null)
                {
                    return Result<UsuarioDto>.Error(ResponseCode.NotFound, "Usuario no encontrado");
                }

                return Result<UsuarioDto>.Success(usuarioDto, "Usuario obtenido exitosamente");
            }
            catch (Exception ex)
            {
                return Result<UsuarioDto>.Error(ResponseCode.InternalServerError, "Error al obtener el usuario", new List<string> { ex.Message });
            }
        }

        public async Task<Result<List<UsuarioDto>>> GetAllProyUsuarios()
        {
            try
            {
                // Proyección parcial
                Expression<Func<Usuario, UsuarioDto>> selector = u => new UsuarioDto
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombre,
                    Correo = u.Correo
                };

                var usuariosDto = await _usuarioRepo.GetAllProy(null, selector);
                return Result<List<UsuarioDto>>.Success(usuariosDto, "Usuarios obtenidos exitosamente");
            }
            catch (Exception ex)
            {
                return Result<List<UsuarioDto>>.Error(ResponseCode.InternalServerError, "Error al obtener los usuarios", new List<string> { ex.Message });
            }
        }
    }
}
