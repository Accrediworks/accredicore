using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui.Pages;

public partial class SettingsPage : ContentPage, ITransientDependency
{
	public SettingsPage(SettingsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}