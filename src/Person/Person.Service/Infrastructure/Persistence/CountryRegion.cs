using System;
using System.Collections.Generic;

namespace Person.Service.Infrastructure.Persistence;

public partial class CountryRegion
{
    public string CountryRegionCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<StateProvince> StateProvinces { get; set; } = new List<StateProvince>();
}
