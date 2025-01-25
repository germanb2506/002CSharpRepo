using Common;
using Common.Dto;

namespace Business.Contratos
{
    public interface IUsuarioRepo
    {
        Task<Result<UsuarioDto>> CrearUsuario(UsuarioDto usuarioDto);
        Task<Result<List<UsuarioDto>>> ObtenerUsuarios();
        Task<Result<UsuarioDto>> ObtenerUsuarioPorId(int id);
        Task<Result<UsuarioDto>> ActualizarUsuario(UsuarioDto usuarioDto);
        Task<Result<bool>> EliminarUsuario(int id);
        Task<Result<UsuarioDto>> GetProyUsuario(int id);
        Task<Result<List<UsuarioDto>>> GetAllProyUsuarios();
    }
}

