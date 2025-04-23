using System;
using System.Threading.Tasks;
using Accredi.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Accredi;

public class AccrediDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    public async Task SeedAsync(DataSeedContext context)
    {
       
    }
}