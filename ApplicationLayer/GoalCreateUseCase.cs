using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;


namespace ApplicationLayer
{
    public class GoalCreateUseCase
    {
        public GoalCreateResponse Execute(GoalCreateRequest request)
        {

           DomainLayer.GoalDomainEntity createGoalDomainEntity = new DomainLayer.GoalDomainEntity();
            createGoalDomainEntity.CreatedBy = request.CreatedBy;
            createGoalDomainEntity.Title = request.Title;
            createGoalDomainEntity.StartDate = request.StartDate;
            createGoalDomainEntity.EndDate = request.EndDate;
            createGoalDomainEntity.Score = request.Score;


          DataLayer.GoalDbEntity createDbEntity = new DataLayer.GoalDbEntity();
            createDbEntity.Id = createGoalDomainEntity.Id;
            createDbEntity.CreatedBy = createGoalDomainEntity.CreatedBy;
            createDbEntity.Title = createGoalDomainEntity.Title;
            createDbEntity.StartDate = createDbEntity.StartDate;
            createDbEntity.EndDate = createGoalDomainEntity.EndDate;
            createDbEntity.Score = createGoalDomainEntity.Score;
            Goal excuteGoal = new Goal();
            excuteGoal.Create(createDbEntity);

             var repoResponse = excuteGoal.Get();
          GoalCreateResponse createGoalResponse = new GoalCreateResponse();
            foreach (var i in repoResponse)
            {
                createGoalResponse.Id = i.Id;
                createGoalResponse.CreatedBy = i.CreatedBy;
                createGoalResponse.Title = i.Title;
                createGoalResponse.StartDate = i.StartDate;
                createGoalResponse.EndDate = i.EndDate;
                createGoalResponse.Score = i.Score;
          
           }
                                               
            return createGoalResponse;
        }
    }
}
