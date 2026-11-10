using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class FileUploadDragDropModel : UploadPageBase
    {
        public IActionResult OnPostBtnSubmit_Click(List<IFormFile> filePhoto, List<IFormFile> filePhotos)
        {
            var results = new List<string>();
            foreach (var file in filePhoto.Concat(filePhotos))
            {
                results.Add(ValidateUploadFile(file, out string error) ? file.FileName : $"{file.FileName}（{error}）");
            }

            string message = results.Count == 0 ? "请选择图片。" : "服务器收到：" + string.Join("、", results);
            UIHelper.Label("labResult").Text(message);
            UIHelper.SimpleForm("SimpleForm1").Reset();
            return UIHelper.Result();
        }
    }
}
