using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    class GoalCreateRequest
    {
       
        public int? CreatedBy { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Score { get; set; }
    }
}
