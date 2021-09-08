using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    interface IGoalRepository
    {

        GoalDbEntity Create(GoalDbEntity Obj);

        GoalDbEntity Update(GoalDbEntity Obj);

        string delete(int CreateBy);

        List<GoalDbEntity> Get();

    }
}
