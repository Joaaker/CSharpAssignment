namespace Shared.Models;

public class ContactObjects(string id, string firstName, string lastName, string email, string phoneNumber, string address, string zipCode, string city)
{
    public string Id { get; init; } = id;
    public string? FirstName { get; set; } = firstName;
    public string? LastName { get; set; } = lastName;
    public string? Email { get; set; } = email;
    public string? PhoneNumber { get; set; } = phoneNumber;
    public string? Address { get; set; } = address;
    public string? ZipCode { get; set; } = zipCode;
    public string? City { get; set; } = city;
    public DateTime DateCreated { get; init; } = DateTime.Now;
}