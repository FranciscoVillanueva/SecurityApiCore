using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SecurityCore.Models
{
    public partial class SecurityApiContext : DbContext
    {
        public SecurityApiContext()
        {
        }

        public SecurityApiContext(DbContextOptions<SecurityApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessEntity> AccessEntity { get; set; }
        public virtual DbSet<AccessEntityAuthorizations> AccessEntityAuthorizations { get; set; }
        public virtual DbSet<AccessEntityUsersSettings> AccessEntityUsersSettings { get; set; }
        public virtual DbSet<ActiveToken> ActiveToken { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationAccess> ApplicationAccess { get; set; }
        public virtual DbSet<ApplicationAccessActions> ApplicationAccessActions { get; set; }
        public virtual DbSet<CatDomainSettings> CatDomainSettings { get; set; }
        public virtual DbSet<CatSettingsDataTypes> CatSettingsDataTypes { get; set; }
        public virtual DbSet<CatSystemCatalog> CatSystemCatalog { get; set; }
        public virtual DbSet<CatSystemCatalogDetail> CatSystemCatalogDetail { get; set; }
        public virtual DbSet<CatUserSettings> CatUserSettings { get; set; }
        public virtual DbSet<Domain> Domain { get; set; }
        public virtual DbSet<DomainSettings> DomainSettings { get; set; }
        public virtual DbSet<EndUser> EndUser { get; set; }
        public virtual DbSet<Ipaddress> Ipaddress { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<UserEntity> UserEntity { get; set; }
        public virtual DbSet<UserEntityPermissionsAccess> UserEntityPermissionsAccess { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }
        public virtual DbSet<UserPwdHistoryLog> UserPwdHistoryLog { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source=microservicessttk2.database.windows.net;Initial catalog=SecurityApi;persist security info=True;user id=adminSttk;password=@Softtek01");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessEntity>(entity =>
            {
                entity.Property(e => e.AccessEntityTypeCd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<AccessEntityAuthorizations>(entity =>
            {
                entity.HasKey(e => new { e.AccessEntityId, e.UserEntityId });

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.HasOne(d => d.AccessEntity)
                    .WithMany(p => p.AccessEntityAuthorizations)
                    .HasForeignKey(d => d.AccessEntityId)
                    .HasConstraintName("AccessEntityAuthorizations_AccessEntityId_AccessEntity_FX");

                entity.HasOne(d => d.UserEntity)
                    .WithMany(p => p.AccessEntityAuthorizations)
                    .HasForeignKey(d => d.UserEntityId)
                    .HasConstraintName("AccessEntityAuthorizations_UserEntityId_UserEntity_FX");
            });

            modelBuilder.Entity<AccessEntityUsersSettings>(entity =>
            {
                entity.HasKey(e => new { e.AccessEntityId, e.UserId, e.ScreenItemTag });

                entity.Property(e => e.ScreenItemTag)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SettingXml).HasColumnType("xml");

                entity.HasOne(d => d.AccessEntity)
                    .WithMany(p => p.AccessEntityUsersSettings)
                    .HasForeignKey(d => d.AccessEntityId)
                    .HasConstraintName("AccessEntityUsersSettings_AccessEntityId_AccessEntity_FX");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AccessEntityUsersSettings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("AccessEntityUsersSettings_UserId_EndUser_FX");
            });

            modelBuilder.Entity<ActiveToken>(entity =>
            {
                entity.HasKey(e => e.TokenId);

                entity.Property(e => e.ChannelId)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastConnAttempt).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActiveToken)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_31");
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasIndex(e => e.ApplicationTag)
                    .HasName("Application_ApplicationKey_IDX")
                    .IsUnique();

                entity.Property(e => e.ApplicationTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccessEntity)
                    .WithMany(p => p.Application)
                    .HasForeignKey(d => d.AccessEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Application_AccessEntityId_AccessEntity_FX");
            });

            modelBuilder.Entity<ApplicationAccess>(entity =>
            {
                entity.HasKey(e => e.AccessId);

                entity.HasIndex(e => new { e.ApplicationId, e.AccessTag })
                    .HasName("ApplicationAccess_ApplicationIdAccessKey_IDX")
                    .IsUnique();

                entity.Property(e => e.AccessTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccessEntity)
                    .WithMany(p => p.ApplicationAccess)
                    .HasForeignKey(d => d.AccessEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ApplicationAccess_AccessEntityId_AccessEntity_FX");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationAccess)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("ApplicationAccess_ApplicationId_Application_FX");
            });

            modelBuilder.Entity<ApplicationAccessActions>(entity =>
            {
                entity.HasKey(e => e.ActionId);

                entity.HasIndex(e => new { e.AccessId, e.ActionTag })
                    .HasName("ApplicationAccessActions_AccessIdActionKey_IDX")
                    .IsUnique();

                entity.Property(e => e.ActionTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccessEntity)
                    .WithMany(p => p.ApplicationAccessActions)
                    .HasForeignKey(d => d.AccessEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ApplicationAccessActions_AccessEntityId_AccessEntity_FX");

                entity.HasOne(d => d.Access)
                    .WithMany(p => p.ApplicationAccessActions)
                    .HasForeignKey(d => d.AccessId)
                    .HasConstraintName("ApplicationAccessActions_AccessId_ApplicationAccess_FX");
            });

            modelBuilder.Entity<CatDomainSettings>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.HasIndex(e => e.SettingCd)
                    .HasName("CatDomainSettings_SettingCd_IDX")
                    .IsUnique();

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SettingCd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ValueDefault)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.SettingType)
                    .WithMany(p => p.CatDomainSettings)
                    .HasForeignKey(d => d.SettingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CatDomainSettings_SettingTypeId_CatSettingsDataTypes_FX");
            });

            modelBuilder.Entity<CatSettingsDataTypes>(entity =>
            {
                entity.HasKey(e => e.SettingTypeId);

                entity.HasIndex(e => e.SettingTypeCd)
                    .HasName("CatSettingsDataTypes_SettingTypeCd_IDX")
                    .IsUnique();

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SettingTypeCd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatSystemCatalog>(entity =>
            {
                entity.HasKey(e => e.CatalogId)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => e.Name)
                    .HasName("IXQ_CodeNamespace_Name")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatSystemCatalogDetail>(entity =>
            {
                entity.HasKey(e => new { e.CatalogId, e.CatalogKey });

                entity.Property(e => e.CatalogKey)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.CatSystemCatalogDetail)
                    .HasForeignKey(d => d.CatalogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CodeValue_CodeNamespace");
            });

            modelBuilder.Entity<CatUserSettings>(entity =>
            {
                entity.HasKey(e => e.SettingId);

                entity.HasIndex(e => e.SettingCd)
                    .HasName("catUsersSettings_SettingCd_IDX")
                    .IsUnique();

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SettingCd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ValueDefault)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.SettingType)
                    .WithMany(p => p.CatUserSettings)
                    .HasForeignKey(d => d.SettingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CatUserSettings_SettingTypeId_CatSettingsDataTypes_FX");
            });

            modelBuilder.Entity<Domain>(entity =>
            {
                entity.HasIndex(e => e.FullName)
                    .HasName("Domain_FullName_IDX2")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("Domain_Name_IDX1")
                    .IsUnique();

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.DomainTypeCd)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DomainSettings>(entity =>
            {
                entity.HasKey(e => new { e.DomainId, e.SettingId });

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.DomainSettings)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("DomainSettings_DomainId_Domain_FX");

                entity.HasOne(d => d.Setting)
                    .WithMany(p => p.DomainSettings)
                    .HasForeignKey(d => d.SettingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DomainSettings_SettingId_CatDomainSettings_FX");
            });

            modelBuilder.Entity<EndUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.ChannelId)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCd)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.ExpirateDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogOnDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.LockedCd)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LockedDt).HasColumnType("datetime");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MotherMname)
                    .HasColumnName("MotherMName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserTypeCd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.EndUser)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("EndUser_DomainId_Domain_FX");

                entity.HasOne(d => d.UserEntity)
                    .WithMany(p => p.EndUser)
                    .HasForeignKey(d => d.UserEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EndUser_UserEntityId_UserEntity_FX");
            });

            modelBuilder.Entity<Ipaddress>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FromIpaddress });

                entity.ToTable("IPAddress");

                entity.Property(e => e.FromIpaddress)
                    .HasColumnName("FromIPAddress")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ToIpaddress)
                    .HasColumnName("ToIPAddress")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ipaddress)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("TerminalIP_UserId_EndUser_FX");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasIndex(e => e.ProfileCd)
                    .HasName("Profile_ProfileCd_IDX")
                    .IsUnique();

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileCd)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("_FXProfile_DomainId_Domain_FX");

                entity.HasOne(d => d.UserEntity)
                    .WithMany(p => p.Profile)
                    .HasForeignKey(d => d.UserEntityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Profile_UserEntityId_UserEntity_FX");
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.UserEntityTypeCd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserEntityPermissionsAccess>(entity =>
            {
                entity.HasKey(e => new { e.UserEntityId, e.AccessEntityId });

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.HasOne(d => d.AccessEntity)
                    .WithMany(p => p.UserEntityPermissionsAccess)
                    .HasForeignKey(d => d.AccessEntityId)
                    .HasConstraintName("UserEntityAccessActions_AccessEntityId_AccessEntity_FX");

                entity.HasOne(d => d.UserEntity)
                    .WithMany(p => p.UserEntityPermissionsAccess)
                    .HasForeignKey(d => d.UserEntityId)
                    .HasConstraintName("UserEntityAccessActions_UserEntityId_UserEntity_FX");
            });

            modelBuilder.Entity<UserProfiles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProfileId });

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserProfiles_ProfileId_Profile_FX");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserProfiles_UserId_EndUser_FX");
            });

            modelBuilder.Entity<UserPwdHistoryLog>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RegistrationDt });

                entity.Property(e => e.RegistrationDt).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPwdHistoryLog)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserPwdHistoryLog_UserId_EndUser_FX");
            });

            modelBuilder.Entity<UserSettings>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.SettingId });

                entity.Property(e => e.CreationDt).HasColumnType("datetime");

                entity.Property(e => e.LastModBy)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModDt).HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Setting)
                    .WithMany(p => p.UserSettings)
                    .HasForeignKey(d => d.SettingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserSettings_SettingId_CatUserSettings_FX");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSettings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserSettings_UserId_EndUser_FX");
            });
        }
    }
}
