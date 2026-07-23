using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PokedexG.Uwp.Utils
{
    public static class StringHelper
    {
        public static string ToCamelCase(this string stringToConvert)
        {
            var strings = stringToConvert.Split('_');
            var result = strings[0];

            for (int i = 1; i < strings.Length; i++)
            {
                var current = strings[i];
                result += current.Substring(0, 1).ToUpper() + current.Substring(1, current.Length - 1);
            }

            return result;
        }

        public static string ToPascalCase(this string stringToConvert)
        {
            var strings = stringToConvert.Split('_');
            var result = string.Empty;

            for (int i = 0; i < strings.Length; i++)
            {
                var current = strings[i];
                result += current.Substring(0, 1).ToUpper() + current.Substring(1, current.Length - 1);
            }

            return result;
        }

        public static string RemoveDiacritics(this string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                    .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                 UnicodeCategory.NonSpacingMark)
            ).Normalize(NormalizationForm.FormC);
        }

        public static string Take(this string text, int length = 1)
        {
            if (text == null)
                return string.Empty;
            if (text.Length < length)
                throw new ArgumentOutOfRangeException(nameof(length));

            var result = text[0].ToString().ToUpper();
            if (text.Length > 1)
                result += text.Substring(1, length - 1).ToLower();

            return result;
        }
    }
}