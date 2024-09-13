using CleanArchitecture.Application.Common.Services.Identity;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly IAuthService _authService;
        public LoginUserCommandHandler(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var signInResult = await _userService.LoginUser(request);

            if (signInResult.Succeeded)
            {
                Token token = _authService.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };
            }

            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = "Username or password is incorrect."
            //};

            throw new AuthenticationErrorException();
        }
    }
}
