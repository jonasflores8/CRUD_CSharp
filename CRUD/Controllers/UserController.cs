using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private const string Error = "User not found.";

		private static List<User> users = new List<User>()
		{
			new User()
			{
				Id = 1,
				FirstName = "Laura",
				LastName = "DCarmo",
				Place = "GotanCity"
			},

			new User()
			{
				Id = 2,
				FirstName = "Pedro",
				LastName = "Makarov",
				Place = "Moscow"
			}
		};

		[HttpGet]
		public async Task<ActionResult<List<User>>> GetUser()
		{
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUserId(int id)
		{
			var user = users.Find(x => x.Id == id);
			if(user == null)
				return BadRequest(Error);

			return Ok(user);
		}

		[HttpPost]
		public async Task<ActionResult<List<User>>> AddUser(User user) 
		{
			users.Add(user);
			return Ok(users); 
		}

		[HttpPut]
		public async Task<ActionResult<List<User>>> UpdateUser(User request)
		{
			var user = users.Find(x => x.Id == request.Id);
			if (user == null)
				return BadRequest(Error);

			user.FirstName = request.FirstName;
			user.LastName = request.LastName;
			user.Place = request.Place;

			return Ok(users);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<User>>> DeletelUser(int id)
		{
			var user = users.Find(x => x.Id == id);
			if (user == null)
				return BadRequest(Error);

			users.Remove(user);
			return Ok(users);
		}
	}
}
