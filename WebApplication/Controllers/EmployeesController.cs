using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.ViewModel;

namespace WebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        #region Ctor
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion
        #region Employee Methods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee
                .Include(x => x.Departments)
                .ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (await _context.Employee
                .SingleOrDefaultAsync(m => m.EmployeeId == id) == null)
            {
                return NotFound();
            }

            return base.View(await _context.Employee
                .SingleOrDefaultAsync(m => m.EmployeeId == id));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,Email,Mobile")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                
            }
            return View(employee);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id) == null)
            {
                return NotFound();
            }
            return base.View(await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Email,Mobile")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (await _context.Employee
                .SingleOrDefaultAsync(m => m.EmployeeId == id) == null)
            {
                return NotFound();
            }

            return base.View(await _context.Employee
                .SingleOrDefaultAsync(m => m.EmployeeId == id));
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Employee.Remove(await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeId == id));
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
        #endregion
    }
}
