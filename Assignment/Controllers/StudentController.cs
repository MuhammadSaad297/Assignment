using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Student = _context.student.ToList();
            return View(Student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Student = _context.student.Where(x => x.Id == id).FirstOrDefault();
            return View(Student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Student = await _context.student.FindAsync(id);
            if (Student == null)
            {
                return NotFound();
            }
            return View(Student);
        }

        // POST Request Person-Edit
        [HttpPost, ActionName("Edit")]

        public async Task<IActionResult> Edit(Student student)
        {

            if (ModelState.IsValid)
            {

                _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Student = await _context.student.FindAsync(id);
            if (Student == null)
            {
                return NotFound();
            }
            return View(Student);
        }




        // POST-Delete

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var Student = await _context.student.FindAsync(id);
                _context.student.Remove(Student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        
    }
}
