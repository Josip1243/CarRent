using Application.Common.Interfaces.Authentication;
using Application.Common.Persistence;
using Domain.Entities;
using Serilog;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // Check if user exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                Log.Error("User with given email already exists!");
                throw new Exception("User with given email already exists");
            }

            // Create user (with unique ID)
            Random rnd = new Random();
            int userId = rnd.Next(1000);

            var user = new User()
            {
                Id = userId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);

            // Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                Log.Error("User with given email does not exist!");
                throw new Exception("User with given email does not exist");
            }

            if (user.Password != password)
            {
                Log.Error("Invalid credentials!");
                throw new Exception("Invalid credentials!");
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
