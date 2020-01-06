using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RequestTimeTrackingMiddleware.Models;

namespace RequestTimeTrackingMiddleware.DAL
{
    public interface IProfileRepository:IRepository<Profile>
    {
    }
}
