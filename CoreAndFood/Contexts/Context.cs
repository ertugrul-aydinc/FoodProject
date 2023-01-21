using CoreAndFood.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Contexts
{
	public class Context : DbContext
	{
		//public Context(DbContextOptions<Context> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CoreAndFoodDB");
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Food> Foods { get; set; }
		public DbSet<Admin> Admins { get; set; }
	}
}
