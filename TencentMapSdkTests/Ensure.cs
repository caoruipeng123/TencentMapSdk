using System;
using System.Collections.Generic;
using System.Linq;
namespace TencentMapSdkTests
{
    /// <summary>
    /// 确保输入值必须满足某个条件。如果不满足条件，就抛出异常。
    /// </summary>
    internal class Ensure
    {
        /// <summary>
        /// 确保输入值不为空字符串。如果为空字符串(null、""、"  "、string.empty)，就抛异常。
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <exception cref="ArgumentException"></exception>
        public static void NotNullOrEmpty(string paramName, string input)
        {
            if (input == null || string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                throw new ArgumentException($"参数:{paramName}不能为空字符串！", paramName);
        }
        /// <summary>
        /// 确保输入值为空字符串。如果不为空字符串(null、""、"  "、string.empty)，就抛异常。
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <exception cref="ArgumentException"></exception>
        public static void NullOrEmpty(string paramName, string input)
        {
            if (input != null && string.IsNullOrEmpty(input) == false && string.IsNullOrWhiteSpace(input) == false)
                throw new ArgumentException($"参数:{paramName}不能为空字符串！", paramName);
        }
        /// <summary>
        /// 确保输入值不能为null。如果为null,就抛异常。
        /// </summary>
        /// <param name="paramName">参数名</param> 
        /// <param name="input">输入值</param>
        public static void NotNull(string paramName, object input)
        {
            if (input == null)
                throw new ArgumentException($"参数:{paramName}不能为null！", paramName);
        }
        /// <summary>
        /// 确保输入值必须为null。如果不为null,就抛异常。
        /// </summary>
        /// <param name="paramName">参数名</param> 
        /// <param name="input">输入值</param>
        public static void Null(string paramName, object input)
        {
            if (input != null)
                throw new ArgumentException($"参数:{paramName}必须为null！", paramName);
        }
        /// <summary>
        /// 确保集合中必须有元素。如果没有元素，就抛异常
        /// </summary>
        /// <param name="paramName">集合名</param>
        /// <param name="value">集合</param>
        public static void HasLength(string paramName, System.Collections.IEnumerable value)
        {
            System.Collections.IEnumerator enumerator = value.GetEnumerator();
            if (!enumerator.MoveNext())
                throw new Exception($"{paramName}不能为空，集合中至少需要包含一个元素！");
        }
        /// <summary>
        /// 确保输入值大于参考值。如果输入值小于等于参考值，就抛出异常。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <param name="value">参考值</param>
        public static void Gt<T>(string paramName, T input, T value = default) where T : IComparable
        {
            if (input.CompareTo(value) <= 0)
                throw new ArgumentException($"参数：{paramName}必须大于{value}", paramName);
        }
        /// <summary>
        /// 确保输入值大于等于参考值。如果输入值小于参考值，就抛出异常。
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <param name="value">参考值</param>
        public static void GtOrEq<T>(string paramName, T input, T value = default) where T : IComparable
        {
            if (input.CompareTo(value) < 0)
                throw new ArgumentException($"参数：{paramName}必须大于等于{value}", paramName);
        }
        /// <summary>
        /// 确保输入值小于参考值。如果输入值大于等于参考值，就抛出异常。
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <param name="value">参考值</param>
        public static void Lt<T>(string paramName, T input, T value = default) where T : IComparable
        {
            if (input.CompareTo(value) >= 0)
                throw new ArgumentException($"参数：{paramName}必须小于{value}", paramName);
        }
        /// <summary>
        /// 确保输入值小于等于参考值。如果输入值大于参考值，就抛出异常。
        /// </summary>
        /// <param name="paramName">参考值</param>
        /// <param name="input">输入值</param>
        /// <param name="value">参考值</param>
        public static void LtOrEq<T>(string paramName, T input, T value = default) where T : IComparable
        {
            if (input.CompareTo(value) > 0)
                throw new ArgumentException($"参数：{paramName}必须小于等于{value}", paramName);
        }
        /// <summary>
        /// 确保输入值等于参考值。如果输入值不等于参考值，就抛出异常。
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <param name="value">参考值</param>
        public static void Eq<T>(string paramName, T input, T value)
        {
            if (!value.Equals(input))
                throw new ArgumentException($"参数：{paramName}必须等于{value.ToString()}", paramName);
        }
        /// <summary>
        /// 确保输入值不等于参考值。如果输入值等于参考值，就抛出异常。
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <param name="value">参考值</param>
        public static void NotEq(string paramName, object input, object value)
        {
            if (value.Equals(input))
                throw new ArgumentException($"参数：{paramName}不能等于{value.ToString()}", paramName);
        }
        /// <summary>
        /// 确保输入值不在指定的范围。如果在指定范围之内，就抛出异常。
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <param name="value">范围值</param>
        public static void NotIn<T>(string paramName, object input, IEnumerable<T> value)
        {
            System.Collections.IEnumerator enumerator = value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (input.Equals(enumerator.Current))
                {
                    throw new Exception($"参数：{paramName}必须在指定的范围之外！");
                }
            }
        }
        /// <summary>
        /// 确保输入值在指定的范围内。如果不在指定范围，就抛出异常。
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <param name="value">范围集合</param>
        public static void In(string paramName, object input, System.Collections.IEnumerable value)
        {
            System.Collections.IEnumerator enumerator = value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (input.Equals(enumerator.Current))
                {
                    return;
                }
            }
            throw new Exception($"参数：{paramName}必须在指定的范围之内！");
        }
        /// <summary>
        /// 确保输入值在指定的范围内。如果不在指定范围，就抛出异常。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        /// <param name="value">范围值</param>
        public static void In<T>(string paramName, T input, params T[] value)
        {
            if (!value.Contains(input))
                throw new Exception($"参数：{paramName}必须在指定的范围之内！");
        }
        /// <summary>
        /// 确保输入的int值必须在指定的枚举范围之内，如果不在指定的枚举范围之内，就抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramName">参数名</param>
        /// <param name="input">输入值</param>
        public static void In<T>(string paramName, int input) where T : Enum
        {
            Array array = Enum.GetValues(typeof(T));
            foreach (var item in array)
            {
                int v = (int)item;
                if (v == input)
                {
                    return;
                }
            }
            throw new Exception($"参数：{paramName}必须在指定的枚举范围之内！");
        }
    }
}
