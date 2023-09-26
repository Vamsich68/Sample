using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace Sample.Models
{
    public class Credential
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
