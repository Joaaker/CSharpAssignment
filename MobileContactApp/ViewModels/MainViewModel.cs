using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;

namespace MobileContactApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    public MainViewModel(ContactService contactService)
    {
        _contactService = contactService;
        UpdateContactList();
    }

    [ObservableProperty]
    private Contact _addContactForm = new();

    [ObservableProperty]
    private ObservableCollection<ContactObjects> _contactList = [];


    [RelayCommand]
    public void AddContact()
    {



    }




    public void UpdateContactList()
    {
        ContactList = new ObservableCollection<ContactObjects>(_contactService.Contacts.Select(contact => contact).ToList());
    }



}
