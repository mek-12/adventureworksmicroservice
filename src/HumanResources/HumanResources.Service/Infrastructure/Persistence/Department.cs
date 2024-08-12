using System;
using System.Collections.Generic;

namespace HumanResources.Service.Infrastructure.Persistence;

public partial class Department
{
    public short DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string GroupName { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } = new List<EmployeeDepartmentHistory>();
}
