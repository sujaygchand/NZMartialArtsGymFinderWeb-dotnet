using NZMartialArtsGymFinderWeb.Models;
using NZMartialArtsGymFinderWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NZMartialArtsGymFinderWeb.Repository
{
	public class RegionRepository : Repository<Region>, IRegionRepository
	{
		public RegionRepository(IHttpClientFactory clientFactory) : base(clientFactory)
		{
		}
	}
}
