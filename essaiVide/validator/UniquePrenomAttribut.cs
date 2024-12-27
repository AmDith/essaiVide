using Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Validator
{
    public class UniquePrenomAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var clientService = (IClientService)validationContext.GetService(typeof(IClientService));
            var surnom = (string)value;

            if (clientService.GetClientsAsync().Result.Any(c => c.Prenom == surnom))
            {
                return new ValidationResult("Ce surnom est déjà utilisé.");
            }

            return ValidationResult.Success;
        }
    }
}