using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankDll.Modelos
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override bool Equals(object obj) {
            // converte obj to cliente
            // Tenta ser executada se não for possível converter retorna exception
            //Cliente outroCliente = (Cliente) obj;
            // Tenta ser executada se não for possível converter será nulo.
            Cliente outroCliente = obj as Cliente;
            
            if (outroCliente == null)
                return false;

            return Nome == outroCliente.Nome &&
                CPF == outroCliente.CPF &&
                Profissao == outroCliente.Profissao;
        }
    }
}
