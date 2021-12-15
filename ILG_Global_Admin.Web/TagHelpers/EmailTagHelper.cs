namespace ILG_Global_Admin.Web.TagHelpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Text;


    [HtmlTargetElement("email", TagStructure = TagStructure.WithoutEndTag)]
    public class EmailTagHelper : TagHelper
    {
        private const string EmailDomain = "contoso.com";

 

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "b";
            output.Content.SetHtmlContent("hii");
        }
    }
}
