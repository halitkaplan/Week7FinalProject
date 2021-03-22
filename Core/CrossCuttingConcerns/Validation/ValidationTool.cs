using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity) // entity, dto hepsini kullanabilirim.
        {
            var context = new ValidationContext<object>(entity);    // entity, dto'da olabilir.
            var result = validator.Validate(context);               // validator, yaptık. ne gönderilirse
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
