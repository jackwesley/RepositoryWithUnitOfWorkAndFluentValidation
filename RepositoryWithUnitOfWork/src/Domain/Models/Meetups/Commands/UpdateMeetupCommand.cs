using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Meetups.Commands
{
    public class UpdateMeetupCommand : BaseMeetupCommand
    {
        public UpdateMeetupCommand(
                     Guid id,
                     string name,
                     string description,
                     DateTime dateStart,
                     DateTime dateEnd,
                     bool free,
                     decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Free = free;
            Price = price;
        }
    }
}
