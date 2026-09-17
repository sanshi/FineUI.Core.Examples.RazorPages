using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Layout
{
    public class RegionModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton4_Click()
        {
            var panelLeftRegion = UIHelper.Panel("panelLeftRegion");

            string newtitle = String.Format("左侧面板（有提示信息） - 更新时间：{0}", DateTime.Now.ToLongTimeString());
            panelLeftRegion.Title(newtitle);
            panelLeftRegion.TitleToolTip(newtitle);

            return UIHelper.Result();
        }


        public IActionResult OnPostBtnHideBottomRegion_Click(bool hidden)
        {
            var panelBottomRegion = UIHelper.Panel("panelBottomRegion");

            panelBottomRegion.Hidden(!hidden);

            return UIHelper.Result();
        }

    }
}