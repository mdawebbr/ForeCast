using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace GREM.API.Util
{
    public static class FileSaver
    {
        public static string Save(System.Web.HttpPostedFile file, string fileName)
        {
            if (file == null)
                return string.Empty;

            fileName = fileName.Replace(":", "_").Trim() + ".png";
            file.SaveAs($"{ConfigurationManager.AppSettings["checklistImgPath"]}\\{fileName}");
            return string.Format("{0}\\{1}", ConfigurationManager.AppSettings["checklistImgPath"], fileName);
        }
    }
}