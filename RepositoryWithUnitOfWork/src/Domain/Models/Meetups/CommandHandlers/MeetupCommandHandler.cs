using Domain.Core.Events;
using Domain.Models.CommandHandlers;
using Domain.Models.Meetups.Commands;
using Domain.Models.Meetups.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Meetups.CommandHandlers
{
    public class MeetupCommandHandler : 
               CommandHandler,
               IHandler<RegisterMeetupCommand>,
               IHandler<UpdateMeetupCommand>,
               IHandler<DeleteMeetupCommand>
    {
        private readonly IMeetupRepository _meetupRepository;
        public MeetupCommandHandler(IMeetupRepository meetupRepository)
        {
            _meetupRepository = meetupRepository;
        }

        public void Handle(RegisterMeetupCommand message)
        {
            var meetup = new Meetup(
                message.Name,
                message.Description,
                message.DateStart,
                message.DateEnd,
                message.Free,
                message.Price,
                message.BusinessName
                );

            if (!meetup.IsValid())
            {
                NotitifyErrorValidations(meetup.ValidationResult);
                return;
            }

            //Add others validations

            //Persistence
            _meetupRepository.Add(meetup);
        }

        public void Handle(UpdateMeetupCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(DeleteMeetupCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
