using System.Security.Cryptography.X509Certificates;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            var keyVaultUri = KeyVaultUri(config);

            // Use DefaultAzureCredential which supports local dev + managed identity in Azure
            var credential = new DefaultAzureCredential();

            builder.AddAzureKeyVault(keyVaultUri, credential);
        });
    }

    public static OpenIddictServerBuilder AddAzureProductionEncryptionAndSigningCertificate(
        this OpenIddictServerBuilder builder, IConfiguration configuration)
    {
        var certificate = GetCertificateFromKeyVaultAsync(configuration);

        builder.AddSigningCertificate(certificate);
        builder.AddEncryptionCertificate(certificate);

        return builder;
    }

    private static Uri KeyVaultUri(IConfiguration configuration)
    {
        var keyVaultName = configuration["App:KeyVaultName"];
        if (string.IsNullOrWhiteSpace(keyVaultName))
        {
            throw new InvalidOperationException("App:KeyVaultName must be provided in configuration.");
        }

        var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");
        return keyVaultUri;
    }

    private static X509Certificate2 GetCertificateFromKeyVaultAsync(IConfiguration configuration)
    {
        var vaultUri = KeyVaultUri(configuration);
        var certificateName = configuration["AuthServerCertificate"];
        var secretClient = new SecretClient(vaultUri, new DefaultAzureCredential());
        var secret = secretClient.GetSecret($"{certificateName}").Value;

        // Decode the base64-encoded PFX
        var pfxBytes = Convert.FromBase64String(secret.Value);
        return X509CertificateLoader.LoadPkcs12(pfxBytes, string.Empty, X509KeyStorageFlags.MachineKeySet);
    }
}