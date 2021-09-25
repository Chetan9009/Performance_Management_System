using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
   public class EmployeeGoalGetResponse
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Score { get; set; }

    }
}
