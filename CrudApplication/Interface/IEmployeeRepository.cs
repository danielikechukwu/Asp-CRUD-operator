using CrudApplication.Models;
using CrudApplication.Models.Domain;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace CrudApplication.Interface
{
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> IndexAsync();

        Task<Employee> ViewAsync(Guid Id);

        Task<Employee> NewAddAsync(Employee employee);

        Task<Employee> Delete(Guid Id);
      
    }
};
