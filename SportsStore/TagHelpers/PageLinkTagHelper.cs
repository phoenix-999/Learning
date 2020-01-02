using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        public PagingInfo PageModel { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder div = new TagBuilder("div");//Внутренний контейнер для тегов <а>. В тело ответа не будет записан.
            for(int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", urlHelper.Action(PageAction, new { pageNumber = i}));
                if(PageClassesEnabled)
                {
                    a.AddCssClass(PageClass);
                    a.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                a.InnerHtml.Append(i.ToString());
                div.InnerHtml.AppendHtml(a);
            }
            output.Content.AppendHtml(div.InnerHtml);
        }
    }
}
