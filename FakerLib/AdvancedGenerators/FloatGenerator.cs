using BaseGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedGenerators
{
    public class FloatGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            float result = 0;
            while (result == 0)
            {
                result = (float)random.NextDouble();
            }
            return result;
        }

        public Type GeneratedType()
        {
            return typeof(float);
        }
    }
}
