using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class Password
{
    public int BusinessEntityId { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Person BusinessEntity { get; set; } = null!;
}
