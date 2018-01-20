using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto
{
    public class Ayuda
    {   
        public static string Left(string param, int length)
        {

            string result = param.Substring(0, length);
            return result;
        }

        public static string Right(string param, int length)
        {

            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }

        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }
    }
}
