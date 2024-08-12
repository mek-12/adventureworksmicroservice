using System;
using System.Collections.Generic;

namespace HumanResources.Service.Infrastructure.Persistence;

public partial class Employee
{
    public int BusinessEntityId { get; set; }

    public string NationalIdnumber { get; set; } = null!;

    public string LoginId { get; set; } = null!;

    public short? OrganizationLevel { get; set; }

    public string JobTitle { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string MaritalStatus { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly HireDate { get; set; }

    public bool SalariedFlag { get; set; }

    public short VacationHours { get; set; }

    public short SickLeaveHours { get; set; }

    public bool CurrentFlag { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } = new List<EmployeeDepartmentHistory>();

    public virtual ICollection<EmployeePayHistory> EmployeePayHistories { get; set; } = new List<EmployeePayHistory>();

    public virtual ICollection<JobCandidate> JobCandidates { get; set; } = new List<JobCandidate>();
}
