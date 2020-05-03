using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17bang.Pages.AdInContact
{
    /// <summary>
    /// 1.声明一个自定义的TagHelper：DateTimeTagHelper，在Razor中使用： datetime>@DateTime.Now</datetime
    /// </summary>
    [HtmlTargetElement("datetime", Attributes = INDEX + "," + PATH + "," + ASPONLY + "," + ASPSHOWICON)]
    public class TagHelperHomework :TagHelper
    {
        public const string INDEX = "index";
        public const string PATH = "path";
        public const string ASPONLY = "asp-only";
        public const string ASPSHOWICON = "asp-showicon";



        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "small";

            object pageIndex = context.AllAttributes[INDEX].Value;
            output.Attributes.Remove(context.AllAttributes[INDEX]);

            object path = context.AllAttributes[PATH].Value;
            output.Attributes.Remove(context.AllAttributes[PATH]);

            object aspShowIcon = context.AllAttributes[ASPSHOWICON].Value;
            if (aspShowIcon.ToString() == "true")
            {
                output.Content.AppendHtml("<span class='fa fa-calendar'><span>");
            }

            object aspOnly = context.AllAttributes[ASPONLY].Value;
            if (aspOnly.ToString() == "true")
            {
                output.Content.Append(DateTime.Now.ToString("yyyy年MM月dd日"));
            }
            if (aspOnly.ToString() == "date")
            {
                output.Content.Append(DateTime.Now.ToString("D"));
            }

            output.Attributes.Add("href", $"{path}/page-{pageIndex}");
            base.Process(context, output);
        }
    }
}
