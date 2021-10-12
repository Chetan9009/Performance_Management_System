using System;
using System.Collections.Generic;

namespace DataLayer.Model
{
    public partial class TblEmployeeGoalMapping
    {
        public int Id { get; set; }
        public int AssignBy { get; set; }
        public int AssignTo { get; set; }
        public int Goalid { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual TblEmployee AssignByNavigation { get; set; }
        public virtual TblEmployee AssignToNavigation { get; set; }
    }
}
