using CommunityToolkit.Mvvm.Input;
using Volo.Abp.DependencyInjection;
using Accredi.Maui.Oidc;

namespace Accredi.Maui.ViewModels;

public partial class MainPageViewModel : AccrediViewModelBase, ITransientDependency
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
