using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRTVU.EMS.Domain.Models
{
    public class Student : AggregateRoot
    {
        public string StuID { get; set; }

        public string StuName { get; set; }

        public string ClassID { get; set; }

        public string IDNumber { get; set; }
    }
}
