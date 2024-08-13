using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class ProductPhoto
{
    public int ProductPhotoId { get; set; }

    public byte[]? ThumbNailPhoto { get; set; }

    public string? ThumbnailPhotoFileName { get; set; }

    public byte[]? LargePhoto { get; set; }

    public string? LargePhotoFileName { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; set; } = new List<ProductProductPhoto>();
}
