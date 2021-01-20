using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Linq;

namespace OOPLab12
{
    public static class Reflector<T> where T:new()
    {
        public static string GetAssemblyName(string class_name)
        {
            var result = Type.GetType(class_name).Assembly.GetName().Name;
            WriteToFile(class_name + "_AssemblyName", result);
            return result;
        }
        public static bool HavePublicConstructors(string class_name)
        {
            var result = Type.GetType(class_name).GetConstructors().Length != 0;
            WriteToFile(class_name + "_HavePublicConstructors", result);
            return result ;
        }
        public static IEnumerable<string> GetPublicMethods(string class_name)
        {
            var result = from method in Type.GetType(class_name).GetMethods()
                         where method.IsPublic
                         select method.Name;
            WriteToFile(class_name + "_PublicMethods", result);
            return result;
        }

        public  static IEnumerable<string> GetPropertiesFields(string class_name)
        {
            var properties = from property in Type.GetType(class_name).GetProperties()
                         select property.Name;
            var fields = from field in Type.GetType(class_name).GetFields()
                         select field.Name;
            var result = properties.Concat(fields);
            WriteToFile(class_name + "_PropertiesFields", result);
            return result;
        }

        public static void TypeMethods(string class_name, string parameter_type)
        {
            var methods = Type.GetType(class_name).GetMethods();
            var result = methods.Where(method => method.GetParameters().Where(parametr => parametr.ParameterType.Name.ToLower() == parameter_type.ToLower()).Count() != 0);
            if (result.Count() > 0)
            {
                Console.WriteLine($"Methods of class {class_name}, that has {parameter_type} parameter:");
                foreach (var el in result)
                    Console.WriteLine(el.Name);
            }
            else Console.WriteLine($"There is no methods with {parameter_type} parameter in class {class_name}");
        }

        public static void Invoke(string class_name, string method_name)
        {
            FileStream fstream = new FileStream("params.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fstream);
            object obj = Activator.CreateInstance(Type.GetType(class_name));
            string line = sr.ReadToEnd();
            MethodInfo m = Type.GetType(class_name).GetMethod(method_name);
            m.Invoke(obj, new object[] { line });
        }

        public static object Create(T type)
        {
            return Activator.CreateInstance(typeof(T));
        }

        private static void WriteToFile(string file_name, object obj)
        {
            using (FileStream fstream = new FileStream(file_name + ".txt", FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                if(obj is IEnumerable<string>)
                {
                    foreach (string element in obj as IEnumerable<string>)
                        sw.WriteLine(element);
                }
                else sw.WriteLine(obj);
                sw.Close();
            }
        }
    }
}
