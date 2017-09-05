using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeObjectsToCsv
{
    public static class ExtensionMethods
    {
        public static string ConvertToCamelCaseSplitString(this string value)
        {
            string output = System.Text.RegularExpressions.Regex.Replace(value, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
            return output;
        }

        public static bool IsSimple(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsSimple(type.GetGenericArguments()[0]);
            }
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal))
              || type.Equals(typeof(DateTime));
        }
    }
}
