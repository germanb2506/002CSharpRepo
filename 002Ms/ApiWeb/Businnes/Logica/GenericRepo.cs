using Businnes.Contratos;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Businnes.Logica
{
    public class GenericRepo<T> : IgenericRepo<T> where T : class
    {
        private readonly Context _context;
        internal DbSet<T> dbSet;
        public GenericRepo(Context context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }


        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad);
            await Grabar();
        }

        public async Task Grabar()
        {
            await _context.SaveChangesAsync();
        }



        public async Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true)
        {
            IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.FirstOrDefaultAsync();
        }




        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            return await query.ToListAsync();
        }

        

        public Task Remover(T entidad)
        {
            dbSet.Remove(entidad);
            return Task.CompletedTask;
        }
    }
}
