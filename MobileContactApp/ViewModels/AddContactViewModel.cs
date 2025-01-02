using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MobileContactApp.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    [RelayCommand]
    //2 likadna funktoiner, SOLID??
    public static async Task NavigateToMainPage()
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}
