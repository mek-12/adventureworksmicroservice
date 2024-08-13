﻿using System;
using System.Collections.Generic;

namespace Purchasing.Service.Infrastructure.Persistence;

public partial class Vendor
{
    public int BusinessEntityId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public byte CreditRating { get; set; }

    public bool PreferredVendorStatus { get; set; }

    public bool ActiveFlag { get; set; }

    public string? PurchasingWebServiceUrl { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new List<ProductVendor>();

    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = new List<PurchaseOrderHeader>();
}
