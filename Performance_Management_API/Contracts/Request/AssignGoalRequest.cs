using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance_Management_API.Contracts.Request
{
    public class AssignGoalRequest
    {
        public int AssignBy { get; set; }
        public int[] Goals { get; set; }
    }
}
