using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Infra_Modulos
{
    public class FabricaGenerica
    {
        private static StandardKernel _Kernel { get; set; }

        public static StandardKernel Kernel
        {
            get
            {
                if (_Kernel == null)
                {
                    _Kernel = new StandardKernel(new Provedor());
                }

                return _Kernel;
            }
        }

        public static T Crie<T>()
        {
            return Kernel.Get<T>();
        }

        public static object Crie(Type type)
        {
            return Kernel.Get(type);
        }
    }
}
