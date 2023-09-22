using System;
using System.Collections.Generic;
using BankApplication.ResponseModel;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Models;

public partial class BankManagementContext : DbContext
{
    public BankManagementContext()
    {
    }

    public BankManagementContext(DbContextOptions<BankManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankMaster> BankMasters { get; set; }

    public virtual DbSet<BranchMaster> BranchMasters { get; set; }

    public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }

    public virtual DbSet<TransactionMaster> TransactionMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=.\\;Database=BankManagement;integrated security=True; trustServerCertificate=true");


    // custom
    public virtual DbSet<GetCustomers> GetCustomers { get; set; }

    public virtual DbSet<GetBankBranches> GetBankBranches { get; set; }

    public virtual DbSet<GetCustomeBranchesTransactions> GetCustomeBranchesTransactions { get; set; }

    public virtual DbSet<GetCustomerTransactions> GetCustomerTransactions { get; set; }
    // custom

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //custom
        modelBuilder.Entity<GetCustomers>(entity => entity.HasNoKey());
        modelBuilder.Entity<GetBankBranches>(entity => entity.HasNoKey());
        modelBuilder.Entity<GetCustomeBranchesTransactions>(entity => entity.HasNoKey());
        modelBuilder.Entity<GetCustomerTransactions>(entity => entity.HasNoKey());
        //custom

        modelBuilder.Entity<BankMaster>(entity =>
        {
            entity.ToTable("BankMaster");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<BranchMaster>(entity =>
        {
            entity.ToTable("BranchMaster");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Bank).WithMany(p => p.BranchMasters)
                .HasForeignKey(d => d.BankId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BranchMaster_BankMaster");
        });

        modelBuilder.Entity<CustomerMaster>(entity =>
        {
            entity.ToTable("CustomerMaster");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TransactionMaster>(entity =>
        {
            entity.ToTable("TransactionMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
