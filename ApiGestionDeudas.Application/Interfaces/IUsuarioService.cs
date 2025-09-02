using ApiGestionDeudas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<string?> InsertUsuario(Usuarios usuario);
        Task<Usuarios?> ValidarUsuario(Usuarios usuario);
    }
}
