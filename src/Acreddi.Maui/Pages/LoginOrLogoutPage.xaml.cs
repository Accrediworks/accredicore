using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class LoginOrLogoutPage : ContentPage, ITransientDependency
{
	public LoginOrLogoutPage(LoginOrLogoutViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}