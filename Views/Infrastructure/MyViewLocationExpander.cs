using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Views.Infrastructure
{
    public class MyViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //Категоризация не требуеться
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (var l in viewLocations)
                yield return l;

            string action = (string)context.ActionContext.RouteData.Values["action"];
            yield return $"/Views/Common/{action}/PartialView.cshtml";
            
        }

    }
}
