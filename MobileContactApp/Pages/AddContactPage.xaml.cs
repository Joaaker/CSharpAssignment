using MobileContactApp.ViewModels;

namespace MobileContactApp.Pages;

public partial class AddContactPage : ContentPage
{
	public AddContactPage(AddContactViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}