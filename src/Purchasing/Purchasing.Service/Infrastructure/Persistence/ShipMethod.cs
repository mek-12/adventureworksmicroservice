using System;
using System.Collections.Generic;

namespace Purchasing.Service.Infrastructure.Persistence;

public partial class ShipMethod
{
    public int ShipMethodId { get; set; }

    public string Name { get; set; } = null!;

    public decimal ShipBase { get; set; }

    public decimal ShipRate { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = new List<PurchaseOrderHeader>();
}
