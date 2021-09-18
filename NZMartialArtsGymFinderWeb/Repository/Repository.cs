using Newtonsoft.Json;
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
	public class Repository<T> : IRepository<T> where T : class
	{
		public readonly IHttpClientFactory _clientFactory;

		public Repository(IHttpClientFactory clientFactory)
		{
			_clientFactory = clientFactory ?? throw new Exception("HttpClientFactory does not exist in scope");
		}

		public void AuthenticateBearerToken(ref HttpClient client, string token)
		{
			if (token == null || token.Length < 1 || client == null)
				return;

			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
		}

		public async Task<bool> CreateAsync(string url, T objToCreate, string token = "")
		{
			var request = new HttpRequestMessage(HttpMethod.Post, url);

			if (objToCreate == null)
				return false;

			request.Content = new StringContent(JsonConvert.SerializeObject(objToCreate), Encoding.UTF8, "application/json");

			var client = _clientFactory.CreateClient();
			AuthenticateBearerToken(ref client, token);

			HttpResponseMessage response = await SendApiRequest(client, request);
			return response.StatusCode == HttpStatusCode.Created;
		}

		public async Task<bool> DeleteAsync(string url, int id, string token = "")
		{
			var request = new HttpRequestMessage(HttpMethod.Delete, url+id);
			var client = _clientFactory.CreateClient();
			AuthenticateBearerToken(ref client, token);
			
			HttpResponseMessage response = await SendApiRequest(client, request);
			return response.StatusCode == HttpStatusCode.NoContent;
		}

		public async Task<IEnumerable<T>> GetAllAsync(string url, string token = "")
		{
			var request = new HttpRequestMessage(HttpMethod.Get, url);

			var client = _clientFactory.CreateClient();
			AuthenticateBearerToken(ref client, token);
			HttpResponseMessage response = await SendApiRequest(client, request);

			if (response.StatusCode != HttpStatusCode.OK)
				return null;

			var jsonString = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
		}

		public async Task<T> GetAsync(string url, int id, string token = "")
		{
			var request = new HttpRequestMessage(HttpMethod.Get, url+id);
			var client = _clientFactory.CreateClient();

			AuthenticateBearerToken(ref client, token);
			HttpResponseMessage response = await SendApiRequest(client, request);

			if (response.StatusCode != HttpStatusCode.OK)
				return null;

			var jsonString = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(jsonString);
		}

		public async Task<bool> UpdateAsync(string url, T objToUpdate, string token = "")
		{
			var request = new HttpRequestMessage(HttpMethod.Patch, url);

			if (objToUpdate == null)
				return false;

			request.Content = new StringContent(JsonConvert.SerializeObject(objToUpdate), Encoding.UTF8, "application/json");

			var client = _clientFactory.CreateClient();
			AuthenticateBearerToken(ref client, token);
			HttpResponseMessage response = await SendApiRequest(client, request);

			return response.StatusCode == HttpStatusCode.NoContent;
		}

		private async Task<HttpResponseMessage> SendApiRequest(HttpClient client, HttpRequestMessage request)
		{
			if (client == null)
				return null;

			return await client.SendAsync(request);
		}
	}
}
