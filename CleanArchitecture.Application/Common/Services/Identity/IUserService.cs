using CleanArchitecture.Application.Features.AppUser.CreateUser;
using CleanArchitecture.Application.Features.AppUser.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Services.Identity
{
    public interface IUserService
    {
        Task<CreateUserCommandResponse> CreateUser(CreateUserCommandRequest request);
        Task<LoginUserCommandResponse> LoginUser(LoginUserCommandRequest request);
    }
}
