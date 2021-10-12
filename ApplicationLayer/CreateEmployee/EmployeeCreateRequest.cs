using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class EmployeeCreateRequest
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DesignationId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
