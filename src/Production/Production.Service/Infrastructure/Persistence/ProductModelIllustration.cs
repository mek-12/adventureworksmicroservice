using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class ProductModelIllustration
{
    public int ProductModelId { get; set; }

    public int IllustrationId { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Illustration Illustration { get; set; } = null!;

    public virtual ProductModel ProductModel { get; set; } = null!;
}
