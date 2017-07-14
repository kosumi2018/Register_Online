using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Id { get; set; }
        [DisplayName("学生帐号")]
        public string StuAcc { get; set; }
        [DisplayName("密码")]
        public string Password { get; set; }
    }
}
