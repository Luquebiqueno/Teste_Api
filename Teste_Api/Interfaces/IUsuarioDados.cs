using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Api.Models;

namespace Teste_Api.Interfaces
{
    public interface IUsuarioDados
    {
        List<Usuario> GetUsuario();
    }
}
