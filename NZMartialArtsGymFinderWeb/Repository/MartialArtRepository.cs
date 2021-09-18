using NZMartialArtsGymFinderWeb.Models;
using NZMartialArtsGymFinderWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NZMartialArtsGymFinderWeb.Repository
{
	public class MartialArtRepository : Repository<MartialArt>, IMartialArtRepository
	{
		public MartialArtRepository(IHttpClientFactory clientFactory) : base(clientFactory)
		{
		}
	}
}
