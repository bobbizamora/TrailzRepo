using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trailz.Data.Repository;
using trailz.Models;

namespace trailz.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Route> routeRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Route> RouteRepository
        {
            get
            {
                if (this.routeRepository == null)
                {
                    this.routeRepository = new GenericRepository<Route>(_context);
                }
                return routeRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
