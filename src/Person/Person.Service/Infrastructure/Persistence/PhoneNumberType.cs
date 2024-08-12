using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class PhoneNumberType
{
    public int PhoneNumberTypeId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<PersonPhone> PersonPhones { get; set; } = new List<PersonPhone>();
}
