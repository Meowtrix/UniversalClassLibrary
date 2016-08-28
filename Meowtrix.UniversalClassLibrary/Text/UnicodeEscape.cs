using System.Globalization;
using System.Text.RegularExpressions;

namespace Meowtrix.Text
{
    /// <summary>
    /// Provide static methods for unicode encoded (\uXXXX) strings.
    /// </summary>
    public static class UnicodeEscape
    {
        private static readonly Regex reUnicode = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);
        /// <summary>
        /// Decode an encoded string.
        /// </summary>
        /// <param name="s">Encoded string.</param>
        /// <returns>Decoded string.</returns>
        public static string UnicodeDecode(this string s)
            => reUnicode.Replace(s, m =>
            {
                short c;
                if (short.TryParse(m.Groups[1].Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c))
                    return ((char)c).ToString();
                return m.Value;
            });
    }
}
