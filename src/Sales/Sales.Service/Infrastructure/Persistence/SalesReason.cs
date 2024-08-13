using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class SalesReason
{
    public int SalesReasonId { get; set; }

    public string Name { get; set; } = null!;

    public string ReasonType { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; } = new List<SalesOrderHeaderSalesReason>();
}
