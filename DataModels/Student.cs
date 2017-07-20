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
    /// 报名学生信息表
    /// </summary>
    public class Student
    {
        [DisplayName("序号")]
        public int StudentId { get; set; }
        [DisplayName("准考证号")]
        [RegularExpression(@"^[0-9]+$",ErrorMessage ="数字准考证号")]
        public string CardNumber { get; set; }
        [DisplayName("学生姓名")]
        [Required(ErrorMessage = "必填字段")]
        [RegularExpression(@"^[\u4E00-\u9FFF]+$",ErrorMessage ="请输入你的中文名")]
        public string StudentName { get; set; }
        [DisplayName("性别")]
        public string Sex { get; set; }
        [DisplayName("民族")]
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        [DisplayName("出生日期")]
        [Required(ErrorMessage = "必填字段")]
        [RegularExpression(@"^(19|20)\d{2}-(1[0-2]|0?[1-9])-(0?[1-9]|[1-2][0-9]|3[0-1])$",ErrorMessage ="生日格式不对")]
        public string Birthday { get; set; }
        [DisplayName("身份证号码")]
        [RegularExpression(@"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}([0-9]|X)$",ErrorMessage = "身份证号码有误")]
        public string CNumber { get; set; }
        [DisplayName("籍贯")]
        [RegularExpression(@"^[\u4E00-\u9FFF]+$", ErrorMessage = "请输入中文")]
        public string NativePlace { get; set; }
        [DisplayName("联系电话")]
        [Required(ErrorMessage = "必填字段")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "数字")]
        public string TelNumber { get; set; }
        [DisplayName("毕业学校")]
        [RegularExpression(@"^[\u4E00-\u9FFF]+$", ErrorMessage = "请输入中文")]
        public string SchoolName { get; set; }
        [DisplayName("家庭住址")]
        [RegularExpression(@"^[a-zA-Z0-9\u4E00-\u9FFF]+$", ErrorMessage = "请输入中文")]
        public string Adress { get; set; }
        [DisplayName("邮政编码")]
        [RegularExpression(@"^[1-9]\d{5}(?!\d)+$", ErrorMessage = "6位数字邮政编码")]
        public string ZipCode { get; set; }
        [DisplayName("家长姓名")]
        [RegularExpression(@"^[\u4E00-\u9FFF]+$", ErrorMessage = "请输入中文")]
        public string Patriarch { get; set; }
        [DisplayName("家长电话")]
        public string Pat_Telnum { get; set; }
        [DisplayName("委托人员")]
        [RegularExpression(@"^[\u4E00-\u9FFF]+$", ErrorMessage = "请输入中文")]
        public string Mandator { get; set; }
        [DisplayName("统考科目分")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "数字")]
        public int UnifiedScore { get; set; }
        [DisplayName("总分")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "数字")]
        public int TotalPoints { get; set; }        
        [DisplayName("选报专业")]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        [DisplayName("学制")]
        public int Period_CategoryId { get; set; }
        [DisplayName("QQ号或者手机号")]
        public int StudentAccId { get; set; }
        public StudentAcc StudentAcc { get; set; }
        [DisplayName("报名时间")]
        public DateTime Time { get; set; }
    }
}
