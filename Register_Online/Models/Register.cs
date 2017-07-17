using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Register_Online.Models
{
    public class Register
    {
        [Required(ErrorMessage = "必填字段")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "QQ号或者手机号")]
        [DisplayName("QQ号或者手机号")]
        public string Acc { get; set; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z0-9]{6,21}$", ErrorMessage = "输入6到21位字母或数字密码")]
        public string Password { get; set; }
        [DisplayName("确认密码")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="密码不一致！")]
        public string Checkpwd { get; set; }
        public Student Stu { get; set; }
        
    }
}