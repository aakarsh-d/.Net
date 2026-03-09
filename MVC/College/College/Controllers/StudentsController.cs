using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using College.Data;
using College.Models;

namespace College.Controllers
{
    public class StudentsController : Controller
    {
        private readonly CollegeDBContext _context;

        public StudentsController(CollegeDBContext context)
        {
            _context = context;
        }

        // READ ALL
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null) return NotFound();

            return View(student);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                student.AppliedDate = DateTime.Now;
                student.RollNumber = "ROLL" + new Random().Next(1000, 9999);

                if (photo != null && photo.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await photo.CopyToAsync(fileStream);
                    }

                    student.PhotoPath = "/images/" + uniqueFileName;
                }

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // ID CARD VIEW
        public async Task<IActionResult> IDCard(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }

        // DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
                _context.Students.Remove(student);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}