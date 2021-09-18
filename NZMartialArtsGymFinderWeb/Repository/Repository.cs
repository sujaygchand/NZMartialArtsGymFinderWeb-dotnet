using NZMartialArtsGymFinderWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NZMartialArtsGymFinderWeb.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		public readonly IHttpClientFactory _clientFactory;

		public Repository(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public Task<bool> CreateAsync(string url, T objToCreate, string token)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAsync(string url, int id, string token)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<T>> GetAllAsync(string url, string token)
		{
			throw new NotImplementedException();
		}

		public Task<T> GetAsync(string url, int id, string token)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateAsync(string url, T objToUpdate, string token)
		{
			throw new NotImplementedException();
		}
	}
}
