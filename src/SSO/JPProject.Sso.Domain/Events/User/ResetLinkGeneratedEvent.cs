﻿using System;
using JPProject.Domain.Core.Events;

namespace JPProject.Sso.Domain.Events.User
{
    public class ResetLinkGeneratedEvent : Event
    {
        public string Email { get; }
        public string Username { get; }

        public ResetLinkGeneratedEvent(string aggregateId, string email, string username)
            : base(EventTypes.Success)
        {
            AggregateId = aggregateId.ToString();
            Email = email;
            Username = username;
        }
    }
}