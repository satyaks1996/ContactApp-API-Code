using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppCS.Model
{
    public class Employee
    {
        [Key]
        /// Id primary key auto- increment for the Employee entity.
        public int Id { get; set; }

        /// FirstName of the Employee entity get;set;
        public string FirstName { get; set; } = string.Empty;

        /// LastName of the Employee entity get;set;
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Email of the Employee entity get;set;
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
