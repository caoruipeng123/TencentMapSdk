

using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
namespace TencentMapSdk
{
    /// <summary>
    /// 系统类的扩展
    /// </summary>
    internal static partial class Extensions
    {
        /// <summary>
        /// 判断字符串是否能转换为Decimal类型。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string str)
        {
            return decimal.TryParse(str, out decimal returnValue);
        }
        /// <summary>
        /// 判断字符串是否能转换为Decimal类型。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string str, out decimal returnValue)
        {
            return decimal.TryParse(str, out returnValue);
        }
        /// <summary>
        /// 字符串转换为Decimal类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str)
        {
            return decimal.TryParse(str, out decimal returnValue) ? returnValue : default(decimal);
        }
        /// <summary>
        /// 字符串转换为Decimal类型并四舍五入保留指定位数的小数
        /// </summary>
        /// <param name="str">被转换的字符串</param>
        /// <param name="decimals">保留的小数位数，默认值为2</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str, int decimals = 2)
        {
            return decimal.TryParse(str, out decimal returnValue) ? decimal.Round(returnValue, decimals, MidpointRounding.AwayFromZero) : default(decimal);
        }
        /// <summary>
        /// 判断字符串能否成功转换为Double类型。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDouble(this string str)
        {
            return double.TryParse(str, out double returnValue);
        }
        /// <summary>
        /// 判断字符串能否成功转换为Double类型。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool IsDouble(this string str, out double returnValue)
        {
            return double.TryParse(str, out returnValue);
        }
        /// <summary>
        /// 字符串转换为double类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ToDouble(this string str)
        {
            return double.TryParse(str, out double returnValue) ? returnValue : default(double);
        }
        /// <summary>
        /// 判断字符串能否转换为int类型。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(this string str)
        {
            return int.TryParse(str, out int returnValue);
        }
        /// <summary>
        /// 判断字符串能否成功转换为Int32类型。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool IsInt(this string str, out int returnValue)
        {
            return int.TryParse(str, out returnValue);
        }
        /// <summary>
        /// 字符串转换为int32类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            return int.TryParse(str, out int returnValue) ? returnValue : default(int);
        }
        /// <summary>
        /// 字符串转换为int类型。如果转换失败，返回指定的默认值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns></returns>
        public static int ToInt(this string str, int defaultValue)
        {
            return int.TryParse(str, out int returnValue) ? returnValue : defaultValue;
        }
        /// <summary>
        /// 字符串转换为int类型或者null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToIntOrNull(this string str)
        {
            if (int.TryParse(str, out int returnValue))
            {
                return returnValue;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 字符串转换为Short类型(Int16类型)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static short ToShort(this string str)
        {
            return short.TryParse(str, out short returnValue) ? returnValue : default(short);
        }
        /// <summary>
        /// 字符串转换为Long类型(int64)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long ToLong(this string str)
        {
            return long.TryParse(str, out long returnValue) ? returnValue : default(long);
        }
        /// <summary>
        /// 去除字符串中所有空格，包括\r和\n。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpace(this string str)
        {
            if (str.IsNullOrEmpty()) return "";
            return str.Replace(" ", "").Replace("\r", "").Replace("\n", "");
        }
        /// <summary>
        /// 判断字符串能否转换为Long类型。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLong(this string str)
        {
            return long.TryParse(str, out long returnValue);
        }
        /// <summary>
        /// 判断字符串能够转换为Long类型。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool IsLong(this string str, out long returnValue)
        {
            return long.TryParse(str, out returnValue);
        }
        /// <summary>
        /// 判断字符串能够转换为DateTime类型。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string str)
        {
            return DateTime.TryParse(str, out DateTime returnValue);
        }
        /// <summary>
        /// 判断字符串能够转换为DateTime类型。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string str, out DateTime returnValue)
        {
            return DateTime.TryParse(str, out returnValue);
        }
        /// <summary>
        /// 字符串转换为DateTime类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            return str.ToDateTime(default(DateTime));
        }
        /// <summary>
        /// 字符串转换为DateTime类型。如果转换失败，返回指定的默认值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str, DateTime defaultValue)
        {
            return DateTime.TryParse(str, out DateTime returnValue) ? returnValue : defaultValue;
        }
        /// <summary>
        /// 字符串转换为DateTime类型，如果转换失败，返回null 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeOrNull(this string str,string format= "yyyy-MM-dd HH:mm:ss")
        {
            if (str.IsNullOrEmpty())
            {
                return null;
            }
            return DateTime.ParseExact(str, format, CultureInfo.CurrentCulture);
        }
        /// <summary>
        /// 判断字符串能够转换为Guid类型。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsGuid(this string str)
        {
            return Guid.TryParse(str, out Guid returnValue);
        }
        /// <summary>
        ///判断字符串能够转为Guid类型。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static bool IsGuid(this string str, out Guid returnValue)
        {
            return Guid.TryParse(str, out returnValue);
        }
        /// <summary>
        /// 字符串转换为Guid类型，如果转换失败，返回
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string str)
        {
            Guid test;
            if (Guid.TryParse(str, out test))
            {
                return test;
            }
            else
            {
                return Guid.Empty;
            }
        }
        /// <summary>
        /// 判断一个字符串是否为url格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUrl(this string str)
        {
            if (str.IsNullOrEmpty())
                return false;
            string pattern = @"^(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*$";
            return Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// 判断一个字符串是否为Email格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(this string str)
        {
            return Regex.IsMatch(str, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        /// <summary>
        /// 字符串转换为bool类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ToBoolean(this string str)
        {
            return Boolean.TryParse(str, out bool returnValue) ? returnValue : default(bool);
        }
        /// <summary>
        /// 判断字符串是否为空。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return str == null || string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 判断字符串是否为空。为空时返回ture并执行指定的委托
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action">字符串为空时，执行的委托</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str, Action action)
        {
            if (str == null || string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                if (action != null)
                    action();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 确认字符串不为空
        /// </summary>
        /// <param name="str"></param>
        /// <param name="newStr"></param>
        public static string EnsureNotNullOrEmpty(this string str, string newStr)
        {
            if (str.IsNullOrEmpty())
            {
                if (newStr.IsNullOrEmpty())
                {
                    throw new Exception("旧字符串和新字符串不应该都为空！");
                }
                return newStr;
            }
            return str;
        }
        /// <summary>
        /// 判断字符串是否不为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !str.IsNullOrEmpty();
        }
        /// <summary>
        /// 断字符串是否不为空。不为空时返回true并执行指定委托
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action">对象不为空时，指定的委托</param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string str, Action action)
        {
            if (!str.IsNullOrEmpty())
            {
                if (action != null)
                    action();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 截取左边多少个(length)字符。length小于1时，返回空字符串""。length大于被截取的字符串长度时，返回源字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Left(this string str, int length)
        {
            if (str == null || length < 1) { return ""; }
            if (length < str.Length)
            {
                return str.Substring(0, length);
            }
            else
            {
                return str;
            }
        }
        /// <summary>
        /// 获取右边多少个字符。length小于1时，返回空字符串""。length大于被截取的字符串长度时，返回源字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Right(this string str, int length)
        {
            if (str == null || length < 1) { return ""; }
            if (length < str.Length)
            {
                return str.Substring(str.Length - length);
            }
            else
            {
                return str;
            }
        }
        /// <summary>
        /// 字符串是否包含标点符号(不包括_下画线)。当字符串中包含_时，返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ContainPunctuation(this string str)
        {
            foreach (char c in str.ToCharArray())
            {
                if (char.IsPunctuation(c) && c != '_')
                    return true;
            }
            return false;

        }
        /// <summary>
        /// 去除字符串中的标点符号和空字符   
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemovePunctuationOrEmpty(this string str)
        {
            StringBuilder NewString = new StringBuilder(str.Length);
            char[] charArr = str.ToCharArray();
            foreach (char symbols in charArr)
            {
                if (!char.IsPunctuation(symbols) && !char.IsWhiteSpace(symbols))
                {
                    NewString.Append(symbols);
                }
            }
            return NewString.ToString();
        }
        /// <summary>
        /// 将字符串中的所有字符编码为一个字节序列
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding">编码方式：默认使用Encoding.UTF8</param>
        /// 该方法和<see cref="Decode(System.Collections.Generic.IEnumerable{byte}, Encoding)"/>相反
        /// <returns></returns>
        public static byte[] Encode(this string str, Encoding encoding = null)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            encoding = encoding ?? Encoding.UTF8;
            return encoding.GetBytes(str);
        }
        /// <summary>
        /// 判断字符串是否在指定的字符串集合中
        /// </summary>
        /// <param name="str"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool In(this string str, params string[] array)
        {
            if (array.Contains(str))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 将字符串转换为null或者枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Enum ToEnumOrNull<T>(this string str) where T : Enum
        {
            if (str.IsNullOrEmpty())
            {
                return null;
            }
            return (T)Enum.Parse(typeof(T), str);
        }
    }
}


