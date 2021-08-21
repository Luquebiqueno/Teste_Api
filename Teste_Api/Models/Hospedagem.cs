using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Api.Models
{
    public class Hospedagem
    {
        public string Nome { get; set; }
        public int Valor { get; set; }
        public int Estrelas { get; set; }
        public int Reviews { get; set; }
        public DateTime Data { get; set; }
        public Endereco Endereco { get; set; }
        public Casa Casa { get; set; }
        public OQueOLugarOferece O_Que_O_Lugar_Oferece { get; set; }
        public DescricaoDoLugar DescricaoDoLugar { get; set; }
    }
}
