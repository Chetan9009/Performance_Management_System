using System;
using System.Collections.Generic;

namespace DataLayer.Model
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblEmployeeGoalMappingAssignByNavigation = new HashSet<TblEmployeeGoalMapping>();
            TblEmployeeGoalMappingAssignToNavigation = new HashSet<TblEmployeeGoalMapping>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DesignationId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public virtual TblDesignation Designation { get; set; }
        public virtual ICollection<TblEmployeeGoalMapping> TblEmployeeGoalMappingAssignByNavigation { get; set; }
        public virtual ICollection<TblEmployeeGoalMapping> TblEmployeeGoalMappingAssignToNavigation { get; set; }
    }
}
