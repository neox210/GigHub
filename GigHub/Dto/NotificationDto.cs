using GigHub.Models;
using System;

namespace GigHub.Dto
{
    public class NotificationDto
    {
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }
        public DateTime? OrginalDateTime { get; private set; }
        public string OrginalVenue { get; private set; }
        public GigDto Gig { get; private set; }
    }
}