using ApiGestionDeudas.Domain.Entities;
using ApiGestionDeudas.Domain.Interfaces;
using ApiGestionDeudas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public AppDbContext DbContext { get; }

        public async Task<string> InsertUsuario(Usuarios usuario)
        {
            try
            {
                await DbContext.Usuarios.AddAsync(usuario);
                await DbContext.SaveChangesAsync();
                return usuario.Id.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuarios?> GetUsuario(string EmailUsuario)
        {
            try {
                return await DbContext.Usuarios.Where(u=> u.Email == EmailUsuario)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }
    }
}
