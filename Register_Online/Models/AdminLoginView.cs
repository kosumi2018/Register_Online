using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Register_Online.Models
{
    public class AdminLoginView
    {
        [DisplayName("用户名")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [RegularExpression(@"^[0-9a-zA-Z\-\@]{4,23}$", ErrorMessage = "4位至23位的数字或字母和-、@组合")]
        public string Account { get; set; }
        [DisplayName("密码")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [MinLength(6), MaxLength(21)]
        public string Password { get; set; }
        [DisplayName("验证码")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "4位数字验证马")]
        public string Codeimg { get; set; }
    }
}