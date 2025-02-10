using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PickMe.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Surveys = new List<Survey>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
            Reports = new List<Report>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
