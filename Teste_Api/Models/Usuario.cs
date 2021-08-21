using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Api.Models
{
    public class Usuario
    {
        #region [ Propriedades ]

        public string Nome { get; set; }
        public string Email { get; set; }
        public long? Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        #endregion
    }
}
