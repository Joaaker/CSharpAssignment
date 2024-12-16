using Shared.Models;
using Shared.Factories;
using Shared.Services;
using Shared.Interface;
using System.Data;

namespace ContactConsoleApp.Dialogs;

public class MenuDialog(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void ShowMenu()
    {
        while (true)
        {
            Menu();
        }
    }

    private void Menu()
    {
        Console.WriteLine($"{"1.",-2} Add a new contact");
        Console.WriteLine($"{"2.",-2} Show contact list");
        Console.WriteLine($"{"3.",-2} Get contact by ID");
        Console.WriteLine($"{"5.",-2} Exit program");
        Console.Write("Choose your menu option: ");
        var option = Console.ReadLine()!;

        switch (option.ToLower())
        {
            case "1":
                AddContact();
                break;

            case "2":
                ShowContactList();
                break;

            case "3":
                GetContactByID();
                break;

            case "5":
                ExitOption();
                break;

            default:
                InvalidOption();
                break;
        }
    }

    private void AddContact()
    {
        Console.Write("Enter a first name: ");
        string firstName = Console.ReadLine()!;

        Console.Write("Enter a last name: ");
        string lastName = Console.ReadLine()!;

        Console.Write("Enter an email address: ");
        string email = Console.ReadLine()!;

        Console.Write("Enter a phone number: ");
        var phoneNumber = Console.ReadLine()!;

        try
        {
            var newContact = ContactFactory.CreateContact(firstName, lastName, email, phoneNumber);
            _contactService.AddContact(newContact);
            Console.WriteLine("contact added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ShowContactList()
    {
        Console.Clear();
        var contacts = _contactService.GetAllContacts();


        if (contacts == null)
        {
            Console.WriteLine("No contacts found");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.Id}");
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}, Phone number: {contact.PhoneNumber}");
                Console.WriteLine("");
            }

        }
    }

    private void GetContactByID()
    {
        Console.Write("Enter contact ID:");
        var input = Console.ReadLine()!;

        if (input == null)
        {
            Console.WriteLine("Input cannot be empty");
        }
        else
        {
            try
            {
                var contact = _contactService.GetContactById(input);
                Console.WriteLine($"ID: {contact.Id}");
                Console.WriteLine($"First name: {contact.FirstName}, Last name: {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}, Phone number: {contact.PhoneNumber}");
                Console.WriteLine($"Date created: {contact.DateCreated}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private void ExitOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit this application? (y/n): ");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
        else if (option.Equals("n", StringComparison.CurrentCultureIgnoreCase))
        {
            ShowMenu();
        }
        else
        {
            Console.WriteLine("Invalid option, please try again.");
            ExitOption();
        }
    }
    private static void InvalidOption()
    {
        Console.WriteLine("Invalid option, please try again.");
    }
}