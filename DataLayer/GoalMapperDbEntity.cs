using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class GoalMapperDbEntity
    {
        public int Id { get; set; }
        public int AssignBy { get; set; }
        public int AssignTo { get; set; }
        public int Goalid { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
