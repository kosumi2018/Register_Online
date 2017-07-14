using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    /// <summary>
    /// 学校专业
    /// </summary>
    public class Specialty
    {
        [DisplayName("专业编号")]
        public int SpecialtyId { get; set; }
        [DisplayName("专业名称")]
        public string SpecialtyName { get; set; }
        [DisplayName("专业学制")]
        public string Period { get; set; }
        [DisplayName("专业学费")]
        public int Tuition { get; set; }
    }
}
