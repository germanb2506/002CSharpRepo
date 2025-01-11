using Businnes.Contratos;
using Data;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.Logica
{
    internal class UsuarioRepo : GenericRepo<Usuario>, IUsuarioRepo
    {
        private readonly Context _context;
        public UsuarioRepo(Context context):base (context)         
        {
                _context = context;
        }
        public Task<Usuario> Actualizar(Usuario usuario)
        {
            usuario
        }
    }
}
