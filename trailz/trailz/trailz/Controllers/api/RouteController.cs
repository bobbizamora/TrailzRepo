using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trailz.Data;
using trailz.Data.UnitOfWork;
using trailz.Models;
using trailz.Areas.Identity.Data;
using trailz.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;


namespace trailz.Controllers.api
{
   
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class RouteController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RouteController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Route
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Route>>> GetRoutes()
        {
            return await _uow.RouteRepository.GetAll()
                .Include(b => b.LoggedInUser)
                .Include(c => c.RouteType)
                .Include(d => d.Level)
                .Include(f => f.LoggedInUserRequests)
                .ToListAsync();
        }

        // GET: api/Route/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Route>> GetRoute(int id)
        {
            Route route = await _uow.RouteRepository.GetById(id);

            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // GET: api/Route/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Route>>> GetRouteslist()
        {
            return await _uow.RouteRepository.GetAll()
                .Include(b => b.LoggedInUser)
                .Include(c => c.RouteType)
                .Include(d => d.Level)
                .Include(f => f.LoggedInUserRequests)
                .ToListAsync();
        }

        // PUT: api/Route/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoute(int id, Route route)
        {
            if (id != route.RouteID)
            {
                return BadRequest();
            }

            _uow.RouteRepository.Update(route);
            await _uow.Save();            

            return NoContent();
        }

        // POST: api/Route
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Route>> PostRoute(Route route)
        {
            _uow.RouteRepository.Create(route);
            await _uow.Save();

            return CreatedAtAction("GetRoute", new { id = route.RouteID}, route);
        }

        // DELETE: api/Route/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Route>> DeleteRoute(int id)
        {
            Route route = await _uow.RouteRepository.GetById(id);
            if (route == null)
            {
                return NotFound();
            }

            _uow.RouteRepository.Delete(route);
            await _uow.Save();

            return NoContent();
        }
    }
}
