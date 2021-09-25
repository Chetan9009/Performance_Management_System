using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    interface IGoalRepository
    {

        GoalDbEntity Create(GoalDbEntity Obj);

        GoalDbEntity Update(GoalDbEntity Obj);

        void delete(int CreateBy);

        List<GoalDbEntity> Get();
        List<GoalDbEntity> Get(int id);
        List<EmployeeGoalDbEntity> GetEmpGoal();

        bool CreateGoalMapper(List<GoalMapperDbEntity> obj);

    }
}
