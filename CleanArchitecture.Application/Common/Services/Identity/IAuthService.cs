using CleanArchitecture.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Services.Identity
{
    public interface IAuthService
    {
        Token CreateAccessToken(int minute,bool isBusiness); 
    }
}
