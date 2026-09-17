using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class FileUploadModel : BaseUploadModel
    {
        public void OnGet()
        {

        }


        
        
        public IActionResult OnPostBtnSubmit_Click(IFormFile filePhoto, IFormCollection values)
        {
            if (filePhoto != null)
            {
                string originalName = filePhoto.FileName;

                // 校验：扩展名白名单 + 文件大小
                if (!ValidateUploadFile(filePhoto, out string error))
                {
                    // 清空上传控件（清空上传控件，否则提交表单时会再次上传！）
                    UIHelper.FileUpload("filePhoto").Reset();

                    ShowNotify(error);
                }
                else
                {
                    // 保存到 wwwroot 之外的目录，图片地址指向公共下载页（/Home/Download，带 inline=1 内联显示）
                    string savedName = SaveUploadFile(filePhoto);

                    UIHelper.Label("labResult").Text("<p>文件路径：" + HtmlEncode(originalName) + "</p>" +
                        "<p>用户名：" + values["tbxUserName"] + "</p>" +
                        "<p>头像：<br /><img src=\"" + GetImageUrl(savedName) + "\" /></p>");

                    // 清空表单字段（清空上传控件，否则提交表单时会再次上传！）
                    UIHelper.SimpleForm("SimpleForm1").Reset();
                }
            }

            return UIHelper.Result();
        }

    }
}