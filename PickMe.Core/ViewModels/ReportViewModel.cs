using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Core.ViewModels
{
    public class ReportViewModel
    {
        public string Reason { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int SurveyId { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
