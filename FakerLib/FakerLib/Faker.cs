using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{

    public class Faker
    {
        private TypesCreator creator = new TypesCreator();



        public T Create<T>()
        {
            T obj = (T)CreateDTO(typeof(T));
            return obj;
        }



        private object CreateDTO(Type type)
        {
            var obj = CreateWithConstructor(type);
            FillDTO(obj);
            return obj;
        }



        private object CreateWithConstructor(Type type)
        {
            try
            {
                if (creator.GeneratorExists(type))
                {
                    return creator.Create(type);
                }

                var constructor = type.GetConstructors()[0];
                var constrParams = constructor.GetParameters();
                if (constrParams.Any())
                {
                    var createdConstParams = new List<object>();
                    foreach (var constrParam in constrParams)
                    {
                        createdConstParams.Add(CreateDTO(constrParam.ParameterType));
                    }
                }
                return constructor.Invoke(constrParams.ToArray());
            }
            catch
            {
                try
                {
                    return Activator.CreateInstance(type);
                }
                catch
                {
                    return null;
                }
            }
        }



        private void FillDTO(object obj)
        {
            if (obj == null) { return; }

            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.SetMethod != null)
                {
                    if (creator.GeneratorExists(property.PropertyType))
                    {
                        property.SetValue(obj, creator.Create(property.PropertyType));
                        continue;
                    }

                    var propertyObject = CreateDTO(property.PropertyType);
                    FillDTO(propertyObject);
                    property.SetValue(obj, propertyObject);
                }
            }

            var fields = obj.GetType().GetFields();
            foreach (var field in fields)
            {
                try
                {
                    if (creator.GeneratorExists(field.FieldType))
                    {
                        field.SetValue(obj, creator.Create(field.FieldType));
                        continue;
                    }

                    var fieldObject = CreateDTO(field.FieldType);
                    FillDTO(fieldObject);
                    field.SetValue(obj, fieldObject);
                }
                catch
                {
                    field.SetValue(obj, null);
                }
            }
        }
    }
}
