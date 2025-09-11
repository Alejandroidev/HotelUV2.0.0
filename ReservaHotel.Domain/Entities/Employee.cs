using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents an employee of the hotel.
    /// </summary>
    public class Employee : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the employee's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the employee's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the employee's national identification number (e.g., Cédula de Ciudadanía).
        /// </summary>
        public string NationalId { get; set; }

        /// <summary>
        /// Gets or sets the employee's job position (e.g., "Receptionist", "Manager").
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the department the employee belongs to (e.g., "Front Desk", "Housekeeping").
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Gets or sets the date the employee was hired.
        /// </summary>
        public DateTime HireDate { get; set; }

        /// <summary>
        /// Gets or sets the employee's contact email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the employee's contact phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the location where the employee works.
        /// </summary>
        public Guid LocationId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the location.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the optional unique identifier for the user account associated with this employee.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the user account.
        /// </summary>
        public User User { get; set; }
    }
}