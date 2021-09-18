using Newtonsoft.Json;
using NZMartialArtsGymFinderWeb.Models;
using NZMartialArtsGymFinderWeb.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NZMartialArtsGymFinderWeb.Repository
{
	public class AccountRepository : Repository<User>, IAccountRepository
	{
		public AccountRepository(IHttpClientFactory clientFactory) : base(clientFactory)
		{

		}

		public async Task<User> LoginAsync(string url, User user)
		{
			if (user == null)
				return new User();

			var request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

			var client = _clientFactory.CreateClient();
			HttpResponseMessage response = await SendApiRequest(client, request);

			if (response.StatusCode != HttpStatusCode.OK)
				return new User();

			var jsonString = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<User>(jsonString);
		}

		public async Task<bool> RegisterAsync(string url, User userToCreate)
		{
			if (userToCreate == null)
				return false;

			var request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = new StringContent(JsonConvert.SerializeObject(userToCreate), Encoding.UTF8, "application/json");

			var client = _clientFactory.CreateClient();
			HttpResponseMessage response = await SendApiRequest(client, request);

			return response.StatusCode == HttpStatusCode.OK;
		}
	}
}
