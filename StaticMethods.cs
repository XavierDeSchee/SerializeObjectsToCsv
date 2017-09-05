using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SerializeObjectsToCsv
{
    public static class StaticMethods
    {
        public static void SerializeToCsv<T>(List<T> objects, string path)
        {
            if (Path.GetExtension(path) != ".csv")
            {
                throw new ArgumentException("Invalid argument: the following path should end with a .csv extension: " + path);
            }

            var output = objects.First().ToCsvHeader();
            output += Environment.NewLine;

            objects.ForEach(obj =>
            {
                output += obj.ToCsvRow();
                output += Environment.NewLine;
            });

            System.IO.File.WriteAllText(path, output);
        }

        private static string ToCsvHeader(this object obj)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            string result = string.Empty;
            Array.ForEach(properties, prop =>
            {
                if (prop.PropertyType.IsSimple() && !prop.IsDefined(typeof(InternalUseOnly), true))
                    result += prop.Name.ConvertToCamelCaseSplitString() + ",";
            });

            return (!string.IsNullOrEmpty(result) ? result.Substring(0, result.Length - 1) : result);
        }

        private static string ToCsvRow(this object obj)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            string result = string.Empty;
            Array.ForEach(properties, prop =>
            {
                if (prop.PropertyType.IsSimple() && !prop.IsDefined(typeof(InternalUseOnly), true))
                {
                    var value = prop.GetValue(obj, null);
                    var propertyType = prop.PropertyType.FullName;
                    if (propertyType == "System.String")
                    {
                        value = "\"" + value + "\"";
                    }

                    result += value + ",";
                }

            });

            return (!string.IsNullOrEmpty(result) ? result.Substring(0, result.Length - 1) : result);
        }
    }
}
