using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebUI.Helper
{
    public static class DescriptionHelper
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