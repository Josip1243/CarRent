﻿using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Persistence;
using Domain.Common.Errors;
using Domain.User;
using Domain.User.ValueObjects;
using ErrorOr;
using MediatR;
using Serilog;

namespace Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler 
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            // Check if user exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                Log.Error("User with given email already exists!");
                return Errors.User.DuplicateEmail;
            }

            // Create user (with unique ID)
            var user = User.Create(command.FirstName, command.LastName, command.Email, command.Password);
            _userRepository.Add(user);

            // Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}