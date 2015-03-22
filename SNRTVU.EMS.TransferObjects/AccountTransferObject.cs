using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SNRTVU.EMS.TransferObjects
{
    [DataContract]
    public class AccountTransferObject
    {
        /// <summary>
        /// 获取或设置用户ID。
        /// </summary>
        [DataMember]
        public Guid ID { get; set; }

        [Display(Name = "账号")]
        [DataMember]
        public string Account { get; set; }

        [Display(Name = "密码")]
        [DataMember]
        public string Password { get; set; }

        [Display(Name = "身份证号码")]
        public string Identification { get; set; }

        [Display(Name = "姓名")]
        public string Name { get; set; }

        [Display(Name = "电话")]
        [DataMember]
        public string Phone { get; set; }

        [Display(Name = "省份")]
        public string Province { get; set; }

        [Display(Name = "城市")]
        public string City { get; set; }

        [Display(Name = "区/县")]
        public string District { get; set; }

        [Display(Name = "详细地址")]
        public string Address { get; set; }

        [Display(Name = "邮寄课本")]
        public bool? IsByPost { get; set; }

        /// <summary>
        /// 获取或设置新闻创建日期。
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }

        [Display(Name = "详细地址")]
        public string FullAddress
        {
            get
            {
                return this.Province + this.City + this.District + this.Address;
            }
        }
    }

    [DataContract]
    public class LoginTransferObject
    {
        /// <summary>
        /// 获取或设置账户。
        /// </summary>
        [Display(Name = "账号")]
        [Required(ErrorMessage = "{0}不能为空。")]
        [StringLength(50, ErrorMessage = "{0} 长度不能超过{1}。")]
        [DataMember]
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置密码。
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}不能为空。")]
        [StringLength(100, ErrorMessage = "{0} 长度不能超过{1}。")]
        [DataMember]
        public string Password { get; set; }
    }

    [DataContract]
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "{0}不能为空。")]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "{0}不能为空。")]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }

    public class ModifyProfileViewModel
    {
        [Required(ErrorMessage = "{0}不能为空。")]
        [Display(Name = "登录账号")]
        public string Account { get; set; }
    }

    [DataContract]
    public class ContactTransferObject
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "联系电话")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "请选择{0}")]
        [Display(Name = "省份")]
        public string Province { get; set; }

        [Required(ErrorMessage = "请选择{0}")]
        [Display(Name = "城市")]
        public string City { get; set; }

        [Required(ErrorMessage = "请选择{0}")]
        [Display(Name = "区/县")]
        public string District { get; set; }

        [Required(ErrorMessage = "{0}必填")]
        [Display(Name = "详细地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0}必选")]
        [Display(Name = "是否邮寄课本")]
        public bool IsByPost { get; set; }
    }
}
