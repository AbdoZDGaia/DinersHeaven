using DinersHeaven.Domain.Entities;

namespace DinersHeaven.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
