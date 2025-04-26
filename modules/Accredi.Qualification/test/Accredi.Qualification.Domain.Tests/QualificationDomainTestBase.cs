using Volo.Abp.Modularity;

namespace Accredi.Qualification;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class QualificationDomainTestBase<TStartupModule> : QualificationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
