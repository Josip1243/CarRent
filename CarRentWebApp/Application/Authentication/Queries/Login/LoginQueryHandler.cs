using Application.Authentication.Commands.Register;
using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Persistence;
using Domain.Common.Errors;
using Domain.Entities;
using ErrorOr;
using MediatR;
using Serilog;

namespace Application.Authentication.Queries.Login
{
    public class LoginQueryHandler
    : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                Log.Error("User with given email does not exist!");
                return Errors.Authentication.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                Log.Error("Invalid credentials!");
                return Errors.Authentication.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
