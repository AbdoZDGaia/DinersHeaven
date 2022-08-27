using DinersHeaven.Application.Common.Interfaces;
using DinersHeaven.Application.Common.Persistence;
using DinersHeaven.Domain.Entities;

namespace DinersHeaven.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            // Validate user existence
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("The given email does not exist");
            }

            // Validate password
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }

            // Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user,
                token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // Validate user existence
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with the same email already exists.");
            }

            //Create user (generate unique ID) & Persist to DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.AddUser(user);

            //Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user,
                token);
        }
    }
}
