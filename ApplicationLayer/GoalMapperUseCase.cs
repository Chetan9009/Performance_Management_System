using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
    public class GoalMapperUseCase
    {
        public bool Execute(List<CreateGoalMapper> requestGoalMapper)
        {
            List<DomainLayer.GoalMapperDomainEntity> createGoalMapperDomainEntity = new List<DomainLayer.GoalMapperDomainEntity>();
            foreach(var i in requestGoalMapper )
            {
                createGoalMapperDomainEntity.Add(new DomainLayer.GoalMapperDomainEntity
                {
                    AssignBy = i.AssignBy,
                    AssignTo=i.AssignTo,
                    Goalid = i.GoalIds,
                    CreateDate = i.CreateDate
                });
            }



            List<DataLayer.GoalMapperDbEntity> createGoalMapperDbEntity = new List<DataLayer.GoalMapperDbEntity>();
            foreach(var i in createGoalMapperDomainEntity)
            {
                createGoalMapperDbEntity.Add(new DataLayer.GoalMapperDbEntity
                {
                    AssignBy = i.AssignBy,
                    AssignTo=i.AssignTo,
                    Goalid = i.Goalid,
                    CreateDate = i.CreateDate
                });
            }

            


            GoalRepository excuteGoal = new GoalRepository();
            var repoResponse = excuteGoal.CreateGoalMapper(createGoalMapperDbEntity);

            return repoResponse;

        }
    }
}
