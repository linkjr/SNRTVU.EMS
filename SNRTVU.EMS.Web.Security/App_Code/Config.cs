using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SNRTVU.EMS.Web.Security
{
    public class Config
    {
        private readonly static string _siteName = ConfigurationManager.AppSettings["SiteName"];

        /// <summary>
        /// 获取站点名称。
        /// </summary>
        public static string SiteName
        {
            get { return _siteName; }
        }

        #region 浏览器地址下载

        private readonly static string _chromeDownload = ConfigurationManager.AppSettings["ChromeDownload"];
        /// <summary>
        /// 获取Chrome下载地址。
        /// </summary>
        public static string ChromeDownload
        {
            get { return _chromeDownload; }
        }

        private readonly static string _firefoxDownload = ConfigurationManager.AppSettings["FirefoxDownload"];
        /// <summary>
        /// 获取Firefox下载地址。
        /// </summary>
        public static string FirefoxDownload
        {
            get { return _firefoxDownload; }
        }

        #endregion
    }
}