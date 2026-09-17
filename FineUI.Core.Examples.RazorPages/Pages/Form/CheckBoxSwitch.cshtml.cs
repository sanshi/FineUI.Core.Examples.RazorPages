using Microsoft.AspNetCore.Mvc;
using System;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class CheckBoxSwitchModel : BaseModel
    {
        public void OnGet()
        {
            ViewBag.CheckBox5SwitchOnText = "<i class=\"f-icon f-iconfont f-iconfont-check\"></i>";
            ViewBag.CheckBox5SwitchOffText = "<i class=\"f-icon f-iconfont f-iconfont-close\"></i>";
        }



        public IActionResult OnPostBtnSelectCheckBox_Click(bool isChecked)
        {
            UIHelper.CheckBox("CheckBox1").Checked(!isChecked);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnDisableCheckBox_Click(bool isDisabled)
        {
            UIHelper.CheckBox("CheckBox1").Disabled(!isDisabled);

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnChangeText_Click()
        {
            UIHelper.CheckBox("CheckBox1").Text(String.Format("复选框（{0}）", DateTime.Now.ToLongTimeString()));

            return UIHelper.Result();
        }

        public IActionResult OnPostCheckBox2_CheckedChanged(bool isChecked)
        {
            ShowNotify("复选框的状态：" + (isChecked ? "选中" : "未选中"));

            return UIHelper.Result();
        }
    }
}
