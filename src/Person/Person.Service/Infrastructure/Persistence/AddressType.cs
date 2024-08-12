using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class AddressType
{
    public int AddressTypeId { get; set; }

    public string Name { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; } = new List<BusinessEntityAddress>();
}
