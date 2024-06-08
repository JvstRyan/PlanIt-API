

using PlanIt.API.Models.Domain;
using PlanIt.API.Models.DTO;

namespace PlanIt.API.Repositories
{
    public interface IResponseRepository
    {
        Task<Response> CreateResponse(Response response);

        Task<List<ActiveDateDto>> GetAllResponses();

        Task<bool> HasUserAnswered(string userId);

        Task<bool> DeleteUser(string userId);

        
    }
}
