﻿using System;
using JPProject.Domain.Core.Events;

namespace JPProject.Sso.Domain.Events.UserManagement
{
    public class PasswordChangedEvent : Event
    {

        public PasswordChangedEvent(string aggregateId)
            : base(EventTypes.Success)
        {
            AggregateId = aggregateId.ToString();
        }
    }
}