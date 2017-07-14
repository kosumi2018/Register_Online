using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    /// <summary>
    /// 学制类型
    /// </summary>
    public class Period_Category
    {
        [DisplayName("编号")]
        public int Id { get; set; }
        [DisplayName("学制名称")]
        public string CategoryName { get; set; }
    }
}
