﻿using Microsoft.AspNetCore.Identity;

namespace Present.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string? FisrtName { get; set; }
        public string? LastName { get; set; }
    }
}
