using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int? PersonId { get; set; }

    public int? StoreId { get; set; }

    public int? TerritoryId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    public virtual Store? Store { get; set; }

    public virtual SalesTerritory? Territory { get; set; }
}
