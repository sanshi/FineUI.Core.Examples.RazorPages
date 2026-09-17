using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class ChangeConfirmFormModel : BaseModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostBtnClosePostBack_Click(IFormCollection values)
        {
            ShowNotify(values);

            // 保存数据后，清空面板内表单字段的改变状态
            UIHelper.SimpleForm("SimpleForm1").ClearDirty();

            return UIHelper.Result();
        }

    }
}