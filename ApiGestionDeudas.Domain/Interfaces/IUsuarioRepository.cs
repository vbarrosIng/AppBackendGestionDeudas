using ApiGestionDeudas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<string> InsertUsuario(Usuarios usuario);
        Task<Usuarios?> GetUsuario(string EmailUsuario);
    }
}
