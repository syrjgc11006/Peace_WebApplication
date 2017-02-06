using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.Compilation;
using System.Reflection.Emit;

namespace Peace.Com.Tools
{
    /// <summary>
    /// 关于反射的帮助类
    /// </summary>
    public static class RefHelper
    {
        #region 对象的属性操作
        static readonly BindingFlags bindAttr = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
        const char SPILTER = ','; //在保存字符中数组时用的分隔符

        static Dictionary<Type, IPraseable> PraserDict = new Dictionary<Type, IPraseable>
        {
          {  typeof(Point), new PointPraser()},
          {typeof(Size), new SizePraser()}
        };

        /// <summary>
        /// 注册解析类，用于从字符串解析成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="praser">解析对象，实现了<see cref="IPraseable"/>的接口</param>
        public static void RegisterPraser<T>(IPraseable praser)
        {
            PraserDict[typeof(T)] = praser;
        }

        /// <summary>
        /// 反射获取用'.'号隔开的对象路径中的对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyPathName">'.'号分隔的对象路径</param>
        /// <returns>反射获取的对象</returns>
        static object GetPathProperty(object obj, string propertyPathName)
        {
            string[] propertyNames = propertyPathName.Split('.');
            foreach (string p in propertyNames.Take(propertyNames.Length - 1))
            {
                FieldInfo fi = obj.GetType().GetField(p, bindAttr);
                if (fi != null)
                {
                    obj = fi.GetValue(obj);
                }
                else
                {
                    PropertyInfo pi = GetPropertyInfo(obj, p);
                    if (pi == null) return null;
                    obj = pi.GetValue(obj, null);
                }
            }
            return obj;
        }

        /// <summary>
        /// 获取对象的一个嵌套的属性或字段值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyPathName">用.号分隔的名称</param>
        /// <returns>获取的值</returns>
        public static object GetPathValue(object obj, string propertyPathName)
        {
            var obj1 = GetPathProperty(obj, propertyPathName);
            return GetValue(obj1, propertyPathName.Split('.').Last());
        }

        /// <summary>
        /// 设置对象的一个嵌套的属性或字段值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyPathName">用.号分隔的名称</param>
        /// <param name="value">要设置的值</param>
        public static void SetPathValue(object obj, string propertyPathName, string value)
        {
            var obj1 = GetPathProperty(obj, propertyPathName);
            SetValue(obj1, propertyPathName.Split('.').Last(), value);
        }

        /// <summary>
        /// 获取对象的属性信息
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo(Object obj, string propertyName)
        {
            if (obj == null) return null;
            PropertyInfo[] pis = obj.GetType().GetProperties(bindAttr);
            PropertyInfo pi = pis.FirstOrDefault(pi1 => pi1.Name == propertyName);
            if (pi == null) return null;
            return pi;
        }

        /// <summary>
        /// 获取对象的字段信息
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="fieldName">字段名</param>
        /// <returns>字段</returns>
        public static FieldInfo GetFieldInfo(Object obj, string fieldName)
        {
            if (obj == null) return null;
            FieldInfo[] pis = obj.GetType().GetFields(bindAttr);
            FieldInfo fi = pis.FirstOrDefault(fi1 => fi1.Name == fieldName);
            if (fi == null) return null;
            return fi;
        }

        /// <summary>
        /// 将value中的值赋给对象的属性或字段
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propName">属性名</param>
        /// <param name="value">值</param>
        public static void SetValue(object obj, string propName, string value, Type actualType = null)
        {
            //if (String.IsNullOrEmpty(value)) return;
            FieldInfo fi = obj.GetType().GetField(propName, bindAttr);

            if (fi != null)
            {
                SetFieldValue(obj, fi, value, actualType);
                return;
            }
            PropertyInfo pi = GetPropertyInfo(obj, propName);
            if (pi == null) return;
            if (!pi.CanWrite) return;
            if (PraserDict.ContainsKey(pi.PropertyType))
            {
                var pvalue = PraserDict[pi.PropertyType].Prase(value);
                if (pvalue == null) return;
                pi.SetValue(obj, pvalue, null);
                return;
            }
            if (pi.PropertyType == typeof(string) || pi.PropertyType == typeof(object))
            {
                pi.SetValue(obj, value, null);
            }
            else if (pi.PropertyType == typeof(int))
            {
                pi.SetValue(obj, CommOp.ToInt(value), null);
            }
            else if (pi.PropertyType == typeof(Int64))
            {
                pi.SetValue(obj, CommOp.ToLong(value), null);
            }
            else if (pi.PropertyType == typeof(Int16))
            {
                pi.SetValue(obj, (short)CommOp.ToInt(value), null);
            }
            else if (pi.PropertyType == typeof(int?))
            {
                pi.SetValue(obj, CommOp.ToIntNull(value), null);
            }
            else if (pi.PropertyType == typeof(bool))
            {
                pi.SetValue(obj, CommOp.ToBool(value), null);
            }
            else if (pi.PropertyType == typeof(char))
            {
                pi.SetValue(obj, CommOp.ToChar(value), null);
            }
            else if (pi.PropertyType == typeof(double) || pi.PropertyType == typeof(float))
            {
                pi.SetValue(obj, CommOp.ToDouble(value), null);
            }
            else if (pi.PropertyType == typeof(decimal))
            {
                pi.SetValue(obj, CommOp.ToDecimal(value), null);
            }
            else if (pi.PropertyType.IsEnum)
            {
                if (CommOp.IsNumeric(value))
                {
                    var val = CommOp.ToInt(value);
                    if (pi.PropertyType.IsEnumDefined(val))
                        pi.SetValue(obj, Enum.Parse(pi.PropertyType, val.ToString()), null);
                }
                else
                {
                    var val = CommOp.ToStr(value);
                    if (pi.PropertyType.IsEnumDefined(val))
                        pi.SetValue(obj, Enum.Parse(pi.PropertyType, val), null);
                }
            }
            else if (pi.PropertyType == typeof(DateTime))
            {
                DateTime dt = CommOp.ToDateTime(value);
                if (dt == default(DateTime)) return;
                pi.SetValue(obj, dt, null);
            }
            else if (pi.PropertyType == typeof(DateTime?))
            {
                DateTime? dt = CommOp.ToDateTimeNull(value);
                pi.SetValue(obj, dt, null);
            }
            else
            {
                actualType = actualType ?? pi.PropertyType;
                var p = JsonHelper.FormJson(value, actualType) ?? Activator.CreateInstance(actualType);
                try
                {
                    pi.SetValue(obj, p, null);
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 更新对象中字段的值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="fi">字段信息</param>
        /// <param name="value">值</param>
        /// <returns>转换成功与否</returns>
        static void SetFieldValue(object obj, FieldInfo fi, string value, Type actualType = null)
        {
            if (fi == null) return;
            if (String.IsNullOrEmpty(value)) return;
            if (PraserDict.ContainsKey(fi.FieldType))
            {
                var pvalue = PraserDict[fi.FieldType].Prase(value);
                if (pvalue == null) return;
                fi.SetValue(obj, pvalue);
                return;
            }
            if (fi.FieldType == typeof(string) || fi.FieldType == typeof(object)) //字段类型为String
            {
                fi.SetValue(obj, value);
            }
            else if (fi.FieldType == typeof(int) || fi.FieldType == typeof(Int64) || fi.FieldType == typeof(Int16))
            {
                fi.SetValue(obj, CommOp.ToLong(value));
            }
            else if (fi.FieldType == typeof(bool))
            {
                fi.SetValue(obj, CommOp.ToBool(value));
            }
            else if (fi.FieldType == typeof(double) || fi.FieldType == typeof(float))
            {
                fi.SetValue(obj, CommOp.ToDouble(value));
            }
            else if (fi.FieldType == typeof(decimal))
            {
                fi.SetValue(obj, CommOp.ToDecimal(value));
            }
            else if (fi.FieldType.IsEnum)
            {
                if (fi.FieldType.IsEnumDefined(value ?? ""))
                    fi.SetValue(obj, Enum.Parse(fi.FieldType, value));
            }
            else
            {
                actualType = actualType ?? fi.FieldType;
                var p = JsonHelper.FormJson(value, actualType) ?? Activator.CreateInstance(actualType);
                fi.SetValue(obj, p);
            }
        }

        /// <summary>
        /// 获取对象的public属性值或字段值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="propName">属性名</param>
        /// <returns>值</returns>
        public static object GetValue(object obj, string propName)
        {
            PropertyInfo pi = GetPropertyInfo(obj, propName);

            if (pi == null)
            {
                return GetFieldValue(obj, propName);
            }
            obj = pi.GetValue(obj, null);
            return obj;
        }

        static object GetFieldValue(object obj, string propName)
        {
            FieldInfo fi = GetFieldInfo(obj, propName);
            if (fi == null) return null;
            return fi.GetValue(obj);
        }

        #endregion

        #region 程序集和类
        /// <summary>
        /// 通过反射生成指定类型对象
        /// </summary>
        /// <param name="fullClassName">类型全称</param>
        /// <returns>对象</returns>
        public static object LoadClass(string fullClassName)
        {
            Type type = LoadType(fullClassName);
            return Activator.CreateInstance(type);
        }

        /// <summary>
        /// 带参数反射生成对象
        /// </summary>
        /// <param name="fullClassName">类的完全限定名</param>
        /// <param name="param">构造函数参数</param>
        /// <returns>对象</returns>
        public static object LoadClass(string fullClassName, string param)
        {
            var ass = LoadAssembly(fullClassName);
            if (ass == null) return null;
            return ass.CreateInstance(fullClassName, false, BindingFlags.Default, null, new object[] { param }, null, null);
        }

        /// <summary>
        /// 根据类名加载所在程序集，类名必须是完全限定名
        /// </summary>
        /// <param name="fullClassName">类型的全称</param>
        /// <returns>程序集</returns>
        public static Assembly LoadAssembly(string fullClassName)
        {
            string[] names = fullClassName.Split(new char[] { ',' }, 2);

            Assembly ass = null;
            if (names.Length == 1)
            {
                int i = fullClassName.LastIndexOf('.');
                string path = fullClassName.Substring(0, i);
                ass = Assembly.Load(path);
            }
            else if (names.Length >= 2)
            {
                fullClassName = names[0];
                ass = Assembly.Load(names[1]);
            }
            return ass;
        }

        /// <summary>
        /// 加载指定类型
        /// </summary>
        /// <param name="fullClassName">类型的全称</param>
        /// <returns>指定类型的Type</returns>
        public static Type LoadType(string fullClassName)
        {
            if (fullClassName.IsEmpty()) return null;
            if (fullClassName.Contains('['))
            {
                return LoadGenericType(fullClassName);
            }
            Assembly ass = LoadAssembly(fullClassName);
            return ass.GetType(fullClassName.Split(',')[0], true);
            //Object obj = asm.CreateInstance("Reflection4.Calculator", true, BindingFlags.Default, null, parameters, null, null);
        }

        private static Type LoadGenericType(string fullClassName)
        {
            int idx = fullClassName.LastIndexOf(',');
            Assembly ass = Assembly.Load(fullClassName.Split(',').Last());
            return ass.GetType(fullClassName.Remove(idx), true);
        }
        #endregion

        /// <summary>
        /// 通过反射直接调用对象指定名称的方法，方法可以为非public, 但不是static
        /// </summary>
        /// <param name="obj">定义了此方法的对象</param>
        /// <param name="methodName">方法名称</param>
        /// <param name="p">参数列表</param>
        /// <returns>方法执行后的返回值</returns>
        public static object CallMethod(object obj, string methodName, params object[] p)
        {
            MethodInfo mi = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod);
            return mi.Invoke(obj, p);
        }

        /// <summary>
        /// 通过反射直接调用对象指定名称的泛型方法，方法可以为非public, 但不是static
        /// </summary>
        /// <param name="obj">定义了此方法的对象</param>
        /// <param name="methodName">方法名称</param>
        /// <param name="types">泛型类型参数</param>
        /// <param name="p">参数列表</param>
        /// <returns>方法执行后的返回值</returns>
        public static object CallMethod(object obj, string methodName, Type[] types, params object[] p)
        {
            MethodInfo mi = obj.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod);
            mi = mi.MakeGenericMethod(types);
            return mi.Invoke(obj, p);
        }

        const string suffix = "WcfWrapper";


        public static Type GetElementType<T>(IEnumerable<T> data)
        {
            var type = (data.GetType().GetElementType()) ??
           (data.GetType()
                 .GetGenericArguments()
                 .FirstOrDefault(t => typeof(T).IsAssignableFrom(t))
                 ?? ((data.Count() == 0) ? typeof(T) : data.FirstOrDefault().GetType()));
            return type;
        }
    }

    public interface IPraseable
    {
        object Prase(string tStr);
    }

    public class PointPraser : IPraseable
    {
        /// <summary>
        /// 分析字符串，返回Point
        /// </summary>
        /// <param name="tStr"></param>
        /// <returns></returns>
        public object Prase(string tStr)
        {
            Regex ex = new Regex("X=(-?\\d+),\\s*Y=(-?\\d+)");
            var match = ex.Matches(tStr);
            if (match == null || match.Count == 0 || match[0].Groups.Count < 3) return null;
            int x = int.Parse(match[0].Groups[1].Value);
            int y = int.Parse(match[0].Groups[2].Value);

            return new Point(x, y);
        }

    }

    public class SizePraser : IPraseable
    {
        /// <summary>
        /// 分析字符串，返回Size
        /// </summary>
        /// <param name="tStr"></param>
        /// <returns></returns>
        public object Prase(string tStr)
        {
            Regex ex = new Regex("Width=(-?\\d+),\\s*Height=(-?\\d+)");
            var match = ex.Matches(tStr);
            if (match == null || match.Count == 0 || match[0].Groups.Count < 3) return null;
            int w = int.Parse(match[0].Groups[1].Value);
            int h = int.Parse(match[0].Groups[2].Value);

            return new Size(w, h);
        }
    }
}
