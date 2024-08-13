﻿using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class Currency
{
    public string CurrencyCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<CountryRegionCurrency> CountryRegionCurrencies { get; set; } = new List<CountryRegionCurrency>();

    public virtual ICollection<CurrencyRate> CurrencyRateFromCurrencyCodeNavigations { get; set; } = new List<CurrencyRate>();

    public virtual ICollection<CurrencyRate> CurrencyRateToCurrencyCodeNavigations { get; set; } = new List<CurrencyRate>();
}
