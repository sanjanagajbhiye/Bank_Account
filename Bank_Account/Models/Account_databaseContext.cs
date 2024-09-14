using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bank_Account.Models
{
    public partial class Account_databaseContext : DbContext
    {
        public Account_databaseContext()
        {
        }

        public Account_databaseContext(DbContextOptions<Account_databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountOpeningFormTable> AccountOpeningFormTables { get; set; } = null!;
        public virtual DbSet<BranchTable> BranchTables { get; set; } = null!;
        public virtual DbSet<CityTable> CityTables { get; set; } = null!;
        public virtual DbSet<LanguageTable1> LanguageTable1s { get; set; } = null!;
        public virtual DbSet<StateTable> StateTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=DESKTOP-RNQISD0\\SQLEXPRESS; database=Account_database; trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountOpeningFormTable>(entity =>
            {
                entity.HasKey(e => e.FormNumber)
                    .HasName("PK__Account___03BC4C5D531D0FBC");

                entity.ToTable("Account_opening_form_table");

                entity.Property(e => e.FormNumber).HasColumnName("Form_number");

                entity.Property(e => e.CustAccountType).HasColumnName("Cust_account_type");

                entity.Property(e => e.CustAge)
                    .HasColumnName("Cust_age")
                    .HasComputedColumnSql("(datediff(year,[Cust_date_of_birth],getdate()))", false);

                entity.Property(e => e.CustBranchCode).HasColumnName("Cust_branch_code");

                entity.Property(e => e.CustCityCode).HasColumnName("Cust_city_code");

                entity.Property(e => e.CustDateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Cust_date_of_birth");

                entity.Property(e => e.CustEmailId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Cust_email_id");

                entity.Property(e => e.CustFirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Cust_first_name");

                entity.Property(e => e.CustLastName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Cust_last_name");

                entity.Property(e => e.CustMiddleName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Cust_middle_name");

                entity.Property(e => e.CustMobile)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Cust_mobile");

                entity.Property(e => e.CustPreferredLanguage).HasColumnName("Cust_preferred_language");

                entity.Property(e => e.CustSex)
                    .HasColumnName("Cust_sex")
                    .HasComputedColumnSql("(case when [Cust_title]=(4) OR [Cust_title]=(1) then (1) when [Cust_title]=(5) OR [Cust_title]=(3) OR [Cust_title]=(2) then (2) else (3) end)", false);

                entity.Property(e => e.CustStateCode).HasColumnName("Cust_state_code");

                entity.Property(e => e.CustStdCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Cust_std_code");

                entity.Property(e => e.CustTelephone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Cust_telephone");

                entity.Property(e => e.CustTitle).HasColumnName("Cust_title");

                entity.Property(e => e.FormFillingDate)
                    .HasColumnType("date")
                    .HasColumnName("Form_filling_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FormFillingTime)
                    .HasColumnName("Form_filling_time")
                    .HasDefaultValueSql("(CONVERT([time],getdate()))");

                entity.HasOne(d => d.CustBranchCodeNavigation)
                    .WithMany(p => p.AccountOpeningFormTables)
                    .HasForeignKey(d => d.CustBranchCode)
                    .HasConstraintName("FK__Account_o__Cust___32E0915F");

                entity.HasOne(d => d.CustCityCodeNavigation)
                    .WithMany(p => p.AccountOpeningFormTables)
                    .HasForeignKey(d => d.CustCityCode)
                    .HasConstraintName("FK__Account_o__Cust___31EC6D26");

                entity.HasOne(d => d.CustPreferredLanguageNavigation)
                    .WithMany(p => p.AccountOpeningFormTables)
                    .HasForeignKey(d => d.CustPreferredLanguage)
                    .HasConstraintName("FK__Account_o__Cust___33D4B598");

                entity.HasOne(d => d.CustStateCodeNavigation)
                    .WithMany(p => p.AccountOpeningFormTables)
                    .HasForeignKey(d => d.CustStateCode)
                    .HasConstraintName("FK__Account_o__Cust___30F848ED");
            });

            modelBuilder.Entity<BranchTable>(entity =>
            {
                entity.HasKey(e => e.BranchCode)
                    .HasName("PK__branch_t__A9F83E3A25DA48CB");

                entity.ToTable("branch_table");

                entity.Property(e => e.BranchCode)
                    .ValueGeneratedNever()
                    .HasColumnName("branch_code");

                entity.Property(e => e.BranchCityCode).HasColumnName("Branch_city_code");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("branch_name");

                entity.HasOne(d => d.BranchCityCodeNavigation)
                    .WithMany(p => p.BranchTables)
                    .HasForeignKey(d => d.BranchCityCode)
                    .HasConstraintName("FK__branch_ta__Branc__173876EA");
            });

            modelBuilder.Entity<CityTable>(entity =>
            {
                entity.HasKey(e => e.CityCode)
                    .HasName("PK__city_tab__B6FC2B96899290D7");

                entity.ToTable("city_table");

                entity.Property(e => e.CityCode)
                    .ValueGeneratedNever()
                    .HasColumnName("city_code");

                entity.Property(e => e.CityName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city_name");

                entity.Property(e => e.CityStateCode).HasColumnName("city_state_code");

                entity.HasOne(d => d.CityStateCodeNavigation)
                    .WithMany(p => p.CityTables)
                    .HasForeignKey(d => d.CityStateCode)
                    .HasConstraintName("FK__city_tabl__city___145C0A3F");
            });

            modelBuilder.Entity<LanguageTable1>(entity =>
            {
                entity.HasKey(e => e.LanguageCode);

                entity.ToTable("Language_table1");

                entity.Property(e => e.LanguageCode)
                    .ValueGeneratedNever()
                    .HasColumnName("language_code");

                entity.Property(e => e.LanguageName)
                    .HasMaxLength(20)
                    .HasColumnName("language_name");
            });

            modelBuilder.Entity<StateTable>(entity =>
            {
                entity.HasKey(e => e.StateCode);

                entity.ToTable("State_table");

                entity.Property(e => e.StateCode)
                    .ValueGeneratedNever()
                    .HasColumnName("State_code");

                entity.Property(e => e.StateName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("State_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
