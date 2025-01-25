using Businnes.Contratos;
using Common;
using Common.Dto;
using Data;
using Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Businnes.Logica
{
    public class Crud : ICrud
    {
        #region Contexto y Constructor
        private readonly Context _context;
        public Crud(Context context)
        {
            _context = context;
        }
        #endregion
        #region Crear Usuario
        /// <summary>
        /// Crea un nuevo objeto de la clase Usuario empleando usuarioDTO.
        /// </summary>
        /// <param name="usuarioDto">Datos del usuario.</param>
        /// <returns>201 para creado satisfactoriamente, 
        /// 400 si se ha enviado una petición vacía,
        /// 500 si hay un error que no permitió guardar la información.</returns>
        public async Task<Result<UsuarioDto>> CreateAsync(UsuarioDto usuarioDto)
        {
            if (usuarioDto == null)
            {
                return Result<UsuarioDto>.Error(
                    code: ResponseCode.BadRequest,
                    message: "No se puede cargar un dato vacío en la base de datos"
                );
            }

            var usuario = new Usuario
            {
                Nombre = usuarioDto.Nombre,
                Apellido = usuarioDto.Apellido,
                Correo = usuarioDto.Correo,
                Contrasena = usuarioDto.Contrasena,
                Telefono = usuarioDto.Telefono,
                Direccion = usuarioDto.Direccion
            };

            try
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    // Agregar usuario al contexto
                    await _context.Usuarios.AddAsync(usuario);

                    // Guardar cambios
                    int confirmacion = await _context.SaveChangesAsync();

                    if (confirmacion > 0)
                    {
                        // Confirmar transacción
                        await transaction.CommitAsync();

                        // Actualizar el ID en el DTO
                        usuarioDto.IdUsuario = usuario.IdUsuario;

                        return Result<UsuarioDto>.Success(
                            data: usuarioDto,
                            message: "El registro se ha guardado satisfactoriamente"
                        );
                    }
                    else
                    {
                        // Deshacer transacción en caso de error
                        await transaction.RollbackAsync();

                        return Result<UsuarioDto>.Error(
                            code: ResponseCode.InternalServerError,
                            message: "No se ha podido guardar correctamente la información"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                return Result<UsuarioDto>.Error(
                    code: ResponseCode.InternalServerError,
                    message: "No se ha podido guardar correctamente la información",
                    errors: new List<string> { ex.Message }
                );
            }
        }
        #endregion



        #region Obtener Usuario por ID
        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario.</param>
        /// <returns>Un usuario por Id.</returns>
        public async Task<Result<UsuarioDto>> GetByIdAsync(int idUsuario)
        {
            try
            {
                // Consulta usando LINQ y expresión lambda
                var usuario = await _context.Usuarios
                    .Where(u => u.IdUsuario == idUsuario)
                    .Select(u => new UsuarioDto
                    {
                        IdUsuario = u.IdUsuario,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Correo = u.Correo,
                        Telefono = u.Telefono,
                        Direccion = u.Direccion
                    })
                    .FirstOrDefaultAsync();

                // Validar si el usuario no existe
                if (usuario == null)
                {
                    return Result<UsuarioDto>.Error(
                        code: ResponseCode.NotFound,
                        message: "Usuario no encontrado."
                    );
                }

                // Retornar usuario encontrado
                return Result<UsuarioDto>.Success(
                    data: usuario,
                    message: "Usuario encontrado exitosamente."
                );
            }
            catch (Exception ex)
            {
                // Manejo de errores y respuesta en caso de excepción
                return Result<UsuarioDto>.Error(
                    code: ResponseCode.InternalServerError,
                    message: "Ocurrió un error al intentar obtener el usuario.",
                    errors: new List<string> { ex.Message }
                );
            }
        }
        #endregion

        #region Obtener Todos los Usuarios
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns>Lista de usuarios o un mensaje de error si ocurre algún problema.</returns>
        public async Task<Result<List<UsuarioDto>>> GetAllAsync()
        {
            try
            {
                // Consulta para obtener todos los usuarios
                var usuarios = await _context.Usuarios
                    .Select(u => new UsuarioDto
                    {
                        IdUsuario = u.IdUsuario,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Correo = u.Correo,
                        Telefono = u.Telefono,
                        Direccion = u.Direccion
                    })
                    .ToListAsync();

                // Validar si no se encontraron usuarios
                if (usuarios == null || !usuarios.Any())
                {
                    return Result<List<UsuarioDto>>.Error(
                        code: ResponseCode.NotFound,
                        message: "No se encontraron usuarios."
                    );
                }

                // Retornar lista de usuarios encontrados
                return Result<List<UsuarioDto>>.Success(
                    data: usuarios,
                    message: "Usuarios obtenidos exitosamente."
                );
            }
            catch (Exception ex)
            {
                // Manejo de errores y retorno de respuesta en caso de excepción
                return Result<List<UsuarioDto>>.Error(
                    code: ResponseCode.InternalServerError,
                    message: "Ocurrió un error al intentar obtener los usuarios.",
                    errors: new List<string> { ex.Message }
                );
            }
        }
        #endregion


        #region Actualizar Usuario
        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a actualizar.</param>
        /// <param name="usuarioDto">Datos a actualizar. Los valores nulos se respetan según el modo indicado.</param>
        /// <param name="esActualizacionCompleta">Indica si se debe realizar una actualización completa o parcial.</param>
        /// <returns>Resultado del proceso.</returns>
        public async Task<Result<UsuarioDto>> UpdateAsync(int idUsuario, UsuarioDto usuarioDto, bool esActualizacionCompleta = false)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Busca el usuario por su ID
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);

                if (usuario == null)
                {
                    return Result<UsuarioDto>.Error(
                        code: ResponseCode.NotFound,
                        message: "Usuario no encontrado."
                    );
                }

                if (esActualizacionCompleta)
                {
                    // Actualización completa: todos los campos del DTO se aplican, incluso nulos
                    usuario.Nombre = usuarioDto.Nombre;
                    usuario.Apellido = usuarioDto.Apellido;
                    usuario.Correo = usuarioDto.Correo;
                    usuario.Contrasena = usuarioDto.Contrasena;
                    usuario.Telefono = usuarioDto.Telefono;
                    usuario.Direccion = usuarioDto.Direccion;
                }
                else
                {
                    // Actualización parcial: solo actualiza los campos no nulos en el DTO
                    if (!string.IsNullOrEmpty(usuarioDto.Nombre)) usuario.Nombre = usuarioDto.Nombre;
                    if (!string.IsNullOrEmpty(usuarioDto.Apellido)) usuario.Apellido = usuarioDto.Apellido;
                    if (!string.IsNullOrEmpty(usuarioDto.Correo)) usuario.Correo = usuarioDto.Correo;
                    if (!string.IsNullOrEmpty(usuarioDto.Contrasena)) usuario.Contrasena = usuarioDto.Contrasena;
                    if (!string.IsNullOrEmpty(usuarioDto.Telefono)) usuario.Telefono = usuarioDto.Telefono;
                    if (!string.IsNullOrEmpty(usuarioDto.Direccion)) usuario.Direccion = usuarioDto.Direccion;
                }

                // Actualiza la entidad en el contexto
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                // Commit de la transacción
                await transaction.CommitAsync();

                // Asignar el ID actualizado al DTO
                usuarioDto.IdUsuario = usuario.IdUsuario;

                return Result<UsuarioDto>.Success(
                    data: usuarioDto,
                    message: "Usuario actualizado exitosamente."
                );
            }
            catch (Exception ex)
            {
                // Rollback en caso de error
                await transaction.RollbackAsync();
                return Result<UsuarioDto>.Error(
                    code: ResponseCode.InternalServerError,
                    message: "Error al actualizar el usuario.",
                    errors: new List<string> { ex.Message }
                );
            }
        }
        #endregion


        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="idUsuario">ID del usuario a eliminar.</param>
        /// <returns>Resultado del proceso.</returns>
        public async Task<Result<UsuarioDto>> DeleteAsync(int idUsuario)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Busca el usuario por su ID
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == idUsuario);

                if (usuario == null)
                {
                    return Result<UsuarioDto>.Error(
                        code: ResponseCode.NotFound,
                        message: "Usuario no encontrado."
                    );
                }

                // Elimina al usuario del contexto
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                // Realiza el commit de la transacción
                await transaction.CommitAsync();

                return Result<UsuarioDto>.Success(
                    data: null, // No se retorna nada en `data` para evitar redundancia
                    message: "El usuario ha sido eliminado correctamente."
                );
            }
            catch (Exception ex)
            {
                // En caso de error, realiza el rollback
                await transaction.RollbackAsync();
                return Result<UsuarioDto>.Error(
                    code: ResponseCode.InternalServerError,
                    message: "Error al eliminar el usuario.",
                    errors: new List<string> { ex.Message }
                );
            }
        }


    }

}

