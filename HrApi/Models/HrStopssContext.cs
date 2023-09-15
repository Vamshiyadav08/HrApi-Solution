using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HrApi.Models;

public partial class HrStopssContext : DbContext
{
    public HrStopssContext()
    {
    }

    public HrStopssContext(DbContextOptions<HrStopssContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankDetail> BankDetails { get; set; }

    public virtual DbSet<DocumentDetail> DocumentDetails { get; set; }

    public virtual DbSet<EducationDetail> EducationDetails { get; set; }

    public virtual DbSet<EmployeeAdminDetail> EmployeeAdminDetails { get; set; }

    public virtual DbSet<EmployeeCredential> EmployeeCredentials { get; set; }

    public virtual DbSet<FamilyDetail> FamilyDetails { get; set; }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=HrApiDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankDetail>(entity =>
        {
            entity.HasKey(e => e.BankDetailsId);

            entity.ToTable("BankDetail");

            entity.Property(e => e.BankDetailsId)
                .ValueGeneratedNever()
                .HasColumnName("bank_details_id");
            entity.Property(e => e.AccType)
                .HasMaxLength(255)
                .HasColumnName("acc_type");
            entity.Property(e => e.AccountNo)
                .HasMaxLength(255)
                .HasColumnName("account_no");
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .HasColumnName("bank_name");
            entity.Property(e => e.Branch)
                .HasMaxLength(255)
                .HasColumnName("branch");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Ifsc)
                .HasMaxLength(255)
                .HasColumnName("ifsc");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(255)
                .HasColumnName("payment_mode");

            entity.HasOne(d => d.Employee).WithMany(p => p.BankDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_BankDetail_EmployeeCredential");
        });

        modelBuilder.Entity<DocumentDetail>(entity =>
        {
            entity.HasKey(e => e.DocumentId);

            entity.Property(e => e.DocumentId)
                .ValueGeneratedNever()
                .HasColumnName("document_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Identifier)
                .HasMaxLength(255)
                .HasColumnName("identifier");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Employee).WithMany(p => p.DocumentDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_DocumentDetails_EmployeeCredential");
        });

        modelBuilder.Entity<EducationDetail>(entity =>
        {
            entity.HasKey(e => e.EducationId);

            entity.Property(e => e.EducationId)
                .ValueGeneratedNever()
                .HasColumnName("education_id");
            entity.Property(e => e.College)
                .HasMaxLength(255)
                .HasColumnName("college");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Gpa)
                .HasMaxLength(255)
                .HasColumnName("gpa");
            entity.Property(e => e.Specialization)
                .HasMaxLength(255)
                .HasColumnName("specialization");
            entity.Property(e => e.University)
                .HasMaxLength(255)
                .HasColumnName("university");
            entity.Property(e => e.Year)
                .HasColumnType("date")
                .HasColumnName("year");

            entity.HasOne(d => d.Employee).WithMany(p => p.EducationDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EducationDetails_EmployeeCredential");
        });

        modelBuilder.Entity<EmployeeAdminDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.DateOfJoin)
                .HasColumnType("date")
                .HasColumnName("date_of_join");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .HasColumnName("department");
            entity.Property(e => e.Designation)
                .HasMaxLength(255)
                .HasColumnName("designation");
            entity.Property(e => e.IsAdmin).HasColumnName("is_admin");
            entity.Property(e => e.ReportingManagerId).HasColumnName("reporting_manager_id");

            entity.HasOne(d => d.ReportingManager).WithMany(p => p.InverseReportingManager)
                .HasForeignKey(d => d.ReportingManagerId)
                .HasConstraintName("FK_EmployeeAdminDetails_EmployeeAdminDetails");
        });

        modelBuilder.Entity<EmployeeCredential>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("EmployeeCredential");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");

            entity.HasOne(d => d.Employee).WithOne(p => p.EmployeeCredential)
                .HasForeignKey<EmployeeCredential>(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeCredential_EmployeeAdminDetails");
        });

        modelBuilder.Entity<FamilyDetail>(entity =>
        {
            entity.HasKey(e => e.FamilyId);

            entity.Property(e => e.FamilyId)
                .ValueGeneratedNever()
                .HasColumnName("family_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .HasColumnName("gender");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(255)
                .HasColumnName("mobile_no");
            entity.Property(e => e.Occupation)
                .HasMaxLength(255)
                .HasColumnName("occupation");
            entity.Property(e => e.Relationship)
                .HasMaxLength(255)
                .HasColumnName("relationship");

            entity.HasOne(d => d.Employee).WithMany(p => p.FamilyDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_FamilyDetails_EmployeeCredential");
        });

        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.HasKey(e => e.EmpPersonalId);

            entity.Property(e => e.EmpPersonalId)
                .ValueGeneratedNever()
                .HasColumnName("emp_personal_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(255)
                .HasColumnName("blood_group");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Linkedin)
                .HasMaxLength(255)
                .HasColumnName("linkedin");
            entity.Property(e => e.MartialStatus)
                .HasMaxLength(255)
                .HasColumnName("martial_status");
            entity.Property(e => e.Mobile)
                .HasMaxLength(255)
                .HasColumnName("mobile");
            entity.Property(e => e.PersonalEmail)
                .HasMaxLength(255)
                .HasColumnName("personal_email");
            entity.Property(e => e.Religion)
                .HasMaxLength(255)
                .HasColumnName("religion");

            entity.HasOne(d => d.Employee).WithMany(p => p.PersonalDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_PersonalDetails_EmployeeCredential");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
