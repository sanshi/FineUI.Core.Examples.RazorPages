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
    public class FileUploadToolModel : BaseUploadModel
    {
        public void OnGet()
        {

        }


        

        public IActionResult OnPostFilePhoto_FileSelected(IFormFile filePhoto, IFormCollection values)
        {
            if (filePhoto != null)
            {
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
                    UIHelper.Image("imgPhoto").ImageUrl(GetImageUrl(savedName));

                    // 清空上传控件（清空上传控件，否则提交表单时会再次上传！）
                    UIHelper.FileUpload("filePhoto").Reset();
                }
            }

            return UIHelper.Result();
        }

        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            var filePhoto = UIHelper.FileUpload("filePhoto");

            var imgPhotoUrl = values["imgPhotoUrl"].ToString();

            if (imgPhotoUrl.EndsWith("blank.png"))
            {
                filePhoto.MarkInvalid("请先上传个人头像！");
                ShowNotify("请先上传个人头像！");
            }
            else
            {
                UIHelper.Label("labResult").Text("用户名：" + values["tbxUserName"] + "<br/>" +
                        "邮箱：" + values["tbxEmail"] + "<br/>" +
                        "<p>头像：<br /><img src=\"" + imgPhotoUrl + "\" /></p>");

                // 清空表单字段（清空上传控件，否则提交表单时会再次上传！）
                UIHelper.Image("imgPhoto").ImageUrl(Url.Content("~/res/images/blank.png"));
                filePhoto.Reset();
                UIHelper.TextBox("tbxEmail").Reset();
                UIHelper.TextBox("tbxUserName").Reset();
            }

            return UIHelper.Result();
        }

    }
}