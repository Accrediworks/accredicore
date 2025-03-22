using Acreddi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Acreddi.Maui;

public partial class MainPage : ContentPage, ITransientDependency
{
    public MainPage(
		MainPageViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
    }
}