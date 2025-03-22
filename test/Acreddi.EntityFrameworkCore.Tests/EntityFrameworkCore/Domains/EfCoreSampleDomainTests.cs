using Acreddi.Samples;
using Xunit;

namespace Acreddi.EntityFrameworkCore.Domains;

[Collection(AcreddiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AcreddiEntityFrameworkCoreTestModule>
{

}
