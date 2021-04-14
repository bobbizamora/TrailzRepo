using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trailz.Data;
using trailz.Models;

namespace trailz.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AttributeTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttributeTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AttributeType
        public async Task<IActionResult> Index()
        {
            return View(await _context.AttributeTypes.ToListAsync());
        }

        // GET: AttributeType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeType = await _context.AttributeTypes
                .FirstOrDefaultAsync(m => m.AttributeTypeID == id);
            if (attributeType == null)
            {
                return NotFound();
            }

            return View(attributeType);
        }

        // GET: AttributeType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttributeType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttributeTypeID,Name")] AttributeType attributeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attributeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attributeType);
        }

        // GET: AttributeType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeType = await _context.AttributeTypes.FindAsync(id);
            if (attributeType == null)
            {
                return NotFound();
            }
            return View(attributeType);
        }

        // POST: AttributeType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttributeTypeID,Name")] AttributeType attributeType)
        {
            if (id != attributeType.AttributeTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attributeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeTypeExists(attributeType.AttributeTypeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(attributeType);
        }

        // GET: AttributeType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeType = await _context.AttributeTypes
                .FirstOrDefaultAsync(m => m.AttributeTypeID == id);
            if (attributeType == null)
            {
                return NotFound();
            }

            return View(attributeType);
        }

        // POST: AttributeType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attributeType = await _context.AttributeTypes.FindAsync(id);
            _context.AttributeTypes.Remove(attributeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeTypeExists(int id)
        {
            return _context.AttributeTypes.Any(e => e.AttributeTypeID == id);
        }
    }
}
