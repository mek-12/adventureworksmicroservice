

namespace HumanResources.Service.Domain.Entities {
    public class EmployeeDepartmentHistory {
        public int BusinessEntityID { get; set; } // Employee identification number. Foreign key to Employee.BusinessEntityID.

        public short DepartmentID { get; set; } // Department in which the employee worked including currently. Foreign key to Department.DepartmentID.

        public byte ShiftID { get; set; } // Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID.

        public DateTime StartDate { get; set; } // Date the employee started work in the department.

        public DateTime? EndDate { get; set; } // Date the employee left the department. NULL = Current department.

        public DateTime ModifiedDate { get; set; } // Date and time the record was last updated.
    }
}
