using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
   public class GoalGetUseCase
    {
        public GoalGetResponse Execute( )
        {
            GoalRepository excuteGoal = new GoalRepository();

           var repoResponse = excuteGoal.Get();

            GoalGetResponse getGoals = new GoalGetResponse();
            foreach(var i in repoResponse)
            {
                getGoals.Id = i.Id;
                getGoals.CreatedBy = i.CreatedBy;
                getGoals.Title = i.Title;
                getGoals.StartDate = i.StartDate;
                getGoals.EndDate = i.EndDate;
               
                getGoals.Score = i.Score;
            }
                  
            return  getGoals;

        }
    }
}
