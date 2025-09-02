using ApiGestionDeudas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Domain.Interfaces
{
    public interface IDeudaRepository
    {
        Task<Deudas?> GetDeudaPorId(string Id);
        Task<string> InsertDeuda(Deudas deudas);
        Task<bool> UpdateDeuda(Deudas deudas);
        Task<List<Deudas>> GetDeduas(string IdUsuario);
        Task<List<Deudas>> GetDeduasPorUsuario(string IdUsuario);
    }
}
