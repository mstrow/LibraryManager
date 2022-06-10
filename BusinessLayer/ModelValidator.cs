using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ModelValidator
    {
        /// <summary>
        /// List of validation errors from the last validation
        /// </summary>
        public ICollection<ValidationResult> Errors { get; }

        public ModelValidator()
        {
            Errors = new List<ValidationResult>();
        }

        public bool Validate(object model)
        {
            Errors.Clear();

            var context = new ValidationContext(model, null, null);

            return Validator.TryValidateObject(model, context, Errors, true);
        }
    }
}
