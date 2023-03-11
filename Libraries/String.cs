using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace jsmhToolChest.Libraries
{
    internal class String
    {
        public static string GetRandomCharacters(int n = 10, bool Number = true, bool Lowercase = true, bool Capital = true ,string Characters = null)
        {
            StringBuilder tmp = new StringBuilder();
            Random rand = new Random();
            string characters = (Capital ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ" : null) + (Number ? "0123456789" : null) + (Lowercase ? "abcdefghijklmnopqrstuvwxyz" : null) + Characters;
            if (characters.Length < 1)
            {
                return (null);
            }
            for (int i = 0; i < n; i++)
            {
                tmp.Append(characters[rand.Next(0, characters.Length)].ToString());
            }
            return (tmp.ToString());
        }

        public static string GetMiddleString(string original, string before, string after)
        {
            string pattern = $@"(?<={Regex.Escape(before)}).+?(?={Regex.Escape(after)})";
            Match match = Regex.Match(original, pattern);
            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                throw new ArgumentException($"Could not find a matching string between \"{before}\" and \"{after}\" in \"{original}\".");
            }
        }
    }
}
