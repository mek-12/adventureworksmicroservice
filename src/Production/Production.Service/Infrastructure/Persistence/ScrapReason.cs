using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class ScrapReason
{
    public short ScrapReasonId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
