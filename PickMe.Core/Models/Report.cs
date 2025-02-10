using System;

namespace PickMe.Core.Models
{
    public class Report
    {
        public Report()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int SurveyId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public virtual Survey Survey { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
