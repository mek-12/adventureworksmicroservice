using System;
using System.Collections.Generic;

namespace HumanResources.Service.Infrastructure.Persistence;

public partial class Shift
{
    public byte ShiftId { get; set; }

    public string Name { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<EmployeeDepartmentHistory> EmployeeDepartmentHistories { get; set; } = new List<EmployeeDepartmentHistory>();
}
