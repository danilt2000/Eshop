

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Models

{
	public class User : IdentityUser 
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }

		public string PhoneNumber { get; set; }
	}
}
