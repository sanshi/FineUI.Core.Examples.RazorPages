using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FineUI.Core.Examples.RazorPages.Pages.Form
{
    public class FileUploadDragDropModel : UploadPageBase
    {
        public IActionResult OnPostBtnSubmit_Click(List<IFormFile> filePhoto, List<IFormFile> filePhotos)
        {
            UIHelper.Label("labPhotoResult").Text("单张图片：" + FormatUploadedFiles(filePhoto));
            UIHelper.Label("labPhotosResult").Text("多张图片：" + FormatUploadedFiles(filePhotos));
            UIHelper.SimpleForm("SimpleForm1").Reset();
            return UIHelper.Result();
        }

        private static string FormatUploadedFiles(IEnumerable<IFormFile> files)
        {
            var results = new List<string>();
            foreach (var file in files)
            {
                results.Add(ValidateUploadFile(file, out string error) ? file.FileName : $"{file.FileName}（{error}）");
            }

            return results.Count == 0 ? "未选择文件" : string.Join("、", results);
        }
    }
}
