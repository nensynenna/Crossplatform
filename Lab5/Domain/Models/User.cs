using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Domain.Models;

public class IdentityCustomUser : IdentityUser
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
}


