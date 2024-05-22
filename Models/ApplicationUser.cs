using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Yamine.Models;

public class ApplicationUser : IdentityUser
{
    [JsonIgnore, IgnoreDataMember, NotMapped]
    public string Name
    {
        get
        {
            return UserName;
        }
        set
        {
            UserName = value;
        }
    }
}
