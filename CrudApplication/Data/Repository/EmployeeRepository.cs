using CrudApplication.Interface;
using CrudApplication.Models;
using CrudApplication.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

       

        private readonly CRUDAppDbContext _appDbContext;

        public EmployeeRepository( CRUDAppDbContext appDbContext)
        {
            appDbContext = _appDbContext;
        }

        //Viewing all data in the database
        public async Task<IEnumerable<Employee>> IndexAsync()
        {
            return await _appDbContext.employees.ToListAsync();
        }


        //Viewing an individual database
        public async Task<Employee> ViewAsync(Guid Id)
        {
            return await _appDbContext.employees.FirstOrDefaultAsync(x => x.Id == Id);

        }

        //public Employee View(Guid Id)
        //{
        //    return _appDbContext.employees.Find(Id);
        //}

        //Adding new data to the database
        public async Task<Employee> NewAddAsync(Employee employee) 
        {

            await _appDbContext.employees.AddAsync(employee);

            await _appDbContext.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> Delete(Guid Id)
        {
            Employee employee = _appDbContext.employees.Find(Id);

            if(employee != null)
            {
                _appDbContext.employees.Remove(employee);
                _appDbContext.SaveChanges();
            }

            return employee;
        }
    }
};
