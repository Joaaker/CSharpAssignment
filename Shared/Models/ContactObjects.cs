namespace Shared.Models;

public class ContactObjects(string id, string firstName, string lastName, string email, string phoneNumber)
{
    public string Id { get; init; } = id;
    public string? FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
    public string? Email { get; set; } = email;
    public string? PhoneNumber { get; set; } = phoneNumber;
    public DateTime DateCreated { get; init; } = DateTime.Now;
}