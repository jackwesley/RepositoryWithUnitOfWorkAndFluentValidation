using Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime TimeStamp { get; private set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
