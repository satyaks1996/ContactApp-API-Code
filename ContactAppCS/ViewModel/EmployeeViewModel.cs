using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppCS.ViewModel
{
    /// <summary>
    /// Represents the view model for employee-related data.
    /// </summary>
    public class EmployeeViewModel
    {
        /// <summary>
        /// Gets or sets the data model containing employee-related information.
        /// </summary>
        public EmployeeDataModel? DataModel { get; set; }
    }

    /// <summary>
    /// Represents the data model containing employee-related information.
    /// </summary>
    public class EmployeeDataModel
    {
        /// <summary>
        /// Gets or sets the success message to display after an operation is performed.
        /// </summary>
        public string? SucessMessage { get; set; }

        /// <summary>
        /// Gets or sets the list of employee details.
        /// </summary>
        public List<EmployeeDetails> ?EmployeeList { get; set; }

        /// <summary>
        /// Gets or sets the detailed information of a single employee.
        /// </summary>
        public EmployeeDetails ? EmployeeDetails { get; set; }
    }

    /// <summary>
    /// Represents the details of an individual employee.
    /// </summary>
    public class EmployeeDetails
    {
        /// <summary>
        /// Gets or sets the unique identifier of the employee.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        public string? Email { get; set; }
    }
}
