using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class TenantCreatePage : ContentPage, ITransientDependency
{
    public TenantCreatePage(TenantCreateViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}
