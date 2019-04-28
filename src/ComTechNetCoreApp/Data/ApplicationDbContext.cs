using ComTechNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ComTechNetCoreApp.Data
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Lecturer> Lecturers { get; set; }
		public DbSet<Subdivision> Subdivisions { get; set; }


		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}
}
