using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.Other
{
    public class ServerErrorCustomTimeoutModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostButton5_Click()
        {
            // 故意延迟5秒，以便客户端AJAX请求超时
            System.Threading.Thread.Sleep(5000);

            throw new Exception("服务器异常错误！");
        }

    }
}