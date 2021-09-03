using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer
{
    interface IGoalRepository
    {

        void Create(GoalDbEntity Obj);

        void Update(GoalDbEntity Obj);

        void delete(int CreateBy);

      List <GoalDbEntity> Get();

    }
}
