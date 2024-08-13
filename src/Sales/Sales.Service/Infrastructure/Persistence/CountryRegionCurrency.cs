using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class CountryRegionCurrency
{
    public string CountryRegionCode { get; set; } = null!;

    public string CurrencyCode { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;
}
