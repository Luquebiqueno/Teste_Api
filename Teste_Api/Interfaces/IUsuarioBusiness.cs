using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Api.Dto;
using Teste_Api.Models;

namespace Teste_Api.Interfaces
{
    public interface IUsuarioBusiness
    {
        Usuario GetUsuarioByLoginSenha(string login, string senha);
        public object GetUsuarioAuthentication(UsuarioLoginDto usuarioLoginDto);
    }
}
