using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankDll.Modelos
{
    // Helpers são auxiliares não concretos e não devem ser expostos
    // Internal (ou apenas class) possui logica apenas para escopo do projeto, apenas para biblioteca
    internal class AutenticacaoHelper
    {
        public bool CompararSenhas(string senhaVerdadeira, string senhaTentativa) {
            return senhaVerdadeira == senhaTentativa;
        }
    }
}
