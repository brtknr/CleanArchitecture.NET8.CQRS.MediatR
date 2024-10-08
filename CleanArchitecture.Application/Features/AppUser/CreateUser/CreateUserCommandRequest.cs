﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AppUser.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string Username { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Gender { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? MersisNo { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public bool isBusiness { get; set; } // 0 for customer - 1 for business
    }
}
