﻿using System.ComponentModel.DataAnnotations;
using Microsoft.Performance.SDK.Processing;

namespace Microsoft.Performance.Toolkit.Plugins.Cli
{
    public class PluginManifestValidator
        : IPluginManifestValidator
    {
        private readonly ILogger logger;

        public PluginManifestValidator(Func<Type, ILogger> loggerFactory)
        {
            this.logger = loggerFactory(typeof(PluginManifestValidator));
        }

        public bool Validate(
            PluginManifest pluginManifest)
        {
            var validationContext = new ValidationContext(pluginManifest);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(pluginManifest, validationContext, validationResults, true);
            if (!isValid)
            {
                foreach (var validationResult in validationResults)
                {
                    this.logger.Error(validationResult.ErrorMessage);
                }

                return false;
            }

            return true;
        }
    }
}
