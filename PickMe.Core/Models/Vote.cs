using System;

namespace PickMe.Core.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
