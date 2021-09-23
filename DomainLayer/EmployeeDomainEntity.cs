using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class EmployeeDomainEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DesignationId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
