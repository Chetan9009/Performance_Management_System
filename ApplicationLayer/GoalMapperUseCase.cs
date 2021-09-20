using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class GoalMapperUseCase
    {
        public bool Execute(CreateGoalMapper requestGoalMapper)
        {
            DomainLayer.GoalMapperDomainEntity createGoalMapperDomainEntity = new DomainLayer.GoalMapperDomainEntity()
            {
                Empid = requestGoalMapper.EmpId,
                Goalid = requestGoalMapper.GoalIds,
                CreateDate = requestGoalMapper.CreateDate
            };

            DataLayer.GoalMapperDbEntity createGoalMapperDbEntity = new DataLayer.GoalMapperDbEntity()
            {
                Empid = createGoalMapperDomainEntity.Empid,
                Goalid = createGoalMapperDomainEntity.Goalid,
                CreateDate = createGoalMapperDomainEntity.CreateDate
            };


            GoalRepository excuteGoal = new GoalRepository();
            var repoResponse = excuteGoal.CreateGoalMapper(createGoalMapperDbEntity);

            return repoResponse;

        }
    }
}
