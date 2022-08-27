using DinersHeaven.Domain.Entities;

namespace DinersHeaven.Application.Common.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void AddUser(User user);
    }
}