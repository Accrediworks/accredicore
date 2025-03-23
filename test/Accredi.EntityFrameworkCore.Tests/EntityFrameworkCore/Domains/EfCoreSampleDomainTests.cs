using Accredi.Samples;
using Xunit;

namespace Accredi.EntityFrameworkCore.Domains;

[Collection(AccrediTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AccrediEntityFrameworkCoreTestModule>
{

}
