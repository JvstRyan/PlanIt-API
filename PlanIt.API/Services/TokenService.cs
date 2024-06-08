using PlanIt.API.Models.Domain;
using PlanIt.API.Repositories.Interfaces;
using PlanIt.API.Services.Interfaces;
using System.Collections.Generic;

namespace PlanIt.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }
        public string CreateJWTToken(ApplicationUser user, IList<string> roles)
        {
            return _tokenRepository.CreateJWTToken(user, roles);
        }
    }
}
