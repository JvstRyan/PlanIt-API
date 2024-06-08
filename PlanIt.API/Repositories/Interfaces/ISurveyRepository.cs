using PlanIt.API.Models.Domain;

namespace PlanIt.API.Repositories.Interfaces
{
    public interface ISurveyRepository
    {

        Task<List<Dates>> GetAllActiveAsync();

        Task<List<Dates>> CreateAsync(List<Dates> dates);

    }
}
