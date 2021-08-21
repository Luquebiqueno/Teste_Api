using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste_Api.Interfaces;
using Teste_Api.Models;

namespace Teste_Api.Business
{
    public class HospedagemBusiness : IHospedagemBusiness
    {
        private readonly IHospedagemDados _hospedagemDados;
        public HospedagemBusiness(IHospedagemDados hospedagemDados)
        {
            _hospedagemDados = hospedagemDados;
        }
        public Hospedagem GetHospedagem()
        {
            var hospedagem = _hospedagemDados.GetHospedagem();

            return hospedagem;
        }
    }
}
