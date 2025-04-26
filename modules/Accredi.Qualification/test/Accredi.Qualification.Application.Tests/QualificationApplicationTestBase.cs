using Volo.Abp.Modularity;

namespace Accredi.Qualification;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class QualificationApplicationTestBase<TStartupModule> : QualificationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
