using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib.Generators
{
    public class IntGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            int result = 0;
            while (result == 0)
            {
                result = (int)random.Next(int.MinValue, int.MaxValue);
            }
            return result;
        }



        public Type GeneratedType()
        {
            return typeof(int);
        }
    }
}
