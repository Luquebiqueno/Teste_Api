using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Teste_Api.Dados;
using Teste_Api.Dto;
using Teste_Api.Helpers;
using Teste_Api.Interfaces;
using Teste_Api.Models;

namespace Teste_Api.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioDados _usuarioDados;
        private readonly SigningConfiguration _signingConfiguration;
        private readonly TokenConfiguration _tokenConfiguration;

        public UsuarioBusiness(IUsuarioDados usuarioDados,
                               SigningConfiguration signingConfiguration,
                               TokenConfiguration tokenConfiguration)
        {
            _usuarioDados = usuarioDados;
            _signingConfiguration = signingConfiguration;
            _tokenConfiguration = tokenConfiguration;
        }

        public Usuario GetUsuarioByLoginSenha(string login, string senha)
        {
            var usuario = _usuarioDados.GetUsuario().FirstOrDefault(x => x.Login == login && x.Senha == senha);

            return usuario;
        }

        public object GetUsuarioAuthentication(UsuarioLoginDto usuarioLoginDto)
        {
            var usuario = GetUsuarioByLoginSenha(usuarioLoginDto.Login, usuarioLoginDto.Senha);
            if (usuario == null)
            {
                return new
                {
                    authenticated = false,
                    message = "Login/Senha errado."
                };
            }
            else
            {
                var identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Login),
                    new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //Jti id do Token
                            new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login),
                            new Claim("Senha", usuario.Senha),
                    });

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expirationDate, handler);

                return SucessObject(createDate, expirationDate, token, usuarioLoginDto);
            }
        }

        private object SucessObject(DateTime createDate, DateTime expirationDate, string token, UsuarioLoginDto usuarioLoginDto)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = usuarioLoginDto.Login,
                message = "Usuário Logado com sucesso."
            };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

    }
}
