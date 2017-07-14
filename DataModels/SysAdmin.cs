using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class SysAdmin
    {
        [DisplayName("编号")]
        public int Id { get; set; }
        [DisplayName("用户名")]
        public string AdminName { get; set; }
        [DisplayName("密码")]
        public string Password { get; set; }
    }
}
