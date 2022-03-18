using System;
using System.Linq;

namespace nuestra_boda.Core.Helpers
{
    public static class CodeHelper
    {
        public static string GenerateCode(int length = 6)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
