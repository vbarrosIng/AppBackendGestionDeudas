using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGestionDeudas.Domain.Interfaces
{
    public interface IAuth
    {
        string GenerateToken(string username);
    }
}
