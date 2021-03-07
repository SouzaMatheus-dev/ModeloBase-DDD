using ProjetoBase_Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoBase_Dominio.Autenticacao
{
    public class ContextoPrincipal
    {
        const string CONTEXTO_PRINCIPAL = "BASE_CONTEXT";

        public static Principal Principal
        {
            get
            {
                return HttpContext.Current?.Session?[CONTEXTO_PRINCIPAL] as Principal;
            }
        }

        public static Principal ObtenhaContextoPrincipal(HttpContextBase httpContext)
        {
            //Nesse momento, eu obtenho o objeto principal da sessão
            return httpContext.Session[CONTEXTO_PRINCIPAL] as Principal;
        }

        public static string ObtenhaIDSessao()
        {
            return HttpContext.Current.Session.SessionID;
        }

        internal static string CarregueContexto(Usuario usuario)
        {
            var sessionID = HttpContext.Current.Session.SessionID;
            var principal = new Principal(sessionID, usuario);

            AtualizePrincipal(principal);

            return sessionID;
        }

        public static void FinalizeSessao()
        {
            HttpContext.Current.Session.Remove(CONTEXTO_PRINCIPAL);
        }

        private static void AtualizePrincipal(Principal principal)
        {
            //Nesse momento, eu seto o objeto principal da sessão
            //ContextoPrincipal.Principal.nomeDoCampo (Pego em qualquer lugar do codigo)
            HttpContext.Current.Session[CONTEXTO_PRINCIPAL] = principal;
        }
    }
}
