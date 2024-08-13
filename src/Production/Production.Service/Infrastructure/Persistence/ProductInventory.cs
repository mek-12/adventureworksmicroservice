using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class ProductInventory
{
    public int ProductId { get; set; }

    public short LocationId { get; set; }

    public string Shelf { get; set; } = null!;

    public byte Bin { get; set; }

    public short Quantity { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
