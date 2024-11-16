using System.ComponentModel.DataAnnotations;
using FilmApplication.Enums;

namespace FilmApplication.Models;

public class DataModel
{
    [Required(ErrorMessage = "Please enter your first name")] 
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your last name")] 
    public required string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your email")] 
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter your password")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "Please enter your password again")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public required string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Please enter your phone number")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Please enter your age")]
    [Range(10, 80, ErrorMessage = "Age must be between 10 and 80")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Please enter your city")]
    public City City { get; set; }
}