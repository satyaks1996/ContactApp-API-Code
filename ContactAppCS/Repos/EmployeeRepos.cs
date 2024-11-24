using ContactAppCS.DbContextFile;
using ContactAppCS.IRepos;
using ContactAppCS.Model;
using ContactAppCS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppCS.Repos
{
    public class EmployeeRepos : IEmployeeRepo
    {
        private readonly ContactAppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the EmployeeRepos class.
        /// </summary>
        /// <param name="context">The database context for accessing employee data.</param>
        /// <exception Thrown when the context is null.</exception>
        public EmployeeRepos(ContactAppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Retrieves the list of all employees.
        /// </summary>
        /// <returns>An EmployeeViewModel containing the list of employees.</returns>
        public async Task<EmployeeViewModel> GetEmployeeList()
        {
            var result = new EmployeeViewModel
            {
                DataModel = new EmployeeDataModel()
            };

            try
            {
                var employeeList = _context.Employees.ToList();

                var list = new List<EmployeeDetails>();

                if (employeeList != null)
                {
                    foreach (var item in employeeList)
                    {
                        list.Add(new EmployeeDetails
                        {
                            Id = item.Id.ToString(),
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            Email = item.Email,
                        });
                    }
                    result.DataModel.EmployeeList = list;
                }
                else
                {
                    result.DataModel.SucessMessage = "No Data Available";
                }
            }
            catch (Exception ex)
            {
                result.DataModel.SucessMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Retrieves the details of a specific employee by their ID.
        /// </summary>
        /// <param name="Id">The ID of the employee to retrieve.</param>
        /// <returns>An EmployeeViewModel containing the employee's details.</returns>
        public async Task<EmployeeViewModel> GetEmployeeDetails(int Id)
        {
            var result = new EmployeeViewModel
            {
                DataModel = new EmployeeDataModel()
            };

            if (Id > 0)
            {
                var employee = _context.Employees.Where(x => x.Id == Id).FirstOrDefault();

                if (employee != null)
                {
                    result.DataModel.EmployeeDetails = new EmployeeDetails
                    {
                        Id = employee.Id.ToString(),
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                    };
                }
                else
                {
                    result.DataModel.SucessMessage = "No Data Available";
                }
            }

            return result;
        }

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="Id">The ID of the employee to delete.</param>
        /// <returns>An EmployeeViewModel containing the result of the delete operation.</returns>
        public async Task<EmployeeViewModel> DeleteEmployee(int Id)
        {
            var result = new EmployeeViewModel
            {
                DataModel = new EmployeeDataModel()
            };

            try
            {
                if (Id > 0)
                {
                    var employee = _context.Employees.Where(x => x.Id == Id).FirstOrDefault();

                    if (employee != null)
                    {
                        _context.Employees.Remove(employee);
                        _context.SaveChanges();

                        result.DataModel.SucessMessage = "Employee Deleted Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                result.DataModel.SucessMessage = ex.Message;
            }

            return result;
        }


        /// <summary>
        /// Add or Update Employee Details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public Task<EmployeeViewModel> AddOrUpdateActivity(EmployeeDetails details)
        {
            var result = new EmployeeViewModel
            {
                DataModel = new EmployeeDataModel()
            };


            try
            {

                if (details.Id == null)
                {
                    var employee = new Employee
                    {
                        FirstName = details.FirstName,
                        LastName = details.LastName,
                        Email = details.Email,
                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    result.DataModel.SucessMessage = "Employee Added Successfully";
                    result.DataModel.EmployeeDetails = new EmployeeDetails
                    {
                        Id = employee.Id.ToString(),
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Email = employee.Email,
                    };
                }
                else
                {
                    var employee = _context.Employees.Where(x => x.Id == Convert.ToInt32(details.Id)).FirstOrDefault();
                    if (employee != null)
                    {
                        employee.FirstName = details.FirstName;
                        employee.LastName = details.LastName;
                        employee.Email = details.Email;
                        _context.SaveChanges();
                        result.DataModel.SucessMessage = "Employee Updated Successfully";
                        result.DataModel.EmployeeDetails = new EmployeeDetails
                        {
                            Id = employee.Id.ToString(),
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Email = employee.Email,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                result.DataModel.SucessMessage = ex.Message;
            }

            return Task.FromResult(result);

        }


        public async Task<string> CheckEmailExist(string email)
        {
            var result = string.Empty;

            try
            {
                var employee = _context.Employees.Where(x => x.Email == email).FirstOrDefault();

                if (employee != null)
                {
                    result = "Email Already Exist";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}