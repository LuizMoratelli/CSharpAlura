using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class GerenciadorBonificacao
    {
        private double _totalBonificacao;

        public void Registrar(Funcionario funcionario) {
            _totalBonificacao += funcionario.GetBonificacao();
        }

        //Métodos podem ter o mesmo nome, com entradas diferentes
        //Dessa formas temos várias sobrecargas do método Registrar()
        //public void Registrar(Diretor diretor) { 
        //    _totalBonificacao += diretor.GetBonificacao();
        //}

        public double GetTotalBonificacao() {
            return _totalBonificacao;
        }
    }
}
