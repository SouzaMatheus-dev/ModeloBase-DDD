using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Infra_Data.Basicos.Atributos
{
    public class RepositorioImplementadoAttribute : Attribute
    {
        public Type TipoBase { get; private set; }

        public RepositorioImplementadoAttribute(Type T)
        {
            TipoBase = T;
        }
    }
}
