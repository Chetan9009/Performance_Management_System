using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
   public class GoalDeleteUseCase
    {
        public void Execute(int id)
        {
            DomainLayer.GoalDomainEntity deleteGoalDomainEntity = new DomainLayer.GoalDomainEntity();
            deleteGoalDomainEntity.Id = id;
            DataLayer.GoalDbEntity deleteDbEntity = new DataLayer.GoalDbEntity();
            deleteDbEntity.Id = deleteGoalDomainEntity.Id;
            GoalRepository excuteGoal = new GoalRepository();
            excuteGoal.delete(deleteDbEntity.Id);
        
        }
    }
}
