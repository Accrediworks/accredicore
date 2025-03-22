using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class TenantEditPage : ContentPage, ITransientDependency
{
	public TenantEditPage(TenantEditViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}
