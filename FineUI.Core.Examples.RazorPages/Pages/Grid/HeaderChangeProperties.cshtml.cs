using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.Grid
{
    public class HeaderChangePropertiesModel : PageBase
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostButton1_Click()
        {
            var column = UIHelper.RenderField("Grid1", "EntranceYear");
            column.HeaderText("入学年份（已修改）");
            column.Width(200);
            return UIHelper.Result();
        }

        public IActionResult OnPostButton2_Click()
        {
            var column = UIHelper.RenderField("Grid1", "EntranceYear");
            column.HeaderText("入学年份");
            column.Width(120);
            return UIHelper.Result();
        }

        public IActionResult OnPostButton3_Click()
        {
            // 原生模式不自动恢复服务器列对象，本次只更新提示，让浏览器继续保留当前列设置。
            UIHelper.Label("LabelResult").Text("再次回发完成，列设置和已有数据保持不变。");
            return UIHelper.Result();
        }
    }
}
