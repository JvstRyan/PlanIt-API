using Microsoft.EntityFrameworkCore;
using PlanIt.API.Data;
using PlanIt.API.Models.Domain;

namespace PlanIt.API.Repositories
{
    public class SQLSurveyRepository : ISurveyRepository
    {
        private readonly PlanItDbContext _dbContext;
        public SQLSurveyRepository(PlanItDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Dates>> GetAllActiveAsync()
        {
            return await _dbContext.Dates
                .Where(date => date.Status == "active")
                .ToListAsync();
                
        }
    }
}
