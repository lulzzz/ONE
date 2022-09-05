using System;

namespace ONE.Models.Options
{
    public class ActiveGrainOptions
    {
        public TimeSpan KeepAliveReminderTime { get; set; } = TimeSpan.FromMinutes(5);
    }
}
