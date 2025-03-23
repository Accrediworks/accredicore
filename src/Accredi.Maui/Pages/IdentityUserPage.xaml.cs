using Accredi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Accredi.Maui.Pages;

public partial class IdentityUserPage : ContentPage, ITransientDependency
{
	public IdentityUserPage(IdentityUserPageViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
	}
}