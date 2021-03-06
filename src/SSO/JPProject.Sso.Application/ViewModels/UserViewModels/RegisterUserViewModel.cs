﻿using JPProject.Domain.Core.StringUtils;
using System;
using System.ComponentModel.DataAnnotations;

namespace JPProject.Sso.Application.ViewModels.UserViewModels
{
    public class RegisterUserViewModel
    {

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Phone]
        [Display(Name = "Telephone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Display(Name = "Provider")]
        public string Provider { get; set; }

        [Display(Name = "ProviderId")]
        public string ProviderId { get; set; }

        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Country unique number
        /// e.g:
        /// Social Security Number (USA)
        /// RG or Cpf (Brazil)
        /// Burgerservicenumber (Netherlands)
        /// Henkilötunnus (Finnish)
        /// NIF (Portugal)
        /// </summary>
        public string SocialNumber { get; set; }

        public bool ContainsFederationGateway()
        {
            return Provider.IsPresent() && ProviderId.IsPresent();

        }

        public void ClearSensitiveData()
        {
            Password = null;
            ConfirmPassword = null;
        }
    }
}
