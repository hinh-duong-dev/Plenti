using System.Text;

namespace Plenti.Utils
{
    public static class AppUtils
    {
        public static decimal CalculateDistance(decimal x1, decimal x2, decimal y1, decimal y2)
        {
            var temp1 = Math.Pow((double)(x2 - x1), 2);
            var temp2 = Math.Pow((double)(y2 - y1), 2);

            var dist = Convert.ToDecimal(Math.Sqrt(temp1 + temp2));

            //meters -> default
            return dist * 1609.344m;

        }

        public static string RemoveUnusualCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static bool IsMatchReferralCode(this string code1, string code2)
        {
            var array1 = code1.ToCharArray();
            var array2 = code2.ToCharArray();

            var differentChars = array1.Except(array2);

            return !differentChars.Any();
        }
    }
}
