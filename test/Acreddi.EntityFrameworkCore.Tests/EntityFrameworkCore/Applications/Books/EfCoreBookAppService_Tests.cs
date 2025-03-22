using Acreddi.Books;
using Xunit;

namespace Acreddi.EntityFrameworkCore.Applications.Books;

[Collection(AcreddiTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<AcreddiEntityFrameworkCoreTestModule>
{

}