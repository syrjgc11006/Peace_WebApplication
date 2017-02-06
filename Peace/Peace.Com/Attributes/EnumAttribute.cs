using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Peace.Com.Attributes
{
    /// <summary>
    /// 获取实体类Attribute自定义属性
    /// </summary>
    public class EnumAttribute
    {
        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项。</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetEnumnDescription(Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 返回枚举项的名称。
        /// </summary>
        /// <param name="value">要获取描述信息的枚举项</param>
        /// <returns>枚举项的名称</returns>
        public static string GetEnumnName(Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                return name;
            }
            return null;
        }
        //TODO：枚举转值，方法很简单，这里不赘述（枚举只代表整数）
        /**
         *   int enumValueOne = color.GetHashCode();  
         *   int enumValueTwo = (int)color;  
         *   int enumValueThree = Convert.ToInt32(color);  
         */

    }
}
