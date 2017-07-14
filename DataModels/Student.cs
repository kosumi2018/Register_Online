using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Id { get; set; }
        [DisplayName("准考证号")]
        public string CardNumber { get; set; }
        [DisplayName("学生姓名")]
        public string StudentName { get; set; }
        [DisplayName("性别")]
        public string Sex { get; set; }
        [DisplayName("民族")]
        public string Nation { get; set; }
        [DisplayName("出生日期")]
        public string Birthday { get; set; }
        [DisplayName("籍贯")]
        public string NativePlace { get; set; }
        [DisplayName("联系电话")]
        public string TelNumber { get; set; }
        [DisplayName("毕业学校")]
        public string SchoolName { get; set; }
        [DisplayName("家庭住址")]
        public string Adress { get; set; }
        [DisplayName("邮政编码")]
        public string ZipCode { get; set; }
        [DisplayName("家长姓名")]
        public string Patriarch { get; set; }
        [DisplayName("家长电话")]
        public string Pat_Telnum { get; set; }
        [DisplayName("委托人员")]
        public string Mandator { get; set; }
        [DisplayName("统考科目分")]
        public int UnifiedScore { get; set; }
        [DisplayName("总分")]
        public int TotalPoints { get; set; }
        [DisplayName("照片")]
        public string PicUrl { get; set; }
        [DisplayName("个人简介")]
        public string Resume { get; set; }
        [DisplayName("选报专业")]
        public string ChooseSpecialty { get; set; }
        [DisplayName("学制")]
        public string CategoryName { get; set; }
    }
}
