using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.GridDataUrl
{
    public class ChangeDataUrlModel : PageBase
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostBtnReload_Click()
        {
            // 不传地址，沿用页面当前数据源；客户端切换后重载也不会跳回首次地址。
            global::FineUI.Core.PageContext.InvokeFunction("reloadCurrentDataUrl");
            return UIHelper.Result();
        }


        
        public IActionResult OnPostButton2_Click(string Grid1_sourceKey)
        {
            var grid1 = UIHelper.Grid("Grid1");

            if (Grid1_sourceKey == "source1") {
                grid1.Attribute("data-source-key", "source2");
                grid1.DataUrl(Url.Content("~/GridDataUrl/GridDataUrlData?data2=true"));
            } else {
                grid1.Attribute("data-source-key", "source1");
                grid1.DataUrl(Url.Content("~/GridDataUrl/GridDataUrlData"));
            }

            return UIHelper.Result();
        }

    }
}
