using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class CurrencyRate
{
    public int CurrencyRateId { get; set; }

    public DateTime CurrencyRateDate { get; set; }

    public string FromCurrencyCode { get; set; } = null!;

    public string ToCurrencyCode { get; set; } = null!;

    public decimal AverageRate { get; set; }

    public decimal EndOfDayRate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Currency FromCurrencyCodeNavigation { get; set; } = null!;

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();

    public virtual Currency ToCurrencyCodeNavigation { get; set; } = null!;
}
