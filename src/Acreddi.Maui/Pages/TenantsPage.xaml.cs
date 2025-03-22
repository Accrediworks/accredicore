using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class TenantsPage : ContentPage, ITransientDependency
{
	public TenantsPage(TenantsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
