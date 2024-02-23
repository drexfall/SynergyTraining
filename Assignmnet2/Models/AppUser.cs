using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models;

public class AppUser
{public AppUser()
    {

    }
    public AppUser(string role)
    {
        Role = role;
    }

    [Key]
    public string Role { get; set; }
    public bool IsAuthenticated { get; set; }
}