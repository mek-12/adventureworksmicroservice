﻿using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class TransactionHistory
{
    public int TransactionId { get; set; }

    public int ProductId { get; set; }

    public int ReferenceOrderId { get; set; }

    public int ReferenceOrderLineId { get; set; }

    public DateTime TransactionDate { get; set; }

    public string TransactionType { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal ActualCost { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
