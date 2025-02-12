using Microsoft.EntityFrameworkCore;
using PickMe.Core.Models;
using PickMe.Data.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Data.Repositories.Concretes
{
    internal class ReportRepository : Repository<Report>, IReportRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReportRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public Task<List<Report>> GetReportsByUsernameAsync()
        {
            var datas = _dbContext.Reports.Include(x => x.User).ToListAsync();
            return datas;
        }
    }
    
}
