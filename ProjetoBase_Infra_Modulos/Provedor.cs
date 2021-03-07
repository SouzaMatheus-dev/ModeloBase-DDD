using Ninject.Modules;
using ProjetoBase_Dominio.Interfaces;
using ProjetoBase_Infra_Data.Contexto;
using ProjetoBase_Infra_Data.Fabricas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Infra_Modulos
{
    public class Provedor : NinjectModule
    {
        public override void Load()
        {
            this.BindConexaoBancoDeDados();
            this.BindUnidadeDeTrabalho();

        }

        private void BindConexaoBancoDeDados()
        {
            Bind<IDbConnection>()
                .To<SqlConnection>()
                .WithConstructorArgument("connectionString", FabricaDeConexao.DADOS_DE_CONEXAO);
        }

        private void BindUnidadeDeTrabalho()
        {
            Bind<IUnidadeDeTrabalho>()
                .To<UnidadeDeTrabalho>();
        }
    }
}
