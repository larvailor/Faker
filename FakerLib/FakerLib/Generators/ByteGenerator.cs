using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib.Generators
{
    class ByteGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            byte result = 0;
            while (result == 0)
            {
                result = (byte)random.Next(byte.MinValue, byte.MaxValue);
            }
            return result;
        }



        public Type GeneratedType()
        {
            return typeof(byte);
        }
    }
}
