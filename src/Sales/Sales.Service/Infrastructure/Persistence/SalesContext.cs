using Microsoft.EntityFrameworkCore;

namespace Sales.Service.Infrastructure.Persistence;

public partial class SalesContext : DbContext {
    public SalesContext() {
    }

    public SalesContext(DbContextOptions<SalesContext> options)
        : base(options) {
    }

    public virtual DbSet<CountryRegionCurrency> CountryRegionCurrencies { get; set; }

    public virtual DbSet<CreditCard> CreditCards { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CurrencyRate> CurrencyRates { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<PersonCreditCard> PersonCreditCards { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    public virtual DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; }

    public virtual DbSet<SalesPerson> SalesPeople { get; set; }

    public virtual DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistories { get; set; }

    public virtual DbSet<SalesReason> SalesReasons { get; set; }

    public virtual DbSet<SalesTaxRate> SalesTaxRates { get; set; }

    public virtual DbSet<SalesTerritory> SalesTerritories { get; set; }

    public virtual DbSet<SalesTerritoryHistory> SalesTerritoryHistories { get; set; }

    public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public virtual DbSet<SpecialOffer> SpecialOffers { get; set; }

    public virtual DbSet<SpecialOfferProduct> SpecialOfferProducts { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,15432;Initial Catalog=Sales;Persist Security Info=True;User ID=sa;Password=AdventurePass*123;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<CountryRegionCurrency>(entity => {
            entity.HasKey(e => new { e.CountryRegionCode, e.CurrencyCode }).HasName("PK_CountryRegionCurrency_CountryRegionCode_CurrencyCode");

            entity.ToTable("CountryRegionCurrency");

            entity.Property(e => e.CountryRegionCode).HasMaxLength(3);
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CurrencyCodeNavigation).WithMany(p => p.CountryRegionCurrencies)
                .HasForeignKey(d => d.CurrencyCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CreditCard>(entity => {
            entity.HasKey(e => e.CreditCardId).HasName("PK_CreditCard_CreditCardID");

            entity.ToTable("CreditCard");

            entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");
            entity.Property(e => e.CardNumber).HasMaxLength(25);
            entity.Property(e => e.CardType).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Currency>(entity => {
            entity.HasKey(e => e.CurrencyCode).HasName("PK_Currency_CurrencyCode");

            entity.ToTable("Currency");

            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<CurrencyRate>(entity => {
            entity.HasKey(e => e.CurrencyRateId).HasName("PK_CurrencyRate_CurrencyRateID");

            entity.ToTable("CurrencyRate");

            entity.Property(e => e.CurrencyRateId).HasColumnName("CurrencyRateID");
            entity.Property(e => e.AverageRate).HasColumnType("money");
            entity.Property(e => e.CurrencyRateDate).HasColumnType("datetime");
            entity.Property(e => e.EndOfDayRate).HasColumnType("money");
            entity.Property(e => e.FromCurrencyCode)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ToCurrencyCode)
                .HasMaxLength(3)
                .IsFixedLength();

            entity.HasOne(d => d.FromCurrencyCodeNavigation).WithMany(p => p.CurrencyRateFromCurrencyCodeNavigations)
                .HasForeignKey(d => d.FromCurrencyCode)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ToCurrencyCodeNavigation).WithMany(p => p.CurrencyRateToCurrencyCodeNavigations)
                .HasForeignKey(d => d.ToCurrencyCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Customer>(entity => {
            entity.HasKey(e => e.CustomerId).HasName("PK_Customer_CustomerID");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComputedColumnSql("(isnull('AW'+[dbo].[ufnLeadingZeros]([CustomerID]),''))", false);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PersonId).HasColumnName("PersonID");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

            entity.HasOne(d => d.Store).WithMany(p => p.Customers).HasForeignKey(d => d.StoreId);

            entity.HasOne(d => d.Territory).WithMany(p => p.Customers).HasForeignKey(d => d.TerritoryId);
        });

        modelBuilder.Entity<PersonCreditCard>(entity => {
            entity.HasKey(e => new { e.BusinessEntityId, e.CreditCardId }).HasName("PK_PersonCreditCard_BusinessEntityID_CreditCardID");

            entity.ToTable("PersonCreditCard");

            entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");
            entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CreditCard).WithMany(p => p.PersonCreditCards)
                .HasForeignKey(d => d.CreditCardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesOrderDetail>(entity => {
            entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId }).HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

            entity.ToTable("SalesOrderDetail");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.SalesOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SalesOrderDetailID");
            entity.Property(e => e.CarrierTrackingNumber).HasMaxLength(25);
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("(isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0)))", false)
                .HasColumnType("numeric(38, 6)");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SpecialOfferId).HasColumnName("SpecialOfferID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
            entity.Property(e => e.UnitPriceDiscount).HasColumnType("money");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderDetails).HasForeignKey(d => d.SalesOrderId);

            entity.HasOne(d => d.SpecialOfferProduct).WithMany(p => p.SalesOrderDetails)
                .HasForeignKey(d => new { d.SpecialOfferId, d.ProductId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID");
        });

        modelBuilder.Entity<SalesOrderHeader>(entity => {
            entity.HasKey(e => e.SalesOrderId).HasName("PK_SalesOrderHeader_SalesOrderID");

            entity.ToTable("SalesOrderHeader");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.AccountNumber).HasMaxLength(15);
            entity.Property(e => e.BillToAddressId).HasColumnName("BillToAddressID");
            entity.Property(e => e.Comment).HasMaxLength(128);
            entity.Property(e => e.CreditCardApprovalCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CreditCardId).HasColumnName("CreditCardID");
            entity.Property(e => e.CurrencyRateId).HasColumnName("CurrencyRateID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OnlineOrderFlag).HasDefaultValue(true);
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(25);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesOrderNumber)
                .HasMaxLength(25)
                .HasComputedColumnSql("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))", false);
            entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipMethodId).HasColumnName("ShipMethodID");
            entity.Property(e => e.ShipToAddressId).HasColumnName("ShipToAddressID");
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.TaxAmt).HasColumnType("money");
            entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");
            entity.Property(e => e.TotalDue)
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", false)
                .HasColumnType("money");

            entity.HasOne(d => d.CreditCard).WithMany(p => p.SalesOrderHeaders).HasForeignKey(d => d.CreditCardId);

            entity.HasOne(d => d.CurrencyRate).WithMany(p => p.SalesOrderHeaders).HasForeignKey(d => d.CurrencyRateId);

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrderHeaders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SalesPerson).WithMany(p => p.SalesOrderHeaders).HasForeignKey(d => d.SalesPersonId);

            entity.HasOne(d => d.Territory).WithMany(p => p.SalesOrderHeaders).HasForeignKey(d => d.TerritoryId);
        });

        modelBuilder.Entity<SalesOrderHeaderSalesReason>(entity => {
            entity.HasKey(e => new { e.SalesOrderId, e.SalesReasonId }).HasName("PK_SalesOrderHeaderSalesReason_SalesOrderID_SalesReasonID");

            entity.ToTable("SalesOrderHeaderSalesReason");

            entity.Property(e => e.SalesOrderId).HasColumnName("SalesOrderID");
            entity.Property(e => e.SalesReasonId).HasColumnName("SalesReasonID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.SalesOrder).WithMany(p => p.SalesOrderHeaderSalesReasons).HasForeignKey(d => d.SalesOrderId);

            entity.HasOne(d => d.SalesReason).WithMany(p => p.SalesOrderHeaderSalesReasons)
                .HasForeignKey(d => d.SalesReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesPerson>(entity => {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_SalesPerson_BusinessEntityID");

            entity.ToTable("SalesPerson");

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.Bonus).HasColumnType("money");
            entity.Property(e => e.CommissionPct).HasColumnType("smallmoney");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesLastYear).HasColumnType("money");
            entity.Property(e => e.SalesQuota).HasColumnType("money");
            entity.Property(e => e.SalesYtd)
                .HasColumnType("money")
                .HasColumnName("SalesYTD");
            entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");

            entity.HasOne(d => d.Territory).WithMany(p => p.SalesPeople).HasForeignKey(d => d.TerritoryId);
        });

        modelBuilder.Entity<SalesPersonQuotaHistory>(entity => {
            entity.HasKey(e => new { e.BusinessEntityId, e.QuotaDate }).HasName("PK_SalesPersonQuotaHistory_BusinessEntityID_QuotaDate");

            entity.ToTable("SalesPersonQuotaHistory");

            entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");
            entity.Property(e => e.QuotaDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesQuota).HasColumnType("money");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.SalesPersonQuotaHistories)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SalesReason>(entity => {
            entity.HasKey(e => e.SalesReasonId).HasName("PK_SalesReason_SalesReasonID");

            entity.ToTable("SalesReason");

            entity.Property(e => e.SalesReasonId).HasColumnName("SalesReasonID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ReasonType).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesTaxRate>(entity => {
            entity.HasKey(e => e.SalesTaxRateId).HasName("PK_SalesTaxRate_SalesTaxRateID");

            entity.ToTable("SalesTaxRate");

            entity.Property(e => e.SalesTaxRateId).HasColumnName("SalesTaxRateID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.StateProvinceId).HasColumnName("StateProvinceID");
            entity.Property(e => e.TaxRate).HasColumnType("smallmoney");
        });

        modelBuilder.Entity<SalesTerritory>(entity => {
            entity.HasKey(e => e.TerritoryId).HasName("PK_SalesTerritory_TerritoryID");

            entity.ToTable("SalesTerritory");

            entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");
            entity.Property(e => e.CostLastYear).HasColumnType("money");
            entity.Property(e => e.CostYtd)
                .HasColumnType("money")
                .HasColumnName("CostYTD");
            entity.Property(e => e.CountryRegionCode).HasMaxLength(3);
            entity.Property(e => e.Group).HasMaxLength(50);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesLastYear).HasColumnType("money");
            entity.Property(e => e.SalesYtd)
                .HasColumnType("money")
                .HasColumnName("SalesYTD");
        });

        modelBuilder.Entity<SalesTerritoryHistory>(entity => {
            entity.HasKey(e => new { e.BusinessEntityId, e.StartDate, e.TerritoryId }).HasName("PK_SalesTerritoryHistory_BusinessEntityID_StartDate_TerritoryID");

            entity.ToTable("SalesTerritoryHistory");

            entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TerritoryId).HasColumnName("TerritoryID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.SalesTerritoryHistories)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Territory).WithMany(p => p.SalesTerritoryHistories)
                .HasForeignKey(d => d.TerritoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ShoppingCartItem>(entity => {
            entity.HasKey(e => e.ShoppingCartItemId).HasName("PK_ShoppingCartItem_ShoppingCartItemID");

            entity.ToTable("ShoppingCartItem");

            entity.Property(e => e.ShoppingCartItemId).HasColumnName("ShoppingCartItemID");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.ShoppingCartId)
                .HasMaxLength(50)
                .HasColumnName("ShoppingCartID");
        });

        modelBuilder.Entity<SpecialOffer>(entity => {
            entity.HasKey(e => e.SpecialOfferId).HasName("PK_SpecialOffer_SpecialOfferID");

            entity.ToTable("SpecialOffer");

            entity.Property(e => e.SpecialOfferId).HasColumnName("SpecialOfferID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DiscountPct).HasColumnType("smallmoney");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<SpecialOfferProduct>(entity => {
            entity.HasKey(e => new { e.SpecialOfferId, e.ProductId }).HasName("PK_SpecialOfferProduct_SpecialOfferID_ProductID");

            entity.ToTable("SpecialOfferProduct");

            entity.Property(e => e.SpecialOfferId).HasColumnName("SpecialOfferID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.SpecialOffer).WithMany(p => p.SpecialOfferProducts)
                .HasForeignKey(d => d.SpecialOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Store>(entity => {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Store_BusinessEntityID");

            entity.ToTable("Store");

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.Demographics).HasColumnType("xml");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

            entity.HasOne(d => d.SalesPerson).WithMany(p => p.Stores).HasForeignKey(d => d.SalesPersonId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
