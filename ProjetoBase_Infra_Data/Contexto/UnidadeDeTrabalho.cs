using ProjetoBase_Dominio.Interfaces;
using ProjetoBase_Infra_Data.Basicos.Atributos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Infra_Data.Contexto
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private IDbConnection Conexao { get; set; }
        private Dictionary<string, object> DicionarioDeRepositorios { get; set; }

        public UnidadeDeTrabalho(IDbConnection conexao)
        {
            this.Conexao = conexao;
        }

        private IRepositorio<T> ObtentorDeRepositorio<T>() where T : class
        {
            if (this.DicionarioDeRepositorios == null)
                this.DicionarioDeRepositorios = new Dictionary<string, object>();

            var type = typeof(T);

            if (!this.DicionarioDeRepositorios.ContainsKey(type.Name))
            {
                var assembly = Assembly.GetExecutingAssembly();

                foreach (Type tclass in assembly.GetTypes())
                {
                    if (tclass.GetCustomAttribute(typeof(RepositorioImplementadoAttribute), false) != null)
                    {
                        RepositorioImplementadoAttribute repo = (RepositorioImplementadoAttribute)Attribute.GetCustomAttribute(tclass, typeof(RepositorioImplementadoAttribute));

                        if (repo.TipoBase == type)
                        {
                            object repoInstance = Activator.CreateInstance(tclass, this.Conexao);
                            this.DicionarioDeRepositorios.Add(type.Name, repoInstance);

                            return DicionarioDeRepositorios[type.Name] as IRepositorio<T>;
                        }
                    }
                }

                //caso o foreach não encontrou a implementação do repositório - retorne excecao
                throw new Exception("Repositório não implementado");
            }

            return DicionarioDeRepositorios[type.Name] as IRepositorio<T>;
        }

        public TRepo ObtentorDeRepositorio<T, TRepo>()
            where T : class
            where TRepo : IRepositorio<T>
        {
            return (TRepo)this.ObtentorDeRepositorio<T>();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
