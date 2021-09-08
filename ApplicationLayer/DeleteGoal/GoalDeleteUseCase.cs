using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
   public class GoalDeleteUseCase
    {
        public string Execute(int id)
        {
            DomainLayer.GoalDomainEntity deleteGoalDomainEntity = new DomainLayer.GoalDomainEntity();
            deleteGoalDomainEntity.Id = id;
            DataLayer.GoalDbEntity deleteDbEntity = new DataLayer.GoalDbEntity();
            deleteDbEntity.Id = deleteGoalDomainEntity.Id;
            GoalRepository excuteGoal = new GoalRepository();
            var repoResponse = excuteGoal.delete(deleteDbEntity.Id);
          return repoResponse;
        }
    }
}
