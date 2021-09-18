using NZMartialArtsGymFinderWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZMartialArtsGymFinderWeb.Repository.IRepository
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> LoginAsync(string url, User user);
		Task<bool> RegisterAsync(string url, User userToCreate);
	}
}
