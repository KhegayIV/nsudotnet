using System.Text;

namespace Khegay.Nsudotnet.TicTacToe
{
    static class Utils
    {
        internal static string ExtendWithSpaces(this string s)
        {
            if (s.Length == 0) return "";
            var builder = new StringBuilder();
            builder.Append(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                builder.Append(' ').Append(s[i]);
            }
            return builder.ToString();
        }
    }
}