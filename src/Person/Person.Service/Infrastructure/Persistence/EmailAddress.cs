using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class EmailAddress
{
    public int BusinessEntityId { get; set; }

    public int EmailAddressId { get; set; }

    public string? EmailAddress1 { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Person BusinessEntity { get; set; } = null!;
}
