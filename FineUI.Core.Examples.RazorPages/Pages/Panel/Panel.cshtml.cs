using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Panel
{
    public class PanelModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.Panel1Content = "可以放置<a href=\" http://www.w3schools.com/html/\" target=\"_blank\">HTML</a>标签。";
        }


        
        public IActionResult OnPostButton2_Click(bool collapsed)
        {
            ShowNotify(String.Format("面板处于{0}状态", collapsed ? "折叠" : "展开"));

            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click(bool collapsed)
        {
            UIHelper.Panel("Panel2").Collapsed(!collapsed);

            return UIHelper.Result();
        }

        public IActionResult OnPostButton4_Click()
        {
            UIHelper.Panel("Panel1").Title(String.Format("面板（{0}）", DateTime.Now.ToLongTimeString()));

            return UIHelper.Result();
        }

        public IActionResult OnPostButton5_Click()
        {
            UIHelper.ToolbarText("ToolbarText1").Text(String.Format("工具条文本一（{0}）", DateTime.Now.ToLongTimeString()));

            return UIHelper.Result();
        }

        public IActionResult OnPostButton6_Click(bool textHidden, bool separatorHidden)
        {
            UIHelper.ToolbarText("ToolbarText1").Hidden(!textHidden);
            UIHelper.ToolbarSeparator("ToolbarSeparator1").Hidden(!separatorHidden);

            return UIHelper.Result();
        }

        public IActionResult OnPostButton7_Click()
        {
            UIHelper.Toolbar("Toolbar1").Hidden(true);

            return UIHelper.Result();
        }


        public IActionResult OnPostButton8_Click()
        {
            UIHelper.Toolbar("Toolbar1").Hidden(false);

            return UIHelper.Result();
        }

        public IActionResult OnPostButton9_Click(string iconFont)
        {
            var panel = UIHelper.Panel("Panel1");

            if (iconFont == "f-iconfont-volume-up")
            {
                panel.IconFont(IconFont._VolumeDown);
            }
            else if (iconFont == "f-iconfont-volume-down")
            {
                panel.IconFont(IconFont._VolumeOff);
            }
            else
            {
                panel.IconFont(IconFont._VolumeUp);
            }

            return UIHelper.Result();
        }

        public IActionResult OnPostButton10_Click()
        {
            UIHelper.Panel("Panel1").IconFont(IconFont.None);

            return UIHelper.Result();
        }

    }
}