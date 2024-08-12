﻿using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class BusinessEntityContact
{
    public int BusinessEntityId { get; set; }

    public int PersonId { get; set; }

    public int ContactTypeId { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual BusinessEntity BusinessEntity { get; set; } = null!;

    public virtual ContactType ContactType { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
