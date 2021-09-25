using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class EmployeeGoalUseCase
    {
        public List<EmployeeGoalGetResponse> Execute()
        {
            GoalRepository excuteGoal = new GoalRepository();
            List<EmployeeGoalGetResponse> responseEmployeeGoals = new List<EmployeeGoalGetResponse>();
            var repoResponse = excuteGoal.GetEmpGoal();

               foreach (var i in repoResponse)
              {
                responseEmployeeGoals.Add(new EmployeeGoalGetResponse {
                Id=i.Id,
                FirstName=i.FirstName,
                LastName=i.LastName,
                CreatedBy=i.CreatedBy,
                Title=i.Title,
                StartDate=i.StartDate,
                EndDate=i.EndDate,Score=i.Score
                
                });

                   
                };

            return responseEmployeeGoals;

        }

    }
}
