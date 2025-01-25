using Common.Dto;
using Common;

namespace Businnes.Contratos
{
    public interface ICrud
    {
        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuarioDto">Datos del usuario.</param>
        /// <returns>/// 201 para creado satisfactoriamente, 
        /// 400 si se ha enviado una peticion vacia,
        /// 500 si hay un error que NO permitio guardar la informacion.</returns>
        Task<Result<UsuarioDto>> CreateAsync(UsuarioDto usuarioDto);

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <returns>Resultado del proceso.</returns>
        Task<Result<UsuarioDto>> GetByIdAsync(int idUsuario);

        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Resultado con la lista de usuarios.</returns>
        Task<Result<List<UsuarioDto>>> GetAllAsync();

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a actualizar.</param>
        /// <param name="usuarioDto">Datos a actualizar.</param>
        /// <param name="esActualizacionCompleta">Indica si se debe realizar una actualización completa o parcial.</param>
        /// <returns>Resultado del proceso.</returns>
        Task<Result<UsuarioDto>> UpdateAsync(int idUsuario, UsuarioDto usuarioDto, bool esActualizacionCompleta = false);

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar.</param>
        /// <returns>Resultado del proceso.</returns>
        Task<Result<UsuarioDto>> DeleteAsync(int idUsuario);
    }
}
