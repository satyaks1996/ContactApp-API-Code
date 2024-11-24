using ContactAppCS.IRepos;
using ContactAppCS.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;

        /// <summary>
        /// Initializes a new instance of the EmployeeController class.
        /// </summary>
        /// <param name="employeeRepo">The employee repository used to interact with employee data.</param>
        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        /// <summary>
        /// Gets the list of all employees.
        /// </summary>
        /// <returns>A list of employees in JSON format.</returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployeeList()
        {
            var result = await _employeeRepo.GetEmployeeList();
            return Ok(result);
        }

        /// <summary>
        /// Gets the details of a specific employee by ID.
        /// </summary>
        /// <param name="Id">The ID of the employee to retrieve details for.</param>
        /// <returns>The details of the specified employee.</returns>
        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int Id)
        {
             var result = await _employeeRepo.GetEmployeeDetails(Id);
             return Ok(result);
            
        }

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="Id">The ID of the employee to delete.</param>
        /// <returns>A response indicating the result of the delete operation.</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var result = await _employeeRepo.DeleteEmployee(Id);
            return Ok(result);
        }

        /// <summary>
        /// Add to Update Employee Details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateActivity([FromBody] EmployeeDetails details)
        {
            var result = await _employeeRepo.AddOrUpdateActivity(details);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> CheckEmailExist(string email)
        {
            var result = await _employeeRepo.CheckEmailExist(email);
            return Ok(result);
        }
    }
}
