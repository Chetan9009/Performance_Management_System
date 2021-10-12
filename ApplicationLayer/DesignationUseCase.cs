using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class DesignationUseCase
    {
        public List<DesignationCreateResponse> Execute()
        {
            DesignationRepository excuteGetDesignation = new DesignationRepository();

            var responseDesignation = excuteGetDesignation.GetDesignation();

            List<DesignationDomainEntity> responseListDesignation= new List<DesignationDomainEntity>();

            foreach (var i in responseDesignation)
            {
                responseListDesignation.Add(new DesignationDomainEntity
                {
                    Id = i.Id,
                  Designation=i.Designation
                });
            }

            List<DesignationCreateResponse> responseallDesignation = new List<DesignationCreateResponse>();
            foreach (var i in responseListDesignation)
            {
                responseallDesignation.Add(new DesignationCreateResponse
                {
                    Id = i.Id,
                   Designation=i.Designation
                });
            }

            return responseallDesignation;

        }
    }
}