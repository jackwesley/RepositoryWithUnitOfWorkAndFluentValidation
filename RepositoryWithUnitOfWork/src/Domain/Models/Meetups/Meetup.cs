using Domain.Core.Models;
using Domain.Models.Organizers;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Domain.Models.Meetups
{
    public class Meetup : Entity<Meetup>
    {
        public Meetup(string name,
                    string description,
                    DateTime dateStart,
                    DateTime dateEnd,
                    bool free,
                    decimal price,
                    string businessName)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Free = free;
            Price = price;
            BusinessName = businessName;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public bool Free { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        public Adress Adress { get; private set; }
        public Organizer Organizer { get; private set; }
        public string BusinessName { get; private set; }

        public override bool IsValid()
        {
            Validate();

            return ValidationResult.IsValid;
        }


        #region Validations

        private void Validate()
        {
            ValidateName();
            ValidadeDescription();
            ValidadePrice();
            ValidadeDate();
            ValidationResult = Validate(this);
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name can not be null")
                .Length(2, 150).WithMessage("Name lenght must be between 2 and 150 characters");

        }

        private void ValidadeDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Description can not be null")
                .Length(2, 150).WithMessage("Description lenght must be between 2 and 150 characters");

        }

        private void ValidadePrice()
        {
            if (!Free)
            {
                RuleFor(c => c.Price)
                    .ExclusiveBetween(1, 50000).WithMessage("Price must be between 1 and 50000");
            }

            if (Free)
            {
                RuleFor(c => c.Price)
                    .ExclusiveBetween(0, 0)
                    .When(e => e.Free)
                    .WithMessage("Price must be between 1 and 50000");
            }
        }

        private void ValidadeDate()
        {
            RuleFor(c => c.DateStart)
                .GreaterThan(c => c.DateEnd)
                .WithMessage("DateStart must be greater than DateEnd");

            RuleFor(c => c.DateStart)
                .GreaterThan(DateTime.Now).WithMessage("Data Start can not be in the past");

        }

        #endregion
    }
}
