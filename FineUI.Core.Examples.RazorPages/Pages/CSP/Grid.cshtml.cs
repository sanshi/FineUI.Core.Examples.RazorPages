using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.CSP
{
    public class GridModel : BaseModel
    {
        public void OnGet()
        {
            // 全局已开启严格 CSP；只有本页的外部脚本来源需要额外放行。
            PageManager.Instance.CspScriptsAllowUrls = new[] { "cdn.jsdelivr.net", "unpkg.com" };
        }


        


    }
}
