using ApiGestionDeudas.Application.Interfaces;
using ApiGestionDeudas.Domain.Entities;
using ApiGestionDeudas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Application
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        public IUsuarioRepository UsuarioRepository { get; }

        public async Task<string?> InsertUsuario(Usuarios usuario)
        {
            try
            {
                var passHash = encryptarPass(usuario.PassdHash);
                usuario.PassdHash = passHash;

                var RespuestaInsertUsuario = await UsuarioRepository.InsertUsuario(usuario);
                if (RespuestaInsertUsuario == null)
                {
                    return null;
                }

                return RespuestaInsertUsuario.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuarios?> ValidarUsuario(Usuarios usuario)
        {
            try
            {
                var RespuestaUsuario = await UsuarioRepository.GetUsuario(usuario.Email);
                if (RespuestaUsuario == null)
                {
                    return null;
                }

                var hashSave = RespuestaUsuario.PassdHash;
                var passHash = usuario.PassdHash;
                var ValidarUsuario = validarPass(passHash, hashSave);

                if (!ValidarUsuario)
                {
                    return null;
                }

                return RespuestaUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.Message);
            }
        }

        private string encryptarPass(string pass)
        {

            string hashed = BCrypt.Net.BCrypt.HashPassword(pass);
            return hashed;

        }
        
        private bool validarPass(string passHash, string hashSave)
        {

            bool isValid = BCrypt.Net.BCrypt.Verify(passHash, hashSave);
            return isValid;
        }
    }
}
