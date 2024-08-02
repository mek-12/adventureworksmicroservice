namespace HumanResources.Service.Domain.Entities {
    public class Employee {
        // Primary key for Employee records. Foreign key to Person.BusinessEntityID.
        public int BusinessEntityID { get; private set; }

        // Unique national identification number such as a social security number.
        public string NationalIDNumber { get; private set; }

        // Network login ID.
        public string LoginID { get; private set; }

        // Location in the corporate hierarchy (stored as hierarchyid).
        public string OrganizationNode { get; private set; }

        // The depth of the employee in the corporate hierarchy.
        public int OrganizationLevel { get; private set; }

        // Job title such as Buyer or Sales Representative.
        public string JobTitle { get; private set; }

        // Date of birth.
        public DateTime BirthDate { get; private set; }

        // Marital status: M = Married, S = Single.
        public char MaritalStatus { get; private set; }

        // Gender: M = Male, F = Female.
        public char Gender { get; private set; }

        // Date the employee was hired.
        public DateTime HireDate { get; private set; }

        // Job classification: 0 = Hourly, 1 = Salaried.
        public bool SalariedFlag { get; private set; }

        // Number of available vacation hours.
        public short VacationHours { get; private set; }

        // Number of available sick leave hours.
        public short SickLeaveHours { get; private set; }

        // Employment status: 0 = Inactive, 1 = Active.
        public bool CurrentFlag { get; private set; }

        // Unique identifier GUID.
        public Guid RowGuid { get; private set; }

        // Date and time the record was last updated.
        public DateTime ModifiedDate { get; private set; }

        // Private constructor for entity framework or other ORM.
        private Employee() { }

        // Constructor with parameters to initialize an Employee object.
        public Employee(
            string nationalIDNumber,
            string loginID,
            string organizationNode,
            string jobTitle,
            DateTime birthDate,
            char maritalStatus,
            char gender,
            DateTime hireDate,
            bool salariedFlag,
            short vacationHours,
            short sickLeaveHours,
            bool currentFlag) {
            NationalIDNumber = nationalIDNumber;
            LoginID = loginID;
            OrganizationNode = organizationNode;
            JobTitle = jobTitle;
            BirthDate = birthDate;
            MaritalStatus = maritalStatus;
            Gender = gender;
            HireDate = hireDate;
            SalariedFlag = salariedFlag;
            VacationHours = vacationHours;
            SickLeaveHours = sickLeaveHours;
            CurrentFlag = currentFlag;
            RowGuid = Guid.NewGuid();
            ModifiedDate = DateTime.Now;
        }

        // Method to update the job title and modify the record's ModifiedDate.
        public void UpdateJobTitle(string newJobTitle) {
            JobTitle = newJobTitle;
            ModifiedDate = DateTime.Now;
        }

        // Method to update the number of vacation hours and modify the record's ModifiedDate.
        public void UpdateVacationHours(short newVacationHours) {
            VacationHours = newVacationHours;
            ModifiedDate = DateTime.Now;
        }

        // Method to update the number of sick leave hours and modify the record's ModifiedDate.
        public void UpdateSickLeaveHours(short newSickLeaveHours) {
            SickLeaveHours = newSickLeaveHours;
            ModifiedDate = DateTime.Now;
        }

        // Method to update the current employment status flag and modify the record's ModifiedDate.
        public void UpdateCurrentFlag(bool newCurrentFlag) {
            CurrentFlag = newCurrentFlag;
            ModifiedDate = DateTime.Now;
        }
    }
}
