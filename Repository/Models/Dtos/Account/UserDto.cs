﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Models.Dtos.Account
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool IsEmailConfirmed = true;
    }
}