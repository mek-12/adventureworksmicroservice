using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class UnitMeasure
{
    public string UnitMeasureCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<BillOfMaterial> BillOfMaterials { get; set; } = new List<BillOfMaterial>();

    public virtual ICollection<Product> ProductSizeUnitMeasureCodeNavigations { get; set; } = new List<Product>();

    public virtual ICollection<Product> ProductWeightUnitMeasureCodeNavigations { get; set; } = new List<Product>();
}
