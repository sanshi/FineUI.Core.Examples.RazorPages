using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace FineUI.Core.Examples.RazorPages.Pages.Mobile.Window
{
    public class PositionShengShiXianModel : MobilePageBase
    {
        public void OnGet()
        {
            LoadData();


        }


        
        private void LoadData()
        {
            List<ListItem> items = new List<ListItem>();
            ListItem item = new ListItem();
            items.Add(new ListItem("选择省份", "-1"));
            foreach (ProvinceCityCountyItem sheng in ProvinceCityCountyData.Provinces)
            {
                item = new ListItem();
                item.Text = sheng.Name;
                item.Value = sheng.Code;
                items.Add(item);
            }

            ViewBag.ShengItems = items.ToArray();
        }


        public IActionResult OnPostDdlSheng_SelectedIndexChanged(IFormCollection values)
        {
            BindShi(values["ddlSheng"]);

            return UIHelper.Result();
        }

        public IActionResult OnPostDdlShi_SelectedIndexChanged(IFormCollection values)
        {
            BindXian(values["ddlShi"]);

            return UIHelper.Result();
        }


        private void BindShi(string sheng)
        {
            var ddlShi = UIHelper.DropDownList("ddlShi");

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("选择地区市", "-1", true));
            if (!String.IsNullOrEmpty(sheng) && sheng != "-1")
            {
                foreach (ProvinceCityCountyItem shi in ProvinceCityCountyData.Cities(sheng))
                {
                    ListItem item = new ListItem();
                    item.Text = shi.Name;
                    item.Value = shi.Code;
                    items.Add(item);
                }
            }
            // 更新前台数据
            ddlShi.LoadData(items.ToArray());

            // 是否禁用
            ddlShi.Enabled(!(ddlShi.Source.Items.Count == 1));

            BindXian("-1");
        }

        private void BindXian(string shi)
        {
            var ddlXian = UIHelper.DropDownList("ddlXian");

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("选择县区市", "-1", true));

            if (!String.IsNullOrEmpty(shi) && shi != "-1")
            {
                foreach (ProvinceCityCountyItem xian in ProvinceCityCountyData.Counties(shi))
                {
                    ListItem item = new ListItem();
                    item.Text = xian.Name;
                    item.Value = xian.Code;
                    items.Add(item);
                }
            }
            // 更新前台数据
            ddlXian.LoadData(items.ToArray());

            // 是否禁用
            ddlXian.Enabled(!(ddlXian.Source.Items.Count == 1));

        }

        public IActionResult OnPostButton1_Click(IFormCollection values)
        {
            string sheng = values["ddlSheng"];
            string shi = values["ddlShi"];
            string xian = values["ddlXian"];

            // 隐藏窗体
            UIHelper.Window("Window1").Hidden(true);

            // 弹出选中的值
            ShowNotify("您选择的省市县：" + ProvinceCityCountyData.ProvinceName(sheng) + " | " + ProvinceCityCountyData.CityName(shi) + (xian == "-1" ? "" : " | " + ProvinceCityCountyData.CountyName(xian)));
            
            return UIHelper.Result();
        }

    }
}