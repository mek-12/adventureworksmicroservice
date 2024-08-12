using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class BusinessEntityAddress
{
    public int BusinessEntityId { get; set; }

    public int AddressId { get; set; }

    public int AddressTypeId { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual AddressType AddressType { get; set; } = null!;

    public virtual BusinessEntity BusinessEntity { get; set; } = null!;
}
