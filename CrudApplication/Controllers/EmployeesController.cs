using CrudApplication.Data;
using CrudApplication.Models;
using CrudApplication.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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


     

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employee = await _appDbContext.employees.ToListAsync();

            return View(employee);
        }


        public IActionResult Add()
        {
            return View();
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

            //public async Task<IActionResult> View(Guid Id, UpdateEmployeeViewModel viewModel)
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

                //return View(viewModel);

                return await Task.Run(() => View("View", viewModel ));

            }
              
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> View( UpdateEmployeeViewModel model)

            //public async Task<IActionResult> Update([FromBody] UpdateEmployeeViewModel model)

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


    }
}
