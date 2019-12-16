using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Security.Claims;

namespace Users.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "identity-claim-type")]
    public class ClaimTypeDescription : TagHelper
    {
        [HtmlAttributeName("identity-claim-type")]
        public string ClaimType { get; set; }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            FieldInfo[] fields = typeof(ClaimTypes).GetFields();
            string claimTypeDescription = (from f in fields where f.GetValue(null).ToString() == ClaimType select f).FirstOrDefault()?.Name;
            if (claimTypeDescription != null)
            {
                output.Content.SetContent(claimTypeDescription);
            }
            else
            {
                output.Content.SetContent(ClaimType.Split('/', '.').Last());
            }
           
            return Task.CompletedTask;
        }
    }
}
