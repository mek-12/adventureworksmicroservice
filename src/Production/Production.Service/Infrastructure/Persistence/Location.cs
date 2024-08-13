﻿using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class Location
{
    public short LocationId { get; set; }

    public string Name { get; set; } = null!;

    public decimal CostRate { get; set; }

    public decimal Availability { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

    public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; } = new List<WorkOrderRouting>();
}
