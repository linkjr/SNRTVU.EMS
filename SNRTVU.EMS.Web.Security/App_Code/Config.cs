using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SNRTVU.EMS.Web.Security
{
    public class Config
    {
        private static string _siteName = ConfigurationManager.AppSettings["SiteName"];

        /// <summary>
        /// 获取站点名称。
        /// </summary>
        public static string SiteName
        {
            get { return _siteName; }
        }
    }
}