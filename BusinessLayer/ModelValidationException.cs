using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ModelValidationException : Exception
    {
        public ICollection<ValidationResult> Errors { get; }


        public ModelValidationException()
        {
        }

        public ModelValidationException(string message, ICollection<ValidationResult> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
