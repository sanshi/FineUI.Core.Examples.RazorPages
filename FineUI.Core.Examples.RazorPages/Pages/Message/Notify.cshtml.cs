using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FineUI.Core.Examples.RazorPages.Pages.Message
{
    public class NotifyModel : BaseModel
    {
        public void OnGet()
        {

        }



        public IActionResult OnPostBtnSubmit_Click(IFormCollection values)
        {
            Notify notify = new Notify();
            notify.Message = values["tbxMessage"];

            notify.MessageBoxIcon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), values["ddlMessageBoxIcon"], true);
            notify.Target = (Target)Enum.Parse(typeof(Target), values["ddlTarget"], true);


            if (!String.IsNullOrEmpty(values["nbWidth"]))
            {
                notify.Width = Convert.ToInt32(values["nbWidth"]);
            }

            if (Convert.ToBoolean(values["cbxShowHeader"]))
            {
                notify.ShowHeader = true;

                if (!String.IsNullOrEmpty(values["tbxTitle"]))
                {
                    notify.Title = values["tbxTitle"];
                }

                notify.EnableDrag = Convert.ToBoolean(values["cbxEnableDrag"]);
                notify.EnableClose = Convert.ToBoolean(values["cbxEnableClose"]);
            }
            else
            {
                notify.ShowHeader = false;
            }


            notify.DisplayMilliseconds = Convert.ToInt32(values["nbDisplayMilliseconds"]);
            notify.DisplayProgress = Convert.ToBoolean(values["cbxDisplayProgress"]);

            notify.PositionX = (Position)Enum.Parse(typeof(Position), values["ddlPositionX"], true);
            notify.PositionY = (Position)Enum.Parse(typeof(Position), values["ddlPositionY"], true);

            notify.IsModal = Convert.ToBoolean(values["cbxIsModal"]);

            if (!String.IsNullOrEmpty(values["tbxBodyPadding"]))
            {
                notify.BodyPadding = values["tbxBodyPadding"];
            }

            notify.MessageAlign = (TextAlign)Enum.Parse(typeof(TextAlign), values["ddlMessageAlign"], true);

            if (Convert.ToBoolean(values["cbxShowLoading"]))
            {
                notify.ShowLoading = true;
            }

            if (!String.IsNullOrEmpty(values["nbMinWidth"]))
            {
                notify.MinWidth = Convert.ToInt32(values["nbMinWidth"]);
            }

            if (!String.IsNullOrEmpty(values["nbMaxWidth"]))
            {
                notify.MaxWidth = Convert.ToInt32(values["nbMaxWidth"]);
            }

            if (!String.IsNullOrEmpty(values["tbxID"]))
            {
                notify.ID = values["tbxID"];
            }


            notify.HideScript = "notifyHideCallback();";


            notify.Show();


            return UIHelper.Result();
        }

    }
}
