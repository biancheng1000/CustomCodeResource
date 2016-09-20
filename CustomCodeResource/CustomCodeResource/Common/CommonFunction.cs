using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomCode
{
    /// <summary>
    /// 通用函数库
    /// </summary>
   public class CommonFunction
    {

       static bool invalid;
       /// <summary>
       /// 验证字符串是否是有效的邮箱
       /// </summary>
       /// <param name="emailstr"></param>
       public static bool IsValidEmail(string strIn)
       {
          bool  invalid = false;
           if (String.IsNullOrEmpty(strIn))
               return false;

           // Use IdnMapping class to convert Unicode domain names. 
           try
           {
               strIn = Regex.Replace(strIn, @"(@)(.+)$",DomainMapper,
                                     RegexOptions.None, TimeSpan.FromMilliseconds(200));
           }
           catch (RegexMatchTimeoutException)
           {
               return false;
           }

           if (invalid)
               return false;

           // Return true if strIn is in valid e-mail format. 
           try
           {
               return Regex.IsMatch(strIn,
                     @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                     @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                     RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
           }
           catch (RegexMatchTimeoutException)
           {
               return false;
           }
       }

       /// <summary>
       /// 手机有效性验证
       /// </summary>
       /// <param name="strnumber"></param>
       /// <returns></returns>
       public static bool IsValidPhone(string strnumber)
       {
           if (strnumber.Length == 0)
            {
                return false;
            }
            else if (strnumber.Length != 11)
            {
                return false;
            }
            return System.Text.RegularExpressions.Regex.IsMatch(strnumber, @"^[1]+[3,4,5,7,8]+\d{9}");
       }

       private static string DomainMapper(Match match)
       {
           // IdnMapping class with default property values.
           IdnMapping idn = new IdnMapping();

           string domainName = match.Groups[2].Value;
           try
           {
               domainName = idn.GetAscii(domainName);
           }
           catch (ArgumentException)
           {
               invalid = true;
           }
           return match.Groups[1].Value + domainName;
       }



    }
}
