using Asp_MongoDB.Entites;
using Asp_MongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asp_MongoDB.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var employeeList = await _employeeService.GetAll();
            return View(employeeList);
        }
        [HttpGet]

        public  async Task<IActionResult> Details(Guid id)
        {
            var employee = await _employeeService.GetById(id);
            if(employee != null )
               return View(employee);

            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if(!ModelState.IsValid)
                return BadRequest();

           await _employeeService.Create(employee);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var oldEmployee = await _employeeService.GetById(Id);

            if(oldEmployee != null)

                return View(oldEmployee);

            return NotFound();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
               await _employeeService.Update(employee);

              return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _employeeService.GetById(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
           await _employeeService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
