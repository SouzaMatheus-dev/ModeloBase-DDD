using ProjetoBase_Dominio.Basicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Dominio.Autenticacao.Recursos
{
    public class EnumeradorDeRecurso : EnumeradorBase<EnumeradorDeRecurso>
    {
        public static readonly EnumeradorDeRecurso MODELO_ESTUDO = new EnumeradorDeRecurso(
           "",
           "",
           "",
           "");

        public string Controller { get; private set; }
        public string Action { get; private set; }
        public string Icone { get; private set; }
        public string[] GruposPermitidos { get; private set; }

        protected EnumeradorDeRecurso(
            string descricao,
            string controller,
            string action,
            string icone,
            params string[] gruposPermitidos)
            : base(descricao)
        {
            this.Controller = controller;
            this.Action = action;
            this.Icone = icone;
            this.GruposPermitidos = gruposPermitidos;
        }
    }
}
