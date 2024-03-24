using PlanIt.API.Models.Domain;

namespace PlanIt.API.Repositories
{
    public interface ISurveyRepository
    {

        Task<List<Dates>> GetAllActiveAsync();

    }
}
