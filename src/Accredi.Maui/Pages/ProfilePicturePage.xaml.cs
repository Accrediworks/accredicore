using Accredi.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace Accredi.Maui.Pages;

public partial class ProfilePicturePage : ContentPage, ITransientDependency
{
    public ProfilePicturePage(ProfilePictureViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}