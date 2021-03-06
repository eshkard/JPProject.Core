﻿using System;

namespace JPProject.Domain.Core.Interfaces
{
    /// <summary>
    /// Interface to propagate user id type
    /// </summary>
    public interface IDomainUser
    {
        string Email { get; }
        bool EmailConfirmed { get; }
        string PasswordHash { get; }
        string SecurityStamp { get; }
        string PhoneNumber { get; }
        bool PhoneNumberConfirmed { get; }
        bool TwoFactorEnabled { get; }
        DateTimeOffset? LockoutEnd { get; }
        bool LockoutEnabled { get; }
        int AccessFailedCount { get; }
        string UserName { get; }
        string Picture { get; }
        string Url { get; }
        string Name { get; }
        string Company { get; }
        string Bio { get; }
        string JobTitle { get; }
        string SocialNumber { get; }
        DateTime? Birthdate { get; }
    }
}