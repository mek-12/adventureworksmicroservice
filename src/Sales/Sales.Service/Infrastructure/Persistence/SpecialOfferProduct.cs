using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class SpecialOfferProduct
{
    public int SpecialOfferId { get; set; }

    public int ProductId { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();

    public virtual SpecialOffer SpecialOffer { get; set; } = null!;
}
