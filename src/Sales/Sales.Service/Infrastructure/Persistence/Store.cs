using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class Store
{
    public int BusinessEntityId { get; set; }

    public string Name { get; set; } = null!;

    public int? SalesPersonId { get; set; }

    public string? Demographics { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual SalesPerson? SalesPerson { get; set; }
}
