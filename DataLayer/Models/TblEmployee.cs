using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblEmployeeGoalMapping = new HashSet<TblEmployeeGoalMapping>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DesignationId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public virtual TblDesignation Designation { get; set; }
        public virtual ICollection<TblEmployeeGoalMapping> TblEmployeeGoalMapping { get; set; }
    }
}
