using Common.Dto;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businnes.Contratos
{
    public interface IUsuarioRepo:IgenericRepo<Usuario>
    {
        Task<Usuario> Actualizar(Usuario usuario);
    }
}
