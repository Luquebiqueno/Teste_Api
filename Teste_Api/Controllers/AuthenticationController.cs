using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Teste_Api.Dto;
using Teste_Api.Interfaces;

namespace Teste_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IUsuarioBusiness _usuarioBusiness;

        #endregion

        #region [ Contrutores ]

        public AuthenticationController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        #endregion

        #region [ Métodos ]

        [HttpPost]
        [AllowAnonymous]
        public object UsuarioAuthentication([FromBody] UsuarioLoginDto usuarioLoginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (usuarioLoginDto == null)
                return BadRequest();
            try
            {
                var result = _usuarioBusiness.GetUsuarioAuthentication(usuarioLoginDto);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion
    }
}
