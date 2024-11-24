using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAppCS.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactAppCS.DbContextFile
{
    /// <summary>
    /// Represents the  database context for the ContactApp.
    /// </summary>
    public class ContactAppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactAppDbContext"/> class with specified options.
        /// </summary>
        /// <param name="options">The options to configure the database context.</param>
        public ContactAppDbContext(DbContextOptions<ContactAppDbContext> options) :
            base(options)
        { }

        /// <summary>
        /// Gets or sets the Employee  entities in the database.
        /// </summary>
        public virtual DbSet<Employee>? Employees { get; set; }
    }
}

