using Microsoft.EntityFrameworkCore;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models {
	public class ModelDatabase : DbContext {
		public DbSet<UserEntity> Users { get; set; }

		public ModelDatabase() {
			// ReSharper disable VirtualMemberCallInConstructor
			Database.EnsureCreated();
			// ReSharper restore VirtualMemberCallInConstructor
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			base.OnConfiguring(optionsBuilder);

			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserEntity>().HasIndex(user => user.Login).IsUnique();
		}
	}
}