using System;
using System.Collections.Generic;

namespace ONE.DataAccess.Models
{
    public partial class SystemUser
    {
        public SystemUser()
        {
            ActiveAlarmTrackingHistories = new HashSet<ActiveAlarmTrackingHistory>();
            ActiveAlarmTrackings = new HashSet<ActiveAlarmTracking>();
            ActiveAlarmUserActionTrackings = new HashSet<ActiveAlarmUserActionTracking>();
            PrerecordedAudioClips = new HashSet<PrerecordedAudioClip>();
            PttappChatMessages = new HashSet<PttappChatMessage>();
            PttappChatRoomSystemUsers = new HashSet<PttappChatRoomSystemUser>();
        }

        public Guid SystemUserGuid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRoleTypeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CustomerLocationGuid { get; set; }
        public Guid? PttappChannelPlanGuid { get; set; }
        public string Roipdetails { get; set; }
        public int? Port { get; set; }
        public Guid? PttappChannelGuid { get; set; }
        public string DefaultPassword { get; set; }

        public virtual CustomerLocation CustomerLocationGu { get; set; }
        public virtual PttappChannel PttappChannelGu { get; set; }
        public virtual PttappChannelPlan PttappChannelPlanGu { get; set; }
        public virtual UserRoleType UserRoleTypeCodeNavigation { get; set; }
        public virtual UserSystemConfiguration UserSystemConfiguration { get; set; }
        public virtual ICollection<ActiveAlarmTrackingHistory> ActiveAlarmTrackingHistories { get; set; }
        public virtual ICollection<ActiveAlarmTracking> ActiveAlarmTrackings { get; set; }
        public virtual ICollection<ActiveAlarmUserActionTracking> ActiveAlarmUserActionTrackings { get; set; }
        public virtual ICollection<PrerecordedAudioClip> PrerecordedAudioClips { get; set; }
        public virtual ICollection<PttappChatMessage> PttappChatMessages { get; set; }
        public virtual ICollection<PttappChatRoomSystemUser> PttappChatRoomSystemUsers { get; set; }
    }
}
