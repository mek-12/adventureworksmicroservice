using System;
using System.Collections.Generic;

namespace HumanResources.Service.Infrastructure.Persistence;

public partial class JobCandidate
{
    public int JobCandidateId { get; set; }

    public int? BusinessEntityId { get; set; }

    public string? Resume { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Employee? BusinessEntity { get; set; }
}
