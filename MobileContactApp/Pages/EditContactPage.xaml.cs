using MobileContactApp.ViewModels;

namespace MobileContactApp.Pages;

public partial class EditContactPage : ContentPage
{
    public EditContactPage(EditContactViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}