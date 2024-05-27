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

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _dbContext.Users
                .Include(u => u.Responses)
                .ThenInclude(r => r.DateAnswers)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
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

        public async Task<bool> HasUserAnswered(string userId)
        {
            var hasAnswered = await _dbContext.DateAnswers
                 .Include(da => da.Date)
                 .Include(da => da.Response)
                 .AnyAsync(da => da.Response.UserId == userId && da.Date.Status == "active");

            if (hasAnswered == null)
                return false;
            
            
            return hasAnswered;
        }
    }
}
