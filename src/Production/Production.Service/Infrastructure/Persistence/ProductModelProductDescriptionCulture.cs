using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class ProductModelProductDescriptionCulture
{
    public int ProductModelId { get; set; }

    public int ProductDescriptionId { get; set; }

    public string CultureId { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual Culture Culture { get; set; } = null!;

    public virtual ProductDescription ProductDescription { get; set; } = null!;

    public virtual ProductModel ProductModel { get; set; } = null!;
}
