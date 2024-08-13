using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class Culture
{
    public string CultureId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCultures { get; set; } = new List<ProductModelProductDescriptionCulture>();
}
