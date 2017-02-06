using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Peace.Com.Tools
{
    /// <remarks>王家新, 2014-08-01, 2014-08-01</remarks>
    /// <summary>
    /// 使用NewtonSoft.Json进行序列化和反序列化的帮助类
    /// </summary>
    public static class JsonHelper
    {
        /// <remarks>王家新, 2014-08-01, 2014-08-01</remarks>
        /// <summary>
        /// 序列化数据为Json数据格式.选择是否使用可读性强的缩进格式
        /// </summary>
        /// <param name="value">被序列化的对象</param>
        /// <param name="indent">是否是可读的缩进格式</param>
        /// <returns>json字符串</returns>
        public static string ToJson(object value, bool indent = true)
        {
            if (value == null) return null;
            Type type = value.GetType();
            Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();
            json.NullValueHandling = NullValueHandling.Ignore;
            json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
            json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonTextWriter writer = new JsonTextWriter(sw);
            writer.Formatting = indent ? Formatting.Indented : Formatting.None;// Formatting.Indented;
            if (indent)
            {
                IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
                timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                json.Converters.Add(timeFormat);
            }
            else
            {
                IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();

                //var timeFormat = new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter();
                json.Converters.Add(timeFormat);
            }
            writer.QuoteChar = '"';
            json.Serialize(writer, value);

            string output = sw.ToString();
            writer.Close();
            return output;
        }

        /// <summary>
        /// 反序列化json字符串得到相应的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns>反序列化得到的对象，如果json是空串，则返回T的默认值</returns>
        public static T FromJson<T>(string json)
        {
            if (String.IsNullOrEmpty(json)) return default(T);
            T t = JsonConvert.DeserializeObject<T>(json);
            return t;
        }

        /// <summary>
        /// 反序列化json字符串得到相应的对象
        /// </summary>
        /// <param name="json">json字符串</param>
        /// <param name="t">对象类型</param>
        /// <returns>反序列化得到的对象，如果json是空串，则返回则返回t的默认值</returns>
        public static object FormJson(string json, Type t)
        {
            if (String.IsNullOrEmpty(json)) return null;
            object obj = JsonConvert.DeserializeObject(json, t);
            return obj;
        }

        /// <summary>
        /// 反序列化得到一个由Hashtable组成的ArrayList对象(当字符串是一个json的对象数组时)，或一个Hashtable对象(当字符串是单个json对象时），
        /// 或一个日期（当字符串是一个日期时），取决于输入的Json字符串的特征。
        /// </summary>
        /// <param name="json">输入的Json字符串</param>
        /// <returns>反序列化后得到的对象</returns>
        public static object FormJson(string json)
        {
            if (String.IsNullOrEmpty(json)) return "";
            object o = JsonConvert.DeserializeObject(json);
            if (o.GetType() == typeof(String) || o.GetType() == typeof(string))
            {
                o = JsonConvert.DeserializeObject(o.ToString());
            }
            object v = ToObject(o);
            return v;
        }

        private static object ToObject(object o)
        {
            if (o == null) return null;

            if (o.GetType() == typeof(string))
            {
                //判断是否符合2010-09-02T10:00:00的格式
                string s = o.ToString();
                if (s.Length == 19 && s[10] == 'T' && s[4] == '-' && s[13] == ':')
                {
                    o = System.Convert.ToDateTime(o);
                }
            }
            else if (o is JObject)
            {
                JObject jo = o as JObject;

                Hashtable h = new Hashtable();

                foreach (KeyValuePair<string, JToken> entry in jo)
                {
                    h[entry.Key] = ToObject(entry.Value);
                }

                o = h;
            }
            else if (o is IList)
            {

                ArrayList list = new ArrayList();
                list.AddRange((o as IList));
                int i = 0, l = list.Count;
                for (; i < l; i++)
                {
                    list[i] = ToObject(list[i]);
                }
                o = list;

            }
            else if (typeof(JValue) == o.GetType())
            {
                JValue v = (JValue)o;
                o = ToObject(v.Value);
            }
            else
            {
            }
            return o;
        }

    }
}