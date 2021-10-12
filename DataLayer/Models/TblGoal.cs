using System;
using System.Collections.Generic;

namespace DataLayer.Model
{
    public partial class TblGoal
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Score { get; set; }
    }
}
