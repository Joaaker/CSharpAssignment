using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MobileContactApp.ViewModels;

public partial class EditContactViewModel : ObservableObject
{
    [RelayCommand]
    public static async Task NavigateToMainPage()
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}
