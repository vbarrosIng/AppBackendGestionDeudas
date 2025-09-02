using ApiGestionDeudas.Application.Interfaces;
using ApiGestionDeudas.Domain.Entities;
using ApiGestionDeudas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Application
{
    public class DeudaService : IDeudaService
    {
        public DeudaService(IDeudaRepository deudaRepository)
        {
            DeudaRepository = deudaRepository;
        }

        public IDeudaRepository DeudaRepository { get; }

        public async Task<string> InsertDedua(Deudas deuda)
        {
            try
            {
                var RespuestaDeduaInsert = await DeudaRepository.InsertDeuda(deuda);
                return RespuestaDeduaInsert;
            }
            catch (Exception ex)    
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateDeuda(Deudas deudas)
        {
            try
            {
                var RespuestaDeuda = await GetDeudaPorId(deudas.Id.ToString());
                if (RespuestaDeuda == null)
                {
                    return false;
                }

                if (RespuestaDeuda.Estado == 2)
                {
                    return false;
                }

                RespuestaDeuda.Estado = deudas.Estado;
                RespuestaDeuda.FechaPago = DateTime.UtcNow;

                await DeudaRepository.UpdateDeuda(RespuestaDeuda);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<Deudas?> GetDeudaPorId(string Id)
        {
            try
            {
                var RespuestaDeuda = await DeudaRepository.GetDeudaPorId(Id);
                if (RespuestaDeuda == null)
                {
                    return null;
                }

                return RespuestaDeuda;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<List<Deudas>?> GetDeudas(string IdUsuario)
        {
            try
            {
                var RespuestaDeudas = await DeudaRepository.GetDeduas(IdUsuario);
                if (RespuestaDeudas == null)
                {
                    return null;
                }

                return RespuestaDeudas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Deudas>?> GetDeudasPorUsuario(string IdUsuario)
        {
            try
            {
                List<Deudas> listDeudas = new List<Deudas>(); 

                var RespuestaDeudasUsuario = await DeudaRepository.GetDeduasPorUsuario(IdUsuario);
                if (RespuestaDeudasUsuario == null)
                {
                    return listDeudas;
                }

                return RespuestaDeudasUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

    }
}
