using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class ChangePasswordPage : ContentPage, ITransientDependency
{
	public ChangePasswordPage(ChangePasswordViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}