using ApiGestionDeudas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Application.Interfaces
{
    public interface IDeudaService
    {
        Task<string> InsertDedua(Deudas deuda);
        Task<bool> UpdateDeuda(Deudas deudas);
        Task<List<Deudas>?> GetDeudas(string IdUsuario);
        Task<List<Deudas>?> GetDeudasPorUsuario(string IdUsuario);
    }
}
