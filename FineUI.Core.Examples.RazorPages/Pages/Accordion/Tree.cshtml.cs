using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace FineUI.Core.Examples.RazorPages.Pages.Accordion
{
    public class TreeModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }


        
        //// GET: Accordion/Tree/DefaultPage
        //public IActionResult DefaultPage()
        //{
        //    return View();
        //}

        private void LoadData()
        {
            string xmlPath = FineUI.Core.PageContext.MapWebPath("~/res/menu.xml");

            string xmlContent = String.Empty;
            using (StreamReader sr = new StreamReader(xmlPath))
            {
                xmlContent = sr.ReadToEnd();
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlContent);

            ViewBag.Tree1DataSource = xdoc;
        }


    }
}