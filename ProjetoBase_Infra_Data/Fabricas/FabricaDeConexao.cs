using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Infra_Data.Fabricas
{
    public class FabricaDeConexao
    {
        private static string _DADOS_DE_CONEXAO { get; set; }

        public static string DADOS_DE_CONEXAO
        {
            get
            {
                if (string.IsNullOrEmpty(_DADOS_DE_CONEXAO))
                {
                    _DADOS_DE_CONEXAO = ConfigurationManager.ConnectionStrings["DATABASE"].ConnectionString;
                }

                return _DADOS_DE_CONEXAO;
            }
        }
    }
}
