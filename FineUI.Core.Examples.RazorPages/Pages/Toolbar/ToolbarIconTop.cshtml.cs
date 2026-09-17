using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Toolbar
{
    public class ToolbarIconTopModel : BaseUploadModel
    {
        public void OnGet()
        {

        }


        
        public IActionResult OnPostFilePhoto_FileSelected(IFormFile filePhoto)
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

    }
}