using Microsoft.AspNetCore.Mvc;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class ClearSelectionModel : PageBase
    {
        public object[] GridData { get; private set; }

        public void OnGet()
        {
            GridData = new object[]
            {
                new { Id = "a", Name = "甲" },
                new { Id = "b", Name = "乙（不可选）" }
            };
        }

        private void ClearAllSelections()
        {
            UIHelper.Grid("Grid1").ClearSelection();
            UIHelper.DropDownBox("DropDownBox1").ClearSelection();
            UIHelper.DropDownList("DropDownList1").ClearSelection();
            UIHelper.DataList("DataList1").ClearSelection();
            UIHelper.Tree("Tree1").ClearSelection();
            UIHelper.CheckBoxList("CheckBoxList1").ClearSelection();
            UIHelper.RadioButtonList("RadioButtonList1").ClearSelection();
        }

        public IActionResult OnPostBtnClearSelection_Click()
        {
            ClearAllSelections();
            UIHelper.Label("labResult").Text("清空动作已发送");
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnClearAndSelect_Click()
        {
            ClearAllSelections();
            UIHelper.Grid("Grid1").SelectedRowIDArray("a");
            UIHelper.DropDownBox("DropDownBox1").Values(new[] { "a" }, new[] { "甲" });
            UIHelper.DropDownList("DropDownList1").SelectedValue("a");
            UIHelper.DataList("DataList1").SelectedValueArray("a");
            UIHelper.Tree("Tree1").SelectedNodeID("a");
            UIHelper.CheckBoxList("CheckBoxList1").SelectedValueArray("a");
            UIHelper.RadioButtonList("RadioButtonList1").SelectedValue("a");
            UIHelper.Label("labResult").Text("重新选择动作已发送");
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnUncheckNodes_Click()
        {
            global::FineUI.Core.PageContext.InvokeFunction("uncheckTreeNodes");
            UIHelper.Label("labResult").Text("取消勾选动作已发送");
            return UIHelper.Result();
        }

        public IActionResult OnPostBtnReadSelection_Click(string selection)
        {
            UIHelper.Label("labResult").Text("当前" + selection);
            return UIHelper.Result();
        }

    }
}
