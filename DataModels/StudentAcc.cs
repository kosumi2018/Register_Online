using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    /// <summary>
    /// 学生帐号表
    /// </summary>
    public class StudentAcc
    {
        [DisplayName("编号")]        
        public int StudentAccId { get; set; }
        [Required(ErrorMessage = "必填字段")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "QQ号或者手机号")]
        [DisplayName("QQ号或者手机号")]
        public string StuAcc { get; set; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z0-9]{6,21}$", ErrorMessage = "输入6到21位字母或数字密码")]
        public string Password { get; set; }
        [DisplayName("注册时间")]
        public DateTime Time { get; set; }
    }
}
