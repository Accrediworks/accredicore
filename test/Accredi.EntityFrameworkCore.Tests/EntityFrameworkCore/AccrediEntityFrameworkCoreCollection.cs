using Xunit;

namespace Accredi.EntityFrameworkCore;

[CollectionDefinition(AccrediTestConsts.CollectionDefinitionName)]
public class AccrediEntityFrameworkCoreCollection : ICollectionFixture<AccrediEntityFrameworkCoreFixture>
{

}
