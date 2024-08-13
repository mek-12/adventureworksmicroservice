using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class SalesOrderHeaderSalesReason
{
    public int SalesOrderId { get; set; }

    public int SalesReasonId { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual SalesOrderHeader SalesOrder { get; set; } = null!;

    public virtual SalesReason SalesReason { get; set; } = null!;
}
