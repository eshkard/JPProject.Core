using System;
using JPProject.Admin.Domain.Commands.ApiResource;
using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.ApiResource
{
    public class ApiResourceRegisteredEvent : Event
    {
        public ApiResourceRegisteredEvent(string name)
        {
            AggregateId = name;
        }
    }
}