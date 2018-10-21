using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Server.Database.Entities;
using TaskBoard.Server.Database.Models;

namespace TaskBoard.Server.Controllers {
	[Route("api/values"), ApiController]
	public class ValuesController : ControllerBase {
		[HttpGet]
		public ActionResult<IEnumerable<UserEntity>> Get() {
			using (var modelDatabase = new ModelDatabase())
				return modelDatabase.Users.ToArray();
		}
		
		[HttpGet("{id}")]
		public ActionResult<UserEntity> Get(Guid id) {
			using (var modelDatabase = new ModelDatabase())
				return modelDatabase.Users.FirstOrDefault(user => user.Id == id);
		}
		
		[HttpPost]
		public void Post([FromBody] UserEntity value) {
			using (var modelDatabase = new ModelDatabase()) {
				modelDatabase.Users.Add(value);
				modelDatabase.SaveChanges();
			}
		}
		
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] UserEntity value) {
		}
		
		[HttpDelete("{id}")]
		public void Delete(Guid id) {
			using (var modelDatabase = new ModelDatabase()) {
				var deletedUser = modelDatabase.Users.FirstOrDefault(user => user.Id == id);
				if (deletedUser == null)
					return;

				modelDatabase.Users.Remove(deletedUser);
				modelDatabase.SaveChanges();
			}
		}
	}
}