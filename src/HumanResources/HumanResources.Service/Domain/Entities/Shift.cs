using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HumanResources.Service.Domain.Entities {
    /// <summary>
    /// Work shift lookup table.
    /// </summary>
    [Table("Shift", Schema = "HumanResources")]
    public class Shift {
        /// <summary>
        /// Primary key for Shift records.
        /// </summary>
        [Key]
        public byte ShiftID { get; set; }

        /// <summary>
        /// Shift description.
        /// </summary>
        [Required]
        [StringLength(50)] // Assuming a max length, adjust as needed
        public string Name { get; set; }

        /// <summary>
        /// Shift start time.
        /// </summary>
        [Required]
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Shift end time.
        /// </summary>
        [Required]
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
