using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class SalesTerritory
{
    public int TerritoryId { get; set; }

    public string Name { get; set; } = null!;

    public string CountryRegionCode { get; set; } = null!;

    public string Group { get; set; } = null!;

    public decimal SalesYtd { get; set; }

    public decimal SalesLastYear { get; set; }

    public decimal CostYtd { get; set; }

    public decimal CostLastYear { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    public virtual ICollection<SalesPerson> SalesPeople { get; set; } = new List<SalesPerson>();

    public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new List<SalesTerritoryHistory>();
}
