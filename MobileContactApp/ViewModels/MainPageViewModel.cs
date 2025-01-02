using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MobileContactApp.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    [RelayCommand]
    public static async Task NavigateToAddContactPage()
    {
        await Shell.Current.GoToAsync("AddContactPage");
    }
}
