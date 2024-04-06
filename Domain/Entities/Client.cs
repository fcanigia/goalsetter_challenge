using System.ComponentModel.DataAnnotations.Schema;

namespace GoalsetterChallenge.Domain.Entities;

public class Client
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public bool IsRemoved { get; set; } = false;

    [NotMapped]
    public string FullName {
        get
        {
            return $"{LastName} {FirstName}";
        }
    }
}

