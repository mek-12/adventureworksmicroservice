using System;
using System.Collections.Generic;

namespace Production.Service.Infrastructure.Persistence;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string ProductNumber { get; set; } = null!;

    public bool MakeFlag { get; set; }

    public bool FinishedGoodsFlag { get; set; }

    public string? Color { get; set; }

    public short SafetyStockLevel { get; set; }

    public short ReorderPoint { get; set; }

    public decimal StandardCost { get; set; }

    public decimal ListPrice { get; set; }

    public string? Size { get; set; }

    public string? SizeUnitMeasureCode { get; set; }

    public string? WeightUnitMeasureCode { get; set; }

    public decimal? Weight { get; set; }

    public int DaysToManufacture { get; set; }

    public string? ProductLine { get; set; }

    public string? Class { get; set; }

    public string? Style { get; set; }

    public int? ProductSubcategoryId { get; set; }

    public int? ProductModelId { get; set; }

    public DateTime SellStartDate { get; set; }

    public DateTime? SellEndDate { get; set; }

    public DateTime? DiscontinuedDate { get; set; }

    public Guid Rowguid { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<BillOfMaterial> BillOfMaterialComponents { get; set; } = new List<BillOfMaterial>();

    public virtual ICollection<BillOfMaterial> BillOfMaterialProductAssemblies { get; set; } = new List<BillOfMaterial>();

    public virtual ICollection<ProductCostHistory> ProductCostHistories { get; set; } = new List<ProductCostHistory>();

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

    public virtual ICollection<ProductListPriceHistory> ProductListPriceHistories { get; set; } = new List<ProductListPriceHistory>();

    public virtual ProductModel? ProductModel { get; set; }

    public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; set; } = new List<ProductProductPhoto>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ProductSubcategory? ProductSubcategory { get; set; }

    public virtual UnitMeasure? SizeUnitMeasureCodeNavigation { get; set; }

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();

    public virtual UnitMeasure? WeightUnitMeasureCodeNavigation { get; set; }

    public virtual ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
}
