using PickMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Data.Repositories.Abstracts
{
    public interface IReportRepository : IRepository<Report>
    {
        Task<List<Report>> GetReportsByUsernameAsync();
       
    }
}
