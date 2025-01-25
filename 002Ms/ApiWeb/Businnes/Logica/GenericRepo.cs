using Business.Contratos;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Business.Logica
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {  /// <summary>
       /// Contexto de la base de datos.
       /// </summary>
        private readonly Context _context;
        private readonly DbSet<T> dbSet;
        private IDbContextTransaction? _currentTransaction;
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="context"></param>
        public GenericRepo(Context context)
        {
            _context = context;
            dbSet = context.Set<T>();
        }
        /// <summary>
        /// Crea una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad);
            await Grabar();
        }
        /// <summary>
        /// Guarda los cambios pendientes en el contexto de la base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task Grabar()
        {
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Obtiene una única entidad que cumple con un filtro.
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="tracked"></param>
        /// <returns></returns>
        public async Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.FirstOrDefaultAsync();
        }
        /// <summary>
        /// Obtiene todas las entidades que cumplen con un filtro opcional.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.ToListAsync();
        }
        /// <summary>
        /// Elimina una entidad de la base de datos.
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        public async Task Remover(T entidad)
        {
            dbSet.Remove(entidad);
            await Grabar();
        }

        /// <summary>
        /// Inicia una transacción explícita.
        /// </summary>
        public async Task IniciarTransaccion()
        {
            if (_currentTransaction != null) return; // No se permite anidar transacciones.
            _currentTransaction = await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Confirma los cambios dentro de la transacción actual.
        /// </summary>
        public async Task ConfirmarTransaccion()
        {
            if (_currentTransaction == null)
                throw new InvalidOperationException("No hay una transacción activa para confirmar.");

            await Grabar(); // Guarda los cambios en la base de datos.
            await _currentTransaction.CommitAsync();
            _currentTransaction.Dispose();
            _currentTransaction = null;
        }

        /// <summary>
        /// Revierte todos los cambios realizados dentro de la transacción actual.
        /// </summary>
        public async Task RevertirTransaccion()
        {
            if (_currentTransaction == null)
                throw new InvalidOperationException("No hay una transacción activa para revertir.");

            await _currentTransaction.RollbackAsync();
            _currentTransaction.Dispose();
            _currentTransaction = null;
        }
        /// <summary>
        /// Obtiene una proyección específica de una entidad que cumple con un filtro.
        /// </summary>
        public async Task<TResult> GetProy<TResult>(Expression<Func<T, bool>> filtro, Expression<Func<T, TResult>> selector)
        {
            IQueryable<T> query = dbSet.AsNoTracking(); // No rastrear para reducir la sobrecarga.
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.Select(selector).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtiene una lista proyectada de entidades que cumplen con un filtro.
        /// </summary>
        public async Task<List<TResult>> GetAllProy<TResult>( Expression<Func<T, bool>>? filtro,Expression<Func<T, TResult>> selector)
        {
            IQueryable<T> query = dbSet.AsNoTracking(); // No rastrear para reducir la sobrecarga.
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.Select(selector).ToListAsync();
        }

    }
}
