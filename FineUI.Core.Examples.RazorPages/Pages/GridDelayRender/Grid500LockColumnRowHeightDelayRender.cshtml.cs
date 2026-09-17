using System;
using System.Data;


namespace FineUI.Core.Examples.RazorPages.Pages.GridDelayRender
{
    public class Grid500LockColumnRowHeightDelayRenderModel : BaseModel
    {
        public void OnGet()
        {
            LoadData();


        }



        private void LoadData()
        {
            DataTable table = DataSourceUtil.GetDataTable();

            int newtableID = 101;
            DataTable newtable = table.Clone();
            for (int i = 0; i <= 41; i++)
            {
                foreach (DataRow row in table.Rows)
                {
                    newtable.ImportRow(row);

                    var newImportedRow = newtable.Rows[newtable.Rows.Count - 1];
                    newImportedRow["Id"] = newtableID;
                    if (i > 0)
                    {
                        newImportedRow["Name"] = String.Format("{0}（{1}）", newImportedRow["Name"], i);
                    }

                    newtableID++;
                }
            }

            ViewBag.Grid1DataSource = newtable;
        }



    }
}
