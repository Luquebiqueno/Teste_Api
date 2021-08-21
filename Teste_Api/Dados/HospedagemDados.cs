using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Api.Interfaces;
using Teste_Api.Models;

namespace Teste_Api.Dados
{
    public class HospedagemDados : IHospedagemDados
    {
        public Hospedagem GetHospedagem()
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\hospedagem.json");

            var hospedagem = JsonConvert.DeserializeObject<Hospedagem>(json);

            return hospedagem;
        }
    }
}
