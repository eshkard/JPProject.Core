﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPProject.Sso.Application.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telephone")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Picture")]
        public string Picture { get; set; }


        public string Url { get; set; }
        public string Company { get; set; }
        public string Bio { get; set; }
        public string JobTitle { get; set; }

        [JsonIgnore]
        public string Id { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string SecurityStamp { get; set; }
        public string SocialNumber { get; set; }
        public DateTime Birthdate { get; set; }
    }
}