using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Security;

namespace SNRTVU.EMS.Infrastructure.Authentication
{
    public class HashEncrypt
    {
        /// <summary>
        /// 加密字符串文本
        /// </summary>
        /// <param name="plaintext">要加密的字符串</param>
        /// <param name="passwordFormat">加密方式</param>
        /// <returns></returns>
        public static string EncryptText(string plaintext, FormsAuthPasswordFormat passwordFormat)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(plaintext, passwordFormat.ToString());
        }


        /// <summary>
        /// 根据MD5加密字符串文本
        /// </summary>
        /// <param name="plaintext">要加密的字符串</param>
        /// <returns></returns>
        public static string MD5EncryptText(string plaintext)
        {
            return EncryptText(plaintext, FormsAuthPasswordFormat.MD5);
        }
    }
}
