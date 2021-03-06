using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrchardCore.Commerce.Abstractions;
using OrchardCore.Entities;
using OrchardCore.Settings;

namespace OrchardCore.Commerce.Services
{
    public class CommerceSettingsConfiguration : IConfigureOptions<CommerceSettings>
    {
        private readonly ISiteService _site;
        private readonly ILogger<CommerceSettingsConfiguration> _logger;

        public CommerceSettingsConfiguration(
            ISiteService site,
            ILogger<CommerceSettingsConfiguration> logger)
        {
            _site = site;
            _logger = logger;
        }

        public void Configure(CommerceSettings options)
        {
            var settings = _site.GetSiteSettingsAsync()
                .GetAwaiter().GetResult()
                .As<CommerceSettings>();

            options.DefaultCurrency = settings.DefaultCurrency;
        }
    }
}
