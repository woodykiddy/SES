using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SES.Domain.Entities
{
    public class ShortCourse : Course
    {
        // add short course specific properties
        public string DeliveryMethod { get; set; }

    }
}
