using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using Newtonsoft.Json.Linq;


namespace FineUI.Core.Examples.RazorPages.Pages.GridOther
{
    public class MultiActionsColumnModel : BaseModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostWindow1_Close()
        {
            Alert.Show("触发了窗体的关闭事件！");

            return UIHelper.Result();
        }

        public IActionResult OnPostGrid1_CustomDelete(int rowIndex, string rowId, string rowText)
        {
            ShowNotify(String.Format("你点击了第 {0} 行的删除按钮，行ID：{1}，姓名：{2}", rowIndex + 1, rowId, rowText));

            return UIHelper.Result();
        }

        public IActionResult OnPostGrid1_CustomEdit(int rowIndex, string rowId, string rowText)
        {
            ShowNotify(String.Format("你点击了第 {0} 行的编辑按钮，行ID：{1}，姓名：{2}", rowIndex + 1, rowId, rowText));

            return UIHelper.Result();
        }
        

    }
}