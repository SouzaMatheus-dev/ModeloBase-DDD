using ProjetoBase_Dominio.Autenticacao.Recursos;
using ProjetoBase_Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Dominio.Autenticacao
{
    public class Principal
    {
        public string IdSessao { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Grupo { get; set; }

        internal Principal() { }
        internal Principal(string idSessao, Usuario usuario)
        {
            this.IdSessao = idSessao;
            this.Email = usuario.EMAIL;
            this.Nome = usuario.NOME;
            this.Grupo = usuario.GRUPO;
        }

        public List<EnumeradorDeModulo> ObtenhaModulosHabilitados()
        {
            List<EnumeradorDeModulo> modulos = new List<EnumeradorDeModulo>();

            foreach (var modulo in EnumeradorDeModulo.ObtenhaCatalogo())
            {
                if (this.PossuiModuloHabilitado(modulo))
                    modulos.Add(modulo);
            }

            return modulos;
        }

        public bool PossuiModuloHabilitado(EnumeradorDeModulo modulo)
        {
            foreach (var recurso in modulo.Recursos)
            {
                if (this.RecursoEHabilitado(recurso))
                    return true;
            }

            return false;
        }

        public bool RecursoEHabilitado(EnumeradorDeRecurso recurso)
        {
            if (recurso.GruposPermitidos != null && recurso.GruposPermitidos.Length > 0)
            {
                foreach (var grupoPermitido in recurso.GruposPermitidos)
                {
                    if (this.Grupo == grupoPermitido)
                        return true;
                }

                return false;
            }

            return true;
        }
    }
}
