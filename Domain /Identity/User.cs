using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class User : IdentityUser<int>
    {
        [Column("USER_ID")]
        [Display(Name = "Código")]
        public override int Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string FullName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}