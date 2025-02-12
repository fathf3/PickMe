using PickMe.Business.Services.Abstractions;
using PickMe.Core.Models;
using PickMe.Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Business.Services.Concretes
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task DeleteReportAsync(int id)
        {
            var report = await _reportRepository.GetByIdAsync(id);
            _reportRepository.RemoveAsync(report);
        }

        public Task<List<Report>> GetAllReportsAsync()
        {
            return _reportRepository.GetReportsByUsernameAsync();
        }

        public Task<Report> GetReportByIdAsync(int id)
        {
            return _reportRepository.GetByIdAsync(id);
        }
    }
}
