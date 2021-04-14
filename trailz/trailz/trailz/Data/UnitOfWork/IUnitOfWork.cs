using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trailz.Models;
using trailz.Data.Repository;


namespace trailz.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Route> RouteRepository { get; }
        Task Save();
    }
}
