namespace PokedexG.Uwp.Utils
{
    /// <summary>
    /// Static class used to provide internal tools
    /// </summary>
    public static class ConverterHelper
    {
        /// <summary>
        /// Helper method to safely cast an object to a boolean
        /// </summary>
        /// <param name="parameter">Parameter to cast to a boolean</param>
        /// <returns>Bool value or false if cast failed</returns>
        public static bool TryParseBool(object parameter)
        {
            var parsed = false;
            if (parameter != null)
            {
                bool.TryParse(parameter.ToString(), out parsed);
            }

            return parsed;
        }

        /// <summary>
        /// Helper method to safely cast an object to an integer
        /// </summary>
        /// <param name="parameter">Parameter to cast to an integer</param>
        /// <returns>Bool value or false if cast failed</returns>
        public static int TryParseInt(object parameter)
        {
            var parsed = 0;
            if (parameter != null)
            {
                int.TryParse(parameter.ToString(), out parsed);
            }

            return parsed;
        }
    }
}