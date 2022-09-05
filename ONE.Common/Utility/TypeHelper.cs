using System;
using System.Reflection;

namespace ONE.Common.Utility
{
    public static class TypeHelper
    {
        /// <summary>
        /// Gets the first type found in all assemblies by the type name
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <returns></returns>
        public static Type GetFirstTypeFoundInAllAssemblies(string typeName)
        {
            //Iterate all of the assemblies to find the type by name
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.Name == typeName)
                    {
                        return type;
                    }
                }
            }

            //Return null if you can't find it
            return null;
        }
    }
}
