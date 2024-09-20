using CleanArchitecture.Application.Features.AppUser.CreateUser;
using CleanArchitecture.Application.Features.AppUser.LoginUser;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Services.Identity
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> CreateUser(CreateUserCommandRequest request);
        Task<(SignInResult, List<Claim>)> LoginUser(LoginUserCommandRequest request);
    }
}
