using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public User User { get; set;}
        public Role Role {get; set;}
    }
}