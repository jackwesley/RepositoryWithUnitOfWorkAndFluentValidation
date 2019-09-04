using System;


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
