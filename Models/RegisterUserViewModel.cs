﻿namespace EventManagementSystem.Models
{
    public class RegisterUserViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool isAdmin { get; set; } = false;
    }
}
