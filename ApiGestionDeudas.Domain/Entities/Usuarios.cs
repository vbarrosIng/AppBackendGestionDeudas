using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Domain.Entities
{
    public class Usuarios
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string PassdHash { get; set; } = null!;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
