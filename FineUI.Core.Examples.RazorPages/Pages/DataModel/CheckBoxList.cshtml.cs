using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FineUI.Core.Examples.RazorPages.Pages.DataModel.Models;

namespace FineUI.Core.Examples.RazorPages.Pages.DataModel
{
    public class CheckBoxListModel : PageBase
    {
        public void OnGet()
        {
            var model = new Models.CheckBoxListModel();
            model.IsChecked = true;
            model.CheckBoxList1 = new string[] { "Value1", "Value3" };
            model.CheckBoxList1Items = new List<CheckItem>
            {
                new CheckItem {
                    Text = "可选项 1",
                    Value = "Value1"
                },
                new CheckItem {
                    Text = "可选项 2",
                    Value = "Value2"
                },
                new CheckItem {
                    Text = "可选项 3",
                    Value = "Value3"
                }
            };

            model.RadioButtonList1 = "Value1";
            model.RadioButton1Items = new List<RadioItem>
            {
                new RadioItem {
                    Text = "可选项 1",
                    Value = "Value1"
                },
                new RadioItem {
                    Text = "可选项 2",
                    Value = "Value2"
                },
                new RadioItem {
                    Text = "可选项 3",
                    Value = "Value3"
                }
            };

            model.Gender = 0;

            model.GenderType = GenderType.Woman;

            TheModel = model;
        }

        [BindProperty]
        public Models.CheckBoxListModel TheModel { get; set; }
        

        public IActionResult OnPostBtnSubmit_Click([FromForm(Name = "TheModel_GenderType_2_text")] string otherGender)
        {
            if (ModelState.IsValid)
            {
                // 独立下拉列表的显示文字由 Name 加 _text 的表单参数读取，不写入表单模型。
                ShowNotify(new RawHtml(
                    "用户提交的数据：<br/><pre>{0}</pre>"
                        + "模型性别：{1}<br/>独立下拉列表 TheModel_GenderType_2：{2}",
                    EncodeJson(TheModel), EncodeJson(TheModel.GenderType), EncodeJson(otherGender)));
            }

            return UIHelper.Result();
        }

    }
}
