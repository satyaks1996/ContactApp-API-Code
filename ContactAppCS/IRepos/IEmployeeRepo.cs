using ContactAppCS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppCS.IRepos
{
    /// <summary>
    /// Defines methods for managing employee data in the repository.
    /// </summary>
    public interface IEmployeeRepo
    {
        /// <summary>
        /// Retrieves a list of all employees.
        /// </summary>

        Task<EmployeeViewModel> GetEmployeeList();

        /// <summary>
        /// Retrieves the details of a specific employee by their unique identifier.
        /// </summary>
        /// <param name="Id">The unique identifier of the employee.</param>

        ///Add and Update Employee Details
        Task<EmployeeViewModel> AddOrUpdateActivity(EmployeeDetails details);

        Task<EmployeeViewModel> GetEmployeeDetails(int Id);

        /// <summary>
        /// Deletes an employee from the repository based on their unique identifier.
        /// </summary>
        /// <param name="Id">The unique identifier of the employee to delete.</param>
        Task<EmployeeViewModel> DeleteEmployee(int Id);

        Task<string> CheckEmailExist(string email);

    }
}

