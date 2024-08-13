using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Purchasing.Service.Infrastructure.Persistence;

public partial class PurchasingContext : DbContext
{
    public PurchasingContext()
    {
    }

    public PurchasingContext(DbContextOptions<PurchasingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductVendor> ProductVendors { get; set; }

    public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

    public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }

    public virtual DbSet<ShipMethod> ShipMethods { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,15432;Initial Catalog=Purchasing;Persist Security Info=True;User ID=sa;Password=AdventurePass*123;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductVendor>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.BusinessEntityId }).HasName("PK_ProductVendor_ProductID_BusinessEntityID");

            entity.ToTable("ProductVendor");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");
            entity.Property(e => e.LastReceiptCost).HasColumnType("money");
            entity.Property(e => e.LastReceiptDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StandardPrice).HasColumnType("money");
            entity.Property(e => e.UnitMeasureCode)
                .HasMaxLength(3)
                .IsFixedLength();

            entity.HasOne(d => d.BusinessEntity).WithMany(p => p.ProductVendors)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PurchaseOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.PurchaseOrderId, e.PurchaseOrderDetailId }).HasName("PK_PurchaseOrderDetail_PurchaseOrderID_PurchaseOrderDetailID");

            entity.ToTable("PurchaseOrderDetail");

            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");
            entity.Property(e => e.PurchaseOrderDetailId)
                .ValueGeneratedOnAdd()
                .HasColumnName("PurchaseOrderDetailID");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("(isnull([OrderQty]*[UnitPrice],(0.00)))", false)
                .HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ReceivedQty).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.RejectedQty).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.StockedQty)
                .HasComputedColumnSql("(isnull([ReceivedQty]-[RejectedQty],(0.00)))", false)
                .HasColumnType("decimal(9, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PurchaseOrderHeader>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PK_PurchaseOrderHeader_PurchaseOrderID");

            entity.ToTable("PurchaseOrderHeader");

            entity.Property(e => e.PurchaseOrderId).HasColumnName("PurchaseOrderID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Freight).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.ShipMethodId).HasColumnName("ShipMethodID");
            entity.Property(e => e.Status).HasDefaultValue((byte)1);
            entity.Property(e => e.SubTotal).HasColumnType("money");
            entity.Property(e => e.TaxAmt).HasColumnType("money");
            entity.Property(e => e.TotalDue)
                .HasComputedColumnSql("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))", true)
                .HasColumnType("money");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");

            entity.HasOne(d => d.ShipMethod).WithMany(p => p.PurchaseOrderHeaders)
                .HasForeignKey(d => d.ShipMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Vendor).WithMany(p => p.PurchaseOrderHeaders)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ShipMethod>(entity =>
        {
            entity.HasKey(e => e.ShipMethodId).HasName("PK_ShipMethod_ShipMethodID");

            entity.ToTable("ShipMethod");

            entity.Property(e => e.ShipMethodId).HasColumnName("ShipMethodID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.ShipBase).HasColumnType("money");
            entity.Property(e => e.ShipRate).HasColumnType("money");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Vendor_BusinessEntityID");

            entity.ToTable("Vendor");

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasColumnName("BusinessEntityID");
            entity.Property(e => e.AccountNumber).HasMaxLength(15);
            entity.Property(e => e.ActiveFlag).HasDefaultValue(true);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PreferredVendorStatus).HasDefaultValue(true);
            entity.Property(e => e.PurchasingWebServiceUrl)
                .HasMaxLength(1024)
                .HasColumnName("PurchasingWebServiceURL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
