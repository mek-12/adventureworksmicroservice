using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class ContactType
{
    public int ContactTypeId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; } = new List<BusinessEntityContact>();
}
