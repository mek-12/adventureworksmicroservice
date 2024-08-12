﻿using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class StateProvince
{
    public int StateProvinceId { get; set; }

    public string StateProvinceCode { get; set; } = null!;

    public string CountryRegionCode { get; set; } = null!;

    public bool IsOnlyStateProvinceFlag { get; set; }

    public string Name { get; set; } = null!;

    public int TerritoryId { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual CountryRegion CountryRegionCodeNavigation { get; set; } = null!;
}
