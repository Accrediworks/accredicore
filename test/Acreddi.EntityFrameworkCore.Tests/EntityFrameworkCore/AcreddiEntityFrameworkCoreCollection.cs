using Xunit;

namespace Acreddi.EntityFrameworkCore;

[CollectionDefinition(AcreddiTestConsts.CollectionDefinitionName)]
public class AcreddiEntityFrameworkCoreCollection : ICollectionFixture<AcreddiEntityFrameworkCoreFixture>
{

}
