using ProjetoBase_Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Infra_Data.Repositorios.Base
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected IDbConnection Conexao { get; set; }
        public Repositorio(IDbConnection conexao)
        {
            this.Conexao = conexao;
        }
    }
}
