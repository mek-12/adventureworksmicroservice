using System;
using System.Collections.Generic;

namespace Sales.Service.Infrastructure.Persistence;

public partial class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }

    public string ShoppingCartId { get; set; } = null!;

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime ModifiedDate { get; set; }
}
