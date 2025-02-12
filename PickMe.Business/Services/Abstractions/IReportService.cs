using PickMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Business.Services.Abstractions
{
    public interface IReportService
    {
        Task<Report> GetReportByIdAsync(int id);
        Task<List<Report>> GetAllReportsAsync();
        Task DeleteReportAsync(int id);
    }
}
