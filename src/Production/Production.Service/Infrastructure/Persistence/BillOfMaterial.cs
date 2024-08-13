using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class BillOfMaterial
{
    public int BillOfMaterialsId { get; set; }

    public int? ProductAssemblyId { get; set; }

    public int ComponentId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string UnitMeasureCode { get; set; } = null!;

    public short Bomlevel { get; set; }

    public decimal PerAssemblyQty { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Product Component { get; set; } = null!;

    public virtual Product? ProductAssembly { get; set; }

    public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; } = null!;
}
