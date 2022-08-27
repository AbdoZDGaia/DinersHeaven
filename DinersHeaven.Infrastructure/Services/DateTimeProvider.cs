using DinersHeaven.Application.Common.Interfaces.Services;

namespace DinersHeaven.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
