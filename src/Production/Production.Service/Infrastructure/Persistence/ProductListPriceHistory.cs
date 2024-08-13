using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class ProductListPriceHistory
{
    public int ProductId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public decimal ListPrice { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
