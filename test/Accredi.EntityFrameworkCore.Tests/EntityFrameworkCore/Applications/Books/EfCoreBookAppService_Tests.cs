using Accredi.Books;
using Xunit;

namespace Accredi.EntityFrameworkCore.Applications.Books;

[Collection(AccrediTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<AccrediEntityFrameworkCoreTestModule>
{

}