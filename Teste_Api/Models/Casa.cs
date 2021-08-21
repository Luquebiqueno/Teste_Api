using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Api.Models
{
    public class Casa
    {
        public int Convidados { get; set; }
        public int Quartos { get; set; }
        public int Camas { get; set; }
        public int Banheiros { get; set; }
        public QuartoDetalhes QuartoDetalhes { get; set; }
    }
}
