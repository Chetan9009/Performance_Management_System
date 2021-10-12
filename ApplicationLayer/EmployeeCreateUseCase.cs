using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
   public class EmployeeCreateUseCase
    {
        public EmployeeCreateResponse Execute(EmployeeCreateRequest request)
        {

            DomainLayer.EmployeeDomainEntity createEmployeeDomainEntity = new DomainLayer.EmployeeDomainEntity()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DesignationId = request.DesignationId,
                EmailId = request.EmailId,
                Password = request.Password
            };



            DataLayer.EmployeeDbEntity createDbEntity = new DataLayer.EmployeeDbEntity()
            {
                FirstName = createEmployeeDomainEntity.FirstName,
                LastName = createEmployeeDomainEntity.LastName,
                DesignationId = createEmployeeDomainEntity.DesignationId,
                EmailId = createEmployeeDomainEntity.EmailId,
                Password = createEmployeeDomainEntity.Password

            };


            EmployeeRepository excuteEmployee = new EmployeeRepository();

            var repoEmployeeResponse = excuteEmployee.Create(createDbEntity);
            EmployeeCreateResponse createEmployeeResponse = new EmployeeCreateResponse()
            {
                Id = repoEmployeeResponse.Id,
                FirstName = repoEmployeeResponse.FirstName,
                LastName = repoEmployeeResponse.LastName,
                DesignationId = repoEmployeeResponse.DesignationId,
                EmailId = repoEmployeeResponse.EmailId,
                Password = repoEmployeeResponse.Password

            };
              
            return createEmployeeResponse;
        }


    }
}
