using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class CreditCard
{
    public int CreditCardId { get; set; }

    public string CardType { get; set; } = null!;

    public string CardNumber { get; set; } = null!;

    public byte ExpMonth { get; set; }

    public short ExpYear { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; } = new List<PersonCreditCard>();

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new List<SalesOrderHeader>();
}
