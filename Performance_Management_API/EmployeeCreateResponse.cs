using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance_Management_API
{
    public class EmployeeCreateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DesignationId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
