using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBase_Dominio.Basicos
{
    public abstract class EnumeradorBase<T> where T : class
    {
        public int Identificador { get; private set; }
        public string Descricao { get; private set; }

        public EnumeradorBase(int identificador, string descricao)
        {
            this.Identificador = identificador;
            this.Descricao = descricao;
        }

        public EnumeradorBase(string descricao)
        {
            this.Identificador = descricao.GetHashCode();
            this.Descricao = descricao;
        }

        public static IEnumerable<T> ObtenhaCatalogo()
        {
            var campos = typeof(T).GetFields(BindingFlags.Public |
                                         BindingFlags.Static |
                                         BindingFlags.DeclaredOnly);

            return campos.Select(f => f.GetValue(null)).Cast<T>();
        }

        public static T Obtenha(int identificador)
        {
            return ObtenhaCatalogo().SingleOrDefault(enumeradorBase => enumeradorBase.Equals(identificador));
        }

        public static explicit operator int(EnumeradorBase<T> obj)
        {
            return obj.Identificador;
        }

        public static explicit operator string(EnumeradorBase<T> obj)
        {
            return obj.Descricao;
        }

        public static bool operator ==(EnumeradorBase<T> obj1, EnumeradorBase<T> obj2)
        {
            return obj1?.Identificador == obj2?.Identificador;
        }

        public static bool operator !=(EnumeradorBase<T> obj1, EnumeradorBase<T> obj2)
        {
            return obj1?.Identificador != obj2?.Identificador;
        }

        public override bool Equals(object obj)
        {
            if (obj is int identificador)
                return this.Identificador == identificador;
            else if (obj is string descricao)
                return this.Descricao == descricao;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Identificador;
        }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
