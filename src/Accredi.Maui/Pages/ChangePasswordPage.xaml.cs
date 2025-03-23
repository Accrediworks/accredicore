using Accredi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Accredi.Maui.Pages;

public partial class ChangePasswordPage : ContentPage, ITransientDependency
{
	public ChangePasswordPage(ChangePasswordViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}