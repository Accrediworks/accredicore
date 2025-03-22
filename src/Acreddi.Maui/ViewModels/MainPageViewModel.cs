using CommunityToolkit.Mvvm.Input;
using Volo.Abp.DependencyInjection;
using Acreddi.Maui.Oidc;

namespace Acreddi.Maui.ViewModels;

public partial class MainPageViewModel : AcreddiViewModelBase, ITransientDependency
{
    protected ILoginService LoginService { get; }
    
    public MainPageViewModel(ILoginService loginService)
    {
        LoginService = loginService;
    }

    [RelayCommand]
    async Task SeeAllUsers()
    {
        await Shell.Current.GoToAsync("///users");
    }
    
    [RelayCommand]
    async Task Login()
    {
        await Shell.Current.GoToAsync("///login");
    }
}
