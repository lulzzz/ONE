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

        public virtual DbSet<ActiveAlarmDashboardCache> ActiveAlarmDashboardCaches { get; set; }
        public virtual DbSet<ActiveAlarmTracking> ActiveAlarmTrackings { get; set; }
        public virtual DbSet<ActiveAlarmTrackingHistory> ActiveAlarmTrackingHistories { get; set; }
        public virtual DbSet<ActiveAlarmUserActionTracking> ActiveAlarmUserActionTrackings { get; set; }
        public virtual DbSet<ActiveAlarmUserActionType> ActiveAlarmUserActionTypes { get; set; }
        public virtual DbSet<ActiveCustomScreenFragmentCache> ActiveCustomScreenFragmentCaches { get; set; }
        public virtual DbSet<ActiveEventFlowExecutionTracking> ActiveEventFlowExecutionTrackings { get; set; }
        public virtual DbSet<Appliance> Appliances { get; set; }
        public virtual DbSet<ApplianceFeatureOptionType> ApplianceFeatureOptionTypes { get; set; }
        public virtual DbSet<ApplianceType> ApplianceTypes { get; set; }
        public virtual DbSet<ApplianceTypeFeatureOptionType> ApplianceTypeFeatureOptionTypes { get; set; }
        public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }
        public virtual DbSet<ApplicationTypeDefaultInitiatorType> ApplicationTypeDefaultInitiatorTypes { get; set; }
        public virtual DbSet<ApplicationTypeEventTypeAliasConfiguration> ApplicationTypeEventTypeAliasConfigurations { get; set; }
        public virtual DbSet<ApplicationTypeEventTypeAliasConfigurationDetail> ApplicationTypeEventTypeAliasConfigurationDetails { get; set; }
        public virtual DbSet<ApplicationTypeMatchType> ApplicationTypeMatchTypes { get; set; }
        public virtual DbSet<ApplicationTypeOutputNodeType> ApplicationTypeOutputNodeTypes { get; set; }
        public virtual DbSet<ArchiveEventFlowLog> ArchiveEventFlowLogs { get; set; }
        public virtual DbSet<BatchArchive> BatchArchives { get; set; }
        public virtual DbSet<BatchArchiveConfiguration> BatchArchiveConfigurations { get; set; }
        public virtual DbSet<BatchArchiveDetail> BatchArchiveDetails { get; set; }
        public virtual DbSet<BaudRateType> BaudRateTypes { get; set; }
        public virtual DbSet<BlocklyBlock> BlocklyBlocks { get; set; }
        public virtual DbSet<BlocklyBlockApplicationTypeInitiatorType> BlocklyBlockApplicationTypeInitiatorTypes { get; set; }
        public virtual DbSet<BlocklyBlockCategoryType> BlocklyBlockCategoryTypes { get; set; }
        public virtual DbSet<BlocklyBlockType> BlocklyBlockTypes { get; set; }
        public virtual DbSet<CustomScreen> CustomScreens { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerLocation> CustomerLocations { get; set; }
        public virtual DbSet<CustomerLocationSection> CustomerLocationSections { get; set; }
        public virtual DbSet<CustomerLocationSectionAudit> CustomerLocationSectionAudits { get; set; }
        public virtual DbSet<DailyTimeSpanSegment> DailyTimeSpanSegments { get; set; }
        public virtual DbSet<DashboardAlarmStateTransitionConfiguration> DashboardAlarmStateTransitionConfigurations { get; set; }
        public virtual DbSet<DashboardDisposition> DashboardDispositions { get; set; }
        public virtual DbSet<DashboardDispositionType> DashboardDispositionTypes { get; set; }
        public virtual DbSet<DataBitsType> DataBitsTypes { get; set; }
        public virtual DbSet<DatabaseVersionScript> DatabaseVersionScripts { get; set; }
        public virtual DbSet<EnterpriseScheduledBroadcastInitiator> EnterpriseScheduledBroadcastInitiators { get; set; }
        public virtual DbSet<EventFlow> EventFlows { get; set; }
        public virtual DbSet<EventFlowApplicationTypeInitiatorType> EventFlowApplicationTypeInitiatorTypes { get; set; }
        public virtual DbSet<EventFlowAudit> EventFlowAudits { get; set; }
        public virtual DbSet<EventFlowCompletionType> EventFlowCompletionTypes { get; set; }
        public virtual DbSet<EventFlowLog> EventFlowLogs { get; set; }
        public virtual DbSet<EventFlowLogDetail> EventFlowLogDetails { get; set; }
        public virtual DbSet<EventFlowTemplate> EventFlowTemplates { get; set; }
        public virtual DbSet<EventInterpreterTrackedMessage> EventInterpreterTrackedMessages { get; set; }
        public virtual DbSet<EventInterpreterType> EventInterpreterTypes { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<EveryWayChannel> EveryWayChannels { get; set; }
        public virtual DbSet<FahrenheitIdentificationType> FahrenheitIdentificationTypes { get; set; }
        public virtual DbSet<FeatureOptionType> FeatureOptionTypes { get; set; }
        public virtual DbSet<FlowType> FlowTypes { get; set; }
        public virtual DbSet<FontAwesomeType> FontAwesomeTypes { get; set; }
        public virtual DbSet<FragmentLog> FragmentLogs { get; set; }
        public virtual DbSet<GenericRoutingCodeActivationClearMatchType> GenericRoutingCodeActivationClearMatchTypes { get; set; }
        public virtual DbSet<HttpAuthenticationType> HttpAuthenticationTypes { get; set; }
        public virtual DbSet<Initiator> Initiators { get; set; }
        public virtual DbSet<InitiatorAudit> InitiatorAudits { get; set; }
        public virtual DbSet<InitiatorType> InitiatorTypes { get; set; }
        public virtual DbSet<IntentConfiguration> IntentConfigurations { get; set; }
        public virtual DbSet<IntentRecognitionEntity> IntentRecognitionEntities { get; set; }
        public virtual DbSet<IntentRecognitionEntityType> IntentRecognitionEntityTypes { get; set; }
        public virtual DbSet<IntentRecognitionFeatureType> IntentRecognitionFeatureTypes { get; set; }
        public virtual DbSet<IntentRecognitionMachineLearnedPhrase> IntentRecognitionMachineLearnedPhrases { get; set; }
        public virtual DbSet<IntentType> IntentTypes { get; set; }
        public virtual DbSet<KeyPerformanceIndicatorType> KeyPerformanceIndicatorTypes { get; set; }
        public virtual DbSet<MarketType> MarketTypes { get; set; }
        public virtual DbSet<MatchType> MatchTypes { get; set; }
        public virtual DbSet<MicrolocationType> MicrolocationTypes { get; set; }
        public virtual DbSet<OutputDevice> OutputDevices { get; set; }
        public virtual DbSet<OutputNode> OutputNodes { get; set; }
        public virtual DbSet<OutputNodeAudit> OutputNodeAudits { get; set; }
        public virtual DbSet<OutputNodeType> OutputNodeTypes { get; set; }
        public virtual DbSet<ParityType> ParityTypes { get; set; }
        public virtual DbSet<PassKeyReferenceType> PassKeyReferenceTypes { get; set; }
        public virtual DbSet<PccDispositionSyncTracking> PccDispositionSyncTrackings { get; set; }
        public virtual DbSet<PccPatientCustomerLocationSection> PccPatientCustomerLocationSections { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonFahrenheit> PersonFahrenheits { get; set; }
        public virtual DbSet<PersonGroup> PersonGroups { get; set; }
        public virtual DbSet<PersonGroupFahrenheit> PersonGroupFahrenheits { get; set; }
        public virtual DbSet<PersonGroupReasonForEntryType> PersonGroupReasonForEntryTypes { get; set; }
        public virtual DbSet<PersonGroupScreeningQuestionnaire> PersonGroupScreeningQuestionnaires { get; set; }
        public virtual DbSet<PersonPreScreeningQuestionnaireResponse> PersonPreScreeningQuestionnaireResponses { get; set; }
        public virtual DbSet<PersonPreScreeningResponse> PersonPreScreeningResponses { get; set; }
        public virtual DbSet<PersonScreeningQuestionnaireResponse> PersonScreeningQuestionnaireResponses { get; set; }
        public virtual DbSet<PersonScreeningResult> PersonScreeningResults { get; set; }
        public virtual DbSet<PersonSurveyQuestionnaireResponse> PersonSurveyQuestionnaireResponses { get; set; }
        public virtual DbSet<PersonTemperatureTerminal> PersonTemperatureTerminals { get; set; }
        public virtual DbSet<PrerecordedAudioClip> PrerecordedAudioClips { get; set; }
        public virtual DbSet<ProductTypeInitiatorTypeProvisionInterpreter> ProductTypeInitiatorTypeProvisionInterpreters { get; set; }
        public virtual DbSet<ProtocolType> ProtocolTypes { get; set; }
        public virtual DbSet<ProvisionOption> ProvisionOptions { get; set; }
        public virtual DbSet<ProvisionOptionApplianceTypeCodeSystemInput> ProvisionOptionApplianceTypeCodeSystemInputs { get; set; }
        public virtual DbSet<ProvisionOptionApplianceTypeCodeSystemOutput> ProvisionOptionApplianceTypeCodeSystemOutputs { get; set; }
        public virtual DbSet<ProvisionOptionApplianceTypeEventFlow> ProvisionOptionApplianceTypeEventFlows { get; set; }
        public virtual DbSet<PttappChannel> PttappChannels { get; set; }
        public virtual DbSet<PttappChannelPlan> PttappChannelPlans { get; set; }
        public virtual DbSet<PttappChatMessage> PttappChatMessages { get; set; }
        public virtual DbSet<PttappChatRoom> PttappChatRooms { get; set; }
        public virtual DbSet<PttappChatRoomSystemUser> PttappChatRoomSystemUsers { get; set; }
        public virtual DbSet<PttappScanType> PttappScanTypes { get; set; }
        public virtual DbSet<RadioModelType> RadioModelTypes { get; set; }
        public virtual DbSet<ReasonForEntryType> ReasonForEntryTypes { get; set; }
        public virtual DbSet<ReportPeriodType> ReportPeriodTypes { get; set; }
        public virtual DbSet<ReportScheduler> ReportSchedulers { get; set; }
        public virtual DbSet<ScreeningQuestionnaire> ScreeningQuestionnaires { get; set; }
        public virtual DbSet<ScreeningResultReportStatusFilter> ScreeningResultReportStatusFilters { get; set; }
        public virtual DbSet<ScreeningStatusType> ScreeningStatusTypes { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<StopBitsType> StopBitsTypes { get; set; }
        public virtual DbSet<SurveyQuestionnaire> SurveyQuestionnaires { get; set; }
        public virtual DbSet<SystemConfigurationType> SystemConfigurationTypes { get; set; }
        public virtual DbSet<SystemContentGroup> SystemContentGroups { get; set; }
        public virtual DbSet<SystemFunctionPermissionType> SystemFunctionPermissionTypes { get; set; }
        public virtual DbSet<SystemHealthDashboardCache> SystemHealthDashboardCaches { get; set; }
        public virtual DbSet<SystemInput> SystemInputs { get; set; }
        public virtual DbSet<SystemInputAudit> SystemInputAudits { get; set; }
        public virtual DbSet<SystemInputType> SystemInputTypes { get; set; }
        public virtual DbSet<SystemIo> SystemIos { get; set; }
        public virtual DbSet<SystemIobaseType> SystemIobaseTypes { get; set; }
        public virtual DbSet<SystemIotype> SystemIotypes { get; set; }
        public virtual DbSet<SystemOutput> SystemOutputs { get; set; }
        public virtual DbSet<SystemOutputAudit> SystemOutputAudits { get; set; }
        public virtual DbSet<SystemOutputCategoryType> SystemOutputCategoryTypes { get; set; }
        public virtual DbSet<SystemOutputType> SystemOutputTypes { get; set; }
        public virtual DbSet<SystemOutputTypeRadioModelType> SystemOutputTypeRadioModelTypes { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<SystemUserAudit> SystemUserAudits { get; set; }
        public virtual DbSet<TemperatureDetectorEventLog> TemperatureDetectorEventLogs { get; set; }
        public virtual DbSet<TemperatureMonitorEventLog> TemperatureMonitorEventLogs { get; set; }
        public virtual DbSet<TemperatureTerminalPersonBatch> TemperatureTerminalPersonBatches { get; set; }
        public virtual DbSet<TemperatureTerminalPersonBatchDetail> TemperatureTerminalPersonBatchDetails { get; set; }
        public virtual DbSet<TemperatureTerminalSyncTracking> TemperatureTerminalSyncTrackings { get; set; }
        public virtual DbSet<TextSubstitution> TextSubstitutions { get; set; }
        public virtual DbSet<TextSubstitutionAudit> TextSubstitutionAudits { get; set; }
        public virtual DbSet<ThermalBufferType> ThermalBufferTypes { get; set; }
        public virtual DbSet<ThermistorProbeType> ThermistorProbeTypes { get; set; }
        public virtual DbSet<ThermistorProbeTypeRtcurveDataItem> ThermistorProbeTypeRtcurveDataItems { get; set; }
        public virtual DbSet<ThermistorProbeTypeThermalBufferType> ThermistorProbeTypeThermalBufferTypes { get; set; }
        public virtual DbSet<UserRoleType> UserRoleTypes { get; set; }
        public virtual DbSet<UserRoleTypeSystemFunctionPermissionType> UserRoleTypeSystemFunctionPermissionTypes { get; set; }
        public virtual DbSet<UserSystemConfiguration> UserSystemConfigurations { get; set; }
        public virtual DbSet<XmldataTemplate> XmldataTemplates { get; set; }

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
            modelBuilder.Entity<ActiveAlarmDashboardCache>(entity =>
            {
                entity.HasKey(e => e.ActiveAlarmDashboardCacheGuid);

                entity.ToTable("ActiveAlarmDashboardCache");

                entity.Property(e => e.ActiveAlarmDashboardCacheGuid).ValueGeneratedNever();

                entity.Property(e => e.ActivationDateTime).HasColumnType("datetime");

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EventTypeCodeNavigation)
                    .WithMany(p => p.ActiveAlarmDashboardCaches)
                    .HasForeignKey(d => d.EventTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveAlarmDashboardCache_EventType");

                entity.HasOne(d => d.InitiatorGu)
                    .WithMany(p => p.ActiveAlarmDashboardCaches)
                    .HasForeignKey(d => d.InitiatorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveAlarmDashboardCache_Initiator");
            });

            modelBuilder.Entity<ActiveAlarmTracking>(entity =>
            {
                entity.HasKey(e => e.ActiveAlarmTrackingGuid);

                entity.ToTable("ActiveAlarmTracking");

                entity.Property(e => e.ActiveAlarmTrackingGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ActiveAlarmTrackingGUID");

                entity.Property(e => e.AlarmEndTime).HasColumnType("datetime");

                entity.Property(e => e.AlarmStartTime).HasColumnType("datetime");

                entity.Property(e => e.AssociatedSystemUserGuid).HasColumnName("AssociatedSystemUserGUID");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DashboardDispositionGuid).HasColumnName("DashboardDispositionGUID");

                entity.Property(e => e.EventInstanceGuid).HasColumnName("EventInstanceGUID");

                entity.Property(e => e.InitiatorGuid).HasColumnName("InitiatorGUID");

                entity.Property(e => e.SaveAudioMessageGuid).HasColumnName("SaveAudioMessageGUID");

                entity.HasOne(d => d.AssociatedSystemUserGu)
                    .WithMany(p => p.ActiveAlarmTrackings)
                    .HasForeignKey(d => d.AssociatedSystemUserGuid)
                    .HasConstraintName("FK_ActiveAlarmTracking_SystemUser");

                entity.HasOne(d => d.DashboardDispositionGu)
                    .WithMany(p => p.ActiveAlarmTrackings)
                    .HasForeignKey(d => d.DashboardDispositionGuid)
                    .HasConstraintName("FK_ActiveAlarmTracking_DashboardDisposition");

                entity.HasOne(d => d.EventTypeCodeNavigation)
                    .WithMany(p => p.ActiveAlarmTrackings)
                    .HasForeignKey(d => d.EventTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveAlarmTracking_EventType");

                entity.HasOne(d => d.InitiatorGu)
                    .WithMany(p => p.ActiveAlarmTrackings)
                    .HasForeignKey(d => d.InitiatorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveAlarmTracking_Initiator");
            });

            modelBuilder.Entity<ActiveAlarmTrackingHistory>(entity =>
            {
                entity.HasKey(e => e.ActiveAlarmTrackingHistoryGuid);

                entity.ToTable("ActiveAlarmTrackingHistory");

                entity.Property(e => e.ActiveAlarmTrackingHistoryGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ActiveAlarmTrackingHistoryGUID");

                entity.Property(e => e.AlarmEndTime).HasColumnType("datetime");

                entity.Property(e => e.AlarmStartTime).HasColumnType("datetime");

                entity.Property(e => e.AssociatedSystemUserGuid).HasColumnName("AssociatedSystemUserGUID");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DashboardDispositionGuid).HasColumnName("DashboardDispositionGUID");

                entity.Property(e => e.EventInstanceGuid).HasColumnName("EventInstanceGUID");

                entity.Property(e => e.InitiatorGuid).HasColumnName("InitiatorGUID");

                entity.Property(e => e.SaveAudioMessageGuid).HasColumnName("SaveAudioMessageGUID");

                entity.HasOne(d => d.AssociatedSystemUserGu)
                    .WithMany(p => p.ActiveAlarmTrackingHistories)
                    .HasForeignKey(d => d.AssociatedSystemUserGuid)
                    .HasConstraintName("FK_ActiveAlarmTrackingHistory_SystemUser");

                entity.HasOne(d => d.DashboardDispositionGu)
                    .WithMany(p => p.ActiveAlarmTrackingHistories)
                    .HasForeignKey(d => d.DashboardDispositionGuid)
                    .HasConstraintName("FK_ActiveAlarmTrackingHistory_DashboardDisposition");

                entity.HasOne(d => d.EventTypeCodeNavigation)
                    .WithMany(p => p.ActiveAlarmTrackingHistories)
                    .HasForeignKey(d => d.EventTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveAlarmTrackingHistory_EventType");

                entity.HasOne(d => d.InitiatorGu)
                    .WithMany(p => p.ActiveAlarmTrackingHistories)
                    .HasForeignKey(d => d.InitiatorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveAlarmTrackingHistory_Initiator");
            });

            modelBuilder.Entity<ActiveAlarmUserActionTracking>(entity =>
            {
                entity.HasKey(e => e.ActiveAlarmUserActionTrackingGuid);

                entity.ToTable("ActiveAlarmUserActionTracking");

                entity.Property(e => e.ActiveAlarmUserActionTrackingGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ActiveAlarmUserActionTrackingGUID");

                entity.HasOne(d => d.ActiveAlarmTrackingGu)
                    .WithMany(p => p.ActiveAlarmUserActionTrackings)
                    .HasForeignKey(d => d.ActiveAlarmTrackingGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveAlarmUserActionTracking_ActiveAlarmTracking");

                entity.HasOne(d => d.ActiveAlarmUserActionTypeCodeNavigation)
                    .WithMany(p => p.ActiveAlarmUserActionTrackings)
                    .HasForeignKey(d => d.ActiveAlarmUserActionTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveAlarmUserActionTracking_ActiveAlarmUserActionType");

                entity.HasOne(d => d.AssociatedSystemUserGu)
                    .WithMany(p => p.ActiveAlarmUserActionTrackings)
                    .HasForeignKey(d => d.AssociatedSystemUserGuid)
                    .HasConstraintName("FK_ActiveAlarmUserActionTracking_SystemUser");
            });

            modelBuilder.Entity<ActiveAlarmUserActionType>(entity =>
            {
                entity.HasKey(e => e.ActiveAlarmUserActionTypeCode);

                entity.ToTable("ActiveAlarmUserActionType");

                entity.Property(e => e.ActiveAlarmUserActionTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<ActiveCustomScreenFragmentCache>(entity =>
            {
                entity.HasKey(e => e.ActiveCustomScreenFragmentCacheGuid);

                entity.ToTable("ActiveCustomScreenFragmentCache");

                entity.Property(e => e.ActiveCustomScreenFragmentCacheGuid).ValueGeneratedNever();

                entity.Property(e => e.ActivationDateTime).HasColumnType("datetime");

                entity.Property(e => e.FragmentAreaId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FragmentDesignId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FragmentId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomScreenGu)
                    .WithMany(p => p.ActiveCustomScreenFragmentCaches)
                    .HasForeignKey(d => d.CustomScreenGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActiveCustomScreenFragmentCache_CustomScreen");
            });

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

            modelBuilder.Entity<Appliance>(entity =>
            {
                entity.HasKey(e => e.ApplianceGuid);

                entity.ToTable("Appliance");

                entity.Property(e => e.ApplianceGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ApplianceGUID");

                entity.Property(e => e.ApplianceImageVersion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApplianceIntegrationKey)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsPttserver).HasColumnName("IsPTTServer");

                entity.Property(e => e.LastUpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OdinComputeAppVersion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OdinComputeDatabaseVersion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryNetworkInfo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("This column can hold either IP Address or DNS name of Primary appliance");

                entity.HasOne(d => d.ApplianceTypeCodeNavigation)
                    .WithMany(p => p.Appliances)
                    .HasForeignKey(d => d.ApplianceTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appliance_ApplianceType");

                entity.HasOne(d => d.CustomerLocationGu)
                    .WithMany(p => p.Appliances)
                    .HasForeignKey(d => d.CustomerLocationGuid)
                    .HasConstraintName("FK_Appliance_CustomerLocation");
            });

            modelBuilder.Entity<ApplianceFeatureOptionType>(entity =>
            {
                entity.HasKey(e => new { e.ApplianceGuid, e.FeatureOptionTypeCode });

                entity.ToTable("ApplianceFeatureOptionType");

                entity.Property(e => e.ApplianceGuid).HasColumnName("ApplianceGUID");
            });

            modelBuilder.Entity<ApplianceType>(entity =>
            {
                entity.HasKey(e => e.ApplianceTypeCode);

                entity.ToTable("ApplianceType");

                entity.Property(e => e.ApplianceTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<ApplianceTypeFeatureOptionType>(entity =>
            {
                entity.HasKey(e => new { e.ApplianceTypeCode, e.FeatureOptionTypeCode });

                entity.ToTable("ApplianceTypeFeatureOptionType");
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

            modelBuilder.Entity<ApplicationTypeDefaultInitiatorType>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationTypeCode, e.InitiatorTypeCode, e.Name });

                entity.ToTable("ApplicationTypeDefaultInitiatorType");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationTypeEventTypeAliasConfigurationGuid).HasColumnName("ApplicationTypeEventTypeAliasConfigurationGUID");

                entity.HasOne(d => d.ApplicationTypeCodeNavigation)
                    .WithMany(p => p.ApplicationTypeDefaultInitiatorTypes)
                    .HasForeignKey(d => d.ApplicationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationTypeDefaultInitiatorType_ApplianceType");

                entity.HasOne(d => d.InitiatorTypeCodeNavigation)
                    .WithMany(p => p.ApplicationTypeDefaultInitiatorTypes)
                    .HasForeignKey(d => d.InitiatorTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationTypeDefaultInitiatorType_InitiatorType");
            });

            modelBuilder.Entity<ApplicationTypeEventTypeAliasConfiguration>(entity =>
            {
                entity.HasKey(e => e.ApplicationTypeEventTypeAliasConfigurationGuid);

                entity.ToTable("ApplicationTypeEventTypeAliasConfiguration");

                entity.Property(e => e.ApplicationTypeEventTypeAliasConfigurationGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ApplicationTypeEventTypeAliasConfigurationGUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplicationTypeCodeNavigation)
                    .WithMany(p => p.ApplicationTypeEventTypeAliasConfigurations)
                    .HasForeignKey(d => d.ApplicationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationTypeEventTypeAliasConfiguration_ApplicationTypeCode");
            });

            modelBuilder.Entity<ApplicationTypeEventTypeAliasConfigurationDetail>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationTypeEventTypeAliasConfigurationGuid, e.EventTypeCode });

                entity.Property(e => e.ApplicationTypeEventTypeAliasConfigurationGuid).HasColumnName("ApplicationTypeEventTypeAliasConfigurationGUID");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplicationTypeEventTypeAliasConfigurationGu)
                    .WithMany(p => p.ApplicationTypeEventTypeAliasConfigurationDetails)
                    .HasForeignKey(d => d.ApplicationTypeEventTypeAliasConfigurationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationTypeEventTypeAliasConfigurationDetails_ApplicationTypeEventTypeAliasConfiguration");

                entity.HasOne(d => d.EventTypeCodeNavigation)
                    .WithMany(p => p.ApplicationTypeEventTypeAliasConfigurationDetails)
                    .HasForeignKey(d => d.EventTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationTypeEventTypeAliasConfigurationDetails_EventType");
            });

            modelBuilder.Entity<ApplicationTypeMatchType>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationTypeCode, e.MatchTypeCode });

                entity.ToTable("ApplicationTypeMatchType");
            });

            modelBuilder.Entity<ApplicationTypeOutputNodeType>(entity =>
            {
                entity.HasKey(e => new { e.ApplicationTypeCode, e.OutputNodeTypeCode });

                entity.ToTable("ApplicationTypeOutputNodeType");
            });

            modelBuilder.Entity<ArchiveEventFlowLog>(entity =>
            {
                entity.HasKey(e => e.EventFlowLogGuid);

                entity.ToTable("Archive_EventFlowLog");

                entity.Property(e => e.EventFlowLogGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("EventFlowLogGUID");

                entity.Property(e => e.EventFlowEndUtc).HasColumnType("datetime");

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.Property(e => e.EventFlowStartUtc).HasColumnType("datetime");

                entity.Property(e => e.EventInstanceGuid).HasColumnName("EventInstanceGUID");

                entity.Property(e => e.HaltedByEventFlowInstanceGuid).HasColumnName("HaltedByEventFlowInstanceGUID");

                entity.Property(e => e.InitiatorGuid).HasColumnName("InitiatorGUID");

                entity.Property(e => e.LocationSectionGuid).HasColumnName("LocationSectionGUID");

                entity.Property(e => e.ReportAliasGuid).HasColumnName("ReportAliasGUID");

                entity.Property(e => e.TriggeredByEventFlowInstanceGuid).HasColumnName("TriggeredByEventFlowInstanceGUID");
            });

            modelBuilder.Entity<BatchArchive>(entity =>
            {
                entity.ToTable("BatchArchive");

                entity.Property(e => e.ArchiveEndTime).HasColumnType("datetime");

                entity.Property(e => e.ArchiveError)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ArchiveStartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<BatchArchiveConfiguration>(entity =>
            {
                entity.ToTable("BatchArchiveConfiguration");

                entity.Property(e => e.DelayTime)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BatchArchiveDetail>(entity =>
            {
                entity.ToTable("BatchArchiveDetail");

                entity.HasIndex(e => e.EventFlowLogGuid, "IX_BatchArchiveDetail")
                    .IsUnique();

                entity.Property(e => e.EventFlowLogGuid).HasColumnName("EventFlowLogGUID");

                entity.HasOne(d => d.BatchArchive)
                    .WithMany(p => p.BatchArchiveDetails)
                    .HasForeignKey(d => d.BatchArchiveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BatchArchiveDetail_BatchArchive");
            });

            modelBuilder.Entity<BaudRateType>(entity =>
            {
                entity.HasKey(e => e.BaudRateTypeCode);

                entity.ToTable("BaudRateType");

                entity.Property(e => e.BaudRateTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<BlocklyBlock>(entity =>
            {
                entity.HasKey(e => e.BlocklyBlockCode);

                entity.ToTable("BlocklyBlock");

                entity.Property(e => e.BlocklyBlockCode).ValueGeneratedNever();

                entity.Property(e => e.BlocklyBlockTypeAttribute)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InnerBlockXml)
                    .IsUnicode(false)
                    .HasColumnName("InnerBlockXML");

                entity.HasOne(d => d.BlocklyBlockCategoryTypeCodeNavigation)
                    .WithMany(p => p.BlocklyBlocks)
                    .HasForeignKey(d => d.BlocklyBlockCategoryTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlocklyBlock_BlocklyBlockCategoryType");

                entity.HasOne(d => d.BlocklyBlockTypeCodeNavigation)
                    .WithMany(p => p.BlocklyBlocks)
                    .HasForeignKey(d => d.BlocklyBlockTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlocklyBlock_BlocklyBlockType");
            });

            modelBuilder.Entity<BlocklyBlockApplicationTypeInitiatorType>(entity =>
            {
                entity.HasKey(e => e.BlocklyBlockApplicationTypeInitiatorTypeCode);

                entity.ToTable("BlocklyBlockApplicationTypeInitiatorType");

                entity.Property(e => e.BlocklyBlockApplicationTypeInitiatorTypeCode).ValueGeneratedNever();

                entity.HasOne(d => d.ApplicationTypeCodeNavigation)
                    .WithMany(p => p.BlocklyBlockApplicationTypeInitiatorTypes)
                    .HasForeignKey(d => d.ApplicationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlocklyBlockApplicationTypeInitiatorType_ApplicationType");

                entity.HasOne(d => d.InitiatorTypeCodeNavigation)
                    .WithMany(p => p.BlocklyBlockApplicationTypeInitiatorTypes)
                    .HasForeignKey(d => d.InitiatorTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlocklyBlockApplicationTypeInitiatorType_InitiatorType");
            });

            modelBuilder.Entity<BlocklyBlockCategoryType>(entity =>
            {
                entity.HasKey(e => e.BlocklyBlockCategoryTypeCode);

                entity.ToTable("BlocklyBlockCategoryType");

                entity.Property(e => e.BlocklyBlockCategoryTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<BlocklyBlockType>(entity =>
            {
                entity.HasKey(e => e.BlocklyBlockTypeCode);

                entity.ToTable("BlocklyBlockType");

                entity.Property(e => e.BlocklyBlockTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<CustomScreen>(entity =>
            {
                entity.HasKey(e => e.CustomScreenGuid);

                entity.ToTable("CustomScreen");

                entity.Property(e => e.CustomScreenGuid).ValueGeneratedNever();

                entity.Property(e => e.CustomScreenType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FragmentConfigurationXml).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScreenConfigurationXml).IsUnicode(false);

                entity.Property(e => e.StyleConfigurationXml).IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
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

            modelBuilder.Entity<CustomerLocationSectionAudit>(entity =>
            {
                entity.HasKey(e => e.CustomerLocationSectionAuditGuid);

                entity.ToTable("CustomerLocationSectionAudit");

                entity.Property(e => e.CustomerLocationSectionAuditGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerLocationSectionAuditGUID");

                entity.Property(e => e.Activity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CapcodePlanSystemOutputGuid).HasColumnName("CAPCodePlanSystemOutputGUID");

                entity.Property(e => e.CapcodePlanSystemOutputGuid2).HasColumnName("CAPCodePlanSystemOutputGUID2");

                entity.Property(e => e.CapcodePlanSystemOutputGuid3).HasColumnName("CAPCodePlanSystemOutputGUID3");

                entity.Property(e => e.CustomerLocationGuid).HasColumnName("CustomerLocationGUID");

                entity.Property(e => e.CustomerLocationSectionDisplayAs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLocationSectionGuid).HasColumnName("CustomerLocationSectionGUID");

                entity.Property(e => e.CustomerLocationSectionPronounceAs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RadioChannelGuid).HasColumnName("RadioChannelGUID");

                entity.Property(e => e.RadioChannelGuid2).HasColumnName("RadioChannelGUID2");

                entity.Property(e => e.RadioChannelGuid3).HasColumnName("RadioChannelGUID3");

                entity.Property(e => e.ReportAs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<DailyTimeSpanSegment>(entity =>
            {
                entity.HasKey(e => e.DailyTimeSpanSegmentCode);

                entity.ToTable("DailyTimeSpanSegment");

                entity.Property(e => e.DailyTimeSpanSegmentCode).ValueGeneratedNever();

                entity.Property(e => e.SegmentName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DashboardAlarmStateTransitionConfiguration>(entity =>
            {
                entity.HasKey(e => e.DashboardAlarmStateTransitionConfigurationGuid);

                entity.ToTable("DashboardAlarmStateTransitionConfiguration");

                entity.Property(e => e.DashboardAlarmStateTransitionConfigurationGuid).ValueGeneratedNever();

                entity.Property(e => e.CustomerLocationSectionGuid).HasColumnName("CustomerLocationSectionGUID");

                entity.Property(e => e.PriorityType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State1BackgroundColor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State1Visual)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State2BackgroundColor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State2Visual)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State3BackgroundColor)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State3Visual)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DashboardDisposition>(entity =>
            {
                entity.HasKey(e => e.DashboardDispositionGuid);

                entity.ToTable("DashboardDisposition");

                entity.Property(e => e.DashboardDispositionGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("DashboardDispositionGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.DashboardDispositionTypeCodeNavigation)
                    .WithMany(p => p.DashboardDispositions)
                    .HasForeignKey(d => d.DashboardDispositionTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DashboardDisposition_DashboardDispositionType");
            });

            modelBuilder.Entity<DashboardDispositionType>(entity =>
            {
                entity.HasKey(e => e.DashboardDispositionTypeCode);

                entity.ToTable("DashboardDispositionType");

                entity.Property(e => e.DashboardDispositionTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<DataBitsType>(entity =>
            {
                entity.HasKey(e => e.DataBitsTypeCode);

                entity.ToTable("DataBitsType");

                entity.Property(e => e.DataBitsTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<DatabaseVersionScript>(entity =>
            {
                entity.HasKey(e => e.ScriptGuid);

                entity.ToTable("DatabaseVersionScript");

                entity.HasIndex(e => e.ScriptPath, "UC_ScriptPath")
                    .IsUnique();

                entity.Property(e => e.ScriptGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ScriptGUID");

                entity.Property(e => e.ScriptPath)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EnterpriseScheduledBroadcastInitiator>(entity =>
            {
                entity.HasKey(e => new { e.EnterpriseScheduledBroadcastGuid, e.InitiatorGuid });

                entity.ToTable("EnterpriseScheduledBroadcastInitiator");

                entity.Property(e => e.EnterpriseScheduledBroadcastGuid).HasColumnName("EnterpriseScheduledBroadcastGUID");

                entity.Property(e => e.InitiatorGuid).HasColumnName("InitiatorGUID");
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

            modelBuilder.Entity<EventFlowAudit>(entity =>
            {
                entity.HasKey(e => e.EventFlowAuditGuid);

                entity.ToTable("EventFlowAudit");

                entity.Property(e => e.EventFlowAuditGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("EventFlowAuditGUID");

                entity.Property(e => e.Activity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.Property(e => e.EventFlowXml)
                    .HasColumnType("xml")
                    .HasColumnName("EventFlowXML");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<EventFlowCompletionType>(entity =>
            {
                entity.HasKey(e => e.EventFlowCompletionTypeCode);

                entity.ToTable("EventFlowCompletionType");

                entity.Property(e => e.EventFlowCompletionTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventFlowLog>(entity =>
            {
                entity.HasKey(e => e.EventFlowLogGuid);

                entity.ToTable("EventFlowLog");

                entity.Property(e => e.EventFlowLogGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("EventFlowLogGUID");

                entity.Property(e => e.EventFlowEndUtc).HasColumnType("datetime");

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.Property(e => e.EventFlowStartUtc).HasColumnType("datetime");

                entity.Property(e => e.EventInstanceGuid).HasColumnName("EventInstanceGUID");

                entity.Property(e => e.HaltedByEventFlowInstanceGuid).HasColumnName("HaltedByEventFlowInstanceGUID");

                entity.Property(e => e.InitiatorGuid).HasColumnName("InitiatorGUID");

                entity.Property(e => e.LocationSectionGuid).HasColumnName("LocationSectionGUID");

                entity.Property(e => e.ReportAliasGuid).HasColumnName("ReportAliasGUID");

                entity.Property(e => e.TriggeredByEventFlowInstanceGuid).HasColumnName("TriggeredByEventFlowInstanceGUID");
            });

            modelBuilder.Entity<EventFlowLogDetail>(entity =>
            {
                entity.HasKey(e => e.EventFlowLogDetailGuid);

                entity.ToTable("EventFlowLogDetail");

                entity.Property(e => e.EventFlowLogDetailGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("EventFlowLogDetailGUID");

                entity.Property(e => e.EventFlowLogDetailXml)
                    .HasColumnType("xml")
                    .HasColumnName("EventFlowLogDetailXML");

                entity.Property(e => e.EventFlowLogGuid).HasColumnName("EventFlowLogGUID");

                entity.HasOne(d => d.EventFlowLogGu)
                    .WithMany(p => p.EventFlowLogDetails)
                    .HasForeignKey(d => d.EventFlowLogGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventFlowLogDetail_EventFlowLog");
            });

            modelBuilder.Entity<EventFlowTemplate>(entity =>
            {
                entity.HasKey(e => e.EventFlowTemplateCode);

                entity.ToTable("EventFlowTemplate");

                entity.Property(e => e.EventFlowTemplateCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EventFlowTemplateXml)
                    .HasColumnType("xml")
                    .HasColumnName("EventFlowTemplateXML");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplicationTypeCodeNavigation)
                    .WithMany(p => p.EventFlowTemplates)
                    .HasForeignKey(d => d.ApplicationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventFlowTemplate_ApplicationType");

                entity.HasOne(d => d.InitiatorTypeCodeNavigation)
                    .WithMany(p => p.EventFlowTemplates)
                    .HasForeignKey(d => d.InitiatorTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventFlowTemplate_InitiatorType");
            });

            modelBuilder.Entity<EventInterpreterTrackedMessage>(entity =>
            {
                entity.HasKey(e => e.EventInterpreterTrackedMessageGuid);

                entity.ToTable("EventInterpreterTrackedMessage");

                entity.Property(e => e.EventInterpreterTrackedMessageGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("EventInterpreterTrackedMessageGUID");

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.Property(e => e.EventInstanceGuid).HasColumnName("EventInstanceGUID");

                entity.Property(e => e.EventTrackedDateTime).HasColumnType("datetime");

                entity.Property(e => e.GlobalTrackingGuid).HasColumnName("GlobalTrackingGUID");

                entity.Property(e => e.InitiatorGuid).HasColumnName("InitiatorGUID");
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

            modelBuilder.Entity<EveryWayChannel>(entity =>
            {
                entity.HasKey(e => e.EveryWayChannelGuid);

                entity.ToTable("EveryWayChannel");

                entity.Property(e => e.EveryWayChannelGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("EveryWayChannelGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FahrenheitIdentificationType>(entity =>
            {
                entity.HasKey(e => e.FahrenheitIdentificationTypeCode)
                    .HasName("PK_FahrenheitIdentificationTypeCode");

                entity.ToTable("FahrenheitIdentificationType");

                entity.Property(e => e.FahrenheitIdentificationTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<FeatureOptionType>(entity =>
            {
                entity.HasKey(e => e.FeatureOptionTypeCode);

                entity.ToTable("FeatureOptionType");

                entity.Property(e => e.FeatureOptionTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<FlowType>(entity =>
            {
                entity.HasKey(e => e.FlowTypeCode);

                entity.ToTable("FlowType");

                entity.Property(e => e.FlowTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<FontAwesomeType>(entity =>
            {
                entity.HasKey(e => e.FontAwesomeTypeCode);

                entity.ToTable("FontAwesomeType");

                entity.Property(e => e.FontAwesomeTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FontAwesomeCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FragmentLog>(entity =>
            {
                entity.HasKey(e => e.FragmentLogGuid);

                entity.ToTable("FragmentLog");

                entity.Property(e => e.FragmentLogGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("FragmentLogGUID");

                entity.Property(e => e.FragmentEndUtc).HasColumnType("datetime");

                entity.Property(e => e.FragmentStartUtc).HasColumnType("datetime");

                entity.HasOne(d => d.CustomScreenGu)
                    .WithMany(p => p.FragmentLogs)
                    .HasForeignKey(d => d.CustomScreenGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomScreen");

                entity.HasOne(d => d.InitiatorGu)
                    .WithMany(p => p.FragmentLogs)
                    .HasForeignKey(d => d.InitiatorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Initiator");

                entity.HasOne(d => d.LocationSectionGu)
                    .WithMany(p => p.FragmentLogs)
                    .HasForeignKey(d => d.LocationSectionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationSection");
            });

            modelBuilder.Entity<GenericRoutingCodeActivationClearMatchType>(entity =>
            {
                entity.HasKey(e => e.GenericRoutingCodeActivationClearMatchTypeCode);

                entity.ToTable("GenericRoutingCodeActivationClearMatchType");

                entity.Property(e => e.GenericRoutingCodeActivationClearMatchTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<HttpAuthenticationType>(entity =>
            {
                entity.HasKey(e => e.HttpAuthenticationTypeCode)
                    .HasName("PK__HttpAuth__614DE268154EB88D");

                entity.ToTable("HttpAuthenticationType");

                entity.Property(e => e.HttpAuthenticationTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<InitiatorAudit>(entity =>
            {
                entity.HasKey(e => e.InitiatorAuditGuid);

                entity.ToTable("InitiatorAudit");

                entity.Property(e => e.InitiatorAuditGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("InitiatorAuditGUID");

                entity.Property(e => e.Activity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationTypeEventTypeAliasConfigurationGuid).HasColumnName("ApplicationTypeEventTypeAliasConfigurationGUID");

                entity.Property(e => e.CustomerLocationSectionGuid).HasColumnName("CustomerLocationSectionGUID");

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.Property(e => e.InitiatorConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("InitiatorConfigurationDataXML");

                entity.Property(e => e.InitiatorGuid).HasColumnName("InitiatorGUID");

                entity.Property(e => e.InitiatorOperationalDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("InitiatorOperationalDataXML");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
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

                entity.HasMany(d => d.EventTypeCodes)
                    .WithMany(p => p.InitiatorTypeCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "InitiatorTypeEventType",
                        l => l.HasOne<EventType>().WithMany().HasForeignKey("EventTypeCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InitiatorTypeEventType_EventType"),
                        r => r.HasOne<InitiatorType>().WithMany().HasForeignKey("InitiatorTypeCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_InitiatorTypeEventType_InitiatorType"),
                        j =>
                        {
                            j.HasKey("InitiatorTypeCode", "EventTypeCode");

                            j.ToTable("InitiatorTypeEventType");
                        });
            });

            modelBuilder.Entity<IntentConfiguration>(entity =>
            {
                entity.HasKey(e => e.IntentConfigurationGuid);

                entity.ToTable("IntentConfiguration");

                entity.Property(e => e.IntentConfigurationGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("IntentConfigurationGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IntentConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("IntentConfigurationDataXML");

                entity.Property(e => e.LuisintentId).HasColumnName("LUISIntentId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.IntentTypeCodeNavigation)
                    .WithMany(p => p.IntentConfigurations)
                    .HasForeignKey(d => d.IntentTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntentConfiguration_IntentType");
            });

            modelBuilder.Entity<IntentRecognitionEntity>(entity =>
            {
                entity.HasKey(e => e.IntentRecognitionEntityGuid);

                entity.ToTable("IntentRecognitionEntity");

                entity.Property(e => e.IntentRecognitionEntityGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("IntentRecognitionEntityGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EntityConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("EntityConfigurationDataXML");

                entity.Property(e => e.LuisentityGuid).HasColumnName("LUISEntityGUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ParentIntentRecognitionEntityGuid).HasColumnName("ParentIntentRecognitionEntityGUID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.IntentRecognitionEntityTypeCodeNavigation)
                    .WithMany(p => p.IntentRecognitionEntities)
                    .HasForeignKey(d => d.IntentRecognitionEntityTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IntentRecognitionEntity_IntentRecognitionEntityType");
            });

            modelBuilder.Entity<IntentRecognitionEntityType>(entity =>
            {
                entity.HasKey(e => e.IntentRecognitionEntityTypeCode);

                entity.ToTable("IntentRecognitionEntityType");

                entity.Property(e => e.IntentRecognitionEntityTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<IntentRecognitionFeatureType>(entity =>
            {
                entity.HasKey(e => e.IntentRecognitionFeatureTypeCode);

                entity.ToTable("IntentRecognitionFeatureType");

                entity.Property(e => e.IntentRecognitionFeatureTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<IntentRecognitionMachineLearnedPhrase>(entity =>
            {
                entity.HasKey(e => e.IntentRecognitionMachineLearnedPhraseGuid);

                entity.ToTable("IntentRecognitionMachineLearnedPhrase");

                entity.Property(e => e.IntentRecognitionMachineLearnedPhraseGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("IntentRecognitionMachineLearnedPhraseGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LuisphraseListId).HasColumnName("LUISPhraseListId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<IntentType>(entity =>
            {
                entity.HasKey(e => e.IntentTypeCode);

                entity.ToTable("IntentType");

                entity.Property(e => e.IntentTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<KeyPerformanceIndicatorType>(entity =>
            {
                entity.HasKey(e => new { e.CustomerLocationSectionGuid, e.ApplicationTypeCode });

                entity.ToTable("KeyPerformanceIndicatorType");

                entity.Property(e => e.CustomerLocationSectionGuid).HasColumnName("CustomerLocationSectionGUID");

                entity.HasOne(d => d.ApplicationTypeCodeNavigation)
                    .WithMany(p => p.KeyPerformanceIndicatorTypes)
                    .HasForeignKey(d => d.ApplicationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KeyPerformanceIndicatorType_ApplicationType");

                entity.HasOne(d => d.CustomerLocationSectionGu)
                    .WithMany(p => p.KeyPerformanceIndicatorTypes)
                    .HasForeignKey(d => d.CustomerLocationSectionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KeyPerformanceIndicatorType_CustomerLocationSection");
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

                entity.HasMany(d => d.ApplicationTypeCodes)
                    .WithMany(p => p.MarketTypeCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "MarketTypeApplicationType",
                        l => l.HasOne<ApplicationType>().WithMany().HasForeignKey("ApplicationTypeCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MarketTypeApplicationType_ApplicationType"),
                        r => r.HasOne<MarketType>().WithMany().HasForeignKey("MarketTypeCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_MarketTypeApplicationType_MarketType"),
                        j =>
                        {
                            j.HasKey("MarketTypeCode", "ApplicationTypeCode");

                            j.ToTable("MarketTypeApplicationType");
                        });
            });

            modelBuilder.Entity<MatchType>(entity =>
            {
                entity.HasKey(e => e.MatchTypeCode)
                    .HasName("PK_MatchTypeCode");

                entity.ToTable("MatchType");

                entity.Property(e => e.MatchTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<OutputDevice>(entity =>
            {
                entity.HasKey(e => e.OutputDeviceGuid);

                entity.ToTable("OutputDevice");

                entity.Property(e => e.OutputDeviceGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("OutputDeviceGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OutputNode>(entity =>
            {
                entity.HasKey(e => e.OutputNodeGuid);

                entity.ToTable("OutputNode");

                entity.Property(e => e.OutputNodeGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("OutputNodeGUID");

                entity.Property(e => e.CustomerLocationSectionGuid).HasColumnName("CustomerLocationSectionGUID");

                entity.Property(e => e.OutputNodeConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("OutputNodeConfigurationDataXML");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.ApplicationTypeCodeNavigation)
                    .WithMany(p => p.OutputNodes)
                    .HasForeignKey(d => d.ApplicationTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputNode_ApplicationType");

                entity.HasOne(d => d.CustomerLocationSectionGu)
                    .WithMany(p => p.OutputNodes)
                    .HasForeignKey(d => d.CustomerLocationSectionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputNode_CustomerLocationSection");

                entity.HasOne(d => d.OutputNodeTypeCodeNavigation)
                    .WithMany(p => p.OutputNodes)
                    .HasForeignKey(d => d.OutputNodeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputNode_OutputNodeType");

                entity.HasOne(d => d.StatusTypeCodeNavigation)
                    .WithMany(p => p.OutputNodes)
                    .HasForeignKey(d => d.StatusTypeCode)
                    .HasConstraintName("FK_OutputNode_StatusType");
            });

            modelBuilder.Entity<OutputNodeAudit>(entity =>
            {
                entity.HasKey(e => e.OutputNodeAuditGuid);

                entity.ToTable("OutputNodeAudit");

                entity.Property(e => e.OutputNodeAuditGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("OutputNodeAuditGUID");

                entity.Property(e => e.Activity)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLocationSectionGuid).HasColumnName("CustomerLocationSectionGUID");

                entity.Property(e => e.OutputNodeConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("OutputNodeConfigurationDataXML");

                entity.Property(e => e.OutputNodeGuid).HasColumnName("OutputNodeGUID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<OutputNodeType>(entity =>
            {
                entity.HasKey(e => e.OutputNodeTypeCode);

                entity.ToTable("OutputNodeType");

                entity.Property(e => e.OutputNodeTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParityType>(entity =>
            {
                entity.HasKey(e => e.ParityTypeCode);

                entity.ToTable("ParityType");

                entity.Property(e => e.ParityTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<PassKeyReferenceType>(entity =>
            {
                entity.HasKey(e => e.PassKeyReferenceTypeCode);

                entity.ToTable("PassKeyReferenceType");

                entity.Property(e => e.PassKeyName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PccDispositionSyncTracking>(entity =>
            {
                entity.HasKey(e => e.PccDispositionSyncTrackingGuid)
                    .HasName("PK__PccDispo__A3D263C69AF5F4B2");

                entity.ToTable("PccDispositionSyncTracking");

                entity.Property(e => e.PccDispositionSyncTrackingGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.PccDispositionJsonData)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PccSyncError)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PccPatientCustomerLocationSection>(entity =>
            {
                entity.HasKey(e => e.PccPatientCustomerLocationSectionGuid)
                    .HasName("PK__PccPatie__AFDC256AD0C9CC46");

                entity.ToTable("PccPatientCustomerLocationSection");

                entity.Property(e => e.PccPatientCustomerLocationSectionGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PccPatientId).HasColumnName("PccPatientID");

                entity.HasOne(d => d.CustomerLocationSectionGu)
                    .WithMany(p => p.PccPatientCustomerLocationSections)
                    .HasForeignKey(d => d.CustomerLocationSectionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PccPatien__Custo__6B79F03D");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonGuid)
                    .HasName("PK_People");

                entity.ToTable("Person");

                entity.Property(e => e.PersonGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonGUID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonGroupGuid).HasColumnName("PersonGroupGUID");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceImageBase64).IsUnicode(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.PersonGroupGu)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.PersonGroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Person_PersonGroup");
            });

            modelBuilder.Entity<PersonFahrenheit>(entity =>
            {
                entity.HasKey(e => e.PersonFahrenheitGuid)
                    .HasName("PK_PeopleFahrenheit");

                entity.ToTable("PersonFahrenheit");

                entity.Property(e => e.PersonFahrenheitGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonFahrenheitGUID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.PersonGuid).HasColumnName("PersonGUID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.PersonGu)
                    .WithMany(p => p.PersonFahrenheits)
                    .HasForeignKey(d => d.PersonGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonFahrenheit_Person");
            });

            modelBuilder.Entity<PersonGroup>(entity =>
            {
                entity.HasKey(e => e.PersonGroupGuid)
                    .HasName("PK_GroupDetails");

                entity.ToTable("PersonGroup");

                entity.Property(e => e.PersonGroupGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonGroupGUID");

                entity.Property(e => e.CustomerLocationGuid).HasColumnName("CustomerLocationGUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerLocationGu)
                    .WithMany(p => p.PersonGroups)
                    .HasForeignKey(d => d.CustomerLocationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonGroup_CustomerLocation");
            });

            modelBuilder.Entity<PersonGroupFahrenheit>(entity =>
            {
                entity.HasKey(e => e.PersonGroupFahrenheitGuid);

                entity.ToTable("PersonGroupFahrenheit");

                entity.Property(e => e.PersonGroupFahrenheitGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonGroupFahrenheitGUID");

                entity.Property(e => e.ExitScreeningExpiryTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsSurveyQuestionnaireRequired).HasDefaultValueSql("((0))");

                entity.Property(e => e.KioskScreenLabel)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PersonGroupGuid).HasColumnName("PersonGroupGUID");

                entity.HasOne(d => d.FahrenheitIdentificationTypeCodeNavigation)
                    .WithMany(p => p.PersonGroupFahrenheits)
                    .HasForeignKey(d => d.FahrenheitIdentificationTypeCode)
                    .HasConstraintName("FK_PersonGroupFahrenheit_FahrenheitIdentificationType");

                entity.HasOne(d => d.PersonGroupGu)
                    .WithMany(p => p.PersonGroupFahrenheits)
                    .HasForeignKey(d => d.PersonGroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonGroupFahrenheit_PersonGroup");

                entity.HasOne(d => d.ReasonForEntryTypeCodeNavigation)
                    .WithMany(p => p.PersonGroupFahrenheits)
                    .HasForeignKey(d => d.ReasonForEntryTypeCode)
                    .HasConstraintName("FK_PersonGroupFahrenheit_ReasonForEntryType");
            });

            modelBuilder.Entity<PersonGroupReasonForEntryType>(entity =>
            {
                entity.HasKey(e => new { e.PersonGroupGuid, e.ReasonForEntryTypeCode });

                entity.ToTable("PersonGroupReasonForEntryType");

                entity.Property(e => e.PersonGroupGuid).HasColumnName("PersonGroupGUID");
            });

            modelBuilder.Entity<PersonGroupScreeningQuestionnaire>(entity =>
            {
                entity.HasKey(e => new { e.PersonGroupGuid, e.ScreeningQuestionnaireGuid });

                entity.ToTable("PersonGroupScreeningQuestionnaire");

                entity.Property(e => e.PersonGroupGuid).HasColumnName("PersonGroupGUID");

                entity.Property(e => e.ScreeningQuestionnaireGuid).HasColumnName("ScreeningQuestionnaireGUID");
            });

            modelBuilder.Entity<PersonPreScreeningQuestionnaireResponse>(entity =>
            {
                entity.HasKey(e => e.PersonPreScreeningQuestionnaireResponseGuid);

                entity.ToTable("PersonPreScreeningQuestionnaireResponse");

                entity.Property(e => e.PersonPreScreeningQuestionnaireResponseGuid).ValueGeneratedNever();

                entity.HasOne(d => d.PersonPreScreeningResponseGu)
                    .WithMany(p => p.PersonPreScreeningQuestionnaireResponses)
                    .HasForeignKey(d => d.PersonPreScreeningResponseGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonPreScreeningQuestionnaireResponse_PersonPreScreeningResponse");

                entity.HasOne(d => d.ScreeningQuestionnaireGu)
                    .WithMany(p => p.PersonPreScreeningQuestionnaireResponses)
                    .HasForeignKey(d => d.ScreeningQuestionnaireGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonPreScreeningQuestionnaireResponse_ScreeningQuestionnaire");
            });

            modelBuilder.Entity<PersonPreScreeningResponse>(entity =>
            {
                entity.HasKey(e => e.PersonPreScreeningResponseGuid);

                entity.ToTable("PersonPreScreeningResponse");

                entity.Property(e => e.PersonPreScreeningResponseGuid).ValueGeneratedNever();

                entity.Property(e => e.EntryDetail)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LastPreScreeningDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.ReasonForEntryTypeCodeNavigation)
                    .WithMany(p => p.PersonPreScreeningResponses)
                    .HasForeignKey(d => d.ReasonForEntryTypeCode)
                    .HasConstraintName("FK_PersonPreScreeningResponse_ReasonForEntryType");
            });

            modelBuilder.Entity<PersonScreeningQuestionnaireResponse>(entity =>
            {
                entity.HasKey(e => e.PersonScreeningQuestionnaireResponseGuid)
                    .HasName("PK__PersonSc__9221C55A463F3340");

                entity.ToTable("PersonScreeningQuestionnaireResponse");

                entity.Property(e => e.PersonScreeningQuestionnaireResponseGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonScreeningQuestionnaireResponseGUID");

                entity.Property(e => e.PersonGuid).HasColumnName("PersonGUID");

                entity.Property(e => e.PersonScreeningResultGuid).HasColumnName("PersonScreeningResultGUID");

                entity.Property(e => e.ScreeningQuestionnaireGuid).HasColumnName("ScreeningQuestionnaireGUID");

                entity.HasOne(d => d.PersonGu)
                    .WithMany(p => p.PersonScreeningQuestionnaireResponses)
                    .HasForeignKey(d => d.PersonGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonScreeningQuestionareResponse_Person");

                entity.HasOne(d => d.PersonScreeningResultGu)
                    .WithMany(p => p.PersonScreeningQuestionnaireResponses)
                    .HasForeignKey(d => d.PersonScreeningResultGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_PersonScreeningQuestionareResponse_PersonScreeningResult");

                entity.HasOne(d => d.ScreeningQuestionnaireGu)
                    .WithMany(p => p.PersonScreeningQuestionnaireResponses)
                    .HasForeignKey(d => d.ScreeningQuestionnaireGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonScreeningQuestionareResponse_ScreeningQuestionnaire");
            });

            modelBuilder.Entity<PersonScreeningResult>(entity =>
            {
                entity.HasKey(e => e.PersonScreeningResultGuid)
                    .HasName("PK__PersonSc__CF362CDDF71320FF");

                entity.ToTable("PersonScreeningResult");

                entity.Property(e => e.PersonScreeningResultGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonScreeningResultGUID");

                entity.Property(e => e.EntryDetail)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ExitScreeningDateTime).HasColumnType("datetime");

                entity.Property(e => e.PersonGuid).HasColumnName("PersonGUID");

                entity.Property(e => e.ReferenceImageBase64).IsUnicode(false);

                entity.Property(e => e.ScreeningDateTime).HasColumnType("datetime");

                entity.Property(e => e.TemperatureCelsius).IsUnicode(false);

                entity.HasOne(d => d.ReasonForEntryTypeCodeNavigation)
                    .WithMany(p => p.PersonScreeningResults)
                    .HasForeignKey(d => d.ReasonForEntryTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_PersonScreeningResult_ReasonForEntryType");

                entity.HasOne(d => d.ScreeningStatusTypeCodeNavigation)
                    .WithMany(p => p.PersonScreeningResults)
                    .HasForeignKey(d => d.ScreeningStatusTypeCode)
                    .HasConstraintName("Fk_PersonScreeningResult_ScreeningStatusType");
            });

            modelBuilder.Entity<PersonSurveyQuestionnaireResponse>(entity =>
            {
                entity.HasKey(e => e.PersonSurveyQuestionnaireResponseGuid)
                    .HasName("PK__PersonSu__59947B6E92A91BF0");

                entity.ToTable("PersonSurveyQuestionnaireResponse");

                entity.Property(e => e.PersonSurveyQuestionnaireResponseGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PersonSurveyQuestionnaireResponseGUID");

                entity.Property(e => e.PersonGuid).HasColumnName("PersonGUID");

                entity.Property(e => e.PersonScreeningResultGuid).HasColumnName("PersonScreeningResultGUID");

                entity.Property(e => e.SurveyQuestionnaireGuid).HasColumnName("SurveyQuestionnaireGUID");

                entity.HasOne(d => d.PersonGu)
                    .WithMany(p => p.PersonSurveyQuestionnaireResponses)
                    .HasForeignKey(d => d.PersonGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonSurveyQuestionnaireResponse_Person");

                entity.HasOne(d => d.PersonScreeningResultGu)
                    .WithMany(p => p.PersonSurveyQuestionnaireResponses)
                    .HasForeignKey(d => d.PersonScreeningResultGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_PersonSurveyQuestionnaireResponse_PersonScreeningResult");

                entity.HasOne(d => d.SurveyQuestionnaireGu)
                    .WithMany(p => p.PersonSurveyQuestionnaireResponses)
                    .HasForeignKey(d => d.SurveyQuestionnaireGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonSurveyQuestionnaireResponse_SurveyQuestionnaire");
            });

            modelBuilder.Entity<PersonTemperatureTerminal>(entity =>
            {
                entity.HasKey(e => new { e.PersonGuid, e.TemperatureTerminalFaceId });

                entity.ToTable("PersonTemperatureTerminal");

                entity.Property(e => e.TemperatureTerminalFaceId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrerecordedAudioClip>(entity =>
            {
                entity.HasKey(e => e.PrerecordedAudioClipGuid)
                    .HasName("PK_PrerecordedAudio");

                entity.ToTable("PrerecordedAudioClip");

                entity.Property(e => e.PrerecordedAudioClipGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PrerecordedAudioClipGUID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TextToSpeechReplacementToken)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasComment("This text token can be used in text to speech operations to replace a phrase with precorded audio.  E.G.  \"Please leave a message at the sound of the [BEEP]\".  \"[BEEP]\" would be the text token representing the beep WAV file.  The text string would remove this text token and concatenate the beep wav file to the end of the text to speech.");

                entity.HasOne(d => d.CreatedBySystemUserGu)
                    .WithMany(p => p.PrerecordedAudioClips)
                    .HasForeignKey(d => d.CreatedBySystemUserGuid)
                    .HasConstraintName("FK_PrerecordedAudioClip_SystemUser");
            });

            modelBuilder.Entity<ProductTypeInitiatorTypeProvisionInterpreter>(entity =>
            {
                entity.HasKey(e => new { e.InitiatorTypeCode, e.ProductTypeIdentifier });

                entity.ToTable("ProductTypeInitiatorTypeProvisionInterpreter");

                entity.Property(e => e.ProvisioningInterpreter)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.InitiatorTypeCodeNavigation)
                    .WithMany(p => p.ProductTypeInitiatorTypeProvisionInterpreters)
                    .HasForeignKey(d => d.InitiatorTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvisionInterpreterInitiatorType_InitiatorType");
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

            modelBuilder.Entity<ProvisionOption>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProvisionOption");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplianceTypeCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ApplianceTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvisionOption_ApplianceType");
            });

            modelBuilder.Entity<ProvisionOptionApplianceTypeCodeSystemInput>(entity =>
            {
                entity.HasKey(e => new { e.ProvisionOptionCode, e.ApplianceTypeCode, e.SystemInputGuid });

                entity.ToTable("ProvisionOptionApplianceTypeCodeSystemInput");

                entity.Property(e => e.SystemInputGuid).HasColumnName("SystemInputGUID");

                entity.HasOne(d => d.ApplianceTypeCodeNavigation)
                    .WithMany(p => p.ProvisionOptionApplianceTypeCodeSystemInputs)
                    .HasForeignKey(d => d.ApplianceTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvisionOptionApplianceTypeCodeSystemInput_ApplianceTypeCode");

                entity.HasOne(d => d.SystemInputGu)
                    .WithMany(p => p.ProvisionOptionApplianceTypeCodeSystemInputs)
                    .HasForeignKey(d => d.SystemInputGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvisionOptionApplianceTypeCodeSystemInput_SystemInputGUID");
            });

            modelBuilder.Entity<ProvisionOptionApplianceTypeCodeSystemOutput>(entity =>
            {
                entity.HasKey(e => new { e.ProvisionOptionCode, e.ApplianceTypeCode, e.SystemOutputGuid });

                entity.ToTable("ProvisionOptionApplianceTypeCodeSystemOutput");

                entity.Property(e => e.SystemOutputGuid).HasColumnName("SystemOutputGUID");

                entity.HasOne(d => d.ApplianceTypeCodeNavigation)
                    .WithMany(p => p.ProvisionOptionApplianceTypeCodeSystemOutputs)
                    .HasForeignKey(d => d.ApplianceTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvisionOptionApplianceTypeCodeSystemOutput_ApplianceType");

                entity.HasOne(d => d.SystemOutputGu)
                    .WithMany(p => p.ProvisionOptionApplianceTypeCodeSystemOutputs)
                    .HasForeignKey(d => d.SystemOutputGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvisionOptionApplianceTypeCodeSystemOutput_SystemOutput");
            });

            modelBuilder.Entity<ProvisionOptionApplianceTypeEventFlow>(entity =>
            {
                entity.HasKey(e => new { e.ProvisionOptionCode, e.ApplianceTypeCode, e.EventFlowGuid });

                entity.ToTable("ProvisionOptionApplianceTypeEventFlow");

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.HasOne(d => d.EventFlowGu)
                    .WithMany(p => p.ProvisionOptionApplianceTypeEventFlows)
                    .HasForeignKey(d => d.EventFlowGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProvisionOptionApplianceTypeEventFlow_ProvisionOptionApplianceTypeEventFlow");
            });

            modelBuilder.Entity<PttappChannel>(entity =>
            {
                entity.HasKey(e => e.PttappChannelGuid)
                    .HasName("PK_PTTChannel");

                entity.ToTable("PTTAppChannel");

                entity.Property(e => e.PttappChannelGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PTTAppChannelGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PttappChannelPlan>(entity =>
            {
                entity.HasKey(e => e.PttappChannelPlanGuid);

                entity.ToTable("PTTAppChannelPlan");

                entity.Property(e => e.PttappChannelPlanGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("PTTAppChannelPlanGUID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PttappChannelPlanConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("PTTAppChannelPlanConfigurationDataXML");
            });

            modelBuilder.Entity<PttappChatMessage>(entity =>
            {
                entity.HasKey(e => e.PttappChatMessageGuid)
                    .HasName("PK__PTTAppCh__B4241E3B9A9582BD");

                entity.ToTable("PTTAppChatMessage");

                entity.Property(e => e.PttappChatMessageGuid)
                    .HasColumnName("PTTAppChatMessageGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PttappChatRoomGuid).HasColumnName("PTTAppChatRoomGUID");

                entity.Property(e => e.ReadBy).IsUnicode(false);

                entity.Property(e => e.SenderGuid).HasColumnName("SenderGUID");

                entity.Property(e => e.SenderName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.PttappChatRoomGu)
                    .WithMany(p => p.PttappChatMessages)
                    .HasForeignKey(d => d.PttappChatRoomGuid)
                    .HasConstraintName("FK__PTTAppCha__PTTAp__1229A90A");

                entity.HasOne(d => d.SenderGu)
                    .WithMany(p => p.PttappChatMessages)
                    .HasForeignKey(d => d.SenderGuid)
                    .HasConstraintName("FK__PTTAppCha__Sende__131DCD43");
            });

            modelBuilder.Entity<PttappChatRoom>(entity =>
            {
                entity.HasKey(e => e.PttappChatRoomGuid)
                    .HasName("PK__PTTAppCh__14B5C98E1E9DBA65");

                entity.ToTable("PTTAppChatRoom");

                entity.Property(e => e.PttappChatRoomGuid)
                    .HasColumnName("PTTAppChatRoomGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PttappChatRoomName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PTTAppChatRoomName");
            });

            modelBuilder.Entity<PttappChatRoomSystemUser>(entity =>
            {
                entity.HasKey(e => e.PttappChatRoomSystemUserGuid)
                    .HasName("PK__PTTAppCh__17CAC975C1840E51");

                entity.ToTable("PTTAppChatRoomSystemUser");

                entity.Property(e => e.PttappChatRoomSystemUserGuid)
                    .HasColumnName("PTTAppChatRoomSystemUserGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PttappChatRoomGuid).HasColumnName("PTTAppChatRoomGUID");

                entity.Property(e => e.SystemUserGuid).HasColumnName("SystemUserGUID");

                entity.HasOne(d => d.PttappChatRoomGu)
                    .WithMany(p => p.PttappChatRoomSystemUsers)
                    .HasForeignKey(d => d.PttappChatRoomGuid)
                    .HasConstraintName("FK__PTTAppCha__PTTAp__69279377");

                entity.HasOne(d => d.SystemUserGu)
                    .WithMany(p => p.PttappChatRoomSystemUsers)
                    .HasForeignKey(d => d.SystemUserGuid)
                    .HasConstraintName("FK__PTTAppCha__Syste__6A1BB7B0");
            });

            modelBuilder.Entity<PttappScanType>(entity =>
            {
                entity.HasKey(e => e.PttappScanTypeCode);

                entity.ToTable("PTTAppScanType");

                entity.Property(e => e.PttappScanTypeCode)
                    .ValueGeneratedNever()
                    .HasColumnName("PTTAppScanTypeCode");

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

            modelBuilder.Entity<RadioModelType>(entity =>
            {
                entity.HasKey(e => e.RadioModelTypeCode);

                entity.ToTable("RadioModelType");

                entity.Property(e => e.RadioModelTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReasonForEntryType>(entity =>
            {
                entity.HasKey(e => e.ReasonForEntryTypeCode);

                entity.ToTable("ReasonForEntryType");

                entity.Property(e => e.ReasonForEntryTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReportPeriodType>(entity =>
            {
                entity.HasKey(e => e.ReportPeriodTypeCode);

                entity.ToTable("ReportPeriodType");

                entity.Property(e => e.ReportPeriodTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<ReportScheduler>(entity =>
            {
                entity.HasKey(e => e.ReportSchedulerGuid)
                    .HasName("PK__ReportSc__E5E3F166F809662F");

                entity.ToTable("ReportScheduler");

                entity.Property(e => e.ReportSchedulerGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ReportSchedulerGUID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailParameter).HasColumnType("xml");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ExportType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastRunTime).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NextRunTime).HasColumnType("datetime");

                entity.Property(e => e.ParameterValues).HasColumnType("xml");

                entity.Property(e => e.RecurenceInfo).HasColumnType("xml");

                entity.Property(e => e.ReportPath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ScreeningQuestionnaire>(entity =>
            {
                entity.HasKey(e => e.ScreeningQuestionnaireGuid);

                entity.ToTable("ScreeningQuestionnaire");

                entity.Property(e => e.ScreeningQuestionnaireGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("ScreeningQuestionnaireGUID");

                entity.Property(e => e.BadgeIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionDescription).IsUnicode(false);
            });

            modelBuilder.Entity<ScreeningResultReportStatusFilter>(entity =>
            {
                entity.ToTable("ScreeningResultReportStatusFilter");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScreeningStatusType>(entity =>
            {
                entity.HasKey(e => e.ScreeningStatusTypeCode);

                entity.ToTable("ScreeningStatusType");

                entity.Property(e => e.ScreeningStatusTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
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

            modelBuilder.Entity<StopBitsType>(entity =>
            {
                entity.HasKey(e => e.StopBitsTypeCode);

                entity.ToTable("StopBitsType");

                entity.Property(e => e.StopBitsTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<SurveyQuestionnaire>(entity =>
            {
                entity.HasKey(e => e.SurveyQuestionnaireGuid);

                entity.ToTable("SurveyQuestionnaire");

                entity.Property(e => e.SurveyQuestionnaireGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SurveyQuestionnaireGUID");

                entity.Property(e => e.EventFlowGuid).HasColumnName("EventFlowGUID");

                entity.Property(e => e.QuestionDescription).IsUnicode(false);

                entity.HasOne(d => d.EventFlowGu)
                    .WithMany(p => p.SurveyQuestionnaires)
                    .HasForeignKey(d => d.EventFlowGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyQuestionnaire_EventFlow");
            });

            modelBuilder.Entity<SystemConfigurationType>(entity =>
            {
                entity.HasKey(e => e.SystemConfigurationTypeCode);

                entity.ToTable("SystemConfigurationType");

                entity.Property(e => e.SystemConfigurationTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value).IsUnicode(false);
            });

            modelBuilder.Entity<SystemContentGroup>(entity =>
            {
                entity.HasKey(e => e.SystemContentGroupGuid);

                entity.ToTable("SystemContentGroup");

                entity.Property(e => e.SystemContentGroupGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemContentGroupGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SystemContentGroupConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("SystemContentGroupConfigurationDataXML");
            });

            modelBuilder.Entity<SystemFunctionPermissionType>(entity =>
            {
                entity.HasKey(e => e.SystemFunctionPermissionTypeCode);

                entity.ToTable("SystemFunctionPermissionType");

                entity.Property(e => e.SystemFunctionPermissionTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SystemHealthDashboardCache>(entity =>
            {
                entity.HasKey(e => e.SystemHealthDashboardCacheGuid);

                entity.ToTable("SystemHealthDashboardCache");

                entity.Property(e => e.SystemHealthDashboardCacheGuid).ValueGeneratedNever();

                entity.Property(e => e.ActivationDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.EventTypeCodeNavigation)
                    .WithMany(p => p.SystemHealthDashboardCaches)
                    .HasForeignKey(d => d.EventTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemHealthDashboardCache_EventType");

                entity.HasOne(d => d.InitiatorGu)
                    .WithMany(p => p.SystemHealthDashboardCaches)
                    .HasForeignKey(d => d.InitiatorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemHealthDashboardCache_Initiator");
            });

            modelBuilder.Entity<SystemInput>(entity =>
            {
                entity.HasKey(e => e.SystemInputGuid);

                entity.ToTable("SystemInput");

                entity.Property(e => e.SystemInputGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemInputGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SystemInputConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("SystemInputConfigurationDataXML");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SystemInputTypeCodeNavigation)
                    .WithMany(p => p.SystemInputs)
                    .HasForeignKey(d => d.SystemInputTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemInput_SystemInputType");
            });

            modelBuilder.Entity<SystemInputAudit>(entity =>
            {
                entity.HasKey(e => e.SystemInputAuditGuid);

                entity.ToTable("SystemInputAudit");

                entity.Property(e => e.SystemInputAuditGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemInputAuditGUID");

                entity.Property(e => e.Activity)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SystemInputConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("SystemInputConfigurationDataXML");

                entity.Property(e => e.SystemInputGuid).HasColumnName("SystemInputGUID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SystemInputType>(entity =>
            {
                entity.HasKey(e => e.SystemInputTypeCode);

                entity.ToTable("SystemInputType");

                entity.Property(e => e.SystemInputTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<SystemOutput>(entity =>
            {
                entity.HasKey(e => e.SystemOutputGuid);

                entity.ToTable("SystemOutput");

                entity.Property(e => e.SystemOutputGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemOutputGUID");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsSpecialIoresource).HasColumnName("IsSpecialIOResource");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SystemOutputConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("SystemOutputConfigurationDataXML");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.SystemOutputTypeCodeNavigation)
                    .WithMany(p => p.SystemOutputs)
                    .HasForeignKey(d => d.SystemOutputTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemOutput_SystemOutputType");
            });

            modelBuilder.Entity<SystemOutputAudit>(entity =>
            {
                entity.HasKey(e => e.SystemOutputAuditGuid);

                entity.ToTable("SystemOutputAudit");

                entity.Property(e => e.SystemOutputAuditGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemOutputAuditGUID");

                entity.Property(e => e.Activity)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SystemOutputConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("SystemOutputConfigurationDataXML");

                entity.Property(e => e.SystemOutputGuid).HasColumnName("SystemOutputGUID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<SystemOutputCategoryType>(entity =>
            {
                entity.HasKey(e => e.SystemOutputCategoryTypeCode)
                    .HasName("PK_SystemOutputTypeCategoryType");

                entity.ToTable("SystemOutputCategoryType");

                entity.Property(e => e.SystemOutputCategoryTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<SystemOutputType>(entity =>
            {
                entity.HasKey(e => e.SystemOutputTypeCode);

                entity.ToTable("SystemOutputType");

                entity.Property(e => e.SystemOutputTypeCode).ValueGeneratedNever();

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

                entity.HasOne(d => d.SystemOutputCategoryTypeCodeNavigation)
                    .WithMany(p => p.SystemOutputTypes)
                    .HasForeignKey(d => d.SystemOutputCategoryTypeCode)
                    .HasConstraintName("FK_SystemOutputType_SystemOutputCategoryType");
            });

            modelBuilder.Entity<SystemOutputTypeRadioModelType>(entity =>
            {
                entity.HasKey(e => new { e.SystemOutputTypeCode, e.RadioModelTypeCode });

                entity.ToTable("SystemOutputTypeRadioModelType");
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.SystemUserGuid);

                entity.ToTable("SystemUser");

                entity.Property(e => e.SystemUserGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemUserGUID");

                entity.Property(e => e.DefaultPassword).HasMaxLength(200);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PttappChannelGuid).HasColumnName("PTTAppChannelGUID");

                entity.Property(e => e.PttappChannelPlanGuid).HasColumnName("PTTAppChannelPlanGUID");

                entity.Property(e => e.Roipdetails)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ROIPDetails");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerLocationGu)
                    .WithMany(p => p.SystemUsers)
                    .HasForeignKey(d => d.CustomerLocationGuid)
                    .HasConstraintName("FK_SystemUser_CustomerLocation");

                entity.HasOne(d => d.PttappChannelGu)
                    .WithMany(p => p.SystemUsers)
                    .HasForeignKey(d => d.PttappChannelGuid)
                    .HasConstraintName("FK_SystemUser_PTTAppChannel");

                entity.HasOne(d => d.PttappChannelPlanGu)
                    .WithMany(p => p.SystemUsers)
                    .HasForeignKey(d => d.PttappChannelPlanGuid)
                    .HasConstraintName("FK_SystemUser_PTTAppChannelPlan");

                entity.HasOne(d => d.UserRoleTypeCodeNavigation)
                    .WithMany(p => p.SystemUsers)
                    .HasForeignKey(d => d.UserRoleTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemUser_UserRoleType");
            });

            modelBuilder.Entity<SystemUserAudit>(entity =>
            {
                entity.HasKey(e => e.SystemUserAuditGuid);

                entity.ToTable("SystemUserAudit");

                entity.Property(e => e.SystemUserAuditGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemUserAuditGUID");

                entity.Property(e => e.Activity)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemUserGuid).HasColumnName("SystemUserGUID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TemperatureDetectorEventLog>(entity =>
            {
                entity.HasKey(e => e.TemperatureDetectorEventLogGuid);

                entity.ToTable("TemperatureDetectorEventLog");

                entity.Property(e => e.TemperatureDetectorEventLogGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("TemperatureDetectorEventLogGUID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ExternalTemperature)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InternalTemperature)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.InitiatorGu)
                    .WithMany(p => p.TemperatureDetectorEventLogs)
                    .HasForeignKey(d => d.InitiatorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemperatureDetectorEventLog_Initiator");
            });

            modelBuilder.Entity<TemperatureMonitorEventLog>(entity =>
            {
                entity.HasKey(e => e.TemperatureMonitorEventLogGuid);

                entity.ToTable("TemperatureMonitorEventLog");

                entity.Property(e => e.TemperatureMonitorEventLogGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("TemperatureMonitorEventLogGUID");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.TemperatureAmbient)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.InitiatorGu)
                    .WithMany(p => p.TemperatureMonitorEventLogs)
                    .HasForeignKey(d => d.InitiatorGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemperatureMonitorEventLog_Initiator");
            });

            modelBuilder.Entity<TemperatureTerminalPersonBatch>(entity =>
            {
                entity.HasKey(e => e.TemperatureTerminalPersonBatchGuid);

                entity.ToTable("TemperatureTerminalPersonBatch");

                entity.Property(e => e.TemperatureTerminalPersonBatchGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("TemperatureTerminalPersonBatchGUID");

                entity.Property(e => e.BatchCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ZipFileName)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TemperatureTerminalPersonBatchDetail>(entity =>
            {
                entity.HasKey(e => e.TemperatureTerminalPersonBatchDetailGuid);

                entity.ToTable("TemperatureTerminalPersonBatchDetail");

                entity.Property(e => e.TemperatureTerminalPersonBatchDetailGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("TemperatureTerminalPersonBatchDetailGUID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonGroupGuid).HasColumnName("PersonGroupGUID");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceImageBase64)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SyncError)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TemperatureTerminalPersonBatchGuid).HasColumnName("TemperatureTerminalPersonBatchGUID");

                entity.HasOne(d => d.PersonGroupGu)
                    .WithMany(p => p.TemperatureTerminalPersonBatchDetails)
                    .HasForeignKey(d => d.PersonGroupGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemperatureTerminalPersonBatchDetail_PersonGroup");

                entity.HasOne(d => d.TemperatureTerminalPersonBatchGu)
                    .WithMany(p => p.TemperatureTerminalPersonBatchDetails)
                    .HasForeignKey(d => d.TemperatureTerminalPersonBatchGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemperatureTerminalPersonBatchDetail_TemperatureTerminalPersonBatch");
            });

            modelBuilder.Entity<TemperatureTerminalSyncTracking>(entity =>
            {
                entity.HasKey(e => e.TemperatureTerminalSyncTrackingGuid);

                entity.ToTable("TemperatureTerminalSyncTracking");

                entity.Property(e => e.TemperatureTerminalSyncTrackingGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("TemperatureTerminalSyncTrackingGUID");

                entity.Property(e => e.ApplianceGuid).HasColumnName("ApplianceGUID");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.SyncError)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplianceGu)
                    .WithMany(p => p.TemperatureTerminalSyncTrackings)
                    .HasForeignKey(d => d.ApplianceGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TemperatureTerminalSyncTracking_Appliance");
            });

            modelBuilder.Entity<TextSubstitution>(entity =>
            {
                entity.HasKey(e => e.TextSubstitutionGuid);

                entity.ToTable("TextSubstitution");

                entity.Property(e => e.TextSubstitutionGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("TextSubstitutionGUID");

                entity.Property(e => e.OriginalText)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubstitutedText)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TextSubstitutionAudit>(entity =>
            {
                entity.HasKey(e => e.TextSubstitutionAuditGuid);

                entity.ToTable("TextSubstitutionAudit");

                entity.Property(e => e.TextSubstitutionAuditGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("TextSubstitutionAuditGUID");

                entity.Property(e => e.Activity)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SubstitutedText)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TextSubstitutionGuid).HasColumnName("TextSubstitutionGUID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ThermalBufferType>(entity =>
            {
                entity.HasKey(e => e.ThermalBufferTypeCode);

                entity.ToTable("ThermalBufferType");

                entity.Property(e => e.ThermalBufferTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<ThermistorProbeType>(entity =>
            {
                entity.HasKey(e => e.ThermistorProbeTypeCode);

                entity.ToTable("ThermistorProbeType");

                entity.Property(e => e.ThermistorProbeTypeCode).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnumName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ThermistorProbeTypeRtcurveDataItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ThermistorProbeTypeRTCurveDataItem");

                entity.HasOne(d => d.ThermistorProbeTypeCodeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ThermistorProbeTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThermistorProbeTypeRTCurveDataItem_ThermistorProbeType");
            });

            modelBuilder.Entity<ThermistorProbeTypeThermalBufferType>(entity =>
            {
                entity.HasKey(e => new { e.ThermistorProbeTypeCode, e.ThermalBufferTypeCode });

                entity.ToTable("ThermistorProbeTypeThermalBufferType");
            });

            modelBuilder.Entity<UserRoleType>(entity =>
            {
                entity.HasKey(e => e.UserRoleTypeCode);

                entity.ToTable("UserRoleType");

                entity.Property(e => e.UserRoleTypeCode).ValueGeneratedNever();

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

            modelBuilder.Entity<UserRoleTypeSystemFunctionPermissionType>(entity =>
            {
                entity.HasKey(e => new { e.UserRoleTypeCode, e.SystemFunctionPermissionTypeCode });

                entity.ToTable("UserRoleTypeSystemFunctionPermissionType");
            });

            modelBuilder.Entity<UserSystemConfiguration>(entity =>
            {
                entity.HasKey(e => e.SystemUserGuid)
                    .HasName("PK_UserDashboardFilter");

                entity.ToTable("UserSystemConfiguration");

                entity.Property(e => e.SystemUserGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("SystemUserGUID");

                entity.Property(e => e.DashboardFilterConfigurationDataXml)
                    .HasColumnType("xml")
                    .HasColumnName("DashboardFilterConfigurationDataXML");

                entity.HasOne(d => d.SystemUserGu)
                    .WithOne(p => p.UserSystemConfiguration)
                    .HasForeignKey<UserSystemConfiguration>(d => d.SystemUserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserSystemConfiguration_SystemUser");
            });

            modelBuilder.Entity<XmldataTemplate>(entity =>
            {
                entity.HasKey(e => e.XmldataTemplateGuid);

                entity.ToTable("XMLDataTemplate");

                entity.Property(e => e.XmldataTemplateGuid)
                    .ValueGeneratedNever()
                    .HasColumnName("XMLDataTemplateGUID");

                entity.Property(e => e.AuxillaryXmldata)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("AuxillaryXMLData");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Xmldata)
                    .HasColumnType("xml")
                    .HasColumnName("XMLData");

                entity.Property(e => e.XmldataTemplateName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("XMLDataTemplateName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
