using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel;
using System.Reflection;

namespace Supermarket.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Classe responsável pela transformação de um EUnitOfMeasurement em uma string
        /// utilizando API Reflection para extrair info de uma StringValue
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string ToDescriptionString<TEnum>(this TEnum @enum)
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var attributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            
            return attributes?[0].Description ?? @enum.ToString();
        }
    }
}
