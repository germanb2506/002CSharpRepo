using System.Linq.Expressions;

namespace Business.Contratos
{
    /// <summary>
    /// Interfaz genérica para repositorios, que define operaciones CRUD comunes y manejo de transacciones.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad que maneja el repositorio.</typeparam>
    public interface IGenericRepo<T> where T : class
    {
        /// <summary>
        /// Crea una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entidad">Entidad a crear.</param>
        Task Crear(T entidad);

        /// <summary>
        /// Obtiene una única entidad que cumple con un filtro.
        /// </summary>
        /// <param name="filtro">Expresión lambda para aplicar como filtro.</param>
        /// <param name="tracked">Indica si se debe rastrear la entidad en el contexto de EF.</param>
        /// <returns>La entidad encontrada o null.</returns>
        Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true);

        /// <summary>
        /// Obtiene todas las entidades que cumplen con un filtro opcional.
        /// </summary>
        /// <param name="filtro">Expresión lambda opcional para filtrar resultados.</param>
        /// <returns>Lista de entidades encontradas.</returns>
        Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null);

        /// <summary>
        /// Elimina una entidad de la base de datos.
        /// </summary>
        /// <param name="entidad">Entidad a eliminar.</param>
        Task Remover(T entidad);

        /// <summary>
        /// Guarda los cambios pendientes en el contexto de la base de datos.
        /// </summary>
        Task Grabar();

        /// <summary>
        /// Inicia una transacción explícita.
        /// </summary>
        Task IniciarTransaccion();

        /// <summary>
        /// Confirma los cambios dentro de la transacción actual.
        /// </summary>
        Task ConfirmarTransaccion();

        /// <summary>
        /// Revierte todos los cambios realizados dentro de la transacción actual.
        /// </summary>
        Task RevertirTransaccion();

        /// <summary>
        /// Obtiene una proyección específica de una entidad que cumple con un filtro.
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato proyectado (DTO).</typeparam>
        /// <param name="filtro">Filtro opcional para la consulta.</param>
        /// <param name="selector">Expresión para proyectar los datos a un tipo específico.</param>
        /// <returns>El objeto proyectado o null.</returns>
        Task<TResult> GetProy<TResult>(Expression<Func<T, bool>> filtro,Expression<Func<T, TResult>> selector);

        /// <summary>
        /// Obtiene una lista proyectada de entidades que cumplen con un filtro.
        /// </summary>
        /// <typeparam name="TResult">Tipo de dato proyectado (DTO).</typeparam>
        /// <param name="filtro">Filtro opcional para la consulta.</param>
        /// <param name="selector">Expresión para proyectar los datos a un tipo específico.</param>
        /// <returns>Lista de objetos proyectados.</returns>
        Task<List<TResult>> GetAllProy<TResult>(Expression<Func<T, bool>>? filtro, Expression<Func<T, TResult>> selector);

    }
}
