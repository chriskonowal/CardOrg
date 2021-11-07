using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg.ValidationAttributes
{
    /// <summary>
    /// The allowed extensions attribute
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllowedExtensionsAttribute"/> class.
        /// </summary>
        /// <param name="extensions">The extensions.</param>
        public AllowedExtensionsAttribute(string[] extensions)
        {
            _extensions = extensions;
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult" /> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <returns></returns>
        public string GetErrorMessage()
        {
            return $"This photo extension is not allowed!";
        }
    }
}
