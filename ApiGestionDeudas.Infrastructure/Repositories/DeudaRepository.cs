using ApiGestionDeudas.Domain.Entities;
using ApiGestionDeudas.Domain.Interfaces;
using ApiGestionDeudas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiGestionDeudas.Infrastructure.Repositories
{
    public class DeudaRepository : IDeudaRepository
    {
        public DeudaRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public AppDbContext DbContext { get; }

        public async Task<string> InsertDeuda(Deudas deuda)
        {
            try
            {
                await DbContext.Deudas.AddAsync(deuda);
                await DbContext.SaveChangesAsync();
                return deuda.Id.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateDeuda(Deudas deudas)
        {
            try
            {
                
                DbContext.Update(deudas);
                await DbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<Deudas?> GetDeudaPorId(string Id) {
            var deuda = await DbContext.Deudas.FindAsync(Guid.Parse(Id));
            return deuda;
        }

        public async Task<List<Deudas>> GetDeduas(string IdUsuario)
        {
            try {
                var RespuestaDeudas = await DbContext.Deudas
                    .Where(u=> u.UsuarioId == Guid.Parse(IdUsuario))
                    .ToListAsync();
                return RespuestaDeudas;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Deudas>> GetDeduasPorUsuario(string IdUsuario)
        {
            try
            {
                var RespuestaDeudas = await DbContext.Deudas
                    .Where(d=> d.UsuarioId == Guid.Parse(IdUsuario))
                    .ToListAsync();

                return RespuestaDeudas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}
