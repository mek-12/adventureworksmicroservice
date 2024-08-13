using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class ProductProductPhoto
{
    public int ProductId { get; set; }

    public int ProductPhotoId { get; set; }

    public bool Primary { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ProductPhoto ProductPhoto { get; set; } = null!;
}
