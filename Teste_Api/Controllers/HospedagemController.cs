using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Api.Interfaces;

namespace Teste_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospedagemController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IHospedagemBusiness _hospedagemBusiness;

        #endregion

        #region [ Contrutores ]

        public HospedagemController(IHospedagemBusiness hospedagemBusiness)
        {
            _hospedagemBusiness = hospedagemBusiness;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult GetHospedagem()
        {
            var hospedagem = _hospedagemBusiness.GetHospedagem();
            return new ObjectResult(hospedagem);
        }

        #endregion
    }
}
