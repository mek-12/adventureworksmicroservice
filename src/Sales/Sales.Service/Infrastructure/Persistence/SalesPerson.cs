using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class SalesPerson
{
    public int BusinessEntityId { get; set; }

    public int? TerritoryId { get; set; }

    public decimal? SalesQuota { get; set; }

    public decimal Bonus { get; set; }

    public decimal CommissionPct { get; set; }

    public decimal SalesYtd { get; set; }

    public decimal SalesLastYear { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    public virtual ICollection<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; } = new List<SalesPersonQuotaHistory>();

    public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new List<SalesTerritoryHistory>();

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public virtual SalesTerritory? Territory { get; set; }
}
