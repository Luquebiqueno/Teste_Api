using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Api.Interfaces;
using Teste_Api.Models;

namespace Teste_Api.Dados
{
    public class UsuarioDados : IUsuarioDados
    {

        public List<Usuario> GetUsuario()
        {
            List<Usuario> usuario = new List<Usuario>();
            usuario.Add(new Usuario() { Nome = "Luque", Email = "luque@email.com", Telefone = 11980331240, Login = "luque", Senha = "luque" });
            return usuario;
        }
    }
}
