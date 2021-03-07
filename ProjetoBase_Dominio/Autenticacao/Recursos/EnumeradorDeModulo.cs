using ProjetoBase_Dominio.Basicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Dominio.Autenticacao.Recursos
{
    public class EnumeradorDeModulo : EnumeradorBase<EnumeradorDeModulo>
    {
        public static readonly EnumeradorDeModulo MODELO = new EnumeradorDeModulo(
            "mODELO",
            EnumeradorDeRecurso.MODELO_ESTUDO);

        public EnumeradorDeRecurso[] Recursos { get; private set; }

        public EnumeradorDeModulo(string descricao, params EnumeradorDeRecurso[] recursos)
            : base(descricao)
        {
            this.Recursos = recursos;
        }
    }
}
