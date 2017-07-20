using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Nation
    {
        [DisplayName("编号")]
        public int NationId { get; set; }
        [DisplayName("民族")]
        public string NationName { get; set; }
    }
}
