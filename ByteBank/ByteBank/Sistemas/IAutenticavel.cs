using ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Sistemas
{
    // Interface é semelhante a uma classe abstrata porém nunca pode implementar um método
    public interface IAutenticavel
    {
        // Todos os membros são publicos por quem implementa
        bool Autenticar(string senha);
    }
}
