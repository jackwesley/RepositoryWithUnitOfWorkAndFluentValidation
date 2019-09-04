using Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Meetups.Commands
{
    public abstract class BaseMeetupCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime DateStart { get; protected set; }
        public DateTime DateEnd { get; protected set; }
        public bool Free { get; protected set; }
        public decimal Price { get; protected set; }
        public string BusinessName { get; protected set; }
    }
}
