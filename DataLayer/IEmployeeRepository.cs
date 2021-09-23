using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    interface IEmployeeRepository
    {
        List<EmployeeDbEntity> GetEmployee();
    }
}
