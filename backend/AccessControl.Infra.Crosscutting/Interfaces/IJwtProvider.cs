using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl.Infra.CrossCutting.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(string loginUsuario);
    }
}
