using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HumanResources.Service.Domain.Entities {
    /// <summary>
    /// Résumés submitted to Human Resources by job applicants.
    /// </summary>
    [Table("JobCandidate", Schema = "HumanResources")]
    public class JobCandidate {
        /// <summary>
        /// Primary key for JobCandidate records.
        /// </summary>
        [Key]
        public int JobCandidateID { get; set; }

        /// <summary>
        /// Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID.
        /// </summary>
        public int? BusinessEntityID { get; set; }

        /// <summary>
        /// Résumé in XML format.
        /// </summary>
        public string Resume { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
