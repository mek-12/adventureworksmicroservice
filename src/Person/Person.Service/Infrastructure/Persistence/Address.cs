using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class Address
{
    public int AddressId { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public int StateProvinceId { get; set; }

    public string PostalCode { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; } = new List<BusinessEntityAddress>();

    public virtual StateProvince StateProvince { get; set; } = null!;
}
