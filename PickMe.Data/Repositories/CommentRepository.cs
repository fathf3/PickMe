using Microsoft.EntityFrameworkCore;
using PickMe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentBySurveryIdAsync(int surveyId)
        {
            return await _dbContext.Comments
                .Include(c => c.User)
                .Where(c => c.SurveyId == surveyId)
                .ToListAsync();
        }
    }
}
