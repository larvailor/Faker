using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib.Generators
{
    public class ShortGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            short result = 0;
            while (result == 0)
            {
                result = (short)random.Next(short.MinValue, short.MaxValue);
            }
            return result;
        }



        public Type GeneratedType()
        {
            return typeof(short);
        }
    }
}
