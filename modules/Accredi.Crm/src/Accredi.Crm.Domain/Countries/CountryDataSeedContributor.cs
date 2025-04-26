using System.Threading.Tasks;
using Accredi.Crm.ContactLevels;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace Accredi.Crm.Countries;

/* Creates initial data that is needed to property run the application
 * and make client-to-server communication possible.
 */
public class CountryDataSeedContributor(
    ICountryRepository countryRepository,
    IGuidGenerator guidGenerator) : IDataSeedContributor, ITransientDependency
{
    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        var total = await countryRepository.GetCountAsync();

        if (total == 0)
        {
            await CreateCountryAsync("United Kingdom","GB","GBR");
        }
    }

    private async Task CreateCountryAsync(string name, string iso2Code, string iso3Code)
    {
        var id = guidGenerator.Create();
        var entity = new Country(id, name,  iso2Code,iso3Code);
        await countryRepository.InsertAsync(entity);
    }
}