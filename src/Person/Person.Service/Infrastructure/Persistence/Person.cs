﻿using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class Person
{
    public int BusinessEntityId { get; set; }

    public string PersonType { get; set; } = null!;

    public bool NameStyle { get; set; }

    public string? Title { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Suffix { get; set; }

    public int EmailPromotion { get; set; }

    public string? AdditionalContactInfo { get; set; }

    public string? Demographics { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual BusinessEntity BusinessEntity { get; set; } = null!;

    public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; } = new List<BusinessEntityContact>();

    public virtual ICollection<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();

    public virtual Password? Password { get; set; }

    public virtual ICollection<PersonPhone> PersonPhones { get; set; } = new List<PersonPhone>();
}
