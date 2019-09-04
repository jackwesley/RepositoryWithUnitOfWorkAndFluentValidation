using Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Meetups.Commands
{
    public class DeleteMeetupCommand : BaseMeetupCommand
    {
        public DeleteMeetupCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
