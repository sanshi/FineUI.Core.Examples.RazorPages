using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class FileUploadDragDropAutoModel : UploadPageBase
    {
        public IActionResult OnPostFilePhotos_FileSelected(List<IFormFile> filePhotos)
        {
            var files = filePhotos;
            // 先校验整批。例如第二张图片超过 2 MB 时保留两张图片，让用户重新选择。
            foreach (var file in files)
            {
                if (!ValidateUploadFile(file, out string error))
                {
                    UIHelper.FileUpload("filePhotos").MarkInvalid($"{file.FileName}（{error}）");
                    return UIHelper.Result();
                }
            }

            UIHelper.Label("labResult").Text("服务器收到：" + string.Join("、", files.Select(file => file.FileName)));
            UIHelper.FileUpload("filePhotos").Reset();
            return UIHelper.Result();
        }
    }
}
