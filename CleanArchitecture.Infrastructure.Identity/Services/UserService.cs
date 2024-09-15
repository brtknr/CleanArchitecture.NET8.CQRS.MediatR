using CleanArchitecture.Application.Common.Services.Identity;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.AppUser.CreateUser;
using CleanArchitecture.Application.Features.AppUser.LoginUser;
using CleanArchitecture.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Identity.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
      
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
         
        }

        public async Task<CreateUserCommandResponse> CreateUser(CreateUserCommandRequest request)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
                                        {
                                            Id = Guid.NewGuid().ToString(),
                                            UserName = request.Username,
                                            Name = request.Name,
                                            Surname = request.Surname,
                                            Email = request.Email,
                                            Gender = request.Gender,
                                            MersisNo = request.MersisNo,
                                            PhoneNumber = request.PhoneNumber,
                                            Address = request.Address,
                                        }, request.Password);

            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
            {
                response.Message = "User has been created successfully.";
            }
            else
                foreach(var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            
            return response;
        }

        public async Task<SignInResult> LoginUser(LoginUserCommandRequest request)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user == null)
                throw new UserNotFoundException();

            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
           
            return signInResult;
        }
    }
}
