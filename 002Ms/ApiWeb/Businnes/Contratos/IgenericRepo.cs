using System.Linq.Expressions;

namespace Businnes.Contratos
{
    public interface IgenericRepo<T> where T : class
    {
        Task Crear(T entidad);
        Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>?  expression=null);
        Task<T> Obtener(Expression<Func<T, bool>>? expression = null, bool tracked=true);
        Task Remover(T entidad);
        Task Grabar();
    }
}
