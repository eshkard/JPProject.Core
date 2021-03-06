using System;
using System.Collections.Generic;
using System.Text;
using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.ApiResource
{

    public class ApiSecretSavedEvent : Event
    {
        public string ResourceName { get; }

        public ApiSecretSavedEvent(int id, string resourceName)
        {
            AggregateId = id.ToString();
            ResourceName = resourceName;
        }
    }
}
