using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HumanResources.Service.Domain.Entities {
    /// <summary>
    /// Employee pay history.
    /// </summary>
    [Table("EmployeePayHistory", Schema = "HumanResources")]
    public class EmployeePayHistory {
        /// <summary>
        /// Employee identification number. Foreign key to Employee.BusinessEntityID.
        /// </summary>
        [Key, Column(Order = 0)]
        public int BusinessEntityID { get; set; }

        /// <summary>
        /// Date the change in pay is effective.
        /// </summary>
        [Key, Column(Order = 1)]
        public DateTime RateChangeDate { get; set; }

        /// <summary>
        /// Salary hourly rate.
        /// </summary>
        [Required]
        [Column(TypeName = "money")]
        public decimal Rate { get; set; }

        /// <summary>
        /// 1 = Salary received monthly, 2 = Salary received biweekly.
        /// </summary>
        [Required]
        [Range(1, 2)]
        public byte PayFrequency { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
