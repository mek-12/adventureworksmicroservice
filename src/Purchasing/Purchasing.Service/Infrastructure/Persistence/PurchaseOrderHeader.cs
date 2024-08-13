using System;
using System.Collections.Generic;

namespace Purchasing.Service.Infrastructure.Persistence;

public partial class PurchaseOrderHeader
{
    public int PurchaseOrderId { get; set; }

    public byte RevisionNumber { get; set; }

    public byte Status { get; set; }

    public int EmployeeId { get; set; }

    public int VendorId { get; set; }

    public int ShipMethodId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? ShipDate { get; set; }

    public decimal SubTotal { get; set; }

    public decimal TaxAmt { get; set; }

    public decimal Freight { get; set; }

    public decimal TotalDue { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    public virtual ShipMethod ShipMethod { get; set; } = null!;

    public virtual Vendor Vendor { get; set; } = null!;
}
