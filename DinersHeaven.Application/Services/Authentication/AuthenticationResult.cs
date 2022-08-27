using DinersHeaven.Domain.Entities;

namespace DinersHeaven.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
        );


}
