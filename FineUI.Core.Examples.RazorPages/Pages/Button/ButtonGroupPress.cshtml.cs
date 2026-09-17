using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace FineUI.Core.Examples.RazorPages.Pages.Button
{
    public class ButtonGroupPressModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostButtonGroup_PressChanged(JObject pressedInfo)
        {
            // 将传入的字符串转换为 JSON 对象
            // 数据样本：{"id":"ButtonGroup5","pressed":["按钮一","按钮二","按钮四"]}
            
            // 生成提示信息
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("分组 {0} 中按下的按钮：", pressedInfo["id"]);
            sb.Append("<ul>");
            foreach (string pressedText in pressedInfo["pressed"])
            {
                sb.AppendFormat("<li>{0}</li>", pressedText);
            }
            sb.Append("</ul>");

            ShowNotify(new RawHtml(sb.ToString()));

            return UIHelper.Result();
        }

    }
}