using ReservaHotel.Domain.Entities.Base;
using ReservaHotel.Domain.Interfaces;
using System;

namespace ReservaHotel.Domain.Entities
{
    /// <summary>
    /// Represents a system user with credentials to access the application.
    /// </summary>
    public class User : BaseEntity<Guid>, IAggregateRoot
    {
        /// <summary>
        /// Gets or sets the username, typically the user's email address.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the hashed password. This should never store a plain-text password.
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the salt used to hash the password. Each user must have a unique salt.
        /// </summary>
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user account is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the employee associated with this user account.
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the navigation property for the employee.
        /// </summary>
        public Employee Employee { get; set; }
    }
}