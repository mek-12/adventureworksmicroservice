﻿using System;
using System.Collections.Generic;

namespace HumanResources.Service.Infrastructure.Persistence;

public partial class EmployeeDepartmentHistory
{
    public int BusinessEntityId { get; set; }

    public short DepartmentId { get; set; }

    public byte ShiftId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Employee BusinessEntity { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Shift Shift { get; set; } = null!;
}
