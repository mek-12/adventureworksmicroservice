using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class Illustration
{
    public int IllustrationId { get; set; }

    public string? Diagram { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductModelIllustration> ProductModelIllustrations { get; set; } = new List<ProductModelIllustration>();
}
