using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class ToolTipWhenTruncatedModel : BaseModel
    {
        public void OnGet()
        {
            // 直接绑定原始学生数据（本示例演示"仅截断时显示"，用纯文本专业名即可，无需注入 HTML 片段）
            ViewBag.Grid1DataSource = DataSourceUtil.GetDataTable();
        }




    }
}
