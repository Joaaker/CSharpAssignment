using Shared.Models;
using Shared.Factories;
using Shared.Services;

namespace ContactConsole.Services;

public class MenuService
{
    private readonly FileService _fileService;
    public MenuService()
    {
        _fileService = new FileService();
    }

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


        var newcontact = ContactFactory.CreateContact(firstName, lastName, email, phoneNumber);

        var contacts = _fileService.ReadContactsFromFile();
        contacts.Add(newcontact);
        _fileService.SaveContactsToFile(contacts);

        Console.WriteLine("contact added successfully!");

    }

    private void ShowContactList()
    {
        Console.Clear();
        var contacts = _fileService.ReadContactsFromFile();

        if (contacts == null || contacts.Count == 0)
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
        var contacts = _fileService.ReadContactsFromFile();
        Console.Write("Enter contact ID:");
        var input = Console.ReadLine()!;
        if (input == null)
        {
            Console.WriteLine("Input cannot be empty");
        }
        else
        {
            foreach (var contact in contacts)
            {
                if (contact.Id == input)
                {
                    Console.Write($"ID: {contact.Id}");
                    Console.Write($"First name: {contact.FirstName}, Last name: {contact.LastName}");
                    Console.Write($"Email: {contact.Email}, Phone number: {contact.PhoneNumber}");
                    Console.Write($"Date created: {contact.DateCreated}");
                    Console.WriteLine("");
                }
            }
        }
    }

    private void ExitOption()
    {
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
