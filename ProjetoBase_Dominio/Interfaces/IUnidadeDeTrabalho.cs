using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Dominio.Interfaces
{
    public interface IUnidadeDeTrabalho : IDisposable
    {
        /// <summary>
        /// Obtentor de Repositório com especificação do tipo de repositório específico a ser retornado
        /// </summary>
        /// <typeparam name="TRepo">Tipo de Repositório a ser retornado</typeparam>
        /// <typeparam name="T">Entidade do Repositório</typeparam>
        /// <returns></returns>
        TRepo ObtentorDeRepositorio<T, TRepo>() where T : class where TRepo : IRepositorio<T>;
    }
}
