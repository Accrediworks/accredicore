using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class IdentityUserPage : ContentPage, ITransientDependency
{
	public IdentityUserPage(IdentityUserPageViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
	}
}