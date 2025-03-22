using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class IdentityUserCreateModalPage : ContentPage, ITransientDependency
{
    public IdentityUserCreateModalPage(IdentityUserCreateViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}