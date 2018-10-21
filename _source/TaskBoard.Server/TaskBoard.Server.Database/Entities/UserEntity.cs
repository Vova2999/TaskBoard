using System;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Server.Database.Entities {
	public class UserEntity {
		[Key]
		public Guid Id { get; set; }

		[Required, MaxLength(64)]
		public string Login { get; set; }

		[Required, MaxLength(64)]
		public string Password { get; set; }
	}
}