using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Faker
    {
        private Dictionary<Type, List<object>> innerTypes;

        public T Create<T>()
        {
            innerTypes = new Dictionary<Type, List<object>>();
            T obj = (T)CreateDTO(typeof(T));
            return obj;
        }
    }
}
