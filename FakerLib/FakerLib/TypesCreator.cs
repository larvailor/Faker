using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FakerLib.Generators;

namespace FakerLib
{
    public class TypesCreator
    {
        private Dictionary<Type, IGenerator> generators = new Dictionary<Type, IGenerator>();



        public TypesCreator()
        {
            LoadExistingGenerators();
        }



        private void LoadExistingGenerators()
        {
            IGenerator byteG = new ByteGenerator();
            generators.Add(byteG.GeneratedType(), byteG);

            IGenerator shortG = new ShortGenerator();
            generators.Add(shortG.GeneratedType(), shortG);

            IGenerator intG = new IntGenerator();
            generators.Add(intG.GeneratedType(), intG);
        }



        public bool GeneratorExists(Type type)
        {
            if (generators.ContainsKey(type))
            {
                return true;
            }
            return false;
        }




        public object Create(Type type)
        {
            return generators[type].Generate();
        }

       
        //private void LoadExistingGenerators()
        //{
        //    string pathToGeneratorsDir = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "\\Generators\\");
        //    string[] allGenerators = Directory.GetFiles(pathToGeneratorsDir);
        //    foreach (string generatorPath in allGenerators)
        //    {
        //        Assembly asm = Assembly.LoadFrom(generatorPath);
        //        foreach (Type type in asm.GetTypes())
        //        {
        //            if (type.GetInterface("IGenerator") != null)
        //            {
        //                generators.Add(type);
        //            }
        //        }
        //    }
        //}
    }
}
