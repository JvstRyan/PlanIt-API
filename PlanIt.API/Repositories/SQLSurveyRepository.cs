using Microsoft.EntityFrameworkCore;
using PlanIt.API.Data;
using PlanIt.API.Models.Domain;
using PlanIt.API.Repositories.Interfaces;

namespace PlanIt.API.Repositories
{
    public class SQLSurveyRepository : ISurveyRepository
    {
        private readonly PlanItDbContext _dbContext;
        public SQLSurveyRepository(PlanItDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task SetAllDatesToUnactiveAsync()
        {
            var allDates = await _dbContext.Dates.ToListAsync();

            foreach (var date in allDates)
            {
                date.Status = "unactive";
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Dates>> CreateAsync(List<Dates> newDates)
        {
            await SetAllDatesToUnactiveAsync();

            foreach (var date in newDates)
            {
                _dbContext.Dates.Add(date);
            }

            await _dbContext.SaveChangesAsync();

            return newDates;
        }

        public async Task<List<Dates>> GetAllActiveAsync()
        {
            return await _dbContext.Dates
                .Where(date => date.Status == "active")
                .ToListAsync();
                
        }
    }
}
