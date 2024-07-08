using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExampleCalloutPlugin
{
    internal class UtilFunctions
    {

        public static string GetAssemblyVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyVersionAttribute assemblyVersionAttribute = (AssemblyVersionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyVersionAttribute));
            return assemblyVersionAttribute?.Version ?? "?.?.?";
        }
    }
}
