using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Accredi.Azure;

public static class ConfigurationBuilderExtensions
{
    public static IHostBuilder AddAzureKeyVault(
        this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureAppConfiguration((_, builder) =>
        {
            var config = builder.Build();

            var keyVaultName = config["App:KeyVaultName"];
            if (string.IsNullOrWhiteSpace(keyVaultName))
            {
                throw new InvalidOperationException("App:KeyVaultName must be provided in configuration.");
            }

            var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");

            // Use DefaultAzureCredential which supports local dev + managed identity in Azure
            var credential = new DefaultAzureCredential();

            builder.AddAzureKeyVault(keyVaultUri, credential);
        });
    }
}