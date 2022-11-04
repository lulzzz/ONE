using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ONE.DataAccess.Models
{
    public partial class ONEContext : DbContext
    {
        public ONEContext()
        {
        }

        public ONEContext(DbContextOptions<ONEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveEventFlowExecutionTracking> ActiveEventFlowExecutionTrackings { get; set; }
        public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerLocation> CustomerLocations { get; set; }
        public virtual DbSet<CustomerLocationSection> CustomerLocationSections { get; set; }
        public virtual DbSet<EventFlow> EventFlows { get; set; }
        public virtual DbSet<EventFlowApplicationTypeInitiatorType> EventFlowApplicationTypeInitiatorTypes { get; set; }
        public virtual DbSet<EventInterpreterType> EventInterpreterTypes { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<Initiator> Initiators { get; set; }
        public virtual DbSet<InitiatorType> InitiatorTypes { get; set; }
        public virtual DbSet<MarketType> MarketTypes { get; set; }
        public virtual DbSet<MicrolocationType> MicrolocationTypes { get; set; }
        public virtual DbSet<ProtocolType> ProtocolTypes { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<SystemIo> SystemIos { get; set; }
        public virtual DbSet<SystemIobaseType> SystemIobaseTypes { get; set; }
        public virtual DbSet<SystemIotype> SystemIotypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=ONE;Persist Security Info=True;User ID=ONEDbUser;Password=Thetoerails.;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveEventFlowExecutionTracking>(entity =>
            {
                entity.HasKey(e => e.ActiveEventFlowExecutionTrackingGuid);

                entity.ToTable("ActiveEventFlowExecutionTracking");

                entity.Property(e => e.ActiveEventFlowExecutionTrackingGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ActiveEventFlowExecutionTrackingGUID");

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.Property(e => e.EventFlowLogDetailXml)
                    .HasColumnType("xml")
                    .HasColumnName("EventFlowLogDetailXML");

                entity.Property(e => e.EventFlowXml).HasColumnType("xml");

                entity.Property(e => e.EventInstanceGuid).HasColumnName("EventInstanceGUID");

                entity.Property(e => e.HaltedByEventFlowInstanceGuid).HasColumnName("HaltedByEventFlowInstanceGUID");

                entity.Property(e => e.InitiatorGuid).HasColumnName("InitiatorGUID");

                entity.Property(e => e.TriggeredByEventFlowInstanceGuid).HasColumnName("TriggeredByEventFlowInstanceGUID");

                entity.HasOne(d => d.EventFlowGu)
                    .WithMany(p => p.ActiveEventFlowExecutionTrackings)
                    .HasForeignKey(d => d.EventFlowGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveEventFlowExecutionTracking_EventFlow");

                entity.HasOne(d => d.EventTypeCodeNavigation)
                    .WithMany(p => p.ActiveEventFlowExecutionTrackings)
                    .HasForeignKey(d => d.EventTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveEventFlowExecutionTracking_EventType");

                entity.HasOne(d => d.InitiatorGu)
                    .WithMany(p => p.ActiveEventFlowExecutionTrackings)
                    .HasForeignKey(d => d.InitiatorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveEventFlowExecutionTracking_Initiator");
            });

            modelBuilder.Entity<ApplicationType>(entity =>
            {
                entity.HasKey(e => e.ApplicationTypeCode);

                entity.ToTable("ApplicationType");

                entity.Property(e => e.ApplicationTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasMany(d => d.InitiatorTypeCodes)
                    .WithMany(p => p.ApplicationTypeCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "ApplicationTypeInitiatorType",
                        l => l.HasOne<InitiatorType>().WithMany().HasForeignKey("InitiatorTypeCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ApplicationTypeInitiatorType_InitiatorType"),
                        r => r.HasOne<ApplicationType>().WithMany().HasForeignKey("ApplicationTypeCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ApplicationTypeInitiatorType_ApplicationType"),
                        j =>
                        {
                            j.HasKey("ApplicationTypeCode", "InitiatorTypeCode");

                            j.ToTable("ApplicationTypeInitiatorType");
                        });
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerGuid);

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerGUID");

                entity.Property(e => e.CustomerLogo).IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.MarketTypeCodeNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.MarketTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_MarketType");
            });

            modelBuilder.Entity<CustomerLocation>(entity =>
            {
                entity.HasKey(e => e.CustomerLocationGuid);

                entity.ToTable("CustomerLocation");

                entity.Property(e => e.CustomerLocationGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerLocationGUID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerGuid).HasColumnName("CustomerGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerGu)
                    .WithMany(p => p.CustomerLocations)
                    .HasForeignKey(d => d.CustomerGuid)
                    .HasConstraintName("FK_CustomerLocation_Customer");

                entity.HasOne(d => d.StateCodeNavigation)
                    .WithMany(p => p.CustomerLocations)
                    .HasForeignKey(d => d.StateCode)
                    .HasConstraintName("FK_CustomerLocation_State");
            });

            modelBuilder.Entity<CustomerLocationSection>(entity =>
            {
                entity.HasKey(e => e.CustomerLocationSectionGuid);

                entity.ToTable("CustomerLocationSection");

                entity.Property(e => e.CustomerLocationSectionGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerLocationSectionGUID");

                entity.Property(e => e.CapcodePlanSystemOutputGuid).HasColumnName("CAPCodePlanSystemOutputGUID");

                entity.Property(e => e.CapcodePlanSystemOutputGuid2).HasColumnName("CAPCodePlanSystemOutputGUID2");

                entity.Property(e => e.CapcodePlanSystemOutputGuid3).HasColumnName("CAPCodePlanSystemOutputGUID3");

                entity.Property(e => e.CustomerLocationGuid).HasColumnName("CustomerLocationGUID");

                entity.Property(e => e.CustomerLocationSectionDisplayAs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLocationSectionPronounceAs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RadioChannelGuid).HasColumnName("RadioChannelGUID");

                entity.Property(e => e.RadioChannelGuid2).HasColumnName("RadioChannelGUID2");

                entity.Property(e => e.RadioChannelGuid3).HasColumnName("RadioChannelGUID3");

                entity.Property(e => e.ReportAs).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerLocationGu)
                    .WithMany(p => p.CustomerLocationSections)
                    .HasForeignKey(d => d.CustomerLocationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerLocationSection_CustomerLocation");
            });

            modelBuilder.Entity<EventFlow>(entity =>
            {
                entity.HasKey(e => e.EventFlowGuid);

                entity.ToTable("EventFlow");

                entity.Property(e => e.EventFlowGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("EventFlowGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EventFlowXml)
                    .HasColumnType("xml")
                    .HasColumnName("EventFlowXML");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<EventFlowApplicationTypeInitiatorType>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationTypeCode, e.InitiatorTypeCode, e.EventFlowGuid });

                entity.ToTable("EventFlowApplicationTypeInitiatorType");

                entity.HasOne(d => d.ApplicationTypeCodeNavigation)
                    .WithMany(p => p.EventFlowApplicationTypeInitiatorTypes)
                    .HasForeignKey(d => d.ApplicationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventFlowApplicationTypeInitiatorType_ApplicationType");

                entity.HasOne(d => d.EventFlowGu)
                    .WithMany(p => p.EventFlowApplicationTypeInitiatorTypes)
                    .HasForeignKey(d => d.EventFlowGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventFlowApplicationTypeInitiatorType_EventFlow");

                entity.HasOne(d => d.InitiatorTypeCodeNavigation)
                    .WithMany(p => p.EventFlowApplicationTypeInitiatorTypes)
                    .HasForeignKey(d => d.InitiatorTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventFlowApplicationTypeInitiatorType_InitiatorType");
            });

            modelBuilder.Entity<EventInterpreterType>(entity =>
            {
                entity.HasKey(e => e.EventInterpreterTypeCode);

                entity.ToTable("EventInterpreterType");

                entity.Property(e => e.EventInterpreterTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProtocolTypecodeNavigation)
                    .WithMany(p => p.EventInterpreterTypes)
                    .HasForeignKey(d => d.ProtocolTypecode)
                    .HasConstraintName("FK_ProtocolType_ProtocolTypeCode");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.EventTypeCode);

                entity.ToTable("EventType");

                entity.Property(e => e.EventTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Initiator>(entity =>
            {
                entity.HasKey(e => e.InitiatorGuid);

                entity.ToTable("Initiator");

                entity.Property(e => e.InitiatorGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("InitiatorGUID");

                entity.Property(e => e.ApplicationTypeEventTypeAliasConfigurationGuid).HasColumnName("ApplicationTypeEventTypeAliasConfigurationGUID");

                entity.Property(e => e.CustomerLocationSectionGuid).HasColumnName("CustomerLocationSectionGUID");

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.Property(e => e.InitiatorConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("InitiatorConfigurationDataXML");

                entity.Property(e => e.InitiatorOperationalDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("InitiatorOperationalDataXML");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.ApplicationTypeCodeNavigation)
                    .WithMany(p => p.Initiators)
                    .HasForeignKey(d => d.ApplicationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Initiator_ApplicationType");

                entity.HasOne(d => d.CustomerLocationSectionGu)
                    .WithMany(p => p.Initiators)
                    .HasForeignKey(d => d.CustomerLocationSectionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Initiator_CustomerLocationSection");

                entity.HasOne(d => d.EventFlowGu)
                    .WithMany(p => p.Initiators)
                    .HasForeignKey(d => d.EventFlowGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Initiator_EventFlow");

                entity.HasOne(d => d.InitiatorTypeCodeNavigation)
                    .WithMany(p => p.Initiators)
                    .HasForeignKey(d => d.InitiatorTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Initiator_InitiatorType");

                entity.HasOne(d => d.MicrolocationTypeCodeNavigation)
                    .WithMany(p => p.Initiators)
                    .HasForeignKey(d => d.MicrolocationTypeCode)
                    .HasConstraintName("FK_Initiator_MicrolocationType");

                entity.HasOne(d => d.StatusTypeCodeNavigation)
                    .WithMany(p => p.Initiators)
                    .HasForeignKey(d => d.StatusTypeCode)
                    .HasConstraintName("FK_Initiator_StatusType");
            });

            modelBuilder.Entity<InitiatorType>(entity =>
            {
                entity.HasKey(e => e.InitiatorTypeCode);

                entity.ToTable("InitiatorType");

                entity.Property(e => e.InitiatorTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MarketType>(entity =>
            {
                entity.HasKey(e => e.MarketTypeCode);

                entity.ToTable("MarketType");

                entity.Property(e => e.MarketTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MicrolocationType>(entity =>
            {
                entity.HasKey(e => e.MicrolocationTypeCode);

                entity.ToTable("MicrolocationType");

                entity.Property(e => e.MicrolocationTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProtocolType>(entity =>
            {
                entity.HasKey(e => e.ProtocolTypeCode);

                entity.ToTable("ProtocolType");

                entity.Property(e => e.ProtocolTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.StateCode);

                entity.ToTable("State");

                entity.Property(e => e.StateCode).ValueGeneratedNever();

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusType>(entity =>
            {
                entity.HasKey(e => e.StatusTypeCode);

                entity.ToTable("StatusType");

                entity.Property(e => e.StatusTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemIo>(entity =>
            {
                entity.HasKey(e => e.SystemIoguid);

                entity.ToTable("SystemIO");

                entity.Property(e => e.SystemIoguid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemIOGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SystemIoconfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("SystemIOConfigurationDataXML");

                entity.Property(e => e.SystemIotypeCode).HasColumnName("SystemIOTypeCode");

                entity.HasOne(d => d.SystemIotypeCodeNavigation)
                    .WithMany(p => p.SystemIos)
                    .HasForeignKey(d => d.SystemIotypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemIO_SystemIOType");
            });

            modelBuilder.Entity<SystemIobaseType>(entity =>
            {
                entity.HasKey(e => e.SystemIobaseTypeCode);

                entity.ToTable("SystemIOBaseType");

                entity.Property(e => e.SystemIobaseTypeCode)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemIOBaseTypeCode");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemIotype>(entity =>
            {
                entity.HasKey(e => e.SystemIotypeCode);

                entity.ToTable("SystemIOType");

                entity.Property(e => e.SystemIotypeCode)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemIOTypeCode");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SystemIobaseTypeCode).HasColumnName("SystemIOBaseTypeCode");

                entity.HasOne(d => d.SystemIobaseTypeCodeNavigation)
                    .WithMany(p => p.SystemIotypes)
                    .HasForeignKey(d => d.SystemIobaseTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemIOType_SystemIOBaseType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
