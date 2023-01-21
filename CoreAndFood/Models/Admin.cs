using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Models
{
	public class Admin
	{
		public int Id { get; set; }

		[StringLength(20)]
		public string Username { get; set; }
		[StringLength(20)]
		public string Password { get; set; }
		[StringLength(1)]
		public string AdminRole { get; set; }
	}
}
