using Microsoft.EntityFrameworkCore;
using PlanIt.API.Data;
using PlanIt.API.Models.Domain;
using PlanIt.API.Models.DTO;

namespace PlanIt.API.Repositories
{
    public class SQLResponseRepository : IResponseRepository
    {
        private readonly PlanItDbContext _dbContext;

        public SQLResponseRepository(PlanItDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Response> CreateResponse(Response response)
        {

            await _dbContext.Responses.AddAsync(response);
            await _dbContext.SaveChangesAsync();

            return response;

        }

        public async Task<List<ActiveDateDto>> GetAllResponses()
        {
            var responses = await _dbContext.Responses
                  .Include(r => r.User)
                  .Include(r => r.DateAnswers)
                  .ThenInclude(da => da.Date)
                  .ToListAsync();


            var activeDates = responses
                .SelectMany(r => r.DateAnswers)
                .Where(da => da.Date.Status == "active")
                .GroupBy(da => da.DateId)
                .Select(g => new ActiveDateDto
                {
                    DateId = g.Key,
                    Date = g.First().Date.Date,
                    AvailableUsers = g.Select(da => new ResponseUserDto
                    {
                        UserId = da.Response.UserId,
                        UserName = da.Response.User.UserName
                    }).ToList()
                })
                .ToList();


            return activeDates;  
        }
    }
}
