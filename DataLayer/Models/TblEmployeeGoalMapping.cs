using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class TblEmployeeGoalMapping
    {
        public int Id { get; set; }
        public int Empid { get; set; }
        public int Goalid { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual TblEmployee Emp { get; set; }
        public virtual TblGoal Goal { get; set; }
    }
}
