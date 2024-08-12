using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class BusinessEntity
{
    public int BusinessEntityId { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<BusinessEntityAddress> BusinessEntityAddresses { get; set; } = new List<BusinessEntityAddress>();

    public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; } = new List<BusinessEntityContact>();

    public virtual Person? Person { get; set; }
}
