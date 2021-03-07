using ProjetoBase_Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Dominio.Servicos.Base
{
    public abstract class ServicoBase
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; set; }
        public ServicoBase(IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            this.UnidadeDeTrabalho = unidadeDeTrabalho;
        }

        public void Dispose()
        {
            UnidadeDeTrabalho.Dispose();
        }
    }
}
