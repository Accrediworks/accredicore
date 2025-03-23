using Accredi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Accredi.Maui.Pages;

public partial class TenantsPage : ContentPage, ITransientDependency
{
	public TenantsPage(TenantsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
