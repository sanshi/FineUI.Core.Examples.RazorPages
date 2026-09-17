using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class RadioButtonListImageItemModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();
        }

        private void LoadData()
        {
            // ① DataBind + DataTextRaw：后端预拼 Display（图标 + HtmlEncode(名称)），View 里用 DataTextField+DataTextRaw 绑定
            List<Country> list = new List<Country>();
            foreach (Country c in GetCountries())
            {
                // 只信任图标模板骨架 + 可信 URL；数据字段（名称）经 HtmlEncode 转义
                c.Display = String.Format("<img src=\"{0}\" style=\"vertical-align:middle;\" />&nbsp;{1}",
                    Url.Content("~/res/icon/flag_" + c.Code + ".png"), HttpUtility.HtmlEncode(c.Name));
                list.Add(c);
            }
            ViewBag.RadioButtonList1Source = list;

            // ② 手工构建 Items：RadioItem[]，用 TextRawHtml（图标模板可信 + 名称 HtmlEncode 转义）
            List<RadioItem> items = new List<RadioItem>();
            foreach (Country c in GetCountries())
            {
                items.Add(new RadioItem
                {
                    Value = c.Code,
                    TextRawHtml = new RawHtml("<img src=\"{0}\" style=\"vertical-align:middle;\" />&nbsp;{1}",
                        Url.Content("~/res/icon/flag_" + c.Code + ".png"),
                        HttpUtility.HtmlEncode(c.Name))
                });
            }
            ViewBag.RadioButtonList2Items = items.ToArray();
        }

        // 示例用国家数据（Code 为国家代码，对应 ~/res/icon/flag_{code}.png；Name 为显示名称）
        private List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country("cn", "中国"),
                new Country("us", "美国"),
                new Country("ru", "俄罗斯"),
                new Country("de", "德国")
            };
        }

        #region Country

        public class Country
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Display { get; set; }

            public Country(string code, string name)
            {
                Code = code;
                Name = name;
            }
        }

        #endregion

        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            ShowNotify(values);

            return UIHelper.Result();
        }

    }
}
