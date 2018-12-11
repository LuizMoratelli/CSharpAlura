using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankDll.SistemaAgencia
{
    public class ExtratatorValorDeArgumentosURL
    {
        public string URL { get; }
        private readonly string _argumentos;

        // ctor = criar construtor
        public ExtratatorValorDeArgumentosURL(string url) {
            if (String.IsNullOrEmpty(url)) {
                throw new ArgumentException("O argumento URL não pode ser nulo nem vazio.", nameof(url));
            }
            //if (url == null)
            //    throw new ArgumentNullException(nameof(url));
            //else if (url == "")
            //    throw new ArgumentException("O argumento URL não pode ser uma string vazia.", nameof(url));

            URL = url;

            // Prefere-se utilizar o paramtro à propriedade, pois caso a propriedade seja movida no codigo o mesmo não terá efeito
            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao++);
        }

        public string GetValor(string nomeParametro) {
            string termo = nomeParametro + "=";
            int indiceTermo = _argumentos.IndexOf(termo);

            string resultado = _argumentos.Substring(indiceTermo + termo.Length);
            int indiceEComercial = resultado.IndexOf('&');

            if (indiceEComercial == -1)
                return resultado;

            return resultado.Remove(indiceEComercial);
        }
    }
}
