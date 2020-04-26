using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace _17bang.Pages.Extension
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T status)
        {
            Type enumType = typeof(T);
            FieldInfo enumFieldInfo = enumType.GetField(status.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)
                DescriptionAttribute.GetCustomAttribute(enumFieldInfo, typeof(DescriptionAttribute));

            return attribute.Description;
        }
    }
}
