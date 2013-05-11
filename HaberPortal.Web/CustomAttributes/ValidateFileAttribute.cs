using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortal.Web.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidateFileAttribute : ValidationAttribute, IClientValidatable
    {
        public int MaxContentLength = int.MaxValue;
        public string[] AllowedFileExtensions;
        public string[] AllowedContentTypes;

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;

            //this should be handled by [Required]
            if (file == null)
                return true;

            if (file.ContentLength > MaxContentLength)
            {
                ErrorMessage = "Dosya boyutu izin verilen boyuttan çok büyük.";
                return false;
            }

            if (AllowedFileExtensions != null)
            {
                if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "İzin verilen dosya tipleri: " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
            }

            if (AllowedContentTypes != null)
            {
                if (!AllowedContentTypes.Contains(file.ContentType))
                {
                    ErrorMessage = "İzin verilen dosya tipleri: " + string.Join(", ", AllowedContentTypes);
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[]
            {
                new ModelClientValidationFileRule(FormatErrorMessage(
                    metadata.GetDisplayName()), 
                    MaxContentLength, 
                    AllowedFileExtensions, 
                    AllowedContentTypes)
            };
        }
    }

    public class ModelClientValidationFileRule
        : ModelClientValidationRule
    {
        public ModelClientValidationFileRule(string errorMessage,
                                                      int maxContentLength, string[] allowedFileExtensions, string[] allowedContentTypes)
        {
            ErrorMessage = errorMessage;
            ValidationType = "filevalidation";

            ValidationParameters["maxcontentlength"] = maxContentLength;
            ValidationParameters["allowedfileextensions"] = (allowedFileExtensions == null) ? "" : string.Join(", ", allowedFileExtensions);
            ValidationParameters["allowedcontenttypes"] = (allowedContentTypes == null) ? "" : string.Join(", ", allowedContentTypes);
        }
    }
}