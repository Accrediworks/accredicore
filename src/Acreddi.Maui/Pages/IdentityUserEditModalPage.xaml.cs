using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class IdentityUserEditModalPage : ContentPage, ITransientDependency
{
	public IdentityUserEditModalPage(IdentityUserEditViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}