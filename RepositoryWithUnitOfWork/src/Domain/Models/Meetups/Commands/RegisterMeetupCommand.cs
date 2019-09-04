using System;

namespace Domain.Models.Meetups.Commands
{
    public class RegisterMeetupCommand : BaseMeetupCommand
    {
        public RegisterMeetupCommand(
                     string name,
                     string description,
                     DateTime dateStart,
                     DateTime dateEnd,
                     bool free,
                     decimal price)
        {
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Free = free;
            Price = price;
        }
    }
}
