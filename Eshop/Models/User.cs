

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

		//[Required]
		//[Datatype(DataType.Password)]
		//[Compare("Password")]
		public string Password { get; set; }

		public int BasketId { get; set; }


	}
}
