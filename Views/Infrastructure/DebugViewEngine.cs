using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Views.Infrastructure
{
    public class DebugViewEngine : IViewEngine
    {
        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            if (viewName != "DebugData")
                return ViewEngineResult.NotFound(viewName, new string[] { "Find View method" });

            return ViewEngineResult.Found(viewName, new DebugDataView());
        }

        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            return ViewEngineResult.NotFound(viewPath, new string[] { "Get View method" });
        }
    }
}
