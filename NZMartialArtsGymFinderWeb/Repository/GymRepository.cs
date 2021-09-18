using NZMartialArtsGymFinderWeb.Models;
using NZMartialArtsGymFinderWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NZMartialArtsGymFinderWeb.Repository
{
	public class GymRepository : Repository<Gym>, IGymRepository
	{
		public GymRepository(IHttpClientFactory clientFactory) : base(clientFactory)
		{
		}
	}
}
