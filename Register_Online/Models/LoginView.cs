using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Register_Online.Models
{
    public class LoginView
    {
        [DisplayName("QQ号或手机号")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "QQ号或者手机号")]
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