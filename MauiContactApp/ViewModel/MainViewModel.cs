using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiContactApp.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Items = [];
    }

    [ObservableProperty]
    private ObservableCollection<string> items;

    [ObservableProperty]
    private string text = string.Empty;

    [RelayCommand]
    private void Add()
    {
        if (!string.IsNullOrWhiteSpace(Text))
        {
            Items.Add(Text);
            Text = string.Empty;
        }
    }
}
