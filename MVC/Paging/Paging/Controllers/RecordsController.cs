using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paging.Data;
using Paging.Models;

namespace Paging.Controllers
{
    public class RecordsController : Controller
    {
        private readonly ShkhaDbContext _context;

        public RecordsController(ShkhaDbContext context)
        {
            _context = context;
        }

        // GET: Records
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 5;

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            var records = await _context.Records
                .FromSqlRaw("EXEC GetRecordsPaged @PageNumber={0}, @PageSize={1}", pageNumber, pageSize)
                .ToListAsync();

            ViewBag.PageNumber = pageNumber;

            return View(records);
        }

        // GET: Records/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records
                .FirstOrDefaultAsync(m => m.Id == id);

            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // GET: Records/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Records/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Record record)
        {
            if (ModelState.IsValid)
            {
                _context.Add(record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(record);
        }

        // GET: Records/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // POST: Records/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Record record)
        {
            if (id != record.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(record);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordExists(record.Id))
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

            return View(record);
        }

        // GET: Records/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Records
                .FirstOrDefaultAsync(m => m.Id == id);

            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var record = await _context.Records.FindAsync(id);

            if (record != null)
            {
                _context.Records.Remove(record);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}