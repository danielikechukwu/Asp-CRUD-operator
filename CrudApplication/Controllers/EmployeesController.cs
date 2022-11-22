using CrudApplication.Data;
using CrudApplication.Models;
using CrudApplication.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;

namespace CrudApplication.Controllers
{
   
    public class EmployeesController : Controller
    {

        //Injecting 
        private readonly CRUDAppDbContext _appDbContext;

        //Contructor Injection
        public EmployeesController(CRUDAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employee = await _appDbContext.employees.ToListAsync();

            return View(employee);
        }

        [HttpPost]        
        //[ValidateAntiForgeryToken]
        //[FromBody]
        public async Task<IActionResult> NewAdd(AddEmployeeViewModel employeeViewModel)
        {

            /* if (ModelState.IsValid)
             {
                 return BadRequest();
             } */

            var employee = new Employee()
            {
                Id = Guid.NewGuid(),

                Name = employeeViewModel.Name,

                Email = employeeViewModel.Email,

                Salary = employeeViewModel.Salary,

                DateOfBirth = employeeViewModel.DateOfBirth,

                Department = employeeViewModel.Department,

            };

            await _appDbContext.employees.AddAsync(employee);

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }  


        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {

            var employee = await _appDbContext.employees.FirstOrDefaultAsync(x => x.Id == Id);

            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department,
                };

                return await Task.Run(() => View("View", viewModel ));

            }
              
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> View( UpdateEmployeeViewModel model)

        {
            var employee = await _appDbContext.employees.FindAsync(model.Id);

            if( employee != null)
            {

                employee.Name = model.Name;

                employee.Email = model.Email;

                employee.Salary = model.Salary;

                employee.DateOfBirth = model.DateOfBirth;

                employee.Department = model.Department;

                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(UpdateEmployeeViewModel model)
        {

            var employee = await _appDbContext.employees.FindAsync(model.Id);

            if (employee != null)
            {
                _appDbContext.employees.Remove(employee);

                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
