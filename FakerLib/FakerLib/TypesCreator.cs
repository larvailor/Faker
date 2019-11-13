using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BaseGenerator;
using FakerLib.Generators;

namespace FakerLib
{
    public class TypesCreator
    {
        private Dictionary<Type, IGenerator> generators = new Dictionary<Type, IGenerator>();



        public TypesCreator()
        {
            try
            {
                LoadExistingGenerators();
                LoadAdvancedGenerators();
            }
            catch
            {
                // nothing to loads
            }
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



        private void LoadAdvancedGenerators()
        {
            string pathToAdvancedGeneratorsDll = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\lib\\");
            string[] allDll = Directory.GetFiles(pathToAdvancedGeneratorsDll, "*.dll");
            foreach (string dllPath in allDll)
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                foreach (Type type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator g = (IGenerator)Activator.CreateInstance(type); 
                        generators.Add(g.GeneratedType(), g);
                    }
                }
            }
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
