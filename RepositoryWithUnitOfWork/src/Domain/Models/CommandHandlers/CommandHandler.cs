using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected void NotitifyErrorValidations(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
        }
    }
}
