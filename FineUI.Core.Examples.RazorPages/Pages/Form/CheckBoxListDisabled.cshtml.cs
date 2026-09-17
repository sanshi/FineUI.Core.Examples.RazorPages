using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class CheckBoxListDisabledModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();
            
        }


        
        // 准备 CheckBoxList2 用到的数据
        private void LoadData()
        {
            List<TestClass> myList = new List<TestClass>();
            myList.Add(new TestClass("item1", "数据绑定值 1", false));
            myList.Add(new TestClass("item2", "数据绑定值 2", false));
            myList.Add(new TestClass("item3", "数据绑定值 3", true));
            myList.Add(new TestClass("item4", "数据绑定值 4", true));

            ViewBag.CheckBoxList2DataSource = myList;
            ViewBag.CheckBoxList2SelectedValueArray = new string[] { "item1", "item3" };
        }

        #region TestClass

        public class TestClass
        {
            private string _id;

            public string Id
            {
                get { return _id; }
                set { _id = value; }
            }
            private string _name;

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            private bool _enabled;
            public bool Enabled
            {
                get { return _enabled; }
                set { _enabled = value; }
            }

            public TestClass(string id, string name, bool enabled)
            {
                _id = id;
                _name = name;
                _enabled = enabled;
            }

        }

        #endregion


        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            ShowNotify(values);

            return UIHelper.Result();
        }

        public IActionResult OnPostCheckBoxList3_SelectedIndexChanged(string[] selected)
        {
            ShowNotify(String.Format("列表三的选中项：{0}", String.Join(", ", selected)));

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnServerSetSelectedValue_Click()
        {
            UIHelper.CheckBoxList("CheckBoxList1").SelectedValueArray(new string[] { "value1", "value3" });

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnServerGetSelectedValue_Click(JArray selected)
        {
            if (selected.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("列表一的选中项：");
                sb.Append("<ul>");
                foreach (JObject selectedItem in selected)
                {
                    sb.AppendFormat("<li>{0}（{1}）</li>", selectedItem["label"], selectedItem["value"]);
                }
                sb.Append("</ul>");
                ShowNotify(new RawHtml(sb.ToString()));
            }
            else
            {
                ShowNotify("列表一没有选中项！");
            }

            return UIHelper.Result();
        }
        
    }
}