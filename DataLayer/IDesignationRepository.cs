using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    interface IDesignationRepository
    {
        List<DesignationDbEntity> GetDesignation();
    }
}
