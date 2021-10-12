using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
   public class EmployeeGetAllUseCase
    {
        public List<EmployeeCreateResponse> Execute()
        {
            EmployeeRepository excuteGetEmployee = new EmployeeRepository();

            var responseEmployee = excuteGetEmployee.GetEmployee();

            List<EmployeeDomainEntity> responseListEmployee = new List<EmployeeDomainEntity>();

            foreach (var i in responseEmployee)
            {
                responseListEmployee.Add(new EmployeeDomainEntity
                {
                    Id = i.Id,
                    FirstName=i.FirstName
                   ,LastName=i.LastName

                });
            }

            List<EmployeeCreateResponse> responseallEmployee = new List<EmployeeCreateResponse>();
            foreach(var i in responseListEmployee)
            {
                responseallEmployee.Add(new EmployeeCreateResponse
                {
                    Id = i.Id,
                    FirstName = i.FirstName
                    ,LastName=i.LastName
                });
            }

            return responseallEmployee;

        }
    }
}
