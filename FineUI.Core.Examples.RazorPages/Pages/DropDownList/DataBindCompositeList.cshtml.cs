using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FineUI.Core.Examples.RazorPages.Pages.DropDownList
{
    public class DataBindCompositeListModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        public class CustomClass
        {
            private string _id;

            public string ID
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

            public CustomClass(string id, string name)
            {
                _id = id;
                _name = name;
            }
        }
        
        private void LoadData()
        {
            List<CustomClass> myList = new List<CustomClass>();
            myList.Add(new CustomClass("1", "可选项1"));
            myList.Add(new CustomClass("2", "可选项2"));
            myList.Add(new CustomClass("3", "可选项3"));
            myList.Add(new CustomClass("4", "可选项4"));
            myList.Add(new CustomClass("5", "可选项5"));
            myList.Add(new CustomClass("6", "可选项6"));
            myList.Add(new CustomClass("7", "可选择项7"));
            myList.Add(new CustomClass("8", "可选择项8"));
            myList.Add(new CustomClass("9", "可选择项9"));

            
            ViewBag.DropDownList1DataSource = myList;

        }

        public IActionResult OnPostBtnGetSelection_Click(string DropDownList1, string DropDownList1_text)
        {
            UIHelper.Label("labResult").Text(String.Format("选中项：{0}（值：{1}）", DropDownList1_text, DropDownList1));

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSelectItem6_Click()
        {
            UIHelper.DropDownList("DropDownList1").SelectedValue("6");

            return UIHelper.Result();
        }


    }
}