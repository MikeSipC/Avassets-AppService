using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace ExampleService.Core.Extensions
{
    public static class StringExtension
    {
        public static string StringSqlDecode(this string str)
        {
            if (str != null)
            {
                str = str.Replace("##apos##", "'");
                str = str.Replace("##equ##", "=");
                str = str.Replace("##bopen##", "(");
                str = str.Replace("##bclose##", ")");
                str = str.Replace("##sel##", "select");
                str = str.Replace("##drp##", "drop");
                str = str.Replace("##ins##", "insert");
                str = str.Replace("##whr##", "where");
                str = str.Replace("##per##", "%");
                str = str.Replace("##lke##", "like");
                str = HttpUtility.HtmlDecode(str);
            }
            return str;
        }

        public static bool IsValidEmailAddress(this string str)
        {
            var pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            return Regex.IsMatch(str, pattern);
        }

        public static bool IsMobilePhone(this string str)
        {
            var pattern = "^((\\+\\d{1,3}(-| )?\\(?\\d\\)?(-| )?\\d{1,5})|(\\(?\\d{2,6}\\)?))(-| )?(\\d{3,4})(-| )?(\\d{4})(( x| ext)\\d{1,5}){0,1}$";
            return Regex.IsMatch(str, pattern);
        }

        public static double ToDouble(this string str)
        {
            double dbl = 0.0;
            double.TryParse(str, out dbl);
            return dbl;
        }

        public static int ToInt(this string str)
        {
            int n = 0;
            int.TryParse(str, out n);
            return n;
        }

        public static DateTime? ToDateTime(this string str)
        {
            DateTime.TryParseExact(str,
                                    "yyyy-MM-dd",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out var eventDateDt);

            return eventDateDt;
        }
    }
}
