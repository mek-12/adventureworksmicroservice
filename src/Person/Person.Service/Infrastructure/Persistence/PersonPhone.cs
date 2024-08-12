using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class PersonPhone
{
    public int BusinessEntityId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int PhoneNumberTypeId { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Person BusinessEntity { get; set; } = null!;

    public virtual PhoneNumberType PhoneNumberType { get; set; } = null!;
}
