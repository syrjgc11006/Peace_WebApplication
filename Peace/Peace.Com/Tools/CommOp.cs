using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Peace.Com.Tools
{
    /// <remarks>王家新, 2014-08-01, 2014-08-01</remarks>
    /// <summary>
    /// 常用工具方法
    /// </summary>
    public static class CommOp
    {
        /// <summary>
        /// 生成Guid字符串,不带{}号
        /// </summary>
        /// <returns></returns>
        public static string NewId()
        {
            return Guid.NewGuid().ToString("D");
        }

        /// <summary>
        /// 获取一个字符串的字节长度
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ByteLength(this string s)
        {
            if (s == null) return 0;
            return System.Text.Encoding.Default.GetByteCount(s);
        }

        #region 常见的类型转换
        /// <summary>
        /// 转换成Int32
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(object s)
        {
            int i = 0;
            if (s == null || s == DBNull.Value) return 0;
            if (s is int || s is short || s is byte || s is double || s.GetType().IsEnum) return Convert.ToInt32(s);
            if (int.TryParse(s.ToString(), out i)) return i;
            else return 0;
        }

        /// <summary>
        /// 将字符串转换为Int32数字
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            int i = 0;
            if (int.TryParse(s, out i)) return i;
            else return 0;
        }

        /// <summary>
        /// 将可为空整型转为整形，空值转为0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this int? s)
        {
            if (s == null) return 0;
            else return s.Value;
        }

        /// <summary>
        /// 将对象转为可为空整形
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int? ToIntNull(object s)
        {
            int i = 0;
            if (s == null || s == DBNull.Value) return null;
            if (s is int || s is short || s is byte || s is double || s.GetType().IsEnum) return Convert.ToInt32(s);
            if (int.TryParse(s.ToString(), out i)) return i;
            return null;
        }

        /// <summary>
        /// 转换成Int64(有符号)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long ToLong(object s)
        {
            long i = 0;
            if (s == null || s == DBNull.Value) return 0;
            if (s is long || s is int || s is short || s is byte || s.GetType().IsEnum) return Convert.ToInt64(s);
            if (long.TryParse(s.ToString(), out i)) return i;
            else return 0;
        }

        /// <summary>
        /// 转换成Int64(有符号)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long? ToLongNull(object s)
        {
            long i = 0;
            if (s == null || s == DBNull.Value) return null;
            if (s is long || s is int || s is short || s is byte || s.GetType().IsEnum) return Convert.ToInt64(s);
            if (long.TryParse(s.ToString(), out i)) return i;
            else return null;
        }

        /// <summary>
        /// 转换成Int64(无符号)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ulong ToULong(object s)
        {
            ulong i = 0;
            if (s == null || s == DBNull.Value) return 0;
            if (s is ulong || s is int || s is short || s is byte || s.GetType().IsEnum) return Convert.ToUInt64(s);
            if (ulong.TryParse(s.ToString(), out i)) return i;
            else return 0;
        }

        /// <summary>
        /// 转换成float
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float ToFloat(object s)
        {
            float i = 0f;
            if (s == null || s == DBNull.Value) return 0;
            if (s is decimal || s is float || s is long || s is int || s is short || s is byte
                || s.GetType().IsEnum) return Convert.ToSingle(s);
            if (float.TryParse(s.ToString(), out i)) return i;
            else return 0f;
        }

        /// <summary>
        /// 转换成可为空float
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static float? ToFloatNull(object s)
        {
            float i = 0f;
            if (s == null || s == DBNull.Value) return null;
            if (s is decimal || s is float || s is long || s is int || s is short || s is byte || s.GetType().IsEnum) return Convert.ToSingle(s);
            if (float.TryParse(s.ToString(), out i)) return i;
            else return null;
        }

        /// <summary>
        /// 转换成decimal
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object s)
        {
            if (s == null || s == DBNull.Value) return 0;
            if (s is decimal || s is float || s is double || s is long || s is int || s is short || s is byte || s.GetType().IsEnum) return Convert.ToDecimal(s);

            decimal i = 0;
            if (decimal.TryParse(s.ToString(), out i)) return i;
            else return 0;
        }

        /// <summary>
        /// 转换成可为空的decimal
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal? ToDecimalNull(object s)
        {
            if (s == null || s == DBNull.Value) return null;
            if (s is decimal || s is float || s is double || s is long || s is int || s is short || s is byte || s.GetType().IsEnum) return Convert.ToDecimal(s);

            decimal i = 0;
            if (decimal.TryParse(s.ToString(), out i)) return i;
            else return null;
        }

        /// <summary>
        /// 转换成Double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double ToDouble(object s)
        {
            if (s == null || s == DBNull.Value) return 0;
            if (s is decimal || s is float || s is double || s is long || s is int || s is short || s is byte || s.GetType().IsEnum) return Convert.ToDouble(s);

            double f = 0f;
            if (Double.TryParse(s.ToString(), out f)) return f;
            else return 0f;
        }

        /// <summary>
        /// 转换成可为空的Double
        /// </summary>
        /// <param name="s"></param>
        /// <returns>可为空的Double</returns>
        public static double? ToDoubleNull(object s)
        {
            if (s == null || s == DBNull.Value) return null;
            if (s is decimal || s is float || s is double || s is long || s is int || s is short || s is byte || s.GetType().IsEnum) return Convert.ToDouble(s);

            double f = 0f;
            if (Double.TryParse(s.ToString(), out f)) return f;
            else return null;
        }

        /// <summary>
        /// 转换成bool值,非0的数字或'True'转换成true,其他的转换成false
        /// </summary>
        /// <param name="s">非0的数字或'True'转换成true,其他的转换成false</param>
        /// <returns></returns>
        public static bool ToBool(object s)
        {
            if (s == null || s == DBNull.Value) return false;
            if (s is bool) return (bool)s;

            bool b = false;
            int i = 0;

            if (bool.TryParse(s.ToString(), out b))
            { return b; }
            else if (int.TryParse(s.ToString(), out i))
            { return i != 0; }
            else return s.ToString() == "是";
        }

        /// <summary>
        /// 转换成bool?值
        /// </summary>
        /// <param name="s">非0的数字或'True'转换成true,其他的转换成false</param>
        /// <returns></returns>
        public static bool? ToBoolNull(object s)
        {
            if (s == null || s == DBNull.Value) return null;
            if (s is bool) return (bool)s;

            bool b = false;
            int i = 0;

            if (bool.TryParse(s.ToString(), out b))
            { return b; }
            else
            { return null; }
        }

        /// <summary>
        /// 转换成string,无论如何也会返回一个非null值的串，并且自动去除了头尾空格
        /// </summary>
        /// <param name="obj">任何对象</param>
        /// <returns>非null的字符串</returns>
        public static string ToStr(object obj)
        {
            if (obj == null || obj == DBNull.Value) return "";
            return obj.ToString().Trim();
        }

        /// <summary>
        /// 判断对象是否是空值或空串或DBNULL
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsEmpty(object obj)
        {
            return (obj == null || obj == DBNull.Value || ToStr(obj) == "");
        }

        /// <summary>
        /// 判断对象是否是默认值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsEmpty(this DateTime? d)
        {
            return d == default(DateTime) || d == null;
        }

        /// <summary>
        /// 判断一个列表是否为空或没有数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> s)
        {
            return s == null || s.Count() == 0;
        }

        /// <summary>
        /// 遍历执行某个方法
        /// </summary>
        /// <param name="list">传入的枚举</param>
        /// <param name="action">方法的委托</param>
        /// <returns>原有的枚举</returns>
        public static IEnumerable<T> Each<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
            return list;
        }

        /// <summary>
        /// 遍历执行某个判断，当判断返回false时，终止遍历并跳出
        /// </summary>
        /// <param name="list">传入的枚举</param>
        /// <param name="func">方法的委托</param>
        /// <returns>当遍历终止时已经遍历过的元素枚举(不包括终止的元素)</returns>
        public static IEnumerable<T> Each<T>(this IEnumerable<T> list, Func<T, bool> func)
        {
            foreach (var item in list)
            {
                if (!func(item)) break;
                yield return item;
            }
        }

        /// <summary>
        /// 遍历执行某个方法
        /// </summary>
        /// <param name="list">传入的枚举</param>
        /// <param name="action">方法的委托</param>
        /// <returns>原有的枚举</returns>
        public static IEnumerable Each(this IEnumerable list, Action<object> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
            return list;
        }

        /// <summary>
        /// 遍历执行某个方法，返回某泛型枚举
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="list">输入的集合</param>
        /// <param name="func">函数委托</param>
        /// <returns>泛型T的枚举</returns>
        public static IEnumerable<T> Each<T>(this IEnumerable list, Func<object, T> func)
        {
            foreach (var item in list)
            {
                yield return func(item);
            }
        }

        /// <summary>
        /// 遍历执行某个判断，当判断返回false时，终止遍历并跳出
        /// </summary>
        /// <param name="list">传入的枚举</param>
        /// <param name="action">方法的委托</param>
        /// <returns>原有的枚举</returns>
        public static IEnumerable Each(this IEnumerable list, Func<object, bool> action)
        {
            foreach (var item in list)
            {
                if (!action(item)) break;
            }
            return list;
        }

        /// <summary>
        /// 将所有同类枚举合并成一个大枚举
        /// </summary>
        /// <typeparam name="T">组成枚举的数据类型</typeparam>
        /// <param name="list">同类枚举的枚举</param>
        /// <returns>合并后的单个枚举</returns>
        public static IEnumerable<T> UnionAll<T>(this IEnumerable<IEnumerable<T>> list)
        {
            if (list.IsEmpty())
            {
                return new List<T>();
            }
            IEnumerable<T> tempList = list.First();
            foreach (var subList in list.Skip(1))
            {
                tempList = tempList.Union(subList);
            }
            return tempList;
        }

        /// <summary>
        /// 转换成字符,如果是一个字符串，则取第一个字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static char ToChar(object s)
        {
            if (s == null || s == DBNull.Value || CommOp.ToStr(s) == "") return default(char);
            if (s is char) return (char)s;

            string cs = s.ToString();
            return cs.Length == 0 ? default(char) : cs[0];
        }

        /// <summary>
        /// 转换成Guid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid ToGuid(object s)
        {
            if (s == null || s == DBNull.Value) return Guid.Empty;
            return new Guid(ToStr(s));
        }

        /// <summary>
        /// 将整数的0转换成空串,其他原样转换
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String ToStr(this int s)
        {
            return s == 0 ? String.Empty : s.ToString();
        }

        /// <summary>
        /// 将字符串去左右空格，空值转为空字符串
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>去空格后的字符串</returns>
        public static String ToStr(this string s)
        {
            return s == null ? String.Empty : s.Trim();
        }

        /// <summary>
        /// 原样转换字符串,不截空格，空值转为空串
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>转换后的串</returns>
        public static string ToFullStr(object s)
        {
            if (s == null || s == DBNull.Value) return "";
            return s.ToString();
        }

        /// <summary>
        /// 原样转换字符串,不截空格， 并补齐空格
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="totalLen">加空格后的总长</param>
        /// <returns>加空格后的字符串</returns>
        public static string ToFullStr(object s, int totalLen)
        {
            if (s == null || s == DBNull.Value) return "".PadRight(totalLen);
            return s.ToString().PadRight(totalLen);
        }

        /// <summary>
        /// 截取指定长度字符串
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="len">保留的长度</param>
        /// <returns>截取后的串</returns>
        public static string CutStr(String s, int len)
        {
            if (s == null) s = "";
            if (s.Length > len) s = s.Substring(0, len);
            return s;
        }

        /// <summary>
        /// 根据firstchars在字符串的位置，截取firstChars前面的子串
        /// 没找到则原样返回
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <param name="firstChars">字符数组，在此数组中，查找第一个出现的字符</param>
        /// <returns>截取后的字符串</returns>
        public static string CutStr(String s, params char[] firstChars)
        {
            if (s == null) s = "";
            int idx = 0;
            foreach (char c in s)
            {
                if (firstChars.Contains(c)) break;
                idx++;
            }

            if (idx >= 0 && idx < s.Length) s = s.Remove(idx);
            return s;
        }

        /// <summary>
        /// 截取字符串,不足部分用...代替
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <param name="len">保留的长度</param>
        /// <returns>截取后的字符串</returns>
        public static string CutStrWithDot(String s, int len)
        {
            if (s == null) s = "";
            if (s.Length > len && len >= 4) s = s.Substring(0, len - 3) + "...";
            return s;
        }

        /// <summary>
        /// 按全角2个单位半角1个单位截取指定长度单位的字符串, 如果未截取完则补…
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <param name="len">保留的长度</param>
        /// <returns>截取后的字符串</returns>
        public static string CutByteStrDot(String s, int len)
        {
            if (s == null) return "";
            if (CommOp.ByteLength(s) <= len) return s;
            StringBuilder sb = new StringBuilder();
            int l = 0;
            foreach (char c in s)
            {
                l++;
                if (c > 127)
                {
                    l++;
                }
                if (l > len - 2)
                {
                    sb.Append("…");
                    break;
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 按全角2个单位半角1个单位截取指定长度单位的字符串
        /// </summary>
        /// <param name="s">原字符串</param>
        /// <param name="len">保留的长度</param>
        /// <returns>截取后的字符串</returns>
        public static string CutByteStr(String s, int len)
        {
            if (s == null) return "";
            if (CommOp.ByteLength(s) <= len) return s;

            StringBuilder sb = new StringBuilder();
            int l = 0;
            foreach (char c in s)
            {
                l++;
                if (c > 127)
                {
                    l++;
                }
                if (l >= len)
                {
                    break;
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将日期转换成yyyy-MM-dd或空串
        /// </summary>
        /// <param name="s">要转成日期的对象</param>
        /// <returns>日期串</returns>
        public static string ToDateStr(object s)
        {
            if (s == null || s == DBNull.Value) return "";
            DateTime d;
            if (DateTime.TryParse(s.ToString(), out d))
            {
                return ToDateStr(d);
            }
            else
                return "";
        }

        /// <summary>
        /// 将日期转成yyyy-MM-dd或空串
        /// </summary>
        /// <param name="d">要转的日期</param>
        /// <returns>日期串</returns>
        public static String ToDateStr(DateTime d)
        {
            if (d == DateTime.MinValue) return "";
            return d.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 对象转换为yy/mm/dd形式的日期字符串
        /// </summary>
        /// <param name="s">要转的对象</param>
        /// <returns>日期串</returns>
        public static string ToDateStr2(object s)
        {
            if (s == null || s == DBNull.Value) return "";
            DateTime d;
            if (DateTime.TryParse(s.ToString(), out d))
            {
                if (d == DateTime.MinValue) return "";
                return d.ToString(@"yy/MM/dd");
            }
            else
                return "";
        }

        /// <summary>
        /// 将日期转换成yy-MM-dd HH:mm:ss格式的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String ToTimeStr(object s)
        {
            if (s == null || s == DBNull.Value) return "";
            DateTime d;
            if (DateTime.TryParse(s.ToString(), out d))
            {
                if (d == DateTime.MinValue) return "";
                return d.ToString(@"yy-MM-dd HH:mm:ss");
            }
            else
                return "";
        }

        /// <summary>
        /// 将日期转换成yyyy-MM-dd HH:mm:ss格式的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String ToTimeStr(this DateTime d)
        {
            if (d == DateTime.MinValue) return "";
            return d.ToString(@"yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 将日期转换成MM-dd hh:mm格式的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String ToTimeStr2(object s)
        {
            if (s == null || s == DBNull.Value) return "";
            DateTime d;
            if (DateTime.TryParse(s.ToString(), out d))
            {
                if (d == DateTime.MinValue) return "";
                return d.ToString(@"MM-dd HH:mm");
            }
            else
                return "";
        }

        /// <summary>
        /// 将日期转换成MM-dd hh:mm格式的字符串
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static String ToTimeStr2(this DateTime d)
        {
            if (d == DateTime.MinValue) return "";
            return d.ToString(@"MM-dd HH:mm");
        }

        /// <summary>
        /// 将日期转换成MM-dd hh:mm格式的字符串
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static String ToTimeStr2(this DateTime? d)
        {
            if (d == DateTime.MinValue || d == null) return "";
            return d.Value.ToString(@"MM-dd HH:mm");
        }

        /// <summary>
        /// 转换成DateTime
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(object s)
        {
            DateTime d;
            if (s == null || s == DBNull.Value || !DateTime.TryParse(s.ToString(), out d))
                return default(DateTime);
            return d;
        }

        /// <summary>
        /// 转换成DateTime?型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull(object s)
        {
            DateTime d;
            if (s == null || s == DBNull.Value || !DateTime.TryParse(s.ToString(), out d))
                return null;
            return d;
        }

        /// <summary>
        /// 将字符串分割成整数数组
        /// </summary>
        /// <param name="ints"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int[] ToIntArray(string ints, char c)
        {
            if (ints.IsEmpty()) return new int[0];
            string[] sArr = ints.Split(c);
            int[] iArr = new int[sArr.Length];
            for (int i = 0; i < iArr.Length; i++)
            {
                iArr[i] = CommOp.ToInt(sArr[i]);
            }
            return iArr;
        }

        /// <summary>
        /// 将字符串分割成长整数数组
        /// </summary>
        /// <param name="ints"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static long[] ToLongArray(string ints, char c)
        {
            string[] sArr = ints.Split(c);
            long[] iArr = new long[sArr.Length];
            for (int i = 0; i < sArr.Length; i++)
            {
                iArr[i] = CommOp.ToLong(sArr[i]);
            }
            return iArr;
        }

        /// <summary>
        /// 转换成至少2位小数格式，不足补0
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static String ToNumStr2(object o)
        {
            if (o == null || o == DBNull.Value) return String.Empty;
            return String.Format("{0:0.00##}", o);
        }
        #endregion

        #region 将空值转换成数据库的空值
        /// <summary>
        /// 转换空串到DBNull.Value
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static object TestNull(String s)
        {
            if (s == null || s == "")
            {
                return DBNull.Value;
            }
            else
                return (object)s;
        }

        /// <summary>
        /// 检测Null值，转换对象到DBNull.Value
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static object TestNull(object s)
        {
            if (s == null || s.ToString() == "")
            {
                return DBNull.Value;
            }
            else
                return s;
        }

        /// <summary>
        /// 转换空日期到DBNull.Value
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static object TestNull(DateTime d)
        {
            return d == DateTime.MinValue ? DBNull.Value : (object)d;
        }

        /// <summary>
        /// 转换0到DBNull.Value
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static object TestNull(int i)
        {
            if (i == 0) return DBNull.Value;
            else return (object)i;
        }

        /// <summary>
        /// 转换空值到DBNull.Value
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static object TestNull(decimal i)
        {
            if (i == 0) return DBNull.Value;
            else return (object)i;
        }
        #endregion


        #region 验证

        /// <summary>
        /// 判断是否是Email地址
        /// </summary>
        /// <param name="email">要判断的地址字符串</param>
        /// <returns>是否</returns>
        public static bool IsEmail(string email)
        {
            if (email == null) return false;
            return Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        /// <summary>
        /// 验证是否为汉字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public bool IsChnChar(string str)
        {
            return Regex.IsMatch(str, @"^[\u4e00-\u9fa5]{0,}$");
        }

        /// <summary>
        /// 判断是否是电话号码
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string phoneNumber)
        {
            if (String.IsNullOrEmpty(phoneNumber)) return false;
            return Regex.IsMatch(phoneNumber, @"(\(\d{3}\)|\d{3}-)?\d{8}");
        }

        /// <summary>
        /// 判断是否含有除了字母及数字外的其他字符
        /// </summary>
        /// <param name="str">要验证的字符串</param>
        /// <returns>返回true代表不包含汉字或者特殊字符</returns>
        public static bool StrIsNumberOrLetters(string str)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-z0-9]+$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(this string str)
        {
            if (String.IsNullOrEmpty(str)) return false;
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(str);
            foreach (byte c in bytestr)
            {
                if (c < 48 || c > 57)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 过滤Sql字符串
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static String FilterSql(String sql)
        {
            return (sql ?? "").Replace("'", "''").Replace("--", "");
        }

        #endregion

        /// <summary>
        /// 清除HTML中的Tag标记，只留下文本。
        /// </summary>
        /// <param name="htmlStr">HTML字符串</param>
        /// <returns></returns>
        public static string RemoveHTML(string htmlStr)
        {
            if (String.IsNullOrEmpty(htmlStr)) return "";

            //先去除多余回车或空格
            Regex r = new Regex(@"(\s+|(&nbsp;)+)");
            htmlStr = r.Replace(htmlStr, " ").Trim();

            //将<p>和<br>换成回车换行
            htmlStr = Regex.Replace(htmlStr, "(</p>|<br/>|<br>|<p/>)", "\r\n", RegexOptions.IgnoreCase);

            //去掉所有html标记
            Regex objRegExp = new Regex("<(.|\n)+?>");
            htmlStr = objRegExp.Replace(htmlStr, "");
            htmlStr = htmlStr.Replace("<", "&lt;");
            htmlStr = htmlStr.Replace(">", "&gt;").Trim();

            return htmlStr;
        }

        /// <summary>
        /// 清除HTML中的Tag标记，只留下文本。保留段落
        /// </summary>
        /// <param name="htmlStr">HTML字符串</param>
        /// <returns>有换行标记的HTML</returns>
        public static string RemoveHTMLResP(string htmlStr)
        {
            if (String.IsNullOrEmpty(htmlStr)) return "";

            //先去除多余回车或空格
            Regex r = new Regex(@"\s+");
            htmlStr = r.Replace(htmlStr, " ").Trim();

            //将<p>和<br>换成回车换行
            htmlStr = Regex.Replace(htmlStr, "(</p>|<br/>|<br>|<p/>)", "\r\n", RegexOptions.IgnoreCase);

            //去掉所有html标记
            Regex objRegExp = new Regex("<(.|\n)+?>");
            htmlStr = objRegExp.Replace(htmlStr, "");
            htmlStr = htmlStr.Replace("<", "&lt;");
            htmlStr = htmlStr.Replace(">", "&gt;").Trim();

            //增加段落html标记
            htmlStr = "<p>" + htmlStr.Replace("\r\n", "</p><p>") + "</p>";
            return htmlStr;
        }

        /// <summary>
        /// 将普通字符串中的换行替换为HTML的回车或换行标记
        /// 以能在网页中正常显示换行或回车。
        /// </summary>
        /// <param name="s">字符串</param>
        public static string ToHtmlStr(object s)
        {
            if (s == null || s == DBNull.Value) return "";
            return s.ToString().Replace("\r\n", "<br />");

        }

        /// <summary>
        /// 添加引号
        /// </summary>
        /// <param name="str">需要添加的字符串</param>
        /// <returns></returns>
        public static string AddQuotation(string str)
        {
            if (str != "")
            {
                StringBuilder sb = new StringBuilder();
                string[] strSplit = str.Split(',');
                str = "";
                for (int i = 0; i < strSplit.Length; i++)
                {
                    if (strSplit[i] != "")
                    {
                        //str += "'" + strSplit[i] + "',";
                        sb.Append("'" + strSplit[i] + "',");
                    }
                }
                if (sb.Length > 0)
                {
                    return sb.Remove(sb.Length - 1, 1).ToString();
                }
                //if (str != "")
                //    return str.Substring(0, str.Length - 1);
                //else
                return "";
            }
            else
                return "";
        }

        /// <summary>
        /// 转换成Base64
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToBase64Str(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str ?? "");
            //转成 Base64 形式的 System.String
            return Convert.ToBase64String(b);
        }

        /// <summary>
        /// Base64转换成String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FromBase64Str(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str ?? "");
            //Base64 形式的 System.String
            return Encoding.Default.GetString(Convert.FromBase64String(str));
        }

        /// <summary>
        /// 将字符串强转成枚举型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string str)
            where T : struct
        {
            T t = default(T);

            Enum.TryParse<T>(str, out t);
            return t;
        }

        /// <summary>
        /// 一次次尝试action直到成功为止，这个对性能有很大影响,目前仅用于与Word有关的操作
        /// </summary>
        /// <param name="action">要执行的动作</param>
        /// <param name="tryTimes">重试次数</param>
        /// <param name="sleepMs">重试之间等待的时间(毫秒)</param>
        /// <returns>成功前重试的次数</returns>
        public static void TryAndTry(Action action, int tryTimes = 3, int sleepMs = 200)
        {
            int tryCount = 0;
            while (tryCount < tryTimes)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception ex)
                {
                    tryCount++;
                    if (tryCount >= tryTimes)
                    {
                        throw;
                    }
                    Thread.Sleep(sleepMs);
                }
            }
        }

        public static T TryAndTry<T>(Func<T> func, int tryTimes = 3, int sleepMs = 200)
        {
            int tryCount = 0;
            while (tryCount < tryTimes)
            {
                try
                {
                    return func();
                }
                catch (Exception ex)
                {
                    tryCount++;
                    if (tryCount >= tryTimes)
                    {
                        throw;
                    }
                    Thread.Sleep(sleepMs);
                }
            }
            return default(T);
        }


        #region 比较

        /// <summary>
        /// 判断两个泛型对象是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool EqualTo<T>(this T t1, T t2)
        {
            return EqualityComparer<T>.Default.Equals(t1, t2);
        }

        /// <summary>
        /// 判断一个泛型对象是否是该类型的默认值
        /// 如果T是class,则是判断空值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsDefault<T>(this T t)
        {
            return EqualityComparer<T>.Default.Equals(t, default(T));
        }

        /// <summary>
        /// 判断两个泛型的集合是否相同
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool SetEqualTo<T>(this IEnumerable<T> t1, IEnumerable<T> t2)
        {
            return (t1.Except(t2).Count() == 0) && (t2.Except(t1).Count() == 0);
        }
        /// <summary>
        /// 比较两个值,o1&gt;o2返回1, o1=o2返回0, o1&lt;o2返回-1
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int CompareValue(object o1, object o2, Type type)
        {
            if (o1 == DBNull.Value && o2 == DBNull.Value) return 0;
            if (o1 == DBNull.Value) return -1;
            if (o2 == DBNull.Value) return 1;

            if (o1 == null && o2 == null) return 0;
            if (o1 == null) return -1;
            if (o2 == null) return 1;

            int result = 0;
            if (type == null)
            {
                double d1, d2;
                if (Double.TryParse(o1.ToString(), out d1)
                    && Double.TryParse(o2.ToString(), out d2))
                {
                    return Math.Sign(d1 - d2);
                }
                else
                {
                    return String.Compare(ToStr(o1).PadLeft(20), ToStr(o2).PadLeft(20));
                }
            }
            switch (type.Name)
            {
                case "Int":
                case "Int32":
                case "Int64":
                case "Decimal":
                case "Short":
                case "Byte":
                    result = Decimal.Compare((decimal)o1, (decimal)o2);
                    break;
                case "Float":
                case "Double":
                    if ((Double)o1 > (Double)o2) { result = 1; break; }
                    if ((Double)o1 == (Double)o2) { result = 0; break; }
                    result = -1;
                    break;
                case "DateTime":
                    DateTime d1 = DateTime.MinValue;
                    DateTime d2 = DateTime.MinValue;
                    DateTime.TryParse(o1.ToString(), out d1);
                    DateTime.TryParse(o2.ToString(), out d2);
                    result = DateTime.Compare(d1, d2);
                    break;
                case "Boolean":
                    String i1 = "a", i2 = "a";
                    if ((Boolean)o1) i1 = "b";
                    if ((Boolean)o1) i2 = "b";
                    result = String.Compare(i1, i2);
                    break;
                default:
                    result = System.String.Compare(o1.ToString(), o2.ToString());
                    break;
            }
            return result;
        }

        #endregion

        public static TimeSpan ToTimeSpan(object p)
        {
            TimeSpan ts = default(TimeSpan);
            TimeSpan.TryParse(CommOp.ToStr(p), out ts);
            return ts;
        }

        #region 类型比较
        /// <summary>
        /// 判断一个类型的对象是否可以转换为某个接口或父类
        /// </summary>
        /// <typeparam name="T">某个类型</typeparam>
        /// <typeparam name="I">接口或父类的类型</typeparam>
        /// <returns></returns>
        public static bool CanConvertTo<T, I>()
        {
            return typeof(I).IsAssignableFrom(typeof(T));
        }

        /// <summary>
        /// 判断类型是否为可为空类型
        /// </summary>
        /// <param name="theType"></param>
        /// <returns></returns>
        public static bool IsNullableType(this Type theType)
        {
            return (theType.IsGenericType && theType.
              GetGenericTypeDefinition().Equals
              (typeof(Nullable<>)));
        }
        #endregion

        public static T DeepClone<T>(T t)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, t);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}